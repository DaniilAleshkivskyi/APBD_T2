using Microsoft.EntityFrameworkCore;
using T2.DTOs;

namespace PrepT2.Services;

public interface IDbService
{
    public Task<RoomDTO> GetHistoryForRoomWithId(int roomId);
    
    public Task<(bool,string)> CreateGuest(GuestWithReservationDTO guestWithReservation);
}