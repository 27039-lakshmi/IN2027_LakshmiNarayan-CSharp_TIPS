using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactManager.Helper
{
    internal class Validate
    {
        public bool IsPhoneNumberValid(string phoneNumber)
        {

            if (string.IsNullOrWhiteSpace(phoneNumber) || phoneNumber.Length != 10)
            {
                return false;
            }
            else
            {
                foreach (char c in phoneNumber)
                {
                    if (!char.IsDigit(c))
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public bool IsEmailValid(string email)
        {

            if (string.IsNullOrWhiteSpace(email) || !email.Contains('@') || !email.EndsWith(".com"))
            {
                return false;
            }
            
            return true;
        }
    }
}
