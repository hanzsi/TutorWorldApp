using MvcWebApp.TutorWorldServiceRef;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcWebApp.Models
{
    public class TimeSlotViewModel
    {
        public int SlotId { get; set; }

        public DateTime DateTime { get; set; }

        public BookSession BookSession { get; set; }

    }
}