using System.Text;

namespace ErrorLogger
{
    /// <summary>
    /// Provides an optimized logging implementation where
    /// each caller can write to a separate log file,
    /// reducing contention between concurrent write operations.
    /// </summary>
    public static class OptimisedLogger
    {
        /// <summary>
        /// Writes an error message to the specified log file.
        /// </summary>
        /// <param name="filepath">
        /// The path of the log file to which the message should be appended.
        /// </param>
        /// <param name="errorMessage">
        /// The error message to be written to the log file.
        /// </param>
        public static void LogError(string filepath, string errorMessage)
        {
            using (var memoryStream = new MemoryStream())
            {
                var errorBytes = Encoding.UTF8.GetBytes(errorMessage);
                memoryStream.Write(errorBytes, 0, errorBytes.Length);

                using (var fileStream = new FileStream(filepath, FileMode.Append))
                {
                    memoryStream.WriteTo(fileStream);
                }
            }
        }
    }
}