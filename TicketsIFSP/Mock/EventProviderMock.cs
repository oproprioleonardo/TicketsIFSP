using TicketsIFSP.Models;
using TicketsIFSP.Providers;

namespace TicketsIFSP.Mock
{
    public class EventProviderMock : IEventProvider
    {
        public async Task<IfspEvent> FindEventById(string id)
        {
            await Task.Delay(10);
            return new IfspEvent()
            {
                Id = id,
                Name = "Evento #" + new Random().Next(1, 100),
                MaxTickets = new Random().Next(300, 500),
                TicketsSold = new Random().Next(10, 150),
                Date = DateTime.Now
            };
        }

        public async Task<List<IfspEvent>> FindEvents()
        {
            return new List<IfspEvent>()
            {
                await FindEventById(Guid.NewGuid().ToString()),
                await FindEventById(Guid.NewGuid().ToString()),
                await FindEventById(Guid.NewGuid().ToString()),
                await FindEventById(Guid.NewGuid().ToString()),
                await FindEventById(Guid.NewGuid().ToString()),
            };
        }
    }
}
