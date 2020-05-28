using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GestFilm.Interfaces;
using GestFilm.Models.Data;
using GestFilm.Web.Infrastructure;
using GestFilm.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

namespace GestFilm.Web.Controllers
{
    public class UserController : BaseController
    {
        private readonly IUserRepository<User> userRepository;
        private Search search = new Search();

        public UserController(IUserRepository<User> userRepository, ISessionManager sessionManager) : base(sessionManager)
        {
            this.userRepository = userRepository;
        }

        [Route("user/search/{idGroup:int}")]
        public ActionResult Search(int idGroup)
        {
            SessionManager.IdGroup = idGroup;
            ViewBag.Message = SessionManager.IdGroup;
            return View(search);
        }
        [Route("user/search/{idGroup:int}")]
        [HttpPost]
        public ActionResult Search(int idGroup,Search s2)
        {
            search.value = s2.value;
            search.users = userRepository.Get(search.value, idGroup);//SessionManager.IdGroup
            return View(search);
        }

        [Route("user/list/{idGroup:int}")]
        public ActionResult List(int idGroup)
        {
            ViewBag.Message = SessionManager.User.Id;
            SessionManager.IdGroup = idGroup;
            return View(userRepository.Get(idGroup));
        }

        [Route("user/addUser/{idUser:int}")]
        public ActionResult AddUser(int idUser)
        {
            userRepository.Insert(SessionManager.IdGroup, idUser);
            return RedirectToAction("List", new { idGroup = SessionManager.IdGroup});
        }

        [Route("user/delete/{idUser:int}")]
        public ActionResult Delete(int idUser)
        {
            userRepository.Delete(SessionManager.IdGroup, idUser);
            return RedirectToAction("List", new { idGroup = SessionManager.IdGroup });
        }
    }
}