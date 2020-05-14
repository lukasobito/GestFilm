using ApiGestFilm.Models;
using ApiGestFilm.Models.Repositories;
using GestFilm.Interfaces;
using GestFilm.Models.Global;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ApiGestFilm.Controllers
{
    public class EventController : ApiController
    {
        private IEventRepository<Event> eventRepository;

        public EventController()
        {
            eventRepository = new EventRepository();
        }

        [Route("api/Event/GetEventByUserId/{userId:int}")]
        public IEnumerable<Event> GetEventByUserId(int userId)
        {
            return eventRepository.GetByUserId(userId);
        }

        [Route("api/Event/GetEventByGroupId/{groupId:int}")]
        public IEnumerable<Event> GetEventByGroupId(int groupId)
        {
            return eventRepository.GetByGroupId(groupId);
        }

        [Route("api/Event/GetById/{id:int}")]
        public Event Get(int id)
        {
            return eventRepository.GetOne(id);
        }

        public Event Post([FromBody]CreateEvent ev)
        {
            Event e = new Event()
            {
                Name = ev.Name,
                Film = ev.Film,
                DateEvent = ev.DateEvent,
                IsDateValid = false,
                IsFilmValid = false
            };

            return eventRepository.Insert(e);
        }

        public HttpResponseMessage Put(int id, [FromBody]Event ev)
        {
            if (eventRepository.Update(id, ev))
                return new HttpResponseMessage(HttpStatusCode.OK);
            else
                return new HttpResponseMessage(HttpStatusCode.NotFound);
        }

        public HttpResponseMessage Delete(int id)
        {
            if (eventRepository.Delete(id))
                return new HttpResponseMessage(HttpStatusCode.OK);
            else
                return new HttpResponseMessage(HttpStatusCode.NotFound);
        }
    }
}
