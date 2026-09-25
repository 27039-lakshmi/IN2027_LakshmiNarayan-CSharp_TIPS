using System.Diagnostics;
using FileDataProcessor;

namespace Assignments
{
    /// <summary>
    /// Entry point for the File Data Processor application.
    /// Creates a large file, measures file-reading performance,
    /// processes the file data, and writes the processed output.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Application entry point.
        /// </summary>
        /// <param name="args">Command-line arguments.</param>
        public static void Main(string[] args)
        {
            //string filepath = "C:/Chummah/Largefile.txt";
            //string outputFilepath = "C:/Chummah/ProcessedData.txt";

            try
            {
                string filepath = GetFilePath("Enter filepath to create large file");
                string outputFilepath = GetFilePath("Enter filepath to store processed data");
                var writer = new FileWriter(filepath);
                writer.CreateLargeFile();
                Console.WriteLine("File created successfully");

                MeasureFileStreamReadTime(filepath);
                MeasureBufferStreamReadTime(filepath);

                var reader = new FileReader(filepath);
                Console.WriteLine("Processing data");
                var stopwatch = new Stopwatch();
                stopwatch.Start();
                reader.ReadAndProcessData(outputFilepath);
                stopwatch.Stop();

                Console.WriteLine($"Time taken to read and process {stopwatch.ElapsedMilliseconds}ms");
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
        /// Measures the time taken to read the entire file using a FileStream.
        /// </summary>
        /// <param name="filepath">
        /// Path of the file to be read.
        /// </param>
        private static void MeasureFileStreamReadTime(string filepath)
        {
            var stopwatch = new Stopwatch();
            var reader = new FileReader(filepath);

            stopwatch.Start();
            reader.ReadUsingFileStream();
            stopwatch.Stop();
            Console.WriteLine($"Time Taken with File stream  {stopwatch.ElapsedMilliseconds}ms");
        }

        /// <summary>
        /// Measures the time taken to read the entire file using a BufferedStream
        /// </summary>
        /// <param name="filepath">
        /// Path of the file to be read.
        /// </param>
        private static void MeasureBufferStreamReadTime(string filepath)
        {
            var stopwatch = new Stopwatch();
            var reader = new FileReader(filepath);

            stopwatch.Start();
            reader.ReadUsingBufferedStream();
            stopwatch.Stop();
            Console.WriteLine($"Time Taken with Buffered stream  {stopwatch.ElapsedMilliseconds}ms");
        }
    }
}