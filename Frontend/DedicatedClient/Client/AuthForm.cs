using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ServiceModel;
using Client.TotorWorldService;
using Client.AuthService;

namespace Client
{

    public partial class AuthForm : Form
    {
        private AuthServiceClient client = new AuthServiceClient();


        public AuthForm()
        {
            InitializeComponent();
            regTab.SelectTab(1);

            // TEST DATA
            tbEmail.Text = loginEmailBox.Text = "test.t@gmail.com";
            tbPw1.Text = loginPasswordBox.Text = "123456789";
            tbPw2.Text = "123456789";


        }

        private void btSubmit_Click(object sender, EventArgs e)
        {
            string Email = tbEmail.Text;
            if (Email.Length < 6)
            {
                MessageBox.Show("Email error");
                return;
            }
            string Pw1 = tbPw1.Text;
            string Pw2 = tbPw2.Text;
            if(Pw1 != Pw2)
            {
                MessageBox.Show("Passwords dont match");
                return;
            }
            if(Pw1.Length < 6)
            {
                MessageBox.Show("Password is too short");
                return;
            }
            if (!rbStudent.Checked && !rbTeacher.Checked)
            {
                MessageBox.Show("Please select the profile type: teacher or student", "Validation error");
                return;
            }

            try
            {
                client.Register(Email, Pw1, rbTeacher.Checked);
                UserCredentialStore.Instance.Email = Email;
                UserCredentialStore.Instance.Password = Pw1;
                
            }
            catch (FaultException<AuthFault> ex)
            {
                var fault = ex.Detail;
                MessageBox.Show(fault.Message, ex.Message);
                return;
            }

            ShowProfileCreation();

        }

        private void ShowProfileCreation()
        {
            Form form = null;
            if (rbStudent.Checked)
            {
                form = new StudentProfileCreation();
            }
            else if (rbTeacher.Checked)
            {
                form = new TeacherProfileCreation();
            }
                
            if (form == null)
            {
                return;
            }

            form.Tag = this;
            form.Show();
            form.VisibleChanged += (src, ev) => ShowMain();
           // form.FormClosed += (src, ev) => ShowMain();
       
        }

        private void ShowMain()
        {
            Hide();
            var form = new MainMenu();
            form.FormClosed += (s, e) => Close();
            form.Show();
        }

        private void loginBtn_Click(object sender, EventArgs e)
        {
            if (loginEmailBox.Text.Length < 6)
            {
                MessageBox.Show("Please enter an email address");
                return;
            }

            if (loginPasswordBox.Text.Length < 6)
            {
                MessageBox.Show("Please enter a longer password");
                return;
            }

            try
            {
                client.Login(loginEmailBox.Text, loginPasswordBox.Text);
                UserCredentialStore.Instance.Email = loginEmailBox.Text;
                UserCredentialStore.Instance.Password = loginPasswordBox.Text;
                ShowMain();
            } 
            catch (FaultException<AuthFault> ex)
            {
                MessageBox.Show(ex.Detail.Message, ex.Message);
                return;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Unknown error");
                return;
            }
        }
    }
}
