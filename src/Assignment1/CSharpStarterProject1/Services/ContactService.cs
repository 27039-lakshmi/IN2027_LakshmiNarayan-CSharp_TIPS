using ContactManager.Helper;
using ContactManager.Models;
using ContactManager.Repository;

namespace ContactManager.Services
{
    /// <summary>
    /// Provides business logic operations for managing contacts.
    /// </summary>
    internal class ContactService
    {
        private readonly ContactRepo _repo = new ContactRepo();

        /// <summary>
        /// Retrieves all contacts.
        /// </summary>
        /// <returns>
        /// A collection of all contacts.
        /// </returns>
        public List<Contact> GetAllContacts()
        {
            return _repo.GetAll();
        }

        /// <summary>
        /// Adds a new contact.
        /// </summary>
        /// <param name="contact">
        /// The contact to add.
        /// </param>
        public void AddContact(Contact contact)
        {
            _repo.Add(contact);
        }

        /// <summary>
        /// Updates an existing contact.
        /// </summary>
        /// <param name="contact">
        /// The contact containing the updated information.
        /// </param>
        public void EditContact(Contact contact)
        {
            _repo.Update(contact);
        }

        /// <summary>
        /// Deletes a contact by its unique identifier.
        /// </summary>
        /// <param name="id">
        /// The unique identifier of the contact to delete.
        /// </param>
        public void DeleteContact(Guid id)
        {
            _repo.Delete(id);
        }

        /// <summary>
        /// Searches for a contact by its unique identifier.
        /// </summary>
        /// <param name="id">
        /// The unique identifier of the contact to search for.
        /// </param>
        /// <returns>
        /// The matching contact if found; otherwise, <c>null</c>.
        /// </returns>
        public Contact SearchContact(Guid id)
        {
            return _repo.Search(id);
        }

        /// <summary>
        /// Gets the total number of contacts.
        /// </summary>
        /// <returns>
        /// The total number of contacts.
        /// </returns>
        public int ContactCount()
        {
            return _repo.ContactCount();
        }

        /// <summary>
        /// Validates and adds a phone number to the specified contact.
        /// </summary>
        /// <param name="contact">
        /// The contact to which the phone number is added.
        /// </param>
        /// <param name="phone">
        /// The phone number to validate.
        /// </param>
        /// <returns>
        /// An empty string if the phone number is valid; otherwise, an error message.
        /// </returns>
        public string PhoneNumberValidity(Contact contact, string phone)
        {
            Validate helper = new Validate();

            if (helper.IsPhoneNumberValid(phone))
            {
                contact.PhoneNumbers.Add(phone);
                return string.Empty;
            }

            return "Enter a valid phone number";
        }

        /// <summary>
        /// Validates and adds an email address to the specified contact.
        /// </summary>
        /// <param name="contact">
        /// The contact to which the email address is added.
        /// </param>
        /// <param name="email">
        /// The email address to validate.
        /// </param>
        /// <returns>
        /// An empty string if the email address is valid; otherwise, an error message.
        /// </returns>
        public string EmailValidity(Contact contact, string email)
        {
            Validate helper = new Validate();

            if (helper.IsEmailValid(email))
            {
                contact.Emails.Add(email);
                return string.Empty;
            }

            return "Enter a valid email";
        }
    }
}