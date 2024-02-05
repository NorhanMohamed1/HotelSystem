using NileHotels.Resources;
using System.ComponentModel.DataAnnotations;
using System.Data;

namespace NileHotels.Models
{
    public class StoreResponsable
    {
        [Display(Name = "ID", ResourceType = typeof(Resource))]
        public int Id { get; set; }


        [Display(Name = "StartDate", ResourceType = typeof(Resource))]
        public DateTime StartDate { get; set; }


        [Display(Name = "EndDate", ResourceType = typeof(Resource))]
        public DateTime? EndDate { get; set; }

        public string InsertedBy { get; set; }
        public DateTime InsertedDate { get; set; } = DateTime.Now;
        public string? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string? DeletedBy { get; set; }
        public DateTime? DeletedDate { get; set; }


        public int StoreId { get; set; }
        public virtual Store Store { get; set; }
        public int EmployeeId { get; set; }
        public virtual Employee Employee { get; set; }

        //  public virtual ICollection<Store> Stores { get; set; }

    }
}
