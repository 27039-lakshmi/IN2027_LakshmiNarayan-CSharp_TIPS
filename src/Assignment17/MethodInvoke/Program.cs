namespace Assignments
{
    /// <summary>
    /// Entry point of the application
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Entrypoint of the application. Creates a Person object and invokes a method based on user input.
        /// </summary>
        /// <param name="args">String array containing args</param>
        public static void Main(string[] args)
        {
            var person = new Person
            {
                Name = "John Doe",
                Age = 30,
                City = "New York",
            };

            string methodName = GetMethodNameInput(person);
            var type = person.GetType();
            type.GetMethod(methodName)?.Invoke(person, null);
        }

        private static string GetMethodNameInput(Person person)
        {
            Console.WriteLine("Enter method name to be invoked");
            string methodname = Console.ReadLine() ?? string.Empty;
            while (person.GetType().GetMethod(methodname) == null)
            {
                Console.WriteLine("Method not found. Please enter a valid method name:");
                methodname = Console.ReadLine() ?? string.Empty;
            }

            return methodname;
        }
    }
}