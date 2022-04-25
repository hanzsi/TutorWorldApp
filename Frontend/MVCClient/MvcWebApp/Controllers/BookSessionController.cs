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
    [WcfAuthorization(Roles = "Student")]
    public class BookSessionController : Controller
    {
        private UserServiceClient UserService;
        private WeekCalculator WeekCalc = new WeekCalculator();

       


        protected override void Initialize(RequestContext requestContext)
        {
            base.Initialize(requestContext);
            UserService = new UserServiceClient();
            UserService.ClientCredentials.UserName.UserName = Session["Email"] as string;
            UserService.ClientCredentials.UserName.Password = Session["Password"] as string;
        }

        [HttpPost]
        public ActionResult Create(BookSessionViewModel vm)
        {
            var student = UserService.GetAuthenticatedStudent();
            var teacher = UserService.FindTeacherById(vm.TeacherId);
            var slot = teacher.WorkDays.SelectMany(wd => wd.TimeSlots).Where(s => s.Id == vm.SlotId).First();
            BookSession session = new BookSession()
            {
                Topic = vm.Topic,
                Slot = slot,
                Subject = teacher.Subjects.Find(s => s.Id == vm.SubjectId),
                Student = student,
                Comments = vm.Comments,
                Date = WeekCalc.GetDateFromWeek(vm.WeekNumber, slot.WorkDay.Day)
            };
            try
            {
                UserService.Book(session);
                TempData["Success"] = "Appointment created";
            } 
            catch (FaultException e)
            {
                TempData["Error"] = e.Message;
            }
            return RedirectToAction("Details", "Teacher", new { id = teacher.Id });
        }
    }
}