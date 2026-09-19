using Task3.Application;

namespace Task3.Presentation
{
    /// <summary>
    /// Provides a console-based user interface for managing
    /// and displaying a queue of people.
    /// </summary>
    public class PeopleQueueConsole
    {
        private PeopleQueueService _queueService;

        /// <summary>
        /// Initializes a new instance of the <see cref="PeopleQueueConsole"/> class.
        /// </summary>
        /// <param name="queueService">
        /// Service responsible for queue management operations.
        /// </param>
        public PeopleQueueConsole(PeopleQueueService queueService)
        {
            this._queueService = queueService;
        }

        /// <summary>
        /// Starts the queue management demonstration.
        /// Adds sample people to the queue, displays the queue,
        /// removes the first person, and displays the updated queue.
        /// </summary>
        public void Start()
        {
            Console.WriteLine("Adding persons to queue");

            this._queueService.AddPerson("Dinesh");
            this._queueService.AddPerson("Raj");
            this._queueService.AddPerson("Jay");
            this._queueService.AddPerson("Santhana");
            this._queueService.AddPerson("Megha");

            this.DisplayPersons();
            Console.WriteLine("Removing person from queue");

            this._queueService.RemovePerson();
            this.DisplayPersons();
        }

        /// <summary>
        /// Retrieves and displays all people currently in the queue.
        /// </summary>
        public void DisplayPersons()
        {
            var personsList = this._queueService.GetPersonList();

            foreach (var person in personsList)
            {
                Console.WriteLine("Name : " + person);
            }
        }
    }
}