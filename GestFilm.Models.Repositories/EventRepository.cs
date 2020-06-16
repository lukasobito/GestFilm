using GestFilm.Interfaces;
using GestFilm.Models.Data;
using G = GestFilm.Models.Global;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Authentication;
using System.Text;
using System.Linq;
using GestFilm.Models.Repositories.Mappers;

namespace GestFilm.Models.Repositories
{
    public class EventRepository : IEventRepository<Event>
    {

        private readonly HttpClient httpClient;

        public EventRepository(Uri uri)
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

        public IEnumerable<Event> GetByGroupId(int groupId)
        {
            HttpResponseMessage responseMessage = httpClient.GetAsync("Event/GetEventByGroupId/" + groupId).Result;
            responseMessage.EnsureSuccessStatusCode();

            string json = responseMessage.Content.ReadAsStringAsync().Result;
            return JsonConvert.DeserializeObject<G.Event[]>(json).Select(e => e.ToClient());
        }

        public IEnumerable<Event> GetByUserId(int userId, string token)
        {
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage responseMessage = httpClient.GetAsync("Event/GetEventByUserId/" + userId).Result;
            responseMessage.EnsureSuccessStatusCode();

            string json = responseMessage.Content.ReadAsStringAsync().Result;
            return JsonConvert.DeserializeObject<G.Event[]>(json).Select(e => e.ToClient());
        }

        public Event GetOne(int id)
        {
            HttpResponseMessage responseMessage = httpClient.GetAsync("Event/GetById/" + id).Result;
            responseMessage.EnsureSuccessStatusCode();

            string json = responseMessage.Content.ReadAsStringAsync().Result;
            return JsonConvert.DeserializeObject<G.Event>(json)?.ToClient();
        }

        public Event Insert(Event entity)
        {
            HttpContent content = new StringContent(JsonConvert.SerializeObject(entity));
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            HttpResponseMessage responseMessage = httpClient.PostAsync("Event/create", content).Result;
            responseMessage.EnsureSuccessStatusCode();

            string json = responseMessage.Content.ReadAsStringAsync().Result;
            G.Event newEvent = JsonConvert.DeserializeObject<G.Event>(json);
            return newEvent.ToClient();
        }

        public bool Update(int id, Event entity)
        {
            HttpContent content = new StringContent(JsonConvert.SerializeObject(entity));
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            HttpResponseMessage responseMessage = httpClient.PutAsync("Event/update/" + id, content).Result;
            return responseMessage.IsSuccessStatusCode;
        }
        public bool Delete(int id)
        {
            HttpResponseMessage responseMessage = httpClient.DeleteAsync("Event/delete/" + id).Result;
            return responseMessage.IsSuccessStatusCode;
        }
    }
}
