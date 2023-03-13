using AddressBook.Model.Models;
using AddressBook.Repository.Interfaces;
using Dapper.Contrib.Extensions;
using SimpleInjector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook.Repository.Dapper
{
    public class ContactsDbContextRepo : IContactDbContext
    {

        private DapperDbContext _context;
        public ContactsDbContextRepo(Container container) {
            _context = container.GetInstance<DapperDbContext>();
        }   
        public void AddContact(UserContact contact)
        {
            _context.Connection.Insert(contact);
        }

        public void DeleteContact(int id)
        {
            
            _context.Connection.Delete(_context.Connection.Get<UserContact>(id));
        }

        public UserContact GetContact(int id)
        {
            return _context.Connection.Get<UserContact>(id);
        }

        public List<UserContact> GetContacts()
        {
           return _context.Connection.GetAll<UserContact>().ToList();
        }

        public void UpdateContact(UserContact contact, int id)
        {
            contact.Id = id;    
            _context.Connection.Update(contact);
        }
    }
}
