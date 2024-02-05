namespace NileHotels.Models
{
    public class PurchaseItem
    {
        public int Id { get; set; }
        //public int ProductId { get; set; }
        public int Quantity { get; set; }
        public float UnitPrice { get; set; }
        public float TotalPrice { get; set; }

        public string InsertedBy { get; set; }
        public DateTime InsertedDate { get; set; } = DateTime.Now;
        public string? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string? DeletedBy { get; set; }
        public DateTime? DeletedDate { get; set; }


        public int PurchaseId { get; set; }
        public Purchase Purchase { get; set; }

        public int AssetId { get; set; }
        public Asset Asset { get; set; }

        //public int RoomAssetId { get; set; }
        //public RoomAsset RoomAsset { get; set; }


    }
}
