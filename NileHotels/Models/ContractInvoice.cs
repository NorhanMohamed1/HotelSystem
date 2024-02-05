using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Contracts;

namespace NileHotels.Models
{
    public class ContractInvoice
    {

        public int Id { get; set; }
        public int CompanyId { get; set; }
        public bool IsCredit { get; set; }
        public decimal NetPrice { get; set; }
        public string Vat { get; set; }
        public decimal Total { get; set; }

        public string InsertedBy { get; set; }
        public DateTime InsertedDate { get; set; } = DateTime.Now;
        public string? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string? DeletedBy { get; set; }
        public DateTime? DeletedDate { get; set; }



        public int CustomerId { get; set; }
        public virtual Customer Customer { get; set; }

        public int ContractId { get; set; }
        public virtual Contracts Contract { get; set; }
        public int TaxTypeId { get; set; }
        public virtual TaxType TaxType { get; set; }
       

    }
}
