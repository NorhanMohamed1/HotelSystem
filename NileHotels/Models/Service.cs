using System.ComponentModel.DataAnnotations;

namespace NileHotels.Models
{
    public class Service
    {
        public int Id { get; set; }

        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
        public float NetPrice { get; set; }
        public float Vat { get; set; }
        public float Total { get; set; }
        public bool IsCredit { get; set; }

        public string InsertedBy { get; set; }
        public DateTime InsertedDate { get; set; } = DateTime.Now;
        public string? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string? DeletedBy { get; set; }
        public DateTime? DeletedDate { get; set; }


        public int PaymentTypeId { get; set; }
        public virtual PaymentType PaymentType { get; set; }

        public int HotelId { get; set; }
        public virtual Hotel Hotel { get; set; }

        public int CustomerId { get; set; }
        public virtual Customer Customer { get; set; }

        public int StoreId { get; set; }
        public virtual Store Store { get; set; }

        public int ContractId { get; set; }
        public virtual Contracts Contract { get; set; }
        public virtual ICollection<ServiceItem> ServiceItems { get; set; }
       
    }

}
