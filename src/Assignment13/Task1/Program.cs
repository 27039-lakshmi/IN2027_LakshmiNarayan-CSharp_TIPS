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
            try
            {
                var listRepository = new BookListRepository<string>();
                var listService = new BookListService(listRepository);
                var controller = new BookListConsole(listService);
                controller.Start();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}