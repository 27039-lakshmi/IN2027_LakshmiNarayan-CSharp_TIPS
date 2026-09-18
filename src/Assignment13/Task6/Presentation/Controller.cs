using Task6.Application;

namespace Task6.Presentation
{
    /// <summary>
    /// Provides a console-based interface for demonstrating
    /// collection operations such as calculating sums and
    /// displaying dictionary contents.
    /// </summary>
    public class Controller
    {
        private CollectionService _collectionService;

        /// <summary>
        /// Initializes a new instance of the <see cref="Controller"/> class.
        /// </summary>
        /// <param name="collectionService">
        /// Service responsible for collection-related operations.
        /// </param>
        public Controller(CollectionService collectionService)
        {
            this._collectionService = collectionService;
        }

        /// <summary>
        /// Starts the collection demonstration.
        /// Calculates and displays the sum of elements in a list,
        /// queue, and stack, then generates and displays a dictionary.
        /// </summary>
        public void Start()
        {
            int listSum = this._collectionService.GetSumOfElements(new List<int> { 1, 2, 3, 4, 5 });
            int queueSum = this._collectionService.GetSumOfElements(new Queue<int>(new[] { 1, 2, 3, 4, 5 }));
            int stackSum = this._collectionService.GetSumOfElements(new Stack<int>(new[] { 1, 2, 3, 4, 5 }));

            Console.WriteLine($"List sum : {listSum}\n" +
                              $"Queue sum : {queueSum}\n" +
                              $"Stack sum : {stackSum}\n");
            Console.WriteLine("Creating dictionary");

            var dictionary = this._collectionService.GenerateDictionary();
            this.PrintDictionary(dictionary);
        }

        /// <summary>
        /// Displays the contents of the specified read-only dictionary.
        /// </summary>
        /// <param name="dictionary">
        /// The dictionary containing key-value pairs to display.
        /// </param>
        private void PrintDictionary(IReadOnlyDictionary<string, int> dictionary)
        {
            foreach (var item in dictionary)
            {
                Console.WriteLine($"Name : {item.Key} Age : {item.Value}");
            }
        }
    }
}