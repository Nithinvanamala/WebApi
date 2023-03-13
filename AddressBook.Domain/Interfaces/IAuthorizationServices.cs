using AddressBook.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook.Domain.Interfaces
{
    public interface IAuthorizationServices
    {

         void RegisterUser(UserRegister LoginInfo);

         bool IsRegistered(UserLoginDto user);


         string GetUserRole(UserLoginDto user);
        
    }
}
