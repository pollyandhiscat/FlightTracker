using FlightTracker.DTO;
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
        public async Task<ActionResult<List<FlightResponse>>> Get()
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

        [HttpPost]
        public async Task<ActionResult<FlightResponse>> CreateFlight(CreateFlightRequest flightRequest)
        {

            var flight = await Service.CreateFlightAsync(flightRequest);

            return CreatedAtAction(nameof(GetById), new { id = flight.Id }, flight);

        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateFlight(int id, UpdateFlightRequest flightRequest)
        {

            var flight = await Service.UpdateFlightAsync(id, flightRequest);
            return flight ? NoContent() : NotFound($"Flight with Id {id} not found.");

        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteFlight(int id)
        {

            var flight = await Service.DeleteFlightAsync(id);
            return flight ? NoContent() : NotFound($"Flight with Id {id} not found.");

        }
    }
}
