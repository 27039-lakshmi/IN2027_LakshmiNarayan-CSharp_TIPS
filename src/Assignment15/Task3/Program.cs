using System.Diagnostics;
using System.Text;

namespace Assignments
{
    /// <summary>
    /// Demonstrates inefficient and efficient approaches for
    /// reading from and writing to files, and compares their execution times.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Entry point of the application.
        /// Executes both the inefficient and efficient file processing methods.
        /// </summary>
        /// <param name="args">
        /// Command-line arguments passed to the application.
        /// </param>
        public static void Main(string[] args)
        {
            try
            {
                string path = GetFilePath("Enter file path");
                string data = "This is some test data";
                MeasureTimeForInefficientOperation(path, data); // Time taken: 14.6907ms
                MeasureTimeForEfficientOperation(path, data); // Time taken: 5.4932ms
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
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
        /// Demonstrates an inefficient approach to file processing by using
        /// an unnecessary MemoryStream, ASCII encoding, and
        /// byte-by-byte processing while measuring the execution time.
        /// </summary>
        /// <param name="path">
        /// The path of the file to be created and read.
        /// </param>
        /// <param name="data">
        /// The text data to be written to the file.
        /// </param>
        private static void MeasureTimeForInefficientOperation(string path, string data)
        {
            Console.WriteLine("Processing Inefficiently");
            var stopwatch = new Stopwatch();
            stopwatch.Start();

            // Writing to file using MemoryStream
            using (var memoryStream = new MemoryStream()) // Memory stream is not necessary. Can use filestream directly to write data.
            {
                byte[] buffer = Encoding.ASCII.GetBytes(data); // ASCII doesn't have encoding for all characters. Should use UTF instead of ASCII
                memoryStream.Write(buffer, 0, buffer.Length);

                // Write from MemoryStream to file
                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    byte[] writeBuffer = memoryStream.ToArray();
                    fileStream.Write(writeBuffer, 0, writeBuffer.Length);
                }
            }

            // Reading from file using FileStream
            using (var fileStream = new FileStream(path, FileMode.Open))
            {
                byte[] buffer = new byte[1024];
                int bytesRead;

                while ((bytesRead = fileStream.Read(buffer, 0, buffer.Length)) > 0)
                {
                    Console.Write("Data: ");

                    // Simulate memory inefficiency
                    for (int i = 0; i < bytesRead; i++)
                    {
                        Console.Write((char)buffer[i]); // Processing each byte individually will require more number of traversal.
                    }

                    Console.WriteLine();
                }
            }

            stopwatch.Stop();
            Console.WriteLine($"Time Taken {stopwatch.Elapsed.TotalMilliseconds}ms");
        }

        /// <summary>
        /// Demonstrates an efficient approach to file processing by writing
        /// data directly to a <see cref="FileStream"/>, using UTF-8 encoding,
        /// and processing data in larger chunks while measuring execution time.
        /// </summary>
        /// <param name="path">
        /// The path of the file to be created and read.
        /// </param>
        /// <param name="data">
        /// The text data to be written to the file.
        /// </param>
        private static void MeasureTimeForEfficientOperation(string path, string data)
        {
            Console.WriteLine("Processing Efficiently");
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            using (var fileStream = new FileStream(path, FileMode.Create))
            {
                byte[] writeBuffer = Encoding.UTF8.GetBytes(data);
                fileStream.Write(writeBuffer, 0, writeBuffer.Length);
            }

            // Reading from file using FileStream
            using (var fileStream = new FileStream(path, FileMode.Open))
            {
                byte[] buffer = new byte[1024];
                int bytesRead;

                while ((bytesRead = fileStream.Read(buffer, 0, buffer.Length)) > 0)
                {
                    string bufferData = Encoding.UTF8.GetString(buffer, 0, bytesRead);
                    Console.WriteLine("Data: " + bufferData);
                }
            }

            stopwatch.Stop();
            Console.WriteLine($"Time Taken {stopwatch.Elapsed.TotalMilliseconds}ms");
        }
    }
}