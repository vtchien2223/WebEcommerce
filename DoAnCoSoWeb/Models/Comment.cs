namespace DoAnCoSoWeb.Models
{
	public class Comment
	{
		public int Id { get; set; }

		public int AccountId { get; set; }
		public Account? Account { get; set; }

		public DateTime? NgayComment { get; set; }

		public string? Note { get; set; }

        public int SanphamId { get; set; }
        public Sanpham? sanpham { get; set; }
        public List<ChiTietGioHang> chiTietGioHangs { get; set; }
        public bool? IsUserBoughtProduct { get; set; } // Thuộc tính mới

        public int TinhtrangcommentId { get; set; } // Khóa ngoại đến trạng thái bình luận
        public Tinhtrangcomment? Tinhtrangcomment { get; set; }
    }
}
