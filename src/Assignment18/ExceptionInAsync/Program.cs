using System;
using System.Threading.Tasks;

namespace Assignments
{
    /// <summary>
    /// Demonstrates the difference in exception handling
    /// between async void and async Task methods.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Application entry point.
        /// Calls both an async void method and an async Task method
        /// to show how exceptions are propagated.
        /// </summary>
        /// <param name="args">Command-line arguments.</param>
        /// <returns>A task that represents a work</returns>
        public static async Task Main(string[] args)
        {
            try
            {
                // Exception thrown from async void methods
                // cannot be caught by this try-catch block.
                VoidMethod();
            }
            catch
            {
                Console.WriteLine("Caught exception from void method");
            }

            try
            {
                // Exceptions thrown from async Task methods
                // are captured by the returned Task and rethrown
                // when the task is awaited.
                await TaskMethod();
            }
            catch
            {
                Console.WriteLine("Caught exception from Task method");
            }
        }

        /// <summary>
        /// An asynchronous method that returns void.
        /// Intended only for event handlers.
        /// Any exception thrown inside this method bypasses
        /// the caller's try-catch block and is raised directly
        /// on the synchronization context.
        /// </summary>
        private static async void VoidMethod()
        {
            await Task.Delay(1000);
            throw new NotImplementedException();
        }

        /// <summary>
        /// An asynchronous method that returns a Task.
        /// Exceptions are stored in the returned Task and
        /// can be handled by awaiting the method within
        /// a try-catch block.
        /// </summary>
        /// <returns>
        /// A Task representing the asynchronous operation.
        /// </returns>
        private static async Task TaskMethod()
        {
            await Task.Delay(1000);
            throw new NotImplementedException();
        }
    }
}