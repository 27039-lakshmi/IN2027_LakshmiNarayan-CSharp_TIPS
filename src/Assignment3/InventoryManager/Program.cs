using InventoryManager.View;

namespace Assignments
{
    /// <summary>
    /// Entry point of the Inventory Management application.
    /// Responsible for starting the user interface and handling
    /// any unhandled exceptions that occur during execution.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Main method that serves as the application's entry point.
        /// Initializes the inventory management user interface.
        /// </summary>
        /// <param name="args">
        /// Command-line arguments passed to the application.
        /// </param>
        private static void Main(string[] args)
        {
            try
            {
                InventoryView.Start();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unexpected error: {ex.Message}");
            }
        }
    }
}