using AddressBook.Domain.Interfaces;
using AddressBook.Model.Models;
using AddressBook.Repository.EfCore;
using AddressBook.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook.Domain.Implementation
{
    public  class ContactServices : IContactServices
    {
        private IContactDbContext _context;
       
        public ContactServices(IContactDbContext context )
        {
            this._context = context;
            
        }

        public List<UserContact> GetContacts()
        {
            return _context.GetContacts();
        }

        public  void AddContact(UserContact contact)
        {
             _context.AddContact(contact);
            //( (ApplicationDbContext) _context).SaveChanges();
            //( (ApplicationDbContext) _context).SaveChanges();
           // _context2.SaveChanges();
        }

        public UserContact GetContact(int id)
        {
            return _context.GetContact(id);
        }

        public void UpdateContact(UserContact contact,int id) {
            _context.UpdateContact(contact, id);
        }

        public void DeleteContact(int id)
        {
             _context.DeleteContact(id);
        }
    }
}
