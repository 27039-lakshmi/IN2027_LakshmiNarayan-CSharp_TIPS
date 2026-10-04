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
        /// Stores the path of the file that this writer instance operates on.
        /// </summary>
        private readonly string _filepath;

        /// <summary>
        /// Stores a collection of file paths where large files will be created.
        /// </summary>
        private List<string> _filepaths;

        /// <summary>
        /// Initializes a new instance of the <see cref="FileWriter"/> class.
        /// </summary>
        public FileWriter()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FileWriter"/> class
        /// with a collection of file paths.
        /// </summary>
        /// <param name="filepaths">
        /// Collection of file paths where large files will be created.
        /// </param>
        public FileWriter(List<string> filepaths)
        {
            this._filepaths = filepaths;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FileWriter"/> class
        /// with a target file path.
        /// </summary>
        /// <param name="filepath">
        /// The path of the file that this writer will operate on.
        /// </param>
        public FileWriter(string filepath)
        {
            this._filepath = filepath;
        }

        /// <summary>
        /// Creates one or more large text files of approximately 1 GB each.
        /// </summary>
        public void CreateLargeFiles()
        {
            foreach (string filepath in this._filepaths)
            {
                this.CreateLargeFile(filepath);
            }
        }

        /// <summary>
        /// Writes processed text data to the configured output file
        /// using a MemoryStream.
        /// </summary>
        /// <param name="processedData">
        /// The processed text data to be written to the file.
        /// </param>
        public void WriteUsingMemoryStream(string processedData)
        {
            using var fs = new FileStream(this._filepath, FileMode.Create, FileAccess.Write);
            using var ms = new MemoryStream();

            byte[] buffer = Encoding.UTF8.GetBytes(processedData);

            ms.Write(buffer, 0, buffer.Length);
            ms.Position = 0;
            ms.WriteTo(fs);
        }

        /// <summary>
        /// Creates a large text file of approximately 1 GB in size
        /// by repeatedly writing predefined text content until the
        /// target size is reached.
        /// </summary>
        /// <param name="filepath">
        /// The path where the large file will be created.
        /// </param>
        private void CreateLargeFile(string filepath)
        {
            using var fs = new FileStream(filepath, FileMode.Create, FileAccess.Write);

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
    }
}