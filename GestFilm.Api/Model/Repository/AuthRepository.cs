using GestFilm.Api.Helpers;
using GestFilm.Api.Model.Mappers;
using GestFilm.Forms;
using GestFilm.Interfaces;
using GestFilm.Models.Global;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using ToolBox.Connections;

namespace GestFilm.Api.Model.Repository
{
    public class AuthRepository : IAuthRepository<RegisterForm, LoginForm, User>
    {
        private IConnection dbConnection;
        private readonly AppSettings appSettings;

        public AuthRepository(IOptions<ConnectionHelper> options, IOptions<AppSettings> app)
        {
            ConnectionHelper connection = options.Value;
            DbProviderFactories.RegisterFactory(connection.ProviderName, SqlClientFactory.Instance);

            // Get the provider invariant names
            IEnumerable<string> invariants = DbProviderFactories.GetProviderInvariantNames(); // => 1 result; 'test'

            // Get a factory using that name
            DbProviderFactory factory = DbProviderFactories.GetFactory(invariants.FirstOrDefault());

            dbConnection = new Connection(connection.ConnectionString, factory);

            appSettings = app.Value;
        }

        public User Login(LoginForm loginForm)
        {
            Command command = new Command("FilmApp.SP_LoginUser", true);
            command.AddParameter("Login", loginForm.Login);
            command.AddParameter("Password", loginForm.Password);

            User user = dbConnection.ExecuteReader(command, dr => dr.ToUser()).SingleOrDefault();

            if (user == null) return null;

            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            byte[] key = Encoding.ASCII.GetBytes(appSettings.Secret);

            SecurityTokenDescriptor tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Id.ToString())
                }),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            SecurityToken token = tokenHandler.CreateToken(tokenDescriptor);
            user.Token = tokenHandler.WriteToken(token);

            return user;
        }

        public void Register(RegisterForm registerForm)
        {
            Command command = new Command("FilmApp.SP_RegisterUser", true);
            command.AddParameter("LastName", registerForm.LastName);
            command.AddParameter("FirstName", registerForm.FirstName);
            command.AddParameter("Login", registerForm.Login);
            command.AddParameter("Password", registerForm.Password);

            dbConnection.ExecuteNonQuery(command);
        }
    }
}
