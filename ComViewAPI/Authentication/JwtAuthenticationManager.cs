using ComView.Data;
using ComView.Dto;
using ComView.Models;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ComView.Authentication
{
    public class JwtAuthenticationManager : IJwtAuthenticationManager
    {
        private readonly string _key;
        private static readonly RefreshTokenGenerator refreshTokenGenerator = new RefreshTokenGenerator();
        public JwtAuthenticationManager(string key)
        {
            _key = key;
        }
        public AuthResponse Authenticate(User user, IUserRepo userRepo, Claim[] claims)
        {
            var jwtSecurityToken = new JwtSecurityToken(

                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(1),
                signingCredentials: new SigningCredentials(
                    new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_key)), SecurityAlgorithms.HmacSha256Signature)
            ) ;
            var token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
            var refToken = refreshTokenGenerator.GenerateToken();
            if(refToken != null)
            {
                user.RefToken = refToken;
                userRepo.UpdateUser(user);
                userRepo.SaveChanges();
            }

            return new AuthResponse(token, refToken);
        }
        public AuthResponse Authenticate(User user)
        {
            
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenKey = Encoding.ASCII.GetBytes(_key);
            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = new System.Security.Claims.ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Username),
                    new Claim(ClaimTypes.Role, user.IsAdmin ? "Admin" : "User")
                }),
                Expires = DateTime.UtcNow.AddMinutes(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature)
            };
            Console.WriteLine(tokenDescriptor.Expires);
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var refToken = refreshTokenGenerator.GenerateToken();

            return new AuthResponse(tokenHandler.WriteToken(token), refToken);
        }
    }
}
