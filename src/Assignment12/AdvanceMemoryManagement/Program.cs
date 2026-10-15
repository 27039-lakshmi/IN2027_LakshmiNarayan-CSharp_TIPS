using AdvanceMemoryManagement.Application;

namespace Assignments
{
    /// <summary>
    /// Entry point of the application.
    /// Responsible for creating a <see cref="MemoryEater"/> instance and
    /// initiating the memory allocation process.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Starts the application and invokes continuous memory allocation.
        /// Displays memory statistics after allocation completes and waits
        /// for user input before closing the application.
        /// </summary>
        /// <param name="args">Command-line arguments passed to the application.</param>
        public static void Main(string[] args)
        {
            try
            {
                var memoryEater = new MemoryEater();
                memoryEater.Allocate();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            finally
            {
                Console.WriteLine("Total Allocated Memory: " + GC.GetTotalMemory(false));
            }
        }
    }
}