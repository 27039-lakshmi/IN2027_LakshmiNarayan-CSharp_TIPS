using System.Diagnostics;
using SerializationAPI;

namespace Assignments
{
    /// <summary>
    /// Entry point of the program that demonstrates serialization using reflection and Reflection.Emit.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Demonstrates serialization of simple and nested objects using reflection and Reflection.Emit, and compares their performance.
        /// </summary>
        /// <param name="args">Command line arguments</param>
        public static void Main(string[] args)
        {
            try
            {
                var employee = new Employee { Id = "E123", Salary = 75000 };
                var person = new Person { Name = "Lakshmi Narayan", Address = new Address { City = "Madurai" } };

                string reflectionResultOfSimpleObject = ReflectionSerializer.Serialize(employee);
                string reflectionResultOfNestedObject = ReflectionSerializer.Serialize(person);

                var employeeSerializer = DynamicSerializer.CreateSerializer(typeof(Employee));
                var personSerializer = DynamicSerializer.CreateSerializer(typeof(Person));

                string emitResultOfEmployee = employeeSerializer(employee);
                string emitResultOfPerson = personSerializer(person);

                Console.WriteLine($"Reflection Output of simple object: {reflectionResultOfSimpleObject}");
                Console.WriteLine($"Reflection Output of nested object: {reflectionResultOfNestedObject}");

                Console.WriteLine($"\nReflection.Emit Output of simple object: {emitResultOfEmployee}");
                Console.WriteLine($"\nReflection.Emit Output of nested object: {emitResultOfPerson}");

                Console.WriteLine($"\nOutputs match: {reflectionResultOfSimpleObject == emitResultOfEmployee}");
                Console.WriteLine($"\nOutputs match: {reflectionResultOfNestedObject == emitResultOfPerson}");

                const int iterations = 100_000;
                var stopwatch = Stopwatch.StartNew();
                for (int i = 0; i < iterations; i++)
                {
                    ReflectionSerializer.Serialize(employee);
                }

                stopwatch.Stop();
                Console.WriteLine($"\nReflection time: {stopwatch.ElapsedMilliseconds} ms"); // 89ms
                stopwatch.Restart();

                for (int i = 0; i < iterations; i++)
                {
                    employeeSerializer(employee);
                }

                stopwatch.Stop();
                Console.WriteLine($"Reflection.Emit time: {stopwatch.ElapsedMilliseconds} ms"); // 43ms
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }
}