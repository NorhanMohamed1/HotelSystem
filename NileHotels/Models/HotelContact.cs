using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NileHotels.Models
{
    public class HotelContact
    {
        public int Id { get; set; }
        public string Value { get; set; }
        public bool IsDefault { get; set; }
        public string Description { get; set; }

        public string InsertedBy { get; set; }
        public DateTime InsertedDate { get; set; } = DateTime.Now;
        public string? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string? DeletedBy { get; set; }
        public DateTime? DeletedDate { get; set; }


        public int HotelId { get; set; }
        public virtual Hotel Hotel { get; set; }
        public int ContactTypeId { get; set; }
        public virtual ContactType ContactType { get; set; }
    }
    public class HotelContactModal
    {
        public int Id { get; set; }
        public int HotelId { get; set; }
        public int ContactTypeId { get; set; }
       
        public string hotelar { get; set; }
        public string hotelen { get; set; }
        public string Value { get; set; }
        public string typear { get; set; }
        public string typeen { get; set; }

    }

}
