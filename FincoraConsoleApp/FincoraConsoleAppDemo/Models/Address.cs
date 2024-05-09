using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace FincoraConsoleAppDemo.Models
{
    public class Address
    {
        [Key, JsonIgnore]
        public Guid Id { get; set; } = Guid.NewGuid();
        public required string Country { get; set; }
        public required string City { get; set; }
        public required string PostalCode { get; set; }
        public required string Street { get; set; }
        public required string HouseNumber { get; set; }
        [JsonIgnore]
        public virtual List<Client> Clients { get; } = [];
        [JsonIgnore]
        public virtual List<InsuranceCompany> InsuranceCompanys { get; } = [];
    }
}
