using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Contracts;

namespace NileHotels.Models
{
    public class ContractRecepitVoucher 
    {

        public int Id { get; set; }
        public double Amount { get; set; }
        public string Description { get; set; }
        public string PaymentNature { get; set; }
        public DateTime PaymentDate { get; set; }
        public bool Isprocess { get; set; }
        public double TotalPrice { get; set; }
        public double TotalRemainingValue { get; set; }
        public int HotelId { get; set; }
        public string InsertedBy { get; set; }
        public DateTime InsertedDate { get; set; } = DateTime.Now;
        public String? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public String? DeletedBy { get; set; }
        public DateTime? DeletedDate { get; set; }



       
     
        public int  ContractId { get; set; }
        public virtual Contracts Contract { get; set; }
        public int PaymentTypeId { get; set; }
        public virtual PaymentType PaymentType { get; set; }

        //public int CurrencyId { get; set; }
        //public virtual Curncy Currency { get; set; }

    }
}
