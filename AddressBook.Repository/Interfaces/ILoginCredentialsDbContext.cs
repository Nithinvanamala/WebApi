using AddressBook.Model.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook.Repository.Interfaces
{
    public interface ILoginCredentialsDbContext
    {
        public void RegisterUser(UserRegister LoginInfo);

        public bool IsRegistered(UserLoginDto user);

        public string GetUserRole(UserLoginDto user);
        

    }
}
