using InventoryManager.Models;
using InventoryManager.Repository;

namespace InventoryManager.Services
{
    /// <summary>
    /// Provides business logic and operations for managing products
    /// within the inventory system.
    /// </summary>
    internal class InventoryService
    {
        /// <summary>
        /// Repository used to store and manage inventory products.
        /// </summary>
        private Inventory _inventory = new ();

        /// <summary>
        /// Creates and adds a new product to the inventory.
        /// </summary>
        /// <param name="productId">The unique identifier of the product.</param>
        /// <param name="productName">The name of the product.</param>
        /// <param name="productPrice">The price of the product.</param>
        /// <param name="productQuantity">The available quantity of the product.</param>
        public void AddProduct(
            string productId,
            string productName,
            int productPrice,
            int productQuantity)
        {
            Product newProduct = this.CreateProduct(
                productId,
                productName,
                productPrice,
                productQuantity);

            this._inventory.Add(newProduct);
        }

        /// <summary>
        /// Updates an existing product with new details.
        /// </summary>
        /// <param name="productId">The identifier of the product to update.</param>
        /// <param name="productName">The updated product name.</param>
        /// <param name="productPrice">The updated product price.</param>
        /// <param name="productQuantity">The updated product quantity.</param>
        public void UpdateProduct(
            string productId,
            string productName,
            int productPrice,
            int productQuantity)
        {
            Product oldProduct = this._inventory.GetById(productId) !;

            Product newProduct = this.CreateProduct(
                productId,
                productName,
                productPrice,
                productQuantity);

            this._inventory.Update(oldProduct, newProduct);
        }

        /// <summary>
        /// Creates a new product instance.
        /// </summary>
        /// <param name="productId">The product identifier.</param>
        /// <param name="productName">The product name.</param>
        /// <param name="productPrice">The product price.</param>
        /// <param name="productQuantity">The product quantity.</param>
        /// <returns>
        /// A newly created <see cref="Product"/> object.
        /// </returns>
        public Product CreateProduct(
            string productId,
            string productName,
            int productPrice,
            int productQuantity)
        {
            return new Product(
                productId,
                productName,
                productPrice,
                productQuantity);
        }

        /// <summary>
        /// Deletes a product from the inventory using its identifier.
        /// </summary>
        /// <param name="productId">
        /// The identifier of the product to delete.
        /// </param>
        /// <param name="deleteStatus">
        /// Returns <c>true</c> if the product was successfully deleted;
        /// otherwise, <c>false</c>.
        /// </param>
        public void DeleteProduct(string productId, out bool deleteStatus)
        {
            var product = this._inventory.GetById(productId);

            if (product != null)
            {
                this._inventory.Remove(product);
                deleteStatus = true;
                return;
            }

            deleteStatus = false;
        }

        /// <summary>
        /// Determines whether a product with the specified identifier
        /// exists in the inventory.
        /// </summary>
        /// <param name="productId">
        /// The product identifier to search for.
        /// </param>
        /// <returns>
        /// <c>true</c> if the product exists; otherwise, <c>false</c>.
        /// </returns>
        public bool DoesProductIdExist(string productId)
        {
            return this._inventory.GetById(productId) != null;
        }

        /// <summary>
        /// Retrieves all products whose names match the specified value.
        /// </summary>
        /// <param name="productName">
        /// The product name or prefix to search for.
        /// </param>
        /// <returns>
        /// A list of matching products.
        /// </returns>
        public List<Product> ListProductsByName(string productName)
        {
            return this._inventory.GetProductsByName(productName);
        }

        /// <summary>
        /// Retrieves all products from the inventory.
        /// </summary>
        /// <returns>
        /// A list containing all available products.
        /// </returns>
        public List<Product> ListAllProducts()
        {
            return this._inventory.GetAllProducts();
        }

        /// <summary>
        /// Retrieves the total number of products in the inventory.
        /// </summary>
        /// <returns>
        /// The product count.
        /// </returns>
        public int GetProductsCount()
        {
            return this._inventory.GetTotalProductsCount();
        }

        /// <summary>
        /// Determines whether the inventory contains any products.
        /// </summary>
        /// <param name="message">
        /// Returns a message indicating that the inventory is empty.
        /// </param>
        /// <returns>
        /// <c>true</c> if the inventory contains no products;
        /// otherwise, <c>false</c>.
        /// </returns>
        public bool IsInventoryEmpty(out string message)
        {
            message = "Inventory is Empty . Please add products first\n";

            if (this.GetProductsCount() == 0)
            {
                Console.WriteLine();
                return true;
            }

            return false;
        }
    }
}