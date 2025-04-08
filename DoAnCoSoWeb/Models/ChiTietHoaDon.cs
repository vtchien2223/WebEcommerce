using System.ComponentModel.DataAnnotations;

namespace DoAnCoSoWeb.Models
{
    public class ChiTietHoaDon
    {
        [Key]
        public int Id { get; set; }

        public int SanphamId { get; set; }  
        public Sanpham? SanPhams { get; set; }

        public int HoaDonId { get; set; }
        public Hoadon? Hoadon { get; set; }


        [Range(1, int.MaxValue)]
        public int SoLuong { get; set; }

        [Range(0, 100000000.00)]
        public decimal ThanhTien { get; set; }

        public int AccountId { get; set; }
        public Account? Account { get; set; } 

        public long? Phone {  get; set; }
        public string? DiaChi { get; set; }
    }


}
