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
    [DataContract(IsReference = true)]
    public class TimeSlot
    {
        [Required]
        [DataMember]
        public int Id { get; set; }
        [Required]
        [DataMember]
        public DateTime StartTime { get; set; }
        [Required]
        [DataMember]
        public WorkDay WorkDay { get; set; }
        [Required]
        [ForeignKey("WorkDay")]
        public int WorkDay_Id { get; set; }
        [DataMember]
        public List<BookSession> BookSessions { get; set; }

        public TimeSlot()
        {
            this.BookSessions = new List<BookSession>();
        }
    }
}
