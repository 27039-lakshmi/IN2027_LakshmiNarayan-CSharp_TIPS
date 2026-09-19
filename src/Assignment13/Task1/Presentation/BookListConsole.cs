using Task1.Application;

namespace Task1.Presentation
{
    /// <summary>
    /// Provides a console-based user interface for demonstrating
    /// book management operations such as adding, removing,
    /// displaying, and searching for books.
    /// </summary>
    public class BookListConsole
    {
        private BookListService _listService;

        /// <summary>
        /// Initializes a new instance of the <see cref="BookListConsole"/> class.
        /// </summary>
        /// <param name="listService">
        /// The service responsible for handling book-related business logic.
        /// </param>
        public BookListConsole(BookListService listService)
        {
            this._listService = listService;
        }

        /// <summary>
        /// Starts the console application workflow.
        /// Adds sample books, displays them, removes a book,
        /// and demonstrates book existence checks.
        /// </summary>
        public void Start()
        {
            Console.WriteLine("Adding books");
            this._listService.AddBook("Harry Potter");
            this._listService.AddBook("Game of Thrones");
            this._listService.AddBook("To Kill a Mockingbird");
            this._listService.AddBook("The Great Gatsby");
            this._listService.AddBook("Chernobyl");

            this.DisplayBooks();
            Console.WriteLine("Removing Chernobyl book");
            if (this._listService.DoesBookExist("Chernobyl"))
            {
                this._listService.RemoveBook("Chernobyl");
            }
            else
            {
                Console.WriteLine("Book does not exist");
            }

            this.DisplayBooks();
            Console.WriteLine("Does Game of Thrones exist : " + this._listService.DoesBookExist("Game of Thrones"));
            Console.WriteLine("Does Chernobyl exist : " + this._listService.DoesBookExist("Chernobyl"));
        }

        /// <summary>
        /// Retrieves all books from the service layer and
        /// displays each book title in the console.
        /// </summary>
        public void DisplayBooks()
        {
            var booksList = this._listService.GetBooks();

            foreach (var book in booksList)
            {
                Console.WriteLine(book);
            }
        }
    }
}
