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
    public class GroupController : ApiController
    {
        private IGroupRepository<Group> groupRepository;

        public GroupController()
        {
            groupRepository = new GroupRepository();
        }

        [Route("api/Group/GetGroupByUserId/{userId:int}")]
        public IEnumerable<Group> Get(int userId)
        {
            return groupRepository.Get(userId);
        }

        [Route("api/Group/GetById/{id:int}")]
        public Group GetOne(int id)
        {
            return groupRepository.GetOne(id);
        }
        // api/group
        [Route("api/Group/{userId:int}")]
        public Group Post([FromBody]CreateGroup group, int userId)
        {
            Group g = new Group()
            {
                Name = group.Name
            };
            return groupRepository.Insert(g, userId);
        }

        //Api/group/5
        [Route("api/Group/{id:int}")]
        public HttpResponseMessage Put(int id, [FromBody]Group group)
        {
            if (groupRepository.Update(id, group))
                return new HttpResponseMessage(HttpStatusCode.OK);
            else
                return new HttpResponseMessage(HttpStatusCode.NotFound);
        }

        //Api/group/5
        [Route("api/Group/{id:int}")]
        public HttpResponseMessage Delete(int id)
        {
            if (groupRepository.Delete(id))
                return new HttpResponseMessage(HttpStatusCode.OK);
            else
                return new HttpResponseMessage(HttpStatusCode.NotFound);
        }
    }
}
