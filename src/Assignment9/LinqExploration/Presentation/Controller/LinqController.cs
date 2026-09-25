using System.Diagnostics;
using ConsoleTables;
using LinqExploration.Application.Service;
using LinqExploration.Domain.Models;

namespace LinqExploration.Presentation.Controller
{
    /// <summary>
    /// Coordinates the execution of LINQ demonstration tasks.
    /// </summary>
    public class LinqController
    {
        private readonly ProductService _productService;

        private readonly SupplierService _supplierService;

        private readonly ArrayService _arrayService;

        /// <summary>
        /// Initializes a new instance of the <see cref="LinqController"/> class.
        /// </summary>
        /// <param name="productService">Instance of ProductService from program.cs</param>
        /// <param name="supplierService">Instance of SupplierService from program.cs</param>
        /// <param name="arrayService">Instance of ArrayService from program.cs</param>
        public LinqController(ProductService productService, SupplierService supplierService, ArrayService arrayService)
        {
            this._productService = productService;
            this._supplierService = supplierService;
            this._arrayService = arrayService;
        }

        /// <summary>
        /// Seeds sample product and supplier data and executes all LINQ tasks.
        /// </summary>
        public void Start()
        {
            this.AddProducts();
            this.AddSuppliers();
            int userChoice;
            do
            {
                Console.WriteLine("Enter your choice\n" +
                                  "[1] Execute Task1\n" +
                                  "[2] Execute Task2\n" +
                                  "[3] Execute Task3\n" +
                                  "[4] Execute Task4\n" +
                                  "[5] Execute Task5\n" +
                                  "[6] Exit");
                if (!int.TryParse(Console.ReadLine(), out userChoice))
                {
                    Console.WriteLine("Choice must be an integer");
                    continue;
                }

                switch (userChoice)
                {
                    case 1:
                        this.ExecuteTask1();
                        break;
                    case 2:
                        this.ExecuteTask2();
                        break;
                    case 3:
                        this.ExecuteTask3();
                        break;
                    case 4:
                        this.ExecuteTask4();
                        break;
                    case 5:
                        this.ExecuteTask5();
                        break;
                    case 6:
                        Console.WriteLine("Exitting");
                        break;
                    default:
                        Console.WriteLine("Invalid choice");
                        break;
                }
            }
            while (userChoice != 6);
        }

        /// <summary>
        /// Adds a list of products to product database
        /// </summary>
        private void AddProducts()
        {
            this._productService.AddProducts(new List<Product>
        {
             new Product(1, "Soap", 20, "Daily_Utilities"),
             new Product(2, "Phone", 10000, "Electronics"),
             new Product(3, "TV", 500000, "Electronics"),
             new Product(4, "Laptop", 70000, "Electronics"),
             new Product(5, "Shampoo", 55, "Daily_Utilities"),
             new Product(6, "Trimmer", 100, "Electronics"),
        });
        }

        /// <summary>
        /// Adds a list of suppliers to supplier database
        /// </summary>
        private void AddSuppliers()
        {
            this._supplierService.AddSuppliers(new List<Supplier>()
            {
                    new Supplier(101, "ABC Electronics", 1),
                    new Supplier(102, "XYZ Mobiles", 2),
                    new Supplier(103, "Comfort Furnitures", 3),
                    new Supplier(104, "Wood Works", 4),
                    new Supplier(105, "Home Appliances Ltd", 5),
            });
        }

        /// <summary>
        /// Demonstrates filtering, sorting, and aggregation operations on products.
        /// </summary>
        private void ExecuteTask1()
        {
            var products = this._productService.GetProducts();
            Console.WriteLine("Performing task1");
            this.PrintProducts(products);
            var filteredProducts = this._productService.GetFilteredProducts();
            this.DisplayFilteredProducts(filteredProducts);

            var sortedFilteredProducts = filteredProducts.OrderByDescending(product => product.Price).ToList();
            this.DisplaySortedProducts(sortedFilteredProducts);

            decimal averagePrice = filteredProducts.Average(product => product.Price);
            this.DisplayAveragePrice(averagePrice);
        }

        /// <summary>
        /// Displays the calculated average price of the filtered products.
        /// </summary>
        /// <param name="averagePrice">
        /// The average price to display.
        /// </param>
        private void DisplayAveragePrice(decimal averagePrice)
        {
            Console.WriteLine("Average of price: " + averagePrice);
        }

        /// <summary>
        /// Displays the filtered products sorted in descending order of price.
        /// </summary>
        /// <param name="sortedFilteredProducts">
        /// The collection of products sorted by price in descending order.
        /// </param>
        private void DisplaySortedProducts(List<ProductDTO> sortedFilteredProducts)
        {
            var table = new ConsoleTable("S.No", "Product Name", "Product Price");
            Console.WriteLine("Sorted by descending");
            for (int i = 0; i < sortedFilteredProducts.Count; i++)
            {
                table.AddRow(i + 1, sortedFilteredProducts[i].Name, sortedFilteredProducts[i].Price);
            }

            table.Write(Format.MarkDown);
            table.Rows.Clear();
        }

        /// <summary>
        /// Displays the filtered products in a tabular format.
        /// </summary>
        /// <param name="products">
        /// The filtered products to display.
        /// </param>
        private void DisplayFilteredProducts(IReadOnlyList<ProductDTO> products)
        {
            Console.WriteLine(
                "Filtered products category \"Electronics\" with a price greater than $500");

            var table = new ConsoleTable("S.No", "Product Name", "Product Price");

            for (int i = 0; i < products.Count; i++)
            {
                table.AddRow(i + 1, products[i].Name, products[i].Price);
            }

            table.Write(Format.MarkDown);
        }

        /// <summary>
        /// Demonstrates grouping products by category and joining products with suppliers.
        /// </summary>
        private void ExecuteTask2()
        {
            var products = this._productService.GetProducts();
            Console.WriteLine("Performing Task2");
            this.PrintProducts(products);
            var productCategoryWiseSummary = this._productService.GetProductCategorySummary();
            this.DisplayCategorySummary(productCategoryWiseSummary);
            var suppliers = this._supplierService.GetSuppliers();
            this.DisplaySuppliers(suppliers);
            var supplierProductMapping = this._supplierService.GetProductWithSuppliers();
            this.DisplaySupplierProductMapping(supplierProductMapping);
        }

        /// <summary>
        /// Displays the supplier and product mappings produced by the join operation.
        /// </summary>
        /// <param name="supplierProductMapping">
        /// The collection containing supplier and product information.
        /// </param>
        private void DisplaySupplierProductMapping(List<ProductWithSupplierDto> supplierProductMapping)
        {
            var supplierProductMappingTable = new ConsoleTable("Supplier Id", "Supplier Name", "Product Id", "Product Name");
            foreach (var item in supplierProductMapping)
            {
                supplierProductMappingTable.AddRow(item.SupplierId, item.SupplierName, item.ProductId, item.ProductName);
            }

            supplierProductMappingTable.Write(Format.MarkDown);
        }

        /// <summary>
        /// Displays the list of suppliers in a tabular format.
        /// </summary>
        /// <param name="suppliers">
        /// The suppliers to display.
        /// </param>
        private void DisplaySuppliers(IEnumerable<Supplier> suppliers)
        {
            var supplierTable = new ConsoleTable("Supplier Id", "Supplier Name", "Product ID");
            Console.WriteLine("Supplier List");
            foreach (var supplier in suppliers)
            {
                supplierTable.AddRow(supplier.SupplierId, supplier.SupplierName, supplier.ProductId);
            }

            supplierTable.Write(Format.MarkDown);
        }

        /// <summary>
        /// Displays the category-wise product summary including product count
        /// and the most expensive product in each category.
        /// </summary>
        /// <param name="productCategoryWiseSummary">
        /// The category summary data to display.
        /// </param>
        private void DisplayCategorySummary(IReadOnlyList<CategorySummaryDTO> productCategoryWiseSummary)
        {
            var categorySummaryTable = new ConsoleTable("Category", "Number of products", "Expensive Product");
            Console.WriteLine("Category-wise summary for products");
            foreach (var category in productCategoryWiseSummary)
            {
                categorySummaryTable.AddRow(category.Category, category.Count, category.ExpensiveProduct);
            }

            categorySummaryTable.Write(Format.MarkDown);
        }

        /// <summary>
        /// Demonstrates array-based LINQ operations including finding the
        /// second highest element and identifying number pairs matching a target sum.
        /// </summary>
        private void ExecuteTask3()
        {
            Console.WriteLine("Performing Task3");
            int[] arr = new int[] { 10, 20, 30, 40, 60, 70, 80, 90 };
            this.DisplayArray(arr);

            int secondHighest = this._arrayService.GetSecondHighestElement(arr);
            Console.WriteLine("Second highest element " + secondHighest);

            int target = 100;
            var pairs = this._arrayService.GetPairsWithTargetSum(arr, target);
            this.DisplayPairsWithTargetSum(pairs);
        }

        /// <summary>
        /// Displays the pairs of numbers whose sum matches the target value.
        /// </summary>
        /// <param name="pairs">
        /// The collection of matching number pairs.
        /// </param>
        private void DisplayPairsWithTargetSum(List<PairsDTO> pairs)
        {
            Console.WriteLine($"Pairs with target sum");

            foreach (var pair in pairs)
            {
                Console.WriteLine(
                    $"Number 1 : {pair.FirstNumber} Number 2 : {pair.SecondNumber}");
            }
        }

        /// <summary>
        /// Displays all elements of the input array.
        /// </summary>
        /// <param name="arr">
        /// The array to display.
        /// </param>
        private void DisplayArray(int[] arr)
        {
            Console.WriteLine("Array");
            foreach (int num in arr)
            {
                Console.Write(num + " ");
            }
        }

        /// <summary>
        /// Compares the performance of optimized and non-optimized LINQ queries.
        /// </summary>
        private void ExecuteTask4()
        {
            Console.WriteLine("Performing Task4");
            this.PerformUnoptimisedQuery();
            this.PerformOptimisedQuery();
        }

        /// <summary>
        /// Executes the non-optimized product filtering query and
        /// displays its execution time.
        /// </summary>
        private void PerformUnoptimisedQuery()
        {
            var stopWatch = new Stopwatch();
            Console.WriteLine("Unoptimised Query");
            stopWatch.Start();
            var productsUnderBooks = this._productService.FilterWithoutOptimisation();
            stopWatch.Stop();
            double unoptimisedTime = stopWatch.Elapsed.TotalMilliseconds;
            this.PrintProducts(productsUnderBooks);
            Console.WriteLine("Execution time: " + unoptimisedTime);
        }

        /// <summary>
        /// Executes the optimized product filtering query and
        /// displays its execution time.
        /// </summary>
        private void PerformOptimisedQuery()
        {
            var stopWatch = new Stopwatch();
            Console.WriteLine("Optimised Query");
            stopWatch.Restart();
            var productsUnderBooks = this._productService.FilterWithOptimisation();
            stopWatch.Stop();
            double optimisedTime = stopWatch.Elapsed.TotalMilliseconds;
            this.PrintProducts(productsUnderBooks);
            Console.WriteLine("Execution time: " + optimisedTime);
        }

        /// <summary>
        /// Demonstrates the custom QueryBuilder fluent API with filtering,
        /// sorting, joining, and query execution.
        /// </summary>
        private void ExecuteTask5()
        {
            Console.WriteLine("Performing Task5");
            Console.WriteLine("Category : Electronics, SortBy : Price");
            var result = new QueryBuilder<Product>(this._productService.GetProducts())
                .Filter(product => product.Category == "Electronics")
                .SortBy(product => product.Price)
                .Join(
                      this._supplierService.GetSuppliers(),
                      p => p.ProductId,
                      s => s.ProductId,
                      (p, s) => new { SupplierName = s.SupplierName, ProductName = p.ProductName })
                .Execute();
            this.PrintSupplierProducts(result);
        }

        /// <summary>
        /// Displays supplier and product information returned by the query builder.
        /// </summary>
        /// <param name="products">
        /// The collection containing supplier and product details.
        /// </param>
        private void PrintSupplierProducts(IEnumerable<dynamic> products)
        {
            foreach (var item in products)
            {
                Console.WriteLine(
                    $"Supplier Name : {item.SupplierName}\n" +
                    $"Product Name  : {item.ProductName}");
            }
        }

        /// <summary>
        /// Displays the provided products in a tabular format.
        /// </summary>
        /// <param name="products">
        /// The products to display.
        /// </param>
        private void PrintProducts(IReadOnlyList<Product> products)
        {
            Console.WriteLine("Products List");
            var table = new ConsoleTable("Product ID", "Product Name", "Category", "Price");
            foreach (var product in products)
            {
                table.AddRow(product.ProductId, product.ProductName, product.Category, product.Price);
            }

            table.Write(Format.MarkDown);
        }
    }
}
