using MvcWebApp.Models;
using MvcWebApp.TutorWorldServiceRef;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Web;
using System.Web.Mvc;

namespace MvcWebApp.Controllers
{
    public class AuthController : Controller
    {
        private AuthServiceClient AuthClient = new AuthServiceClient();
        private UserServiceClient UserClient = new UserServiceClient();

        // GET: Auth
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string email, string password)
        {
            try
            {
                AuthClient.Login(email, password);
                LoginUser(email, password);
                TempData["Success"] = "Welcome back, " + ((UserProfile)Session["User"]).FirstName;
                return RedirectToAction("Index", "Home");
            }
            catch (FaultException<AuthFault> e)
            {
                TempData["Error"] = e.Detail.Message;
                
                return RedirectToAction("Index");
            }
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(AuthViewModel authVM)
        {
            if (authVM.Password != authVM.PasswordConfirm)
            {
                TempData["Error"] = "Passwords do not match";
            }
            else
            {
                try
                {
                    AuthClient.Register(authVM.Email, authVM.Password, authVM.IsTeacher);
                    LoginUser(authVM.Email, authVM.Password);
                    TempData["Success"] = "You succesfully registered. Welcome to Tutor World!";
                    return RedirectToAction("Index", "Home");
                }
                catch (FaultException<AuthFault> e)
                {
                    TempData["Error"] = e.Detail.Message;
                }
            }
           
            return RedirectToAction("Register");
        }

        private UserProfile LoginUser(string email, string password)
        {
            UserClient.ClientCredentials.UserName.UserName = email;
            UserClient.ClientCredentials.UserName.Password = password;
            UserProfile user = UserClient.GetAuthenticatedTeacher();
            if (user == null)
            {
                user = UserClient.GetAuthenticatedStudent();
            }
            Session["Email"] = email;
            Session["Password"] = password;
            Session["User"] = user;
            return user;
        }

        public ActionResult Logout()
        {
            Session["User"] = null;
            Session["Email"] = null;
            Session["Password"] = null;
            TempData["Success"] = "You have logged out!";
            return RedirectToAction("Index");
        }
    }
}