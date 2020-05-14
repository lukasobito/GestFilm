using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GestFilm.Web.Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace GestFilm.Web.Controllers
{
    [IsLoggedAction]
    public class BaseController : Controller
    {
        protected internal ISessionManager SessionManager { get; private set; }
        public BaseController(ISessionManager sessionManager)
        {
            SessionManager = sessionManager;
        }
    }
}