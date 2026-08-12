using ExpenseTracker.Models;

namespace ExpenseTracker.Repository
{
    /// <summary>
    /// Store the transaction data including income list, expense list and balance
    /// </summary>
    public class TransactionData
    {
        /// <summary>
        /// Gets or sets the income list
        /// </summary>
        /// <value>
        /// List of incomes made
        /// </value>
        public List<Income> Incomes { get; set; } = new ();

        /// <summary>
        /// Gets or sets the expense list
        /// </summary>
        /// <value>
        /// List of expenses made
        /// </value>
        public List<Expense> Expenses { get; set; } = new ();

        /// <summary>
        /// Gets or sets the balance
        /// </summary>
        /// <value>
        /// Current balance of the person
        /// </value>
        public int Balance { get; set; }
    }
}
