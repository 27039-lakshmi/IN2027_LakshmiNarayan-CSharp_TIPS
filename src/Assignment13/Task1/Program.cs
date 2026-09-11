using Task1.Application;
using Task1.Infrastructure;
using Task1.Presentation;

namespace Assignments
{
    /// <summary>
    /// Entry point of the Book List application.
    /// Responsible for creating application dependencies and
    /// starting the console-based user interface.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Main method that initializes the repository, service,
        /// and presentation layers, then starts the application.
        /// </summary>
        /// <param name="args">
        /// Command-line arguments passed to the application.
        /// </param>
        private static void Main(string[] args)
        {
            BookListRepository<string> listRepository = new ();
            BookListService listService = new (listRepository);
            BookListConsole controller = new (listService);

            controller.Start();
        }
    }
}