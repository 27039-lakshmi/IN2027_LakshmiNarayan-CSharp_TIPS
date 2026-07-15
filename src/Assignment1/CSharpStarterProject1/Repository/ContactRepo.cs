using ContactManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ContactManager.Repository
{
    /// <summary>
    /// Provides methods for storing and managing contacts in memory.
    /// </summary>
    internal class ContactRepo
    {
        private List<Contact> _contacts = new List<Contact>();

        /// <summary>
        /// Adds a contact to the repository.
        /// </summary>
        /// <param name="contact">
        /// The contact to add.
        /// </param>
        public void Add(Contact contact)
        {
            _contacts.Add(contact);
        }

        /// <summary>
        /// Retrieves all contacts from the repository.
        /// </summary>
        /// <returns>
        /// A collection of all contacts.
        /// </returns>
        public List<Contact> GetAll()
        {
            return _contacts;
        }

        /// <summary>
        /// Searches for a contact by its unique identifier.
        /// </summary>
        /// <param name="id">
        /// The unique identifier of the contact to find.
        /// </param>
        /// <returns>
        /// The matching contact if found; otherwise, <c>null</c>.
        /// </returns>
        public Contact Search(Guid id)
        {
            return _contacts.Find(c => c.Id == id);
        }

        /// <summary>
        /// Removes a contact from the repository.
        /// </summary>
        /// <param name="id">
        /// The unique identifier of the contact to remove.
        /// </param>
        public void Delete(Guid id)
        {
            Contact contact = Search(id);

            if (contact != null)
            {
                _contacts.Remove(contact);
            }
        }

        /// <summary>
        /// Updates an existing contact in the repository.
        /// </summary>
        /// <param name="contact">
        /// The contact containing the updated information.
        /// </param>
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

        /// <summary>
        /// Gets the total number of contacts in the repository.
        /// </summary>
        /// <returns>
        /// The number of contacts stored in the repository.
        /// </returns>
        public int ContactCount()
        {
            return _contacts.Count();
        }
    }
}