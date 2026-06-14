using FlightTracker.DTO;
using FlightTracker.Models;

namespace FlightTracker.Services
{
    public interface IFlightService
    {

        Task<List<FlightResponse>> GetAllFlightsAsync();
        Task<FlightResponse?> GetFlightByIdAsync(int id);
        Task<FlightResponse> CreateFlightAsync(CreateFlightRequest flight);
        Task<bool> UpdateFlightAsync(int id, UpdateFlightRequest flight);
        Task<bool> DeleteFlightAsync(int id);
    }
}
