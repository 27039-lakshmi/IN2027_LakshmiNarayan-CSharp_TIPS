namespace LinqExploration.Domain.Models
{
    /// <summary>
    /// Represents combined product and supplier information.
    /// </summary>
    public class ProductWithSupplierDto
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ProductWithSupplierDto"/> class.
        /// </summary>
        /// <param name="supplierName">
        /// Name of the supplier associated with the product.
        /// </param>
        /// <param name="supplierId">
        /// Unique identifier of the supplier.
        /// </param>
        /// <param name="productName">
        /// Name of the product supplied.
        /// </param>
        /// <param name="productId">
        /// Unique identifier of the product.
        /// </param>
        public ProductWithSupplierDto(
            string supplierName,
            int supplierId,
            string productName,
            int productId)
        {
            this.SupplierName = supplierName;
            this.SupplierId = supplierId;
            this.ProductName = productName;
            this.ProductId = productId;
        }

        /// <summary>
        /// Gets or sets the supplier name.
        /// </summary>
        /// <value>
        /// Name of the supplier associated with the product.
        /// </value>
        public string SupplierName { get; set; }

        /// <summary>
        /// Gets or sets the supplier identifier.
        /// </summary>
        /// <value>
        /// Unique identifier assigned to the supplier.
        /// </value>
        public int SupplierId { get; set; }

        /// <summary>
        /// Gets or sets the product name.
        /// </summary>
        /// <value>
        /// Name used to identify the product.
        /// </value>
        public string ProductName { get; set; }

        /// <summary>
        /// Gets or sets the product identifier.
        /// </summary>
        /// <value>
        /// Unique identifier assigned to the product.
        /// </value>
        public int ProductId { get; set; }
    }
}