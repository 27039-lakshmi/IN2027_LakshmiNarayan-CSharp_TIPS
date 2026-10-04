using System.Text;

namespace FileDataProcessor
{
    /// <summary>
    /// Responsible for creating files and writing processed data
    /// to files using a MemoryStream.
    /// </summary>
    public class FileWriter
    {
        /// <summary>
        /// Stores the path of the file to be created or written to.
        /// </summary>
        private string _filepath;
        private readonly FileStream _fileStream;
        private readonly MemoryStream _memoryStream;

        /// <summary>
        /// Initializes a new instance of the <see cref="FileWriter"/> class.
        /// </summary>
        /// <param name="filepath">
        /// The path of the file that this writer will operate on.
        /// </param>
        public FileWriter(string filepath)
        {
            this._fileStream = new FileStream(filepath, FileMode.Create, FileAccess.Write);
            this._memoryStream = new MemoryStream();
        }

        /// <summary>
        /// Creates a text file of approximately 1 GB in size with repeated text.
        /// </summary>
        public void CreateLargeFile()
        {
            using var fs = new FileStream(this._filepath, FileMode.Create, FileAccess.Write);
            long targetSize = 1024L * 1024 * 1024; // 1 GB
            string line = "This line is going to written in the file";
            var sb = new StringBuilder();

            for (int i = 0; i < 1000; i++)
            {
                sb.AppendLine(line);
            }

            byte[] buffer = Encoding.UTF8.GetBytes(sb.ToString());

            while (fs.Length < targetSize)
            {
                fs.Write(buffer);
            }

            fs.Flush();
        }

        /// <summary>
        /// Writes processed text data to the specified file stream
        /// using a MemoryStream.
        /// </summary>
        /// <param name="processedData">
        /// The processed text data to be written to the file.
        /// </param>
        public void WriteUsingMemoryStream(string processedData)
        {
            byte[] buffer = Encoding.UTF8.GetBytes(processedData);
            this._memoryStream.Write(buffer, 0, buffer.Length);
            this._memoryStream.Position = 0;
            this._memoryStream.WriteTo(this._fileStream);
        }
    }
}