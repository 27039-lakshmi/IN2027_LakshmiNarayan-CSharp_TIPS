using LinqExploration.Domain.Models;

namespace LinqExploration.Infrastructure.Repository
{
    /// <summary>
    /// Represents an in-memory data store for products, suppliers, and orders.
    /// </summary>
    public class SampleDatabaseContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SampleDatabaseContext"/> class.
        /// </summary>
        public SampleDatabaseContext()
        {
            this.Products = new List<Product>();
            this.Suppliers = new List<Supplier>();
        }

        /// <summary>
        /// Gets or sets the collection of products.
        /// </summary>
        /// <value>
        /// Products available in the data store.
        /// </value>
        public List<Product> Products { get; set; }

        /// <summary>
        /// Gets or sets the collection of suppliers.
        /// </summary>
        /// <value>
        /// Suppliers available in the data store.
        /// </value>
        public List<Supplier> Suppliers { get; set; }

        /// <summary>
        /// Retrieves all products from the data store.
        /// </summary>
        /// <returns>
        /// A list containing all products.
        /// </returns>
        public List<Product> GetAllProducts()
        {
            return this.Products.ToList();
        }

        /// <summary>
        /// Adds a collection of products to the data store.
        /// </summary>
        /// <param name="products">
        /// Products to be added.
        /// </param>
        public void AddProducts(List<Product> products)
        {
            this.Products.AddRange(products);
        }

        /// <summary>
        /// Adds a collection of suppliers to the data store.
        /// </summary>
        /// <param name="suppliers">
        /// Suppliers to be added.
        /// </param>
        public void AddSuppliers(List<Supplier> suppliers)
        {
            this.Suppliers.AddRange(suppliers);
        }

        /// <summary>
        /// Retrieves all suppliers from the data store.
        /// </summary>
        /// <returns>
        /// A list containing all suppliers.
        /// </returns>
        public List<Supplier> GetAllSuppliers()
        {
            return this.Suppliers.ToList();
        }
    }
}