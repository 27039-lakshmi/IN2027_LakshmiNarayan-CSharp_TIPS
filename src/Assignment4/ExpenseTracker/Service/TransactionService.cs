using ExpenseTracker.Models;
using ExpenseTracker.Repository;
namespace ExpenseTracker.Service
{
    internal class TransactionService
    {
        private readonly Transactions _transactions;

        public TransactionService(Transactions transactions)
        {
            this._transactions = transactions;
        }

        public void AddTransaction(Transaction transaction)
        {
            if (transaction is Income income)
            {
                _transactions.AddIncome(income);
            }
            else if (transaction is Expense expense)
            {
                _transactions.AddExpense(expense);
            }
            this.UpdateBalance(null, transaction);
        }

        public void UpdateBalance(Transaction? oldTransaction, Transaction? newTransaction)
        {
            int balance = _transactions.GetBalance();

            // Remove old transaction effect
            if (oldTransaction != null)
            {
                if (oldTransaction is Income oldIncome)
                    balance -= oldIncome.Amount;
                else if (oldTransaction is Expense oldExpense)
                    balance += oldExpense.Amount;
            }

            // Apply new transaction effect
            if (newTransaction != null)
            {
                if (newTransaction is Income newIncome)
                    balance += newIncome.Amount;
                else if (newTransaction is Expense newExpense)
                    balance -= newExpense.Amount;
            }

            _transactions.UpdateBalance(balance);
        }

        public List<Transaction> GetRecords(string recordType)
        {
            if(recordType == "Income")
            {
                var incomeRecords = _transactions.GetIncomeRecords();
                return incomeRecords;
            }
            else
            {
                var expenseRecords = _transactions.GetExpenseRecords();
                return expenseRecords;
            }
        }

        public bool UpdateTransaction(string id, Transaction transaction)
        {
            if (transaction is Income income)
            {
                var incomeList = _transactions.GetIncomeRecords();
                var matchedIncome = SearchTransaction(incomeList, id);

                if (matchedIncome != null)
                {
                    this.UpdateBalance(matchedIncome, income);
                    _transactions.UpdateIncome((Income)matchedIncome, income);
                    return true;
                }
            }
            else if (transaction is Expense expense)
            {
                var expenseList = _transactions.GetExpenseRecords();
                var matchedExpense = SearchTransaction(expenseList, id);
                if (matchedExpense != null)
                {
                    this.UpdateBalance(matchedExpense, expense);
                    _transactions.UpdateExpense((Expense)matchedExpense, expense);
                    return true;
                }
            }
            return false;
        }

        public bool DeleteTransaction(string id,string recordType)
        {
            if(recordType == "Income")
            {
                var incomeList = _transactions.GetIncomeRecords();
                var matchedIncome = SearchTransaction(incomeList, id);
                if (matchedIncome == null)
                {
                    return false;
                }
                _transactions.DeleteIncome((Income)matchedIncome);
                this.UpdateBalance(matchedIncome, null);

            }
            else 
            {
                var expenseList = _transactions.GetExpenseRecords();
                var matchedExpense = SearchTransaction(expenseList, id);
                if (matchedExpense == null)
                {
                    return false;
                }
                _transactions.DeleteExpense((Expense)matchedExpense);
                this.UpdateBalance(matchedExpense, null);
            }
            return true;
        }

        public Transaction? SearchTransaction(List<Transaction> transactions,string id)
        {
            return transactions.Find(transaction => transaction.Id == id);
        }

        public int GetTotal(string recordType)
        {
            if(recordType == "Income")
            {
                var incomeList = _transactions.GetIncomeRecords();
                int incomeSum = 0;
                foreach(Transaction transaction in incomeList)
                {
                    incomeSum += transaction.Amount;
                }
                return incomeSum;
            }
            else
            {
                var expenseList = _transactions.GetExpenseRecords();
                int expenseSum = 0;
                foreach (Transaction transaction in expenseList)
                {
                    expenseSum += transaction.Amount;
                }
                return expenseSum;
            }
        }

        public bool isIncomeEmpty()
        {
            return _transactions.GetIncomeRecords().Count == 0;
        }

        public bool isExpenseEmpty()
        {
            return _transactions.GetExpenseRecords().Count == 0;
        }

        public int GetBalance()
        {
            return _transactions.GetBalance();
        }
    }
}
