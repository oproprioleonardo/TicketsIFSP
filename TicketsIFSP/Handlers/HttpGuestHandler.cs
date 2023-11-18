using Newtonsoft.Json;
using TicketsIFSP.Models;

namespace TicketsIFSP.Handlers
{
    public class HttpGuestHandler : IGuestHandler
    {
        private readonly HttpClient Client = new()
        {
            BaseAddress = new Uri("xxxxxxxxxxx"),
        };

        public HttpGuestHandler() { }

        public async Task<bool> Ban(Guest guest)
        {
            var response = await Client.SendAsync(new HttpRequestMessage(HttpMethod.Patch, "toggle/blocked/" + guest.Id));
            return response.IsSuccessStatusCode;
        }

        public async Task<Guest> Enter(Guest guest)
        {
            var response = await Client.SendAsync(new HttpRequestMessage(HttpMethod.Patch, "toggle/enter/" + guest.Id));
            string jsonResponse = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Guest>(jsonResponse);
        }

        public async Task<bool> Left(Guest guest)
        {
            var response = await Client.SendAsync(new HttpRequestMessage(HttpMethod.Patch, "toggle/left/" + guest.Id));
            return response.IsSuccessStatusCode;
        }
    }
}
