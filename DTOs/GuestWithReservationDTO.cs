namespace T2.DTOs;

public class GuestWithReservationDTO
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public CreateReservationForGuestDTO? CreateReservationForGuest { get; set; }
}

public class CreateReservationForGuestDTO
{
    public int RoomId { get; set; }
    public DateTime CheckInDate { get; set; }
}