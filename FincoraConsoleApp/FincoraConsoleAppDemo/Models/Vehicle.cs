using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace FincoraConsoleAppDemo.Models
{
    public class Vehicle
    {
        [Key, JsonIgnore]
        public Guid Id { get; set; } = Guid.NewGuid();
        public required string Brand { get; set; }
        public required string Model { get; set; }
        public required string YearOfManufacture { get; set; }
        public required string Price { get; set; }
        [JsonIgnore]
        public virtual List<Contract> Contracts { get; } = [];
        public required string EvidenceNumber { get; set; }
    }
}
