using NileHotels.Resources;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NileHotels.Models
{
    public class Room
    {
        [Display(Name = "ID", ResourceType = typeof(Resource))]
        public int Id { get; set; }

        [Display(Name = "RoomNo", ResourceType = typeof(Resource))]
        public int RoomNo { get; set; }


        [Display(Name = "FloorNo", ResourceType = typeof(Resource))]
        public int FloorNo { get; set; }


        [Display(Name = "NormalPrice", ResourceType = typeof(Resource))]
        public float NormalPrice { get; set; }


        [Display(Name = "MinPrice", ResourceType = typeof(Resource))]
        public float MinPrice { get; set; }


        [Display(Name = "PriceWithBreakfast", ResourceType = typeof(Resource))]
        public float PriceWithBreakfast { get; set; }


        [Display(Name = "PriceWithLunch", ResourceType = typeof(Resource))]
        public float PriceWithLunch { get; set; }


        [Display(Name = "PriceWithDinner", ResourceType = typeof(Resource))]
        public float PriceWithDinner { get; set; }


        [Display(Name = "MinPriceWithBreakfast", ResourceType = typeof(Resource))]
        public float MinPriceWithBreakfast { get; set; }


        [Display(Name = "MinPriceWithLunch", ResourceType = typeof(Resource))]
        public float MinPriceWithLunch { get; set; }


        [Display(Name = "MinPriceWithDinner", ResourceType = typeof(Resource))]
        public float MinPriceWithDinner { get; set; }


        [Display(Name = "SingleBedNo", ResourceType = typeof(Resource))]
        public int SingleBedNo { get; set; }


        [Display(Name = "DoubleBedNo", ResourceType = typeof(Resource))]
        public int DoubleBedNo { get; set; }


        [Display(Name = "WcNo", ResourceType = typeof(Resource))]
        public int WcNo { get; set; }

        public string InsertedBy { get; set; }
        public DateTime InsertedDate { get; set; } = DateTime.Now;
        public string? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string? DeletedBy { get; set; }
        public DateTime? DeletedDate { get; set; }


        public int HotelId { get; set; }
        public virtual Hotel Hotel { get; set; }
        public int RoomTypeId { get; set; }
        public virtual RoomType RoomType { get; set; }

        public int RoomStatusId { get; set; }
        public virtual RoomStatus RoomStatus { get; set; }

        public virtual ICollection<Booking> Booking { get; set; }
        public virtual ICollection<RoomAsset> RoomAssets { get; set; }
        public virtual ICollection<Contracts> Contracts { get; set; }
        //public ICollection<RoomRecords> RoomRecords { get; set; }
    }
}
