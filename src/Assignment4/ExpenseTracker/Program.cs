using ExpenseTracker.Repository;
using ExpenseTracker.Service;
using ExpenseTracker.View;
namespace Assignments
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var transactions = new Transactions();
                var transactionService = new TransactionService(transactions);
                var userViewer = new UserViewer(transactionService);
                userViewer.Start();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
    }
}