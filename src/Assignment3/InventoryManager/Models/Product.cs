namespace InventoryManager.Models
{
    /// <summary>
    /// Represents a product in the inventory system.
    /// Contains product identification, name, price, and quantity information.
    /// </summary>
    public class Product
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Product"/> class
        /// with the specified product details.
        /// </summary>
        /// <param name="id">The unique identifier of the product.</param>
        /// <param name="name">The name of the product.</param>
        /// <param name="price">The price of the product.</param>
        /// <param name="quantity">The available quantity of the product.</param>
        public Product(string id, string name, decimal price, int quantity)
        {
            this.Id = id;
            this.Name = name;
            this.Price = price;
            this.Quantity = quantity;
        }

        /// <summary>
        /// Gets or sets the unique identifier of the product.
        /// </summary>
        /// <value>
        /// A unique string used to identify the product.
        /// </value>
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the name of the product.
        /// </summary>
        /// <value>
        /// The descriptive name of the product.
        /// </value>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the price of the product.
        /// </summary>
        /// <value>
        /// The monetary value assigned to the product.
        /// </value>
        public decimal Price { get; set; }

        /// <summary>
        /// Gets or sets the available quantity of the product.
        /// </summary>
        /// <value>
        /// The number of units currently available in inventory.
        /// </value>
        public int Quantity { get; set; }
    }
}