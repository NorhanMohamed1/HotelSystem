using NileHotels.Resources;
using System.ComponentModel.DataAnnotations;

namespace NileHotels.Models
{
    public class Employee
    {
        [Display(Name = "ID", ResourceType = typeof(Resource))]
        public int Id { get; set; }


        [Display(Name = "NameAr", ResourceType = typeof(Resource))]
        public string NameAr { get; set; }


        [Display(Name = "NameEn", ResourceType = typeof(Resource))]
        public string NameEn { get; set; }


        [Display(Name = "BirthDate", ResourceType = typeof(Resource))]
        public DateTime BirthDate { get; set; }


        [Display(Name = "IdValue", ResourceType = typeof(Resource))]
        public int IdNumber { get; set; }

        public string InsertedBy { get; set; }
        public DateTime InsertedDate { get; set; } = DateTime.Now;
        public string? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string? DeletedBy { get; set; }
        public DateTime? DeletedDate { get; set; }



        public int HotelId { get; set; }
        public virtual Hotel Hotel { get; set; }

        public int CountryId { get; set; }
        public virtual Country Country { get; set; }
        public int IdTypeId { get; set; }
        public virtual IdType IdType { get; set; }

    }
}
