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
        private ProductService _productService;

        private SupplierService _supplierService;

        private ArrayService _arrayService;

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
            this._productService.AddProducts(new List<Product>
        {
            new Product
            {
                ProductId = 1,
                ProductName = "Laptop",
                Price = 600m,
                Category = "Electronics",
            },
            new Product
            {
                ProductId = 2,
                ProductName = "Smartphone",
                Price = 550m,
                Category = "Electronics",
            },

            new Product
            {
                ProductId = 3,
                ProductName = "Office Chair",
                Price = 200m,
                Category = "Furniture",
            },
            new Product
            {
                ProductId = 4,
                ProductName = "Desk",
                Price = 1200m,
                Category = "Furniture",
            },
            new Product
            {
                ProductId = 5,
                ProductName = "Coffee Maker",
                Price = 300m,
                Category = "Appliances",
            },
            new Product
            {
                ProductId = 6,
                ProductName = "Harry Potter",
                Price = 200m,
                Category = "Books",
            },
            new Product
            {
                ProductId = 7,
                ProductName = "Game of thrones",
                Price = 550m,
                Category = "Books",
            },
        });

            this._supplierService.AddSuppliers(new List<Supplier>()
            {
                new Supplier
            {
                SupplierId = 101,
                SupplierName = "ABC Electronics",
                ProductId = 1,
            },
                new Supplier
            {
                SupplierId = 102,
                SupplierName = "XYZ Mobiles",
                ProductId = 2,
            },
                new Supplier
            {
                SupplierId = 103,
                SupplierName = "Comfort Furnitures",
                ProductId = 3,
            },
                new Supplier
            {
                SupplierId = 104,
                SupplierName = "Wood Works",
                ProductId = 4,
            },
                new Supplier
            {
                SupplierId = 105,
                SupplierName = "Home Appliances Ltd",
                ProductId = 5,
            },
            });
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
                    Console.WriteLine("Invalid choice");
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
        /// Demonstrates filtering, sorting, and aggregation operations on products.
        /// </summary>
        public void ExecuteTask1()
        {
            var products = this._productService.GetProducts();
            var productsTable = new ConsoleTable("Product ID", "Product Name", "Category", "Price");
            Console.WriteLine("Performing task1");
            Console.WriteLine("Products List");
            foreach (var product in products)
            {
                productsTable.AddRow(product.ProductId, product.ProductName, product.Category, product.Price);
            }

            productsTable.Write(Format.MarkDown);
            productsTable.Rows.Clear();
            var filteredProducts = this._productService.GetFilteredProducts();
            var sortedFilteredProducts = filteredProducts.OrderByDescending(product => product.Price).ToList();
            decimal averagePrice = filteredProducts.Average(product => product.Price);
            var filteredTable = new ConsoleTable("S.No", "Product Name", "Product Price");
            Console.WriteLine("Filtered products category \"Electronics\" with a price greater than $500");
            for (int i = 0; i < filteredProducts.Count; i++)
            {
                filteredTable.AddRow(i + 1, filteredProducts[i].Name, filteredProducts[i].Price);
            }

            filteredTable.Write(Format.MarkDown);
            filteredTable.Rows.Clear();
            Console.WriteLine("Sorted by descending");
            for (int i = 0; i < sortedFilteredProducts.Count; i++)
            {
                filteredTable.AddRow(i + 1, sortedFilteredProducts[i].Name, sortedFilteredProducts[i].Price);
            }

            filteredTable.Write(Format.MarkDown);
            filteredTable.Rows.Clear();
            Console.WriteLine("Average of price: " + averagePrice);
        }

        /// <summary>
        /// Demonstrates grouping products by category and joining products with suppliers.
        /// </summary>
        public void ExecuteTask2()
        {
            var products = this._productService.GetProducts();
            var productsTable = new ConsoleTable("Product ID", "Product Name", "Category", "Price");
            Console.WriteLine("Performing Task2");
            Console.WriteLine("Products List");
            foreach (var product in products)
            {
                productsTable.AddRow(product.ProductId, product.ProductName, product.Category, product.Price);
            }

            productsTable.Write(Format.MarkDown);
            productsTable.Rows.Clear();

            var productCategoryWiseSummary = this._productService.GetProductCategorySummary();
            var categorySummaryTable = new ConsoleTable("Category", "Number of products", "Expensive Product");
            Console.WriteLine("Category-wise summary for products");
            foreach (var category in productCategoryWiseSummary)
            {
                categorySummaryTable.AddRow(category.Category, category.Count, category.ExpensiveProduct);
            }

            categorySummaryTable.Write(Format.MarkDown);
            var suppliers = this._supplierService.GetSuppliers();
            var supplierTable = new ConsoleTable("Supplier Id", "Supplier Name", "Product ID");
            Console.WriteLine("Supplier List");
            foreach (var supplier in suppliers)
            {
                supplierTable.AddRow(supplier.SupplierId, supplier.SupplierName, supplier.ProductId);
            }

            supplierTable.Write(Format.MarkDown);
            var supplierProductMappingTable = new ConsoleTable("Supplier Id", "Supplier Name", "Product Id", "Product Name");
            var supplierProductMapping = this._supplierService.GetProductWithSuppliers();
            foreach (var item in supplierProductMapping)
            {
                supplierProductMappingTable.AddRow(item.SupplierId, item.SupplierName, item.ProductId, item.ProductName);
            }

            supplierProductMappingTable.Write(Format.MarkDown);
        }

        /// <summary>
        /// Demonstrates array-based LINQ operations including finding the
        /// second highest element and identifying number pairs matching a target sum.
        /// </summary>
        public void ExecuteTask3()
        {
            Console.WriteLine("Performing Task3");
            int[] arr = new int[] { 10, 20, 30, 40, 60, 70, 80, 90 };
            Console.WriteLine("Array");
            foreach (int num in arr)
            {
                Console.Write(num + " ");
            }

            int secondHighest = this._arrayService.GetSecondHighestElement(arr);
            Console.WriteLine("Second highest element " + secondHighest);
            int target = 100;
            var listOfPairs = this._arrayService.GetPairs(arr, target);
            Console.WriteLine("Pairs with target sum 100");
            foreach (var pair in listOfPairs)
            {
                Console.WriteLine($"Number 1 : {pair.FirstNumber} Number 2 : {pair.SecondNumber}");
            }
        }

        /// <summary>
        /// Compares the performance of optimized and non-optimized LINQ queries.
        /// </summary>
        public void ExecuteTask4()
        {
            Console.WriteLine("Performing Task4");
            Console.WriteLine("Unoptimised Query");
            var stopWatch = new Stopwatch();
            stopWatch.Start();
            var productsUnderBooks = this._productService.FilterWithoutOptimisation();
            stopWatch.Stop();
            double unoptimisedTime = stopWatch.Elapsed.TotalMilliseconds;
            var bookProductsTable = new ConsoleTable("Product ID", "Product Name", "Category", "Price");
            foreach (var item in productsUnderBooks)
            {
                bookProductsTable.AddRow(item.ProductId, item.ProductName, item.Category, item.Price);
            }

            bookProductsTable.Write(Format.MarkDown);
            Console.WriteLine("Execution time: " + unoptimisedTime);
            bookProductsTable.Rows.Clear();

            Console.WriteLine("Optimised Query");
            stopWatch.Restart();
            productsUnderBooks = this._productService.FilterWithOptimisation();
            stopWatch.Stop();
            double optimisedTime = stopWatch.Elapsed.TotalMilliseconds;
            foreach (var item in productsUnderBooks)
            {
                bookProductsTable.AddRow(item.ProductId, item.ProductName, item.Category, item.Price);
            }

            bookProductsTable.Write(Format.MarkDown);
            Console.WriteLine("Execution time: " + optimisedTime);
        }

        /// <summary>
        /// Demonstrates the custom QueryBuilder fluent API with filtering,
        /// sorting, joining, and query execution.
        /// </summary>
        public void ExecuteTask5()
        {
            Console.WriteLine("Performing Task5");
            Console.WriteLine("Category : Electronics, SortBy : Price");
            var result = new QueryBuilder<Product>(this._productService.GetProducts())
                .Filter(product => product.Category == "Electronics")
                .SortBy(product => product.Price)
                .Join(this._supplierService.GetSuppliers(), p => p.ProductId, s => s.ProductId, (p, s) => new { SupplierName = s.SupplierName, ProductName = p.ProductName })
                .Execute();
            foreach (var item in result)
            {
                Console.WriteLine(item.SupplierName);
                Console.WriteLine(item.ProductName);
            }
        }
    }
}
