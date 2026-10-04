namespace ExpenseTracker.Enums
{
    /// <summary>
    /// Represents the available options for adding a transaction.
    /// </summary>
    public enum AddOption
    {
        /// <summary>
        /// Adds an income transaction.
        /// </summary>
        AddIncome = 1,

        /// <summary>
        /// Adds an expense transaction.
        /// </summary>
        AddExpense = 2,

        /// <summary>
        /// Represents an invalid menu selection.
        /// </summary>
        InvalidChoice = -1,
    }
}