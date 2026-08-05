namespace ExpenseTracker.Models
{
    public class Expense : Transaction
    {
        public Expense(DateOnly transactionDate, int amount, string category)
            : base(transactionDate, amount)
        {
            this.Id = $"E{this.ExpenseCounter++}";
            this.Category = category;
        }

        public int ExpenseCounter = 1;
        public string Category { get; set; }
    }
}
