using AddressBook.Domain.Interfaces;
using AddressBook.Model.Models;
using AddressBook.Repository.EfCore;
using AddressBook.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook.Domain.Implementation
{
    public class AuthenticationServices : IAuthorizationServices
    {
        private ILoginCredentialsDbContext _credentialsRepo;
        public AuthenticationServices(ILoginCredentialsDbContext credentialsRepo) {
            _credentialsRepo = credentialsRepo;
        }

        public void RegisterUser(UserRegister LoginInfo)
        {
            _credentialsRepo.RegisterUser(LoginInfo);
        }
        public bool IsRegistered(UserLoginDto user)
        {
            return _credentialsRepo.IsRegistered(user);
        }
        
        public string GetUserRole(UserLoginDto user)
        {
            return _credentialsRepo.GetUserRole(user);
        }
    }
}
