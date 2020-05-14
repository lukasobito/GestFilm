using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GestFilm.Forms;
using GestFilm.Interfaces;
using GestFilm.Models.Global;
using GestFilm.Web.Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace GestFilm.Web.Controllers
{
    public class AuthController : BaseController
    {
        private readonly IAuthRepository<RegisterForm, LoginForm, User> authRepository;

        public AuthController(IAuthRepository<RegisterForm, LoginForm, User> authRepository, ISessionManager sessionManager) : base(sessionManager)
        {
            this.authRepository = authRepository;
        }

        [AnonymousRequired]
        public IActionResult Index()
        {
            return RedirectToAction("Login");
        }

        [AnonymousRequired]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [AnonymousRequired]
        public IActionResult Login(LoginForm loginForm)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    User user = authRepository.Login(loginForm);

                    if(!(user is null))
                    {
                        SessionManager.User = user;
                        return RedirectToAction("Index", "Event");
                    }

                    ViewBag.Message = "Incorrect login or password";
                }
                catch(Exception e)
                {
                    return View("Error");
                }
            }
            return View(loginForm);
        }

        [AnonymousRequired]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [AnonymousRequired]
        public IActionResult Register(RegisterForm registerForm)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    authRepository.Register(registerForm);
                    return RedirectToAction("Login");
                }
                catch(Exception e)
                {
                    return View("Error");
                }
            }

            return View(registerForm);
        }

        [AuthRequired]
        public IActionResult Logout()
        {
            SessionManager.Abandon();
            return RedirectToAction("Login");
        }
    }
}