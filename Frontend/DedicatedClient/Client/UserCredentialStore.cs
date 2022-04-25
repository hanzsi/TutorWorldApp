using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    public class UserCredentialStore
    {
        private static UserCredentialStore instance;
        public static UserCredentialStore Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new UserCredentialStore();
                }
                return instance;
            }
        }

        public string Email;
        public string Password;
    }
}
