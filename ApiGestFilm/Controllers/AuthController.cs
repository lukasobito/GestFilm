using ApiGestFilm.Models.Repositories;
using GestFilm.Forms;
using GestFilm.Interfaces;
using GestFilm.Models.Global;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.UI.WebControls;

namespace ApiGestFilm.Controllers
{
    public class AuthController : ApiController
    {
        IAuthRepository<RegisterForm, LoginForm, User> authRepository;

        public AuthController()
        {
            authRepository = new AuthRepository();
        }

        [Route("api/auth/register/")]
        [HttpPost]
        public HttpResponseMessage Register(RegisterForm registerForm)
        {
            if(!(registerForm is null) && ModelState.IsValid)
            {
                try
                {
                    authRepository.Register(registerForm);
                    return new HttpResponseMessage(HttpStatusCode.OK);
                }
                catch(Exception e)
                {
                    return new HttpResponseMessage(HttpStatusCode.BadRequest);
                }
            }

            HttpContent content = (!(registerForm is null))
                ? new StringContent(JsonConvert.SerializeObject(ModelState))
                : new StringContent("There is no Data !");

            return new HttpResponseMessage(HttpStatusCode.BadRequest) { Content = content };
        }

        [Route("api/auth/login/")]
        [HttpPost]
        public HttpResponseMessage Login(LoginForm loginForm)
        {
            if(!(loginForm is null) && ModelState.IsValid)
            {
                try
                {
                    User user = authRepository.Login(loginForm);

                    if(user is null)
                    {
                        return new HttpResponseMessage(HttpStatusCode.NoContent);
                    }
                    else
                    {
                        return new HttpResponseMessage(HttpStatusCode.OK) { Content = new StringContent(JsonConvert.SerializeObject(user)) };
                    }
                }
                catch(Exception e)
                {
                    return new HttpResponseMessage(HttpStatusCode.BadRequest);
                }
            }

            HttpContent content = (!(loginForm is null))
                ? new StringContent(JsonConvert.SerializeObject(ModelState))
                : new StringContent("There si no Data !");

            return new HttpResponseMessage(HttpStatusCode.BadRequest) { Content = content };
        }
    }
}
