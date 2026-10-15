using Task3.Application;
using Task3.Infrastructure;
using Task3.Presentation;

namespace Assignments
{
    /// <summary>
    /// Entry point of the Queue Management application.
    /// Responsible for creating application dependencies
    /// and starting the console-based interface.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Initializes the infrastructure, application,
        /// and presentation layers, then starts the application.
        /// </summary>
        /// <param name="args">
        /// Command-line arguments passed to the application.
        /// </param>
        private static void Main(string[] args)
        {
            try
            {
                var personQueueRepository = new PeopleQueueRepository<string>();
                var peopleQueueService = new PeopleQueueService(personQueueRepository);
                var peopleQueueConsole = new PeopleQueueConsole(peopleQueueService);
                peopleQueueConsole.Start();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}