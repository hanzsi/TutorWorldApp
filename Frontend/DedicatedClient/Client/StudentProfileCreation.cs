using Client.TotorWorldService;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    public partial class StudentProfileCreation : Form
    {

        private static string PhonenumberPattern = @"^[0-9]{8}$";
        private UserServiceClient client;
        private Student Student;
        public StudentProfileCreation()
        {
            this.client = new UserServiceClient();
            client.ClientCredentials.UserName.UserName = UserCredentialStore.Instance.Email;
            client.ClientCredentials.UserName.Password = UserCredentialStore.Instance.Password;
            InitializeComponent();
        }
        protected override void OnActivated(EventArgs e)
        {
            base.OnActivated(e);
            var store = UserCredentialStore.Instance;
            Student = client.FindStudent(store.Email, store.Password);
            if (Student.FirstName != null)
                tbFirstName.Text = Student.FirstName;
            if (Student.LastName != null)
                tbLastName.Text = Student.LastName;
            if (Student.Phonenumber != null)
                tbPhone.Text = Student.Phonenumber;
            if (Student.Bio != null)
                tbBio.Text = Student.Bio;
        }

        private void bSubmit_Click(object sender, EventArgs e)
        {

            if (tbFirstName.Text == "")
            {
                MessageBox.Show("Please enter first name, please try again");
                return;
            }

            if (tbLastName.Text == "")
            {
                MessageBox.Show("Please enter last name, please try again");
                return;
            }

            string phone = tbPhone.Text;
            Regex regex = new Regex(PhonenumberPattern);
            if (!regex.IsMatch(phone))
            {
                MessageBox.Show("Phonenumber wrong, please try again");
                return;
            }

            Student.FirstName = tbFirstName.Text;
            Student.LastName = tbLastName.Text;
            Student.Bio = tbBio.Text;
            Student.Phonenumber = tbPhone.Text;

            try
            {
                client.Update(Student);
                

            }
            catch (FaultException<UserFault> ex)
            {
                var fault = ex.Detail;
                MessageBox.Show("Whoops, please try again"+ fault);
                return;
            }

            MessageBox.Show("Profile was saved!");
            Hide();
        }

        private void SkipBtn_Click(object sender, EventArgs e)
        {
            Hide();
        }
    }
}
