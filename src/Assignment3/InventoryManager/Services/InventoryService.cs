using InventoryManager.Models;
using InventoryManager.Repository;

namespace InventoryManager.Services
{
    /// <summary>
    /// Provides business logic and operations for managing products
    /// within the inventory system.
    /// </summary>
    public class InventoryService
    {
        /// <summary>
        /// Provides inventory repository along with CRUD operations.
        /// </summary>
        private readonly Inventory _inventoryRepo = new ();

        /// <summary>
        /// Creates and adds a new product to the inventory.
        /// </summary>
        /// <param name="newProduct">
        /// The product to be added to the inventory.
        /// </param>
        public void AddProduct(Product newProduct)
        {
            this._inventoryRepo.Add(newProduct);
        }

        /// <summary>
        /// Updates an existing product with new details.
        /// </summary>
        /// <param name="newProduct">
        /// Contains the updated product information,
        /// including the product identifier.
        /// </param>
        public void UpdateProduct(Product newProduct)
        {
            Product oldProduct = this._inventoryRepo.GetById(newProduct.Id) !;
            this._inventoryRepo.Update(oldProduct, newProduct);
        }

        /// <summary>
        /// Deletes a product from the inventory using its identifier.
        /// </summary>
        /// <param name="productId">
        /// The identifier of the product to delete.
        /// </param>
        /// <returns>
        /// <c>true</c> if the product was successfully deleted;
        /// otherwise, <c>false</c>.
        /// </returns>
        public bool DeleteProduct(string productId)
        {
            var product = this._inventoryRepo.GetById(productId);

            if (product != null)
            {
                this._inventoryRepo.Remove(product);
                return true;
            }

            return false;
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
        public bool DoesProductIdExist(string productId) => this._inventoryRepo.GetById(productId) != null;

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
            return this._inventoryRepo.GetAllProducts().Where(product => product.Name.StartsWith(productName, StringComparison.OrdinalIgnoreCase)).ToList();
        }

        /// <summary>
        /// Retrieves all products from the inventory.
        /// </summary>
        /// <returns>
        /// A list containing all available products.
        /// </returns>
        public List<Product> ListAllProducts()
        {
            return this._inventoryRepo.GetAllProducts();
        }

        /// <summary>
        /// Retrieves the total number of products in the inventory.
        /// </summary>
        /// <returns>
        /// The product count.
        /// </returns>
        public int GetProductsCount() => this._inventoryRepo.GetTotalProductsCount();

        /// <summary>
        /// Determines whether the inventory contains any products.
        /// </summary>
        /// <returns>
        /// <c>true</c> if the inventory contains no products;
        /// otherwise, <c>false</c>.
        /// </returns>
        public bool IsInventoryEmpty() => this.GetProductsCount() == 0;
    }
}