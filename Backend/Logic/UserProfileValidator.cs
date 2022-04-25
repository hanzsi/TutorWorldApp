using ModelLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Logic
{
    class UserProfileValidator
    {
        private static string PhonenumberPattern = @"^(\+45)?[0-9]{8}$";

        public void Validate(UserProfile profile)
        {
            if (profile.FirstName == null || profile.FirstName == "" || profile.LastName == null || profile.LastName == "")
            {
                throw new UserCreationException("Invalid first or last name", profile);
            }
           
            Regex regex = new Regex(PhonenumberPattern);
            if (profile.Phonenumber == null || !regex.IsMatch(profile.Phonenumber))
            {
                throw new UserCreationException("User phonenumber is not in format: XXXXXXXX", profile);
            }
        }
    }
}
