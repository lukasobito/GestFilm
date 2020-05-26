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
    public class UserRepository : IUserRepository<User>
    {
        private IConnection dbConnection;

        public UserRepository()
        {
            dbConnection = new Connection(
                ConfigurationManager.ConnectionStrings["GestFilmDB"].ConnectionString,
                DbProviderFactories.GetFactory(ConfigurationManager.ConnectionStrings["GestFilmDB"].ProviderName));
        }

        public bool Delete(int idGroup, int idUser)
        {
            Command command = new Command("FilmApp.SP_UnlinkUserGroup", true);
            command.AddParameter("IdGroup", idGroup);
            command.AddParameter("IdUser", idUser);

            return dbConnection.ExecuteNonQuery(command) == 1;
        }

        public IEnumerable<User> Get(string search, int idGroup)
        {
            Command command = new Command("FilmApp.SP_GetUser", true);
            command.AddParameter("IdGroup", idGroup);
            command.AddParameter("Search", search);

            return dbConnection.ExecuteReader(command, dr => dr.ToUser());
        }

        public IEnumerable<User> Get(int idGroup)
        {
            Command command = new Command("FilmApp.SP_GetUserByIdGroup", true);
            command.AddParameter("IdGroup", idGroup);

            return dbConnection.ExecuteReader(command, dr => dr.ToUser());
        }

        public bool Insert(int idGroup, int idUser)
        {
            Command command = new Command("FilmApp.SP_LinkUserGroup", true);
            command.AddParameter("IdGroup", idGroup);
            command.AddParameter("IdUser", idUser);

            return dbConnection.ExecuteNonQuery(command) == 1;
        }
    }
}