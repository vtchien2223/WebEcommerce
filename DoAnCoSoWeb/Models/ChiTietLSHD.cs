namespace DoAnCoSoWeb.Models
{
	public class ChiTietLSHD
	{
		public int Id { get; set; }

		public int AccountId { get; set; }
		public Account? Account { get; set; }

		public int SanphamId { get; set; }
		public Sanpham? Sanpham { get; set; }
	}
}
