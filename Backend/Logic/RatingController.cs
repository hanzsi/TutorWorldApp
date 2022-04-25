using DatabaseLayer;
using ModelLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class RatingController
    {
        private DBContext Db = new DBContext();

        public Rating Create(Rating rating)
        {
            if (rating.Subject == null || rating.Student == null)
            {
                throw new ArgumentNullException("Rating subject and student must not be null ");
            }
            if (rating.Score < 1 || rating.Score > 5)
            {
                throw new Exception("Rating score must be between 1 and 5");
            }

            rating.Subject = Db.Subjects.Find(rating.Subject.Id);
            rating.Student = Db.Students.Find(rating.Student.Id);

            Db.Ratings.Add(rating);
            Db.SaveChanges();
            return rating;
        }   

        public List<Rating> FindBySubject(Subject subject)
        {
            return Db.Ratings.Where(r => r.SubjectId == subject.Id).ToList();
        }
    }
}
