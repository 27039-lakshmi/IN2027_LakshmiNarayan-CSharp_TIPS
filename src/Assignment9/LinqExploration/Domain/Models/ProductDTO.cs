namespace LinqExploration.Domain.Models
{
    /// <summary>
    /// Represents a simplified view of product information.
    /// </summary>
    public class ProductDTO
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ProductDTO"/> class.
        /// </summary>
        /// <param name="name">
        /// Name of the product.
        /// </param>
        /// <param name="price">
        /// Price of the product.
        /// </param>
        public ProductDTO(string name, decimal price)
        {
            this.Name = name;
            this.Price = price;
        }

        /// <summary>
        /// Gets or sets the product name.
        /// </summary>
        /// <value>
        /// Display name used to identify the product.
        /// </value>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the product price.
        /// </summary>
        /// <value>
        /// Monetary value of the product.
        /// </value>
        public decimal Price { get; set; }
    }
}