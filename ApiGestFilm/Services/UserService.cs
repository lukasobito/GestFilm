using ApiGestFilm.Helpers;
using ApiGestFilm.Models.Repositories;
using GestFilm.Forms;
using GestFilm.Interfaces;
using GestFilm.Models.Global;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Web;

namespace ApiGestFilm.Services
{
    public class UserService : IUserService
    {
        private readonly AppSettings appSettings;

        IAuthRepository<RegisterForm, LoginForm, User> authRepository;

        public UserService(IOptions<AppSettings> app)
        {
            appSettings = app.Value;
            authRepository = new AuthRepository();
        }
        public User Authentificate(string login, string password)
        {
            LoginForm loginForm = new LoginForm()
            {
                Login = login,
                Password = password
            };
            User user = authRepository.Login(loginForm);

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
            //user.Token = tokenHandler.WriteToken(token); A VERIFIER

            return user;
        }

        public IEnumerable<User> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}