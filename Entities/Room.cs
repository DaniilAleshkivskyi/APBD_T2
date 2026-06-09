using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace T2.Entities;

public class Room
{
    [Key]
    public int RoomId { get; set; }
    [MaxLength(10)]
    public string RoomNumber { get; set; } = string.Empty;
    [MaxLength(50)]
    public string Type { get; set; } = string.Empty;
    [Column(TypeName = "decimal(10,2)")]
    public decimal PricePerNight { get; set; }
    public int Floor { get; set; }

    public ICollection<Reservation> Reservations { get; set; } = [];

}