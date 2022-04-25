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
    public class BookSession
    {
        [DataMember]
        [Required]
        public int Id { get; set; }

        [DataMember]
        [Required]
        public string Topic { get; set; }

        [DataMember]
        public TimeSlot Slot { get; set; }

        [ForeignKey("Slot")]
        [Required]
        public int Slot_Id { get; set; }

        [DataMember]
        public Student Student { get; set; }

        [ForeignKey("Student")]
        public int Student_Id { get; set; }

        [DataMember]
        public string Comments { get; set; }

        [DataMember]
        public Subject Subject { get; set; }

        [ForeignKey("Subject")]
        public int Subject_Id { get; set; }

        [DataMember]
        [Required]
        public DateTime Date { get; set; }
    }
}
