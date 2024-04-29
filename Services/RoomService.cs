using CustomerApp.Data;
using CustomerApp.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace CustomerApp.Services
{
    public class RoomService : IRoomService
    {
        private readonly CustomerAppContext dx;
        

        public RoomService(CustomerAppContext dx)
        {
            this.dx = dx;
            
        }

        public async Task<List<Room>> GetAllRooms()
        {
            var rooms = await dx.Rooms.ToListAsync();
            return rooms;
        }
    }
}
