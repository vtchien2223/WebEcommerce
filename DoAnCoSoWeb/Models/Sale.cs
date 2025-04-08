namespace DoAnCoSoWeb.Models
{
    public class Sale
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Link { get; set; }
        public decimal? GiaSale { get; set; }
        public List<Sanpham>? sanphams { get; set; }
    }
}
