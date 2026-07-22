namespace BankApplication.Models
{
    /// <summary>
    /// Represents a savings account.
    /// Provides withdrawal functionality while enforcing
    /// a minimum balance requirement.
    /// </summary>
    internal class SavingsAccount : BankAccount
    {
        private readonly decimal _minimumBankBalance = 1000;

        /// <summary>
        /// Initializes a new instance of the <see cref="SavingsAccount"/> class.
        /// </summary>
        /// <param name="accountNumber">
        /// The unique account number associated with the savings account.
        /// </param>
        public SavingsAccount(string accountNumber)
            : base(accountNumber)
        {
        }

        /// <summary>
        /// Withdraws the specified amount from the account if the
        /// remaining balance does not fall below the minimum balance.
        /// </summary>
        /// <param name="amount">
        /// The amount to be withdrawn from the account.
        /// </param>
        /// <returns>
        /// A message indicating the result of the withdrawal operation.
        /// Returns an empty string if the withdrawal is successful.
        /// </returns>
        public override string Withdraw(decimal amount)
        {
            if (this.Balance - amount < 0)
            {
                return "Balance is not enough for this withdrawal\n";
            }
            else if (this.Balance < this._minimumBankBalance)
            {
                return "Already balance is less than minimum balance";
            }
            else if (this.Balance - amount >= this._minimumBankBalance)
            {
                this.Balance -= amount;
                return string.Empty;
            }
            else
            {
                return "Withdraw failed. Balance should not go below minimum balance\n";
            }
        }
    }
}