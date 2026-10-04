namespace ExpenseTracker.Service
{
    /// <summary>
    /// Manages transaction-related events and notifies subscribers
    /// when transactions are added, updated, or deleted.
    /// </summary>
    public class TransactionEventManager
    {
        /// <summary>
        /// Occurs when a transaction is modified.
        /// </summary>
        /// <remarks>
        /// Subscribers can use this event to perform actions such as
        /// recalculating balances or refreshing displayed data.
        /// </remarks>
        public event Action? TransactionChanged;

        /// <summary>
        /// Raises the <see cref="TransactionChanged"/> event.
        /// </summary>
        public void RaiseTransactionChanged()
        {
            this.TransactionChanged?.Invoke();
        }
    }
}