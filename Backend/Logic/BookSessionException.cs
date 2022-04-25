using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelLayer;

namespace Logic
{
    public class BookSessionException : Exception
    {
        public BookSession Session { get; set; }

        public BookSessionException(string message, BookSession session): base (message)
        {
            this.Session = session;
        }
    }
}
