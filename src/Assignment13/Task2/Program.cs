using Task2.Application;
using Task2.Infrastructure;
using Task2.Presentation;

namespace Assignments
{
    /// <summary>
    /// Entry point of the String Reversal application.
    /// Configures the application's dependencies and
    /// starts the console-based user interface.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Initializes the repository, application service,
        /// and presentation layer, then starts the application.
        /// </summary>
        /// <param name="args">
        /// Command-line arguments passed to the application.
        /// </param>
        private static void Main(string[] args)
        {
            StackRepository<char> stackRepository = new ();
            StringReverser stringReverser = new (stackRepository);
            StringReversalConsole controller = new StringReversalConsole(stringReverser);

            controller.Start();
        }
    }
}