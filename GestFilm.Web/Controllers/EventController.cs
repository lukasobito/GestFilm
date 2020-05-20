using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GestFilm.Interfaces;
using GestFilm.Models.Data;
using GestFilm.Web.Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace GestFilm.Web.Controllers
{
    public class EventController : BaseController
    {
        private readonly IEventRepository<Event> eventRepository;

        public EventController(IEventRepository<Event> eventRepository, ISessionManager sessionManager): base(sessionManager)
        {
            this.eventRepository = eventRepository;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}