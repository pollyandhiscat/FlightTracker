using Microsoft.EntityFrameworkCore;
using FlightTracker.Models;

namespace FlightTracker.Data
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        public DbSet<Flight> Flights => Set<Flight>();
    }
}
