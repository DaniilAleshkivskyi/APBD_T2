using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace T2.Entities;

public class Reservation
{
    [Key]
    public int ReservationId { get; set; }
    public int RoomId { get; set; }
    [ForeignKey(nameof(RoomId))]
    public Room Room { get; set; } = null!;
    public int GuestId { get; set; }
    [ForeignKey(nameof(GuestId))]
    public Guest Guest { get; set; } = null!;
    public DateTime CheckInDate { get; set; }
    public DateTime? CheckOutDate { get; set; }
    [MaxLength(50)]
    public string Status { get; set; } = string.Empty;
    
    public ICollection<ReservationService> ReservationServices { get; set; } = [];
}