using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DoAnCoSoWeb.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "giohangs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_giohangs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "hangs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenHang = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Mota = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Link = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_hangs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "hoadons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NgayLap = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NgayThanhToan = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TongTien = table.Column<decimal>(type: "decimal(18,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_hoadons", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "hotros",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ten = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MoTa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ThuTu = table.Column<int>(type: "int", nullable: true),
                    HienThi = table.Column<int>(type: "int", nullable: true),
                    link = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_hotros", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "loaisanphams",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_loaisanphams", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ranks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenRank = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ranks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "sales",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Link = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GiaSale = table.Column<decimal>(type: "decimal(18,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sales", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "thongbaos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ten = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MoTa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Link = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_thongbaos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tinhtrangcomments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tinhtrangcomments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "trusos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenTruSo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageTruso = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Link = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_trusos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "accounts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MatKhau = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AnhDaiDien = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SoDienThoai = table.Column<int>(type: "int", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DiaChi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RankId = table.Column<int>(type: "int", nullable: false),
                    GiohangId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_accounts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_accounts_giohangs_GiohangId",
                        column: x => x.GiohangId,
                        principalTable: "giohangs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_accounts_ranks_RankId",
                        column: x => x.RankId,
                        principalTable: "ranks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "khos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenKho = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    ImageKho = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    link = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TrusoId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_khos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_khos_trusos_TrusoId",
                        column: x => x.TrusoId,
                        principalTable: "trusos",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "sanphams",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenSanPham = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Gia = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Image1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Image2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Image3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Mota = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Link = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageUrls = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KhoId = table.Column<int>(type: "int", nullable: false),
                    SaleId = table.Column<int>(type: "int", nullable: false),
                    HangId = table.Column<int>(type: "int", nullable: false),
                    LoaiId = table.Column<int>(type: "int", nullable: false),
                    loaisanphamId = table.Column<int>(type: "int", nullable: true),
                    GiohangId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sanphams", x => x.Id);
                    table.ForeignKey(
                        name: "FK_sanphams_giohangs_GiohangId",
                        column: x => x.GiohangId,
                        principalTable: "giohangs",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_sanphams_hangs_HangId",
                        column: x => x.HangId,
                        principalTable: "hangs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_sanphams_khos_KhoId",
                        column: x => x.KhoId,
                        principalTable: "khos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_sanphams_loaisanphams_loaisanphamId",
                        column: x => x.loaisanphamId,
                        principalTable: "loaisanphams",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_sanphams_sales_SaleId",
                        column: x => x.SaleId,
                        principalTable: "sales",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "chitiethoadons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SanphamId = table.Column<int>(type: "int", nullable: false),
                    HoaDonId = table.Column<int>(type: "int", nullable: false),
                    SoLuong = table.Column<int>(type: "int", nullable: false),
                    ThanhTien = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    AccountId = table.Column<int>(type: "int", nullable: false),
                    Phone = table.Column<long>(type: "bigint", nullable: true),
                    DiaChi = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_chitiethoadons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_chitiethoadons_accounts_AccountId",
                        column: x => x.AccountId,
                        principalTable: "accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_chitiethoadons_hoadons_HoaDonId",
                        column: x => x.HoaDonId,
                        principalTable: "hoadons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_chitiethoadons_sanphams_SanphamId",
                        column: x => x.SanphamId,
                        principalTable: "sanphams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "chiTietLSHDs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccountId = table.Column<int>(type: "int", nullable: false),
                    SanphamId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_chiTietLSHDs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_chiTietLSHDs_accounts_AccountId",
                        column: x => x.AccountId,
                        principalTable: "accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_chiTietLSHDs_sanphams_SanphamId",
                        column: x => x.SanphamId,
                        principalTable: "sanphams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "comments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccountId = table.Column<int>(type: "int", nullable: false),
                    NgayComment = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SanphamId = table.Column<int>(type: "int", nullable: false),
                    IsUserBoughtProduct = table.Column<bool>(type: "bit", nullable: true),
                    TinhtrangcommentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_comments_accounts_AccountId",
                        column: x => x.AccountId,
                        principalTable: "accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_comments_sanphams_SanphamId",
                        column: x => x.SanphamId,
                        principalTable: "sanphams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_comments_tinhtrangcomments_TinhtrangcommentId",
                        column: x => x.TinhtrangcommentId,
                        principalTable: "tinhtrangcomments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "chitietgiohangs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    SanphamId = table.Column<int>(type: "int", nullable: false),
                    GioHangId = table.Column<int>(type: "int", nullable: false),
                    CommentId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_chitietgiohangs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_chitietgiohangs_comments_CommentId",
                        column: x => x.CommentId,
                        principalTable: "comments",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_chitietgiohangs_giohangs_GioHangId",
                        column: x => x.GioHangId,
                        principalTable: "giohangs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_chitietgiohangs_sanphams_SanphamId",
                        column: x => x.SanphamId,
                        principalTable: "sanphams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_accounts_GiohangId",
                table: "accounts",
                column: "GiohangId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_accounts_RankId",
                table: "accounts",
                column: "RankId");

            migrationBuilder.CreateIndex(
                name: "IX_chitietgiohangs_CommentId",
                table: "chitietgiohangs",
                column: "CommentId");

            migrationBuilder.CreateIndex(
                name: "IX_chitietgiohangs_GioHangId",
                table: "chitietgiohangs",
                column: "GioHangId");

            migrationBuilder.CreateIndex(
                name: "IX_chitietgiohangs_SanphamId",
                table: "chitietgiohangs",
                column: "SanphamId");

            migrationBuilder.CreateIndex(
                name: "IX_chitiethoadons_AccountId",
                table: "chitiethoadons",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_chitiethoadons_HoaDonId",
                table: "chitiethoadons",
                column: "HoaDonId");

            migrationBuilder.CreateIndex(
                name: "IX_chitiethoadons_SanphamId",
                table: "chitiethoadons",
                column: "SanphamId");

            migrationBuilder.CreateIndex(
                name: "IX_chiTietLSHDs_AccountId",
                table: "chiTietLSHDs",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_chiTietLSHDs_SanphamId",
                table: "chiTietLSHDs",
                column: "SanphamId");

            migrationBuilder.CreateIndex(
                name: "IX_comments_AccountId",
                table: "comments",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_comments_SanphamId",
                table: "comments",
                column: "SanphamId");

            migrationBuilder.CreateIndex(
                name: "IX_comments_TinhtrangcommentId",
                table: "comments",
                column: "TinhtrangcommentId");

            migrationBuilder.CreateIndex(
                name: "IX_khos_TrusoId",
                table: "khos",
                column: "TrusoId");

            migrationBuilder.CreateIndex(
                name: "IX_sanphams_GiohangId",
                table: "sanphams",
                column: "GiohangId");

            migrationBuilder.CreateIndex(
                name: "IX_sanphams_HangId",
                table: "sanphams",
                column: "HangId");

            migrationBuilder.CreateIndex(
                name: "IX_sanphams_KhoId",
                table: "sanphams",
                column: "KhoId");

            migrationBuilder.CreateIndex(
                name: "IX_sanphams_loaisanphamId",
                table: "sanphams",
                column: "loaisanphamId");

            migrationBuilder.CreateIndex(
                name: "IX_sanphams_SaleId",
                table: "sanphams",
                column: "SaleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "chitietgiohangs");

            migrationBuilder.DropTable(
                name: "chitiethoadons");

            migrationBuilder.DropTable(
                name: "chiTietLSHDs");

            migrationBuilder.DropTable(
                name: "hotros");

            migrationBuilder.DropTable(
                name: "thongbaos");

            migrationBuilder.DropTable(
                name: "comments");

            migrationBuilder.DropTable(
                name: "hoadons");

            migrationBuilder.DropTable(
                name: "accounts");

            migrationBuilder.DropTable(
                name: "sanphams");

            migrationBuilder.DropTable(
                name: "tinhtrangcomments");

            migrationBuilder.DropTable(
                name: "ranks");

            migrationBuilder.DropTable(
                name: "giohangs");

            migrationBuilder.DropTable(
                name: "hangs");

            migrationBuilder.DropTable(
                name: "khos");

            migrationBuilder.DropTable(
                name: "loaisanphams");

            migrationBuilder.DropTable(
                name: "sales");

            migrationBuilder.DropTable(
                name: "trusos");
        }
    }
}
