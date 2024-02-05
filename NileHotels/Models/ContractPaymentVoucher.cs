using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Contracts;

namespace NileHotels.Models
{
    public class ContractPaymentVoucher 
    {
        public int Id { get; set; }
        public float Amount { get; set; }
        public string Description { get; set; }
        public string PaymentNature { get; set; }
        public DateTime PaymentDate { get; set; }
        public bool Isprocess { get; set; }
        public float TotalPrice { get; set; }
        public float TotalRemainingValue { get; set; }



        public string InsertedBy { get; set; }
        public DateTime InsertedDate { get; set; } = DateTime.Now;
        public string? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string? DeletedBy { get; set; }
        public DateTime? DeletedDate { get; set; }

        //public int HotelId { get; set; }
        public virtual Hotel Hotel { get; set; }
        public int ContractId { get; set; }
        public virtual Contracts Contract { get; set; }
        public int PaymentTypeId { get; set; } 
        public virtual PaymentType PaymentType { get; set; }

        //public int CurrencyId { get; set; }
        //public virtual Curncy Currency { get; set; }



    }
}
