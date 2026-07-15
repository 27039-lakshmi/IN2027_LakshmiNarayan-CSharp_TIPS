using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactManager.Models
{/// <summary>
 /// Joins a first name and a last name together into a single string.
 /// </summary>

    internal class Contact
    {
        
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public List<string> PhoneNumber { get; set; } = new List<string>(); 
        public List<string> Email { get; set; }= new List<string>();
        public string? Notes { get; set; }

        public  Contact ( string name,List<string> phoneNumber, List<string> email, string notes )
        {
            Id= Guid.NewGuid();
            Name = name;
            PhoneNumber = phoneNumber;
            Email = email;
            Notes = notes;
        }
    }
}
