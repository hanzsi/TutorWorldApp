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
    public partial class ListOfTeachersUI : Form
    {
        private const int TeachersPerPage = 3;

        private BindingList<Teacher> Teachers;
        private List<Subject> Subjects = new List<Subject>();


        private UserServiceClient ServiceClient;

        private UserProfile CurrentUser;

        private int CurrentPage;
        private int MaxPage;


        public ListOfTeachersUI(UserServiceClient client, UserProfile currentUser)
        {
            this.ServiceClient = client;
            this.CurrentUser = currentUser;
            this.Teachers = new BindingList<Teacher>(ServiceClient.GetTeacherList());
            InitializeComponent();
            lboxFilter.Visible = false;
            tbMin.Visible = false;
            tbMax.Visible = false;
            Subjects = ServiceClient.GetDistinctSubjets();

        }

        private void ListOfTeachersUI_Load(object sender, EventArgs e)
        {
            MaxPage = Teachers.Count / TeachersPerPage;
            if (Teachers.Count % TeachersPerPage != 0)
            {
                MaxPage++;
            }
            ShowPage(0);
            btBack.Enabled = false;
        }


        private void btNext_Click(object sender, EventArgs e)
        {
            if (CurrentPage < MaxPage)
            {
                CurrentPage++;
                btBack.Enabled = true;
                if (CurrentPage == MaxPage - 1)
                {
                    btNext.Enabled = false;
                }
                ShowPage(CurrentPage);
            }
        }

        private void btShow_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            int index = CurrentPage * TeachersPerPage + (int)btn.Tag;

            Teacher teacher = Teachers[index];

            // We do not know how long was the user looking at the list
            // Let's get the fresh teacher details
            teacher = ServiceClient.FindTeacherById(teacher.Id);

            Hide();
            var form = new TeacherProfileUI(ServiceClient, CurrentUser, teacher);
            form.FormClosed += (src, ev) => Show();
            form.Show();


        }


        public string SubjectToString(List<Subject> L)
        {
            string s = "";
            foreach (var x in L)
            {
                if (x != L.Last())
                {
                    s += x.SubjectName + ", ";
                }
                else
                {
                    s += x.SubjectName;
                }
                    
            }
            
            return s;
        }

        private void btBack_Click(object sender, EventArgs e)
        {
            if (CurrentPage > 0)
            {
                CurrentPage--;
                btNext.Enabled = true;
                if (CurrentPage == 0)
                {
                    btBack.Enabled = false;
                }
                ShowPage(CurrentPage);
            }

        }

        private void ShowPage(int pageNumber)
        {
            CurrentPage = pageNumber;
            lbPage.Text = (pageNumber + 1) + "/" + (MaxPage);
            int index = pageNumber * TeachersPerPage;
            ShowTeacherListItem(index, lblName1, lblSubjects1, lblPrice1, btShow1);

            index = pageNumber * TeachersPerPage + 1;
            ShowTeacherListItem(index, lblName2, lblSubjects2, lblPrice2, btShow2);

            index = pageNumber * TeachersPerPage + 2;
            ShowTeacherListItem(index, lblName3, lblSubjects3, lblPrice3, btShow3);
        }

        private void ShowTeacherListItem(int index, Label nameLabel, Label subjectLabel, Label priceLabel, Button btn)
        {
            if (index >= 0 && index < Teachers.Count)
            {
                var teacher = Teachers[index];
                nameLabel.Text = teacher.FirstName +" " + teacher.LastName;
                subjectLabel.Text = SubjectToString(teacher.Subjects);
                priceLabel.Text = teacher.HourlyPrice.ToString();
                nameLabel.Visible = true;
                subjectLabel.Visible = true;
                priceLabel.Visible = true;
                btn.Visible = true;
                btNext.Enabled = false;
            }
            else
            {
                nameLabel.Visible = false;
                subjectLabel.Visible = false;
                priceLabel.Visible = false;
                btn.Visible = false;
            }

        }

        private void rbSubject_CheckedChanged(object sender, EventArgs e)
        {
            lboxFilter.Visible = true;
            tbMin.Visible = false;
            tbMax.Visible = false;
            FilterButton.Visible = false;
            lboxFilter.DataSource = Subjects;
            lboxFilter.DisplayMember = "SubjectName";
            lboxFilter.ValueMember = "Id";



        }

        private void rbPrice_CheckedChanged(object sender, EventArgs e)
        {
            lboxFilter.Visible = false;
            tbMin.Visible = true;
            tbMax.Visible = true;
            FilterButton.Visible = true;
        }

        private void rbLocation_CheckedChanged(object sender, EventArgs e)
        {
            lboxFilter.Visible = true;
            tbMin.Visible = false;
            tbMax.Visible = false;
            FilterButton.Visible = false;
            var list = Teachers.Select(t => t.PostalCode).Distinct().ToList();
            lboxFilter.DataSource = list;
            lboxFilter.DisplayMember = "PostalCode";

        }



        private void lboxFilter_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (rbLocation.Checked == true)
            {
                int pc = (int)lboxFilter.SelectedItem;
                Teachers = new BindingList<Teacher>(ServiceClient.FilterByPostalCode(pc));

            }
            else if (rbSubject.Checked == true)
            {
                Subject currentSubject = (Subject)lboxFilter.SelectedItem;
                Teachers = new BindingList<Teacher>(ServiceClient.FilterBySubject(currentSubject)); 
            }
            ShowPage(0);
        }

        private void FilterButton_Click(object sender, EventArgs e)
        {
            int min;
            int max;
            if (!int.TryParse(tbMin.Text, out min) || min < 0)
            {
                MessageBox.Show("Min price can not be smaller than 0");
            }
            else if (!int.TryParse(tbMax.Text, out max))
            {
                MessageBox.Show("Max price is not a number");
            }
            else if (min > max)
            {
                MessageBox.Show(" Min should not be bigger then max");
            }
            else
            {
                try
                {
                    Teachers = new BindingList<Teacher>(ServiceClient.FilterByPrice(min, max));
                } 
                catch (FaultException<UserFault> ex)
                {
                    MessageBox.Show(ex.Detail.Details, ex.Detail.Issue, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                ShowPage(0);
            }
        }

        private void RstButton_Click(object sender, EventArgs e)
        {
            if(rbSubject.Checked == true || rbPrice.Checked == true || rbLocation.Checked == true)
            {
                rbLocation.Checked = false;
                rbPrice.Checked = false;
                rbSubject.Checked = false;
            }

            Teachers = new BindingList<Teacher>(ServiceClient.GetTeacherList());
            ShowPage(0);
        }
    }
}
