using ContactManager.Helper;
using ContactManager.Models;
using ContactManager.Services;

namespace ContactManager.View
{
    /// <summary>
    /// Provides a console-based user interface for managing contacts.
    /// </summary>
    internal class UserViewer
    {
        /// <summary>
        /// Provides contact management operations.
        /// </summary>
        private readonly ContactService _service = new ContactService();

        /// <summary>
        /// Provides validation for contact information.
        /// </summary>
        private readonly Validator _helper = new Validator();

        /// <summary>
        /// Collects contact details from the user and adds a new contact.
        /// </summary>
        internal void AddContact()
        {
            Contact contact = this.GetInfo();
            this._service.AddContact(contact);
            Console.WriteLine("Contact Added Successfully.");
        }

        /// <summary>
        /// Updates the details of an existing contact.
        /// </summary>
        internal void EditContact()
        {
            if (this._service.CountContact() != 0)
            {
                var contact = new Contact();

                Console.Write("Enter Contact Phone : ");
                contact.PhoneNumbers.Add(Console.ReadLine() ?? "0");

                Contact? findContact = this._service.SearchContact(contact.PhoneNumbers[0]);

                if (findContact == null)
                {
                    Console.WriteLine("Contact Not Found.");
                    return;
                }

                this.GetInfo(findContact);
                this._service.EditContact(findContact, contact);
                Console.WriteLine("Contact Updated Successfully.");
            }
            else
            {
                Console.WriteLine("No contacts to edit");
            }
        }

        /// <summary>
        /// Deletes a contact identified by its unique identifier.
        /// </summary>
        internal void DeleteContact()
        {
            if (this._service.CountContact() != 0)
            {
                Console.Write("Enter Contact Phone Number : ");
                string phone = Console.ReadLine() ?? string.Empty;

                Contact? findContact = this._service.SearchContact(phone!);

                if (findContact == null)
                {
                    Console.WriteLine("Contact Not Found.");
                    return;
                }

                this._service.DeleteContact(phone);
                Console.WriteLine("Contact Deleted.");
            }
            else
            {
                Console.WriteLine("No contacts to delete");
            }
        }

        /// <summary>
        /// Searches for a contact by its unique identifier and displays the details.
        /// </summary>
        internal void SearchContact()
        {
            if (this._service.CountContact() != 0)
            {
                Console.Write("Enter Contact Name : ");
                string name = Console.ReadLine() ?? string.Empty;
                List<Contact> contacts = this._service.SearchContactByName(name!);

                if (contacts == null)
                {
                    Console.WriteLine("Contact Not Found.");
                    return;
                }

                Console.WriteLine("Contacts starting with " + name);

                foreach (Contact contact in contacts)
                {
                    Console.WriteLine($"\nName : {contact.Name}");
                    Console.WriteLine("Phone Numbers");

                    foreach (string phone in contact.PhoneNumbers)
                    {
                        Console.WriteLine(phone);
                    }
                }
            }
            else
            {
                Console.WriteLine("No contacts to search");
            }
        }

        /// <summary>
        /// Displays all contacts stored in the application.
        /// </summary>
        internal void DisplayAll()
        {
            var contacts = this._service.GetAllContacts();

            if (contacts.Count == 0)
            {
                Console.WriteLine("No Contacts Available.");
                return;
            }

            foreach (Contact contact in contacts)
            {
                Console.WriteLine($"Name : {contact.Name}");

                Console.WriteLine("Phone Numbers");

                foreach (string phone in contact.PhoneNumbers)
                {
                    Console.WriteLine(phone);
                }

                Console.WriteLine("Email IDs");

                foreach (string email in contact.Emails)
                {
                    Console.WriteLine(email);
                }

                Console.WriteLine();
            }
        }

        private Contact GetInfo(Contact? contact = null)
        {
            if (contact == null)
            {
                contact = new Contact();
            }

            if (contact.Id == Guid.Empty)
            {
                contact.Id = Guid.NewGuid();
            }

            Console.Write("Enter Name : ");
            contact.Name = Console.ReadLine();

            Console.Write("How many Phone Numbers : ");
            string phoneNumberCountInput = Console.ReadLine() ?? "0";
            if (!int.TryParse(phoneNumberCountInput, out int phoneNumberCount))
            {
                Console.WriteLine("Enter a valid number");
            }

            string message;
            for (int i = 0; i < phoneNumberCount; i++)
            {
                do
                {
                    Console.Write($"Phone {i + 1} : ");
                    string phoneNumber = Console.ReadLine() ?? string.Empty;
                    message = this._service.ValidatePhoneNumber(contact, phoneNumber);
                    if (!string.IsNullOrEmpty(message))
                    {
                        Console.WriteLine(message);
                    }
                }
                while (!string.IsNullOrEmpty(message));
            }

            Console.Write("How many Email IDs : ");
            string emailCountInput = Console.ReadLine() ?? "0";
            if (!int.TryParse(emailCountInput, out int emailCount))
            {
                Console.WriteLine("Enter a valid number");
            }

            for (int i = 0; i < emailCount; i++)
            {
                do
                {
                    Console.Write($"Email {i + 1} : ");
                    string email = Console.ReadLine() ?? string.Empty;

                    message = this._service.EmailValidity(contact, email);

                    if (!string.IsNullOrEmpty(message))
                    {
                        Console.WriteLine(message);
                    }
                }
                while (!string.IsNullOrEmpty(message));
            }

            return contact;
        }
    }
}