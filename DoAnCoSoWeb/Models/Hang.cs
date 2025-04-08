using System.ComponentModel.DataAnnotations;

namespace DoAnCoSoWeb.Models
{
    public class Hang
    {
        [Key]
        public int Id { get; set; }
        public string TenHang { get; set; }
        public string? Image { get; set; }
        public string? Mota { get; set; }
        public string? Link { get; set; }

        public List<Sanpham>? sanphams { get; set; }
    }
}
