using ContactManager.Models;
using ContactManager.Repository;
using ContactManager.Helper;
namespace ContactManager.Services
{
    internal class ContactService
    {
        ContactRepo repo = new ContactRepo();
        public List<Contact> GetAllContacts()
        {
            return repo.GetAll();
        }

        public void AddContact(Contact contact)
        {
            repo.Add(contact);
        }

        public void EditContact(Contact contact)
        {
            repo.Update(contact);
        }

        public void DeleteContact(Guid id)
        {
            repo.Delete(id);
        }
        public Contact SearchContact(Guid id)
        {
            return repo.Search(id);
        }

        public int ContactCount()
        {
            return repo.ContactCount();
        }

        public string PhoneNumberValidity(Contact contact,string phone)
        {
            Validate helper=new Validate();
            if (helper.IsPhoneNumberValid(phone))
            {
                contact.PhoneNumbers.Add(phone);
                return "";
            }
            else
            {
                
                return "Enter a valid phone number";
            }
        }

        public string EmailValidity(Contact contact, string email)
        {
            Validate helper = new Validate();
            if (helper.IsEmailValid(email))
            {
                contact.Emails.Add(email);
                return "";
            }
            else
            {

                return "Enter a valid email";
            }
        }
    }
}
