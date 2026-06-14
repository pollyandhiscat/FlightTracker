using FlightTracker.Models;
using FlightTracker.Services;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace FlightTracker.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FlightController: ControllerBase
    {

        private readonly ILogger<FlightController> Logger;

        private IFlightService Service;

        public FlightController(IFlightService service, ILogger<FlightController> logger)
        {
            Logger = logger;
            Service = service;
        }

        [HttpGet(Name = "GetAllFlights")]
        public async Task<ActionResult<List<Flight>>> Get()
        {

            return Ok(await Service.GetAllFlightsAsync());

        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<Flight?>>> GetById(int id)
        {
            
            var flight = await Service.GetFlightByIdAsync(id);

            if (flight == null)
            {

                return NotFound($"Flight with Id {id} does not exist.");
            }

            return Ok(flight);

        }
    }
}
