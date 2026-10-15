using PluginInterface;

namespace Plugin2
{
    /// <summary>
    /// A plugin that displays a greeting message when executed.
    /// Implements the <see cref="IPlugin"/> interface.
    /// </summary>
    public class Plugin2 : IPlugin
    {
        /// <summary>
        /// Gets the name of the plugin.
        /// </summary>
        /// <value> Name of the plugin</value>
        public string Name => "Greeting Plugin2";

        /// <summary>
        /// Executes the plugin's functionality by displaying
        /// a greeting message to the console.
        /// </summary>
        public void Execute()
        {
            Console.WriteLine($"{this.Name} Hi from the plugin!");
        }
    }
}