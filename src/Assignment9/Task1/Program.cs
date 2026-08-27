using ConsoleTables;
using LinqExploration.Application.Service;
using LinqExploration.Domain.Models;
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
        LinqController controller = new ();
        controller.Start();
    }
}
