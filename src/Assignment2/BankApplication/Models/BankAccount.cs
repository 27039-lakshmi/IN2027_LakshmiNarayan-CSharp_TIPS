using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApplication.Models
{
    internal abstract class BankAccount
    {
        public BankAccount(string accountNumber)
        {
            AccountNumber= accountNumber;
        }
        protected string AccountNumber { get; set; }
        protected decimal Balance { get; set; }

        public void Deposit(decimal amount)
        {
            Balance += amount;
        }

        public abstract string Withdraw(decimal amount);

    }
}
