using GestFilm.Forms;
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
    public class AuthController : ApiController
    {
        IAuthRepository<RegisterForm, LoginForm, User> authRepository;
    }
}
