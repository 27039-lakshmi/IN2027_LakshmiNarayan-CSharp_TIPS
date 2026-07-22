using System;

namespace BankApplication.Models
{
    /// <summary>
    /// Represents a checking account.
    /// Provides withdrawal functionality specific to checking accounts.
    /// </summary>
    internal class CheckingAccount : BankAccount
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CheckingAccount"/> class.
        /// </summary>
        /// <param name="accountNumber">
        /// The unique account number associated with the checking account.
        /// </param>
        public CheckingAccount(string accountNumber)
            : base(accountNumber)
        {
        }

        /// <summary>
        /// Withdraws the specified amount from the account if sufficient funds exist.
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
            if (this.Balance - amount >= 0)
            {
                this.Balance -= amount;
                return string.Empty;
            }
            else
            {
                return "Withdraw failed. Insufficient Balance";
            }
        }
    }
}