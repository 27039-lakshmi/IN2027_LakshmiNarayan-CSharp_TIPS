namespace Assignments
{
    /// <summary>
    /// Demonstrates how to avoid deadlocks by using async/await
    /// instead of blocking calls such as .Result or .Wait().
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Entry point of the application.
        /// Awaits the asynchronous method to ensure proper execution.
        /// </summary>
        /// <param name="args">Command-line arguments.</param>
        /// <returns>Task representing a work</returns>
        public static async Task Main(string[] args)
        {
            await DeadlockMethod();
        }

        /// <summary>
        /// Calls an asynchronous operation and awaits its completion.
        /// Using await prevents the thread from being blocked and
        /// avoids potential deadlocks caused by .Result or .Wait().
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        public static async Task DeadlockMethod()
        {
            string result = await SomeAsyncOperation();
            Console.WriteLine(result);
        }

        /// <summary>
        /// Simulates an asynchronous operation by delaying execution
        /// for one second and then returning a message.
        /// </summary>
        /// <returns>
        /// A task containing the string "Hello, World!".
        /// </returns>
        public static async Task<string> SomeAsyncOperation()
        {
            await Task.Delay(1000);
            return "Hello, World!";
        }
    }
}