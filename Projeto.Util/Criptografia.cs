using System;
using System.Security.Cryptography;
using System.Text;

namespace Projeto.Util
{
    public class Criptografia
    {
        public static string GetMd5(string value)
        {
            byte[] valueBytes = Encoding.UTF8.GetBytes(value);

            var md5 = new MD5CryptoServiceProvider();
            var hash = md5.ComputeHash(valueBytes);

            string result = string.Empty;
            foreach(var pos in hash)
            {
                result += pos.ToString("X2");
            }
            return result;
        }

        public static string GetSha1(string value)
        {
            byte[] valueBytes = Encoding.UTF8.GetBytes(value);

            var sha1 = new SHA1CryptoServiceProvider();
            var hash = sha1.ComputeHash(valueBytes);

            string result = string.Empty;
            foreach (var pos in hash)
            {
                result += pos.ToString("X2");
            }
            return result;
        }
    }
}
