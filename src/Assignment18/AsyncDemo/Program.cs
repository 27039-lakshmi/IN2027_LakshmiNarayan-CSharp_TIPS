namespace Assignments
{
    /// <summary>
    /// Demonstrates downloading content from a specified URL using the HttpClient class.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Application entry point.
        /// Downloads content from a URL and displays the result.
        /// </summary>
        /// <param name="args">Command-line arguments.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        public static async Task Main(string[] args)
        {
            try
            {
                string url = "https://www.google.com/";
                string downloadedContent = await DownloadContentAsync(url);
                Console.WriteLine("Downloaded Content : " + downloadedContent);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        /// <summary>
        /// Downloads the content from the specified URL asynchronously.
        /// </summary>
        /// <param name="url">The URL from which content should be downloaded.</param>
        /// <returns>
        /// A task that represents the asynchronous operation.
        /// The task result contains the downloaded content as a string.
        /// </returns>
        public static async Task<string> DownloadContentAsync(string url)
        {
            Console.WriteLine("Processing..");
            using HttpClient client = new HttpClient();
            string downloadedContent = await client.GetStringAsync(url);
            return downloadedContent;
        }
    }
}