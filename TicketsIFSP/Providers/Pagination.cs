using Newtonsoft.Json;

namespace TicketsIFSP.Providers
{
    [JsonObject]
    public class Pagination<T>
    {

        [JsonProperty("currentPage")]
        public int CurrentPage { get; set; }
        [JsonProperty("perPage")]
        public int PerPage { get; set; }
        [JsonProperty("total")]
        public int Total { get; set; }
        [JsonProperty("items")]
        public List<T> Items { get; set; }

        public Pagination()
        {
        }
    }
}
