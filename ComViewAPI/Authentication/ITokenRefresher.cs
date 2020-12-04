using ComView.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComView.Authentication
{
    public interface ITokenRefresher
    {
        AuthResponse Refresh(AuthResponse tokens, IUserRepo userRepo);
    }
}
