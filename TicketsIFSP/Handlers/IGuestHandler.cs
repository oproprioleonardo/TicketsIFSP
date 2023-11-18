using TicketsIFSP.Models;

namespace TicketsIFSP.Handlers
{
    public interface IGuestHandler
    {
        Task<bool> Left(Guest guest);

        Task<Guest> Enter(Guest guest);

        Task<bool> Ban(Guest guest);
    }
}
