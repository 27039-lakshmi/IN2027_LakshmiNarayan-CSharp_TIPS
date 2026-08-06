using InventoryManager.Models;

namespace InventoryManager.Repository
{
    /// <summary>
    /// Represents an in-memory inventory repository that stores and manages products.
    /// Provides methods to add, retrieve, update, remove, and count products.
    /// </summary>
    public static class Inventory
    {
        /// <summary>
        /// Stores the collection of products in the inventory.
        /// </summary>
        private static List<Product> _inventory = new ();

        /// <summary>
        /// Adds a product to the inventory.
        /// </summary>
        /// <param name="product">
        /// The product to be added.
        /// </param>
        public static void Add(Product product)
        {
            _inventory.Add(product);
        }

        /// <summary>
        /// Retrieves a product by its unique identifier.
        /// </summary>
        /// <param name="id">
        /// The identifier of the product to retrieve.
        /// </param>
        /// <returns>
        /// The matching product if found; otherwise, <c>null</c>.
        /// </returns>
        public static Product? GetById(string id)
        {
            return _inventory.Find(p => p.Id == id);
        }

        /// <summary>
        /// Updates an existing product with the details of another product.
        /// </summary>
        /// <param name="oldProduct">
        /// The product to be updated.
        /// </param>
        /// <param name="newProduct">
        /// The product containing the new values.
        /// </param>
        public static void Update(Product oldProduct, Product newProduct)
        {
            oldProduct.Name = newProduct.Name;
            oldProduct.Price = newProduct.Price;
            oldProduct.Quantity = newProduct.Quantity;
        }

        /// <summary>
        /// Removes a product from the inventory.
        /// </summary>
        /// <param name="product">
        /// The product to remove.
        /// </param>
        public static void Remove(Product product)
        {
            _inventory.Remove(product);
        }

        /// <summary>
        /// Retrieves all products currently stored in the inventory.
        /// </summary>
        /// <returns>
        /// A list containing all products in the inventory.
        /// </returns>
        public static List<Product> GetAllProducts()
        {
            return _inventory.ToList();
        }

        /// <summary>
        /// Gets the total number of products stored in the inventory.
        /// </summary>
        /// <returns>
        /// The number of products in the inventory.
        /// </returns>
        public static int GetTotalProductsCount()
        {
            return _inventory.Count;
        }
    }
}