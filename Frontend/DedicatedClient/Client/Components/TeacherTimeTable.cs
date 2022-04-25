using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Client.TotorWorldService;
using System.Globalization;

namespace Client.Components
{
    public delegate void TimeSlotSelected(object sender, TimeSlot slot, DateTime selectedDate);


    public partial class TeacherTimeTable : UserControl
    {
        public event TimeSlotSelected TimeSlotSelectedEvent;
        private UserServiceClient serviceClient;
        //private Student LoggedInStudent;
        private Teacher _Teacher;
        public Teacher Teacher
        {
            get { return _Teacher; }
            set
            {
                _Teacher = value;
                if (Teacher != null)
                    UpdateTable();
            }
        }

        private CalendarWeekRule LocalCalendarWeekRule = CultureInfo.CurrentCulture.DateTimeFormat.CalendarWeekRule;
        private DayOfWeek LocalFirstDayOfWeek = CultureInfo.CurrentCulture.DateTimeFormat.FirstDayOfWeek;
        private Calendar LocalCalendar = new GregorianCalendar();
        private int CurrentWeek;

        public TeacherTimeTable()
        {
            this.serviceClient = new UserServiceClient("WSHttpBinding_IUserService");
            this.serviceClient.ClientCredentials.UserName.UserName = UserCredentialStore.Instance.Email;
            this.serviceClient.ClientCredentials.UserName.Password = UserCredentialStore.Instance.Password;
            //this.LoggedInStudent = loggedInStudent;
            //this.Teacher = teacher;

            InitializeComponent();

            CurrentWeek = LocalCalendar.GetWeekOfYear(DateTime.Now, LocalCalendarWeekRule, LocalFirstDayOfWeek);
            label10.Text = CurrentWeek + "";
            
            new ListBox[] { listBox1, listBox2, listBox3, listBox4, listBox5, listBox6, listBox7 }
                .ToList() // Put all listboxes in a temporary list for convenience
                .ForEach(lb =>
                {
                    lb.ClearSelected();
                    lb.FormattingEnabled = true;
                    lb.SelectionMode = SelectionMode.One;
                    // Format all values to only show hour and minute
                    lb.Format += (sender, args) =>
                    {
                        var ts = (TimeSlot)args.Value;
                        args.Value = string.Format("{0:HH:mm}", ts.StartTime);
                    };
                });
        }

        private void UpdateTable()
        {
            ShowWeek(CurrentWeek);
        }



        private void ShowWeek(int wwekNumber)
        {
            listBox1.DataSource = FilterTimeSlots(Teacher.WorkDays, DayOfWeek.Monday, wwekNumber);
            listBox2.DataSource = FilterTimeSlots(Teacher.WorkDays, DayOfWeek.Tuesday, wwekNumber);
            listBox3.DataSource = FilterTimeSlots(Teacher.WorkDays, DayOfWeek.Wednesday, wwekNumber);
            listBox4.DataSource = FilterTimeSlots(Teacher.WorkDays, DayOfWeek.Thursday, wwekNumber);
            listBox5.DataSource = FilterTimeSlots(Teacher.WorkDays, DayOfWeek.Friday, wwekNumber);
            listBox6.DataSource = FilterTimeSlots(Teacher.WorkDays, DayOfWeek.Saturday, wwekNumber);
            listBox7.DataSource = FilterTimeSlots(Teacher.WorkDays, DayOfWeek.Sunday, wwekNumber);
        }


        private List<TimeSlot> FilterTimeSlots(List<WorkDay> days, DayOfWeek day, int weekNumber)
        {
            var workDay = days.Where(s => s.Day == day).FirstOrDefault();
            if (workDay == null)
            {
                return new List<TimeSlot>();
            }
            // This will filter slots which are in the specified week
            // AND do not have any book sessions associated with them
            return workDay.TimeSlots
                .Where(s => s.BookSessions == null ||
                    // Count how many sessions are there for this week
                    s.BookSessions.Count(bs => LocalCalendar.GetWeekOfYear(bs.Date, LocalCalendarWeekRule, LocalFirstDayOfWeek) == weekNumber) == 0)
                .ToList();

        }

        private void listBox_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            var listBox = (ListBox)sender;
            var selectedSlot = (TimeSlot)listBox.SelectedItem;
            var sessionDate = GetSessionDate(listBox);
            if(-1 == sessionDate.CompareTo(DateTime.Now))
            {
                MessageBox.Show("Wrong time");
            }
            else
            {
                OnTimeSlotSelected(selectedSlot, sessionDate);
            }
        }

        protected virtual void OnTimeSlotSelected(TimeSlot timeSlot, DateTime date)
        {
            TimeSlotSelectedEvent?.Invoke(this, timeSlot, date);
        }

        private DateTime GetSessionDate(ListBox listbox)
        {
            DayOfWeek day;
            if (listbox == listBox1)
                day = DayOfWeek.Monday;
            else if (listbox == listBox2)
                day = DayOfWeek.Tuesday;
            else if (listbox == listBox3)
                day = DayOfWeek.Wednesday;
            else if (listbox == listBox4)
                day = DayOfWeek.Thursday;
            else if (listbox == listBox5)
                day = DayOfWeek.Friday;
            else if (listbox == listBox6)
                day = DayOfWeek.Saturday;
            else if (listbox == listBox7)
                day = DayOfWeek.Sunday;
            else throw new NotImplementedException();

            var now = DateTime.Now;
            int daysToAdd = ((int)day - (int)now.DayOfWeek + 7) % 7;

            var date = DateTime.Now.AddDays(daysToAdd);
            int weekDiff = CurrentWeek - LocalCalendar.GetWeekOfYear(date, LocalCalendarWeekRule, LocalFirstDayOfWeek);
            return LocalCalendar.AddWeeks(date, weekDiff);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CurrentWeek++;
            label10.Text = CurrentWeek + "";
            ShowWeek(CurrentWeek);
        }
    }
}
