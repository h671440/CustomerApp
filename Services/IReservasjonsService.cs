using CustomerApp.Models.Entities;

namespace CustomerApp.Services
{
    public interface IReservasjonsService
    {
       // Task<List<Reservasjon>> GetAllReservasjoner();

        Task<Reservasjon> ReserverRom( int roomId, int userId, DateTime start, DateTime end);
    }
}
