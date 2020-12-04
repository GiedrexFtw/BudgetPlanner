using ComView.Dto;
using ComView.Models;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComView.Data
{
    public class SqlUserRepo : IUserRepo
    {
        private readonly ApplicationContext _appContext;
        public SqlUserRepo(ApplicationContext appContext)
        {
            _appContext = appContext;
        }
        public User GetUserById(int id)
        {
            return _appContext.Users.Find(id);
        }

        public User GetUserByCredentials(UserLoginDto user)
        {
            return _appContext.Users.FirstOrDefault(u => u.Username == user.Username && u.Password == user.Password);
        }
        public User GetUserByUsername(string username)
        {
            return _appContext.Users.FirstOrDefault(u => u.Username == username);
        }

        public bool UserExists(UserLoginDto user)
        {
            return _appContext.Users.Any(u => u.Username == user.Username && u.Password == user.Password);
        }
        public void UpdateUser(User user)
        {
            _appContext.Users.Update(user);
        }
        public void SaveChanges()
        {
            _appContext.SaveChanges();
        }
    }
}
