using Client.TotorWorldService;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    public partial class MySessionsList : Form
    {

        private UserServiceClient USC;
        
        BindingList<BookSession> bookedSession = new BindingList<BookSession>();
        private BookSession CurrentSession;//$e$$ion
        
        public MySessionsList(Student student, UserServiceClient usc)
        {
            this.USC = usc;
            InitializeComponent();//LÉTREHOZZA A KIBASZOTT FORMOT
            foreach (BookSession bs in student.BookSessions)
            {
                bookedSession.Add(bs);
            }


            //bookedSession.Add("Wednesday 14:00 Week: 42");
            //bookedSession1.Add("Wednesday 14:00");
            //bookedSession1.Add("Math");
            //bookedSession1.Add("Analysis");
            //bookedSession1.Add("It's just some text, normally this is the comment from the student to the teacher, if he needs something special.");
            //bookedSession.Add("Monday 10:30 Week: 43");
            //bookedSession1.Add("Monday 10:30");
            //bookedSession1.Add("Programming");
            //bookedSession1.Add("C#");
            //bookedSession1.Add("Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor");
            
        }

        private void listBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            CurrentSession = (BookSession)listBox1.SelectedItem;
            label7.Text = String.Format("{0:H:mm}", CurrentSession.Date);
            label8.Text = CurrentSession.Subject.SubjectName;
            label9.Text = CurrentSession.Topic;
            textBox1.Text = CurrentSession.Comments;
            
           
        }



        private void MySessionsList_Load(object sender, EventArgs e)
        {
            listBox1.DataSource = bookedSession;
            listBox1.DisplayMember = bookedSession.ToString();
            listBox1.FormattingEnabled = true;
            listBox1.Format += (senders, args) =>
            {
                var bs = (BookSession)args.Value;
                args.Value = string.Format("{0} {1}", bs.Subject.SubjectName, bs.Date);
            };
            label7.Text = "";
            label8.Text = "";
            label9.Text = "";
            
            
            
        }

        private void button1_Click(object sender, EventArgs e)
        {

            int check = CurrentSession.Date.AddHours(-24).CompareTo(DateTime.Now);
            if (check < 0)
            {
                MessageBox.Show("You cannot cancel this session, contact your tutor for more information");
                return;
            }
            else
            {
                bookedSession.Remove(CurrentSession);
                USC.RemoveBookedSession(CurrentSession);
                textBox1.Clear();
                label7.Text = "";
                label8.Text = "";
                label9.Text = "";
            }
            

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        
    }
}
