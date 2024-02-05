using NileHotels.Resources;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NileHotels.Models
{
    public class RoomRecords
    {

        [Display(Name = "ID", ResourceType = typeof(Resource))]
        public int Id { get; set; }

       
       
        public int ContractId { get; set; }
        public virtual Contracts Contract { get; set; }
        public DateTime CheckInTime { get; set; }
        public DateTime CheckOut { get; set; }
        public int Duration { get; set; }
      


        public string InsertedBy { get; set; }
        public DateTime InsertedDate { get; set; } = DateTime.Now;
        public string? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string? DeletedBy { get; set; }
        public DateTime? DeletedDate { get; set; }
        


    }
}
