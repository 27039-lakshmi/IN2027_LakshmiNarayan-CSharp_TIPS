namespace LinqExploration.Domain.Models
{
    /// <summary>
    /// Represents a supplier and the product supplied by that supplier.
    /// </summary>
    public class Supplier
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Supplier"/> class.
        /// </summary>
        /// <param name="supplierId">Id of the supplier</param>
        /// <param name="supplierName">Name of the supplier</param>
        /// <param name="productId">Id of the product</param>
        public Supplier(int supplierId, string supplierName, int productId)
        {
            this.SupplierId = supplierId;
            this.SupplierName = supplierName;
            this.ProductId = productId;
        }

        /// <summary>
        /// Gets or sets the supplier identifier.
        /// </summary>
        /// <value>
        /// Unique identifier assigned to the supplier.
        /// </value>
        public int SupplierId { get; set; }

        /// <summary>
        /// Gets or sets the supplier name.
        /// </summary>
        /// <value>
        /// Name of the supplier providing the product.
        /// </value>
        public string SupplierName { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the product identifier.
        /// </summary>
        /// <value>
        /// Identifier of the product associated with the supplier.
        /// </value>
        public int ProductId { get; set; }
    }
}