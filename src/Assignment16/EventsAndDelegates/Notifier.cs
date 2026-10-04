namespace EventsAndDelegates
{
    /// <summary>
    /// Publishes notifications to subscribed event handlers.
    /// </summary>
    public class Notifier
    {
        /// <summary>
        /// Represents a method that handles a notification message.
        /// </summary>
        /// <param name="message">The notification message.</param>
        public delegate void Notify(string message);

        /// <summary>
        /// Occurs when a notification is raised.
        /// Subscribers receive the notification message through this event.
        /// </summary>
        public event Notify? OnAction;

        /// <summary>
        /// Raises the <see cref="OnAction"/> event and passes the specified
        /// message to all subscribed event handlers.
        /// </summary>
        /// <param name="message">The message to send to subscribers.</param>
        public void RaiseEvent(string message)
        {
            this.OnAction?.Invoke(message);
        }
    }
}