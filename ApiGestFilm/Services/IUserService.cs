using GestFilm.Models.Global;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiGestFilm.Services
{
    interface IUserService
    {
        User Authentificate(string login, string password);
        IEnumerable<User> GetAll();
    }
}
