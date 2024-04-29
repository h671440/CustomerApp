using CustomerApp.Models.Entities;

namespace CustomerApp.Services
{
    public interface IRoomService
    {
     Task<List<Room>> GetAllRooms();
    }
}
