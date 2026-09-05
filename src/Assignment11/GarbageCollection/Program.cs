using GarbageCollection.Application.Service;
using GarbageCollection.Presentation.Controller;

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
            var service = new GarbageCollectionService();
            var controller = new GarbageCollectionController(service);
            controller.Start();
        }
    }
}