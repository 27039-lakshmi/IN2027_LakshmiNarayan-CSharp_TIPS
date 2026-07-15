using ContactManager.Models;
using ContactManager.Services;
using ContactManager.View;
using System.Xml.Linq;

namespace Assignments

{
    internal class Program
    {  
        static void Main(string[] args)
        {
            
            ContactService contactservice = new ContactService();
            View view= new View();
            view.Start();

        }
    }
}