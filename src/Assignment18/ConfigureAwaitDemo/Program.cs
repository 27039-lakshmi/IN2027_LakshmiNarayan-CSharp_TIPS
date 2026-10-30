namespace Assignments
{
    /// <summary>
    /// Demonstrates asynchronous programming using async/await.
    /// The program invokes a chain of asynchronous methods and displays
    /// the thread IDs before and after an awaited operation to illustrate
    /// how continuations may execute on a different thread.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Application entry point.
        /// Starts the asynchronous workflow by calling <see cref="MethodB"/>
        /// and awaiting its result.
        /// </summary>
        /// <param name="args">Command-line arguments.</param>
        /// <returns>A task representing the asynchronous execution of the application.</returns>
        public static async Task Main(string[] args)
        {
            string result = await MethodB();
        }

        /// <summary>
        /// Simulates an asynchronous operation by delaying execution for one second.
        /// Displays the managed thread ID before and after the await to demonstrate
        /// how execution may resume on a different thread when no synchronization
        /// context is available.
        /// </summary>
        /// <returns>
        /// A task that, when completed, returns the integer value 100.
        /// </returns>
        private static async Task<int> MethodA()
        {
            Console.WriteLine("Thread ID before await : " + Thread.CurrentThread.ManagedThreadId);

            await Task.Delay(1000).ConfigureAwait(false);

            Console.WriteLine("Thread ID after await : " + Thread.CurrentThread.ManagedThreadId);

            return 100;
        }

        /// <summary>
        /// Calls <see cref="MethodA"/>, awaits its completion, and converts
        /// the returned integer value to its string representation.
        /// </summary>
        /// <returns>
        /// A task that, when completed, returns the result from
        /// <see cref="MethodA"/> as a string.
        /// </returns>
        private static async Task<string> MethodB()
        {
            int result = await MethodA();
            return result.ToString();
        }
    }
}