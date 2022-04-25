using MvcWebApp.TutorWorldServiceRef;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MvcWebApp.Filters
{
    public class WcfAuthorizationAttribute: AuthorizeAttribute 
    {
        private AuthServiceClient AuthServiceClient = new AuthServiceClient();


        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            var email = filterContext.HttpContext.Session["Email"] as string;
            var password = filterContext.HttpContext.Session["Password"] as string;
            var roles = this.Roles;
            if (email == null || password == null)
            {
                filterContext.Controller.TempData["Error"] = "Unauthenticated";
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new { controller = "Auth", action = "Index" }));
                return;
            }

            try
            {
                AuthServiceClient.Login(email, password);
                var userServiceClient = new UserServiceClient();
                userServiceClient.ClientCredentials.UserName.UserName = email;
                userServiceClient.ClientCredentials.UserName.Password = password;
                if (!CheckRoles(userServiceClient))
                {
                    filterContext.Controller.TempData["Error"] = "You are not permitted to access this page";
                    filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new { controller = "Auth", action = "Index" }));
                }

            }
            catch (FaultException<AuthFault> ignored)
            {
                filterContext.Controller.TempData["Error"] = "Unauthenticated";
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new { controller = "Auth", action = "Index" }));
            }
        }
        private bool CheckRoles(UserServiceClient usc)
        {
            if (!string.IsNullOrEmpty(Roles))
            {
                if ((Roles == "Teacher" && usc.GetAuthenticatedTeacher() == null) ||
                   (Roles == "Student" && usc.GetAuthenticatedStudent() == null))
                {
                    return false;
                }
            }
            return true;
        }
    }
}