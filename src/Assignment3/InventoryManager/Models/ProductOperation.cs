namespace InventoryManager.Models
{
    /// <summary>
    /// Represents the operation being performed on a product.
    /// </summary>
    public enum ProductOperation
    {
        /// <summary>
        /// Indicates a new product is being added to the inventory.
        /// </summary>
        Add,

        /// <summary>
        /// Indicates an existing product is being updated.
        /// </summary>
        Update,
    }
}
