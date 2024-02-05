
namespace NileHotels.Models
{
    public class CustomerContact
    {
        public int Id { get; set; }
        public string Value { get; set; }
        public string Description { get; set; }

        public string InsertedBy { get; set; }
        public DateTime InsertedDate { get; set; } = DateTime.Now;
        public string? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string? DeletedBy { get; set; }
        public DateTime? DeletedDate { get; set; }


        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public int ContactTypeId { get; set; }
        public ContactType ContactType { get; set; }
       
    }
}
