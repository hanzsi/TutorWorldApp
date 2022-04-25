using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcWebApp.Models
{
    public class WorkDayViewModel
    {
        public DayOfWeek DayOfWeek { get; set; }

        public List<TimeSlotViewModel> TimeSlots { get; set; }

        public DateTime Date { get; set; }
    }
}