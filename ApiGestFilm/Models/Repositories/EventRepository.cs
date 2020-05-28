using ApiGestFilm.Models.Mappers;
using GestFilm.Interfaces;
using GestFilm.Models.Global;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Common;
using System.Linq;
using System.Web;
using ToolBox.Connections;

namespace ApiGestFilm.Models.Repositories
{
    public class EventRepository : IEventRepository<Event>
    {
        private IConnection dbConnection;

        public EventRepository()
        {
            dbConnection = new Connection(
                ConfigurationManager.ConnectionStrings["GestFilmDB"].ConnectionString,
                DbProviderFactories.GetFactory(ConfigurationManager.ConnectionStrings["GestFilmDB"].ProviderName));
        }
        public bool Delete(int id)
        {
            Command command = new Command("FilmApp.SP_DeleteEvent", true);
            command.AddParameter("Id", id);

            return dbConnection.ExecuteNonQuery(command) == 1;
        }

        public IEnumerable<Event> GetByGroupId(int groupId)
        {
            Command command = new Command("FilmApp.SP_GetGroupEvent", true);
            command.AddParameter("GroupId", groupId);

            return dbConnection.ExecuteReader(command, dr => dr.ToEvent());
        }

        public IEnumerable<Event> GetByUserId(int userId)
        {
            Command command = new Command("FilmApp.SP_GetUserEvent", true);
            command.AddParameter("UserId", userId);

            return dbConnection.ExecuteReader(command, dr => dr.ToEvent());
        }

        public Event GetOne(int id)
        {
            Command command = new Command("FilmApp.SP_GetEvent", true);
            command.AddParameter("Id", id);

            return dbConnection.ExecuteReader(command, dr => dr.ToEvent()).SingleOrDefault();

        }

        public Event Insert(Event entity)
        {
            Command command = new Command("FilmApp.SP_CreateEvent", true);
            command.AddParameter("Name", entity.Name);
            command.AddParameter("Film", entity.Film);
            command.AddParameter("Date", entity.DateEvent);
            command.AddParameter("IsFilmValid", entity.IsFilmValid);
            command.AddParameter("IsDateValid", entity.IsDateValid);
            command.AddParameter("GroupId", entity.GroupId);


            entity.Id = (int)dbConnection.ExecuteScalar(command);
            return entity;
        }

        public bool Update(int id, Event entity)
        {
            Command command = new Command("FilmApp.SP_UpdateEvent", true);
            command.AddParameter("Id", id);
            command.AddParameter("Name", entity.Name);
            command.AddParameter("Film", entity.Film);
            command.AddParameter("Date", entity.DateEvent);
            command.AddParameter("IsFilmValid", entity.IsFilmValid);
            command.AddParameter("IsDateValid", entity.IsDateValid);
            command.AddParameter("GroupId", entity.GroupId);

            return dbConnection.ExecuteNonQuery(command) == 1;
        }
    }
}