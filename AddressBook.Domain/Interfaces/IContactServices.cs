using AddressBook.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook.Domain.Interfaces
{
    public interface IContactServices
    {
        List<UserContact> GetContacts();
        void AddContact(UserContact contact);

        public void UpdateContact(UserContact contact, int id);
        public UserContact GetContact(int id);

        public void DeleteContact(int id);



    }
}
