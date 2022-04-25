using MvcWebApp.Filters;
using MvcWebApp.Models;
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
    [WcfAuthorization(Roles = "Teacher")]
    public class TimeTableController : Controller
    {
        private UserServiceClient UserService;

        protected override void Initialize(RequestContext requestContext)
        {
            base.Initialize(requestContext);
            UserService = new UserServiceClient();
            UserService.ClientCredentials.UserName.UserName = Session["Email"] as string;
            UserService.ClientCredentials.UserName.Password = Session["Password"] as string;
        }

        // GET: TimeTable
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }
        
        [HttpPost]
        public ActionResult Create(List<SessionViewModel> sessions)
        {
           // This code.. it is garbage. 
           // But since this project is not about clients, its ok ;)
            var workdays = sessions
                .Select(s => s.DayOfWeek)
                .Distinct()
                .Select(d => new WorkDay() { Day = (DayOfWeek)Enum.Parse(typeof(DayOfWeek), d), TimeSlots = new List<TimeSlot>() })
                .OrderBy(wd => wd.Day)
                .ToList();

            sessions.ForEach(s =>
            {
                var wd = workdays.Find(w => w.Day.ToString() == s.DayOfWeek);
                wd.TimeSlots.Add(new TimeSlot() { WorkDay = wd, StartTime = s.Time });
            });
            try
            {
                workdays.ForEach(wd => UserService.CreateWorkDay(wd));
                TempData["Success"] = "Timetable updated successfully";
                var teacher = UserService.GetAuthenticatedTeacher();
                return RedirectToAction("Details", "Teacher", new { id = teacher.Id });
            }
           catch(Exception e)
            {
                TempData["Error"] = e.Message;
                return RedirectToAction("Create");
            }
        }

  
    }
}