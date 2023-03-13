using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook.Model.Models
{
    public class ViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        public string Mobile { get; set; }

        public string LandLine { get; set; }

        public string Website { get; set; }

        public AddressModel Address { get; set; }
    }
}
