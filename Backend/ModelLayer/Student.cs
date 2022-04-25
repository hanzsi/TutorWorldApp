using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ModelLayer
{
    [Table("Students")]
    [DataContract]
    public class Student : UserProfile
    {
        [DataMember]
        
        public List<Teacher> Teachers { get; set; }
        [DataMember]
        public List<BookSession> BookSessions { get; set; }

        public Student()
        {
            Teachers = new List<Teacher>();
            BookSessions = new List<BookSession>();
        }
    }
}
