using GestFilm.Models.Global;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestFilm.Web.Infrastructure
{
    public class SessionManager : ISessionManager
    {
        private ISession session;

        public SessionManager(IHttpContextAccessor httpContextAccessor)
        {
            session = httpContextAccessor.HttpContext.Session;
        }
        public User User 
        {
            get
            {
                string json = session.GetString(nameof(User));
                return (json is null) ? null : JsonConvert.DeserializeObject<User>(json);
            }
            set
            {
                session.SetString(nameof(User), JsonConvert.SerializeObject(value));
            }
        }

        public int IdGroup 
        {
            get 
            {
                return (session.GetInt32(nameof(IdGroup)) ?? default(int));
            }
            set
            {
                session.SetInt32(nameof(IdGroup), value);
            }
        }

        public void Abandon()
        {
            session.Clear();
        }
    }
}
