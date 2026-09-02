using ExpenseTracker.Repository;
using ExpenseTracker.Service;
using ExpenseTracker.View;

namespace Assignments
{
    /// <summary>
    /// Application entry point.
    /// Creates the repository, event manager, service layer,
    /// and view components before launching the Expense Tracker.
    /// </summary>
    /// <param name="args">
    /// An array of command-line arguments.
    /// </param>
    public class Program
    {
        private static void Main(string[] args)
        {
            try
            {
                var inMemoryRepo = new InMemoryRepo();
                var fileRepo = new FileRepo();
                var eventManager = new TransactionEventManager();
                var transactionService = new TransactionService(fileRepo, eventManager);
                var userViewer = new ExpenseTrackerView(transactionService);
                userViewer.Start();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}