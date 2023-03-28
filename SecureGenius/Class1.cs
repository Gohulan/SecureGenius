using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace SecureGenius
{
    public class Class1
    {
        public static string Generate(int length)
        {
            const string validChars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890!@#$%^&*()_+";
            var random = new RNGCryptoServiceProvider();

            var password = new StringBuilder();
            for (var i = 0; i < length; i++)
            {
                var bytes = new byte[4];
                random.GetBytes(bytes);
                var randomNumber = BitConverter.ToInt32(bytes, 0);
                var randomChar = validChars[randomNumber % validChars.Length];
                password.Append(randomChar);
            }

            return password.ToString();
        }
    }
}