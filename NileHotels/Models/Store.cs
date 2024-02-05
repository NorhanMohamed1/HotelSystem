using NileHotels.Resources;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NileHotels.Models
{
    public class Store
    {
        [Display(Name = "ID", ResourceType = typeof(Resource))]
        public int Id { get; set; }


        [Display(Name = "NameAr", ResourceType = typeof(Resource))]
        public string NameAr { get; set; }


        [Display(Name = "NameEn", ResourceType = typeof(Resource))]
        public string NameEn { get; set; }

        //public string Address { get; set; }
        //public string Phone { get; set; }
        //public string Email { get; set; }
        //public string ContactPerson { get; set; }

        public string InsertedBy { get; set; }
        public DateTime InsertedDate { get; set; } = DateTime.Now;
        public string? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string? DeletedBy { get; set; }
        public DateTime? DeletedDate { get; set; }


        public int HotelId { get; set; }
        public virtual Hotel Hotel { get; set; }

        public virtual ICollection<StoreResponsable> StoreResponsables { get; set; }
        public virtual ICollection<Service> Service { get; set; }
        public virtual ICollection<Purchase> Purchases { get; set; }
        public virtual ICollection<StoreAsset> StoreAssets { get; set; }
    }
}
