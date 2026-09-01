using LinqExploration.Domain.Models;
using LinqExploration.Infrastructure.Repository;

namespace LinqExploration.Application.Service
{
    /// <summary>
    /// Provides operations for managing and querying product data.
    /// </summary>
    public class ProductService
    {
        private readonly SampleDatabaseContext _context;

        public ProductService(SampleDatabaseContext database)
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
                .Where(product => product.Category.Equals("Electronics")
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
        public List<Product> GetProducts()
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
        public List<CategorySummaryDTO> GetProductCategorySummary()
        {
            return this._context.GetAllProducts()
                .GroupBy(product => product.Category)
                .Select(g => new CategorySummaryDTO(
                 g.Key,
                 g.Count(),
                 g.OrderByDescending(product => product.Price).First().ProductName))
                .ToList();
        }

        /// <summary>
        /// Demonstrates a less optimal query by sorting products
        /// before applying the filter.
        /// </summary>
        /// <returns>
        /// A list of books ordered by price.
        /// </returns>
        public List<Product> FilterWithoutOptimisation()
        {
            return this.GetProducts()
                .OrderBy(product => product.Price)
                .Where(product => product.Category.Equals("Books"))
                .ToList();
        }

        /// <summary>
        /// Demonstrates a more optimal query by filtering products
        /// before sorting them.
        /// </summary>
        /// <returns>
        /// A list of books ordered by price.
        /// </returns>
        public List<Product> FilterWithOptimisation()
        {
            return this.GetProducts()
                .Where(product => product.Category.Equals("Books"))
                .OrderBy(product => product.Price)
                .ToList();
        }
    }
}