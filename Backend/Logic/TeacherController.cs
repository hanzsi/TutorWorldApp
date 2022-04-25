using DatabaseLayer;
using ModelLayer;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Logic
{
    public class TeacherController
    {
        private static string[] EducationLevels = new string[] { "high school", "college", "bachelors", "masters", "phd" };
        private DBContext db = new DBContext();
        private RegHash hasher = new RegHash();
        List<Subject> Subjects = new List<Subject>();

        public void Update(Teacher teacher)
        {
            UserProfileValidator validator = new UserProfileValidator();
            validator.Validate(teacher);

            if (!EducationLevels.Contains(teacher.EducationLevel.ToLower()))
            {
                throw new UserCreationException("Invalid education level, must be in: " + string.Join(",", EducationLevels), teacher);
            }
            if (teacher.HourlyPrice <= 0)
            {
                throw new UserCreationException("Teacher hourly price must be greather than 0", teacher);
            }
            if (teacher.Bio == null || teacher.Bio == "")
            {
                throw new UserCreationException("Teacher bio cannot be empty", teacher);
            }

            if (teacher.Bio.Length < 154)
            {
                throw new UserCreationException("Teacher bio is too short, 154 characters minimum", teacher);
            }

            if (teacher.PostalCode < 1000)
            {
                throw new UserCreationException("Teacher postal code is not valid", teacher);
            }

            var saved = db.Teachers.Where(t => t.Id == teacher.Id).First();
            saved.Bio = teacher.Bio;
            saved.EducationLevel = teacher.EducationLevel;
            saved.Phonenumber = teacher.Phonenumber;
            saved.PostalCode = teacher.PostalCode;
            saved.HourlyPrice = teacher.HourlyPrice;
            saved.FirstName = teacher.FirstName;
            saved.LastName = teacher.LastName;
            db.SaveChanges();
        }

        public Teacher FindByEmail(string email)
        {
            return db.Teachers
                  .Include("Subjects")
                .Include("Subjects.Skill")
                .Include("Subjects.Ratings")
                .Include("WorkDays.TimeSlots")
                .Include("WorkDays.TimeSlots.BookSessions")
                .Include("WorkDays.TimeSlots.BookSessions.Student")
                .Where(s => s.Email == email).FirstOrDefault();
        }

        public Teacher Find(string email, string password)
        {
            string hash = hasher.RegEncrypt(password);

            return db.Teachers
                .Include("Subjects")
                
                .Include("Subjects.Skill")
                .Include("Subjects.Ratings")
                .Include("WorkDays.TimeSlots")
                .Where(t => t.Email == email && t.Password == hash)
                .FirstOrDefault<Teacher>();
        }

        public Teacher FindById(int id)
        {
            return db.Teachers
                .Include("Subjects")
                .Include("Subjects.Skill")
                .Include("Subjects.Ratings")
                .Include("WorkDays.TimeSlots")
                .Include("WorkDays.TimeSlots.BookSessions")
                .Include("WorkDays.TimeSlots.BookSessions.Student")
                //.Include("WorkDays.TimeSlots.BookSessions.Subject")
                .Where(t => t.Id == id)
                .FirstOrDefault();
        }
        
        public List<Teacher> GetTeacherList()
        {
            List<Teacher> lTeach = db.Teachers.Include("Subjects")
                .Include("Subjects.Skill")
                .Include("Subjects.Ratings")
                .Include("WorkDays.TimeSlots").ToList();

            return lTeach;
        }

        public List<Teacher> FilterBySubject(Subject subject)
        {
            List<Teacher> lTeach = db.Teachers.Include("Subjects")
                .Include("Subjects.Skill")
                .Include("Subjects.Ratings")
                .Include("WorkDays.TimeSlots").ToList();
            return lTeach.Where(x => x.Subjects.Contains(subject)).ToList();
        }

        public List<Teacher> FilterByPrice(int min, int max)
        {
            if (min < 0)
            {
                throw new TeacherException("Minimum price must be a positive number");
            }
            if(min > max)
            {
                throw new TeacherException("Minimum cannot be bigger then maximum");
            }
            return db.Teachers.Where(X => X.HourlyPrice >= min && X.HourlyPrice <= max).ToList();
        }

        public List<Teacher> FilterByPostalCode(int pc)
        {
            if (pc < 1000 || pc > 9999) // check if 4 digits
            {
                throw new TeacherException("Postal code is not valid");
            }
            return db.Teachers.Where(t => t.PostalCode == pc).ToList();
        }

    }
}
