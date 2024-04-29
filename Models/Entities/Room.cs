using System.ComponentModel.DataAnnotations.Schema;

namespace CustomerApp.Models.Entities
{
    public class Room
    {
        public int RoomId { get; set; }
        public int Number { get; set; }
        public int NumberOfBeds { get; set; }
    
        public string RoomType { get; set; }

        public bool IsAvailable { get; set; }

     

    }       
}
