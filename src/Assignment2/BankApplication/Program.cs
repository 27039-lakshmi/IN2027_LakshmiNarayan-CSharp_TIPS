using BankApplication.View;

namespace Assignments
{
    /// <summary>
    /// Entry point of the Bank Application.
    /// Initializes the application and starts the user interaction workflow.
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// Main method that serves as the starting point of the application.
        /// Invokes the user interface to begin bank account operations.
        /// </summary>
        /// <param name="args">
        /// Command-line arguments passed to the application.
        /// </param>
        public static void Main(string[] args)
        {
            UserViewer.Start();
        }
    }
}