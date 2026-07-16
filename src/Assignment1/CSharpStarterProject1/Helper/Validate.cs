using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactManager.Helper
{
    /// <summary>
 /// Provides methods for validating contact information such as phone numbers and email addresses.
 /// </summary>
    internal class Validate
    {
        /// <summary>
        /// Validates a phone number to ensure it contains exactly ten numeric digits.
        /// </summary>
        /// <param name="phoneNumber">
        /// The phone number to validate.
        /// </param>
        /// <returns>
        /// <c>true</c> if the phone number is valid; otherwise, <c>false</c>.
        /// </returns>
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

        /// <summary>
        /// Validates an email address to ensure it is in the expected format.
        /// </summary>
        /// <param name="email">
        /// The email address to validate.
        /// </param>
        /// <returns>
        /// <c>true</c> if the email address is valid; otherwise, <c>false</c>.
        /// </returns>
        public bool IsEmailValid(string email)
        {
            return !string.IsNullOrWhiteSpace(email) && email.Contains('@') && email.EndsWith(".com");
        }
    }
}
