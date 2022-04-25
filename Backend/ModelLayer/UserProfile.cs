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
    public class UserProfile
    {
        [DataMember]
        [Required]
        public int Id { get; set; }
        [DataMember]
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [DataMember]
        public string FirstName { get; set; }
        [DataMember]
        public string LastName { get; set; }
        [DataMember]
        public string Phonenumber { get; set; }
        [DataMember]
        public string ImageName { get; set; }
        [DataMember]
        public string Bio { get; set; }


        public override bool Equals(object obj)
        {
            return obj is Teacher && ((Teacher)obj).Id == this.Id;
        }
    }
}
