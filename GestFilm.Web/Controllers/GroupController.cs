using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GestFilm.Interfaces;
using GestFilm.Models.Global;
using GestFilm.Web.Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace GestFilm.Web.Controllers
{
    public class GroupController : BaseController
    {
        private readonly IGroupRepository<Group> groupRepository;

        public GroupController(IGroupRepository<Group> groupRepository, ISessionManager sessionManager) : base(sessionManager)
        {
            this.groupRepository = groupRepository;
        }

        public IActionResult Index()
        {
            return View(groupRepository.Get(SessionManager.User.Id));
        }
    }
}