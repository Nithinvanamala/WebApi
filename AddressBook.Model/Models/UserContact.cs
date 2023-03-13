using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook.Model.Models
{
    [Table("UserContact")]
    public  class UserContact
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        public string Mobile { get; set; }

        public string LandLine { get; set; }

        public string Website { get; set; }

        public string Address { get; set; }
    }
}
