using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace Helper.CookieCrypto
{
    public static class Crypto
    {
        public static string GenerateSalt()
        {
            var SaltBytes=new byte[10];
            var Provide = new RNGCryptoServiceProvider();
            Provide.GetNonZeroBytes(SaltBytes);

            return Convert.ToBase64String(SaltBytes);
        }

        public static string GenerateSHA256Hash(string input,string salt)
        {
            HMACSHA256 hmc = new HMACSHA256(Encoding.UTF8.GetBytes(salt));
            var Hash =hmc.ComputeHash(Encoding.UTF8.GetBytes(input+salt));

            return Encoding.UTF8.GetString(Hash);
        }
    }
}
