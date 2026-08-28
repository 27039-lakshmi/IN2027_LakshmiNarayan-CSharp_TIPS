using BankApplication.Models;

namespace BankApplication.Services
{
    /// <summary>
    /// Provides services for creating bank accounts
    /// and validating account-related input.
    /// </summary>
    public static class BankServices
    {
        /// <summary>
        /// Creates a bank account using the specified account number.
        /// </summary>
        /// <param name="accountNumber">
        /// The account number used to create the savings account.
        /// </param>
        /// <param name="type">
        /// The bank account type (Savings or Checking).
        /// </param>
        /// <returns>
        /// A <see cref="SavingsAccount"/> object if the account number is valid;
        /// otherwise, <c>null</c>.
        /// </returns>
        public static BankAccount? CreateAccount(string accountNumber, AccountType type)
        {
            if (!ValidateAccountNumber(accountNumber))
            {
                return null;
            }
            else
            {
                if (type == AccountType.Savings)
                {
                    return new SavingsAccount(accountNumber);
                }
                else
                {
                    return new CheckingAccount(accountNumber);
                }
            }
        }

        /// <summary>
        /// Validates the account number.
        /// An account number must contain at least ten digits
        /// and consist only of numeric characters.
        /// </summary>
        /// <param name="accountNumber">
        /// The account number to validate.
        /// </param>
        /// <returns>
        /// <c>true</c> if the account number is valid; otherwise, <c>false</c>.
        /// </returns>
        public static bool ValidateAccountNumber(string accountNumber)
        {
            if (accountNumber.Length < 10)
            {
                return false;
            }

            foreach (char c in accountNumber)
            {
                if (!char.IsDigit(c))
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Checks the balance of bank account
        /// </summary>
        /// <param name="bankAccount">
        /// The account to check balance.
        /// </param>
        /// <returns>
        /// balance of the bank account
        /// </returns>
        public static decimal FindAccountBalance(BankAccount bankAccount)
        {
            return bankAccount.CheckBalance();
        }
    }
}