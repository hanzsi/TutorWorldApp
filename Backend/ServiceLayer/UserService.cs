using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using ModelLayer;
using Logic;


namespace ServiceLayer
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]
    public class UserService : IUserService
    {
        private TeacherController teacherCtr = new TeacherController();
        private StudentController studentCtr = new StudentController();
        private WorkDayController workDayCtr = new WorkDayController();
        private BookSessionController sessionCtr = new BookSessionController();
        private SkillController skillCtr = new SkillController();
        private SubjectController subjectCtr = new SubjectController();

        public void CreateWorkDay(WorkDay workDay)
        {
            workDay.Teacher = GetAuthenticatedTeacher();
            workDayCtr.Create(workDay);
        }

        public Student GetAuthenticatedStudent()
        {
            var email = ServiceSecurityContext.Current.PrimaryIdentity.Name;
            return studentCtr.FindByEmail(email);
        }



        public Teacher FindTeacherById(int id)
        {
            return teacherCtr.FindById(id);
        }

        public Teacher GetAuthenticatedTeacher()
        {
            var email = ServiceSecurityContext.Current.PrimaryIdentity.Name;
            return teacherCtr.FindByEmail(email);
        }


        public void Update(UserProfile profile)
        {
            try
            {
                if (profile is Teacher)
                {
                    if (profile.Id != GetAuthenticatedTeacher()?.Id)
                    {
                        throw new FaultException<AuthException>(new AuthException("You are not allowed to execute this action"));
                    }
                    teacherCtr.Update((Teacher)profile);
                }
                else
                {
                    if (profile.Id != GetAuthenticatedStudent()?.Id)
                    {
                        throw new FaultException<AuthException>(new AuthException("You are not allowed to execute this action"));
                    }
                    studentCtr.Update((Student)profile);
                }
            }
            catch (UserCreationException e)
            {
                throw new FaultException<UserFault>(new UserFault()
                {
                    Issue = "Profile input error",
                    Details = e.Message
                });
            }
            catch (Exception e)
            {
                throw new FaultException<UserFault>(new UserFault { Issue = "Unknown error", Details = e.Message });
            }
        }



        public void Book(BookSession session)
        {
            try
            {
                session.Student = GetAuthenticatedStudent();
                sessionCtr.Create(session);
            }
            catch (BookSessionException e)
            {
                throw new FaultException("Session exception: " + e.Message);
            }
        }

        public void RemoveBookedSession(BookSession session)
        {
            sessionCtr.DeleteSession(session);
        }

        public Subject AddSubject(Subject subject)
        {
            try
            {
                subject.Teacher = GetAuthenticatedTeacher();
                subjectCtr.Add(subject);
                return subject;

            }

            catch (SubjectException Se)
            {
                {
                    throw new FaultException<SubjectError>(new SubjectError { Issue = "Unexpected error occured", Details = Se.Message });
                }
            }
        }

        public Skill AddSkillset(Skill skill, Subject subject)
        {
            try
            {
                subject.Teacher = GetAuthenticatedTeacher();
                skillCtr.Add(skill, subject);
                return skill;
            }

            catch (SkillException Sk)
            {
                {
                    throw new FaultException<SkillError>(new SkillError { Issue = "Unexpected error occured", Details = Sk.Message });
                }
            }
        }

        public void RemoveSkillset(Skill skill, Subject subject)
        {
            try
            {
                subject.Teacher = GetAuthenticatedTeacher();
                skillCtr.Remove(skill, subject);
            }

            catch (SkillException Sk)
            {
                {
                    throw new FaultException<SkillError>(new SkillError { Issue = "Unexpected error occured", Details = Sk.Message });
                }
            }
        }

        public void RemoveSubject(Subject subject)
        {

            try
            {
                subject.Teacher = GetAuthenticatedTeacher();
                subjectCtr.Remove(subject);
            }

            catch (SubjectException Se)
            {
                {
                    throw new FaultException<SubjectError>(new SubjectError { Issue = "Unexpected error occured", Details = Se.Message });
                }

            }
        }

        public IEnumerable<Subject> GetDistinctSubjets()
        {
            return subjectCtr.GetDistinctSubjects();
        }

        public List<Teacher> GetTeacherList()
        {
            return teacherCtr.GetTeacherList();
        }

        public Rating CreateRating(Rating rating)
        {
            var ratingCtr = new RatingController();
            try
            {
                rating.Student = GetAuthenticatedStudent();
                rating.Subject.Teacher = GetAuthenticatedTeacher();
                return ratingCtr.Create(rating);
            }
            catch (Exception e)
            {
                throw new FaultException("Can not create rating: " + e.Message);
            }
        }

        public List<Rating> GetRatingsBySubject(Subject subject)
        {
            return new RatingController().FindBySubject(subject);
        }

        public List<Teacher> FilterBySubject(Subject subject)
        {
            return teacherCtr.FilterBySubject(subject);
        }

        public List<Teacher> FilterByPrice(int min, int max)
        {
            try
            {
                return teacherCtr.FilterByPrice(min, max);
            }
            catch (TeacherException e)
            {
                throw new FaultException<UserFault>(new UserFault() { Issue = "Error filtering", Details = e.Message });
            }
        }

        public List<Teacher> FilterByPostalCode(int pc)
        {
            return teacherCtr.FilterByPostalCode(pc);
        }

        public Student FindById(int id)
        {
            return studentCtr.FindById(id);
        }
    }
}
