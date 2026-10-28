namespace SerializationAPI
{
    using System.Reflection;
    using System.Reflection.Emit;
    using System.Text;

    public class DynamicSerializer
    {
        public static Func<object, string> CreateSerializer(Type type)
        {
            DynamicMethod method =
                new DynamicMethod(
                    "Serialize",
                    typeof(string),
                    new[] { typeof(object) });

            ILGenerator il = method.GetILGenerator();

            il.Emit(OpCodes.Ldarg_0);
            il.Emit(OpCodes.Castclass, type);

            il.Emit(OpCodes.Call,
                typeof(DynamicSerializer)
                .GetMethod(nameof(BuildString)));

            il.Emit(OpCodes.Ret);

            return (Func<object, string>)
                method.CreateDelegate(typeof(Func<object, string>));
        }

        public static string BuildString(object obj)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("{");

            foreach (PropertyInfo property in obj.GetType().GetProperties())
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
