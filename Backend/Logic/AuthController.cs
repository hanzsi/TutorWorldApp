using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelLayer;
using DatabaseLayer;
using System.Text.RegularExpressions;

namespace Logic
{
    public class AuthController
    {
        private static string EmailRegex = @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$";
        private DBContext db = new DBContext();
        private RegHash hasher = new RegHash();

        public void Validate(string email, string password)
        {
            var user = db.Users.Where(u => u.Email == email).FirstOrDefault();
            if (user == null || !hasher.Matches(password, user.Password))
            {
                throw new AuthException("Email or password not found");
            }
        }

        public void Register(string email, string password, bool isTeacher)
        {
            if (email == null || password == null)
            {
                throw new ArgumentNullException("Email and password can not be null");
            }

            Regex regex = new Regex(EmailRegex, RegexOptions.IgnoreCase);
            if (email == null || !regex.IsMatch(email))
            {
                throw new AuthException("Email does not match format: example@example.com");
            }

            if (password == null || password.Length < 6)
            {
                throw new AuthException("Password is too short");
            }

            if (db.Users.Where(u => u.Email == email).FirstOrDefault() != null)
            {
                throw new AuthException("Email " + email + " is already taken");
            }

            string hash = hasher.RegEncrypt(password);
            UserProfile user = null;
            if (isTeacher)
            {
                user = new Teacher();
            }
            else
            {
                user = new Student();
            }
            user.Email = email;
            user.Password = hash;
            db.Users.Add(user);
            db.SaveChanges();
        }
    }
}
