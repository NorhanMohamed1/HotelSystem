namespace NileHotels.Models
{
    public class Contracts
    {
        public int Id { get; set; }
        public DateTime CheckInTime { get; set; }
        public DateTime CheckOut { get; set; }
        public int  Duration { get; set; }//
        public decimal UnitPrice { get; set; }
        public decimal NetPrice { get; set; }
        public int CountofPerson { get; set; }
        public decimal TotalVat { get; set; }
        public float TotalPrice { get; set; }
        public int Status { get; set; }

         
        public bool IsHospitalityContract { get; set; }

        public string InsertedBy { get; set; }
        public DateTime InsertedDate { get; set; } = DateTime.Now;
        public string? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string? DeletedBy { get; set; }
        public DateTime? DeletedDate { get; set; }


        public int HotelId { get; set; }
        public virtual Hotel Hotel { get; set; }
        public int RoomId { get; set; }
        public virtual Room Room { get; set; }
        public int CustomerId { get; set; }
        public virtual Customer Customer { get; set; }
        public int PurposeVisitId { get; set; }
        public virtual PurposeVisit PurposeVisit { get; set; }


        //public int FutureReservisionId { get; set; }
        //public virtual FutureReservision FutureReservision { get; set; }// make it contract in fr as a atribute

        //public int VendorId { get; set; }
        //public virtual Vendor Vendor { get; set; }

        public virtual ICollection<ContractInvoice> ContractInvoices { get; set; }
        public virtual ICollection<ContractTax> ContractTaxes { get; set; }
        public virtual ICollection<ContractRecepitVoucher> ContractRecepitVouchers { get; set; }
        public virtual ICollection<ContractPaymentVoucher> ContractPaymentVouchers { get; set; }










    }
}
