using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class AuthException : Exception
    {
        public AuthException(string msg) : base(msg)
        {

        }

        public AuthException(string msg, Exception inner): base(msg, inner)
        {

        }

    }
}
