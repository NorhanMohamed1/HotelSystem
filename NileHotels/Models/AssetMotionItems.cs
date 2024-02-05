namespace NileHotels.Models
{
    public class AssetMotionItems // transProduct
    {
        public int Id { get; set; }
       
        public int Qty { get; set; }

        public string InsertedBy { get; set; }
        public DateTime InsertedDate { get; set; } = DateTime.Now;
        public string? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string? DeletedBy { get; set; }
        public DateTime? DeletedDate { get; set; }

        public int  StoreMotionId { get; set; }
        public virtual StoreMotion StoreMotion { get; set; }

        public int AssetId { get; set; }
        public virtual Asset Asset { get; set; }



    }
}
