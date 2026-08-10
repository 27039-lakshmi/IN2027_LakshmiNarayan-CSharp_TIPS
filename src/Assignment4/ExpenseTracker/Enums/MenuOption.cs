namespace ExpenseTracker.Enums
{
    /// <summary>
    /// Represents the available options in the main application menu.
    /// </summary>
    public enum MenuOption
    {
        /// <summary>
        /// Opens the menu for adding income or expense transactions.
        /// </summary>
        Add = 1,

        /// <summary>
        /// Opens the menu for editing existing transactions.
        /// </summary>
        Edit = 2,

        /// <summary>
        /// Opens the menu for deleting existing transactions.
        /// </summary>
        Delete = 3,

        /// <summary>
        /// Opens the menu for viewing income or expense transactions.
        /// </summary>
        View = 4,

        /// <summary>
        /// Displays a summary of income, expenses, and current balance.
        /// </summary>
        Summary = 5,

        /// <summary>
        /// Exits the application.
        /// </summary>
        Exit = 6,
    }
}