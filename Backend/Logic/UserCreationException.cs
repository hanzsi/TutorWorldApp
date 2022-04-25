using ModelLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class UserCreationException : Exception
    {
        public UserProfile User { get; set; }

        public UserCreationException(string message, UserProfile user): base(message)
        {
            this.User = user;
        }
    }
}
