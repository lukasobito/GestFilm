using GestFilm.Interfaces;
using GestFilm.Models.Data;
using G = GestFilm.Models.Global;
using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Http;
using System.Security.Authentication;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using GestFilm.Models.Repositories.Mappers;
using System.Linq;

namespace GestFilm.Models.Repositories
{
    public class UserRepository : IUserRepository<User>
    {
        private readonly HttpClient httpClient;

        public UserRepository(Uri uri)
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

        public bool Delete(int idGroup, int idUser)
        {
            HttpResponseMessage responseMessage = httpClient.DeleteAsync("user/" + idGroup + "/" + idUser).Result;
            return responseMessage.IsSuccessStatusCode;
        }

        public IEnumerable<User> Get(string search, int idGroup)
        {
            HttpResponseMessage responseMessage = httpClient.GetAsync("user/get/" + idGroup + "/" + search).Result;
            responseMessage.EnsureSuccessStatusCode();

            string json = responseMessage.Content.ReadAsStringAsync().Result;
            return JsonConvert.DeserializeObject<G.User[]>(json).Select(u => u.ToClient());
        }

        public IEnumerable<User> Get(int idGroup)
        {
            HttpResponseMessage responseMessage = httpClient.GetAsync("user/getbyidgroup/" + idGroup).Result;
            responseMessage.EnsureSuccessStatusCode();

            string json = responseMessage.Content.ReadAsStringAsync().Result;
            return JsonConvert.DeserializeObject<G.User[]>(json).Select(u => u.ToClient());
        }

        public bool Insert(int idGroup, int idUser)
        {
            HttpResponseMessage responseMessage = httpClient.GetAsync("User/link/" + idGroup + "/" + idUser).Result;
            return responseMessage.IsSuccessStatusCode;
        }
    }
}
