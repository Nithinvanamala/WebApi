using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook.Model.Models
{
    public class ContactDepartment
    {
        [Key]
        public int Id { get; set; }
        public string Department { get; set; }
    }
}
