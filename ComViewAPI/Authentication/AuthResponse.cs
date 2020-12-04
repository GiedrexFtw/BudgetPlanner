using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComView.Authentication
{
    public class AuthResponse
    {
        public string JwtToken { get; set; }
        public string RefToken { get; set; }

        public AuthResponse(string jwtToken, string refToken)
        {
            JwtToken = jwtToken;
            RefToken = refToken;
        }
        public AuthResponse()
        {

        }
    }
}
