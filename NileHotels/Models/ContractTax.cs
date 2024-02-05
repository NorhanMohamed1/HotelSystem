using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Contracts;

namespace NileHotels.Models
{
    public class ContractTax
    {
        public int Id { get; set; }
        public float Value { get; set; }

        public string InsertedBy { get; set; }
        public DateTime InsertedDate { get; set; } = DateTime.Now;
        public string? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string? DeletedBy { get; set; }
        public DateTime? DeletedDate { get; set; }


        public int ContractId { get; set; }
        public virtual Contracts Contract { get; set; }
        public int TaxTypeId { get; set; }
        public virtual TaxType TaxType { get; set; }
    }
}

