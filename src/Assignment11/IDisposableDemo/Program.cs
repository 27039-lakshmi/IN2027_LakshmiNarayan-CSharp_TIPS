using IDisposableDemo.Presentation.Controller;

namespace Assignments
{
    /// <summary>
    /// Represents the entry point of the application.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Creates the controller and starts the IDisposable demonstration.
        /// </summary>
        /// <param name="args">
        /// Command-line arguments passed to the application.
        /// </param>
        public static void Main(string[] args)
        {
            var controller = new IDisposableController();
            controller.Start();
        }
    }
}