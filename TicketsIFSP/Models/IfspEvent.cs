using Newtonsoft.Json;

namespace TicketsIFSP.Models
{

    [Serializable]
    [JsonObject]
    public class IfspEvent
    {

        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("date")]
        public DateTime Date { get; set; }
        [JsonProperty("max_guests")]
        public int MaxTickets { get; set; }
        [JsonProperty("sold_tickets")]
        public int TicketsSold { get; set; }

        public IfspEvent()
        {
        }

        public IfspEvent(string name, DateTime date, int maxTickets, int ticketsSold)
        {
            Name = name;
            Date = date;
            MaxTickets = maxTickets;
            TicketsSold = ticketsSold;
        }

        public string GetFormattedDateTime()
        {
            return Date.ToString("dd/MM/yyyy às HH:mm");
        }
    }
}
