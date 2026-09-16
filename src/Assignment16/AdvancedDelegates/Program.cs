using AdvancedDelegates;

namespace Assignments
{
    /// <summary>
    /// Demonstrates the use of delegates for sorting products
    /// based on different criteria such as name, category, and price.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Represents a delegate used for comparing two products.
        /// The returned integer determines the sort order.
        /// </summary>
        /// <param name="firstProduct">The first product to compare.</param>
        /// <param name="secondProduct">The second product to compare.</param>
        /// <returns>
        /// Less than zero if the first product precedes the second product;
        /// zero if they are equal;
        /// greater than zero if the first product follows the second product.
        /// </returns>
        public delegate int SortDelegate(Product firstProduct, Product secondProduct);

        /// <summary>
        /// Application entry point.
        /// Creates a list of products and demonstrates sorting
        /// by name, category, and price using delegates.
        /// </summary>
        /// <param name="args">Command-line arguments.</param>
        public static void Main(string[] args)
        {
            List<Product> products = AddProducts();

            SortDelegate sortByName = SortName;
            SortDelegate sortByCategory = SortCategory;
            SortDelegate sortByPrice = SortPrice;

            Console.WriteLine("Sort by Name");
            SortAndDisplay(sortByName, products);

            Console.WriteLine("Sort by Category");
            SortAndDisplay(sortByCategory, products);

            Console.WriteLine("Sort by Price");
            SortAndDisplay(sortByPrice, products);
        }

        /// <summary>
        /// Adds products and returns the list of products
        /// </summary>
        /// <returns>A list of products</returns>
        private static List<Product> AddProducts()
        {
            return new List<Product>
            {
                new Product("Iphone", "Smartphone", 100000),
                new Product("Victus", "Laptop", 200000),
                new Product("Harry Potter", "Book", 1000),
                new Product("Apple", "Fruit", 100),
                new Product("Guava", "Fruit", 200),
            };
        }

        /// <summary>
        /// Sorts the provided list of products using the specified delegate
        /// and displays the sorted results on the console.
        /// </summary>
        /// <param name="sort">
        /// Delegate that defines the sorting logic.
        /// </param>
        /// <param name="products">
        /// List of products to be sorted and displayed.
        /// </param>
        private static void SortAndDisplay(SortDelegate sort, List<Product> products)
        {
            products.Sort((firstProduct, secondProduct) =>
                sort(firstProduct, secondProduct));

            foreach (var product in products)
            {
                Console.WriteLine(
                    $"Product Name {product.Name} " +
                    $"Product Category {product.Category} " +
                    $"Product Price {product.Price}");
            }
        }

        /// <summary>
        /// Compares two products by their names.
        /// </summary>
        /// <param name="firstProduct">The first product.</param>
        /// <param name="secondProduct">The second product.</param>
        /// <returns>
        /// A value indicating the relative order of the product names.
        /// </returns>
        private static int SortName(Product firstProduct, Product secondProduct)
        {
            return firstProduct.Name.CompareTo(secondProduct.Name);
        }

        /// <summary>
        /// Compares two products by their categories.
        /// </summary>
        /// <param name="firstProduct">The first product.</param>
        /// <param name="secondProduct">The second product.</param>
        /// <returns>
        /// A value indicating the relative order of the product categories.
        /// </returns>
        private static int SortCategory(Product firstProduct, Product secondProduct)
        {
            return firstProduct.Category.CompareTo(secondProduct.Category);
        }

        /// <summary>
        /// Compares two products by their prices.
        /// </summary>
        /// <param name="firstProduct">The first product.</param>
        /// <param name="secondProduct">The second product.</param>
        /// <returns>
        /// A value indicating the relative order of the product prices.
        /// </returns>
        private static int SortPrice(Product firstProduct, Product secondProduct)
        {
            return firstProduct.Price.CompareTo(secondProduct.Price);
        }
    }
}