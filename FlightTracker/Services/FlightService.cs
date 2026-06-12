using FlightTracker.Models;

namespace FlightTracker.Services
{
    public class FlightService : IFlightService
    {

        private static readonly List<Flight> flights = new List<Flight>
{
            new Flight { Id = 1, IcaoTypeCode = "GLF6", TailNumber = "N1KE", DepartureAirport = "PDX", ArrivalAirport = "JFK", Ownership = Flight.OwnershipTypes.CHARTER.ToString(), RunwayRequirementFeet = 5858, DepartureTime = DateTime.Now },
            new Flight { Id = 2, IcaoTypeCode = "CL35", TailNumber = "CL35", DepartureAirport = "PBI", ArrivalAirport = "VNY", Ownership = Flight.OwnershipTypes.FRACTIONAL.ToString(), RunwayRequirementFeet = 4835, DepartureTime = DateTime.Now },
            new Flight { Id = 3, IcaoTypeCode = "E55P", TailNumber = "N550QS", DepartureAirport = "SEA", ArrivalAirport = "LAX", Ownership = Flight.OwnershipTypes.SOLE.ToString(), RunwayRequirementFeet = 3138, DepartureTime = DateTime.Now },

        };

        public async Task<List<Flight>> GetAllFlightsAsync()
        {

            return await Task.FromResult(flights);

        }

        public Task<Flight> GetFlightByIdAsync(int id)
        {

            throw new NotImplementedException();
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
