using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ModelLayer;
using DatabaseLayer;

namespace Logic.Tests
{
    [TestClass]
    public class TeacherControllerTests
    {
        [TestMethod]
        [ExpectedException(typeof(UserCreationException))]
        public void TestUpdateWithNoFirstName()
        {
            Teacher t = MakeTeacher();
            t.FirstName = "";
            TeacherController ctr = new TeacherController();

            ctr.Update(t);
        }

        [TestMethod]
        [ExpectedException(typeof(UserCreationException))]
        public void TestUpdateWithNoBio()
        {
            Teacher t = MakeTeacher();
            t.Bio = "";
            TeacherController ctr = new TeacherController();

           ctr.Update(t);
        }

        [TestMethod]
        public void TestUpdateWithValidData()
        {
            var teacher = MakeTeacher();
            DBContext context = new DBContext();
            context.Users.Add(teacher);
            context.SaveChanges();
            var ctr = new TeacherController();

            try
            {
                ctr.Update(teacher);
                if (teacher.Id == 0)
                {
                    Assert.Fail("not saved");
                }
            }
            catch (Exception e)
            {
                Assert.Fail("Updating teacher profile failed: " + e.Message);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(UserCreationException))]
        public void TestUpdateWithInvalidPhoneNumber()
        {
            var teacher = MakeTeacher();
            teacher.Phonenumber = "696969696969696969";
            var ctr = new TeacherController();

            ctr.Update(teacher);
        }

        [TestMethod]
        [ExpectedException(typeof(UserCreationException))]
        public void TestUpdateWithInvalidZipCode()
        {
            var teacher = MakeTeacher();
            teacher.PostalCode = -5000;
            var ctr = new TeacherController();

            ctr.Update(teacher);
        }

        [TestMethod]
        [ExpectedException(typeof(UserCreationException))]
        public void TestUpdateWithInvalidPrice()
        {
            var teacher = MakeTeacher();
            teacher.HourlyPrice = -5000;
            var ctr = new TeacherController();

            ctr.Update(teacher);
        }

        [TestMethod]
        [ExpectedException(typeof(UserCreationException))]
        public void TestUpdateWithInvalidEducationLevel()
        {
            var teacher = MakeTeacher();
            teacher.EducationLevel = "I finished UCN, is it valid?";
            var ctr = new TeacherController();

            ctr.Update(teacher);
        }

        private Teacher MakeTeacher()
        {
            return new Teacher
            {
                FirstName = "FirstName",
                LastName = "LastName",
                Email = "test@tutorworld.com",
                Password = "AVeryGoodSecureStrongSecureUltimatePassword",
                Phonenumber = "22223585",
                Bio = "Alright. This is my bio. I'm a nice person(I'm not Adam). I want to learn so plz gimme tutor. For fuck's sake this needs to be 154 characters. I am already regretting this limit..... Where am I supposed to get this text...",
                PostalCode = 9210,
                HourlyPrice = 150,
                EducationLevel = "High School"
            };
        }
    }
}
