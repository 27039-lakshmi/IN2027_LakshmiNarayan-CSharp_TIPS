using System.Reflection;
using System.Text;

namespace SerializationAPI
{
    /// <summary>
    /// Provides functionality to serialize objects into a simple
    /// string representation using reflection.
    /// </summary>
    public static class ReflectionSerializer
    {
        /// <summary>
        /// Serializes the public properties of an object into a string.
        /// Each property is represented as a key-value pair in the format:
        /// {PropertyName=PropertyValue;}
        /// </summary>
        /// <param name="obj">
        /// The object to serialize.
        /// </param>
        /// <returns>
        /// A string containing the serialized representation of the object.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown when the specified object is null.
        /// </exception>
        public static string Serialize(object obj)
        {
            if (obj == null)
            {
                throw new ArgumentNullException(nameof(obj));
            }

            var type = obj.GetType();
            var properties = type.GetProperties();

            var sb = new StringBuilder();

            sb.Append("{");

            foreach (var property in properties)
            {
                object? value = property.GetValue(obj);

                sb.Append($"{property.Name}={value};");
            }

            sb.Append("}");

            return sb.ToString();
        }
    }
}
