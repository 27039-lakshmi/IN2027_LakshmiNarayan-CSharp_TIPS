using IDisposableDemo.Application.Service;

namespace IDisposableDemo.Presentation.Controller
{
    /// <summary>
    /// Coordinates user interaction for the IDisposable demonstration,
    /// including writing data to a file and reading it back.
    /// </summary>
    public class IDisposableController
    {
        /// <summary>
        /// Starts the IDisposable demonstration workflow.
        /// </summary>
        public void Start()
        {
            FileWriter service;
            using (service = new FileWriter("C:/chummah/data.txt"))
            {
                Console.WriteLine("Enter text to write into file");
                service.WriteIntoFile(Console.ReadLine());
            }

            Console.WriteLine("Data in file");
            string? text = service.ReadFromFile();
            Console.WriteLine(text);
        }
    }
}