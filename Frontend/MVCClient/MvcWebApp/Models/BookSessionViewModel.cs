using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcWebApp.Models
{
    public class BookSessionViewModel
    {
        [Required]
        public int TeacherId { get; set; }

        [Required]
        public int SlotId { get; set; }

        [Required]
        public int SubjectId { get; set; }

        [Required]
        public string Topic { get; set; }

        public string Comments { get; set; }

        [Required]
        public int WeekNumber { get; set; }
    }
}