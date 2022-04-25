using MvcWebApp.Filters;
using MvcWebApp.Models;
using MvcWebApp.Services;
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
    public class TeacherController : Controller
    {
        private UserServiceClient UserService;
        private WeekCalculator WeekCalc = new WeekCalculator();

        public TeacherController() : base()
        {
            
        }

        protected override void Initialize(RequestContext requestContext)
        {
            base.Initialize(requestContext);
            UserService = new UserServiceClient();
            UserService.ClientCredentials.UserName.UserName = Session["Email"] as string;
            UserService.ClientCredentials.UserName.Password = Session["Password"] as string;
        }

        // GET: Teacher
        [WcfAuthorization]
        public ActionResult Index()
        {
            List<Teacher> teachers = UserService.GetTeacherList();
            return View(teachers);
        }

        [WcfAuthorization]
        public ActionResult Details(int? id, int? week)
        {
            Teacher teacher;
            if (id == null)
            {
                teacher = UserService.GetAuthenticatedTeacher();
            }
            else
            {
                teacher = UserService.FindTeacherById((int)id);
            }
            
            var currentUser = UserService.GetAuthenticatedTeacher();
            ViewBag.AuthTeacher = currentUser;

            var selectedWeek = week != null ? (int)week: WeekCalc.GetCurrentWeek();

            var workdays = new WorkDayViewModel[7];
            int i = 0;
            foreach (DayOfWeek day in Enum.GetValues(typeof(DayOfWeek))) {
                workdays[i++] = new WorkDayViewModel()
                {
                    DayOfWeek = day,
                    Date = WeekCalc.GetDateFromWeek(selectedWeek, day),
                    TimeSlots = teacher.WorkDays 
                                .Find(wd => wd.Day == day) // find the workday for 'this' day
                                ?.TimeSlots // get timeslots of that day
                                //?.Where(ts => 
                                 //   ts.BookSessions == null ||
                                  //  ts.BookSessions.Count(bs => WeekCalc.GetWeekFromDate(bs.Date) == selectedWeek) == 0) // Count how many sessions are there for this week
                                ?.Select(ts => new TimeSlotViewModel()  // change timeslots to view models and set exact date for selected week
                                {
                                    SlotId = ts.Id,
                                    DateTime = WeekCalc.GetDateTimeFromWeek(selectedWeek, day, ts.StartTime),
                                    BookSession = ts?.BookSessions.Find(bs => WeekCalc.GetWeekFromDate(bs.Date) == selectedWeek)
                                })
                                ?.ToList()
                };
            }
            ViewBag.Week = selectedWeek;
            ViewBag.WorkDays = workdays;
            return View(teacher);
        }

        [WcfAuthorization]
        public ActionResult Edit()
        {
            var teacher = UserService.GetAuthenticatedTeacher();
            if (teacher == null)
            {
                TempData["Error"] = "You are not a teacher";
                return RedirectToAction("Index", "Home");
            }
            return View(teacher);
        }
        
        [WcfAuthorization]
        [HttpPost]
        public ActionResult Edit([Bind(Include = "Id,FirstName,LastName,Phonenumber,EducationLevel,HourlyPrice,PostalCode,Bio")]Teacher teacher)
        {
            try
            {
                UserService.Update(teacher);
            } 
            catch (FaultException<UserFault> e)
            {
                TempData["Error"] = e.Detail.Details;
                return RedirectToAction("Edit");
            }
            TempData["Success"] = "Profile updated";
            return RedirectToAction("Details", new { id = teacher.Id });
        }
    }
}