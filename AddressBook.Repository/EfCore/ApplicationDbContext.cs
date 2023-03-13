using AddressBook.Model.Models;
using AddressBook.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook.Repository.EfCore
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) {
        }


        public DbSet<UserContact> UserContacts { get; set; }

        public DbSet<ContactDepartment> ContactDepartments { get; set;}

        public DbSet<UserRegister> LoginCredentials { get; set; }


    }
}
