using ExpenseTracker.Models;

namespace ExpenseTracker.Repository
{
    /// <summary>
    /// Stores and manages income and expense records.
    /// Provides methods for adding, updating, deleting,
    /// and retrieving transaction data.
    /// </summary>
    public class Transactions
    {
        private List<Income> _incomes = new List<Income>();
        private List<Expense> _expenses = new List<Expense>();

        /// <summary>
        /// Adds an income record.
        /// </summary>
        /// <param name="income">The income to add.</param>
        public void AddIncome(Income income)
        {
            this._incomes.Add(income);
        }

        /// <summary>
        /// Adds an expense record.
        /// </summary>
        /// <param name="expense">The expense to add.</param>
        public void AddExpense(Expense expense)
        {
            this._expenses.Add(expense);
        }

        /// <summary>
        /// Updates an existing income record with new values.
        /// </summary>
        /// <param name="oldIncome">The income to update.</param>
        /// <param name="newIncome">The updated income values.</param>
        public void UpdateIncome(Income oldIncome, Income newIncome)
        {
            oldIncome.Amount = newIncome.Amount;
            oldIncome.TransactionDate = newIncome.TransactionDate;
            oldIncome.Source = newIncome.Source;
        }

        /// <summary>
        /// Updates an existing expense record with new values.
        /// </summary>
        /// <param name="oldExpense">The expense to update.</param>
        /// <param name="newExpense">The updated expense values.</param>
        public void UpdateExpense(Expense oldExpense, Expense newExpense)
        {
            oldExpense.Amount = newExpense.Amount;
            oldExpense.TransactionDate = newExpense.TransactionDate;
            oldExpense.Category = newExpense.Category;
        }

        /// <summary>
        /// Retrieves all income records.
        /// </summary>
        /// <returns>A list of income transactions.</returns>
        public List<Transaction> GetIncomeRecords()
        {
            return this._incomes.ToList<Transaction>();
        }

        /// <summary>
        /// Retrieves all expense records.
        /// </summary>
        /// <returns>A list of expense transactions.</returns>
        public List<Transaction> GetExpenseRecords()
        {
            return this._expenses.ToList<Transaction>();
        }

        /// <summary>
        /// Removes an income record.
        /// </summary>
        /// <param name="income">The income to remove.</param>
        public void DeleteIncome(Income income)
        {
            this._incomes.Remove(income);
        }

        /// <summary>
        /// Removes an expense record.
        /// </summary>
        /// <param name="expense">The expense to remove.</param>
        public void DeleteExpense(Expense expense)
        {
            this._expenses.Remove(expense);
        }
    }
}