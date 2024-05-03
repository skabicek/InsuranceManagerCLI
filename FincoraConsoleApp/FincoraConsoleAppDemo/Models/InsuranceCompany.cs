using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FincoraConsoleAppDemo.Models
{
    public class InsuranceCompany
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
