using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using GestFilm.Interfaces;
using GestFilm.Models.Global;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GestFilm.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserRepository<User> userRepository;

        public UserController(IUserRepository<User> userRepository)
        {
            this.userRepository = userRepository;
        }

        [Route("getByIdGroup/{idGroup:int}")]
        public IEnumerable<User> Get(int idGroup)
        {
            return userRepository.Get(idGroup);
        }


        [Route("Get/{idGroup:int}/{search}")]
        public IEnumerable<User> Get(string search, int idGroup)
        {
            return userRepository.Get(search, idGroup);
        }

        [Route("link/{idGroup:int}/{idUser:int}")]
        public IActionResult GetCreate(int idGroup, int idUser)
        {
            if (userRepository.Insert(idGroup, idUser))
                return Ok();
            //return new HttpResponseMessage(HttpStatusCode.OK);
            else
                return BadRequest();
                //return new HttpResponseMessage(HttpStatusCode.BadRequest);
        }

        [Route("{idGroup:int}/{idUser:int}")]
        public IActionResult Delete(int idGroup, int idUser)
        {
            if (userRepository.Delete(idGroup, idUser))
                return Ok();
            //return new HttpResponseMessage(HttpStatusCode.OK);
            else
                return BadRequest();
                //return new HttpResponseMessage(HttpStatusCode.BadRequest);
        }
    }
}