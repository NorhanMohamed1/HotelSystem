using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NileHotels.Models
{
    public class Payment
    {

        public int Id { get; set; }
        public double Amount { get; set; }


        public string InsertedBy { get; set; }
        public DateTime InsertedDate { get; set; } = DateTime.Now;
        public string? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string? DeletedBy { get; set; }
        public DateTime? DeletedDate { get; set; }



        public int PaymentTypeId{ get; set; }
         public virtual PaymentType PaymentType { get; set; }
        public int BookingId { get; set; }
        public virtual Booking Booking { get; set; }
    }
}
