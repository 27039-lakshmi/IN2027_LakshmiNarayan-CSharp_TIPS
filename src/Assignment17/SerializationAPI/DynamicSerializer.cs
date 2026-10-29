namespace SerializationAPI
{
    using System.Reflection;
    using System.Reflection.Emit;
    using System.Text;

    /// <summary>
    /// Provides functionality to dynamically generate object serializers
    /// using Reflection.Emit and DynamicMethod.
    /// </summary>
    public class DynamicSerializer
    {
        /// <summary>
        /// Creates a serializer delegate for the specified type.
        /// The generated delegate accepts an object instance and returns
        /// its serialized string representation.
        /// </summary>
        /// <param name="type">
        /// The type for which the serializer should be generated.
        /// </param>
        /// <returns>
        /// A delegate that serializes an object into a string.
        /// </returns>
        public static Func<object, string> CreateSerializer(Type type)
        {
            var method = new DynamicMethod(
                            "Serialize",
                            typeof(string),
                            new[] { typeof(object) });
            var il = method.GetILGenerator();

            il.Emit(OpCodes.Ldarg_0);
            il.Emit(OpCodes.Castclass, type);
            il.Emit(
                    OpCodes.Call,
                    typeof(DynamicSerializer).GetMethod(nameof(BuildString)) !);

            il.Emit(OpCodes.Ret);
            return (Func<object, string>)method.CreateDelegate(typeof(Func<object, string>));
        }

        /// <summary>
        /// Builds a simple string representation of an object's public properties.
        /// Each property is represented in the format:
        /// PropertyName=PropertyValue;
        /// </summary>
        /// <param name="obj">
        /// The object to serialize.
        /// </param>
        /// <returns>
        /// A string containing the serialized property values enclosed in braces.
        /// Example:
        /// {Name=John;Age=25;}
        /// </returns>
        public static string BuildString(object obj)
        {
            var sb = new StringBuilder();
            sb.Append("{");

            foreach (var property in obj.GetType().GetProperties())
            {
                sb.Append($"{property.Name}=");
                sb.Append(property.GetValue(obj));
                sb.Append(";");
            }

            sb.Append("}");
            return sb.ToString();
        }
    }
}
