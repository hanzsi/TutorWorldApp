using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ModelLayer
{
    [DataContract(IsReference = true)]
    public class WorkDay
    {
        [DataMember]
        [Required]
        public int Id { get; set; }
        [DataMember]
        [Required]
        public DayOfWeek Day { get; set; }
        [DataMember]
        [Required]
        public Teacher Teacher { get; set; }
        [DataMember]
        [Required]
        public List<TimeSlot> TimeSlots { get; set; }
    }
}
