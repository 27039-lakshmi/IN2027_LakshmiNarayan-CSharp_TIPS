using System.Text.Json;
using ExpenseTracker.Enums;
using ExpenseTracker.Models;
using ExpenseTracker.Service;

namespace ExpenseTracker.Repository
{
    /// <summary>
    /// Stores and manages income and expense records.
    /// Provides methods for adding, updating, deleting,
    /// and retrieving transaction data.
    /// </summary>
    public class Transactions
    {
        private string _filepath = string.Empty;
        private TransactionData _data = new ();
        private TransactionEventManager _eventManager = new ();

<<<<<<< HEAD
        /// <summary>
        /// Sets the filepath
        /// </summary>
        /// <param name="filepath">The filepath received from service layer</param>
        public void SetFilePath(string filepath)
        {
            this._filepath = filepath;
            this._data = this.LoadDataFromFile();
        }

        /// <summary>
        /// Loads data from File
        /// </summary>
        /// <returns>
        /// an object of type <see cref="TransactionData"/> with data from file
        /// </returns>
        public TransactionData LoadDataFromFile()
        {
            if (!File.Exists(this._filepath))
            {
                return new TransactionData();
            }

            string json = File.ReadAllText(this._filepath);
            return JsonSerializer.Deserialize<TransactionData>(json) ?? new TransactionData();
        }

        /// <summary>
        /// Writes data into the file
        /// </summary>
        public void WriteDataIntoFile()
        {
           string json = JsonSerializer.Serialize(this._data, new JsonSerializerOptions
           {
               WriteIndented = true,
           });
           File.WriteAllText(this._filepath, json);
        }

=======
>>>>>>> feature-user-27039-Lakshmi-Assignments-Assignment4-ExpenseTracker
        /// <summary>
        /// Adds an income record.
        /// </summary>
        /// <param name="income">The income to add.</param>
        public void AddIncome(Income income)
        {
            this._data.Incomes.Add(income);
            this.WriteDataIntoFile();
        }

        /// <summary>
        /// Adds an expense record.
        /// </summary>
        /// <param name="expense">The expense to add.</param>
        public void AddExpense(Expense expense)
        {
            this._data.Expenses.Add(expense);
            this.WriteDataIntoFile();
        }

        /// <summary>
<<<<<<< HEAD
        /// Gets the current balance.
        /// </summary>
        /// <returns>The current balance.</returns>
        public int GetBalance()
        {
            return this._data.Balance;
        }

        /// <summary>
        /// Updates the current balance.
        /// </summary>
        /// <param name="newBalance">The recalculated balance.</param>
        public void UpdateBalance(int newBalance)
        {
            this._data.Balance = newBalance;
            this.WriteDataIntoFile();
        }

        /// <summary>
=======
>>>>>>> feature-user-27039-Lakshmi-Assignments-Assignment4-ExpenseTracker
        /// Updates an existing income record with new values.
        /// </summary>
        /// <param name="oldIncome">The income to update.</param>
        /// <param name="newIncome">The updated income values.</param>
        public void UpdateIncome(Income oldIncome, Income newIncome)
        {
            oldIncome.Amount = newIncome.Amount;
            oldIncome.TransactionDate = newIncome.TransactionDate;
            oldIncome.Source = newIncome.Source;
            this.WriteDataIntoFile();
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
            this.WriteDataIntoFile();
        }

        /// <summary>
        /// Retrieves all income records.
        /// </summary>
        /// <returns>A list of income transactions.</returns>
        public List<Transaction> GetIncomeRecords()
        {
            return this._data.Incomes.ToList<Transaction>();
        }

        /// <summary>
        /// Retrieves all expense records.
        /// </summary>
        /// <returns>A list of expense transactions.</returns>
        public List<Transaction> GetExpenseRecords()
        {
            return this._data.Expenses.ToList<Transaction>();
        }

        /// <summary>
        /// Removes an income record.
        /// </summary>
        /// <param name="income">The income to remove.</param>
        public void DeleteIncome(Income income)
        {
            this._data.Incomes.Remove(income);
            this.WriteDataIntoFile();
        }

        /// <summary>
        /// Removes an expense record.
        /// </summary>
        /// <param name="expense">The expense to remove.</param>
        public void DeleteExpense(Expense expense)
        {
            this._data.Expenses.Remove(expense);
            this.WriteDataIntoFile();
        }
    }
}