using IDisposableDemo.Application.Service;

namespace IDisposableDemo.Presentation.View
{
    /// <summary>
    /// Coordinates user interaction for the IDisposable demonstration,
    /// including writing data to a file and reading it back.
    /// </summary>
    public class IDisposableViewer
    {
        /// <summary>
        /// Starts the IDisposable demonstration workflow.
        /// </summary>
        public void Start()
        {
            string filepath = "C:/chummah/data.txt";
            using (var fileWriter = new FileWriter(filepath))
            {
                Console.WriteLine("Enter text to write into file");
                fileWriter.WriteIntoFile(Console.ReadLine());
            }

            var fileReader = new FileReader(filepath);
            Console.WriteLine("Data in file");
            string? text = fileReader.ReadFromFile();
            Console.WriteLine(text);
        }
    }
}