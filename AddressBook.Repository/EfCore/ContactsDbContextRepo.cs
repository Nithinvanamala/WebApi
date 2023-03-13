using AddressBook.Model.Models;
using AddressBook.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook.Repository.EfCore
{
    public class ContactsDbContextRepo : IContactDbContext
    {

        private ApplicationDbContext _context;
        public ContactsDbContextRepo(ApplicationDbContext context) { 
            _context= context;
        }

        public List<UserContact> GetContacts()
        {
            return _context.UserContacts.ToList();
        }

        public async void AddContact(UserContact contact)
        {
            _context.UserContacts.Add(contact);
            _context.SaveChanges();

        }

        public UserContact GetContact(int id)
        {
            return _context.UserContacts.FirstOrDefault(x => x.Id == id);
        }

        public void UpdateContact(UserContact contact, int id)
        {
            contact.Id = id;
            _context.UserContacts.Update(contact);
            _context.SaveChanges();
        }

        public void DeleteContact(int id)
        {
            _context.UserContacts.Remove(_context.UserContacts.SingleOrDefault(contact => contact.Id == id));
            _context.SaveChanges();


            /// ApplicationDbContext
            /// Repos
            /// DapperDbContext
            /// Repos

        }
    }
}
