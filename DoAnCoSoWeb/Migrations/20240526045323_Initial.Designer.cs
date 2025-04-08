﻿// <auto-generated />
using System;
using DoAnCoSoWeb.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DoAnCoSoWeb.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240526045323_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("DoAnCoSoWeb.Models.Account", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("AnhDaiDien")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DiaChi")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("GiohangId")
                        .HasColumnType("int");

                    b.Property<string>("MatKhau")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RankId")
                        .HasColumnType("int");

                    b.Property<int?>("SoDienThoai")
                        .HasColumnType("int");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("GiohangId")
                        .IsUnique();

                    b.HasIndex("RankId");

                    b.ToTable("accounts");
                });

            modelBuilder.Entity("DoAnCoSoWeb.Models.ChiTietGioHang", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("CommentId")
                        .HasColumnType("int");

                    b.Property<int>("GioHangId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<int>("SanphamId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CommentId");

                    b.HasIndex("GioHangId");

                    b.HasIndex("SanphamId");

                    b.ToTable("chitietgiohangs");
                });

            modelBuilder.Entity("DoAnCoSoWeb.Models.ChiTietHoaDon", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AccountId")
                        .HasColumnType("int");

                    b.Property<string>("DiaChi")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("HoaDonId")
                        .HasColumnType("int");

                    b.Property<long?>("Phone")
                        .HasColumnType("bigint");

                    b.Property<int>("SanphamId")
                        .HasColumnType("int");

                    b.Property<int>("SoLuong")
                        .HasColumnType("int");

                    b.Property<decimal>("ThanhTien")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("AccountId");

                    b.HasIndex("HoaDonId");

                    b.HasIndex("SanphamId");

                    b.ToTable("chitiethoadons");
                });

            modelBuilder.Entity("DoAnCoSoWeb.Models.ChiTietLSHD", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AccountId")
                        .HasColumnType("int");

                    b.Property<int>("SanphamId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AccountId");

                    b.HasIndex("SanphamId");

                    b.ToTable("chiTietLSHDs");
                });

            modelBuilder.Entity("DoAnCoSoWeb.Models.Comment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AccountId")
                        .HasColumnType("int");

                    b.Property<bool?>("IsUserBoughtProduct")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("NgayComment")
                        .HasColumnType("datetime2");

                    b.Property<string>("Note")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SanphamId")
                        .HasColumnType("int");

                    b.Property<int>("TinhtrangcommentId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AccountId");

                    b.HasIndex("SanphamId");

                    b.HasIndex("TinhtrangcommentId");

                    b.ToTable("comments");
                });

            modelBuilder.Entity("DoAnCoSoWeb.Models.Giohang", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.HasKey("Id");

                    b.ToTable("giohangs");
                });

            modelBuilder.Entity("DoAnCoSoWeb.Models.Hang", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Link")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Mota")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TenHang")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("hangs");
                });

            modelBuilder.Entity("DoAnCoSoWeb.Models.Hoadon", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("NgayLap")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("NgayThanhToan")
                        .HasColumnType("datetime2");

                    b.Property<decimal?>("TongTien")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("hoadons");
                });

            modelBuilder.Entity("DoAnCoSoWeb.Models.Hotro", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("HienThi")
                        .HasColumnType("int");

                    b.Property<string>("MoTa")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Ten")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ThuTu")
                        .HasColumnType("int");

                    b.Property<string>("link")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("hotros");
                });

            modelBuilder.Entity("DoAnCoSoWeb.Models.Kho", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ImageKho")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TenKho")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<int?>("TrusoId")
                        .HasColumnType("int");

                    b.Property<string>("link")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("TrusoId");

                    b.ToTable("khos");
                });

            modelBuilder.Entity("DoAnCoSoWeb.Models.Loaisanpham", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("loaisanphams");
                });

            modelBuilder.Entity("DoAnCoSoWeb.Models.Rank", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("TenRank")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ranks");
                });

            modelBuilder.Entity("DoAnCoSoWeb.Models.Sale", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<decimal?>("GiaSale")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Link")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("sales");
                });

            modelBuilder.Entity("DoAnCoSoWeb.Models.Sanpham", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<decimal>("Gia")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int?>("GiohangId")
                        .HasColumnType("int");

                    b.Property<int>("HangId")
                        .HasColumnType("int");

                    b.Property<string>("Image1")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Image2")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Image3")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageUrls")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("KhoId")
                        .HasColumnType("int");

                    b.Property<string>("Link")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("LoaiId")
                        .HasColumnType("int");

                    b.Property<string>("Mota")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SaleId")
                        .HasColumnType("int");

                    b.Property<string>("TenSanPham")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<int?>("loaisanphamId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("GiohangId");

                    b.HasIndex("HangId");

                    b.HasIndex("KhoId");

                    b.HasIndex("SaleId");

                    b.HasIndex("loaisanphamId");

                    b.ToTable("sanphams");
                });

            modelBuilder.Entity("DoAnCoSoWeb.Models.Thongbao", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Link")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MoTa")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Ten")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("thongbaos");
                });

            modelBuilder.Entity("DoAnCoSoWeb.Models.Tinhtrangcomment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("tinhtrangcomments");
                });

            modelBuilder.Entity("DoAnCoSoWeb.Models.Truso", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ImageTruso")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Link")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TenTruSo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("trusos");
                });

            modelBuilder.Entity("DoAnCoSoWeb.Models.Account", b =>
                {
                    b.HasOne("DoAnCoSoWeb.Models.Giohang", "Giohang")
                        .WithOne("Account")
                        .HasForeignKey("DoAnCoSoWeb.Models.Account", "GiohangId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DoAnCoSoWeb.Models.Rank", "Rank")
                        .WithMany("Accounts")
                        .HasForeignKey("RankId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Giohang");

                    b.Navigation("Rank");
                });

            modelBuilder.Entity("DoAnCoSoWeb.Models.ChiTietGioHang", b =>
                {
                    b.HasOne("DoAnCoSoWeb.Models.Comment", null)
                        .WithMany("chiTietGioHangs")
                        .HasForeignKey("CommentId");

                    b.HasOne("DoAnCoSoWeb.Models.Giohang", "Giohang")
                        .WithMany("chiTietGioHangs")
                        .HasForeignKey("GioHangId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DoAnCoSoWeb.Models.Sanpham", "SanPhams")
                        .WithMany()
                        .HasForeignKey("SanphamId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Giohang");

                    b.Navigation("SanPhams");
                });

            modelBuilder.Entity("DoAnCoSoWeb.Models.ChiTietHoaDon", b =>
                {
                    b.HasOne("DoAnCoSoWeb.Models.Account", "Account")
                        .WithMany("ChiTietHoaDons")
                        .HasForeignKey("AccountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DoAnCoSoWeb.Models.Hoadon", "Hoadon")
                        .WithMany("chiTietHoaDons")
                        .HasForeignKey("HoaDonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DoAnCoSoWeb.Models.Sanpham", "SanPhams")
                        .WithMany("chiTietHoaDons")
                        .HasForeignKey("SanphamId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Account");

                    b.Navigation("Hoadon");

                    b.Navigation("SanPhams");
                });

            modelBuilder.Entity("DoAnCoSoWeb.Models.ChiTietLSHD", b =>
                {
                    b.HasOne("DoAnCoSoWeb.Models.Account", "Account")
                        .WithMany()
                        .HasForeignKey("AccountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DoAnCoSoWeb.Models.Sanpham", "Sanpham")
                        .WithMany()
                        .HasForeignKey("SanphamId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Account");

                    b.Navigation("Sanpham");
                });

            modelBuilder.Entity("DoAnCoSoWeb.Models.Comment", b =>
                {
                    b.HasOne("DoAnCoSoWeb.Models.Account", "Account")
                        .WithMany()
                        .HasForeignKey("AccountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DoAnCoSoWeb.Models.Sanpham", "sanpham")
                        .WithMany("Comments")
                        .HasForeignKey("SanphamId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DoAnCoSoWeb.Models.Tinhtrangcomment", "Tinhtrangcomment")
                        .WithMany("Comments")
                        .HasForeignKey("TinhtrangcommentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Account");

                    b.Navigation("Tinhtrangcomment");

                    b.Navigation("sanpham");
                });

            modelBuilder.Entity("DoAnCoSoWeb.Models.Kho", b =>
                {
                    b.HasOne("DoAnCoSoWeb.Models.Truso", "Truso")
                        .WithMany("khos")
                        .HasForeignKey("TrusoId");

                    b.Navigation("Truso");
                });

            modelBuilder.Entity("DoAnCoSoWeb.Models.Sanpham", b =>
                {
                    b.HasOne("DoAnCoSoWeb.Models.Giohang", null)
                        .WithMany("sanphams")
                        .HasForeignKey("GiohangId");

                    b.HasOne("DoAnCoSoWeb.Models.Hang", "hang")
                        .WithMany("sanphams")
                        .HasForeignKey("HangId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DoAnCoSoWeb.Models.Kho", "Kho")
                        .WithMany("sanphams")
                        .HasForeignKey("KhoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DoAnCoSoWeb.Models.Sale", "Sale")
                        .WithMany("sanphams")
                        .HasForeignKey("SaleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DoAnCoSoWeb.Models.Loaisanpham", "loaisanpham")
                        .WithMany("sanphams")
                        .HasForeignKey("loaisanphamId");

                    b.Navigation("Kho");

                    b.Navigation("Sale");

                    b.Navigation("hang");

                    b.Navigation("loaisanpham");
                });

            modelBuilder.Entity("DoAnCoSoWeb.Models.Account", b =>
                {
                    b.Navigation("ChiTietHoaDons");
                });

            modelBuilder.Entity("DoAnCoSoWeb.Models.Comment", b =>
                {
                    b.Navigation("chiTietGioHangs");
                });

            modelBuilder.Entity("DoAnCoSoWeb.Models.Giohang", b =>
                {
                    b.Navigation("Account");

                    b.Navigation("chiTietGioHangs");

                    b.Navigation("sanphams");
                });

            modelBuilder.Entity("DoAnCoSoWeb.Models.Hang", b =>
                {
                    b.Navigation("sanphams");
                });

            modelBuilder.Entity("DoAnCoSoWeb.Models.Hoadon", b =>
                {
                    b.Navigation("chiTietHoaDons");
                });

            modelBuilder.Entity("DoAnCoSoWeb.Models.Kho", b =>
                {
                    b.Navigation("sanphams");
                });

            modelBuilder.Entity("DoAnCoSoWeb.Models.Loaisanpham", b =>
                {
                    b.Navigation("sanphams");
                });

            modelBuilder.Entity("DoAnCoSoWeb.Models.Rank", b =>
                {
                    b.Navigation("Accounts");
                });

            modelBuilder.Entity("DoAnCoSoWeb.Models.Sale", b =>
                {
                    b.Navigation("sanphams");
                });

            modelBuilder.Entity("DoAnCoSoWeb.Models.Sanpham", b =>
                {
                    b.Navigation("Comments");

                    b.Navigation("chiTietHoaDons");
                });

            modelBuilder.Entity("DoAnCoSoWeb.Models.Tinhtrangcomment", b =>
                {
                    b.Navigation("Comments");
                });

            modelBuilder.Entity("DoAnCoSoWeb.Models.Truso", b =>
                {
                    b.Navigation("khos");
                });
#pragma warning restore 612, 618
        }
    }
}
