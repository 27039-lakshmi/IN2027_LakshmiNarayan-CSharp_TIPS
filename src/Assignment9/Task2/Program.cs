using ConsoleTables;
namespace Assignments;
public class Product
{
    public int ProductId { get; set; }

    public string ProductName { get; set; }

    public decimal Price { get; set; }

    public string Category { get; set; }
}

public class Supplier
{
    public int SupplierId { get; set; }

    public string SupplierName { get; set; }

    public int ProductId { get; set; }
}

public class Order
{
    public int OrderId { get; set; }

    public DateTime OrderDate { get; set; }

    public string OrderStatus { get; set; }
}

public class SampleDatabaseContext
{
    public List<Product> Products { get; set; }

    public List<Supplier> Suppliers { get; set; }

    public List<Order> Orders { get; set; }

    public SampleDatabaseContext()
    {
        this.Products = new List<Product>();
        this.Suppliers = new List<Supplier>();
        this.Orders = new List<Order>();
    }
}

public static class Program
{
    public static void Main()
    {
        var context = new SampleDatabaseContext();
        var products = context.Products;
        // Sample Products
        products.AddRange(new List<Product>
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
        });

        var suppliers = context.Suppliers;
        // Sample Suppliers
        suppliers.AddRange(new List<Supplier>
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
        var productsTable = new ConsoleTable("Product ID", "Product Name", "Category", "Price");
        Console.WriteLine("Performing task2");
        Console.WriteLine("Products List");
        foreach (var product in products)
        {
            productsTable.AddRow(product.ProductId, product.ProductName, product.Category, product.Price);
        }

        productsTable.Write();
        var groupedProducts = context.Products.GroupBy(g => g.Category).Select(product => new { Category = product.Key, Count = product.Count(), ExpensiveProduct = product.Max(product => product.Price)}).ToList();
        var filteredTable = new ConsoleTable("Category", "Number of products", "Most Expense");
        foreach (var product in groupedProducts)
        {
            filteredTable.AddRow(product.Category,product.Count,product.ExpensiveProduct);
        }
        filteredTable.Write();
    }
}