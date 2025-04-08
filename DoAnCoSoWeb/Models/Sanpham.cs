using System.ComponentModel.DataAnnotations;

namespace DoAnCoSoWeb.Models
{
    public class Sanpham
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        public string TenSanPham { get; set; }
        [Range(0, 100000000.00)]
        public decimal Gia { get; set; }
        public string? Image1 { get; set; }
        public string? Image2 { get; set; }
        public string? Image3 { get; set; }
        public string? Mota { get; set; }
        public string? Link { get; set; }

        public string? ImageUrl { get; set; } // Đường dẫn đến hình ảnh đại diện
        public List<string>? ImageUrls { get; set; }

        public int KhoId { get; set; }
        public Kho? Kho { get; set; }

        public int SaleId { get; set; }
        public Sale? Sale { get; set; }

        public int HangId { get; set; }
        public Hang? hang { get; set; }

        public List<ChiTietHoaDon>? chiTietHoaDons { get; set; }

        public int LoaiId { get; set; }
        public Loaisanpham? loaisanpham { get; set; }

        public  List<Comment>? Comments { get; set; }
    }
}
