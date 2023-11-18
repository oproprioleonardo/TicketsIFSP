using TicketsIFSP.Models;

namespace TicketsIFSP.Providers
{
    public interface IGuestProvider
    {

        Task<Guest> FindGuestById(string id);

    }
}
