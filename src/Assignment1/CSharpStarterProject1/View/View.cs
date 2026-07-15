using ContactManager.Helper;
using ContactManager.Models;
using ContactManager.Services;
using System.Numerics;
namespace ContactManager.View
{
    internal class View
    {
        ContactService service = new ContactService();
        Validate helper= new Validate();
        public void Start()

        {

            while (true)

            {
                Console.WriteLine("1. Add Contact");
                Console.WriteLine("2. Edit Contact");
                Console.WriteLine("3. Delete Contact");
                Console.WriteLine("4. Search Contact");
                Console.WriteLine("5. Display All Contacts");
                Console.WriteLine("6. Exit");

                Console.Write("Enter Choice : ");
                Console.WriteLine();
                
                int choice = int.Parse(Console.ReadLine());

                switch (choice)

                {

                    case 1:

                        AddContact();
                        break;

                    case 2:

                        EditContact();
                        break;

                    case 3:

                        DeleteContact();
                        break;

                    case 4:

                        SearchContact();
                        break;

                    case 5:

                        DisplayAll();
                        break;

                    case 6:

                        return;

                    default:

                        Console.WriteLine("Invalid Choice");
                        break;

                }

            }

        }

        private void AddContact()

        {
            string phone,email;
            Contact contact = new Contact();

            contact.Id =Guid.NewGuid();

            Console.Write("Enter Name : ");
            contact.Name = Console.ReadLine();

            Console.Write("How many Phone Numbers : ");
            int phoneCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < phoneCount; i++)
            {
                do
                {
                    Console.Write($"Phone {i + 1} : ");
                    phone = Console.ReadLine();
                    string message = service.PhoneNumberValidity(contact, phone);
                    if (message != "")
                    {
                        Console.WriteLine(message);
                    }
                    
                }
                while (!helper.IsPhoneNumberValid(phone));
            }

            Console.Write("How many Email IDs : ");
            int emailCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < emailCount; i++)

            {
                do
                {
                    Console.Write($"Email {i + 1} : ");
                    email = Console.ReadLine();
                    string message = service.EmailValidity(contact, email);
                    if (message != "")
                    {
                        Console.WriteLine(message);
                    }
                }
                while (!helper.IsEmailValid(email));
            }

            service.AddContact(contact);
            Console.WriteLine("Contact Added Successfully.");
        }

        private void EditContact()
        {
            string phone, email; 
            if (service.ContactCount() != 0)
            {
                Contact contact = new Contact();
                Console.Write("Enter Contact ID : ");
                contact.Id = Guid.Parse(Console.ReadLine());

                Contact findContact = service.SearchContact(contact.Id);

                if (findContact == null)
                {
                    Console.WriteLine("Contact Not Found.");
                    return;
                }
                else
                {
                    Console.Write("Enter New Name : ");
                    contact.Name = Console.ReadLine();

                    Console.Write("How many Phone Numbers : ");
                    int phoneCount = int.Parse(Console.ReadLine());

                    for (int i = 0; i < phoneCount; i++)
                    {

                        bool isValid;

                        do
                        {
                            Console.Write($"Phone {i + 1} : ");
                            phone = Console.ReadLine();

                            string message = service.PhoneNumberValidity(contact, phone);
                            if (message != "")
                            {
                                Console.WriteLine(message);
                            }

                        } while (!isValid);
                    }

                    Console.Write("How many Email IDs : ");
                    int emailCount = int.Parse(Console.ReadLine());


                    for (int i = 0; i < emailCount; i++)
                    {
                        do
                        {
                            Console.Write($"Email {i + 1} : ");
                            email = Console.ReadLine();
                            string message = service.EmailValidity(contact, email);
                            if (message != "")
                            {
                                Console.WriteLine(message);
                            }
                        }
                        while (!helper.IsEmailValid(email));
                    }

                    service.EditContact(contact);
                    Console.WriteLine("Contact Updated Successfully.");
                }
            }
            else
            {
                Console.WriteLine("No contacts to edit\n");
            }
        }

        private void DeleteContact()
        {
            if (service.ContactCount() != 0)
            {
                Console.Write("Enter Contact ID : ");
                Guid id = Guid.Parse(Console.ReadLine());
                Contact findContact = service.SearchContact(id);

                if (findContact == null)
                {
                    Console.WriteLine("Contact Not Found.");
                    return;
                }
                else
                {
                    service.DeleteContact(id);
                }
                Console.WriteLine("Contact Deleted.");
            }
            else { Console.WriteLine("No contacts to delete\n"); }

        }

        private void SearchContact()

        {
            if (service.ContactCount() != 0)
            {
                Console.Write("Enter Contact ID : ");
                Guid id = Guid.Parse(Console.ReadLine());

                Contact contact = service.SearchContact(id);

                if (contact == null)
                {
                    Console.WriteLine("Contact Not Found.");
                    return;
                }

                Console.WriteLine("\nID : " + contact.Id);
                Console.WriteLine("Name : " + contact.Name);
                Console.WriteLine("\nPhone Numbers");
                foreach (string phone in contact.PhoneNumbers)
                {
                    Console.WriteLine(phone);
                }

                Console.WriteLine("\nEmail IDs");
                foreach (string email in contact.Emails)
                {
                    Console.WriteLine(email);
                }
            }
            else
            {
                Console.WriteLine("No contacts to search\n");
            }
        }

        private void DisplayAll()
        {
            List<Contact> contacts = service.GetAllContacts();
            if (contacts.Count == 0)
            {
                Console.WriteLine("No Contacts Available.");
                return;
            }

            foreach (Contact contact in contacts)
            {
                Console.WriteLine("ID : " + contact.Id);
                Console.WriteLine("Name : " + contact.Name);
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
            }
        }
    }
}
