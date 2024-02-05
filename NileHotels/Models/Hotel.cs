using Microsoft.Extensions.Localization;
using NileHotels.Resources;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Numerics;

namespace NileHotels.Models
{
    public class Hotel
    {
        [Display(Name = "ID", ResourceType = typeof(Resource))]
        public int Id { get; set; }

        [Display(Name = "NameAr", ResourceType = typeof(Resource))]
        public string NameAr { get; set; }

        [Display(Name = "NameEn", ResourceType = typeof(Resource))]
        public string NameEn { get; set; }

        [Display(Name = "FloorsNo", ResourceType = typeof(Resource))]
        public int FloorNo { get; set; }

        [Display(Name = "RoomsNo", ResourceType = typeof(Resource))]
        public int RoomNo { get; set; }

        [Display(Name = "FullAddressAr", ResourceType = typeof(Resource))]
        public string FullAddressAr { get; set; }//Streat

        [Display(Name = "FullAddressEn", ResourceType = typeof(Resource))]
        public string FullAddressEn { get; set; }

        [Display(Name = "gps", ResourceType = typeof(Resource))]
        public string gps { get; set; }//location

        [Display(Name = "BuildingNo", ResourceType = typeof(Resource))]
        public string BuildingNo { get; set; }

        [Display(Name = "PostBox", ResourceType = typeof(Resource))]
        public string PostBox { get; set; } //

        [Display(Name = "ZipeCode", ResourceType = typeof(Resource))]
        public string ZipeCode { get; set; }

        [Display(Name = "CheckInTime", ResourceType = typeof(Resource))]
        public DateTime CheckInTime { get; set; }

        [Display(Name = "CheckOut", ResourceType = typeof(Resource))]
        public DateTime CheckOut { get; set; }

        [Display(Name = "ActualCheckOut", ResourceType = typeof(Resource))]
        public DateTime ActualCheckOut { get; set; }

        [Display(Name = "VatNo", ResourceType = typeof(Resource))]
        public string VatNo { get; set; }

        [Display(Name = "CR", ResourceType = typeof(Resource))]
        public string CR { get; set; }

        [Display(Name = "Logo", ResourceType = typeof(Resource))]
        public string Logo { get; set; }

        public string InsertedBy { get; set; }
        public DateTime InsertedDate { get; set; } = DateTime.Now;
        public string? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string? DeletedBy { get; set; }
        public DateTime? DeletedDate { get; set; }

        //CityId*

        [Display(Name = "CountryId", ResourceType = typeof(Resource))]
        public int CountryId { get; set; }
        public virtual Country Country { get; set; }

        public virtual ICollection<HotelContact> HotelContact { get; set; }
        public virtual ICollection<Employee> Employee { get; set; }
        public virtual ICollection<Room> Rooms { get; set; }
        public virtual ICollection<Vendor> Vendors { get; set; }
        public virtual ICollection<Service> Services { get; set; }
        public virtual ICollection<Contracts> Contracts { get; set; }
        public virtual ICollection<Asset> Asset { get; set; }
        public virtual ICollection<Customer> Customer { get; set; }
        public virtual ICollection<TaxType> TaxType { get; set; }
        public virtual ICollection<ContractPaymentVoucher> ContractPaymentVoucher { get; set; }
 

    }

}
