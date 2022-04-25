using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;

namespace MvcWebApp.Services
{
    public class WeekCalculator
    {
        // All of this is local to the web server
        private CalendarWeekRule LocalCalendarWeekRule = CultureInfo.CurrentCulture.DateTimeFormat.CalendarWeekRule;
        private DayOfWeek LocalFirstDayOfWeek = CultureInfo.CurrentCulture.DateTimeFormat.FirstDayOfWeek;
        private Calendar LocalCalendar = new GregorianCalendar();

        public int GetCurrentWeek()
        {
            return GetWeekFromDate(DateTime.Now);
        }

        public int GetWeekFromDate(DateTime date)
        {
            return LocalCalendar.GetWeekOfYear(date, LocalCalendarWeekRule, LocalFirstDayOfWeek);
        }

        public DateTime GetDateFromWeek(int weeknumber, DayOfWeek dayOfWeek)
        {
            var now = DateTime.Now;
            int daysToAdd = ((int)dayOfWeek - (int)now.DayOfWeek + 7) % 7;

            var date = DateTime.Now.AddDays(daysToAdd);
            int weekDiff = weeknumber - LocalCalendar.GetWeekOfYear(date, LocalCalendarWeekRule, LocalFirstDayOfWeek);
            return LocalCalendar.AddWeeks(date, weekDiff);
        }

        public DateTime GetDateTimeFromWeek(int weeknumber, DayOfWeek dayOfWeek, DateTime time)
        {
            var date = GetDateFromWeek(weeknumber, dayOfWeek);
            return new DateTime(date.Year, date.Month, date.Day, time.Hour, time.Minute, time.Second, time.Millisecond, LocalCalendar);
        }
    }
}