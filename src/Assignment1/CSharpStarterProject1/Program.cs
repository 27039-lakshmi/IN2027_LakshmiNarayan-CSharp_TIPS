using System.Xml.Linq;
using ContactManager.Models;
using ContactManager.Services;
using ContactManager.View;

namespace Assignments
{
    /// <summary>
    /// Entry point for the Contact Manager application.
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// Starts the Contact Manager application and launches the user interface.
        /// </summary>
        /// <param name="args">
        /// Command-line arguments passed to the application.
        /// </param>
        public static void Main(string[] args)
        {
            ContactService contactService = new ContactService();
            View view = new View();

            view.Start();
        }
    }
}