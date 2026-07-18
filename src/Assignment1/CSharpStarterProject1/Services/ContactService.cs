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
        /// <summary>
        /// Repository used to store and retrieve contacts.
        /// </summary>
        private readonly ContactRepo _repo = new ContactRepo();
        private readonly Validate _helper = new Validate();

        /// <summary>
        /// Retrieves all contacts.
        /// </summary>
        /// <returns>A list containing all contacts.</returns>
        public List<Contact> GetAllContacts()
        {
            return _repo.GetAll();
        }

        /// <summary>
        /// Adds a new contact to the repository.
        /// </summary>
        /// <param name="contact">The contact to be added.</param>
        public void AddContact(Contact contact)
        {
            this._repo.Add(contact);
        }

        /// <summary>
        /// Updates an existing contact with new information.
        /// </summary>
        /// <param name="findContact">
        /// The existing contact that should be updated.
        /// </param>
        /// <param name="contact">
        /// The contact containing the updated values.
        /// </param>
        public void EditContact(Contact findContact, Contact contact)
        {
            this._repo.Update(findContact, contact);
        }

        /// <summary>
        /// Deletes a contact using a phone number.
        /// </summary>
        /// <param name="phone">
        /// A phone number belonging to the contact to be deleted.
        /// </param>
        public void DeleteContact(string phone)
        {
            this._repo.Delete(phone);
        }

        /// <summary>
        /// Searches for a contact using a phone number.
        /// </summary>
        /// <param name="phone">
        /// The phone number used to search for the contact.
        /// </param>
        /// <returns>
        /// The matching contact if found; otherwise <c>null</c>.
        /// </returns>
        public Contact? SearchContact(string phone)
        {
            return this._repo.Search(phone);
        }

        /// <summary>
        /// Searches contacts whose names start with the specified text.
        /// </summary>
        /// <param name="name">
        /// The name or partial name to search for.
        /// </param>
        /// <returns>
        /// A list of matching contacts.
        /// </returns>
        public List<Contact> SearchContactByName(string name)
        {
            List<Contact> contacts = new ();

            foreach (Contact contact in this._repo.GetAll())
            {
                if (contact.Name!.ToLower().StartsWith(name.ToLower()))
                {
                    contacts.Add(contact);
                }
            }

            return contacts;
        }

        /// <summary>
        /// Gets the total number of contacts stored in the repository.
        /// </summary>
        /// <returns>The number of contacts.</returns>
        public int ContactCount()
        {
            return this._repo.ContactCount();
        }

        /// <summary>
        /// Validates a phone number and adds it to the specified contact.
        /// </summary>
        /// <param name="contact">
        /// The contact to which the phone number will be added.
        /// </param>
        /// <param name="phone">
        /// The phone number to validate.
        /// </param>
        /// <returns>
        /// An empty string if validation succeeds; otherwise an error message.
        /// </returns>
        public string PhoneNumberValidity(Contact contact, string phone)
        {
            if (_helper.IsPhoneNumberValid(phone))
            {
                if (!IsPhoneExist(phone))
                {
                    contact.PhoneNumbers.Add(phone);
                    return string.Empty;
                }

                return "Phone Number already exist";
            }

            return "Enter a valid phone number";
        }

        /// <summary>
        /// Validates an email address and adds it to the specified contact.
        /// </summary>
        /// <param name="contact">
        /// The contact to which the email address will be added.
        /// </param>
        /// <param name="email">
        /// The email address to validate.
        /// </param>
        /// <returns>
        /// An empty string if validation succeeds; otherwise an error message.
        /// </returns>
        public string EmailValidity(Contact contact, string email)
        {
            if (this._helper.IsEmailValid(email))
            {
                if (!IsEmailExist(email))
                {
                    contact.Emails.Add(email);
                    return string.Empty;
                }

                return "Email already exist";
            }

            return "Enter a valid email";
        }

        /// <summary>
        /// Determines whether the specified phone number already exists.
        /// </summary>
        /// <param name="phone">
        /// The phone number to search for.
        /// </param>
        /// <returns>
        /// <c>true</c> if the phone number exists; otherwise <c>false</c>.
        /// </returns>
        public bool IsPhoneExist(string phone)
        {
            foreach (Contact contact in this._repo.GetAll())
            {
                if (contact.PhoneNumbers.Contains(phone))
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Determines whether the specified email address already exists.
        /// </summary>
        /// <param name="email">
        /// The email address to search for.
        /// </param>
        /// <returns>
        /// <c>true</c> if the email address exists; otherwise <c>false</c>.
        /// </returns>
        public bool IsEmailExist(string email)
        {
            foreach (Contact contact in this._repo.GetAll())
            {
                if (contact.Emails.Contains(email))
                {
                    return true;
                }
            }

            return false;
        }
    }
}