using ModelLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatabaseLayer;

namespace Logic
{
   public class SkillController
    {
        DBContext db = new DBContext();
        public Skill Add(Skill skill, Subject subject)
        {
            if (skill == null || subject == null)
            {
                throw new ArgumentNullException();
            }
            subject = db.Subjects.Find(subject.Id);
            if (subject == null)
            {
                throw new SkillException("Subject is null");
            }
            if(subject.Skill.Count >= 10)
            {
                throw new SkillException("Amount of skills is illegal");
            }
            foreach (Skill skll in subject.Skill)
            {
                if(skll.SkillName == skill.SkillName)
                {
                    throw new SkillException("No duplicates allowed");
                }
            }
            subject.Skill.Add(skill);
            skill.Subject = subject;
            skill.SubjectId = subject.Id;
            db.SaveChanges();

            return skill;
        }

        public void Remove(Skill skill, Subject subject)
        {
            if (skill == null || subject == null)
            {
                throw new ArgumentNullException();
            }
            subject = db.Subjects.Find(subject.Id);
            if (subject == null)
            {
                throw new SkillException("Subject is null");
            }
            subject.Skill.Remove(skill);
            skill = db.Skills.Find(skill.Id);
            db.Skills.Remove(skill);
            db.SaveChanges();
        }
    }
}
