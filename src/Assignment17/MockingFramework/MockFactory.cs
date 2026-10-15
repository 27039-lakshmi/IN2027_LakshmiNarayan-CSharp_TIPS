using System.Reflection;
using System.Reflection.Emit;

namespace MockingFramework
{
    /// <summary>
    /// Provides functionality for creating mock implementations
    /// of interfaces at runtime using Reflection.Emit.
    /// </summary>
    public class MockFactory
    {
        /// <summary>
        /// Creates a mock object for the specified interface type.
        /// The generated mock implements all interface methods and
        /// returns predefined values for supported return types.
        /// </summary>
        /// <typeparam name="T">
        /// The interface type for which a mock implementation is created.
        /// </typeparam>
        /// <returns>
        /// An instance of a dynamically generated class that implements
        /// the specified interface.
        /// </returns>
        /// <exception cref="InvalidOperationException">
        /// Thrown when the mock type cannot be created.
        /// </exception>
        public static T CreateMock<T>()
        {
            var interfaceType = typeof(T);

            var assembly = AssemblyBuilder.DefineDynamicAssembly(
                    new AssemblyName("MockAssembly"),
                    AssemblyBuilderAccess.Run);

            var module = assembly.DefineDynamicModule("MockModule");

            var typeBuilder = module.DefineType(
                    "MockClass",
                    TypeAttributes.Public);

            typeBuilder.AddInterfaceImplementation(interfaceType);

            foreach (var method in interfaceType.GetMethods())
            {
                var methodBuilder = typeBuilder.DefineMethod(
                        method.Name,
                        MethodAttributes.Public | MethodAttributes.Virtual,
                        method.ReturnType,
                        Type.EmptyTypes);

                var il = methodBuilder.GetILGenerator();
                if (method.ReturnType == typeof(string))
                {
                    il.Emit(OpCodes.Ldstr, "Mock Result");
                }

                il.Emit(OpCodes.Ret);

                typeBuilder.DefineMethodOverride(methodBuilder, method);
            }

            Type? mockType = typeBuilder.CreateType();

            if (mockType != null)
            {
                return (T)Activator.CreateInstance(mockType) !;
            }

            throw new InvalidOperationException("Failed to create mock type.");
        }
    }
}
