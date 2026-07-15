using ContactManager.Models;
using ContactManager.Services;
using System.Xml.Linq;

namespace Assignments

{
    internal class Program
    {  
        static void Main(string[] args)
        {
            string input = "";
            string opt = "";
            string phoneNumber, email, name;
            List<Contact> contacts = new List<Contact>();
            List<string> details = new List<string>();
            List<string> phoneNumberList = new();
            List<string> emailList = new();
            ContactService contactservice = new ContactService();

            do
            {
                Console.WriteLine("Enter 1 to view contacts");
                Console.WriteLine("Enter 2 to add contacts");
                Console.WriteLine("Enter 3 to edit contacts");
                Console.WriteLine("Enter 4 to delete contacts");
                Console.WriteLine("Enter 5 to search contacts");
                Console.WriteLine("Enter X/x to Exit");
                input = Console.ReadLine();
                switch (input)
                {
                    case ("1"):
                        
                        contactservice.View(contacts);
                        break;

                    case ("2"):
                        Console.WriteLine("Enter Details");
                        Console.WriteLine("Enter Name");                        
                        do
                        {
                            name = Console.ReadLine();
                            if (name.Length == 0)
                            {
                                Console.WriteLine("Name should not be empty");
                            }
                        } while (name.Length == 0);
                        Console.WriteLine("enter no. of phone numbers");
                        string count=Console.ReadLine();
                        int phoneCount = int.Parse(count);
                         while(phoneCount-->0)
                        {                             
                            bool phoneNumberValid;
                            do
                            {
                                phoneNumberValid = true;
                                Console.WriteLine("Enter Phone Number");
                                phoneNumber = Console.ReadLine();
                                if (phoneNumber.Length != 10)
                                    Console.WriteLine("Phone number length should be 10");
                                
                                else
                                {
                                    foreach (char num in phoneNumber)
                                    {
                                        if (!char.IsDigit(num))
                                        {
                                            phoneNumberValid = false;
                                            Console.WriteLine("Phone number should contain only numbers");
                                            break;
                                        }
                                    }
                                }
                            }
                            while (phoneNumber.Length != 10 || !phoneNumberValid);
                            phoneNumberList.Add(phoneNumber);
                        }
                        Console.WriteLine("enter no. of email");
                        count = Console.ReadLine();
                        int emailCount = int.Parse(count);
                        while (emailCount-- > 0)
                        {
                            Console.WriteLine("Enter Email");
                            do
                            {
                                email = Console.ReadLine();
                                if (!email.Contains('@') || !email.EndsWith(".com"))
                                {
                                    Console.WriteLine("Email should contain @ and end with .com");
                                }
                            } while (!email.Contains('@') || !email.EndsWith(".com"));
                            emailList.Add(email);

                        }
                        Console.WriteLine("Enter notes (Optional)");
                        string notes = Console.ReadLine();
                        Contact contact =new Contact(name,phoneNumberList,emailList,notes);
                        contactservice.Add(contacts,contact);
                        break;

                    case ("3"):
                        if (contacts.Count == 0) Console.WriteLine("No contacts to edit . Please add new contacts\n");
                        else
                        {
                            contactservice.View(contacts);
                            Console.WriteLine("Enter your ID to choose the contact");
                            string findId = Console.ReadLine();
                            contactservice.Edit(contacts,findId);
                        }
                        break;

                    case ("4"):
                        if (contacts.Count == 0) Console.WriteLine("No contacts to delete . Please add new contacts\n");
                        else
                        {
                            Console.WriteLine("Enter the ID to delete the contact");
                            string findId = Console.ReadLine();
                            contactservice.Delete(contacts,findId);
                        }
                        break;

                    case "5":
                        if (contacts.Count == 0) Console.WriteLine("No contacts to search . Please add new contacts\n");
                        else
                        {
                            Console.WriteLine("Enter ID to search the contact");
                            string findId = Console.ReadLine();
                            contactservice.Search(contacts,findId);
                        }
                        break;

                    case ("X" or "x"):
                        Console.WriteLine("Exitting ....");
                        break;

                    default:
                        Console.WriteLine("Invalid Choice\n");
                        break;
                }
            }
            while (input != "x" && input != "X");
        }
    }
}