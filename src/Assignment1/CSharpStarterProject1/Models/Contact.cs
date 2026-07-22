namespace ContactManager.Models
{
    /// <summary>
    /// Represents a contact with personal details, phone numbers, email addresses, and notes.
    /// </summary>
    internal class Contact
    {
        /// <summary>
        /// Gets or sets the unique identifier of the contact.
        /// </summary>
        /// <value>
        /// A unique identifier used to distinguish the contact from other contacts.
        /// </value>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the name of the contact.
        /// </summary>
        /// <value>
        /// The name of the contact.
        /// </value>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the phone numbers associated with the contact.
        /// </summary>
        /// <value>
        /// A collection of phone numbers belonging to the contact.
        /// </value>
        public List<string> PhoneNumbers { get; set; } = new ();

        /// <summary>
        /// Gets or sets the email addresses associated with the contact.
        /// </summary>
        /// <value>
        /// A collection of email addresses belonging to the contact.
        /// </value>
        public List<string> Emails { get; set; } = new ();

        /// <summary>
        /// Gets or sets additional notes about the contact.
        /// </summary>
        /// <value>
        /// Additional information or remarks related to the contact.
        /// </value>
        public string? Notes { get; set; }
    }
}