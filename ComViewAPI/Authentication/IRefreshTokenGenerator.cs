using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComView.Authentication
{
    interface IRefreshTokenGenerator
    {
        string GenerateToken();
    }
}
