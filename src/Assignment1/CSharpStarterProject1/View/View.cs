using ContactManager.Helper;
using ContactManager.Models;
using ContactManager.Services;

namespace ContactManager.View
{
    /// <summary>
    /// Provides a console-based user interface for managing contacts.
    /// </summary>
    internal class View
    {
        /// <summary>
        /// Provides contact management operations.
        /// </summary>
        private readonly ContactService _service = new ContactService();

        /// <summary>
        /// Provides validation for contact information.
        /// </summary>
        private readonly Validate _helper = new Validate();

        /// <summary>
        /// Collects contact details from the user and adds a new contact.
        /// </summary>
        internal void AddContact()
        {
            string phone;
            string email;
            Contact contact = new Contact();

            contact.Id = Guid.NewGuid();

            Console.Write("Enter Name : ");
            contact.Name = Console.ReadLine();

            Console.Write("How many Phone Numbers : ");
            string phoneCountInput = Console.ReadLine() ?? "0";
            if (!int.TryParse(phoneCountInput, out int phoneCount))
            {
                Console.WriteLine("Enter a valid number");
            }

            string message;
            for (int i = 0; i < phoneCount; i++)
            {
                do
                {
                    Console.Write($"Phone {i + 1} : ");
                    phone = Console.ReadLine() ?? string.Empty;
                    message = this._service.PhoneNumberValidity(contact, phone);
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
                    email = Console.ReadLine() ?? string.Empty;

                    message = this._service.EmailValidity(contact, email);

                    if (!string.IsNullOrEmpty(message))
                    {
                        Console.WriteLine(message);
                    }
                }
                while (!string.IsNullOrEmpty(message));
            }

            this._service.AddContact(contact);
            Console.WriteLine("Contact Added Successfully.");
        }

        /// <summary>
        /// Updates the details of an existing contact.
        /// </summary>
        internal void EditContact()
        {
            string phone;
            string email;

            if (this._service.ContactCount() != 0)
            {
                Contact contact = new Contact();

                Console.Write("Enter Contact Phone : ");
                contact.PhoneNumbers.Add(Console.ReadLine() ?? "0");

                Contact? findContact = this._service.SearchContact(contact.PhoneNumbers[0]);

                if (findContact == null)
                {
                    Console.WriteLine("Contact Not Found.");
                    return;
                }

                Console.Write("Enter New Name : ");
                contact.Name = Console.ReadLine();

                Console.Write("How many Phone Numbers : ");
                string phoneCountInput = Console.ReadLine() ?? "0";
                if (!int.TryParse(phoneCountInput, out int phoneCount))
                {
                    Console.WriteLine("Enter a valid number");
                }

                for (int i = 0; i < phoneCount; i++)
                {
                    do
                    {
                        Console.Write($"Phone {i + 1} : ");
                        phone = Console.ReadLine() ?? string.Empty;

                        string message = this._service.PhoneNumberValidity(contact, phone);

                        if (!string.IsNullOrEmpty(message))
                        {
                            Console.WriteLine(message);
                        }
                    }
                    while (!this._helper.IsPhoneNumberValid(phone));
                }

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
                        email = Console.ReadLine() ?? string.Empty;

                        string message = this._service.EmailValidity(contact, email);

                        if (!string.IsNullOrEmpty(message))
                        {
                            Console.WriteLine(message);
                        }
                    }
                    while (!this._helper.IsEmailValid(email));
                }

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
            if (this._service.ContactCount() != 0)
            {
                Console.Write("Enter Contact Phone Number : ");
                string phone = Console.ReadLine();

                Contact? findContact = this._service.SearchContact(phone);

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
            if (this._service.ContactCount() != 0)
            {
                Console.Write("Enter Contact Name : ");
                string name = Console.ReadLine();
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
            List<Contact> contacts = this._service.GetAllContacts();

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
    }
}