namespace T2.DTOs;

public class ReservationServiceDTO
{
    public int Quantity { get; set; }
    public DateTime ServiceDate { get; set; }
    public ServiceDTO? Service { get; set; }
}