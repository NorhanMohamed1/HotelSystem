using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.Contracts;

namespace NileHotels.Models
{
    public class FutureReservision //Future Reservation
    {

        public int Id { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
        public bool Confirmed { get; set; }
        public DateTime ConfirmedDate { get; set; }
        public bool Reservet { get; set; }
        public DateTime ReservetDate { get; set; }

        public int Contractnum { get; set; }


        //public decimal UnitPrice { get; set; }
        //public decimal NetPrice { get; set; }

        public string InsertedBy { get; set; }
        public DateTime InsertedDate { get; set; } = DateTime.Now;
        public string? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string? DeletedBy { get; set; }
        public DateTime? DeletedDate { get; set; }


        public int CustomerId { get; set; }
        public virtual Customer Customer { get; set; }

        public int HotelId { get; set; }
        public virtual Hotel Hotel { get; set; }

        public int RoomId { get; set; }
        public virtual Room Room { get; set; }
        public int RoomTypeId { get; set; }
        public virtual RoomType RoomType { get; set; }

        public int PurposeVisitId { get; set; }
        public virtual PurposeVisit PurposeVisit { get; set; }

        //public virtual ICollection<Contracts> Contracts { get; set; }
    }
}
