using Microsoft.EntityFrameworkCore;
using T2.Data;
using T2.DTOs;
using T2.Entities;

namespace PrepT2.Services;

public class DbService(AppDbContext _context) : IDbService
{
    public async Task<RoomDTO> GetHistoryForRoomWithId(int roomId)
    {
        var room = await _context.Rooms.FirstOrDefaultAsync(r => r.RoomId == roomId);

        if (room == null)
        {
            return null;
        }

        var res = await _context.Rooms.Select(r => new RoomDTO()
        {
            RoomId = r.RoomId,
            RoomNumber = r.RoomNumber,
            Type = r.Type,
            PricePerNight = r.PricePerNight,
            Floor = r.Floor,
            Reservations = r.Reservations.Select(re => new ReservationDTO()
            {
                ReservationId = re.ReservationId,
                Guest = new GuestDTO()
                {
                    FirstName = re.Guest.FirstName,
                    LastName = re.Guest.LastName,
                    Email = re.Guest.Email,
                    Phone = re.Guest.Phone
                },
                CheckInDate = re.CheckInDate,
                CheckOutDate = re.CheckInDate,
                Status = re.Status,
                ReservationServices = re.ReservationServices.Select(rs => new ReservationServiceDTO()
                {
                    Quantity = rs.Quantity,
                    ServiceDate = rs.ServiceDate,
                    Service = new ServiceDTO()
                    {
                        ServiceId = rs.Service.ServiceId,
                        Name = rs.Service.Name,
                        Description = rs.Service.Description,
                        Price = rs.Service.Price,
                        DurationMinutes = rs.Service.DurationMinutes
                    }
                }).ToList()
            }).ToList()
        }).FirstOrDefaultAsync(r => r.RoomId ==  roomId);
        return res;
    }

    public async Task<(bool, string)> CreateGuest(GuestWithReservationDTO guestWithReservation)
    {
        using var transaction = await _context.Database.BeginTransactionAsync();

        try
        {
            var room = await _context.Rooms.Where(r=> r.RoomId == guestWithReservation.CreateReservationForGuest.RoomId).FirstOrDefaultAsync();
            if (room == null)
            {
                return (false, "Room not found");
            }

            if (DateTime.Now > guestWithReservation.CreateReservationForGuest.CheckInDate)
            {
                return (false, "Check-in dates are invalid");
            }

            Guest guest = new Guest()
            {
                FirstName = guestWithReservation.FirstName,
                LastName = guestWithReservation.LastName,
                Email = guestWithReservation.Email,
                Phone = guestWithReservation.Phone,
            };
            _context.Guests.Add(guest);
            await _context.SaveChangesAsync();

            Reservation reservation = new Reservation()
            {
                RoomId = guestWithReservation.CreateReservationForGuest.RoomId,
                GuestId = guest.Id,
                CheckInDate = guestWithReservation.CreateReservationForGuest.CheckInDate,
                CheckOutDate = null,
                Status = "nope"
            };

            _context.Add(reservation);
            await _context.SaveChangesAsync();

            await transaction.CommitAsync();
            return (true, null);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            await transaction.RollbackAsync();
            return (false, e.Message);
        }
    }
}