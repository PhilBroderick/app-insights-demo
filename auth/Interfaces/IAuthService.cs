using auth.Entities;
using auth.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace auth.Interfaces
{
    public interface IAuthService
    {
        LoginResponse Login(LoginRequest model);
        User GetById(int userId);
    }
}
