using System.Reflection;
using System.Reflection.Emit;

namespace MockingFramework
{
    public class MockFactory
    {
        public static T CreateMock<T>()
        {
            Type interfaceType = typeof(T);

            AssemblyBuilder assembly =
                AssemblyBuilder.DefineDynamicAssembly(
                    new AssemblyName("MockAssembly"),
                    AssemblyBuilderAccess.Run);

            ModuleBuilder module =
                assembly.DefineDynamicModule("MockModule");

            TypeBuilder typeBuilder =
                module.DefineType(
                    "MockClass",
                    TypeAttributes.Public);

            typeBuilder.AddInterfaceImplementation(interfaceType);

            foreach (MethodInfo method in interfaceType.GetMethods())
            {
                MethodBuilder methodBuilder =
                    typeBuilder.DefineMethod(
                        method.Name,
                        MethodAttributes.Public | MethodAttributes.Virtual,
                        method.ReturnType,
                        Type.EmptyTypes);

                ILGenerator il = methodBuilder.GetILGenerator();

                if (method.ReturnType == typeof(int))
                {
                    il.Emit(OpCodes.Ldc_I4_0);
                }
                else if (method.ReturnType == typeof(string))
                {
                    il.Emit(OpCodes.Ldstr, "Mock Result");
                }

                il.Emit(OpCodes.Ret);

                typeBuilder.DefineMethodOverride(methodBuilder, method);
            }

            Type mockType = typeBuilder.CreateType();

            return (T)Activator.CreateInstance(mockType)!;
        }
    }
}
