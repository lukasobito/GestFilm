using GestFilm.Web.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestFilm.Web.Infrastructure
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple =false, Inherited =true)]
    public class IsLoggedActionAttribute: ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            BaseController controller = (BaseController)context.Controller;
            controller.ViewBag.IsLogged = !(controller.SessionManager.User is null);
        }
    }
}
