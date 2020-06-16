using GestFilm.Interfaces;
using G = GestFilm.Models.Global;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Authentication;
using System.Text;
using GestFilm.Models.Data;
using GestFilm.Models.Repositories.Mappers;

namespace GestFilm.Models.Repositories
{
    public class GroupRepository : IGroupRepository<Group>
    {
        private readonly HttpClient httpClient;

        public GroupRepository(Uri uri)
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

        public IEnumerable<Group> Get(int userId)
        {
            HttpResponseMessage responseMessage = httpClient.GetAsync("Group/GetGroupByUserId/" + userId).Result;
            responseMessage.EnsureSuccessStatusCode();

            string json = responseMessage.Content.ReadAsStringAsync().Result;
            return JsonConvert.DeserializeObject<G.Group[]>(json).Select(td => td.ToClient());
        }

        public Group GetOne(int id)
        {
            HttpResponseMessage responseMessage = httpClient.GetAsync("Group/GetById/" + id).Result;
            responseMessage.EnsureSuccessStatusCode();

            string json = responseMessage.Content.ReadAsStringAsync().Result;
            return JsonConvert.DeserializeObject<G.Group>(json)?.ToClient();
        }

        public Group Insert(Group entity, int userId)
        {
            HttpContent content = new StringContent(JsonConvert.SerializeObject(entity));
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            HttpResponseMessage responseMessage = httpClient.PostAsync("Group/create/" + userId, content).Result;
            responseMessage.EnsureSuccessStatusCode();

            string json = responseMessage.Content.ReadAsStringAsync().Result;
            G.Group newGroup = JsonConvert.DeserializeObject<G.Group>(json);
            return newGroup.ToClient();
        }

        public bool Update(int id, Group entity)
        {
            HttpContent content = new StringContent(JsonConvert.SerializeObject(entity));
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            HttpResponseMessage responseMessage = httpClient.PutAsync("Group/update/" + id, content).Result;
            return responseMessage.IsSuccessStatusCode;
        }

        public bool Delete(int id)
        {
            HttpResponseMessage responseMessage = httpClient.DeleteAsync("group/delete/" + id).Result;
            return responseMessage.IsSuccessStatusCode;
        }
    }
}
