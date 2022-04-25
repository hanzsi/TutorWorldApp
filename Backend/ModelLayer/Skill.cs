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
    public class Skill
    {   
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        [Required]
        public Subject Subject { get; set; }
        [DataMember]
        public string SkillName { get; set; }
        [DataMember]
        [Required]
        [ForeignKey("Subject")]
        public int SubjectId { get; set; }
     }
}
