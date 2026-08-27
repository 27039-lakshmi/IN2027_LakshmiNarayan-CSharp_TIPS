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
        /// <summary>
        /// Seeds sample product and supplier data and executes all LINQ tasks.
        /// </summary>
        public void Start()
        {
            var productService = new ProductService();
            productService.AddProducts(new List<Product>
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

            var supplierService = new SupplierService();
            supplierService.AddSuppliers(new List<Supplier>()
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
            this.ExecuteTask1();
            this.ExecuteTask2();
            this.ExecuteTask3();
            this.ExecuteTask4();
            this.ExecuteTask5();
        }

        /// <summary>
        /// Demonstrates filtering, sorting, and aggregation operations on products.
        /// </summary>
        public void ExecuteTask1()
        {
            var productService = new ProductService();
            var products = productService.GetProducts();
            var productsTable = new ConsoleTable("Product ID", "Product Name", "Category", "Price");
            Console.WriteLine("Performing task1");
            Console.WriteLine("Products List");
            foreach (var product in products)
            {
                productsTable.AddRow(product.ProductId, product.ProductName, product.Category, product.Price);
            }

            productsTable.Write(Format.MarkDown);
            productsTable.Rows.Clear();
            var filteredProducts = productService.GetFilteredProducts();
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
            var productService = new ProductService();
            var products = productService.GetProducts();
            var supplierService = new SupplierService();
            var productsTable = new ConsoleTable("Product ID", "Product Name", "Category", "Price");
            Console.WriteLine("Performing Task2");
            Console.WriteLine("Products List");
            foreach (var product in products)
            {
                productsTable.AddRow(product.ProductId, product.ProductName, product.Category, product.Price);
            }

            productsTable.Write(Format.MarkDown);
            productsTable.Rows.Clear();

            var productCategoryWiseSummary = productService.GetProductCategorySummary();
            var categorySummaryTable = new ConsoleTable("Category", "Number of products", "Expensive Product");
            Console.WriteLine("Category-wise summary for products");
            foreach (var category in productCategoryWiseSummary)
            {
                categorySummaryTable.AddRow(category.Category, category.Count, category.ExpensiveProduct);
            }

            categorySummaryTable.Write(Format.MarkDown);
            var suppliers = supplierService.GetSuppliers();
            var supplierTable = new ConsoleTable("Supplier Id", "Supplier Name", "Product ID");
            Console.WriteLine("Supplier List");
            foreach (var supplier in suppliers)
            {
                supplierTable.AddRow(supplier.SupplierId, supplier.SupplierName, supplier.ProductId);
            }

            supplierTable.Write(Format.MarkDown);
            var supplierProductMappingTable = new ConsoleTable("Supplier Id", "Supplier Name", "Product Id", "Product Name");
            var supplierProductMapping = supplierService.GetProductWithSuppliers();
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
            Console.WriteLine("Arra");
            foreach (int num in arr)
            {
                Console.Write(num + " ");
            }

            var arrayService = new ArrayService();
            int secondHighest = arrayService.GetSecondHighestElement(arr);
            Console.WriteLine("Second highest element " + secondHighest);
            int target = 100;
            var listOfPairs = arrayService.GetPairs(arr, target);
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
            var productService = new ProductService();
            Console.WriteLine("Performing Task4");
            Console.WriteLine("Unoptimised Query");
            var stopWatch = new Stopwatch();
            stopWatch.Start();
            var productsUnderBooks = productService.FilterWithoutOptimisation();
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
            productsUnderBooks = productService.FilterWithOptimisation();
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
            var productService = new ProductService();
            var supplierService = new SupplierService();
            Console.WriteLine("Performing Task5");
            var result = new QueryBuilder<Product>(productService.GetProducts())
                .Filter(product => product.Category == "Electronics")
                .SortBy(product => product.Price)
                .Join(supplierService.GetSuppliers(), p => p.ProductId, s => s.ProductId, (p, s) => new { SupplierName = s.SupplierName, ProductName = p.ProductName })
                .Execute();
            foreach (var item in result)
            {
                Console.WriteLine(item.SupplierName);
                Console.WriteLine(item.ProductName);
            }
        }
    }
}
