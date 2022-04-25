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
    public partial class SkillsetCreation : Form
    {
        private UserServiceClient USC;
        private Teacher Teacher;
        private BindingList<string> LB1Items;
        private BindingList<Subject> LB2Items;
        private Subject CurrntSubject;
        private TextBox[] SkillBox;
        public SkillsetCreation(UserServiceClient USC, Teacher teacher)
        {
            this.Teacher = teacher;
            this.USC = USC;
            InitializeComponent();

            LB1Items = new BindingList<string>();
            LB2Items = new BindingList<Subject>(Teacher.Subjects);

            SkillBox = new TextBox[] 
            {
                textBox1, textBox2, textBox3, textBox4, textBox5, textBox6,
                textBox7, textBox8, textBox9, textBox10
            };

        }

        private void SkillsetCreation_Load(object sender, EventArgs e)
        {
            List<string> tempList = new List<string>();
            LB1Items.Add("Math");
            LB1Items.Add("Computer Science");
            LB1Items.Add("Audio/Visual");
            LB1Items.Add("Physics");
            LB1Items.Add("Calculus");
            LB1Items.Add("Obscure 1992 Friends TV show references");
            foreach (string name in LB1Items)
            {
                foreach (Subject subject in LB2Items)
                {
                    if(name == subject.SubjectName)
                    {
                        tempList.Add(name);
                    }
                }
            }
            foreach (string name in tempList)
            {
                LB1Items.Remove(name);
            }



            listBox1.DataSource = LB1Items;

            listBox2.DataSource = LB2Items;
            listBox2.ValueMember = "Id";
            listBox2.DisplayMember = "SubjectName";
            listBox2.ClearSelected();
            foreach (TextBox box in SkillBox)
            {
                box.Text = "";
                box.Enabled = true;
            }
        }

        private void UpdateSkillBoxes()
        {
            if(CurrntSubject == null || CurrntSubject.Skill == null ||  CurrntSubject.Skill.Count == 0)
            {
                foreach (TextBox box in SkillBox)
                {
                    box.Text = "";
                    box.Enabled = true;
                }   
            }
            else
            {
                for (int i = 0; i < CurrntSubject.Skill.Count; i++)
                {

                    SkillBox[i].Text = CurrntSubject.Skill[i].SkillName;
                    SkillBox[i].Enabled = false;
                }
            }      
        }

        private void SubjectChecker()
        {
            if (Teacher.Subjects.Count > 5 )
            {
                MessageBox.Show("Get off your high horse genious");
                Teacher.Subjects.Remove(CurrntSubject);
            }
        }

        private void listBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {

            string selected = (string)listBox1.SelectedItem;
            label2.Text = selected;
            try
            {
                CurrntSubject = USC.AddSubject(new Subject() { SubjectName = selected, Teacher = Teacher, TeacherId = Teacher.Id, Skill = new List<Skill>() });
                LB1Items.Remove(selected);
                LB2Items.Add(CurrntSubject);
                UpdateSkillBoxes();
            }
            catch (FaultException<SubjectError> ex)
            {
                MessageBox.Show(ex.Detail.Details, ex.Detail.Issue, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            Subject selected = (Subject)listBox2.SelectedItem;
            CurrntSubject = selected;
            if (selected == null)
            {
                label2.Text = "________";
            }
            else
            {
                label2.Text = selected.SubjectName;
                UpdateSkillBoxes();
            }
            
            
        }

        private void listBox2_DoubleClick(object sender, EventArgs e)
        {
            Subject selected = (Subject)listBox2.SelectedItem;
            CurrntSubject = null;
            label2.Text = "________";
            LB1Items.Add(selected.SubjectName);
            LB2Items.Remove(selected);
            try
            {
                USC.RemoveSubject(selected);
                UpdateSkillBoxes();
            }
            catch (FaultException<SubjectError> ex)
            {
                MessageBox.Show(ex.Detail.Details, ex.Detail.Issue, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DeleteSkillButton_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            int index = (int)btn.Tag;

            if (CurrntSubject == null)
            {
                MessageBox.Show("Please select a subject from the list");
            }
            else if (SkillBox[index].Text == "")
            {
                MessageBox.Show("The field is empty, cannot delete");
            }
            else
            {

                Skill currntSkill = null;
                foreach (Skill skill in CurrntSubject.Skill)
                {
                    if (skill.SkillName == SkillBox[index].Text)
                    {
                        currntSkill = skill;
                    }
                }
                SkillBox[index].Text = "";
                SkillBox[index].Enabled = true;
                CurrntSubject.Skill.Remove(currntSkill);
                USC.RemoveSkillset(currntSkill, CurrntSubject);

            }
        }

        private void AddSkillButton_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            int index = (int)btn.Tag;

            if (CurrntSubject == null)
            {
                MessageBox.Show("Please select a subject from the list");
            }
            else if (string.IsNullOrEmpty(SkillBox[index].Text))
            {
                MessageBox.Show("Skill cannot be empty");
            }
            else if (SkillBox[index].Enabled == false)
            {
                MessageBox.Show("Skill already added");
            }
            else
            {
                
                MessageBox.Show("You added:" + SkillBox[index].Text);
                SkillBox[index].Enabled = false;
                Skill skill = new Skill();
                skill.SkillName = SkillBox[index].Text;
                skill.Subject = CurrntSubject;
                if (CurrntSubject.Skill == null)
                {
                    CurrntSubject.Skill = new List<Skill>();
                }
                skill = USC.AddSkillset(skill, CurrntSubject);
                CurrntSubject.Skill.Add(skill);
            }
            
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
