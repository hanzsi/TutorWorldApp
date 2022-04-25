using Client.TotorWorldService;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    public partial class TeacherProfileCreation : Form
    {
        private static string PhonenumberPattern = @"^[0-9]{8}$";
        private static string PostPattern = @"^[0-9]{4}$";

        private UserServiceClient client;
        private Teacher Teacher;

        public TeacherProfileCreation()
        {
            client = new UserServiceClient();
            client.ClientCredentials.UserName.UserName = UserCredentialStore.Instance.Email;
            client.ClientCredentials.UserName.Password = UserCredentialStore.Instance.Password;
            InitializeComponent();
            cbEducation.Items.Add("High school");
            cbEducation.Items.Add("College");
            cbEducation.Items.Add("Bachelors");
            cbEducation.Items.Add("Masters");
            cbEducation.Items.Add("Phd");
        }

        protected override void OnActivated(EventArgs e)
        {
            base.OnActivated(e);
            var store = UserCredentialStore.Instance;
            Teacher = client.FindTeacher(store.Email, store.Password);

            if (Teacher.FirstName != null)
                tbFirstName.Text = Teacher.FirstName;
            if (Teacher.LastName != null)
                tbLastName.Text = Teacher.LastName;
            if (Teacher.Phonenumber != null)
                tbPhone.Text = Teacher.Phonenumber;
            if (Teacher.PostalCode != null)
                tbPostalCode.Text = "" + Teacher.PostalCode;
            if (Teacher.Bio != null)
                tbBio.Text = Teacher.Bio;
            if (Teacher.EducationLevel != null)
                cbEducation.SelectedItem = Teacher.EducationLevel;
            if (Teacher.HourlyPrice != null)
                tbPrice.Text = string.Format("{0:0.00}", Teacher.HourlyPrice);
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
            Regex regex2 = new Regex(PostPattern);
            if (!regex.IsMatch(phone))
            {
                MessageBox.Show("Phonenumber wrong, please try again");
                return;
            }

            if (tbBio.Text == "" || tbBio.Text == null || tbBio.Text.Length < 154)
            {
                MessageBox.Show("The Bio should be atleast 154 characters long");
                return;
            }

            if (cbEducation.SelectedItem == null)
            {
                MessageBox.Show("Please select your education");
                return;
            }

            if (!regex2.IsMatch(tbPostalCode.Text))

            {
                MessageBox.Show("Please enter your postal code");
                return;
            }

            double price;
            bool isDouble = double.TryParse(tbPrice.Text, out price);
            if (string.IsNullOrEmpty(tbPrice.Text) || !isDouble || price < 1)
            {
                MessageBox.Show("Please enter your desired price");
                return;
            }

            Teacher.FirstName = tbFirstName.Text;
            Teacher.LastName = tbLastName.Text;
            Teacher.Phonenumber = tbPhone.Text;
            Teacher.PostalCode = Convert.ToInt32(tbPostalCode.Text);
            Teacher.Bio = tbBio.Text;
            Teacher.EducationLevel = cbEducation.Text;
            Teacher.HourlyPrice = Convert.ToDouble(tbPrice.Text);
            try
            {
                client.Update(Teacher);
            }

            catch (FaultException<UserFault> exception)
            {
                var error = exception.Detail.Issue + ":" + exception.Detail.Details;
                MessageBox.Show("An error has occured" + error);
                return;
            }
            MessageBox.Show("Profile was saved!");
            Hide();
        }

        private void SkipBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void bChoose_Click(object sender, EventArgs e)
        {

            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp)|*.jpg; *.jpeg; *.gif; *.bmp";
            if (open.ShowDialog() == DialogResult.OK)
            {

                var fd = new SaveFileDialog();
                fd.Filter = "Bmp(*.BMP;)|*.BMP;| Jpg(*Jpg)|*.jpg";
                fd.AddExtension = true;
                if (fd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    Image bitmap = Image.FromFile(open.FileName);
                    bitmap.Save(@"C:\Games\MyFile2.bmp");
                }
            }
        }

        private void tbFirstName_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
