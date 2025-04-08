using System.ComponentModel.DataAnnotations;

namespace DoAnCoSoWeb.Models
{
    public class Truso
    {
        [Key]
        public int Id { get; set; }
        public string TenTruSo { get; set; }
        public string? ImageTruso { get; set; }
        public string? Link { get; set; }

        public List<Kho>? khos { get; set; }
    }
}
