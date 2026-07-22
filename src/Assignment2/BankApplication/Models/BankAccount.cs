namespace BankApplication.Models
{
    /// <summary>
    /// Represents the base class for all bank account types.
    /// Provides common functionality such as account creation,
    /// balance management, and deposits.
    /// </summary>
    internal abstract class BankAccount
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BankAccount"/> class.
        /// </summary>
        /// <param name="accountNumber">
        /// The unique account number associated with the bank account.
        /// </param>
        public BankAccount(string accountNumber)
        {
            this.AccountNumber = accountNumber;
        }

        /// <summary>
        /// Gets or sets the account number.
        /// </summary>
        /// <value>
        /// A string representing the unique account number.
        /// </value>
        protected string AccountNumber { get; set; }

        /// <summary>
        /// Gets or sets the current balance of the account.
        /// </summary>
        /// <value>
        /// A decimal value representing the account balance.
        /// </value>
        protected decimal Balance { get; set; }

        /// <summary>
        /// Deposits the specified amount into the account.
        /// </summary>
        /// <param name="amount">
        /// The amount to be deposited.
        /// </param>
        public void Deposit(decimal amount)
        {
            this.Balance += amount;
        }

        /// <summary>
        /// Withdraws the specified amount from the account.
        /// The withdrawal behavior is defined by derived account types.
        /// </summary>
        /// <param name="amount">
        /// The amount to be withdrawn.
        /// </param>
        /// <returns>
        /// A message indicating the result of the withdrawal operation.
        /// </returns>
        public abstract string Withdraw(decimal amount);

        /// <summary>
        /// Checks balance of the account
        /// </summary>
        /// /// <returns>
        /// Balance of the account
        /// </returns>
        public decimal CheckBalance()
        {
            return this.Balance;
        }
    }
}