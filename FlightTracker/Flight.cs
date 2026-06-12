using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace FlightTracker
{
    public class Flight
    {

        [JsonConverter(typeof(JsonStringEnumConverter))]
        public enum OwnershipTypes { SOLE, FRACTIONAL, CHARTER };

        public int Id { get; set; }

        // International Civil Aviation Organization code.
        [StringLength(4, MinimumLength = 2)]
        public string IcaoTypeCode { get; set; } = string.Empty;

        // Tail numbers should not be lowercase and contain invalid characters like underscores.
        [RegularExpression(@"^[A-Z0-9-]+$", ErrorMessage = "Invalid tail number format.")]
        public string TailNumber { get; set; } = String.Empty;

        public string DepartureAirport { get; set; } = String.Empty;
        public string ArrivalAirport { get; set; } = String.Empty;
        public string Ownership { get; set; } = String.Empty;
        public int RunwayRequirementFeet { get; set; }
        public DateTime DepartureTime { get; set; }

    }

}
