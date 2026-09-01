namespace ExpenseTracker.Models
{
    /// <summary>
    /// Represents the summary of all financial transactions.
    /// </summary>
    public static class TransactionSummary
    {
        /// <summary>
        /// Gets or sets the total income amount.
        /// </summary>
        /// <value>
        /// The sum of all income transactions.
        /// </value>
        public static int TotalIncome { get; set; }

        /// <summary>
        /// Gets or sets the total expense amount.
        /// </summary>
        /// <value>
        /// The sum of all expense transactions.
        /// </value>
        public static int TotalExpense { get; set; }

        /// <summary>
        /// Gets or sets the current account balance.
        /// </summary>
        /// <value>
        /// The difference between total income and total expenses.
        /// </value>
        public static int Balance { get; set; }
    }
}