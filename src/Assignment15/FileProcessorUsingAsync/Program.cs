using System.Diagnostics;
using FileDataProcessor;

namespace Assignments
{
        /// <summary>
        /// Provides the entry point for the application and coordinates
        /// file creation, processing, and performance measurement operations.
        /// </summary>
        public class Program
        {
            private static int numberOfFiles = 2;

            /// <summary>
            /// Stores the paths of the source files that will be created
            /// and processed during application execution.
            /// </summary>
            private static string[] filepaths = { "C:/Chummah/Largefile1.txt", "C:/Chummah/Largefile2.txt" };

            /// <summary>
            /// Stores the paths of the output files where the processed
            /// file content will be written.
            /// </summary>
            private static string[] outputFilepaths = { "C:/Chummah/ProcessedData1.txt", "C:/Chummah/ProcessedData2.txt" };

            /// <summary>
            /// Creates sample files, processes their contents both
            /// synchronously and asynchronously, and displays the
            /// execution time for each processing approach.
            /// </summary>
            /// <param name="args">
            /// Command-line arguments supplied to the application.
            /// </param>
            /// <returns>Task representing asynchronous execution </returns>
            public static async Task Main(string[] args)
            {
                try
                {
                    var writer = new FileWriter();
                    writer.CreateLargeFiles(filepaths);
                    Console.WriteLine("Files created successfully");

                    var reader = new FileReader(filepaths, outputFilepaths, numberOfFiles);
                    MeasurePerformanceOfSynchronous(reader);
                    await MeasurePerformanceOfAsynchronous(reader);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }

            /// <summary>
            /// Measures and displays the time required to process
            /// files asynchronously.
            /// </summary>
            /// <param name="reader">
            /// The file reader instance used to process the files.
            /// </param>
            /// <returns>Task representing asynchronous execution </returns>
            private static async Task MeasurePerformanceOfAsynchronous(FileReader reader)
            {
                var stopwatch = new Stopwatch();
                Console.WriteLine("Processing data asynchronously");
                stopwatch.Start();
                await reader.ProcessFilesAsync();
                stopwatch.Stop();
                Console.WriteLine($"Time taken to read and process {stopwatch.ElapsedMilliseconds}ms");
            }

            /// <summary>
            /// Measures and displays the time required to process
            /// files synchronously.
            /// </summary>
            /// <param name="reader">
            /// The file reader instance used to process the files.
            /// </param>
            private static void MeasurePerformanceOfSynchronous(FileReader reader)
            {
                Console.WriteLine("Processing data synchronously");
                var stopwatch = new Stopwatch();
                stopwatch.Start();
                reader.ProcessFiles();
                stopwatch.Stop();
                Console.WriteLine($"Time taken to read and process {stopwatch.ElapsedMilliseconds}ms");
            }
    }
}
