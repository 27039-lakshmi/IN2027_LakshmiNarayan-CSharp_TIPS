using InventoryManager.Helper;
using InventoryManager.Models;
using InventoryManager.Services;

namespace InventoryManager.View
{
    /// <summary>
    /// Handles all user interactions related to inventory management,
    /// including displaying menus, reading user input, and showing product information.
    /// </summary>
    public static class UserViewer
    {
        /// <summary>
        /// Provides inventory operations such as add, update, search, and delete.
        /// </summary>
        private static readonly InventoryService InventoryService = new ();

        /// <summary>
        /// Starts the inventory management user interface and displays the menu
        /// until the user chooses to exit the application.
        /// </summary>
        public static void Start()
        {
            int userChoice;

            do
            {
                Console.WriteLine(Messages.MenuText);

                if (int.TryParse(Console.ReadLine(), out userChoice))
                {
                    switch (userChoice)
                    {
                        case 1:
                            (string productId, string productName, int productPrice, int productQuantity, bool isDetailsValid) = GetProductDetails();

                            if (isDetailsValid)
                            {
                                InventoryService.AddProduct(
                                    productId,
                                    productName,
                                    productPrice,
                                    productQuantity);

                                Console.WriteLine(Messages.AddSuccessMessage);
                            }

                            break;

                        case 2:
                            if (InventoryService.IsInventoryEmpty(out string errorMessage))
                            {
                                Console.WriteLine(errorMessage);
                                continue;
                            }

                            Console.WriteLine(Messages.ProductEditDetailsMessage);

                            (string newProductId, string newProductName, int newProductPrice, int newProductQuantity, isDetailsValid) = GetProductDetails();
                            if (isDetailsValid)
                            {
                                InventoryService.UpdateProduct(
                                    newProductId,
                                    newProductName,
                                    newProductPrice,
                                    newProductQuantity);
                            }

                            break;

                        case 3:
                            if (InventoryService.IsInventoryEmpty(out errorMessage))
                            {
                                Console.WriteLine(errorMessage);
                                continue;
                            }

                            string productNameToSearch = GetProductName();

                            var productsMatched =
                                InventoryService.ListProductsByName(productNameToSearch);

                            if (productsMatched != null && productsMatched.Count > 0)
                            {
                                DisplayProducts(productsMatched);
                            }
                            else
                            {
                                Console.WriteLine(Messages.ProductNotExistMessage);
                            }

                            break;

                        case 4:
                            if (InventoryService.IsInventoryEmpty(out errorMessage))
                            {
                                Console.WriteLine(errorMessage);
                                continue;
                            }

                            var allProducts = InventoryService.ListAllProducts();
                            DisplayProducts(allProducts);

                            break;

                        case 5:
                            if (InventoryService.IsInventoryEmpty(out errorMessage))
                            {
                                Console.WriteLine(errorMessage);
                                continue;
                            }

                            string productIdToDelete = GetProductId();

                            InventoryService.DeleteProduct(
                                productIdToDelete,
                                out bool deleteStatus);

                            if (deleteStatus)
                            {
                                Console.WriteLine(Messages.DeleteSuccessMessage);
                            }
                            else
                            {
                                Console.WriteLine(Messages.DeleteFailMessage);
                            }

                            break;

                        case 6:
                            Console.WriteLine(Messages.ExitMessage);
                            break;

                        default:
                            Console.WriteLine(Messages.InvalidChoiceMessage);
                            break;
                    }
                }
                else
                {
                    Console.WriteLine(Messages.InvalidChoiceMessage);
                }
            }
            while (userChoice != 6);
        }

        /// <summary>
        /// Collects and validates product details entered by the user.
        /// </summary>
        /// <returns>
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
        public static (
            string ProductId,
            string ProductName,
            int ProductPrice,
            int ProductQuantity,
            bool IsSuccess) GetProductDetails()
        {
            const string EmptyString = "";
            var failureResult = (EmptyString, EmptyString, 0, 0, false);

            string productId = GetProductId();

            if (Validators.IsNullOrWhiteSpace(productId))
            {
                Console.WriteLine(Messages.NullErrorMessage);
                return failureResult;
            }

            if (InventoryService.DoesProductIdExist(productId))
            {
                Console.WriteLine(Messages.DuplicateIdMessage);
                return failureResult;
            }

            string productName = GetProductName();

            if (Validators.IsNullOrWhiteSpace(productName))
            {
                Console.WriteLine(Messages.NullErrorMessage);
                return failureResult;
            }

            if (!GetPositiveInteger(Messages.ProductPriceMessage, out int productPrice))
            {
                return failureResult;
            }

            if (!GetPositiveInteger(Messages.ProductQuantityMessage, out int productQuantity))
            {
                return failureResult;
            }

            return (productId, productName, productPrice, productQuantity, true);
        }

        /// <summary>
        /// Prompts the user to enter a product ID.
        /// </summary>
        /// <returns>The product ID entered by the user.</returns>
        public static string GetProductId()
        {
            Console.WriteLine(Messages.ProductIdMessage);
            string productId = Console.ReadLine() ?? string.Empty;

            return productId;
        }

        /// <summary>
        /// Prompts the user to enter a product name.
        /// </summary>
        /// <returns>The product name entered by the user.</returns>
        public static string GetProductName()
        {
            Console.WriteLine(Messages.ProductNameMessage);
            string productName = Console.ReadLine() ?? string.Empty;

            return productName;
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
        public static bool GetPositiveInteger(string message, out int value)
        {
            Console.WriteLine(message);

            if (!int.TryParse(Console.ReadLine(), out value) || value < 0)
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
        public static void DisplayProducts(List<Product> products)
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