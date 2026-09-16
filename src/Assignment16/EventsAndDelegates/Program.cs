using EventsAndDelegates;

namespace Assignments
{
    /// <summary>
    /// Entry point for the notification application.
    /// Demonstrates how to subscribe to and raise an event using delegates.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Application entry point.
        /// Creates a notifier, subscribes to the event,
        /// collects user input, and raises the notification event.
        /// </summary>
        /// <param name="args">Command-line arguments.</param>
        public static void Main(string[] args)
        {
            var notifier = new Notifier();
            notifier.OnAction += SendMessage;
            string userInput = GetStringInput();
            notifier.RaiseEvent(userInput);
        }

        /// <summary>
        /// Prompts the user to enter a notification message.
        /// </summary>
        /// <returns>
        /// The message entered by the user.
        /// Returns an empty string if no input is provided.
        /// </returns>
        private static string GetStringInput()
        {
            Console.WriteLine("Enter notification message");
            return Console.ReadLine() ?? string.Empty;
        }

        /// <summary>
        /// Event handler that displays the notification message.
        /// </summary>
        /// <param name="message">
        /// The notification message received from the event.
        /// </param>
        private static void SendMessage(string message)
        {
            Console.WriteLine("Notification : " + message);
        }
    }
}