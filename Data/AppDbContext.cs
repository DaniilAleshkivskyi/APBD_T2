using Microsoft.EntityFrameworkCore;
namespace T2.Data;

public class AppDbContext : DbContext
{
    
    
    protected AppDbContext() { }
    public AppDbContext(DbContextOptions options) : base(options) { }
}