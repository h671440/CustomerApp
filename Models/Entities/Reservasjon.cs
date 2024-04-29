using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CustomerApp.Models.Entities
{
    public class Reservasjon
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ReservasjonId { get; set; }
        public int RoomId { get; set; }
        public int UserId { get; set; }
        public DateTime startDato { get; set; }
        public DateTime sluttDato { get; set; }
        public String Status { get; set; } = "ledig";


        public Reservasjon()
        {
        }
        public Reservasjon( int roomId, int userId, DateTime start, DateTime end, String status)
        {
            
            this.RoomId = roomId;
            this.UserId = userId;
            this.startDato = start;
            this.sluttDato = end;
            this.Status = status;

        }
    }
}
