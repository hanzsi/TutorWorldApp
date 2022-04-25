using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Client.TotorWorldService;

namespace Client.Components
{
    public partial class ProfileSubjectItem : UserControl
    {

        private Subject _subject;

        public Subject Subject
        {
            get { return _subject; }
            set
            {
                _subject = value;
                UpdateUI();
            }
        }

        public ProfileSubjectItem()
        {
            InitializeComponent();
        }

        public void UpdateUI()
        {
            SubjectLbl.Text = Subject.SubjectName;
            if (Subject.Ratings != null && Subject.Ratings.Count != 0)
            {
                var sum = Subject.Ratings.Sum(r => r.Score);
                var avg = sum / Subject.Ratings.Count;
                RatingLbl.Text = string.Format("{0:0.0}",  avg);
                RatingLbl.Visible = true;
            } 
            else
            {
                RatingLbl.Visible = false;
            }
            if (Subject.Skill != null)
            {
                var skillString = string.Join(", ", Subject.Skill.Select(s => s.SkillName));
                SkillsLbl.Text = skillString;
                SkillsToTip.ToolTipTitle = skillString;

            }
            
        }
    }
}
