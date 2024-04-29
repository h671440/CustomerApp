using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CustomerApp.Models.Entities
{

    [Table("User")]
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("UserId")]
        public int UserId { get; set; }

        [Column("Username")]
        [MaxLength(100)]
        public string Username { get; set; }
        [Column("Password")]
        [MaxLength(20)]
        public string Password { get; set; }
        [Column("RoleId")]
        [MaxLength(20)]
        public int RoleId { get; set; }

    }
}
