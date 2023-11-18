using Newtonsoft.Json;
using TicketsIFSP.Models;

namespace TicketsIFSP.Providers
{
    public class HttpEventProvider : IEventProvider
    {

        private readonly HttpClient Client = new()
        {
            BaseAddress = new Uri("XXXXXXXXX"),
        };

        public HttpEventProvider(){ }

        public async Task<IfspEvent> FindEventById(string id)
        {
            using HttpResponseMessage response = await Client.GetAsync(id);
            string jsonResponse = await response.Content.ReadAsStringAsync();
            IfspEvent ifspEvent = JsonConvert.DeserializeObject<IfspEvent>(jsonResponse);
            return ifspEvent;
        }

        public async Task<List<IfspEvent>> FindEvents()
        {
            using HttpResponseMessage response = await Client.GetAsync("list");
            string jsonResponse = await response.Content.ReadAsStringAsync();
            Pagination<IfspEvent> events = JsonConvert.DeserializeObject<Pagination<IfspEvent>>(jsonResponse);
            return events.Items;
        }
    }

    
}
