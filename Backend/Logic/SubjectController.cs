using DatabaseLayer;
using ModelLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
   public class SubjectController
    {
        DBContext db = new DBContext();
        public void Add(Subject subject)
        {
            if (subject == null)
            {
                throw new SubjectException("Subject is null");
            }
            Teacher Teachr = db.Teachers.Include("Subjects").Where(X => X.Id == subject.TeacherId).FirstOrDefault();
            if (Teachr == null)
            {
                throw new SubjectException("Teacher is null");
            }
            if (Teachr.Subjects.Count >= 5)
            {
                throw new SubjectException("Illegal amount of subjects");
            }
            foreach (Subject subjct in Teachr.Subjects)
            {
                if(subjct.SubjectName == subject.SubjectName)
                {
                    throw new SubjectException("Already teaching this subject, no duplicates allowed");
                }
            }
            Teachr.Subjects.Add(subject);
            subject.Teacher = Teachr;
            db.SaveChanges();
        }

        public void Remove(Subject subject)
        {
            if (subject == null)
            {
                throw new SubjectException("Subject is null");
            }
            db.Subjects.Attach(subject);
            db.Subjects.Remove(subject);
            db.SaveChanges();
        }

        public List<Subject> FindByTeacher(Teacher teacher)
        {
            return db.Subjects.Where(X => X.TeacherId == teacher.Id).ToList();
            
        }

        public IEnumerable<Subject> GetDistinctSubjects()
        {
            List<Subject> subjects = db.Subjects.ToList();
            return new HashSet<Subject>(subjects);
        }

       
    }
}
