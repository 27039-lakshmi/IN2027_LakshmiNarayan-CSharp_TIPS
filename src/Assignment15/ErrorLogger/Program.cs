using System.Diagnostics;
using ErrorLogger;

namespace Assignments
{
    /// <summary>
    /// Demonstrates and benchmarks different logging strategies
    /// by measuring the time taken to write log entries
    /// to the same file versus separate files.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Application entry point.
        /// Executes both logging benchmarks and displays the results.
        /// </summary>
        /// <param name="args">Command-line arguments.</param>
        /// <returns>
        /// A task that represents the asynchronous execution of the application.
        /// </returns>
        public static async Task Main(string[] args)
        {
            try
            {
                await MeasureTimeToLogSameFile();
                await MeasureTimeToLogDifferentFile();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        /// <summary>
        /// Measures the time taken for multiple concurrent tasks
        /// to write log entries to the same log file.
        ///
        /// This test helps evaluate file contention and the impact
        /// of synchronization mechanisms when many users attempt
        /// to access a shared log file simultaneously.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        private static async Task MeasureTimeToLogSameFile()
        {
            var tasks = new Task[100];
            var stopwatch = new Stopwatch();
            stopwatch.Start();

            for (int i = 0; i < tasks.Length; i++)
            {
                int userId = i;
                tasks[i] = Task.Run(() =>
                {
                    Logger.LogError($"{userId} Logs an error");
                });
            }

            await Task.WhenAll(tasks);
            stopwatch.Stop();
            Console.WriteLine($"Time taken to log same file: {stopwatch.Elapsed.TotalMilliseconds} ms");
        }

        /// <summary>
        /// Measures the time taken for multiple concurrent tasks
        /// to write log entries to different log files.
        ///
        /// Since each task writes to its own file, file contention
        /// is minimized, providing a baseline for comparison against
        /// the shared log file approach.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        private static async Task MeasureTimeToLogDifferentFile()
        {
            var tasks = new Task[100];
            var stopwatch = new Stopwatch();
            stopwatch.Start();

            for (int i = 0; i < tasks.Length; i++)
            {
                int userId = i;
                tasks[i] = Task.Run(() =>
                {
                    OptimisedLogger.LogError($"C:/Data/user{userId}_Log.txt", $"{userId} Logs an error");
                });
            }

            await Task.WhenAll(tasks);
            stopwatch.Stop();
            Console.WriteLine($"Time taken to log different files: {stopwatch.Elapsed.TotalMilliseconds} ms");
        }
    }
}