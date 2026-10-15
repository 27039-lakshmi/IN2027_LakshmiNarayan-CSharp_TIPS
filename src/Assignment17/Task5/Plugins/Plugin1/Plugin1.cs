using PluginInterface;

namespace Plugin1
{
    /// <summary>
    /// A plugin that displays a greeting message when executed.
    /// Implements the <see cref="IPlugin"/> interface.
    /// </summary>
    public class Plugin1 : IPlugin
    {
        /// <summary>
        /// Gets the name of the plugin.
        /// </summary>
        /// <value> Name of the plugin</value>
        public string Name => "Greeting Plugin1";

        /// <summary>
        /// Executes the plugin's functionality by displaying
        /// a greeting message to the console.
        /// </summary>
        public void Execute()
        {
            Console.WriteLine("Hello from the plugin!");
        }
    }
}