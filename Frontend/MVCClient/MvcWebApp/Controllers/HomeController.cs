using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcWebApp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            if (Session["User"] == null)
            {
                return RedirectToAction("Index", "Auth");
            }


            if (Session["User"] is MvcWebApp.TutorWorldServiceRef.Teacher)
            {
                return RedirectToAction("Details", "Teacher");
            }

            if (Session["User"] is MvcWebApp.TutorWorldServiceRef.Student)
            {
                return RedirectToAction("Index", "Teacher");
            }
            return View();
        }
    }
}