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
            var queueRepository = new PersonQueueRepository<string>();
            var queueService = new QueueService(queueRepository);
            var controller = new QueueConsole(queueService);

            controller.Start();
        }
    }
}