namespace ExpenseTracker.Models
{
    /// <summary>
    /// Represents an expense transaction.
    /// Stores the category to which the expense belongs.
    /// </summary>
    public class Expense : Transaction
    {
        /// <summary>
        /// Gets or sets the expense identifier counter.
        /// </summary>
        /// <value>
        /// A counter used for generating expense IDs.
        /// </value>
        private static int _expenseCounter = 1;

        /// <summary>
        /// Initializes a new instance of the <see cref="Expense"/> class.
        /// </summary>
        /// <param name="transactionDate">
        /// The date on which the expense occurred.
        /// </param>
        /// <param name="amount">
        /// The amount of the expense.
        /// </param>
        /// <param name="category">
        /// The category associated with the expense.
        /// </param>
        public Expense(DateTime transactionDate, int amount, string category)
            : base($"E{_expenseCounter++}", transactionDate, amount)
        {
            this.Category = category;
        }

        /// <summary>
        /// Gets or sets the expense category.
        /// </summary>
        /// <value>
        /// The category associated with the expense, such as Food,
        /// Travel, Rent, or Entertainment.
        /// </value>
        public string Category { get; set; }
    }
}