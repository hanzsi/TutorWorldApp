using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DatabaseLayer;
using ModelLayer;

namespace Logic.Tests
{
   
    [TestClass]
    public class BookSessionControllerTests
    {
        private DBContext db = new DBContext();
        private TimeSlot TimeSlot;
        private Subject Subject;
        private Student Student;

        [TestInitialize]
        public void CreateDependencies()
        {
            Subject = new Subject() { SubjectName = "Programming" };
            Student = new Student() { FirstName = "Student name", LastName = "Student lastname", Password = "Pass", Email = "student@s.com" };
            var t = new Teacher()
            {
                Email = "Teacher@teacher.com",
                FirstName = "First Name",
                LastName = "Last Name",
                Password = "Pass",
                Subjects = new List<Subject> { Subject }
            };
            Subject.Teacher = t;
            var wd = new WorkDay() { Day = DayOfWeek.Wednesday, Teacher = t };
            TimeSlot = new TimeSlot() { StartTime = DateTime.Now, WorkDay = wd };
            db.Timeslots.Add(TimeSlot);
            db.Students.Add(Student);
            db.SaveChanges();
        }

        [TestCleanup]
        public void RemoveDependencies()
        {
            db.Timeslots.Remove(TimeSlot);
            db.Subjects.Remove(Subject);
            db.Students.Remove(Student);
            db.SaveChanges();
        }

        [TestMethod]
        [ExpectedException(typeof(BookSessionException))]
        public void TestCreateWithNoSlotSelected()
        {
            var session = new BookSession() { Date = DateTime.Now, Subject = Subject, Student = Student };
            var ctr = new BookSessionController();

            ctr.Create(session);

        }

        [TestMethod]
        [ExpectedException(typeof(BookSessionException))]
        public void TestCreateWithNullTopic()
        {
            var session = new BookSession() { Date = DateTime.Now, Subject = Subject, Student = Student, Slot = TimeSlot, Topic = null };
            var ctr = new BookSessionController();

            ctr.Create(session);

        }

        [TestMethod]
        [ExpectedException(typeof(BookSessionException))]
        public void TestCreateWithEmptyTopic()
        {
            var session = new BookSession() { Date = DateTime.Now, Subject = Subject, Student = Student, Slot = TimeSlot, Topic = "" };
            var ctr = new BookSessionController();

            ctr.Create(session);

        }


        [TestMethod]
        [ExpectedException(typeof(BookSessionException))]
        public void TestCreateWithUnrelatedSubject()
        {
            var session = new BookSession()
            {
                Date = DateTime.Now,
                Subject = new Subject() { SubjectName = "Not real" },
                Student = Student,
                Slot = TimeSlot,
                Topic = "Topic"
            };
            var ctr = new BookSessionController();

            ctr.Create(session);
        }

        [TestMethod]
        public void TestCreateWithBookedSlot()
        {
            var initialSession = new BookSession()
            {
                Date = DateTime.Now.Date,
                Subject_Id = Subject.Id,
                Student_Id = Student.Id,
                Student = Student,
                Slot_Id = TimeSlot.Id,
                Slot = TimeSlot,
                Topic = "Topic"
            };
            db.BookSessions.Add(initialSession);
            db.SaveChanges();
            var session = new BookSession()
            {
                Date = DateTime.Now.Date,
                Subject_Id = Subject.Id,
                Student_Id = Student.Id,
                Student = Student,
                Slot_Id = TimeSlot.Id,
                Slot = TimeSlot,
                Topic = "Topic"
            };
            var ctr = new BookSessionController();


            try
            {
                ctr.Create(session);
                Assert.Fail("BookSessionException not thrown");
            } 
            catch (BookSessionException ignored) { }

            db.BookSessions.Remove(initialSession);
            db.SaveChanges();
        }
    }
}
