using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using GestFilm.Api.Model;
using GestFilm.Interfaces;
using GestFilm.Models.Global;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GestFilm.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroupController : ControllerBase
    {
        private IGroupRepository<Group> groupRepository;

        public GroupController(IGroupRepository<Group> groupRepository)
        {
            this.groupRepository = groupRepository;
        }

        [Route("GetGroupByUserId/{userId:int}")]
        public IEnumerable<Group> Get(int userId)
        {
            return groupRepository.Get(userId);
        }

        [Route("GetById/{id:int}")]
        public Group GetOne(int id)
        {
            return groupRepository.GetOne(id);
        }
        // api/group
        [Route("create/{userId:int}")]
        public Group Post([FromBody]CreateGroup group, int userId)
        {
            Group g = new Group()
            {
                Name = group.Name
            };
            return groupRepository.Insert(g, userId);
        }

        //Api/group/5
        [Route("update/{id:int}")]
        public IActionResult Put(int id, [FromBody]Group group)
        {
            if (groupRepository.Update(id, group))
                return Ok();
            //return new HttpResponseMessage(HttpStatusCode.OK);
            else
                return NotFound();
                //return new HttpResponseMessage(HttpStatusCode.NotFound);
        }

        //Api/group/5
        [Route("delete/{id:int}")]
        public IActionResult Delete(int id)
        {
            if (groupRepository.Delete(id))
                return Ok();
            // return new HttpResponseMessage(HttpStatusCode.OK);
            else
                return NotFound();
                //return new HttpResponseMessage(HttpStatusCode.NotFound);
        }
    }
}