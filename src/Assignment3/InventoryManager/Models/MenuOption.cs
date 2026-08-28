namespace InventoryManager.Models
{
    /// <summary>
    /// Represents the available menu options in the inventory management system.
    /// </summary>
    public enum MenuOption
    {
        /// <summary>
        /// Adds a new product to the inventory.
        /// </summary>
        AddProduct = 1,

        /// <summary>
        /// Modifies the details of an existing product.
        /// </summary>
        EditProduct = 2,

        /// <summary>
        /// Searches for products by name.
        /// </summary>
        SearchProduct = 3,

        /// <summary>
        /// Displays all products currently stored in the inventory.
        /// </summary>
        ListAllProducts = 4,

        /// <summary>
        /// Removes a product from the inventory.
        /// </summary>
        DeleteProduct = 5,

        /// <summary>
        /// Exits the inventory management application.
        /// </summary>
        Exit = 6,
    }
}