using MvcWebApp.Filters;
using MvcWebApp.TutorWorldServiceRef;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MvcWebApp.Controllers
{
    public class StudentController : Controller
    {
        private UserServiceClient UserService;

        protected override void Initialize(RequestContext requestContext)
        {
            base.Initialize(requestContext);
            UserService = new UserServiceClient();
            UserService.ClientCredentials.UserName.UserName = Session["Email"] as string;
            UserService.ClientCredentials.UserName.Password = Session["Password"] as string;
        }

        // GET: Student
        public ActionResult Index()
        {
            return View();
        }

        [WcfAuthorization]
        public ActionResult Details(int? id)
        {
            bool isItCurrentUser;

            Student studnet;
            if (id == null)
            {
                studnet = UserService.GetAuthenticatedStudent();
                isItCurrentUser = true;
            }
            else
            {
                studnet = UserService.FindById((int)id);
                isItCurrentUser = false;
            }
            ViewBag.IsItCurrentUser = isItCurrentUser;
            return View(studnet);
        }

        [WcfAuthorization(Roles = "Student")]
        public ActionResult Edit()
        {
            Student student = UserService.GetAuthenticatedStudent();
            return View(student);
        }

        [WcfAuthorization(Roles = "Student")]
        [HttpPost]
        public ActionResult Edit([Bind(Include = "Id,FirstName,LastName,Phonenumber,Bio")]Student student)
        {
            try
            {
                UserService.Update(student);
            }
            catch (FaultException<UserFault> e)
            {
                TempData["Error"] = e.Detail.Details;
                return RedirectToAction("Edit");
            }
            TempData["Success"] = "Profile updated";
            return RedirectToAction("Details");
        }

    }
}