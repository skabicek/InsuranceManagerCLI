using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FincoraConsoleAppDemo.Models
{
    public class Contract
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        public DateOnly SignDate { get; set; } //Current date by default
        public string Status { get; set; } //Active by default
        public Guid ContractTypeId { get; set; }
        public ContractType ContractType { get; set; }
        public Guid ClientId { get; set; }
        public Client Client { get; set; }
        public Guid InsuranceCompanyId { get; set; }
        public InsuranceCompany InsuranceCompany { get; set; }
        public Nullable<Guid> VehicleId { get; set; }
        public Vehicle Vehicle { get; set; }
    }
}
