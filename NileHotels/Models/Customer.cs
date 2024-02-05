using NileHotels.Resources;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NileHotels.Models
{
    public class Customer
    {
        [Display(Name = "ID", ResourceType = typeof(Resource))]
        public int Id { get; set; }


        [Display(Name = "FirstName", ResourceType = typeof(Resource))]
        public string FirstName { get; set; }


        [Display(Name = "LastName", ResourceType = typeof(Resource))]
        public string LastName { get; set; }


        [Display(Name = "IsShare", ResourceType = typeof(Resource))]
        public bool IsShare { get; set; }


        [Display(Name = "IsCompony", ResourceType = typeof(Resource))]
        public bool IsCompony { get; set; }


        [Display(Name = "IdValue", ResourceType = typeof(Resource))]
        public string IdValue { get; set; }

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

        public virtual ICollection<Service> Service { get; set; }
        public virtual ICollection<ContractInvoice> ContractInvoices { get; set; }
        public virtual ICollection<Booking> Bookings { get; set; }
    }
}
