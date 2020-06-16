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
    public class UserRepository : IUserRepository<User>
    {
        private IConnection dbConnection;

        public UserRepository(IOptions<ConnectionHelper> options)
        {
            ConnectionHelper connection = options.Value;
            DbProviderFactories.RegisterFactory(connection.ProviderName, SqlClientFactory.Instance);

            // Get the provider invariant names
            IEnumerable<string> invariants = DbProviderFactories.GetProviderInvariantNames(); // => 1 result; 'test'

            // Get a factory using that name
            DbProviderFactory factory = DbProviderFactories.GetFactory(invariants.FirstOrDefault());

            dbConnection = new Connection(connection.ConnectionString, factory);
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

        public IEnumerable<User> Get()
        {
            Command command = new Command("FilmApp.SP_GetAllUser", true);

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
