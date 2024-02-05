using NileHotels.Resources;
using System.ComponentModel.DataAnnotations;

namespace NileHotels.Models
{
    public class TaxType
    {
        [Display(Name = "ID", ResourceType = typeof(Resource))]
        public int Id { get; set; }


        [Display(Name = "NameAr", ResourceType = typeof(Resource))]
        public string NameAr { get; set; }


        [Display(Name = "NameEn", ResourceType = typeof(Resource))]
        public string NameEn { get; set; }


        [Display(Name = "IsFixed", ResourceType = typeof(Resource))]
        public bool IsFixed { get; set; }


        [Display(Name = "Value", ResourceType = typeof(Resource))]
        public float Value { get; set; }


        [Display(Name = "ContractOnly", ResourceType = typeof(Resource))]
        public bool ContractOnly { get; set; }

        public string InsertedBy { get; set; }
        public DateTime InsertedDate { get; set; } = DateTime.Now;
        public string? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string? DeletedBy { get; set; }
        public DateTime? DeletedDate { get; set; }

        public int HotelId { get; set; }
        public virtual Hotel Hotel { get; set; }
        public virtual ICollection<ContractTax> ContractTaxes { get; set; }
    }
}
