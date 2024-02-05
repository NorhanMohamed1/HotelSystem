namespace NileHotels.Models
{
    public class CurncyModel
    {
        public int Id { get; set; }
        public string NameAr { get; set; }
        public string NameEn { get; set; }
        public List<CurncyModel> Curncy { get; set; }
    }
}
