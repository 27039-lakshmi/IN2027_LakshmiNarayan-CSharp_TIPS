namespace ExpenseTracker.Models
{
    public class Income : Transaction
    {
        public Income(DateOnly transactionDate, int amount, string source)
            : base(transactionDate, amount)
        {
            this.Id = $"I{this.incomeCounter++}";
            this.Source = source;
        }

        public int incomeCounter = 1;
        public string Source { get; set; }
    }
}
