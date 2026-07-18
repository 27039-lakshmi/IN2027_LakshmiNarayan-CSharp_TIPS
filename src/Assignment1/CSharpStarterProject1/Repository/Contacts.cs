using ContactManager.Models;

namespace ContactManager.Repository
{
    /// <summary>
    /// Provides methods for storing and managing contacts in memory.
    /// </summary>
    internal class Contacts
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
            this._contacts.Add(contact);
        }

        /// <summary>
        /// Retrieves all contacts from the repository.
        /// </summary>
        /// <returns>
        /// A collection of all contacts.
        /// </returns>
        public List<Contact> GetAll()
        {
            return this._contacts;
        }

        /// <summary>
        /// Searches for a contact by its unique identifier.
        /// </summary>
        /// <param name="phone">
        /// The unique identifier of the contact to find.
        /// </param>
        /// <returns>
        /// The matching contact if found; otherwise, <c>null</c>.
        /// </returns>
        public Contact Search(string phone)
        {
            return this._contacts.Find(c => c.PhoneNumbers.Contains(phone)) !;
        }

        /// <summary>
        /// Removes a contact from the repository.
        /// </summary>
        /// <param name="phone">
        /// The unique identifier of the contact to remove.
        /// </param>
        public void Delete(string phone)
        {
            Contact contact = this.Search(phone);

            if (contact != null)
            {
                this._contacts.Remove(contact);
            }
        }

        /// <summary>
        /// Updates an existing contact in the repository.
        /// </summary>
        /// <param name="findContact">
        /// The existing contact that needs to be updated.
        /// </param>
        /// <param name="contact">
        /// The contact containing the updated information.
        /// </param>
        public void Update(Contact findContact, Contact contact)
        {
            Contact existing = this.Search(findContact.PhoneNumbers[0]);

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
            return this._contacts.Count();
        }
    }
}