namespace GreetingsApp
{
    /// <summary>
    /// Represents the entry point of the calculator application.
    /// Displays a welcome message and starts the console user interface.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Application entry point.
        /// </summary>
        /// <param name="args">Command-line arguments passed to the application.</param>
        public static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Welcome to calculator application");
                AdditionalProject.Program.Main(args);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }
}