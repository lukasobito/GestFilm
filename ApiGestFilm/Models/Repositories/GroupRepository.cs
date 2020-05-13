using System;
using System.Collections.Generic;
using GestFilm.Interfaces;
using System.Linq;
using System.Web;
using GestFilm.Models.Global;
using ToolBox.Connections;
using System.Configuration;
using System.Data.Common;
using ApiGestFilm.Models.Mappers;

namespace ApiGestFilm.Models.Repositories
{
    public class GroupRepository : IGroupRepository<Group>
    {
        private IConnection dbConnection;

        public GroupRepository()
        {
            dbConnection = new Connection(
                ConfigurationManager.ConnectionStrings["GestFilmDB"].ConnectionString,
                DbProviderFactories.GetFactory(ConfigurationManager.ConnectionStrings["GestFilmDB"].ProviderName));
        }

        public bool Delete(int id)
        {
            Command command = new Command("FilmApp.SP_DeleteGroup", true);
            command.AddParameter("Id", id);

            return dbConnection.ExecuteNonQuery(command) == 1;
        }

        public IEnumerable<Group> Get(int userId)
        {
            Command command = new Command("FilmApp.SP_GetUserGroup", true);
            command.AddParameter("UserId", userId);

            return dbConnection.ExecuteReader(command, DbDataReader => DbDataReader.ToGroup());
        }

        public Group GetOne(int id)
        {
            Command command = new Command("FilmApp.SP_GetGroup", true);
            command.AddParameter("Id", id);

            return dbConnection.ExecuteReader(command, dr => dr.ToGroup()).SingleOrDefault();
        }

        public Group Insert(Group entity)
        {
            Command command = new Command("FilmApp.SP_CreateGroup", true);
            command.AddParameter("Name", entity.Name);

            entity.Id = (int)dbConnection.ExecuteScalar(command);
            return entity;
        }

        public bool Update(int id, Group entity)
        {
            Command command = new Command("FilmApp.SP_UpdateGroup", true);
            command.AddParameter("Id", id);
            command.AddParameter("Name", entity.Name);

            return dbConnection.ExecuteNonQuery(command) == 1;
        }
    }
}