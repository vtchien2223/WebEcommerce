namespace DoAnCoSoWeb.Models
{
    public class Account
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string MatKhau { get; set; }
        public string? AnhDaiDien { get; set;}

        public int? SoDienThoai { get; set; }

        public string? Email { get; set; }

        public string? DiaChi { get; set; }


        public int RankId { get; set; }
        public Rank? Rank { get; set; }

        public int GiohangId { get; set; }
        public Giohang? Giohang { get; set; }

        public List<ChiTietHoaDon>? ChiTietHoaDons { get; set; }
        public static Account TaoTaiKhoanMoi(string username, string matKhau, string anhDaiDien, int rankId)
        {
            var giohang = Giohang.TaoGiohangMoi();
            return new Account
            {
                Username = username,
                MatKhau = matKhau,
                AnhDaiDien = anhDaiDien,
                RankId = rankId,
                Giohang = giohang,
                GiohangId = giohang.Id
            };
        }
    }
}
