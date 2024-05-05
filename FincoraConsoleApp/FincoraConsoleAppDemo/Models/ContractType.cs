using System.ComponentModel.DataAnnotations;


namespace FincoraConsoleAppDemo.Models
{
    public class ContractType
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        public required string Name { get; set; }
        public required char InvolveVehicle { get; set; }
        public List<Contract> Contracts { get; } = [];
    }
}
