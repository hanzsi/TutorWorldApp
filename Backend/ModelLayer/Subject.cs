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
    public class Subject
    {
        [Required]
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        [Required]
        [ForeignKey("TeacherId")]
        public Teacher Teacher { get; set; }

        [Required]
        [DataMember]
        public int TeacherId { get; set; }

        [DataMember]
        [Required]
        public string SubjectName { get; set; }
        [DataMember]
        public List<Skill> Skill { get; set; }

        [DataMember]
        public List<Rating> Ratings { get; set; }

        public Subject()
        {
            this.Skill = new List<Skill>();
            this.Ratings = new List<Rating>();
        }

        public override bool Equals(object obj)
        {
            return obj is Subject && ((Subject)obj).SubjectName == this.SubjectName;
        }

        public override int GetHashCode()
        {
            return this.SubjectName.GetHashCode();
        }

    }
}
