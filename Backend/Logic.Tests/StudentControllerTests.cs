using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ModelLayer;
using DatabaseLayer;

namespace Logic.Tests
{
    [TestClass]
    public class StudentControllerTests
    {
        [TestMethod]
        public void TestUpdateWithValidData()
        {
            var student = MakeStudent();
            DBContext context = new DBContext();
            context.Users.Add(student);
            context.SaveChanges();
            StudentController ctr = new StudentController();

            try
            {
                ctr.Update(student);
                if (student.Id == 0)
                {
                    Assert.Fail("not saved");
                }
            }
            catch (Exception e)
            {
                Assert.Fail("Updating student profile failed: " + e.Message);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(UserCreationException))]
        public void TestUpdateWithNoFirstName()
        {
            var student = MakeStudent();
            student.FirstName = "";
            StudentController ctr = new StudentController();

            ctr.Update(student);
        }

        [TestMethod]
        [ExpectedException(typeof(UserCreationException))]
        public void TestUpdateWithWrongPhonenumber()
        {
            var student = MakeStudent();
            student.Phonenumber = Convert.ToString(456546454852641);
            StudentController ctr = new StudentController();

            ctr.Update(student);
        }


        private Student MakeStudent()
        {
            return new Student
            {
                FirstName = "FirstName",
                LastName = "LastName",
                Email = "test@tutorworld.com",
                Password = "AVeryGoodSecureStrongSecureUltimatePassword",
                Phonenumber = "22223585",
                Bio = "Alright. This is my bio. I'm a nice person(I'm not Adam). I want to learn so plz gimme tutor. For fuck's sake this needs to be 154 characters. I am already regretting this limit..... Where am I supposed to get this text...",
            };
        }
    }
}
