namespace SerializationAPI
{
    /// <summary>
    /// Represents a person with a name and address.
    /// Demonstrates serialization of a nested object.
    /// </summary>
    public class Person
    {
        /// <summary>
        /// Gets or sets the person's name.
        /// </summary>
        /// <value> Name of the person</value>
        public string? Name { get; set; }

        /// <summary>
        /// Gets or sets the person's address.
        /// </summary>
        /// <value>Address of the person</value>
        public Address? Address { get; set; }
    }
}