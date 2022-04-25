using DatabaseLayer;
using ModelLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class StudentController
    {
        private DBContext context = new DBContext();
        private RegHash hasher = new RegHash();

        public void Update(Student student)
        {
            UserProfileValidator validator = new UserProfileValidator();
            validator.Validate(student);

            var s = context.Students.Find(student.Id);
            s.Bio = student.Bio;
            s.FirstName = student.FirstName;
            s.LastName = student.LastName;
            s.Phonenumber = student.Phonenumber;
            context.SaveChanges();
        }

        public Student Find(string email, string password)
        {
            string hash = hasher.RegEncrypt(password);

            return context.Students.Include("BookSessions").Include("BookSessions.Subject").Where(s => s.Email == email && s.Password == hash).FirstOrDefault();
        }

        public Student FindByEmail(string email)
        {
            return context.Students.Where(s => s.Email == email).FirstOrDefault();
        }

        public Student FindById(int id)
        {
            return context.Students.Find(id);
        }
    }
}
