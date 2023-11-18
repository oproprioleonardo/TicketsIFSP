using TicketsIFSP.Models;

namespace TicketsIFSP.Providers
{
    public interface IEventProvider
    {

        Task<List<IfspEvent>> FindEvents();

        Task<IfspEvent> FindEventById(string id);

    }
}
