using FlightTracker.DTO;
using FlightTracker.Models;

namespace FlightTracker.Services
{
    public interface IFlightService
    {

        Task<List<FlightResponse>> GetAllFlightsAsync();
        Task<FlightResponse?> GetFlightByIdAsync(int id);
        Task<FlightResponse> AddFlightAsync(Flight flight);
        Task<bool> UpdateFlightAsync(int id);
        Task<bool> DeleteFlightAsync(int id);
    }
}
