using DatabaseLayer;
using ModelLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class WorkDayController
    {
        private DBContext db = new DBContext();


        public void Create(WorkDay workDay)
        {
            // Should never happen I think
            foreach (var slot in workDay.TimeSlots)
            {
                int counter = 0;
                foreach (TimeSlot slot2 in workDay.TimeSlots)
                {
                    if (slot.StartTime == slot2.StartTime)
                    {
                        counter++;
                        if(counter > 1)
                        {
                            throw new Exception("Start times match " + slot.StartTime.Hour + ":" + slot.StartTime.Minute + "0");
                        }
                    }
                    
                }
                slot.WorkDay = workDay;
            }
            workDay.Teacher = db.Teachers.Find(workDay.Teacher.Id);
            db.WorkDays.Add(workDay);
            db.SaveChanges();
        }

    }
}
