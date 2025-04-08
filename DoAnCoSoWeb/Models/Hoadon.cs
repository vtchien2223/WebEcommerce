using System.ComponentModel.DataAnnotations;

namespace DoAnCoSoWeb.Models
{
    public class Hoadon
    {
        public int Id { get; set; }
        public DateTime? NgayLap { get; set; }
        public DateTime? NgayThanhToan { get; set; }
        [Range(0, int.MaxValue)]
        public decimal? TongTien { get; set; }

        public List<ChiTietHoaDon> chiTietHoaDons { get; set; }
    }
}
