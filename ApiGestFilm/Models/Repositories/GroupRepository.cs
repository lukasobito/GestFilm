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

        public bool Delete(int userId, int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Group> Get(int userId)
        {
            Command command = new Command("FilmApp.SP_GetUserGroup", true);
            command.AddParameter("UserId", userId);

            return dbConnection.ExecuteReader(command, DbDataReader => DbDataReader.ToGroup());
        }

        public Group Get(int userId, int id)
        {
            throw new NotImplementedException();
        }

        public Group Insert(Group entity)
        {
            throw new NotImplementedException();
        }

        public bool Update(int id, Group entity)
        {
            throw new NotImplementedException();
        }
    }
}