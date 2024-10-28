using OWSShared.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace OWSShared.Implementations
{
    public class DefaultPublicAPIInputValidation : IPublicAPIInputValidation
    {
        public string ValidateCharacterName(string charName)
        {
            //Test for empty Character Names or Character Names that are shorter than the minimum Character name Length
            if (String.IsNullOrEmpty(charName) || charName.Length < 3)
            {
                return "Please enter a valid Character Name that is at least 3 characters in length.";
            }

            //Test for Character Names that use characters other than Letters (uppercase and lowercase) and Numbers.
            Regex regex = new Regex(@"^\w+$");
            if (!regex.IsMatch(charName))
            {
                return "Please enter a Character Name that only contains letters and numbers.";
            }

            return "";
        }

        public string ValidateEmail(string email)
        {
            //throw new NotImplementedException();
            //Test for empty email address
            if (String.IsNullOrEmpty(email))
            {
                return "Please enter a valid email address.";
            }
            return "";
        }

        public string ValidateUsername(string username)
        {
            //throw new NotImplementedException();
            //Test for empty Usernames or Usernames that are shorter than the minimum Character name Length
            if (String.IsNullOrEmpty(username) || username.Length < 3)
            {
                return "Please enter a valid Username that is at least 3 characters in length.";
            }

            //Test for Usernames that use characters other than Letters (uppercase and lowercase) and Numbers.
            Regex regex = new Regex(@"^\w+$");
            if (!regex.IsMatch(username))
            {
                return "Please enter a Username that only contains letters and numbers.";
            }

            return "";
        }

        public string ValidateFirstName(string lastName)
        {
            throw new NotImplementedException();
        }

        public string ValidateLastName(string lastName)
        {
            throw new NotImplementedException();
        }

        public string ValidatePassword(string password)
        {
            //throw new NotImplementedException();
            //Test for empty passwords or passwords that are shorter than the minimum Character name Length
            if (String.IsNullOrEmpty(password) || password.Length < 8)
            {
                return "Please enter a password that is at least 8 characters in length.";
            }

            return "";
        }
    }
}
