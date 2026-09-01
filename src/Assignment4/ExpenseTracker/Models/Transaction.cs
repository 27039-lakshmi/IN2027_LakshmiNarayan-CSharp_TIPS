namespace ExpenseTracker.Models
{
    /// <summary>
    /// Represents a financial transaction in the expense tracker.
    /// Serves as the base class for income and expense transactions.
    /// </summary>
    public class Transaction
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Transaction"/> class.
        /// </summary>
        /// /// <param name="id">
        /// The Id of the transaction
        /// </param>
        /// <param name="transactionDate">
        /// The date on which the transaction occurred.
        /// </param>
        /// <param name="amount">
        /// The monetary value of the transaction.
        /// </param>
        public Transaction(string id, DateOnly transactionDate, int amount)
        {
            this.Id = id;
            this.TransactionDate = transactionDate;
            this.Amount = amount;
        }

        /// <summary>
        /// Gets the unique identifier of the transaction.
        /// This value can only be assigned during object initialization.
        /// </summary>
        /// <value>
        /// A unique identifier for the transaction.
        /// </value>
        public string Id { get; init; }

        /// <summary>
        /// Gets or sets the date of the transaction.
        /// </summary>
        /// <value>
        /// The date on which the transaction occurred.
        /// </value>
        public DateOnly TransactionDate { get; set; }

        /// <summary>
        /// Gets or sets the transaction amount.
        /// </summary>
        /// <value>
        /// The monetary amount associated with the transaction.
        /// </value>
        public int Amount { get; set; }
    }
}