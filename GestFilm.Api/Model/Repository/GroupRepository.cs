using GestFilm.Api.Model.Mappers;
using GestFilm.Interfaces;
using GestFilm.Models.Global;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using ToolBox.Connections;

namespace GestFilm.Api.Model.Repository
{
    public class GroupRepository : IGroupRepository<Group>
    {
        private IConnection dbConnection;

        public GroupRepository(IOptions<ConnectionHelper> options)
        {
            ConnectionHelper connection = options.Value;
            DbProviderFactories.RegisterFactory(connection.ProviderName, SqlClientFactory.Instance);

            // Get the provider invariant names
            IEnumerable<string> invariants = DbProviderFactories.GetProviderInvariantNames(); // => 1 result; 'test'

            // Get a factory using that name
            DbProviderFactory factory = DbProviderFactories.GetFactory(invariants.FirstOrDefault());

            dbConnection = new Connection(connection.ConnectionString, factory);
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

        public Group Insert(Group entity, int userId)
        {
            Command command = new Command("FilmApp.SP_CreateGroup", true);
            command.AddParameter("Name", entity.Name);
            command.AddParameter("UserId", userId);

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
