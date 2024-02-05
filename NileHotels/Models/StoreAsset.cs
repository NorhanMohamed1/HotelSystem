using NileHotels.Resources;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NileHotels.Models
{
    public class StoreAsset
    {
        [Display(Name = "ID", ResourceType = typeof(Resource))]
        public int Id { get; set; }


        [Display(Name = "IntailQty", ResourceType = typeof(Resource))]
        public int IntailQty { get; set; }


        [Display(Name = "CurrentQty", ResourceType = typeof(Resource))]
        public int CurrentQty { get; set; }

        public string InsertedBy { get; set; }
        public DateTime InsertedDate { get; set; } = DateTime.Now;
        public string? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string? DeletedBy { get; set; }
        public DateTime? DeletedDate { get; set; }


        public int StoreId { get; set; }
        public virtual Store Store { get; set; }
        public int AssetId { get; set; }
        public virtual Asset Asset { get; set; }
        public int AssetStatusTypeId { get; set; }
        public virtual AssetStatusType AssetStatusType { get; set; }
        

    }
}
