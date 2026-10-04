namespace AdvancedDelegates
{
    /// <summary>
    /// Represents a product with a name, category, and price.
    /// </summary>
    public class Product
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Product"/> class.
        /// </summary>
        /// <param name="name">The name of the product.</param>
        /// <param name="category">The category to which the product belongs.</param>
        /// <param name="price">The price of the product.</param>
        public Product(string name, string category, decimal price)
        {
            this.Name = name;
            this.Category = category;
            this.Price = price;
        }

        /// <summary>
        /// Gets or sets the price of the product.
        /// </summary>
        /// <value>The price of the product</value>
        public decimal Price { get; set; }

        /// <summary>
        /// Gets or sets the category of the product.
        /// </summary>
        /// <value>The category of the product</value>
        public string Category { get; set; }

        /// <summary>
        /// Gets or sets the name of the product.
        /// </summary>
        /// <value>The Name of the product</value>
        public string Name { get; set; }
    }
}