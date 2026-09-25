using System.Text;

namespace FileDataProcessor
{
    /// <summary>
    /// Responsible for reading data from files and processing
    /// file content using different stream implementations.
    /// </summary>
    public class FileReader
    {
        /// <summary>
        /// Stores the path of the file to be read.
        /// </summary>
        private readonly string _filepath;

        /// <summary>
        /// Initializes a new instance of the <see cref="FileReader"/> class.
        /// </summary>
        /// <param name="filepath">
        /// Path of the file to be read.
        /// </param>
        public FileReader(string filepath)
        {
            this._filepath = filepath;
        }

        /// <summary>
        /// Reads the file using a FileStream and a fixed-size buffer.
        /// This method is used to measure FileStream read performance.
        /// </summary>
        public void ReadUsingFileStream()
        {
            using var fs = new FileStream(this._filepath, FileMode.Open, FileAccess.Read);
            byte[] buffer = new byte[1024];

            while (fs.Read(buffer, 0, buffer.Length) > 0)
            {
            }
        }

        /// <summary>
        /// Reads the file using a BufferedStream wrapped around
        /// a FileStream to improve read performance through buffering.
        /// </summary>
        public void ReadUsingBufferedStream()
        {
            using var fs = new FileStream(this._filepath, FileMode.Open, FileAccess.Read);
            using var bs = new BufferedStream(fs, 1024 * 1024);
            byte[] buffer = new byte[1024];

            while (bs.Read(buffer, 0, buffer.Length) > 0)
            {
            }
        }

        /// <summary>
        /// Reads data from the source file, converts the text
        /// to uppercase, and writes the processed data to a new file.
        /// </summary>
        /// <param name="outputFilepath">
        /// Path of the file where the processed data will be written.
        /// </param>
        public void ReadAndProcessData(string outputFilepath)
        {
            var writer = new FileWriter(outputFilepath);
            using var input = new FileStream(this._filepath, FileMode.Open, FileAccess.Read);
            using var bs = new BufferedStream(input, 1024 * 1024);

            byte[] buffer = new byte[1024];
            int bytesRead;

            while ((bytesRead = bs.Read(buffer, 0, buffer.Length)) > 0)
            {
                string processedData = Encoding.UTF8.GetString(buffer, 0, bytesRead).ToUpper();
                writer.WriteUsingMemoryStream(processedData);
            }
        }
    }
}