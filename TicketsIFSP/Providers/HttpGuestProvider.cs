using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketsIFSP.Models;

namespace TicketsIFSP.Providers
{
    public class HttpGuestProvider : IGuestProvider
    {
        private readonly HttpClient Client = new()
        {
            BaseAddress = new Uri("XXXXXXXXXXXX"),
        };

        public HttpGuestProvider() { }

        public async Task<Guest> FindGuestById(string id)
        {
            using HttpResponseMessage response = await Client.GetAsync(id);
            string jsonResponse = await response.Content.ReadAsStringAsync();
            Guest guest = JsonConvert.DeserializeObject<Guest>(jsonResponse);
            return guest;
        }
    }
}
