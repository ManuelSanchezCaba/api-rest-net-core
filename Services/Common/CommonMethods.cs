using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Common
{
    public static class CommonMethods
    {
        public static string key = "wbjwqbohqwov";

        public static string EncryptPassword(string password)
        {
            if (string.IsNullOrEmpty(password)) return "";

            password += key;
            var passwordBytes = Encoding.UTF8.GetBytes(password);
            return Convert.ToBase64String(passwordBytes);
        }

        public static string DecryptPassword(string password)
        {
            if (string.IsNullOrEmpty(password)) return "";

            var base64EncodeBytes = Convert.FromBase64String(password);
            var result = Encoding.UTF8.GetString(base64EncodeBytes);
            result = result.Substring(0, result.Length - key.Length);
            return result;
        }
    }
}
