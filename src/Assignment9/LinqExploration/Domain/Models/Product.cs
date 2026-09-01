namespace LinqExploration.Domain.Models
{
    /// <summary>
    /// Represents a product available for purchase.
    /// </summary>
    public class Product
    {
        /// <summary>
        /// Gets or sets the product identifier.
        /// </summary>
        /// <value>
        /// Unique identifier assigned to the product.
        /// </value>
        public int ProductId { get; set; }

        /// <summary>
        /// Gets or sets the product name.
        /// </summary>
        /// <value>
        /// Name used to identify the product.
        /// </value>
        public string ProductName { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the product price.
        /// </summary>
        /// <value>
        /// Monetary value of the product.
        /// </value>
        public decimal Price { get; set; }

        /// <summary>
        /// Gets or sets the product category.
        /// </summary>
        /// <value>
        /// Category to which the product belongs, such as Electronics, Books, or Clothing.
        /// </value>
        public string Category { get; set; } = string.Empty;
    }
}