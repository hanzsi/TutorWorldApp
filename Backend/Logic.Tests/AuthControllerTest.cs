using DatabaseLayer;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ModelLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Tests
{
    [TestClass]
    public class AuthControllerTest
    {
        private DBContext context = new DBContext();

        [TestMethod]
        public void TestValidateWithValidDetails()
        {
            string password = "AVerySecurePassword";
            string hash = new RegHash().RegEncrypt(password);
            string email = "example@example.com";
            var user = new Teacher() { Email = email, Password = hash };
            context.Users.Add(user);
            context.SaveChanges();
            AuthController authCtr = new AuthController();

            try
            {
                authCtr.Validate(email, password);
            }
            catch (Exception e)
            {
                Assert.Fail("Unexpected exception was thrown: " + e.Message);
            }
            context.Users.Remove(user);
            context.SaveChanges();
        }

        [TestMethod]
        [ExpectedException(typeof(AuthException))]
        public void TestValidateWithNullEmail()
        {
            AuthController authCtr = new AuthController();

            authCtr.Validate(null, "AVeryGoodPassword");
        }

        [TestMethod]
        [ExpectedException(typeof(AuthException))]
        public void TestValidateWithNullPassword()
        {
            AuthController authCtr = new AuthController();

            authCtr.Validate("example@example.com", null);
        }

        [TestMethod]
        [ExpectedException(typeof(AuthException))]
        public void TestValidateWithWrongPassword()
        {
            string password = "AVerySecurePassword";
            string email = "example@example.com";
            var user = new Teacher() { Email = email, Password = password };
            context.Users.Add(user);
            context.SaveChanges();
            AuthController authCtr = new AuthController();


            authCtr.Validate(email, password + "WRONG");
            
            context.Users.Remove(user);
            context.SaveChanges();
        }

        [TestMethod]
        [ExpectedException(typeof(AuthException))]
        public void TestRegisterWithNoEmail()
        {
            var input = "";
            AuthController ctr = new AuthController();

            ctr.Register(input, "Random password", false);
        }

        [TestMethod]
        [ExpectedException(typeof(AuthException))]
        public void TestRegisterWithInvalidEmail()
        {
            var input = "oawegjseroigjesrgerg@w.c@!@$";
            AuthController ctr = new AuthController();

            ctr.Register(input, "Whatever this is ", true);
        }

        [TestMethod]
        public void TestRegisterWithValidEmail()
        {
            var input = "example@example.com";
            AuthController ctr = new AuthController();

            try
            {
                ctr.Register(input, "ASecurePassword", false);
            }
            catch (UserCreationException e)
            {
                Assert.Fail("Creation with valid email failed");
            }
        }

        [TestMethod]
        [ExpectedException(typeof(AuthException))]
        public void TestRegisterWithNoPassword()
        {
            var email = "test@gmail.com";
            var password = "";
            AuthController ctr = new AuthController();

            ctr.Register(email, password, true);
        }

        [TestMethod]
        [ExpectedException(typeof(AuthException))]
        public void TestRegisterWith5LetterPassword()
        {
            var email = "test@gmail.com";
            var password = "12345";
            AuthController ctr = new AuthController();

            ctr.Register(email, password, true);
        }

        [TestMethod]
        public void TestRegisterWithValidPassword()
        {
            var email = "example@example.com";
            var password = "AVeryGoodSecurePassword";
            AuthController ctr = new AuthController();

            try
            {
                ctr.Register(email, password, true);
            }
            catch (UserCreationException e)
            {
                Assert.Fail("Creation with valid password failed:" + e.Message);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(AuthException))]
        public void TestRegisterWithDuplicateEmail()
        {
            context.Users.Add(new UserProfile()
            {
                Email = "test@gmail.com",
                Password = "AVeryGoodSecurePassword",
                FirstName = "A",
                LastName = "A",
                Phonenumber = "A"
            });
            context.SaveChanges();
            AuthController ctr = new AuthController();

            var email = "test@gmail.com";
            var password = "AVeryGoodSecurePassword";


            ctr.Register(email, password, true);
        }

        [TestMethod]
        public void TestRegisterWithValidCredentials()
        {
            var email = "example@example.com";
            var password = "AVeryGoodSecurePassword";
            AuthController ctr = new AuthController();

            ctr.Register(email, password, false);

            var savedUser = context.Users.Where(u => u.Email == email).First();
            Assert.AreEqual(email, savedUser.Email);
        }

        [TestMethod]
        //ASSERT
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestWithNullEmail()
        {
            //ARRANGE
            string email = null;
            string password = "OMGWTFBBQ";
            AuthController ctr = new AuthController();
            //ACT
            ctr.Register(email, password, false);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestWithNullPassword()
        {
            //Arrange
            string email = "something69@gmail.com";
            string password = null;
            AuthController ctr = new AuthController();
            //ACT
            ctr.Register(email, password, false);
        }

        [TestCleanup]
        public void RemoveTestUser()
        {
            var user = context.Users.Where(u => u.Email == "example@example.com").FirstOrDefault();
            if (user != null)
            {
                context.Users.Remove(user);
                context.SaveChanges();
            }
        }

    }
}
