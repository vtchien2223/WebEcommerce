using Microsoft.EntityFrameworkCore;
namespace DoAnCoSoWeb.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options) : base(options)
        {}
        public DbSet<Sanpham> sanphams { get; set; }
        public DbSet<Kho> khos { get; set; }
        public DbSet<Truso> trusos { get; set; }
        public DbSet<Sale> sales { get; set; }
        public DbSet<Rank> ranks { get; set; }
        public DbSet<Account> accounts { get; set; }
        public DbSet<Giohang> giohangs { get; set; }
        public DbSet<Hoadon> hoadons { get; set; }
        public DbSet<Hang> hangs { get; set; }
        public DbSet<ChiTietGioHang> chitietgiohangs { get; set; }
        public DbSet<ChiTietHoaDon> chitiethoadons { get; set; }
        public DbSet<Thongbao> thongbaos { get; set; }
        public DbSet<Hotro> hotros { get; set; }
        public DbSet<Loaisanpham> loaisanphams { get; set; }
		public DbSet<Comment> comments { get; set; }
        public DbSet<ChiTietLSHD> chiTietLSHDs { get; set; }
        public DbSet<Tinhtrangcomment> tinhtrangcomments { get; set; }
        public DbSet<contact> contacts { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<contact>().HasKey(c => c.Email); // Đặt Email là khóa chính
        }
    }
}
