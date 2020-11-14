using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using ComView.Authentication;
using ComView.Data;
using ComView.Dto;
using ComView.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace ComView.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUserRepo _userRepo;
        private readonly IJwtAuthenticationManager _jwtAuthenticationManager;
        private readonly ITokenRefresher _tokenRefresher;

        public LoginController(IUserRepo userRepo, IJwtAuthenticationManager jwtAuthenticationManager, ITokenRefresher tokenRefresher)
        {
            _userRepo = userRepo;
            _jwtAuthenticationManager = jwtAuthenticationManager;
            _tokenRefresher = tokenRefresher;
        }
        // GET: LoginController
        [AllowAnonymous]
        [HttpPost("/api/authenticate")]
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
