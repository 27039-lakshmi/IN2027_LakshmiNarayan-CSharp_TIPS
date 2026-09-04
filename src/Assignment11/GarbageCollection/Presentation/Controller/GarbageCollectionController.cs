using GarbageCollection.Application.Service;

namespace GarbageCollection.Presentation.Controller
{
    /// <summary>
    /// Coordinates the execution of the garbage collection demonstration.
    /// </summary>
    public class GarbageCollectionController
    {
        private readonly GarbageCollectionService _service;

        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="GarbageCollectionController"/> class.
        /// </summary>
        /// <param name="service">
        /// The service responsible for creating and releasing memory allocations.
        /// </param>
        public GarbageCollectionController(GarbageCollectionService service)
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