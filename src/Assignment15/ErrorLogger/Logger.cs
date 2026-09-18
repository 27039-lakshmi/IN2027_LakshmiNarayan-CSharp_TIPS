using System.IO;
using System.Text;

/// <summary>
/// Provides functionality for logging error messages
/// to a shared log file.
/// </summary>
public class Logger
{
    /// <summary>
    /// Path of the shared log file.
    /// </summary>
    private static string _logFilePath = "C:/data/log.txt";

    /// <summary>
    /// Synchronizes access to the log file to prevent
    /// concurrent write operations from multiple threads.
    /// </summary>
    private static object _lock = new object();

    /// <summary>
    /// Writes an error message to the log file.
    /// The method acquires a lock before writing to ensure
    /// thread-safe access when multiple users attempt to log
    /// simultaneously.
    /// </summary>
    /// <param name="errorMessage">
    /// The error message to be written to the log file.
    /// </param>
    public static void LogError(string errorMessage)
    {
        lock (_lock)
        {
            using (var memoryStream = new MemoryStream())
            {
                var errorBytes = Encoding.UTF8.GetBytes(errorMessage);
                memoryStream.Write(errorBytes, 0, errorBytes.Length);

                using (var fileStream = new FileStream(_logFilePath, FileMode.Append))
                {
                    memoryStream.WriteTo(fileStream);
                }
            }
        }
    }
}