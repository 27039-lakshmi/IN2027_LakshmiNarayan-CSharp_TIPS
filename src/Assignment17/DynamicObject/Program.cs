namespace Assignments
{
    /// <summary>
    /// Demonstrates the use of Reflection to inspect and modify
    /// object properties at runtime.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Application entry point.
        /// Creates a Person object, displays its properties,
        /// allows the user to modify a property, and displays
        /// the updated values.
        /// </summary>
        /// <param name="args">Command-line arguments.</param>
        public static void Main(string[] args)
        {
            var person = new Person
            {
                Name = "Lakshmi",
                Age = 22,
                City = "Coimbatore",
            };

            DisplayProperties(person);

            string propertyName = GetPropertyName(person);
            string newPropertyValue = GetNewPropertyValue(propertyName);

            SetValue(person, propertyName, newPropertyValue);

            DisplayProperties(person);
        }

        /// <summary>
        /// Prompts the user to enter a new value for the selected property.
        /// </summary>
        /// <param name="propertyName">The name of the property being modified.</param>
        /// <returns>The value entered by the user.</returns>
        private static string GetNewPropertyValue(string propertyName)
        {
            Console.WriteLine($"Enter new value for the {propertyName}");
            return Console.ReadLine() !;
        }

        /// <summary>
        /// Prompts the user to enter a property name and validates
        /// that the property exists on the Person class.
        /// </summary>
        /// <param name="person">The person object whose properties are being inspected.</param>
        /// <returns>A valid property name.</returns>
        private static string GetPropertyName(Person person)
        {
            Console.WriteLine("Enter property name to edit");

            string propertyName = Console.ReadLine() !;

            while (person.GetType().GetProperty(propertyName) == null)
            {
                Console.WriteLine(
                    $"Property '{propertyName}' not found in {person.GetType().Name}.");

                propertyName = Console.ReadLine() !;
            }

            return propertyName;
        }

        /// <summary>
        /// Updates the value of the specified property using Reflection.
        /// The entered string value is converted to the property's actual type
        /// before assigning it.
        /// </summary>
        /// <param name="person">The object whose property is to be modified.</param>
        /// <param name="propertyName">The name of the property to modify.</param>
        /// <param name="newPropertyValue">The new value entered by the user.</param>
        private static void SetValue(
            Person person,
            string propertyName,
            string newPropertyValue)
        {
            var property = person.GetType().GetProperty(propertyName);

            if (property == null)
            {
                return;
            }

            try
            {
                object? convertedValue = Convert.ChangeType(
                    newPropertyValue,
                    property.PropertyType);

                property.SetValue(person, convertedValue);
            }
            catch
            {
                Console.WriteLine(
                    $"Invalid value for type {property.PropertyType.Name}");
            }
        }

        /// <summary>
        /// Displays the names and current values of all public properties
        /// of the specified object.
        /// </summary>
        /// <param name="obj">The object whose properties are to be displayed.</param>
        private static void DisplayProperties(object obj)
        {
            var type = obj.GetType();
            var properties = type.GetProperties();

            foreach (var item in properties)
            {
                Console.WriteLine($"{item.Name} {item.GetValue(obj)}");
            }
        }
    }
}