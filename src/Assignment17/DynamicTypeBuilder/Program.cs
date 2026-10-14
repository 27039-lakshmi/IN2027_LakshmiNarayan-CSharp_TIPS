using System.Reflection;
using System.Reflection.Emit;

namespace Assignments
{
    /// <summary>
    /// Contains the entry point for the application that demonstrates dynamic
    /// type creation and usage with reflection emit APIs.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Entry point for the application.
        /// </summary>
        /// <param name="args">The string array for arguments</param>
        public static void Main(string[] args)
        {
            AssemblyName assemblyName = new AssemblyName("DynamicAssembly");

            AssemblyBuilder assemblyBuilder =
                AssemblyBuilder.DefineDynamicAssembly(
                    assemblyName,
                    AssemblyBuilderAccess.Run);

            ModuleBuilder moduleBuilder =
                assemblyBuilder.DefineDynamicModule("MainModule");

            TypeBuilder typeBuilder =
                moduleBuilder.DefineType(
                    "Person",
                    TypeAttributes.Public);

            FieldBuilder fieldBuilder =
                typeBuilder.DefineField(
                    "_name",
                    typeof(string),
                    FieldAttributes.Private);

            PropertyBuilder propertyBuilder =
                typeBuilder.DefineProperty(
                    "Name",
                    PropertyAttributes.None,
                    typeof(string),
                    null);

            MethodBuilder getMethodBuilder =
                typeBuilder.DefineMethod(
                    "get_Name",
                    MethodAttributes.Public | MethodAttributes.SpecialName | MethodAttributes.HideBySig,
                    typeof(string),
                    Type.EmptyTypes);

            ILGenerator getIL = getMethodBuilder.GetILGenerator();

            getIL.Emit(OpCodes.Ldarg_0);
            getIL.Emit(OpCodes.Ldfld, fieldBuilder);
            getIL.Emit(OpCodes.Ret);

            MethodBuilder setMethodBuilder =
                typeBuilder.DefineMethod(
                    "set_Name",
                    MethodAttributes.Public | MethodAttributes.SpecialName | MethodAttributes.HideBySig,
                    null,
                    new Type[] { typeof(string) });

            ILGenerator setIL = setMethodBuilder.GetILGenerator();

            setIL.Emit(OpCodes.Ldarg_0);
            setIL.Emit(OpCodes.Ldarg_1);
            setIL.Emit(OpCodes.Stfld, fieldBuilder);
            setIL.Emit(OpCodes.Ret);

            propertyBuilder.SetGetMethod(getMethodBuilder);
            propertyBuilder.SetSetMethod(setMethodBuilder);

            MethodBuilder displayMethodBuilder =
                typeBuilder.DefineMethod(
                    "DisplayName",
                    MethodAttributes.Public,
                    typeof(void),
                    Type.EmptyTypes);

            ILGenerator displayIL =
                displayMethodBuilder.GetILGenerator();

            displayIL.Emit(OpCodes.Ldstr, "Person Name: ");
            displayIL.Emit(OpCodes.Ldarg_0);
            displayIL.Emit(OpCodes.Call, getMethodBuilder);
            displayIL.Emit(
                OpCodes.Call,
                typeof(string).GetMethod("Concat", new Type[] { typeof(string), typeof(string) }) !);

            displayIL.Emit(
                OpCodes.Call,
                typeof(Console).GetMethod("WriteLine", new Type[] { typeof(string) }) !);

            displayIL.Emit(OpCodes.Ret);

            Type personType = typeBuilder.CreateType() !;

            object person = Activator.CreateInstance(personType) !;

            personType.GetProperty("Name") !.SetValue(person, "Lakshmi");

            personType.GetMethod("DisplayName") !.Invoke(person, null);
        }
    }
}