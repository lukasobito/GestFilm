using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Authentication;
using System.Text;
using GestFilm.Forms;
using GestFilm.Interfaces;
using GestFilm.Models.Global;
using Newtonsoft.Json;

namespace GestFilm.Models.Repositories
{
    public class AuthRepository : IAuthRepository<RegisterForm, LoginForm, User>
    {
        private readonly HttpClient httpClient;

        public AuthRepository(Uri uri)
        {
            var handler = new HttpClientHandler
            {
                SslProtocols = SslProtocols.Default
            };

            handler.ServerCertificateCustomValidationCallback = (request, cert, chain, errors) =>
            {
                return true;
            };

            httpClient = new HttpClient(handler);
            httpClient.BaseAddress = uri;
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public User Login(LoginForm loginForm)
        {
            HttpContent content = new StringContent(JsonConvert.SerializeObject(loginForm));
            content.Headers.ContentType = new MediaTypeWithQualityHeaderValue("application/json");

            HttpResponseMessage responseMessage = httpClient.PostAsync("auth/login", content).Result;
            responseMessage.EnsureSuccessStatusCode();

            if (responseMessage.StatusCode == HttpStatusCode.NoContent)
                return null;

            string json = responseMessage.Content.ReadAsStringAsync().Result;
            return JsonConvert.DeserializeObject<User>(json);
        }

        public void Register(RegisterForm registerForm)
        {
            HttpContent content = new StringContent(JsonConvert.SerializeObject(registerForm));
            content.Headers.ContentType = new MediaTypeWithQualityHeaderValue("application/json");

            HttpResponseMessage responseMessage = httpClient.PostAsync("auth/register", content).Result;
            responseMessage.EnsureSuccessStatusCode();
        }
    }
}
