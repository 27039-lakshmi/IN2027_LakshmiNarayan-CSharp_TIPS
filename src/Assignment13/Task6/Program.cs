using Task6.Application;
using Task6.Presentation;

namespace Assignments
{
    /// <summary>
    /// Entry point of the Collection Operations application.
    /// Responsible for creating application dependencies
    /// and starting the console-based demonstration.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Initializes the application service and presentation layer,
        /// then starts the application.
        /// </summary>
        /// <param name="args">
        /// Command-line arguments passed to the application.
        /// </param>
        private static void Main(string[] args)
        {
            try
            {
                var collectionService = new CollectionService();
                var collectionConsole = new CollectionConsole(collectionService);
                collectionConsole.Start();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}