using LinqExploration.Domain.Models;

namespace LinqExploration.Infrastructure.Interface
{
    /// <summary>
    /// Defines operations for managing and retrieving product and supplier data.
    /// Provides an abstraction over the underlying data store.
    /// </summary>
    public interface ISampleDatabaseContext
    {
        /// <summary>
        /// Retrieves all products from the data store.
        /// </summary>
        /// <returns>
        /// A read-only collection containing all products.
        /// </returns>
        IReadOnlyList<Product> GetAllProducts();

        /// <summary>
        /// Adds a collection of products to the data store.
        /// </summary>
        /// <param name="products">
        /// The products to add.
        /// </param>
        void AddProducts(List<Product> products);

        /// <summary>
        /// Adds a collection of suppliers to the data store.
        /// </summary>
        /// <param name="suppliers">
        /// The suppliers to add.
        /// </param>
        void AddSuppliers(List<Supplier> suppliers);

        /// <summary>
        /// Retrieves all suppliers from the data store.
        /// </summary>
        /// <returns>
        /// A read-only collection containing all suppliers.
        /// </returns>
        IReadOnlyList<Supplier> GetAllSuppliers();
    }
}