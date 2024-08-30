using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PWManagerUI
{
    internal class PasswordGenerator
    {
        public string PasswordGen()
        {
            const int length = 12; //Used to set the length of the Generated Password

            //Following Variables are used to generate the Password
            const string uppercaseChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            const string lowercaseChars = "abcdefghijklmnopqrstuvwxyz";
            const string digitChars = "0123456789";
            const string specialChars = "!@#$%^&*()_+";
            const string allChars = uppercaseChars + lowercaseChars + digitChars + specialChars;

            StringBuilder password = new StringBuilder();
            Random random = new Random();

            // Following code ensures at least one of each character type is in the generated password
            password.Append(uppercaseChars[random.Next(uppercaseChars.Length)]);
            password.Append(lowercaseChars[random.Next(lowercaseChars.Length)]);
            password.Append(digitChars[random.Next(digitChars.Length)]);
            password.Append(specialChars[random.Next(specialChars.Length)]);

            // Fills the remaining characters with random characters
            for (int i = 4; i < length; i++)
            {
                password.Append(allChars[random.Next(allChars.Length)]);

            }

            // Shuffles the password to randomize the character order (So we don't have the 4 character types at the start)
            string shuffledPassword = ShufflePassword(password.ToString());
            return shuffledPassword;
        }
        public string ShufflePassword(string password)
        {
            char[] passwordArray = password.ToCharArray();
            Random random = new Random();
            int n = passwordArray.Length;
            while (n > 1)
            {
                n--;
                int k = random.Next(n + 1);
                char temp = passwordArray[k];
                passwordArray[k] = passwordArray[n];
                passwordArray[n] = temp;
            }
            return new string(passwordArray);
        }
    }
}
