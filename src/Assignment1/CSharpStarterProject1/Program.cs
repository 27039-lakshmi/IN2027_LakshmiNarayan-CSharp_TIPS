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
            UserViewer view = new UserViewer();

            while (true)
            {
                Console.WriteLine(" 1. Add Contact\n 2. Edit Contact\n 3. Delete Contact\n 4. Search Contact\n " +
                    "5. Display All Contacts\n 6. Exit  \n");
                Console.Write(" Enter Choice : ");
                int choice = int.Parse(Console.ReadLine() ?? "0");

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
                        view.DisplayAllContacts();
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