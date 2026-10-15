using System;
using PluginContracts;

namespace Plugins
{
    public class Plugin1 : IPlugin
    {
        public string Name => "Greeting Plugin";

        public void Execute()
        {
            Console.WriteLine("Hello from the plugin!");
        }
    }
}