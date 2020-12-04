using ComView.Data;
using ComView.Dto;
using ComView.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ComView.Authentication
{
    public interface IJwtAuthenticationManager
    {
       AuthResponse Authenticate(User user);
       AuthResponse Authenticate(User user, IUserRepo userRepo, Claim[] claims);
    }
}
