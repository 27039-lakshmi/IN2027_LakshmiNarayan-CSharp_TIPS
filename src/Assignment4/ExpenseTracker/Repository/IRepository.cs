using ExpenseTracker.Models;

namespace ExpenseTracker.Repository
{
    /// <summary>
    /// Defines methods for managing income and expense transactions.
    /// Provides operations to add, update, delete, and retrieve
    /// income and expense records.
    /// </summary>
    public interface IRepository
    {
        /// <summary>
        /// Adds a new income transaction.
        /// </summary>
        /// <param name="income">
        /// The income transaction to be added.
        /// </param>
        void AddIncome(Income income);

        /// <summary>
        /// Updates an existing income transaction with new values.
        /// </summary>
        /// <param name="oldIncome">
        /// The existing income transaction to update.
        /// </param>
        /// <param name="newIncome">
        /// The new income values that will replace the existing values.
        /// </param>
        void UpdateIncome(Income oldIncome, Income newIncome);

        /// <summary>
        /// Deletes an income transaction.
        /// </summary>
        /// <param name="income">
        /// The income transaction to remove.
        /// </param>
        void DeleteIncome(Income income);

        /// <summary>
        /// Retrieves all income transactions.
        /// </summary>
        /// <returns>
        /// A list containing all income records.
        /// </returns>
        List<Transaction> GetIncomeRecords();

        /// <summary>
        /// Adds a new expense transaction.
        /// </summary>
        /// <param name="expense">
        /// The expense transaction to be added.
        /// </param>
        void AddExpense(Expense expense);

        /// <summary>
        /// Updates an existing expense transaction with new values.
        /// </summary>
        /// <param name="oldExpense">
        /// The existing expense transaction to update.
        /// </param>
        /// <param name="newExpense">
        /// The new expense values that will replace the existing values.
        /// </param>
        void UpdateExpense(Expense oldExpense, Expense newExpense);

        /// <summary>
        /// Deletes an expense transaction.
        /// </summary>
        /// <param name="expense">
        /// The expense transaction to remove.
        /// </param>
        void DeleteExpense(Expense expense);

        /// <summary>
        /// Retrieves all expense transactions.
        /// </summary>
        /// <returns>
        /// A list containing all expense records.
        /// </returns>
        List<Transaction> GetExpenseRecords();
    }
}