using Client.TotorWorldService;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    public partial class TimeTable_Sessions : Form
    {
        private List<WorkDay> WorkDays;
        public TimeTable_Sessions(List<WorkDay> wd)
        {
            WorkDays = wd;
            InitializeComponent();
        }

        List<string> pickedHours = new List<string>();
        

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            textBox2.Visible = true;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            textBox3.Visible = true;
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            textBox4.Visible = true;
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            textBox5.Visible = true;
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            textBox6.Visible = true;
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            textBox7.Visible = true;
        }

        
        
        private void button1_Click(object sender, EventArgs e)
        {
            //foreach (string hours in pickedHours)
            //{
            //    label3.Text = string.Join("  ", pickedHours.Cast<string>());
            //}
            pickedHours.Clear();
            if (textBox1.Text != "")
            {
                pickedHours.Add(textBox1.Text);
            }
            if (textBox2.Text != "")
            {
                pickedHours.Add(textBox2.Text);
            }
            if (textBox3.Text != "")
            {
                pickedHours.Add(textBox3.Text);
            }
            if (textBox4.Text != "")
            {
                pickedHours.Add(textBox4.Text);
            }
            if (textBox5.Text != "")
            {
                pickedHours.Add(textBox5.Text);
            }
            if (textBox6.Text != "")
            {
                pickedHours.Add(textBox6.Text);
            }
            if (textBox7.Text != "")
            {
                pickedHours.Add(textBox7.Text);
            }

            WorkDays.ForEach(wd => wd.TimeSlots?.Clear());

            string TimeRegex=@"^(\d{2}):(\d{2})$";
            Regex regex = new Regex(TimeRegex);

            foreach (string text in pickedHours)
            {
                if (!regex.IsMatch(text))
                {
                    MessageBox.Show(text + " does not match format!");
                    
                    return;
                }
                try
                {
                    var dateTime = DateTime.ParseExact(text, "HH:mm", CultureInfo.InvariantCulture);
                    WorkDays.ForEach(wd =>
                    {
                        if (wd.TimeSlots == null)
                        {
                            wd.TimeSlots = new List<TimeSlot>();
                        }
                        wd.TimeSlots.Add(new TimeSlot { WorkDay = wd, StartTime = dateTime });
                    });

                }
                catch (Exception)
                {
                    MessageBox.Show(text + " does not match format!");
                    return;
                }
            }

            if (pickedHours.Count == 0)
            {
                MessageBox.Show("You have to set at least one timeslot, when you're able to teach!");

                return;
            }
            // Hack, should just use an ordered colelction in the backend and override comapreable in timeslot
            WorkDays.ForEach(wd => wd.TimeSlots = wd.TimeSlots.OrderBy(ts => ts.StartTime).ToList());

            this.Hide();
            var form3 = new TimeTable_FinalSelection(WorkDays);
            form3.Closed += (s, args) => this.Close();
            form3.Show();
        }

        
    }
}
