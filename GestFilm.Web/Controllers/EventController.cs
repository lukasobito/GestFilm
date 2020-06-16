using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using GestFilm.Forms;
using GestFilm.Interfaces;
using GestFilm.Models.Data;
using GestFilm.Web.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GestFilm.Web.Controllers
{
    public class EventController : BaseController
    {
        private readonly IEventRepository<Event> eventRepository;

        public EventController(IEventRepository<Event> eventRepository, ISessionManager sessionManager) : base(sessionManager)
        {
            this.eventRepository = eventRepository;
        }

        [AuthRequired]
        public IActionResult Index()
        {
            return View(eventRepository.GetByUserId(SessionManager.User.Id, SessionManager.User.Token));
        }

        [AuthRequired]
        public ActionResult Details(int id)
        {
            return View(eventRepository.GetOne(id));
        }

        [AuthRequired]
        [Route("event/create/{groupId:int}")]
        public ActionResult Create(int groupId)
        {
            return View();
        }
        [AuthRequired]
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("event/create/{groupId:int}")]
        public ActionResult Create(int groupId, CreateEvent createEvent)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if(groupId != default(int))
                    {
                        Event newEvent = new Event(createEvent.Name, createEvent.Film, createEvent.DateEvent, groupId);
                        eventRepository.Insert(newEvent);
                        return RedirectToAction("Index");
                    }
                    return View("Error");
                }
                return View(createEvent);
            }
            catch
            {
                return View("Error");
            }
        }

        [AuthRequired]
        public ActionResult Edit(int id)
        {
            Event ev = eventRepository.GetOne(id);

            return View(new EditEvent()
            {
                Name = ev.Name,
                Film = ev.Film,
                DateEvent = ev.DateEvent,
                IsDateValid = ev.IsDateValid,
                IsFilmValid = ev.IsFilmValid,
                GroupId = ev.GroupId
            });
        }

        [AuthRequired]
        [HttpPost]
        public ActionResult Edit(int id, EditEvent form)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    eventRepository.Update(id, new Event(id, form.Name, form.Film, form.DateEvent, form.GroupId, form.IsDateValid, form.IsFilmValid));
                    return RedirectToAction("Index");
                }

                return View(form);
            }
            catch
            {
                return View("Error");
            }
        }

        [AuthRequired]
        public ActionResult Delete(int id)
        {
            if (SessionManager.User is null)
                return RedirectToAction("Login", "Auth");
            return View(eventRepository.GetOne(id));
        }

        [AuthRequired]
        [HttpPost]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                eventRepository.Delete(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View("Error");
            }
        }
    }
}