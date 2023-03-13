using AddressBook.Model.Models;
using AddressBook.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook.Repository.EfCore
{
    public class LoginCredentialsRepo : ILoginCredentialsDbContext
    {
        private ApplicationDbContext _context;
        public LoginCredentialsRepo(ApplicationDbContext context)
        {
            _context = context;
        }

        public void RegisterUser(UserRegister LoginInfo)
        {
            _context.LoginCredentials.Add(LoginInfo);
            _context.SaveChanges();
        }

        public bool IsRegistered(UserLoginDto user)
        {

            return _context.LoginCredentials.Any(obj => obj.UserName== user.UserName && obj.Password == user.Password);
            
        }

        public string GetUserRole(UserLoginDto user) { 
            return (_context.LoginCredentials.FirstOrDefault(obj => obj.UserName == user.UserName && obj.Password == user.Password)).Role;
        }

    }
}
