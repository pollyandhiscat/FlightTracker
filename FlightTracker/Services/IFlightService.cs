using FlightTracker.Models;

namespace FlightTracker.Services
{
    public interface IFlightService
    {

        Task<List<Flight>> GetAllFlightsAsync();
        Task<Flight> GetFlightByIdAsync(int id);
        Task<Flight> AddFlightAsync(Flight flight);
        Task<bool> UpdateFlightAsync(int id);
        Task<bool> DeleteFlightAsync(int id);
    }
}
