using FincoraConsoleAppDemo.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;


namespace FincoraConsoleAppDemo.Models
{
    public class Client : IAddressable
    {
        [Key, JsonIgnore]
        public Guid Id { get; set; } = Guid.NewGuid();
        public required string Name { get; set; }
        public required string Surname { get; set; }
        public required string Nationality { get; set; }
        public required string PhoneNumber { get; set; }
        [JsonIgnore]
        public Guid AddressID { get; set; }
        public virtual Address Address { get; set; }
        [JsonIgnore]
        public virtual List<Contract> Contracts { get; } = [];
    }
}
