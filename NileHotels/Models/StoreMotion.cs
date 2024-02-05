namespace NileHotels.Models
{
    public class StoreMotion  //Transportation
    {     
        public int Id { get; set; }
        public string MotionType { get; set; }
        public DateTime MotionDate { get; set; }
        public string Description { get; set; }
        public bool Iscomplete { get; set; }
        public string InsertedBy { get; set; }
        public DateTime InsertedDate { get; set; } = DateTime.Now;
        public string? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string? DeletedBy { get; set; }
        public DateTime? DeletedDate { get; set; }


        public int HotelId { get; set; }
        public virtual Hotel Hotel { get; set; }

    }
}
