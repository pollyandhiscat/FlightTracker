using FlightTracker.Models;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace FlightTracker.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FlightController : ControllerBase
    {
        private static readonly Flight[] flights = new[]
        {
            new Flight { Id = 1, IcaoTypeCode = "GLF6", TailNumber = "N1KE", DepartureAirport = "PDX", ArrivalAirport = "JFK", Ownership = Flight.OwnershipTypes.CHARTER.ToString(), RunwayRequirementFeet = 5858, DepartureTime = DateTime.Now },
            new Flight { Id = 2, IcaoTypeCode = "CL35", TailNumber = "CL35", DepartureAirport = "PBI", ArrivalAirport = "VNY", Ownership = Flight.OwnershipTypes.FRACTIONAL.ToString(), RunwayRequirementFeet = 4835, DepartureTime = DateTime.Now },
            new Flight { Id = 3, IcaoTypeCode = "E55P", TailNumber = "N550QS", DepartureAirport = "SEA", ArrivalAirport = "LAX", Ownership = Flight.OwnershipTypes.SOLE.ToString(), RunwayRequirementFeet = 3138, DepartureTime = DateTime.Now },

        };

        private readonly ILogger<FlightController> Logger;

        public FlightController(ILogger<FlightController> logger)
        {
            Logger = logger;
        }

        [HttpGet(Name = "GetAllFlights")]
        public ActionResult<IEnumerable<Flight>> Get()
        {
            
            return Ok(flights);

        }
    }
}
