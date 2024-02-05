using NileHotels.Resources;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NileHotels.Models
{
    public class RoomAsset
    {
        [Display(Name = "ID", ResourceType = typeof(Resource))]
        public int Id { get; set; }


        [Display(Name = "Qty", ResourceType = typeof(Resource))]
        public int Qty { get; set; }

        //public string SerialNo { get; set; }
        //public string Descriptions { get; set; }
        //public DateTime? EndDate { get; set; }// ??
        public string InsertedBy { get; set; }
        public DateTime InsertedDate { get; set; } = DateTime.Now;
        public string? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string? DeletedBy { get; set; }
        public DateTime? DeletedDate { get; set; }


        public int RoomId { get; set; }
        public virtual Room Room { get; set; }
        public int AssetId { get; set; }
        public virtual Asset Asset { get; set; }
       
        public int AssetTypeId { get; set; }
        public virtual AssetType AssetType { get; set; }
         }
}
