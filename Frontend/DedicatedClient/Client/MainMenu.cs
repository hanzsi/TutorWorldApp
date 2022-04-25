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
    public partial class MainMenu : Form
    {
        private UserProfile Profile;
        private UserServiceClient serviceClient;
        private Form ProfileCreation;

        public MainMenu()
        {
          
            InitializeComponent();
            var store = UserCredentialStore.Instance;
            serviceClient = new UserServiceClient();
            serviceClient.ClientCredentials.UserName.UserName = store.Email;
            serviceClient.ClientCredentials.UserName.Password = store.Password;
            
            Profile = serviceClient.FindTeacher(store.Email, store.Password);
            if (Profile == null)
            {
                Profile = serviceClient.FindStudent(store.Email, store.Password);
            }

          
            if (Profile is Teacher)
            {
                this.btnTimetable.Visible = true;
                this.btnSkills.Visible = true;
                ProfileCreation = new TeacherProfileCreation();
            }
            else
            {
                this.btnTeacherList.Visible = true;
                ProfileCreation = new StudentProfileCreation();
            }
            lbEmail.Text = Profile.Email;

            ProfileCreation.VisibleChanged += (src, e) =>
            {
                if (!ProfileCreation.Visible)
                {
                    Show();
                }
            };

            ProfileCreation.FormClosing += new FormClosingEventHandler(OnCloseSubMenu);
        }

        private void OnCloseSubMenu(object src, EventArgs e)
        {
            Close();
        }

        private void btnProfile_Click(object sender, EventArgs e)
        {
            ShowProfile();
        }

        private void ShowProfile()
        {
            Hide();
            ProfileCreation.Show();
        }

        private void btnTimetable_Click(object sender, EventArgs e)
        {
            Hide();
            var form = new TimeTable_WorkDays(Profile as Teacher);
            form.FormClosing += (src, ee) => Show();
            form.Show();
        }

        private void logoutBtn_Click(object sender, EventArgs e)
        {
            Close();
            UserCredentialStore.Instance.Email = null;
            UserCredentialStore.Instance.Password = null;
        }

        private void btnTeacherList_Click(object sender, EventArgs e)
        {
            Hide();
            var form = new ListOfTeachersUI(serviceClient, Profile);
            form.FormClosing += (src, ee) => Show();
            form.Show();
        }

        private void btnSkills_Click(object sender, EventArgs e)
        {
            Hide();
            var form = new SkillsetCreation(serviceClient, (Teacher)Profile);
            form.FormClosing += (src, ee) => Show();
            form.Show();

        }

        private void btMyProfile_Click(object sender, EventArgs e)
        {
            if(Profile is Student)
            {
                var store = UserCredentialStore.Instance;
                Profile = serviceClient.FindStudent(store.Email, store.Password);
                Hide();
                var form = new MySessionsList((Student)Profile, serviceClient);
                form.FormClosing += (src, ee) => Show();
                form.Show();
            }
           else
            {
                Hide();
                var form = new TeacherProfileUI(serviceClient, Profile, (Teacher)Profile);
                form.FormClosing += (src, ee) => Show();
                form.Show();
            }
        }
    }
}
