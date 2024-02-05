using NileHotels.Resources;
using System.ComponentModel.DataAnnotations;

namespace NileHotels.Models
{
    public class Company
    {
        [Display(Name = "ID", ResourceType = typeof(Resource))]
        public int Id { get; set; }



        [Display(Name = "NameAr", ResourceType = typeof(Resource))]
        public string NameAr { get; set; }




        [Display(Name = "NameEn", ResourceType = typeof(Resource))]
        public string NameEn { get; set; }



        [Display(Name = "FullAddressAr", ResourceType = typeof(Resource))]
        public string FullAddressAr { get; set; }//Streat



        [Display(Name = "FullAddressEn", ResourceType = typeof(Resource))]
        public string FullAddressEn { get; set; }




        [Display(Name = "ZipeCode", ResourceType = typeof(Resource))]
        public string ZipeCode { get; set; }




        [Display(Name = "VatNo", ResourceType = typeof(Resource))]
        public string VatNo { get; set; }



        [Display(Name = "BuildingNo", ResourceType = typeof(Resource))]
        public string BuildingNo { get; set; }



        [Display(Name = "ResponsableName", ResourceType = typeof(Resource))]
        public string ResponsableName { get; set; }

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

        public virtual ICollection<CompanyContact> CompanyContact { get; set; }
    }
}
