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
            List<List<string>> contacts = new List<List<string>>();
            List<string> details = new List<string>();
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
                        if (contacts.Count == 0) Console.WriteLine("No contacts to display . Please add new contacts\n");
                        else
                        {
                            int count = 1;
                            Console.WriteLine("All contacts are displayed below\n");
                            foreach (List<string> contact in contacts)
                            {
                                Console.WriteLine("Contact " + count + ": ");
                                foreach (string detail in contact)
                                { Console.WriteLine(detail); }
                                count++;
                            }
                        }
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


                        bool phoneNumberValid;
                        do
                        {
                            phoneNumberValid = true;
                            Console.WriteLine("Enter Phone Number");
                            phoneNumber = Console.ReadLine();
                            if (phoneNumber.Length != 10)
                            {
                                Console.WriteLine("Phone number length should be 10");
                            }
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
                        Console.WriteLine("Enter Email Address");
                        do
                        {
                            email = Console.ReadLine();
                            if (!email.Contains('@') || !email.EndsWith(".com"))
                            {
                                Console.WriteLine("Email should contain @ and end with .com");
                            }
                        } while (!email.Contains('@') || !email.EndsWith(".com"));

                        Console.WriteLine("Enter notes (Optional)");
                        string notes = Console.ReadLine();
                        contacts.Add(new List<string>() { name, phoneNumber, email, notes });
                        Console.WriteLine("Contacts Added Successfully\n");

                        break;
                    case ("3"):
                        if (contacts.Count == 0) Console.WriteLine("No contacts to edit . Please add new contacts\n");
                        else
                        {
                            Console.WriteLine("Enter any detail to choose the contact");
                            string findEdit = Console.ReadLine();
                            bool found = false;
                            foreach (List<string> contact in contacts)
                            {
                                if (contact.Contains(findEdit))
                                {
                                    Console.WriteLine("Your Details : ");
                                    do
                                    {
                                        foreach (string detail in contact)
                                        {
                                            Console.WriteLine(detail);
                                        }
                                        Console.WriteLine("Enter the details to edit");
                                        string edit = Console.ReadLine();
                                        int index = contact.IndexOf(edit);
                                        Console.WriteLine("Enter the correct detail");
                                        string value = Console.ReadLine();
                                        contact[index] = value;
                                        Console.WriteLine("Enter Y/y to continue editting");
                                        opt = Console.ReadLine();
                                        found = true;
                                    }
                                    while (opt == "Y" || opt == "y");
                                }
                            }
                            if (!found)
                            {
                                Console.WriteLine("Contact not found\n");
                            }
                        }
                        break;
                    case ("4"):
                        if (contacts.Count == 0) Console.WriteLine("No contacts to delete . Please add new contacts\n");

                        else
                        {
                            Console.WriteLine("Enter the phone number to delete the contact");
                            string findDelete = Console.ReadLine();
                            int indexToDelete = 0;
                            foreach (List<string> contact in contacts)
                            {
                                if (contact.Contains(findDelete))
                                {
                                    break;
                                }
                                indexToDelete++;
                            }
                            contacts.RemoveAt(indexToDelete);
                            Console.WriteLine("Contact Deleted Successfully\n");
                        }
                        break;
                    case "5":
                        if (contacts.Count == 0) Console.WriteLine("No contacts to search . Please add new contacts\n");
                        else
                        {
                            Console.WriteLine("Enter any detail to search the contact");
                            string findSearch = Console.ReadLine();
                            bool found = false;
                            foreach (List<string> contact in contacts)
                            {
                                if (contact.Contains(findSearch))
                                {
                                    Console.WriteLine("Your Details : ");
                                    foreach (string detail in contact)
                                    {
                                        Console.WriteLine(detail);
                                    }
                                }
                            }
                            if (!found)
                            {
                                Console.WriteLine("Contact not found\n");
                            }
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