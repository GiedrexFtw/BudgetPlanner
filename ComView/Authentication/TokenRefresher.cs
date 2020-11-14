using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ComView.Data;
using ComView.Models;

namespace ComView.Authentication
{
    public class TokenRefresher : ITokenRefresher
    {
        private readonly string _key;
        private readonly IJwtAuthenticationManager _jwtAuthenticationManager;
        public TokenRefresher(string key, IJwtAuthenticationManager jwtAuthenticationManager)
        {
            _key = key;
            _jwtAuthenticationManager = jwtAuthenticationManager;
        }
        public AuthResponse Refresh(AuthResponse tokens, IUserRepo userRepo)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            SecurityToken validatedToken;
            var principal = tokenHandler.ValidateToken(tokens.JwtToken,
                new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                {
                    ValidateAudience = false,
                    ValidateIssuer = false,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_key))
                }, out validatedToken) ;
            var jwtToken = validatedToken as JwtSecurityToken;
            if(jwtToken == null || !jwtToken.Header.Alg.Equals("HS256"))
            {
                return null;
            }
            var username = principal.Identity.Name;
            User user = userRepo.GetUserByUsername(username);
            if(user.RefToken != tokens.RefToken)
            {
                return null;
            }
            
            return _jwtAuthenticationManager.Authenticate(user, userRepo, principal.Claims.ToArray());
        }
    }
}
