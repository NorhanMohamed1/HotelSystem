using System.ComponentModel.DataAnnotations;

namespace NileHotels.Models
{
    public class ServiceItem
    {
        public int Id { get; set; }
        public int Qty { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal TotalPrice { get; set; }

        public string InsertedBy { get; set; }
        public DateTime InsertedDate { get; set; } = DateTime.Now;
        public string? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string? DeletedBy { get; set; }
        public DateTime? DeletedDate { get; set; }


        public int ServiceId { get; set; }
        public virtual Service Service { get; set; }
        public int AssetId { get; set; }
        public virtual Asset Asset { get; set; }// Product


    }
}
