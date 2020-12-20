using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using ComView.Authentication;
using ComView.Data;
using ComView.Dto;
using ComView.Models;
using ComViewAPI.Dto.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace ComView.Controllers
{
    [ApiController]
    public class LoginController : Controller
    {
        private readonly IUserRepo _userRepo;
        private readonly IJwtAuthenticationManager _jwtAuthenticationManager;
        private readonly ITokenRefresher _tokenRefresher;
        private readonly IMapper _mapper;

        public LoginController(IUserRepo userRepo, IJwtAuthenticationManager jwtAuthenticationManager, ITokenRefresher tokenRefresher, IMapper mapper)
        {
            _userRepo = userRepo;
            _jwtAuthenticationManager = jwtAuthenticationManager;
            _tokenRefresher = tokenRefresher;
            _mapper = mapper;
        }
        // GET: LoginController
        [AllowAnonymous]
        [HttpPost("/api/login")]
        public IActionResult Authenticate([FromBody] UserLoginDto userDto)
        {
            User user = _userRepo.GetUserByCredentials(userDto);
            if (user == null)
            {
                return Unauthorized();
            }
            var tokens = _jwtAuthenticationManager.Authenticate(user);
            if(tokens != null)
            {
                user.RefToken = tokens.RefToken;
                _userRepo.UpdateUser(user);
                _userRepo.SaveChanges();

                return Ok(tokens);
            }
            return Unauthorized();

        }

        [AllowAnonymous]
        [HttpPost("/api/register")]
        public IActionResult Register([FromBody] UserRegisterDto userdto)
        {
            bool isValid = _userRepo.Validate(userdto);
            if (!isValid || !ModelState.IsValid)
            {
                return Unauthorized();
            }
            User user = _mapper.Map<User>(userdto);
            user.IsAdmin = false;
            
            //user.RefToken = tokens.RefToken;
            _userRepo.AddUser(user);
            _userRepo.SaveChanges();
            var tokens = _jwtAuthenticationManager.Authenticate(user);
            
            user.RefToken = tokens.RefToken;
            _userRepo.UpdateUser(user);
            _userRepo.SaveChanges();
            return Ok(tokens);
        }

        [AllowAnonymous]
        [HttpPost("/api/refresh")]
        public IActionResult RefreshToken([FromBody]AuthResponse tokens)
        {
            var refreshedTokens = _tokenRefresher.Refresh(tokens, _userRepo);
            if(refreshedTokens != null)
            {
                return Ok(refreshedTokens);
            }
            return Unauthorized();
            
        }
    }
}
