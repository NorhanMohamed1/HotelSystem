using System;
using System.ComponentModel.DataAnnotations;
using System.Net;

namespace NileHotels.Models
{
    public class PurchaseViewModel
    {
        // Purchases
        public int Id { get; set; }

        [DataType(DataType.Date)]
        public DateTime PurchaseDate { get; set; }
        
        public float NetPrice { get; set; }
        public string Vat { get; set; }
        public float Total  { get; set; } //TotalPrice

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


        //ServiceItemId
        public int PurchasesId { get; set; } 
        public int[] Quantity { get; set; }
        public float[] UnitPrice { get; set; }
        public float[] TotalPrice { get; set; }


        public int PurchaseId { get; set; }
        public Purchase Purchase { get; set; }
         
        public int[] AssetId { get; set; }
        public virtual Asset Asset { get; set; }
        










    }
}
