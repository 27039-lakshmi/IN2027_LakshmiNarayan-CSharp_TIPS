using GarbageCollection.Application.Service;

namespace GarbageCollection.Presentation.View
{
    /// <summary>
    /// Coordinates the execution of the garbage collection demonstration.
    /// </summary>
    public class GarbageCollectionViewer
    {
        private readonly GarbageCollectionService _service;

        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="GarbageCollectionViewer"/> class.
        /// </summary>
        /// <param name="service">
        /// The service responsible for creating and releasing memory allocations.
        /// </param>
        public GarbageCollectionViewer(GarbageCollectionService service)
        {
            this._service = service;
        }

        /// <summary>
        /// Starts the garbage collection demonstration workflow.
        /// </summary>
        public void Start()
        {
            Console.ReadKey(); // used for breakpoint
            this._service.CreateAndDestroyMemory();
            GC.Collect();
            Console.ReadKey(); // used for breakpoint
        }
    }
}