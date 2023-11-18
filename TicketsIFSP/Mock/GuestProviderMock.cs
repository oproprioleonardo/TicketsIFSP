using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketsIFSP.Models;
using TicketsIFSP.Providers;

namespace TicketsIFSP.Mock
{
    public class GuestProviderMock : IGuestProvider
    {

        public async Task<Guest> FindGuestById(string id)
        {
            await Task.Delay(10);
            Guest g = new()
            {
                Id = id,
                EntranceNumber = 1,
                Name = "Pedro XXXXXXXXXX",
                Profile = GuestProfile.STUDENT,
                Document = "12345678910",
                Banned = false,
                Email = "XXXXXXXXXXXX@gmail.com",
                Age = 17,
                PhoneNumber = "11999999999",
                EventId = Guid.NewGuid().ToString()
            };

            return g;
        }

        
    }
}
