using System.Text.Json.Serialization;

namespace IDisposableDemo.Application.Service
{
    /// <summary>
    /// Provides functionality to write text to a file, read file contents,
    /// and release file-related resources when they are no longer needed.
    /// </summary>
    public class FileWriter : IDisposable
    {
        private readonly StreamWriter _writer;
        private readonly string _filepath;

        /// <summary>
        /// Initializes a new instance of the <see cref="FileWriter"/> class.
        /// </summary>
        /// <param name="filepath">filepath where data is stored</param>
        public FileWriter(string filepath)
        {
            this._filepath = filepath;
            this._writer = new StreamWriter(filepath);
        }

        /// <summary>
        /// Releases the resources used by the current instance,
        /// including the underlying <see cref="StreamWriter"/>.
        /// </summary>
        public void Dispose()
        {
            this._writer.Dispose();
        }

        /// <summary>
        /// Writes the specified text to the file followed by a newline.
        /// </summary>
        /// <param name="text">
        /// The text to be written to the file.
        /// </param>
        public void WriteIntoFile(string? text)
        {
            this._writer.WriteLine(text);
        }
    }
}