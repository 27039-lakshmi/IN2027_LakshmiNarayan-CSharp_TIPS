using ExpenseTracker.Enums;
using ExpenseTracker.Models;
using ExpenseTracker.Repository;

namespace ExpenseTracker.Service
{
    /// <summary>
    /// Provides business logic for managing income and expense transactions.
    /// Handles adding, updating, deleting, retrieving transactions,
    /// and maintaining the current balance.
    /// </summary>
    public class TransactionService
    {
        private readonly Transactions _transactions;
        private readonly TransactionEventManager _eventManager;

        /// <summary>
        /// Initializes a new instance of the <see cref="TransactionService"/> class
        /// and subscribes to transaction change events.
        /// </summary>
        /// <param name="transactions">
        /// Repository used to store and retrieve transactions.
        /// </param>
        /// <param name="eventManager">
        /// Manages transaction-related events.
        /// </param>
        public TransactionService(Transactions transactions, TransactionEventManager eventManager)
        {
            this._transactions = transactions;
            this._eventManager = eventManager;
            this._eventManager.TransactionChanged += this.RecalculateSummary;
        }

        /// <summary>
        /// Adds an income or expense transaction to the repository.
        /// </summary>
        /// <param name="transaction">
        /// The transaction to be added.
        /// </param>
        public void AddTransaction(Transaction transaction)
        {
            if (this.TryCast<Income>(transaction, out var income) && income != null)
            {
                this._transactions.AddIncome(income);
            }
            else if (this.TryCast<Expense>(transaction, out var expense) && expense != null)
            {
                this._transactions.AddExpense(expense);
            }

            this._eventManager.RaiseTransactionChanged();
        }

        /// <summary>
        /// Attempts to cast a transaction to the specified transaction type.
        /// </summary>
        /// <typeparam name="T">
        /// The target transaction type.
        /// </typeparam>
        /// <param name="transaction">
        /// The transaction to cast.
        /// </param>
        /// <param name="result">
        /// When this method returns, contains the converted transaction if the cast
        /// succeeded; otherwise, null.
        /// </param>
        /// <returns>
        /// True if the cast succeeds; otherwise, false.
        /// </returns>
        public bool TryCast<T>(Transaction transaction, out T? result)
            where T : Transaction
        {
            result = transaction as T;
            return result != null;
        }

        /// <summary>
        /// Recalculates the current balance based on total income
        /// and total expenses.
        /// </summary>
        public void RecalculateSummary()
        {
            TransactionSummary.TotalIncome = this.GetTotal(TransactionType.Income);
            TransactionSummary.TotalExpense = this.GetTotal(TransactionType.Expense);
            TransactionSummary.Balance = TransactionSummary.TotalIncome - TransactionSummary.TotalExpense;
        }

        /// <summary>
        /// Retrieves all transactions of the specified type.
        /// </summary>
        /// <param name="recordType">
        /// The type of transactions to retrieve.
        /// </param>
        /// <returns>
        /// A list of transactions matching the specified type.
        /// </returns>
        public List<Transaction> GetRecords(TransactionType recordType)
        {
            if (recordType == TransactionType.Income)
            {
                var incomeRecords = this._transactions.GetIncomeRecords();
                return incomeRecords;
            }
            else
            {
                var expenseRecords = this._transactions.GetExpenseRecords();
                return expenseRecords;
            }
        }

        /// <summary>
        /// Updates an existing transaction with new values.
        /// </summary>
        /// <param name="existingTransaction">
        /// The transaction to be updated.
        /// </param>
        /// <param name="transaction">
        /// The transaction containing updated values.
        /// </param>
        public void UpdateTransaction(Transaction existingTransaction, Transaction transaction)
        {
            if (this.TryCast<Income>(transaction, out var income) && income != null)
            {
                    this._transactions.UpdateIncome((Income)existingTransaction, income);
            }
            else if (this.TryCast<Expense>(transaction, out var expense) && expense != null)
            {
                    this._transactions.UpdateExpense((Expense)existingTransaction, expense);
            }

            this._eventManager.RaiseTransactionChanged();
        }

        /// <summary>
        /// Deletes a transaction by its identifier.
        /// </summary>
        /// <param name="id">
        /// The identifier of the transaction to delete.
        /// </param>
        /// <param name="recordType">
        /// The type of transaction to delete.
        /// </param>
        /// <returns>
        /// True if the transaction was found and deleted;
        /// otherwise, false.
        /// </returns>
        public bool DeleteTransaction(string id, TransactionType recordType)
        {
            if (recordType == TransactionType.Income)
            {
                var incomeList = this._transactions.GetIncomeRecords();
                var matchedIncome = this.SearchTransaction(incomeList, id);
                if (matchedIncome == null)
                {
                    return false;
                }

                this._transactions.DeleteIncome((Income)matchedIncome);
            }
            else
            {
                var expenseList = this._transactions.GetExpenseRecords();
                var matchedExpense = this.SearchTransaction(expenseList, id);
                if (matchedExpense == null)
                {
                    return false;
                }

                this._transactions.DeleteExpense((Expense)matchedExpense);
            }

            this._eventManager.RaiseTransactionChanged();

            return true;
        }

        /// <summary>
        /// Searches for a transaction by its identifier.
        /// </summary>
        /// <param name="transactions">
        /// The collection of transactions to search.
        /// </param>
        /// <param name="id">
        /// The identifier of the transaction.
        /// </param>
        /// <returns>
        /// The matching transaction if found; otherwise, null.
        /// </returns>
        public Transaction? SearchTransaction(List<Transaction> transactions, string id)
        {
            return transactions.Find(transaction => string.Equals(transaction.Id, id));
        }

        /// <summary>
        /// Calculates the total amount for the specified transaction type.
        /// </summary>
        /// <param name="type">
        /// The transaction type.
        /// </param>
        /// <returns>
        /// The sum of all transaction amounts for the specified type.
        /// </returns>
        public int GetTotal(TransactionType type)
        {
            return this.GetRecords(type).Sum(t => t.Amount);
        }

        /// <summary>
        /// Retrieves an existing income transaction by its identifier.
        /// </summary>
        /// <param name="id">
        /// The income transaction identifier.
        /// </param>
        /// <returns>
        /// The matching income transaction if found; otherwise, null.
        /// </returns>
        public Income? GetExistingIncome(string id)
        {
            return this.SearchTransaction(this.GetRecords(TransactionType.Income), id) as Income;
        }

        /// <summary>
        /// Retrieves an existing expense transaction by its identifier.
        /// </summary>
        /// <param name="id">
        /// The expense transaction identifier.
        /// </param>
        /// <returns>
        /// The matching expense transaction if found; otherwise, null.
        /// </returns>
        public Expense? GetExistingExpense(string id)
        {
            return this.SearchTransaction(this.GetRecords(TransactionType.Expense), id) as Expense;
        }

        /// <summary>
        /// Determines whether any income records exist.
        /// </summary>
        /// <returns>
        /// True if no income records exist; otherwise, false.
        /// </returns>
        public bool IsIncomeEmpty()
        {
            return !this._transactions.GetIncomeRecords().Any();
        }

        /// <summary>
        /// Determines whether any expense records exist.
        /// </summary>
        /// <returns>
        /// True if no expense records exist; otherwise, false.
        /// </returns>
        public bool IsExpenseEmpty()
        {
            return !this._transactions.GetExpenseRecords().Any();
        }

        /// <summary>
        /// Gets the current balance.
        /// </summary>
        /// <returns>
        /// The current balance amount.
        /// </returns>
        public int GetBalance()
        {
            return TransactionSummary.Balance;
        }

        /// <summary>
        /// Gets the transaction summary
        /// </summary>
        /// <returns> The transaction summary </returns>
        public (int, int, int) GetSummary()
        {
            return (TransactionSummary.TotalIncome, TransactionSummary.TotalExpense, TransactionSummary.Balance);
        }
    }
}
