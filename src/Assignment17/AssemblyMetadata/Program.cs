using System.Reflection;

namespace Assignments
{
    /// <summary>
    /// Entry point of the Application.
    /// Initializes the application and starts the user interaction workflow.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Entry point of the program.
        /// </summary>
        /// <param name="args"> string array arguments</param>
        public static void Main(string[] args)
        {
            try
            {
                var filepath = GetFilepath();
                var file = Assembly.LoadFile(filepath);
                var types = file.GetTypes();
                foreach (var type in types)
                {
                    Console.WriteLine($"Type: {type.FullName}");
                    var methods = type.GetMethods();
                    foreach (var method in methods)
                    {
                        Console.WriteLine($"  Method: {method.Name}");
                    }

                    var properties = type.GetProperties();
                    foreach (var property in properties)
                    {
                        Console.WriteLine($"  Property: {property.Name}");
                    }

                    var fields = type.GetFields();
                    foreach (var field in fields)
                    {
                        Console.WriteLine($"  Field: {field.Name}");
                    }

                    var events = type.GetEvents();
                    foreach (var eventInfo in events)
                    {
                        Console.WriteLine($"  Event: {eventInfo.Name}");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }

        /// <summary>
        /// Gets a valid filepath from the user input. It prompts the user until a valid filepath is provided.
        /// </summary>
        /// <returns>Valid filepath</returns>
        private static string GetFilepath()
        {
            string filepath = Console.ReadLine() !;
            while (!IsValidFilepath(filepath))
            {
                Console.WriteLine("Invalid filepath. Please enter a valid filepath:");
                filepath = Console.ReadLine() !;
            }

            return filepath;
        }

        /// <summary>
        /// Checks if the provided filepath is valid (not null, not empty, and the file exists).
        /// </summary>
        /// <param name="filepath">Filepath input provided by user</param>
        /// <returns>True, if filepath is valid. else false</returns>
        private static bool IsValidFilepath(string filepath)
        {
            return !string.IsNullOrWhiteSpace(filepath) && File.Exists(filepath);
        }
    }
}