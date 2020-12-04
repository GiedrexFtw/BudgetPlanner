using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ComView.Dto;
using ComView.Models;

namespace ComView.Data
{
    public interface IUserRepo
    {
        User GetUserById(int id);
        User GetUserByCredentials(UserLoginDto userDto);
        bool UserExists(UserLoginDto user);
        void UpdateUser(User user);
        User GetUserByUsername(string username);
        void SaveChanges();
    }
}
