using System.ComponentModel.DataAnnotations;


namespace FincoraConsoleAppDemo.Models
{
    public class Client
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        public required string Name { get; set; }
        public required string Surname { get; set; }
        public required string Nationality { get; set; }
        public required string PhoneNumber { get; set; }
        public Guid AddressID { get; set; }
        public Address Address { get; set; }
        public List<Contract> Contracts { get; } = [];
    }
}
