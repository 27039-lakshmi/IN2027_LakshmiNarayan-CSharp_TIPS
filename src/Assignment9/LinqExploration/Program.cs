using LinqExploration.Application.Service;
using LinqExploration.Infrastructure.Repository;
using LinqExploration.Presentation.Controller;

namespace Assignments;

/// <summary>
/// Application entry point.
/// Initializes and starts the LINQ demonstration application.
/// </summary>
public static class Program
{
    /// <summary>
    /// Main method that launches the application and executes
    /// all LINQ demonstration tasks through the controller.
    /// </summary>
    public static void Main()
    {
        var database = new SampleDatabaseContext();
        var productService = new ProductService(database);
        var supplierService = new SupplierService(database);
        var arrayService = new ArrayService();
        var controller = new LinqController(productService, supplierService, arrayService);
        controller.Start();
    }
}
