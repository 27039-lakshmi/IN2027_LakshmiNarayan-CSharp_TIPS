using LinqExploration.Domain.Models;
using LinqExploration.Infrastructure.Repository;

namespace LinqExploration.Application.Service
{
    /// <summary>
    /// Provides operations for managing suppliers and retrieving
    /// supplier-product related information.
    /// </summary>
    internal class SupplierService
    {
        private readonly SampleDatabaseContext _context = new ();

        /// <summary>
        /// Adds a collection of suppliers to the database.
        /// </summary>
        /// <param name="suppliers">The suppliers to add.</param>
        public void AddSuppliers(List<Supplier> suppliers)
        {
            this._context.AddSuppliers(suppliers);
        }

        /// <summary>
        /// Retrieves all suppliers from the database.
        /// </summary>
        /// <returns>A list of suppliers.</returns>
        public List<Supplier> GetSuppliers()
        {
            return this._context.GetAllSuppliers();
        }

        /// <summary>
        /// Retrieves supplier and product information by joining
        /// suppliers with products based on ProductId.
        /// </summary>
        /// <returns>
        /// A list of <see cref="ProductWithSupplierDto"/> containing
        /// product and supplier details.
        /// </returns>
        public List<ProductWithSupplierDto> GetProductWithSuppliers()
        {
            return this.GetSuppliers()
                .Join(
                    this._context.GetAllProducts(),
                    supplier => supplier.ProductId,
                    product => product.ProductId,
                    (supplier, product) => new ProductWithSupplierDto(
                        supplier.SupplierName,
                        supplier.SupplierId,
                        product.ProductName,
                        product.ProductId))
                .ToList();
        }
    }
}