using System.Text;

namespace FileDataProcessor
{
    /// <summary>
    /// Reads data from source files, processes the content,
    /// and writes the transformed output to corresponding files.
    /// </summary>
    public class FileReader
    {
        /// <summary>
        /// Gets the total number of files to process.
        /// </summary>
        private readonly int _numberOfFiles;

        /// <summary>
        /// Stores the paths of the source files to be read.
        /// </summary>
        private readonly string[] _filepaths;

        /// <summary>
        /// Stores the paths of the output files where processed
        /// data will be written.
        /// </summary>
        private readonly string[] _outputFilepaths;

        /// <summary>
        /// Initializes a new instance of the <see cref="FileReader"/> class.
        /// </summary>
        /// <param name="filepaths">
        /// Collection of source file paths to read from.
        /// </param>
        /// <param name="outputFilepaths">
        /// Collection of destination file paths where processed data will be written.
        /// </param>
        /// <param name="numberOfFiles">
        /// Total number of files to process.
        /// </param>
        public FileReader(string[] filepaths, string[] outputFilepaths, int numberOfFiles)
        {
            this._filepaths = filepaths;
            this._outputFilepaths = outputFilepaths;
            this._numberOfFiles = numberOfFiles;
        }

        /// <summary>
        /// Processes all configured files synchronously.
        /// </summary>
        /// <remarks>
        /// Each source file is read, transformed, and written
        /// to its corresponding output file one at a time.
        /// </remarks>
        public void ProcessFiles()
        {
            for (int i = 0; i < this._numberOfFiles; i++)
            {
                this.ProcessFileContent(this._filepaths[i], this._outputFilepaths[i]);
            }
        }

        /// <summary>
        /// Processes all configured files asynchronously.
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous file-processing operation.
        /// </returns>
        /// <remarks>
        /// All file-processing tasks are started and executed concurrently.
        /// The method completes when all files have been processed.
        /// </remarks>
        public async Task ProcessFilesAsync()
        {
            var tasks = new List<Task>();

            for (int i = 0; i < this._numberOfFiles; i++)
            {
                tasks.Add(this.ProcessFileContentAsync(this._filepaths[i], this._outputFilepaths[i]));
            }

            await Task.WhenAll(tasks);
        }

        /// <summary>
        /// Reads a source file, converts its content to uppercase,
        /// and writes the processed content to the output file.
        /// </summary>
        /// <param name="filepath">
        /// Path of the source file to read.
        /// </param>
        /// <param name="outputFilepath">
        /// Path of the destination file to write.
        /// </param>
        private void ProcessFileContent(string filepath, string outputFilepath)
        {
            var writer = new FileWriter();
            using var input = new FileStream(filepath, FileMode.Open, FileAccess.Read);
            using var output = new FileStream(outputFilepath, FileMode.Create, FileAccess.Write);
            using var bs = new BufferedStream(input, 1024 * 1024);

            byte[] buffer = new byte[1024];
            int bytesRead;

            while ((bytesRead = bs.Read(buffer, 0, buffer.Length)) > 0)
            {
                string processedData = this.GetProcessedData(buffer, bytesRead);
                writer.WriteUsingMemoryStream(output, processedData);
            }
        }

        /// <summary>
        /// Asynchronously reads a source file, converts its content
        /// to uppercase, and writes the processed content to the
        /// output file.
        /// </summary>
        /// <param name="filepath">
        /// Path of the source file to read.
        /// </param>
        /// <param name="outputFilepath">
        /// Path of the destination file to write.
        /// </param>
        /// <returns>
        /// A task that represents the asynchronous file-processing operation.
        /// </returns>
        private async Task ProcessFileContentAsync(string filepath, string outputFilepath)
        {
            var writer = new FileWriter();
            using var input = new FileStream(filepath, FileMode.Open, FileAccess.Read);
            using var output = new FileStream(outputFilepath, FileMode.Create, FileAccess.Write);
            using var bs = new BufferedStream(input, 1024 * 1024);

            byte[] buffer = new byte[1024];
            int bytesRead;

            while ((bytesRead = await bs.ReadAsync(buffer, 0, buffer.Length)) > 0)
            {
                string processedData = this.GetProcessedData(buffer, bytesRead);
                writer.WriteUsingMemoryStream(output, processedData);
            }
        }

        /// <summary>
        /// Converts the specified byte buffer into a UTF-8 string
        /// and transforms the content to uppercase.
        /// </summary>
        /// <param name="buffer">
        /// Buffer containing raw file data.
        /// </param>
        /// <param name="bytesRead">
        /// Number of valid bytes read into the buffer.
        /// </param>
        /// <returns>
        /// The processed uppercase string representation of the buffer content.
        /// </returns>
        private string GetProcessedData(byte[] buffer, int bytesRead)
        {
            return Encoding.UTF8.GetString(buffer, 0, bytesRead).ToUpper();
        }
    }
}