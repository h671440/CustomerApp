using CustomerApp.Data;
using CustomerApp.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace CustomerApp.Services
{
    public class ReservasjonsService : IReservasjonsService
    {
        private readonly CustomerAppContext dx;
       


        public ReservasjonsService(CustomerAppContext dx)
        {
            this.dx = dx;
           
        }

        /*

        public async Task<List<Reservasjon>> GetAllReservasjoner()
        {
            var reservasjoner = await dx.Reservasjoner.ToListAsync();
            return reservasjoner;
        }
        */

        public async Task<Reservasjon> ReserverRom(int roomId, int userId, DateTime start, DateTime end)
        {
            Reservasjon reservasjon = new Reservasjon
            {
                RoomId = roomId,
                UserId = userId,
                startDato = start,
                sluttDato = end,
                Status = "Confirmed"
            };

            dx.Reservasjoner.Add(reservasjon);
            await dx.SaveChangesAsync();
            return reservasjon;
        }

      
    
}
}
