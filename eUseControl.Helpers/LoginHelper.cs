using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Security.Cryptography;
using System.Text;

namespace eUseControl.Helpers
{
    public class LoginHelper
    {
        public static string HashGen(string password)
        {
            using (var sha256 = SHA256.Create())
            {
                var hashedbytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                var hash = BitConverter.ToString(hashedbytes).Replace("-", "").ToLower();

                return hash;
            }
        }
    }
}