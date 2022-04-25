using Client.TotorWorldService;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    public partial class PopupFormToBook : Form
    {
        private TimeSlot TimeSlot;
        private DateTime SessionDate;
        private Student Student;
        private UserServiceClient client;

        public PopupFormToBook(UserServiceClient client, Student student, TimeSlot ts, DateTime sessionDate)
        {
            this.client = client;
            InitializeComponent();
            TimeSlot = ts;
            SessionDate = sessionDate;
            Student = student;
        }
        

        private void PopupFormToBook_Load(object sender, EventArgs e)
        {
            label2.Text = string.Format("{0:H:mm}", TimeSlot.StartTime);
            comboBox1.DataSource = TimeSlot.WorkDay.Teacher.Subjects;
            comboBox1.DisplayMember = "SubjectName";
            comboBox1.ValueMember = "Id";
        }

        private void label2_TextChanged(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem == null)
            {
                MessageBox.Show("You must select a subject!", "Booking error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (string.IsNullOrEmpty(textBox2.Text))
            {
                MessageBox.Show("You must specify a topic!", "Booking error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                BookSession session = new BookSession()
                {
                    Slot = TimeSlot,
                    Date = SessionDate,
                    Subject = (Subject)comboBox1.SelectedItem,
                    Topic = textBox2.Text,
                    Comments = textBox1.Text,
                    Student = Student,
                };
                try
                {
                    client.Book(session);
                    Close();
                }
                catch (FaultException ex)
                {
                    MessageBox.Show(ex.Message, "Error occurred when trying to book session");
                }
                
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        
    }
}
