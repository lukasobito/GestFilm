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
    public class UserController : ApiController
    {
        private IUserRepository<User> userRepository;

        public UserController()
        {
            userRepository = new UserRepository();
        }

        [Route("api/User/getByIdGroup/{idGroup:int}")]
        public IEnumerable<User> Get(int idGroup)
        {
            return userRepository.Get(idGroup);
        }


        [Route("api/User/Get/{idGroup:int}/{search}")]
        public IEnumerable<User> Get(string search, int idGroup)
        {
            return userRepository.Get(search, idGroup);
        }

        [Route("api/User/link/{idGroup:int}/{idUser:int}")]
        public HttpResponseMessage GetCreate(int idGroup, int idUser)
        {
            if (userRepository.Insert(idGroup, idUser))
                return new HttpResponseMessage(HttpStatusCode.OK);
            else
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
        }

        [Route("api/User/{idGroup:int}/{idUser:int}")]
        public HttpResponseMessage Delete(int idGroup, int idUser)
        {
            if (userRepository.Delete(idGroup, idUser))
                return new HttpResponseMessage(HttpStatusCode.OK);
            else
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
        }
    }
}
