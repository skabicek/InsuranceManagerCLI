using FincoraConsoleAppDemo.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace FincoraConsoleAppDemo.Models
{
    public class InsuranceCompany : IAddressable
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        public required string Name { get; set; }
        public required string PhoneNumber { get; set; }
        public Guid AddressId { get; set; }
        public Address Address { get; set; }
        public List<Contract> Contracts { get; } = [];
    }
}
