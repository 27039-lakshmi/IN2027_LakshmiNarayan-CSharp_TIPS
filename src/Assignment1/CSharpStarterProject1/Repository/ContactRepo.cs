using ContactManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactManager.Repository
{
    internal class ContactRepo
    {


        private List<Contact> contacts = new List<Contact>();



        public void Add(Contact contact)

        {

            contacts.Add(contact);

        }



        public List<Contact> GetAll()

        {

            return contacts;

        }



        public Contact Search(Guid id)

        {

            return contacts.Find(c => c.Id == id);

        }



        public void Delete(Guid id)

        {

            Contact contact = Search(id);



            if (contact != null)

            {

                contacts.Remove(contact);

            }

        }



        public void Update(Contact contact)

        {

            Contact existing = Search(contact.Id);



            if (existing != null)

            {

                existing.Name = contact.Name;

                existing.PhoneNumbers = contact.PhoneNumbers;

                existing.Emails = contact.Emails;

            }

        }

        public int ContactCount()
        {
            return contacts.Count();
        }

    }
}
