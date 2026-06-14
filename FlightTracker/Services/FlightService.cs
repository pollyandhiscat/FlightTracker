using FlightTracker.Data;
using FlightTracker.DTO;
using FlightTracker.Models;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace FlightTracker.Services
{
    public class FlightService(AppDbContext context) : IFlightService
    {
        public async Task<List<FlightResponse>> GetAllFlightsAsync()
        {
            // Map the EF Core select query result to our DTO object.
            return await context.Flights.Select(f => new FlightResponse
            {

                IcaoTypeCode = f.IcaoTypeCode,
                TailNumber = f.TailNumber,
                DepartureAirport = f.DepartureAirport,
                ArrivalAirport = f.ArrivalAirport,
                Ownership = f.Ownership,
                RunwayRequirementFeet = f.RunwayRequirementFeet,
                DepartureTime = f.DepartureTime
            }).ToListAsync();

        }

        public async Task<FlightResponse?> GetFlightByIdAsync(int id)
        {
            var flight = await context.Flights
                .Where(f => f.Id == id)
                .Select(f => new FlightResponse
                {

                    IcaoTypeCode = f.IcaoTypeCode,
                    TailNumber = f.TailNumber,
                    DepartureAirport = f.DepartureAirport,
                    ArrivalAirport = f.ArrivalAirport,
                    Ownership = f.Ownership,
                    RunwayRequirementFeet = f.RunwayRequirementFeet,
                    DepartureTime = f.DepartureTime
                })
                .FirstOrDefaultAsync();
            
            return flight;
        }

        public Task<FlightResponse> AddFlightAsync(Flight flight)
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
