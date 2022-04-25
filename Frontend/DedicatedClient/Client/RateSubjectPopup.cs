using Client.TotorWorldService;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    public delegate void RatingSubmitted(object sender, Rating rating);
    public partial class RateSubjectPopup : Form
    {
        public event RatingSubmitted RatingSubmittedEvent;

        private Student Student;

        public RateSubjectPopup(Teacher teacher, Student currentStudent)
        {
            if (teacher == null)
            {
                throw new ArgumentNullException("Teacher can not be null");
            }
            if (currentStudent == null)
            {
                throw new ArgumentNullException("Student can not be null");
            }
            InitializeComponent();
            this.Student = currentStudent;
            this.Text = string.Format("{0} {1} - Rating", teacher.FirstName, teacher.LastName);
            this.NameLbl.Text = teacher.FirstName + " " + teacher.LastName;
            this.SubjectBox.DataSource = teacher.Subjects;
        }


        private void ShowError(string s)
        {
            ErrorLbl.Text = s;
            ErrorLbl.Visible = true;
        }

        private void SubmitBtn_Click(object sender, EventArgs e)
        {
            var score = ScoreBox.Value;
            if (score < 1 && score > 5)
            {
                ShowError("Score must be between 1 and 5");
            }
            else if (SubjectBox.SelectedIndex == -1)
            {
                ShowError("You must select a subject to rate");
            }
            else
            {
                Subject subject = (Subject)SubjectBox.SelectedItem;
                Rating rating = new Rating()
                {
                    Subject = subject,
                    SubjectId = subject.Id,
                    Score = (float)score,
                    Student = Student,
                    StudentId = Student.Id
                };
                OnRatingSubmitted(rating);
                Close();
            }
        }

        protected void OnRatingSubmitted(Rating rating)
        {
            RatingSubmittedEvent?.Invoke(this, rating);
        }
    }
}
