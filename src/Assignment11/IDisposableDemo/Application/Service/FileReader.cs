namespace IDisposableDemo.Application.Service
{
    /// <summary>
    /// Provides functionality to read content from file.
    /// </summary>
    public class FileReader
    {
        private readonly string _filepath;

        /// <summary>
        /// Initializes a new instance of the <see cref="FileReader"/> class.
        /// </summary>
        /// <param name="filepath">filepath where data is stored</param>
        public FileReader(string filepath)
        {
            this._filepath = filepath;
        }

        /// <summary>
        /// Reads and returns the entire content of the file.
        /// </summary>
        /// <returns>
        /// A string containing all text from the file.
        /// </returns>
        public string? ReadFromFile()
        {
            return File.ReadAllText(this._filepath);
        }
    }
}
