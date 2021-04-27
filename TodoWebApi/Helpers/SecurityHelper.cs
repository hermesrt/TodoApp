using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace TodoWebApi.Helpers
{
    public class SecurityHelper
    {
        //TODO: investigar cuales serian valores correctos apra estas variables.
        private const int N_SALT = 70;
        private const int N_ITERATION = 100;
        public static string GenerateSalt()
        {
            var saltBytes = new byte[N_SALT];

            using (var provider = new RNGCryptoServiceProvider())
            {
                provider.GetNonZeroBytes(saltBytes);
            }

            return Convert.ToBase64String(saltBytes);
        }

        public static string HashPassword(string password, string salt)
        {
            var saltBytes = Convert.FromBase64String(salt);

            using (var rfc2898DeriveBytes = new Rfc2898DeriveBytes(password, saltBytes, N_ITERATION))
            {
                return Convert.ToBase64String(rfc2898DeriveBytes.GetBytes(N_SALT));
            }
        }

        //        string pwd = "123Abc#@";
        //        string salt = SecurityHelper.GenerateSalt(70);
        //        string pwdHashed = SecurityHelper.HashPassword(pwd, salt, 10101, 70);
        //        Console.WriteLine(pwdHashed);
        //Console.WriteLine(salt);
    }
}
