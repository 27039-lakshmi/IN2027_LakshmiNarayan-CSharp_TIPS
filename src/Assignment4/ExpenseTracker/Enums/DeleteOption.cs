namespace ExpenseTracker.Enums
{
    /// <summary>
    /// Represents the available options for deleting a transaction.
    /// </summary>
    public enum DeleteOption
    {
        /// <summary>
        /// Deletes an income transaction.
        /// </summary>
        DeleteIncome = 1,

        /// <summary>
        /// Deletes an expense transaction.
        /// </summary>
        DeleteExpense = 2,
    }
}