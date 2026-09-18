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
        /// Creates one or more large text files of approximately 1 GB each
        /// </summary>
        /// <param name="filepaths">
        /// Collection of file paths where the large files will be created.
        /// </param>
        public void CreateLargeFiles(string[] filepaths)
        {
            foreach (string filepath in filepaths)
            {
                this.CreateLargeFile(filepath);
            }
        }

        /// <summary>
        /// Writes processed text data to the specified file stream
        /// using a MemoryStream.
        /// </summary>
        /// <param name="fs">
        /// The destination file stream where the processed data
        /// will be written.
        /// </param>
        /// <param name="processedData">
        /// The processed text data to be written to the file.
        /// </param>
        public void WriteUsingMemoryStream(FileStream fs, string processedData)
        {
            using var ms = new MemoryStream();
            byte[] buffer = Encoding.UTF8.GetBytes(processedData);
            ms.Write(buffer, 0, buffer.Length);
            ms.Position = 0;
            ms.WriteTo(fs);
        }

        /// <summary>
        /// Creates a large text file of approximately 1 GB
        /// </summary>
        /// <param name="filepath">
        /// Filepath where the large file will be created.
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