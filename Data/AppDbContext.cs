using Microsoft.EntityFrameworkCore;
using T2.Entities;

namespace T2.Data;

public class AppDbContext : DbContext
{
    protected AppDbContext() { }
    public DbSet<Room> Rooms { get; set; }
    public DbSet<Guest> Guests { get; set; }
    public DbSet<Reservation> Reservations { get; set; }
    public DbSet<Service> Services { get; set; }
    public DbSet<ReservationService> ReservationServices { get; set; }
    
    public AppDbContext(DbContextOptions options) : base(options) { }
}