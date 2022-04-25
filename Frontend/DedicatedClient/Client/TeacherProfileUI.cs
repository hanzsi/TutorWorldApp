using Client.Components;
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
    public partial class TeacherProfileUI : Form
    {
        private UserServiceClient ServiceClient;
        private UserProfile CurrentUser;
        private Teacher Teacher;
        

        public TeacherProfileUI(UserServiceClient client, UserProfile currentUser, Teacher teacher)
        {
            this.ServiceClient = client;
            this.CurrentUser = currentUser;
            this.Teacher = teacher;
            InitializeComponent();

            lblFNameDB.Text = teacher.FirstName;
            lblLNameDB.Text = teacher.LastName;
            
            if(currentUser is Teacher)
            {
                btRate.Enabled = false;
                
            }

            if (!string.IsNullOrEmpty(teacher.Bio))
                lblBioText.Text = teacher.Bio;
            else
                lblBioText.Text = "<no bio>";

            if (teacher.PostalCode != null)
                lblLocationDB.Text = "Postal code: " + teacher.PostalCode;
            else
                lblLocationDB.Visible = false;

            if (!string.IsNullOrEmpty(teacher.Phonenumber))
                lblPhoneDB.Text = teacher.Phonenumber;
            else
                lblPhoneDB.Text = "<no number>";

            if (!string.IsNullOrEmpty(teacher.EducationLevel))
                lblEducationDB.Text = teacher.EducationLevel;
            else
                lblEducation.Text = "<unspecified>";

            if (teacher.HourlyPrice != null)
                lblPriceDB.Text = teacher.HourlyPrice + "";
            else
                lblPriceDB.Text = "Ask";

            foreach (var sub in Teacher.Subjects)
            {
                var item = new ProfileSubjectItem();
                item.Subject = sub;
                sub.Ratings = ServiceClient.GetRatingsBySubject(sub);
                SkillContainer.Controls.Add(item);
            }

            foreach (ProfileSubjectItem item in SkillContainer.Controls)
            {
                item.UpdateUI();
            }

            if (CurrentUser is Student)
            {
                btRate.Visible = true;
            }


            timeTable.Teacher = teacher;
            timeTable.TimeSlotSelectedEvent += TimeTable_TimeSlotSelectedEvent;
        }

        private void TimeTable_TimeSlotSelectedEvent(object sender, TimeSlot slot, DateTime selectedDate)
        {
            if (CurrentUser is Student)
            {
                var student = CurrentUser as Student;

                var form = new PopupFormToBook(ServiceClient, student, slot, selectedDate);
                form.Show();
            }
            else
            {
                MessageBox.Show("Teachers cannot book their own sessions");
                return;
            }
           
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void btRate_Click(object sender, EventArgs e)
        {
            var popup = new RateSubjectPopup(Teacher, CurrentUser as Student);
            popup.RatingSubmittedEvent += Popup_RatingSubmitted;
            popup.Show();
        }

        private void Popup_RatingSubmitted(object sender, Rating rating)
        {
            try
            {
                ServiceClient.CreateRating(rating);
                rating.Subject.Ratings = ServiceClient.GetRatingsBySubject(rating.Subject); // hackish
                foreach (ProfileSubjectItem item in SkillContainer.Controls)
                {
                    item.UpdateUI();
                }
                MessageBox.Show("Rating added");
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error trying to save rating", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
