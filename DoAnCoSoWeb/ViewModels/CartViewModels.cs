using DoAnCoSoWeb.Models;

namespace DoAnCoSoWeb.ViewModels
{
    public class CartViewModels
    {
        public List<Giohang> giohangs {  get; set; }
        public List<ChiTietGioHang> chiTietGioHangs { get; set; }
        
        public List<Sanpham> sanphams { get; set; }

        public List<ChiTietHoaDon> chiTietHoaDons { get; set; }

		public List<ChiTietLSHD> chiTietLSHDs { get; set; }

        public List<Account> accounts { get; set; }
        public List<int> SelectedProducts { get; set; }
        public List<int> selectedProducts { get; set; }
        public Dictionary<int, bool> IsChecked { get; set; }

		public long? Phone { get; set; }
		public string? DiaChi { get; set; }

		public CartViewModels()
        {
            IsChecked = new Dictionary<int, bool>();
        }
    }
}
          