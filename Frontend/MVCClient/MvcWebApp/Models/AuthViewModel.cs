using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcWebApp.Models
{
    public class AuthViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [StringLength(255, MinimumLength = 6)]
        public string Password { get; set; }

        [Required]
        [DisplayName("Password confirmation")]
        [StringLength(255, MinimumLength = 6)]
        public string PasswordConfirm { get; set; }

        [Required]
        public bool IsTeacher { get; set; }
    }
}