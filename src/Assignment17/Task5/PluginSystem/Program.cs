using System.Reflection;
using PluginInterface;

namespace Assignments
{
    /// <summary>
    /// Entry point of the application that loads and executes plugins from a specified folder.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Entry point of the application. It loads and executes plugins from the specified folder.
        /// </summary>
        /// <param name="args">
        /// String array containing command-line arguments. Not used in this application.
        /// </param>
        public static void Main(string[] args)
        {
            try
            {
                string pluginsFolder =
                    @"C:\CSharpAssignments\Repos\IN2027_LakshmiNarayan-CSharp_TIPS\src\Assignment17\Task5\Plugins";
                int pluginsCount = Directory.GetDirectories(pluginsFolder).Length;
                string[] pluginFiles = Directory.GetFiles(pluginsFolder, "*.dll");

                for (int i = 1; i <= pluginsCount; i++)
                {
                    string pluginFilepath = "C:/CSharpAssignments/Repos/IN2027_LakshmiNarayan-CSharp_TIPS/src/Assignment17/Task5/Plugins/";
                    string pluginFile = Path.Combine(
                        pluginFilepath, $"Plugin{i}", "bin", "Debug", "net6.0", $"Plugin{i}.dll");

                    Assembly assembly =
                    Assembly.LoadFile(pluginFile);

                    Console.WriteLine($"Loaded Assembly: {assembly.FullName}");

                    Type[] types = assembly.GetTypes();

                    foreach (Type type in types)
                    {
                        if (type.GetInterface(nameof(IPlugin)) != null)
                        {
                            Console.WriteLine($"Plugin Found: {type.Name}");

                            IPlugin? plugin = (IPlugin?)Activator.CreateInstance(type);
                            if (plugin == null)
                            {
                                Console.WriteLine($"Failed to create an instance of {type.Name}");
                                continue;
                            }

                            Console.WriteLine($"Plugin Name: {plugin.Name}");
                            plugin.Execute();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}