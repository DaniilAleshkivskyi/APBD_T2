using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace T2.Entities;

public class Service
{
    [Key]
    public int ServiceId { get; set; }
    [MaxLength(100)]
    public string Name { get; set; } = string.Empty;
    [MaxLength(100)]
    public string Description { get; set; } = string.Empty;
    [Column(TypeName = "decimal(10,2)")]
    public decimal Price { get; set; }
    public int DurationMinutes { get; set; }
    
    public ICollection<ReservationService> ReservationServices { get; set; } = [];
}



