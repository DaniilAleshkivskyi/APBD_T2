namespace T2.DTOs;

public class ReservationDTO
{
    public int ReservationId { get; set; }
    public GuestDTO? Guest { get; set; }
    public DateTime CheckInDate { get; set; }
    public DateTime CheckOutDate { get; set; }
    public string Status { get; set; } = string.Empty;
    public List<ReservationServiceDTO> ReservationServices = [];
    
}