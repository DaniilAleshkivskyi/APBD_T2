using System.ComponentModel.DataAnnotations;

namespace T2.Entities;

public class Guest
{
    [Key] 
    public int Id { get; set; }
    [MaxLength(50)] 
    public string FirstName { get; set; } = string.Empty;
    [MaxLength(100)] 
    public string LastName { get; set; } = string.Empty;
    [MaxLength(100)]
    public string Email { get; set; } = string.Empty;
    [MaxLength(9)] 
    public string Phone { get; set; } = string.Empty;

    public ICollection<Reservation> Reservations { get; set; } = [];
}