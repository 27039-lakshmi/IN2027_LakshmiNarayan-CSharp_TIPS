namespace ExpenseTracker.Models
{
    public class Transaction
    {
        public Transaction(DateOnly transactionDate, int amount)
        {
            this.TransactionDate = transactionDate;
            this.Amount = amount;
        }

        public string Id { get; init; }

        public DateOnly TransactionDate { get; set; }

        public int Amount { get; set; }
    }
}
