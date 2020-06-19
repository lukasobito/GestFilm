using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using GestFilm.Api.Model;
using GestFilm.Api.Model.Infrastructure;
using GestFilm.Api.Model.Repository;
using GestFilm.Models.Global;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

namespace GestFilm.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        private IEventRepository<Event> eventRepository;

        public EventController(IEventRepository<Event> eventRepository)
        {
            this.eventRepository = eventRepository;
        }
        
        [Route("GetEventByUserId/{userId:int}")]
        public IEnumerable<Event> GetEventByUserId(int userId)
        {
            IEnumerable<Event> events = eventRepository.GetByUserId(userId);
            return events;
        }

        [Route("GetEventByGroupId/{groupId:int}")]
        public IEnumerable<Event> GetEventByGroupId(int groupId)
        {
            return eventRepository.GetByGroupId(groupId);
        }

        [Route("GetById/{id:int}")]
        public Event Get(int id)
        {
            return eventRepository.GetOne(id);
        }

        [Authorize]
        [Route("create")]
        public Event Post([FromBody]CreateEvent ev)
        {
            Event e = new Event()
            {
                Name = ev.Name,
                Film = ev.Film,
                DateEvent = ev.DateEvent,
                IsDateValid = false,
                IsFilmValid = false,
                GroupId = ev.GroupId
            };

            return eventRepository.Insert(e);
        }
        [Route("update/{id:int}")]
        public IActionResult Put(int id, [FromBody]Event ev)
        {
            if (eventRepository.Update(id, ev))
                return Ok();
            //return new HttpResponseMessage(HttpStatusCode.OK);
            else
                return NotFound();
                //return new HttpResponseMessage(HttpStatusCode.NotFound);
        }
        [Route("delete/{id:int}")]
        public IActionResult Delete(int id)
        {
            if (eventRepository.Delete(id))
                return Ok();
            //return new HttpResponseMessage(HttpStatusCode.OK);
            else
                return NotFound();
               // return new HttpResponseMessage(HttpStatusCode.NotFound);
        }
    }
}