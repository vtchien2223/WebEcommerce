using System.ComponentModel.DataAnnotations;

namespace DoAnCoSoWeb.Models
{
    public class Kho
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        public string TenKho { get; set; }
        public string? ImageKho { get; set; }
        public string? link { get; set; }

        public int? TrusoId { get; set; }
        public Truso? Truso { get; set; }
        public List<Sanpham>? sanphams { get; set; }
    }
}
