using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GestFilm.Forms;
using GestFilm.Interfaces;
using GestFilm.Models.Data;
using GestFilm.Web.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GestFilm.Web.Controllers
{
    public class GroupController : BaseController
    {
        private readonly IGroupRepository<Group> groupRepository;
        private readonly IEventRepository<Event> eventRepository;

        public GroupController(IGroupRepository<Group> groupRepository, IEventRepository<Event> eventRepository, ISessionManager sessionManager) : base(sessionManager)
        {
            this.groupRepository = groupRepository;
            this.eventRepository = eventRepository;
        }

        [AuthRequired]
        public IActionResult Index()
        {
            return View(groupRepository.Get(SessionManager.User.Id));
        }

        [AuthRequired]
        public ActionResult Details(int id)
        {
            InfoGroup infoGroup = new InfoGroup()
            {
                Id = id,
                Name = groupRepository.GetOne(id).Name,
                events = eventRepository.GetByGroupId(id)
            };
            return View(infoGroup);
        }

        [AuthRequired]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [AuthRequired]
        public ActionResult Create(CreateGroup form)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    groupRepository.Insert(new Group(form.Name),SessionManager.User.Id);
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
        public ActionResult Edit(int id)
        {
            Group group = groupRepository.GetOne(id);

            return View(new CreateGroup
            {
                Name = group.Name
            });
        }

        [HttpPost]
        [AuthRequired]
        public ActionResult Edit(int id, CreateGroup form)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    groupRepository.Update(id, new Group(id, form.Name));
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

            return View(groupRepository.GetOne(id));
        }
        [HttpPost]
        [AuthRequired]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                groupRepository.Delete(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View("Error");
            }
        }

    }
}