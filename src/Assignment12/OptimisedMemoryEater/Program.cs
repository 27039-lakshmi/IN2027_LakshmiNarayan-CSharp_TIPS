using AdvanceMemoryManagement.Application;

namespace Assignments
{
    /// <summary>
    /// Entry point of the application.
    /// Responsible for accepting user input and invoking the memory allocation process.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Main method that starts the application, reads the heap memory limit
        /// from the user, validates the input, and triggers memory allocation.
        /// </summary>
        /// <param name="args">Command-line arguments passed to the application.</param>
        public static void Main(string[] args)
        {
            var memoryEater = new MemoryEater();

            Console.WriteLine("Enter heap memory limit in Mb");

            if (!int.TryParse(Console.ReadLine(), out int heapLimit) && heapLimit > 0)
            {
                Console.WriteLine("It should be a positive integer");
            }
            else
            {
                memoryEater.Allocate(heapLimit);

                Console.WriteLine("Total Allocated Memory: " + GC.GetTotalMemory(false));
                Console.WriteLine("Exitting application");

                Console.ReadKey();
            }
        }
    }
}