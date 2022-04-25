using Client.TotorWorldService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.ServiceModel;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // Only valid for testing. With a certificate signed by CA this is not needed.
            ServicePointManager.ServerCertificateValidationCallback = (obj, certificate, chain, errors) => true;

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);


            var c = new UserServiceClient();
            var d = new UserProfile();
            List<Teacher> Teachers = new List<Teacher>();
            Teachers.Add(new Teacher() { FirstName = "Patrik", Subjects = new List<Subject> { new Subject() { SubjectName = "Prog" } }, HourlyPrice = 200, PostalCode = 9000 });
            Teachers.Add(new Teacher() { FirstName = "xy", Subjects = new List<Subject> { new Subject() { SubjectName = "Biology" } }, HourlyPrice = 222, PostalCode = 8000 });
            Teachers.Add(new Teacher() { FirstName = "zzz", Subjects = new List<Subject> { new Subject() { SubjectName = "German" } }, HourlyPrice = 250, PostalCode = 9000 });
            Teachers.Add(new Teacher() { FirstName = "Krisztian", Subjects = new List<Subject> { new Subject() { SubjectName = "Hungarian" } }, HourlyPrice = 222, PostalCode = 8000 });
            Teachers.Add(new Teacher() { FirstName = "blabla", Subjects = new List<Subject> { new Subject() { SubjectName = "German" }, new Subject() { SubjectName = "English" } }, HourlyPrice = 250, PostalCode = 9000 });
            Teachers.Add(new Teacher() { FirstName = "blabla", Subjects = new List<Subject> { new Subject() { SubjectName = "German" } }, HourlyPrice = 250, PostalCode = 9000 });

            c.ClientCredentials.UserName.UserName = UserCredentialStore.Instance.Email = "test.t@gmail.com";
            c.ClientCredentials.UserName.Password = UserCredentialStore.Instance.Password = "123456789";

            //var teacher = c.FindTeacher("test.t@gmail.com", "123456789");
            //var student = c.FindStudent("test@gmail.com", "123456789");

            // Try/cathc is for debug, but probably gonna stay longer
            try
            {
                Application.Run(new AuthForm()); // my turn to leave unrelated code and chaos 
            }
            catch (EndpointNotFoundException e)
            {
                var msg = string.Format("{0}\n{1}", e.Message, e.StackTrace);
                MessageBox.Show(msg, "Service Error " + e.GetType().ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
