using InventoryManager.Helper;
using InventoryManager.Models;
using InventoryManager.Services;

namespace InventoryManager.View
{
    /// <summary>
    /// Handles all user interactions related to inventory management,
    /// including displaying menus, reading user input, and showing product information.
    /// </summary>
    public class InventoryView
    {
        /// <summary>
        /// Provides inventory operations such as add, update, search, and delete.
        /// </summary>
        private readonly InventoryService _inventoryService = new ();

        /// <summary>
        /// Provides validation operations for price, quantity, string.
        /// </summary>
        private readonly Validators _validators = new ();

        /// <summary>
        /// Starts the inventory management user interface and displays the menu
        /// until the user chooses to exit the application.
        /// </summary>
        public void Start()
        {
            int userChoice;

            do
            {
                Console.WriteLine(Messages.MenuText);

                if (int.TryParse(Console.ReadLine(), out userChoice))
                {
                    this.HandleMenuOptions((MenuOption)userChoice);
                }
                else
                {
                    Console.WriteLine(Messages.InvalidChoiceMessage);
                }
            }
            while (userChoice != (int)MenuOption.Exit);
        }

        /// <summary>
        /// Processes the selected menu option and invokes the corresponding
        /// inventory operation.
        /// </summary>
        /// <param name="option">
        /// The menu option selected by the user.
        /// </param>
        private void HandleMenuOptions(MenuOption option)
        {
            switch (option)
            {
                case MenuOption.AddProduct:
                    this.AddProduct();
                    break;

                case MenuOption.EditProduct:
                    this.EditProduct();
                    break;

                case MenuOption.SearchProduct:
                    this.SearchProduct();
                    break;

                case MenuOption.ListAllProducts:
                    this.ListAllProducts();
                    break;

                case MenuOption.DeleteProduct:
                    this.DeleteProduct();
                    break;

                case MenuOption.Exit:
                    Console.WriteLine(Messages.ExitMessage);
                    break;

                default:
                    Console.WriteLine(Messages.InvalidChoiceMessage);
                    break;
            }
        }

        /// <summary>
        /// Collects product details from the user and adds the product
        /// to the inventory if validation succeeds.
        /// </summary>
        private void AddProduct()
        {
            (Product productDetails, bool isDetailsValid) = this.GetProductDetails(ProductOperation.Add);

            if (isDetailsValid)
            {
                this._inventoryService.AddProduct(productDetails);

                Console.WriteLine(Messages.AddSuccessMessage);
            }
        }

        /// <summary>
        /// Collects updated product information from the user and updates
        /// an existing product in the inventory.
        /// </summary>
        private void EditProduct()
        {
            if (this._inventoryService.IsInventoryEmpty())
            {
                Console.WriteLine(Messages.InventoryEmptyMessage);
                return;
            }

            Console.WriteLine(Messages.ProductEditDetailsMessage);

            (Product newProduct, bool isDetailsValid) = this.GetProductDetails(ProductOperation.Update);
            if (isDetailsValid)
            {
                this._inventoryService.UpdateProduct(newProduct);
                Console.WriteLine(Messages.UpdateSuccessMessage);
            }
        }

        /// <summary>
        /// Searches for products by name and displays all matching products.
        /// </summary>
        private void SearchProduct()
        {
            if (this._inventoryService.IsInventoryEmpty())
            {
                Console.WriteLine(Messages.InventoryEmptyMessage);
                return;
            }

            string productNameToSearch = this.GetProductName();

            var productsMatched =
                this._inventoryService.ListProductsByName(productNameToSearch);

            if (productsMatched.Any())
            {
                this.DisplayProducts(productsMatched);
            }
            else
            {
                Console.WriteLine(Messages.ProductNotExistMessage);
            }
        }

        /// <summary>
        /// Deletes a product from the inventory using the provided product ID.
        /// </summary>
        private void DeleteProduct()
        {
            if (this._inventoryService.IsInventoryEmpty())
            {
                Console.WriteLine(Messages.InventoryEmptyMessage);
                return;
            }

            string productIdToDelete = this.GetProductId();

            bool deleteStatus = this._inventoryService.DeleteProduct(productIdToDelete);

            if (deleteStatus)
            {
                Console.WriteLine(Messages.DeleteSuccessMessage);
            }
            else
            {
                Console.WriteLine(Messages.DeleteFailMessage);
            }
        }

        /// <summary>
        /// Displays all the products from inventory
        /// </summary>
        private void ListAllProducts()
        {
            if (this._inventoryService.IsInventoryEmpty())
            {
                Console.WriteLine(Messages.InventoryEmptyMessage);
                return;
            }

            var allProducts = this._inventoryService.ListAllProducts();
            this.DisplayProducts(allProducts);
        }

        /// <summary>
        /// Collects product details entered by the user.
        /// </summary>
        /// <returns>
        /// <param name="operation">
        /// Specifies whether the product details are being collected
        /// for an add or update operation.
        /// </param>
        /// A tuple containing:
        /// <list type="bullet">
        /// <item>
        /// <description><c>ProductId</c> - The unique identifier of the product.</description>
        /// </item>
        /// <item>
        /// <description><c>ProductName</c> - The name of the product.</description>
        /// </item>
        /// <item>
        /// <description><c>ProductPrice</c> - The price of the product.</description>
        /// </item>
        /// <item>
        /// <description><c>ProductQuantity</c> - The available quantity of the product.</description>
        /// </item>
        /// <item>
        /// <description><c>IsSuccess</c> - Indicates whether all validations were successful.</description>
        /// </item>
        /// </list>
        /// Returns empty strings and zero values when validation fails.
        /// </returns>
        private (Product productDetails, bool isSuccess) GetProductDetails(ProductOperation operation)
        {
            var failureResult = (new Product(string.Empty, string.Empty, 0, 0), false);

            string productId = this.GetProductId();

            if (this._validators.IsValidString(productId))
            {
                Console.WriteLine(Messages.NullErrorMessage);
                return failureResult;
            }

            if (operation == ProductOperation.Add && this._inventoryService.DoesProductIdExist(productId))
            {
                Console.WriteLine(Messages.DuplicateIdMessage);
                return failureResult;
            }
            else if (operation == ProductOperation.Update && !this._inventoryService.DoesProductIdExist(productId))
            {
                Console.WriteLine(Messages.ProductIdNotExist);
                return failureResult;
            }

            string productName = this.GetProductName();

            if (this._validators.IsValidString(productName))
            {
                Console.WriteLine(Messages.NullErrorMessage);
                return failureResult;
            }

            if (!this.GetProductPriceInput(Messages.ProductPriceMessage, out decimal productPrice))
            {
                return failureResult;
            }

            if (!this.GetProductQuantityInput(Messages.ProductQuantityMessage, out int productQuantity))
            {
                return failureResult;
            }

            return (new Product(productId, productName, productPrice, productQuantity), true);
        }

        /// <summary>
        /// Prompts the user to enter a product ID.
        /// </summary>
        /// <returns>The product ID entered by the user.</returns>
        private string GetProductId()
        {
            Console.WriteLine(Messages.ProductIdMessage);
            string productId = Console.ReadLine() ?? string.Empty;

            return productId;
        }

        /// <summary>
        /// Prompts the user to enter a product name.
        /// </summary>
        /// <returns>The product name entered by the user.</returns>
        private string GetProductName()
        {
            Console.WriteLine(Messages.ProductNameMessage);
            string productName = Console.ReadLine() ?? string.Empty;

            return productName;
        }

        /// <summary>
        /// Prompts the user for a product price input
        /// </summary>
        /// <param name="message">
        /// The message displayed to request the input.
        /// </param>
        /// <param name="value">
        /// When this method returns, contains the parsed decimal value if valid;
        /// otherwise contains zero.
        /// </param>
        /// <returns>
        /// <c>true</c> if a valid non-negative decimal was entered;
        /// otherwise, <c>false</c>.
        /// </returns>
        private bool GetProductPriceInput(string message, out decimal value)
        {
            Console.WriteLine(message);
            string productPriceInput = Console.ReadLine() ?? string.Empty;
            if (!this._validators.IsPriceValid(productPriceInput, out value))
            {
                Console.WriteLine(Messages.PositiveInputErrorMessage);
                return false;
            }

            return true;
        }

        /// <summary>
        /// Prompts the user for a positive integer value and validates the input.
        /// </summary>
        /// <param name="message">
        /// The message displayed to request the input.
        /// </param>
        /// <param name="value">
        /// When this method returns, contains the parsed integer value if valid;
        /// otherwise contains zero.
        /// </param>
        /// <returns>
        /// <c>true</c> if a valid non-negative integer was entered;
        /// otherwise, <c>false</c>.
        /// </returns>
        private bool GetProductQuantityInput(string message, out int value)
        {
            Console.WriteLine(message);
            string productQuantityInput = Console.ReadLine() ?? string.Empty;
            if (!this._validators.IsQuantityValid(productQuantityInput, out value))
            {
                Console.WriteLine(Messages.PositiveInputErrorMessage);
                return false;
            }

            return true;
        }

        /// <summary>
        /// Displays a list of products with their details including
        /// ID, name, price, and quantity.
        /// </summary>
        /// <param name="products">
        /// The collection of products to display.
        /// </param>
        private void DisplayProducts(List<Product> products)
        {
            foreach (Product product in products)
            {
                Console.WriteLine(
                    $"{Messages.ProductIdMessage} : {product.Id}\n" +
                    $"{Messages.ProductNameMessage} : {product.Name}\n" +
                    $"{Messages.ProductPriceMessage} : {product.Price}\n" +
                    $"{Messages.ProductQuantityMessage} : {product.Quantity}");
            }
        }
    }
}