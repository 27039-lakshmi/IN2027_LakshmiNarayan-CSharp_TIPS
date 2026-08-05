using ExpenseTracker.Models;
namespace ExpenseTracker.Repository
{
    public class Transactions
    {
        private List<Income> incomes = new List<Income>();
        private List<Expense> expenses = new List<Expense>();

        private int balance { get; set; }

        public void AddIncome(Income income)
        {
            incomes.Add(income);
        }

        public void AddExpense(Expense expense)
        {
            expenses.Add(expense);
        }

        public int GetBalance() { return balance; }

        public void UpdateBalance(int newBalance)
        {
            balance = newBalance;
        }

        public void UpdateIncome(Income oldIncome, Income newIncome)
        {
            oldIncome.Amount = newIncome.Amount;
            oldIncome.TransactionDate= newIncome.TransactionDate;
            oldIncome.Source = newIncome.Source;
        }

        public void UpdateExpense(Expense oldExpense, Expense newExpense)
        {
            oldExpense.Amount = newExpense.Amount;
            oldExpense.TransactionDate = newExpense.TransactionDate;
            oldExpense.Category = newExpense.Category;
        }

        public List<Transaction> GetIncomeRecords()
        {
            return incomes.ToList<Transaction>();
        }

        public List<Transaction> GetExpenseRecords()
        {
            return expenses.ToList<Transaction>();
        }

        public void DeleteIncome(Income income)
        {
            incomes.Remove(income);
        }

        public void DeleteExpense(Expense expense)
        {
            expenses.Remove(expense);
        }
    }
}
