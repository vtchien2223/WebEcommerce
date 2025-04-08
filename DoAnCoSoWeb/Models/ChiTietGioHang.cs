using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DoAnCoSoWeb.Models
{
	[Serializable]
	public class ChiTietGioHang
	{
		[Key]
		public int Id { get; set; }
		public int Quantity { get; set; }

		public int SanphamId { get; set; }
		public Sanpham? SanPhams { get; set; }

		public int GioHangId { get; set; }
		public Giohang? Giohang { get; set; }
	}

}
