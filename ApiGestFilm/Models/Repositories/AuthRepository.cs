using ApiGestFilm.Models.Mappers;
using GestFilm.Forms;
using GestFilm.Interfaces;
using GestFilm.Models.Global;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Common;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Web;
using ToolBox.Connections;

namespace ApiGestFilm.Models.Repositories
{
    public class AuthRepository: IAuthRepository<RegisterForm, LoginForm, User>
    {
        private IConnection dbConnection;

        public AuthRepository()
        {
            dbConnection = new Connection(
                ConfigurationManager.ConnectionStrings["GestFilmDB"].ConnectionString,
                DbProviderFactories.GetFactory(ConfigurationManager.ConnectionStrings["GestFilmDB"].ProviderName));
        }

        public User Login(LoginForm loginForm)
        {
            Command command = new Command("FilmApp.SP_LoginUser", true);
            command.AddParameter("Login", loginForm.Login);
            command.AddParameter("Password", loginForm.Password);

            return dbConnection.ExecuteReader(command, dr => dr.ToUser()).SingleOrDefault();
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