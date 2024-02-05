using Microsoft.Extensions.Localization;
using NileHotels.Resources;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NileHotels.Models
{
    [Table("Asset")]
    public class Asset //Product
    {
        [Display(Name = "ID", ResourceType = typeof(Resource))]
        public int Id { get; set; }


        [Display(Name ="NameAr",ResourceType =typeof(Resource))]
        public string NameAr { get; set; }


        [Display(Name = "NameEn", ResourceType = typeof(Resource))]
        public string NameEn { get; set; }


        [Display(Name = "SerialNo", ResourceType = typeof(Resource))]
        public string SerialNo { get; set; }


        [Display(Name = "Decription", ResourceType = typeof(Resource))]
        public string Decription { get; set; }


        [Display(Name = "NaturelofAsset", ResourceType = typeof(Resource))]
        public string NaturelofAsset { get; set; }


        [Display(Name = "Price", ResourceType = typeof(Resource))]
        public float Price { get; set; }

        public string InsertedBy { get; set; }
        public DateTime InsertedDate { get; set; } = DateTime.Now;
        public string? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string? DeletedBy { get; set; }
        public DateTime? DeletedDate { get; set; }

        public int HotelId { get; set; }
        public virtual Hotel Hotel { get; set; }
        public int AssetTypeId { get; set; }
        public virtual AssetType AssetType { get; set; }
        public int UnitTypeId { get; set; }
        public virtual UnitType UnitType { get; set; }
        
        public virtual ICollection<RoomAsset> RoomAssets { get; set; }
        public virtual ICollection<StoreAsset> StoreAssets { get; set; }
    }
}

