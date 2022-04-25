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
    public class Rating
    {
        [Required]
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public Subject Subject { get; set; }

        [Required]
        //[ForeignKey("Subject")] // is this necessary?
        [DataMember]
        public int SubjectId { get; set; }

        [DataMember]
        public Student Student { get; set; }
        
        [Required]
        [DataMember]
        public int StudentId { get; set; }

        [Required]
        [DataMember]
        public double Score { get; set; }
    }
}
