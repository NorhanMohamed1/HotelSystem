using NileHotels.Resources;
using System.ComponentModel.DataAnnotations;


namespace NileHotels.Models
{
    public class Vendor
    {
        [Display(Name = "ID", ResourceType = typeof(Resource))]
        public int Id { get; set; }


        [Display(Name = "NameAr", ResourceType = typeof(Resource))]
        public string NameAr { get; set; }


        [Display(Name = "NameEn", ResourceType = typeof(Resource))]
        public string NameEn { get; set; }


        [Display(Name = "VatNo", ResourceType = typeof(Resource))]
        public string VatNo { get; set; }


        [Display(Name = "AddressAr", ResourceType = typeof(Resource))]
        public string AddressAr { get; set; }


        [Display(Name = "FullAddressEn", ResourceType = typeof(Resource))]
        public string AddressEn { get; set; }


        [Display(Name = "ResponsableName", ResourceType = typeof(Resource))]
        public string ResponsableName { get; set; }
        ////
        //public string BankAccountNo { get; set; }
        //public string BankAccountName { get; set; }
        //public string BankName { get; set; }
        //public string BankBranch { get; set; }
        //public string SwiftCode { get; set; }//
        //public string Iban { get; set; }//
        //public string Notes { get; set; }
        //public string Logo { get; set; }

        public string InsertedBy { get; set; }
        public DateTime InsertedDate { get; set; } = DateTime.Now;
        public string? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string? DeletedBy { get; set; }
        public DateTime? DeletedDate { get; set; }

        //CityId
        public int CityId { get; set; }
        public virtual Country Country { get; set; }
        public int HotelId { get; set; }
        public virtual Hotel Hotel { get; set; }
        public virtual ICollection<VendorContact> VendorContacts { get; set; }
        public virtual ICollection<Contracts> Contracts { get; set; }//??
        public virtual ICollection<Purchase> Purchases { get; set; }
    }
}
