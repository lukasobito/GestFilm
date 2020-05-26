using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GestFilm.Interfaces;
using GestFilm.Models.Data;
using GestFilm.Web.Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace GestFilm.Web.Controllers
{
    public class UserController : BaseController
    {
        private readonly IUserRepository<User> userRepository;

        public UserController(IUserRepository<User> userRepository, ISessionManager sessionManager) : base(sessionManager)
        {
            this.userRepository = userRepository;
        }
    }
}