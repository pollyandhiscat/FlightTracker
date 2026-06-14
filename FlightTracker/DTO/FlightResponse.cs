using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace FlightTracker.DTO
{
    public class FlightResponse
    {
        public int Id { get; set; }
        public string IcaoTypeCode { get; set; } = string.Empty;
        public string TailNumber { get; set; } = String.Empty;
        public string DepartureAirport { get; set; } = String.Empty;
        public string ArrivalAirport { get; set; } = String.Empty;
        public string Ownership { get; set; } = String.Empty;
        public int RunwayRequirementFeet { get; set; }
        public DateTime DepartureTime { get; set; }

    }
}
