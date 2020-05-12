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
    }
}
