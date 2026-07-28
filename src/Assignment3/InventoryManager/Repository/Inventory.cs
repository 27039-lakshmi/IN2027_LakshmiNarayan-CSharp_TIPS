using InventoryManager.Models;

namespace InventoryManager.Repository
{
    /// <summary>
    /// Represents an in-memory inventory repository that stores and manages products.
    /// Provides methods to add, retrieve, update, remove, and count products.
    /// </summary>
    internal class Inventory
    {
        /// <summary>
        /// Stores the collection of products in the inventory.
        /// </summary>
        private List<Product> _inventory = new ();

        /// <summary>
        /// Adds a product to the inventory.
        /// </summary>
        /// <param name="product">
        /// The product to be added.
        /// </param>
        public void Add(Product product)
        {
            this._inventory.Add(product);
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
        public Product? GetById(string id)
        {
            return this._inventory.Find(p => p.Id == id);
        }

        /// <summary>
        /// Retrieves all products whose names start with the specified value.
        /// </summary>
        /// <param name="name">
        /// The name or partial name to search for.
        /// </param>
        /// <returns>
        /// A list of matching products. Returns an empty list if no products are found.
        /// </returns>
        public List<Product> GetProductsByName(string name)
        {
            var productsFound = this._inventory
                .Where(product => product.Name.StartsWith(name))
                .ToList();

            return productsFound;
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
        public void Update(Product oldProduct, Product newProduct)
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
        public void Remove(Product product)
        {
            this._inventory.Remove(product);
        }

        /// <summary>
        /// Retrieves all products currently stored in the inventory.
        /// </summary>
        /// <returns>
        /// A list containing all products in the inventory.
        /// </returns>
        public List<Product> GetAllProducts()
        {
            return this._inventory.ToList();
        }

        /// <summary>
        /// Gets the total number of products stored in the inventory.
        /// </summary>
        /// <returns>
        /// The number of products in the inventory.
        /// </returns>
        public int GetTotalProductsCount()
        {
            return this._inventory.Count;
        }
    }
}