using ContactManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactManager.Services
{
    internal class ContactService
    {
        public void Add(List<Contact> contacts, Contact contact)
        {
            contacts.Add(contact);
        }

        private string _opt = "";
        private bool _found = false;
        private string _choice = "";
        /// <summary>
        /// Joins a first name and a last name together into a single string.
        /// </summary>
        /// <param name="contacts">The first name to join.</param>
        /// <param name="id">The last name to join.</param>
        public void Edit(List<Contact> contacts, string id)
        {
            Guid guidId = Guid.Parse(id);
            foreach (Contact contact in contacts)
            {
                if (contact.Id == guidId)
                {
                    Console.WriteLine("Your Details : \n");
                    do
                    {
                        Console.WriteLine(contact.Id);
                        Console.WriteLine(contact.Name);
                        for (int i = 0; i < contact.PhoneNumber.Count; i++)
                        {
                            Console.WriteLine("Phone Number " + (i + 1) + ":" + contact.PhoneNumber[i]);
                        }
                        for (int i = 0; i < contact.Email.Count; i++)
                        {
                            Console.WriteLine("Email " + (i + 1) + ":" + contact.Email[i]);
                        }

                        Console.WriteLine(contact.Notes);

                        Console.WriteLine("Enter N to change name");
                        Console.WriteLine("Enter P to change phone number");
                        Console.WriteLine("Enter E to change email");
                        _choice = Console.ReadLine();

                        switch (_choice)
                        {
                            case "N":
                                Console.WriteLine("Enter correct Name");
                                contact.Name = Console.ReadLine();
                                break;
                            case "P":
                                Console.WriteLine("Enter which number you want to change");

                                string input = Console.ReadLine();
                                Console.WriteLine("Enter correct number");
                                string correctInput = Console.ReadLine();
                                int index = 0;
                                foreach (string phno in contact.PhoneNumber)
                                {
                                    index++;
                                    if (phno == input)
                                    {
                                        break;
                                    }
                                }
                                contact.PhoneNumber[index] = correctInput;
                                break;
                            case "E":
                                Console.WriteLine("Enter which email you want to change");
                                input = Console.ReadLine();
                                Console.WriteLine("Enter correct email");
                                correctInput = Console.ReadLine();
                                index = 0;
                                foreach (string emailid in contact.Email)
                                {
                                    index++;
                                    if (emailid == input)
                                    {
                                        break;
                                    }
                                }
                                contact.Email[index] = correctInput;
                                break;

                            default:
                                break;
                        }
                        Console.WriteLine("Enter Y/y to continue editting");
                        _opt = Console.ReadLine();
                        _found = true;
                    }
                    while (_opt == "Y" || _opt == "y");
                }
            }
            if (!_found)
            {
                Console.WriteLine("Contact not found\n");
            }
        }

        public void View(List<Contact> contacts)
        {
            if (contacts.Count == 0) Console.WriteLine("No contacts to display . Please add new contacts\n");
            else
            {
                int count = 1;
                Console.WriteLine("Contact Details: \n");
                foreach (Contact contact in contacts)
                {
                    Console.WriteLine("Contact " + count + ":\n");
                    Console.WriteLine(contact.Id);
                    Console.WriteLine(contact.Name);
                    for (int i = 0; i < contact.PhoneNumber.Count; i++)
                    {
                        Console.WriteLine("Phone Number " + (i + 1) + ":" + contact.PhoneNumber[i]);
                    }
                    for (int i = 0; i < contact.Email.Count; i++)
                    {
                        Console.WriteLine("Email " + (i + 1) + ":" + contact.Email[i]);
                    }
                    Console.WriteLine(contact.Notes);
                }
            }
        }

        public void Search(List<Contact> contacts, string id)
        {
            Guid guidId = Guid.Parse(id);
            bool found = false;
            foreach (Contact contact in contacts)
            {
                if (contact.Id == guidId)
                {
                    Console.WriteLine("Your Details : ");
                    Console.WriteLine(contact.Id);
                    Console.WriteLine(contact.Name);
                    Console.WriteLine(contact.PhoneNumber);
                    Console.WriteLine(contact.Email);
                    Console.WriteLine(contact.Notes);
                    found = true;
                }
            }
            if (!found)
            {
                Console.WriteLine("Contact not found\n");
            }
        }

        public void Delete(List<Contact> contacts, string id)
        {
            Guid guidId = Guid.Parse(id);
            int index = 0;
            foreach (Contact contact in contacts)
            {
                if (contact.Id == guidId)
                {
                    break;
                }
                index++;
            }
            contacts.RemoveAt(index);
        }

    }
}
