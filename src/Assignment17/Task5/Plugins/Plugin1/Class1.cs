using PluginInterface;
namespace Plugin1
{
    public class HelloPlugin : IPlugin
    {
        public string Name => "Greeting Plugin1";

        public void Execute()
        {
            Console.WriteLine("Hello from the plugin!");
        }
    }
}