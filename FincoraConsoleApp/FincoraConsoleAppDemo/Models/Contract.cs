using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;


namespace FincoraConsoleAppDemo.Models
{
    public class Contract
    {
        [Key, JsonIgnore]
        public Guid Id { get; set; } = Guid.NewGuid();
        public DateOnly SignDate { get; set; } //Current date by default
        public string Status { get; set; } //Active by default
        [JsonIgnore]
        public Guid ContractTypeId { get; set; }
        public virtual ContractType ContractType { get; set; }
        [JsonIgnore]
        public Guid ClientId { get; set; }
        public virtual Client Client { get; set; }
        [JsonIgnore]
        public Guid InsuranceCompanyId { get; set; }
        public virtual InsuranceCompany InsuranceCompany { get; set; }
        [JsonIgnore]
        public Nullable<Guid> VehicleId { get; set; }
        public virtual Vehicle Vehicle { get; set; }
    }
}
