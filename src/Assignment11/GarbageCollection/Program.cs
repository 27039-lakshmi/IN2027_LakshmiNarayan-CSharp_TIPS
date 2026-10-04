using GarbageCollection.Application.Service;
using GarbageCollection.Presentation.View;

namespace Assignments
{
    /// <summary>
    /// Application entry point for demonstrating .NET garbage collection.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Initializes the required components and starts the
        /// garbage collection demonstration.
        /// </summary>
        /// <param name="args">
        /// Command-line arguments passed to the application.
        /// </param>
        public static void Main(string[] args)
        {
            try
            {
                var service = new GarbageCollectionService();
                var view = new GarbageCollectionViewer(service);
                view.Start();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}