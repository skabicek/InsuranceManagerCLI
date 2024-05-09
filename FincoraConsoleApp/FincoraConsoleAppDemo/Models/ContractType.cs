using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;


namespace FincoraConsoleAppDemo.Models
{
    public class ContractType
    {
        [Key, JsonIgnore]
        public Guid Id { get; set; } = Guid.NewGuid();
        public required string Name { get; set; }
        public required char InvolveVehicle { get; set; }
        [JsonIgnore]
        public virtual List<Contract> Contracts { get; } = [];
    }
}
