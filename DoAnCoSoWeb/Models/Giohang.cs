using System.ComponentModel.DataAnnotations;

namespace DoAnCoSoWeb.Models
{
    public class Giohang
    {
		[Key]
        public int Id { get; set; }
        public List<Sanpham>? sanphams { get; set; }
        public Account? Account { get; set; }
        public List<ChiTietGioHang>? chiTietGioHangs { get; set; }


        public static Giohang TaoGiohangMoi()
        {
            return new Giohang
            {
                sanphams = new List<Sanpham>(),
                chiTietGioHangs = new List<ChiTietGioHang>()
            };
        }
    }
}
