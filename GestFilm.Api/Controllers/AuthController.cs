using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using GestFilm.Api.Model.Repository;
using GestFilm.Forms;
using GestFilm.Interfaces;
using GestFilm.Models.Global;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace GestFilm.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class AuthController : ControllerBase
    {
        IAuthRepository<RegisterForm, LoginForm, User> authRepository;

        public AuthController(IAuthRepository<RegisterForm, LoginForm, User> authRepository)
        {
            this.authRepository = authRepository;
        }

        [Route("register/")]
        [HttpPost]
        public IActionResult Register(RegisterForm registerForm)
        {
            if (!(registerForm is null) && ModelState.IsValid)
            {
                try
                {
                    authRepository.Register(registerForm);
                    return Ok();
                   // return new HttpResponseMessage(HttpStatusCode.OK);
                }
                catch (Exception e)
                {
                    return BadRequest("PAS BON");
                   // return new HttpResponseMessage(HttpStatusCode.BadRequest);
                }
            }

            HttpContent content = (!(registerForm is null))
                ? new StringContent(JsonConvert.SerializeObject(ModelState))
                : new StringContent("There is no Data !");

            return BadRequest(content);
            //return new HttpResponseMessage(HttpStatusCode.BadRequest) { Content = content };
        }

        [Route("login/")]
        [HttpPost]
        public IActionResult Login(LoginForm loginForm)
        {
            if (!(loginForm is null) && ModelState.IsValid)
            {
                try
                {
                    User user = authRepository.Login(loginForm);

                    
                    return Ok(user);
                }
                catch (Exception e)
                {
                    return BadRequest("PAS BON");
                }
            }

            HttpContent content = (!(loginForm is null))
                ? new StringContent(JsonConvert.SerializeObject(ModelState))
                : new StringContent("There si no Data !");

            return BadRequest(content);
        }
    }
}