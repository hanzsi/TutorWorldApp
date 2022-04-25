using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Logic;

namespace Logic.Tests
{

    [TestClass]
    public class HashTest
    {
        RegHash Rgh = new Logic.RegHash();
        [TestMethod]

        public void HasHashed()
        {
            string password1 = "text";
            string hashedPw = Rgh.RegEncrypt(password1);
            Assert.AreNotEqual(password1, hashedPw);

        }
        /// <summary>
        /// arrange-paraméterek megadása amivel le fog futni a metódus. mindig ez az első része a tesztnek
        /// act-metódus meghívása
        /// assert-mit várunk a programtól (public  void fasz)
        /// feljebb kerülhet vagy legalul vagy legfelül       
        /// </summary>
        [TestMethod]
        public void PasswordDontMatch()
        {
            string password1 = "alma";
            string password2 = "korte";
            string hashedpass1 = Rgh.RegEncrypt(password1);
            string hashedpass2 = Rgh.RegEncrypt(password2);
            Assert.AreNotEqual(hashedpass1, hashedpass2);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void PasswordIsNull()
        {
            string Password = null;

            string HashedPw = Rgh.RegEncrypt(Password);

            Assert.IsNull(HashedPw);

        }

        [TestMethod]
        public void TestMatchesWithCorrectInput()
        {
            var password = "dog";
            var hashed = Rgh.RegEncrypt(password);

            bool result = Rgh.Matches(password, hashed);

            Assert.IsTrue(result);

        }

        [TestMethod]
        public void TestMatchesWithIncorrecthHash()
        {
            var password = "dog";
            var hashed = "dog";

            bool result = Rgh.Matches(password, hashed);

            Assert.IsFalse(result);
        }


    }
}
