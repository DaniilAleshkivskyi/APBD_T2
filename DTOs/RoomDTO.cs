using T2.Entities;

namespace T2.DTOs;

public class RoomDTO
{
    public int RoomId { get; set; }
    public string RoomNumber { get; set; } = string.Empty;
    public string Type { get; set; } = string.Empty;
    public decimal PricePerNight { get; set; }
    public int Floor {get; set;}
    public List<ReservationDTO> Reservations { get; set; } = [];
}