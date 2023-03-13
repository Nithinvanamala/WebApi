using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook.Repository.EfCore
{
    public class ContactDepartmentDbContext
    {
        private ApplicationDbContext _context;
        public ContactDepartmentDbContext(ApplicationDbContext context)
        {
            _context = context;
        }

    }
}
