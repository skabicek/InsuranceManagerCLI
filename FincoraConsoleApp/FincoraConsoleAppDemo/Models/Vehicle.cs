using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FincoraConsoleAppDemo.Models
{
    public class Vehicle
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        public required string Brand { get; set; }
        public required string Model { get; set; }
        public required int NumberOfSeats { get; set; }
        public required string GearboxType { get; set; }
        public required string Price { get; set; }
        public List<Contract> Contracts { get; } = [];
        public required string EvidenceNumber { get; set; }
    }
}
