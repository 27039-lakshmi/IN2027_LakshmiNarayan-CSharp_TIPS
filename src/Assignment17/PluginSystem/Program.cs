using System.Reflection;
using PluginContracts;

namespace Assignments
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string pluginPath =
                @"D:\Plugins\GreetingPlugin.dll";

            // Load assembly
            Assembly assembly =
                Assembly.LoadFile(pluginPath);

            Console.WriteLine(
                $"Loaded Assembly: {assembly.FullName}");

            // Get all types
            Type[] types = assembly.GetTypes();

            foreach (Type type in types)
            {
                // Check if type implements IPlugin
                if (type.GetInterface(nameof(IPlugin)) != null)
                {
                    Console.WriteLine(
                        $"Plugin Found: {type.Name}");

                    // Create object
                    IPlugin plugin =
                        (IPlugin)Activator.CreateInstance(type);

                    Console.WriteLine(
                        $"Plugin Name: {plugin.Name}");

                    // Execute plugin
                    plugin.Execute();
                }
            }
        }
    }
}