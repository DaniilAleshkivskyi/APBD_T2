using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace T2.Entities;
[PrimaryKey(nameof(ReservationId),nameof(ServiceId))]
public class ReservationService
{
    public int ReservationId { get; set; }
    [ForeignKey(nameof(ReservationId))]
    public Reservation Reservation { get; set; } = null!;
    public int ServiceId { get; set; }
    [ForeignKey(nameof(ServiceId))]
    public Service Service { get; set; } = null!;
    public int Quantity { get; set; }
    public DateTime ServiceDate { get; set; }
}