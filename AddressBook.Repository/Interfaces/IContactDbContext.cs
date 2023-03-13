using AddressBook.Model.Models;
using AddressBook.Repository.EfCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook.Repository.Interfaces
{
    public  interface IContactDbContext 
    {
        List<UserContact> GetContacts();
        void AddContact(UserContact contact);

        public void UpdateContact(UserContact contact, int id);

        public UserContact GetContact(int id);

        public void DeleteContact(int id);
    }
}
