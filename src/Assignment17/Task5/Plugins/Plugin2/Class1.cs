using PluginInterface;
namespace Plugin2
{
    public class HiPlugin : IPlugin
    {
        public string Name => "Greeting Plugin2";

        public void Execute()
        {
            Console.WriteLine("Hi from the plugin!");
        }
    }
}