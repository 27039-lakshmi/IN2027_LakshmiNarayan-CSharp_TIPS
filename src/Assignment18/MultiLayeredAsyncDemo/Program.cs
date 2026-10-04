namespace Assignments
{
    /// <summary>
    /// Demonstrates asynchronous programming by combining a CPU-bound operation,
    /// an asynchronous web service call, and result processing.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Application entry point.
        /// Executes the asynchronous workflow and displays the processed result.
        /// </summary>
        /// <param name="args">Command-line arguments.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        public static async Task Main(string[] args)
        {
            try
            {
                int processedResult = await MethodC();
                Console.WriteLine("Processed Result : " + processedResult);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        /// <summary>
        /// Simulates a CPU-bound operation by performing a large number of calculations.
        /// This method is intended to be executed on a background thread using Task.Run.
        /// </summary>
        /// <returns>
        /// A calculated numeric value that can be used by subsequent operations.
        /// </returns>
        public static long MethodA()
        {
            Console.WriteLine("Processing MethodA");
            long sum = 0;

            for (int i = 0; i < 10000; i++)
            {
                sum *= sum + 1;
            }

            Console.WriteLine("Processed MethodA");
            return sum;
        }

        /// <summary>
        /// Performs an asynchronous web service call.
        /// First executes <see cref="MethodA"/> on a ThreadPool thread,
        /// then uses the result to construct a URL and retrieve data from a web API.
        /// </summary>
        /// <returns>
        /// A task containing the JSON response returned by the web service.
        /// </returns>
        public static async Task<string> MethodB()
        {
            Console.WriteLine("Processing MethodB");
            long calculatedResult = await Task.Run(() => MethodA());
            string url = $"https://jsonplaceholder.typicode.com/posts/{(calculatedResult % 100) + 1}";

            using HttpClient client = new HttpClient();
            string result = await client.GetStringAsync(url);
            Console.WriteLine("Processed MethodB");
            return result;
        }

        /// <summary>
        /// Processes the response returned by <see cref="MethodB"/>.
        /// This method awaits the web service call and performs additional
        /// processing on the returned data.
        /// </summary>
        /// <returns>
        /// A task containing the processed result derived from the response.
        /// </returns>
        public static async Task<int> MethodC()
        {
            Console.WriteLine("Processing MethodC");
            string response = await MethodB();
            int length = response.Length;
            Console.WriteLine("Processed MethodC");
            return length;
        }
    }
}