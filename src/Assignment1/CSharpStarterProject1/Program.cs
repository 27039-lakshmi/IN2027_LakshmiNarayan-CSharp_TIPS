using System.Xml.Linq;
using ContactManager.Models;
using ContactManager.Services;
using ContactManager.View;

namespace Assignments
{
    /// <summary>
    /// Represents the entry point of the Contact Manager application.
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// Displays the main menu and handles user interactions for managing contacts.
        /// </summary>
        /// <param name="args">
        /// Command-line arguments passed to the application.
        /// </param>
        public static void Main(string[] args)
        {
            ContactService contactService = new ContactService();
            View view = new View();

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
                        view.AddContact();
                        break;

                    case 2:
                        view.EditContact();
                        break;

                    case 3:
                        view.DeleteContact();
                        break;

                    case 4:
                        view.SearchContact();
                        break;

                    case 5:
                        view.DisplayAll();
                        break;

                    case 6:
                        return;

                    default:
                        Console.WriteLine("Invalid Choice");
                        break;
                }
            }
        }
    }
}