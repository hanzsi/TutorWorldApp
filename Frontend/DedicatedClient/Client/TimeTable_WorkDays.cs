using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Client.TotorWorldService;

namespace Client
{
    public partial class TimeTable_WorkDays : Form
    {
        private List<CheckBox> Checkboxes;
        private Teacher Teacher;
        public TimeTable_WorkDays(Teacher t)
        {
            this.Teacher = t;
            Checkboxes = new List<CheckBox>();
            
            InitializeComponent();

            Checkboxes.Add(CbMonday);
            Checkboxes.Add(CbTuesday);
            Checkboxes.Add(CbWednesday);
            Checkboxes.Add(CbThursday);
            Checkboxes.Add(CbFriday);
            Checkboxes.Add(CbSaturday);
            Checkboxes.Add(CbSunday);
        }
        
 
        private void BtNextPage1_Click(object sender, EventArgs e)
        {
            
            var workDays = Checkboxes.Where(cb => cb.Checked).Select(cb =>
            {
                return new WorkDay { Day = (DayOfWeek)Enum.Parse(typeof(DayOfWeek), cb.Text), Teacher = this.Teacher };
            }).ToList();
            if (workDays.Count() == 0)
            {
                MessageBox.Show("You have to pick at least one day, when you're able to teach.");

                return;
            }
            this.Hide();
            var form2 = new TimeTable_Sessions(workDays);
            form2.Closed += (s, args) => this.Close();
            form2.Show();
        }

}
}
