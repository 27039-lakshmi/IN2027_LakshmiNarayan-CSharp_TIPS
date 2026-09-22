using LinqExploration.Domain.Constants;
using LinqExploration.Domain.Models;
using LinqExploration.Infrastructure.Interface;

namespace LinqExploration.Application.Service
{
    /// <summary>
    /// Provides operations for managing and querying product data.
    /// </summary>
    public class ProductService
    {
        private readonly ISampleDatabaseContext _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="ProductService"/> class.
        /// </summary>
        /// <param name="database">Instance of database from program.cs</param>
        public ProductService(ISampleDatabaseContext database)
        {
            this._context = database;
        }

        /// <summary>
        /// Retrieves electronics products with a price greater than 500
        /// and projects them into <see cref="ProductDTO"/> objects.
        /// </summary>
        /// <returns>A filtered list of products.</returns>
        public List<ProductDTO> GetFilteredProducts()
        {
            return this._context.GetAllProducts()
                .Where(product => product.Category.Equals(ProductCategory.Electronics, StringComparison.OrdinalIgnoreCase)
                               && product.Price > 500)
                .Select(product => new ProductDTO(
                    product.ProductName,
                    product.Price))
                .ToList();
        }

        /// <summary>
        /// Retrieves all products.
        /// </summary>
        /// <returns>A list of products.</returns>
        public IReadOnlyList<Product> GetProducts()
        {
            return this._context.GetAllProducts();
        }

        /// <summary>
        /// Adds a collection of products to the database.
        /// </summary>
        /// <param name="products">The products to add.</param>
        public void AddProducts(List<Product> products)
        {
            this._context.AddProducts(products);
        }

        /// <summary>
        /// Groups products by category and returns summary information
        /// for each category.
        /// </summary>
        /// <returns>
        /// A list containing the category name, product count,
        /// and most expensive product for each category.
        /// </returns>
        public IReadOnlyList<CategorySummaryDTO> GetProductCategorySummary()
        {
            return this._context.GetAllProducts()
                .GroupBy(product => product.Category)
                .Select(g => new CategorySummaryDTO(
                 g.Key,
                 g.Count(),
                 g.MaxBy(product => product.Price) !.ProductName))
                .ToList();
        }

        /// <summary>
        /// Demonstrates a less optimal query by sorting products
        /// before applying the filter. When sorting is performed before filtering,
        /// it sorts the full database and then with the result filtering is done.
        /// </summary>
        /// <returns>
        /// A list of books ordered by price.
        /// </returns>
        public IReadOnlyList<Product> FilterWithoutOptimisation()
        {
            return this.GetProducts()
                .OrderBy(product => product.Price)
                .Where(product => product.Category.Equals(ProductCategory.Books, StringComparison.OrdinalIgnoreCase))
                .ToList();
        }

        /// <summary>
        /// Demonstrates a more optimal query by filtering products
        /// before sorting them. When filtering is done before sorting
        /// the size of the database will be reduced and sorting is much quicker.
        /// </summary>
        /// <returns>
        /// A list of books ordered by price.
        /// </returns>
        public IReadOnlyList<Product> FilterWithOptimisation()
        {
            return this.GetProducts()
                .Where(product => product.Category.Equals(ProductCategory.Books, StringComparison.OrdinalIgnoreCase))
                .OrderBy(product => product.Price)
                .ToList();
        }
    }
}