using RecordsDemo;

namespace Assignments
{
    /// <summary>
    /// Demonstrates the features of C# records including
    /// value equality, immutability, deconstruction, and
    /// the with expression.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Application entry point.
        /// </summary>
        /// <param name="args">Command-line arguments.</param>
        public static void Main(string[] args)
        {
            try
            {
                // Creating Book records
                var book1 = new Book("Ln", "C#", 5);
                var book2 = new Book("Db", "Python", 8);
                var book3 = new Book("Harini", "C++", 10);
                var book4 = new Book("Db", "Python", 8);

                CheckEqualityOfBooks(book2, book4);

                // Demonstrates immutability
                // book2.AuthorName = "Hello"; // Compile-time error

                // Creates a new record based on an existing record
                // while modifying the Title property.
                var book5 = book4 with { title = "Ln" };

                DisplayBook(book5);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// Compares two Book records and displays whether
        /// they are equal based on their property values.
        /// </summary>
        /// <param name="book1">First book record.</param>
        /// <param name="book2">Second book record.</param>
        private static void CheckEqualityOfBooks(Book book1, Book book2)
        {
            Console.WriteLine($"Are books equal? {book1 == book2}");
        }

        /// <summary>
        /// Deconstructs a Book record and displays its properties.
        /// </summary>
        /// <param name="book">The book record to display.</param>
        private static void DisplayBook(Book book)
        {
            var (title, authorName, isbn) = book;

            Console.WriteLine($"Book Title: {title} Author: {authorName} ISBN: {isbn}");
        }
    }
}