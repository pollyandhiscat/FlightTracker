using FlightTracker.Data;
using FlightTracker.Models;
using Microsoft.EntityFrameworkCore;

namespace FlightTracker.Services
{
    public class FlightService(AppDbContext context) : IFlightService
    {
        public async Task<List<Flight>> GetAllFlightsAsync()
        {

            return await context.Flights.ToListAsync();

        }

        public async Task<Flight?> GetFlightByIdAsync(int id)
        {
            var flight = await context.Flights.FindAsync(id);
            return flight;
        }

        public Task<Flight> AddFlightAsync(Flight flight)
        {

            throw new NotImplementedException();
        }

        public Task<bool> UpdateFlightAsync(int id)
        {

            throw new NotImplementedException();
        }

        public Task<bool> DeleteFlightAsync(int id)
        {

            throw new NotImplementedException();
        }

    }
}
