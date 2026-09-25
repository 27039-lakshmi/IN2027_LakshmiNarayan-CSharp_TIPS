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
            private static int numberOfFiles;

            /// <summary>
            /// Stores the paths of the source files that will be created
            /// and processed during application execution.
            /// </summary>
            private static List<string> filepaths = new ();

            /// <summary>
            /// Stores the paths of the output files where the processed
            /// file content will be written.
            /// </summary>
            private static List<string> outputFilepaths = new ();

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
                    var writer = new FileWriter(filepaths);
                    Console.WriteLine("Enter number of files");
                    if (!int.TryParse(Console.ReadLine(), out numberOfFiles))
                    {
                        Console.WriteLine("Enter a valid integer");
                    }

                    for (int i = 0; i < numberOfFiles; i++)
                    {
                    string filepath = GetFilePath("Enter filepath to create large file");
                    string outputFilepath = GetFilePath("Enter filepath to store processed data");
                    filepaths.Add(filepath);
                    outputFilepaths.Add(outputFilepath);
                    }

                    writer.CreateLargeFiles();
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

            private static string GetFilePath(string inputMessage)
            {
                Console.WriteLine(inputMessage);
                int maxAttempts = 3;
                for (int i = 0; i < maxAttempts; i++)
                {
                    Console.WriteLine("Attempts Left " + (maxAttempts - i));
                    string filepath = Console.ReadLine() ?? string.Empty;
                    if (IsValidfilepath(filepath))
                    {
                        return filepath;
                    }
                    else
                    {
                        Console.WriteLine("Enter valid filepath");
                    }
                }

                return null;
            }

            private static bool IsValidfilepath(string filepath)
            {
                return filepath.EndsWith(".txt");
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
