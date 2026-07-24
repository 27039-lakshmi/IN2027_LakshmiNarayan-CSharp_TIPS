using ShapesManager.View;

namespace Assignments
{
    /// <summary>
    /// Entry point of the Shapes Manager application.
    /// Initializes the application and starts the user interaction workflow.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Main method that serves as the starting point of the application.
        /// Invokes the user interface to begin shape management operations.
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