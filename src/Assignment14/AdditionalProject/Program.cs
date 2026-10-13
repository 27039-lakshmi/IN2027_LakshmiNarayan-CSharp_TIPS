namespace AdditionalProject
{
    /// <summary>
    /// Represents the entry point for the AdditionalProject application.
    /// This application launches the calculator console user interface.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Starts the application and invokes the calculator user interface.
        /// </summary>
        /// <param name="args">
        /// An array of command-line arguments supplied when the application starts.
        /// </param>
        public static void Main(string[] args)
        {
            DisplayApp.ConsoleUI.Start();
        }
    }
}