namespace NileHotels.Models
{
    public class Purchase
    {
        public int Id { get; set; }
        public DateTime PurchaseDate { get; set; }
        //public int InvoiceNo { get; set; }// will delete
        public float NetPrice { get; set; }
        public string Vat { get; set; }
        public float TotalPrice { get; set; }

        public string InsertedBy { get; set; }
        public DateTime InsertedDate { get; set; } = DateTime.Now;
        public string? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string? DeletedBy { get; set; }
        public DateTime? DeletedDate { get; set; }


        public int HotelId { get; set; }
        public Hotel Hotel { get; set; }
        public int VendorId { get; set; }
        public Vendor Vendor { get; set; }
        //public int StoreId { get; set; }
        //public Store Store { get; set; }
        public ICollection<PurchaseItem> PurchaseItems { get; set; }
    }
}
