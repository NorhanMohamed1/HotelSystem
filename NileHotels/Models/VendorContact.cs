namespace NileHotels.Models
{
    public class VendorContact
    {
        public int Id { get; set; }
        public string Value { get; set; }
        public string Description { get; set; }

        public string InsertedBy { get; set; }
        public DateTime InsertedDate { get; set; } = DateTime.Now;
        public string? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string? DeletedBy { get; set; }
        public DateTime? DeletedDate { get; set; }



        public int VendorId { get; set; }
        public virtual Vendor Vendor { get; set; }
        public int ContactTypeId { get; set; }
        public virtual ContactType ContactType { get; set; }
    }
}
