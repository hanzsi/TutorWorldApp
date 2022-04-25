using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace Logic
{
    class LogHashCheck
    {
        public string LogEncrypt(string password3)
        {
            string hashOrigi;
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] passwordOrigiBytes = Encoding.UTF8.GetBytes(password3);
                byte[] hashOrigiBytes = sha256Hash.ComputeHash(passwordOrigiBytes);
                hashOrigi = BitConverter.ToString(hashOrigiBytes).Replace("-", String.Empty);
            }
            return hashOrigi;
        }
    }
}
