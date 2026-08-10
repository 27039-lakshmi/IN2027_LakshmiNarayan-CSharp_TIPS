namespace ExpenseTracker.Models
{
    /// <summary>
    /// Represents an income transaction.
    /// Stores the source from which the income was received.
    /// </summary>
    public class Income : Transaction
    {
        private static int _incomeCounter = 1;

        /// <summary>
        /// Initializes a new instance of the <see cref="Income"/> class.
        /// </summary>
        /// <param name="transactionDate">
        /// The date on which the income was received.
        /// </param>
        /// <param name="amount">
        /// The amount of income received.
        /// </param>
        /// <param name="source">
        /// The source of the income.
        /// </param>
        public Income(DateOnly transactionDate, int amount, string source)
            : base($"I{_incomeCounter++}", transactionDate, amount)
        {
            this.Source = source;
        }

        /// <summary>
        /// Gets or sets the source of the income.
        /// </summary>
        /// <value>
        /// The name of the income source, such as Salary, Freelancing, or Business.
        /// </value>
        public string Source { get; set; }
    }
}