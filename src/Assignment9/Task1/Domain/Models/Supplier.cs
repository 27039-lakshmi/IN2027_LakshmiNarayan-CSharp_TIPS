namespace LinqExploration.Domain.Models
{
    /// <summary>
    /// Represents a supplier and the product supplied by that supplier.
    /// </summary>
    public class Supplier
    {
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