using DoAnCoSoWeb.Models;

namespace DoAnCoSoWeb.ViewModels
{
    public class HomeViewModels
    {
        public List<Sanpham> sanphams { get; set; }
        public List<Comment>? Comments { get; set; }

        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public bool UserBoughtProduct { get; set; }
        public bool HasPurchased { get; set; } // Thêm trường này

        public string Query { get; set; }

        public List<Sanpham>? ram { get; set; }
        public decimal? MinPrice { get; set; }
        public decimal? MaxPrice { get; set; }

        public int[]? SelectedHangIds { get; set; }

        public string? SortOrder { get; set; }
        public List<Hang>? hangs { get; set; }

        public Dictionary<int, int> soldQuantities { get; set; }
        public List<Sanpham> SaleProducts { get; set; }
		public List<Sanpham> PCProducts { get; set; }
		public List<Sanpham> LaptopProducts { get; set; }
		public List<Sanpham> LinhKienProducts { get; set; }
		public List<Sanpham> GearProducts { get; set; }
	}
}
