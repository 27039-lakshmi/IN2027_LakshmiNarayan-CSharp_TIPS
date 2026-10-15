namespace ExpenseTracker.Enums
{
    /// <summary>
    /// Specifies the available date selection options for expense-related operations.
    /// </summary>
    public enum DateOptions
    {
        /// <summary>
        /// Allows the user to manually select or enter a specific date.
        /// </summary>
        ManualDate = 1,

        /// <summary>
        /// Automatically uses the current system date.
        /// </summary>
        TodayDate = 2,
    }
}