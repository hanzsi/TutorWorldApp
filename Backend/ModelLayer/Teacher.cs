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
    [Table("Teachers")]
    [DataContract(IsReference = true)]
    public class Teacher : UserProfile
    {
        [DataMember]
        public List<Student> Students { get; set; }
        [DataMember]
        public int? PostalCode { get; set; }
        [DataMember]
        public double? HourlyPrice { get; set; }
        [DataMember]
        public string EducationLevel { get; set; }
        [DataMember]
        public List<WorkDay> WorkDays { get; set; }

        [DataMember]
        public List<Subject> Subjects { get; set; }
        
        public Teacher()
        {
            Students = new List<Student>();
            Subjects = new List<Subject>();
            WorkDays = new List<WorkDay>();
        }
    }
}
