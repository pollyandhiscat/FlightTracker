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
                Id = f.Id,
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
                    Id = f.Id,
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

        public async Task<FlightResponse> CreateFlightAsync(CreateFlightRequest flight)
        {
            // Map data from new flight request to a Flight model.
            var newFlight = new Flight
            {

                IcaoTypeCode = flight.IcaoTypeCode,
                TailNumber = flight.TailNumber,
                DepartureAirport = flight.DepartureAirport,
                ArrivalAirport = flight.ArrivalAirport,
                Ownership = flight.Ownership,
                RunwayRequirementFeet = flight.RunwayRequirementFeet,
                DepartureTime = flight.DepartureTime

            };

            context.Flights.Add(newFlight);

            // EF Core will handle Id assignment.
            await context.SaveChangesAsync();

            // Map newly created Flight model data to a response DTO.
            return new FlightResponse
            {
                Id = newFlight.Id,
                IcaoTypeCode = newFlight.IcaoTypeCode,
                TailNumber = newFlight.TailNumber,
                DepartureAirport = newFlight.DepartureAirport,
                ArrivalAirport = newFlight.ArrivalAirport,
                Ownership = newFlight.Ownership,
                RunwayRequirementFeet = newFlight.RunwayRequirementFeet,
                DepartureTime = newFlight.DepartureTime

            };
            
        }

        public async Task<bool> UpdateFlightAsync(int id, UpdateFlightRequest flight)
        {
            var existingFlight = await context.Flights.FindAsync(id);
            if (existingFlight == null)
            {
                return false;
            }

            if (!string.IsNullOrWhiteSpace(flight.IcaoTypeCode)) existingFlight.IcaoTypeCode = flight.IcaoTypeCode;
            if (!string.IsNullOrWhiteSpace(flight.TailNumber)) existingFlight.TailNumber = flight.TailNumber;
            if (!string.IsNullOrWhiteSpace(flight.DepartureAirport)) existingFlight.DepartureAirport = flight.DepartureAirport;
            if (!string.IsNullOrWhiteSpace(flight.ArrivalAirport)) existingFlight.ArrivalAirport = flight.ArrivalAirport;
            if (!string.IsNullOrWhiteSpace(flight.Ownership)) existingFlight.Ownership = flight.Ownership;

            existingFlight.RunwayRequirementFeet = flight.RunwayRequirementFeet ?? existingFlight.RunwayRequirementFeet;
            existingFlight.DepartureTime = flight.DepartureTime ?? existingFlight.DepartureTime;

            await context.SaveChangesAsync();
            return true;

        }

        public async Task<bool> DeleteFlightAsync(int id)
        {

            var existingFlight = await context.Flights.FindAsync(id);
            if (existingFlight == null)
            {
                return false;
            }

            context.Flights.Remove(existingFlight);
            await context.SaveChangesAsync();
            return true;

        }

    }
}
