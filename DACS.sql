CREATE DATABASE Doancoso;
GO

USE [Doancoso]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 6/15/2024 8:04:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[accounts]    Script Date: 6/15/2024 8:04:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[accounts](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Username] [nvarchar](max) NOT NULL,
	[MatKhau] [nvarchar](max) NOT NULL,
	[AnhDaiDien] [nvarchar](max) NULL,
	[SoDienThoai] [int] NULL,
	[Email] [nvarchar](max) NULL,
	[DiaChi] [nvarchar](max) NULL,
	[RankId] [int] NOT NULL,
	[GiohangId] [int] NOT NULL,
 CONSTRAINT [PK_accounts] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[chitietgiohangs]    Script Date: 6/15/2024 8:04:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[chitietgiohangs](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Quantity] [int] NOT NULL,
	[SanphamId] [int] NOT NULL,
	[GioHangId] [int] NOT NULL,
	[CommentId] [int] NULL,
 CONSTRAINT [PK_chitietgiohangs] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[chitiethoadons]    Script Date: 6/15/2024 8:04:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[chitiethoadons](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[SanphamId] [int] NOT NULL,
	[HoaDonId] [int] NOT NULL,
	[SoLuong] [int] NOT NULL,
	[ThanhTien] [decimal](18, 2) NOT NULL,
	[AccountId] [int] NOT NULL,
	[Phone] [bigint] NULL,
	[DiaChi] [nvarchar](max) NULL,
 CONSTRAINT [PK_chitiethoadons] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[chiTietLSHDs]    Script Date: 6/15/2024 8:04:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[chiTietLSHDs](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[AccountId] [int] NOT NULL,
	[SanphamId] [int] NOT NULL,
 CONSTRAINT [PK_chiTietLSHDs] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[comments]    Script Date: 6/15/2024 8:04:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[comments](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[AccountId] [int] NOT NULL,
	[NgayComment] [datetime2](7) NULL,
	[Note] [nvarchar](max) NULL,
	[SanphamId] [int] NOT NULL,
	[IsUserBoughtProduct] [bit] NULL,
	[TinhtrangcommentId] [int] NOT NULL,
 CONSTRAINT [PK_comments] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[contacts]    Script Date: 6/15/2024 8:04:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[contacts](
	[Email] [nvarchar](450) NOT NULL,
	[Id] [int] NOT NULL,
 CONSTRAINT [PK_contacts] PRIMARY KEY CLUSTERED 
(
	[Email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[giohangs]    Script Date: 6/15/2024 8:04:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[giohangs](
	[Id] [int] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK_giohangs] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[hangs]    Script Date: 6/15/2024 8:04:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[hangs](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[TenHang] [nvarchar](max) NOT NULL,
	[Image] [nvarchar](max) NULL,
	[Mota] [nvarchar](max) NULL,
	[Link] [nvarchar](max) NULL,
 CONSTRAINT [PK_hangs] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[hoadons]    Script Date: 6/15/2024 8:04:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[hoadons](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[NgayLap] [datetime2](7) NULL,
	[NgayThanhToan] [datetime2](7) NULL,
	[TongTien] [decimal](18, 2) NULL,
 CONSTRAINT [PK_hoadons] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[hotros]    Script Date: 6/15/2024 8:04:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[hotros](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Ten] [nvarchar](max) NOT NULL,
	[MoTa] [nvarchar](max) NULL,
	[ThuTu] [int] NULL,
	[HienThi] [int] NULL,
	[link] [nvarchar](max) NULL,
 CONSTRAINT [PK_hotros] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[khos]    Script Date: 6/15/2024 8:04:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[khos](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[TenKho] [nvarchar](255) NOT NULL,
	[ImageKho] [nvarchar](max) NULL,
	[link] [nvarchar](max) NULL,
	[TrusoId] [int] NULL,
 CONSTRAINT [PK_khos] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[loaisanphams]    Script Date: 6/15/2024 8:04:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[loaisanphams](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_loaisanphams] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ranks]    Script Date: 6/15/2024 8:04:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ranks](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[TenRank] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_ranks] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[sales]    Script Date: 6/15/2024 8:04:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[sales](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[Link] [nvarchar](max) NULL,
	[GiaSale] [decimal](18, 2) NULL,
 CONSTRAINT [PK_sales] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[sanphams]    Script Date: 6/15/2024 8:04:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[sanphams](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[TenSanPham] [nvarchar](255) NOT NULL,
	[Gia] [decimal](18, 2) NOT NULL,
	[Image1] [nvarchar](max) NULL,
	[Image2] [nvarchar](max) NULL,
	[Image3] [nvarchar](max) NULL,
	[Mota] [nvarchar](max) NULL,
	[Link] [nvarchar](max) NULL,
	[ImageUrl] [nvarchar](max) NULL,
	[ImageUrls] [nvarchar](max) NULL,
	[KhoId] [int] NOT NULL,
	[SaleId] [int] NOT NULL,
	[HangId] [int] NOT NULL,
	[LoaiId] [int] NOT NULL,
	[loaisanphamId] [int] NULL,
	[GiohangId] [int] NULL,
 CONSTRAINT [PK_sanphams] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[thongbaos]    Script Date: 6/15/2024 8:04:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[thongbaos](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Ten] [nvarchar](max) NOT NULL,
	[MoTa] [nvarchar](max) NULL,
	[Link] [nvarchar](max) NULL,
 CONSTRAINT [PK_thongbaos] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tinhtrangcomments]    Script Date: 6/15/2024 8:04:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tinhtrangcomments](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
 CONSTRAINT [PK_tinhtrangcomments] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[trusos]    Script Date: 6/15/2024 8:04:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[trusos](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[TenTruSo] [nvarchar](max) NOT NULL,
	[ImageTruso] [nvarchar](max) NULL,
	[Link] [nvarchar](max) NULL,
 CONSTRAINT [PK_trusos] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240526045323_Initial', N'8.0.5')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240601115358_contact', N'8.0.5')
GO
SET IDENTITY_INSERT [dbo].[accounts] ON 

INSERT [dbo].[accounts] ([Id], [Username], [MatKhau], [AnhDaiDien], [SoDienThoai], [Email], [DiaChi], [RankId], [GiohangId]) VALUES (3, N'aa', N'$2a$11$6Yhlg/a59iGQ6jJnbAQEDOS8BpagdD7CO6QL246vyYa..3v/uYKAO', N'no_avatar.png', NULL, NULL, NULL, 1, 3)
INSERT [dbo].[accounts] ([Id], [Username], [MatKhau], [AnhDaiDien], [SoDienThoai], [Email], [DiaChi], [RankId], [GiohangId]) VALUES (4, N'nk', N'$2a$11$oyOHWyRlD0MI2LLyxHRo4edBtoFZtH.bjIcaf0MNcUUGU0TgJh0Li', N'create_product.jpg', 4334, N'dfdfdf', N'dfdfdfd', 1, 4)
INSERT [dbo].[accounts] ([Id], [Username], [MatKhau], [AnhDaiDien], [SoDienThoai], [Email], [DiaChi], [RankId], [GiohangId]) VALUES (5, N'ss', N'$2a$11$/eL1h0FmfEHMdBh/8BP9aOzh.8gzSCGguE3dS18UuAYVskjrd73dS', N'no_avatar.png', NULL, NULL, NULL, 2, 5)
INSERT [dbo].[accounts] ([Id], [Username], [MatKhau], [AnhDaiDien], [SoDienThoai], [Email], [DiaChi], [RankId], [GiohangId]) VALUES (6, N'nguyenkhanh', N'$2a$11$VXxCCaVPVqF67PMxFqs/luelGbR7vuNdvcLNprAoD0gXB/jFld3N2', N'no_avatar.png', NULL, NULL, NULL, 2, 6)
INSERT [dbo].[accounts] ([Id], [Username], [MatKhau], [AnhDaiDien], [SoDienThoai], [Email], [DiaChi], [RankId], [GiohangId]) VALUES (7, N'user1', N'$2a$11$LtJj7EZV2nsx6g94vvtBsus/w7EROrcH80kAM.DkbvtYcH63DxhgS', N'create_product.jpg', 12345678, N'user1@gmail.com', N'abc', 2, 7)
INSERT [dbo].[accounts] ([Id], [Username], [MatKhau], [AnhDaiDien], [SoDienThoai], [Email], [DiaChi], [RankId], [GiohangId]) VALUES (8, N'user2', N'$2a$11$273y9IVCRsd5XlZOWyF9F.i.D7fQiQjZmEYKPGxyXwM7AFjmA1SI6', N'no_avatar.png', NULL, NULL, NULL, 2, 8)
SET IDENTITY_INSERT [dbo].[accounts] OFF
GO
SET IDENTITY_INSERT [dbo].[chitietgiohangs] ON 

INSERT [dbo].[chitietgiohangs] ([Id], [Quantity], [SanphamId], [GioHangId], [CommentId]) VALUES (52, 1, 17, 4, NULL)
INSERT [dbo].[chitietgiohangs] ([Id], [Quantity], [SanphamId], [GioHangId], [CommentId]) VALUES (55, 1, 16, 4, NULL)
SET IDENTITY_INSERT [dbo].[chitietgiohangs] OFF
GO
SET IDENTITY_INSERT [dbo].[chitiethoadons] ON 

INSERT [dbo].[chitiethoadons] ([Id], [SanphamId], [HoaDonId], [SoLuong], [ThanhTien], [AccountId], [Phone], [DiaChi]) VALUES (11, 12, 11, 2, CAST(45980000.00 AS Decimal(18, 2)), 4, 4334, N'dfdfdfd')
INSERT [dbo].[chitiethoadons] ([Id], [SanphamId], [HoaDonId], [SoLuong], [ThanhTien], [AccountId], [Phone], [DiaChi]) VALUES (18, 12, 18, 10, CAST(229900000.00 AS Decimal(18, 2)), 4, 4334, N'dfdfdfd')
INSERT [dbo].[chitiethoadons] ([Id], [SanphamId], [HoaDonId], [SoLuong], [ThanhTien], [AccountId], [Phone], [DiaChi]) VALUES (19, 12, 19, 14, CAST(321860000.00 AS Decimal(18, 2)), 4, 4334, N'dfdfdfd')
INSERT [dbo].[chitiethoadons] ([Id], [SanphamId], [HoaDonId], [SoLuong], [ThanhTien], [AccountId], [Phone], [DiaChi]) VALUES (20, 16, 20, 100, CAST(729900000.00 AS Decimal(18, 2)), 4, 4334, N'dfdfdfd')
INSERT [dbo].[chitiethoadons] ([Id], [SanphamId], [HoaDonId], [SoLuong], [ThanhTien], [AccountId], [Phone], [DiaChi]) VALUES (21, 15, 21, 4, CAST(13199996.00 AS Decimal(18, 2)), 7, 12345678, N'abc')
INSERT [dbo].[chitiethoadons] ([Id], [SanphamId], [HoaDonId], [SoLuong], [ThanhTien], [AccountId], [Phone], [DiaChi]) VALUES (22, 15, 22, 1, CAST(3299999.00 AS Decimal(18, 2)), 7, 12345678, N'abc')
INSERT [dbo].[chitiethoadons] ([Id], [SanphamId], [HoaDonId], [SoLuong], [ThanhTien], [AccountId], [Phone], [DiaChi]) VALUES (23, 12, 23, 2, CAST(45980000.00 AS Decimal(18, 2)), 7, 12345678, N'abc')
INSERT [dbo].[chitiethoadons] ([Id], [SanphamId], [HoaDonId], [SoLuong], [ThanhTien], [AccountId], [Phone], [DiaChi]) VALUES (24, 14, 24, 7, CAST(4893000.00 AS Decimal(18, 2)), 7, 12345678, N'abc')
INSERT [dbo].[chitiethoadons] ([Id], [SanphamId], [HoaDonId], [SoLuong], [ThanhTien], [AccountId], [Phone], [DiaChi]) VALUES (25, 14, 25, 1, CAST(699000.00 AS Decimal(18, 2)), 7, 12345678, N'abc')
INSERT [dbo].[chitiethoadons] ([Id], [SanphamId], [HoaDonId], [SoLuong], [ThanhTien], [AccountId], [Phone], [DiaChi]) VALUES (26, 16, 26, 10, CAST(72990000.00 AS Decimal(18, 2)), 7, 12345678, N'abc')
INSERT [dbo].[chitiethoadons] ([Id], [SanphamId], [HoaDonId], [SoLuong], [ThanhTien], [AccountId], [Phone], [DiaChi]) VALUES (27, 16, 27, 10, CAST(72990000.00 AS Decimal(18, 2)), 7, 12345678, N'abc')
INSERT [dbo].[chitiethoadons] ([Id], [SanphamId], [HoaDonId], [SoLuong], [ThanhTien], [AccountId], [Phone], [DiaChi]) VALUES (28, 2, 28, 3, CAST(38997000.00 AS Decimal(18, 2)), 7, 12345678, N'abc')
INSERT [dbo].[chitiethoadons] ([Id], [SanphamId], [HoaDonId], [SoLuong], [ThanhTien], [AccountId], [Phone], [DiaChi]) VALUES (42, 17, 42, 4, CAST(13999960.00 AS Decimal(18, 2)), 4, 4334, N'dfdfdfd')
INSERT [dbo].[chitiethoadons] ([Id], [SanphamId], [HoaDonId], [SoLuong], [ThanhTien], [AccountId], [Phone], [DiaChi]) VALUES (43, 17, 43, 3, CAST(10499970.00 AS Decimal(18, 2)), 4, 4334, N'dfdfdfd')
INSERT [dbo].[chitiethoadons] ([Id], [SanphamId], [HoaDonId], [SoLuong], [ThanhTien], [AccountId], [Phone], [DiaChi]) VALUES (44, 17, 44, 1, CAST(3499990.00 AS Decimal(18, 2)), 4, 4334, N'dfdfdfd')
INSERT [dbo].[chitiethoadons] ([Id], [SanphamId], [HoaDonId], [SoLuong], [ThanhTien], [AccountId], [Phone], [DiaChi]) VALUES (45, 17, 45, 1, CAST(3499990.00 AS Decimal(18, 2)), 4, 4334, N'dfdfdfd')
INSERT [dbo].[chitiethoadons] ([Id], [SanphamId], [HoaDonId], [SoLuong], [ThanhTien], [AccountId], [Phone], [DiaChi]) VALUES (46, 39, 46, 3, CAST(4199997.00 AS Decimal(18, 2)), 4, 4334, N'dfdfdfd')
INSERT [dbo].[chitiethoadons] ([Id], [SanphamId], [HoaDonId], [SoLuong], [ThanhTien], [AccountId], [Phone], [DiaChi]) VALUES (47, 16, 47, 1, CAST(7299000.00 AS Decimal(18, 2)), 4, 4334, N'dfdfdfd')
INSERT [dbo].[chitiethoadons] ([Id], [SanphamId], [HoaDonId], [SoLuong], [ThanhTien], [AccountId], [Phone], [DiaChi]) VALUES (48, 16, 48, 3, CAST(21897000.00 AS Decimal(18, 2)), 4, 4334, N'dfdfdfd')
INSERT [dbo].[chitiethoadons] ([Id], [SanphamId], [HoaDonId], [SoLuong], [ThanhTien], [AccountId], [Phone], [DiaChi]) VALUES (49, 16, 49, 1, CAST(7299000.00 AS Decimal(18, 2)), 4, 4334, N'dfdfdfd')
SET IDENTITY_INSERT [dbo].[chitiethoadons] OFF
GO
SET IDENTITY_INSERT [dbo].[comments] ON 

INSERT [dbo].[comments] ([Id], [AccountId], [NgayComment], [Note], [SanphamId], [IsUserBoughtProduct], [TinhtrangcommentId]) VALUES (53, 4, CAST(N'2024-06-02T18:49:59.4073044' AS DateTime2), N'dsdsd', 2, NULL, 1)
INSERT [dbo].[comments] ([Id], [AccountId], [NgayComment], [Note], [SanphamId], [IsUserBoughtProduct], [TinhtrangcommentId]) VALUES (54, 4, CAST(N'2024-06-02T18:51:13.1237757' AS DateTime2), N'dsds', 2, NULL, 1)
INSERT [dbo].[comments] ([Id], [AccountId], [NgayComment], [Note], [SanphamId], [IsUserBoughtProduct], [TinhtrangcommentId]) VALUES (55, 4, CAST(N'2024-06-02T19:11:14.0007871' AS DateTime2), N'Hello
', 2, NULL, 1)
INSERT [dbo].[comments] ([Id], [AccountId], [NgayComment], [Note], [SanphamId], [IsUserBoughtProduct], [TinhtrangcommentId]) VALUES (56, 6, CAST(N'2024-06-02T19:34:51.8839148' AS DateTime2), N'Hello', 2, NULL, 2)
INSERT [dbo].[comments] ([Id], [AccountId], [NgayComment], [Note], [SanphamId], [IsUserBoughtProduct], [TinhtrangcommentId]) VALUES (57, 4, CAST(N'2024-06-02T19:54:52.2607267' AS DateTime2), N'Hello
', 12, NULL, 2)
INSERT [dbo].[comments] ([Id], [AccountId], [NgayComment], [Note], [SanphamId], [IsUserBoughtProduct], [TinhtrangcommentId]) VALUES (58, 4, CAST(N'2024-06-10T21:50:46.7619180' AS DateTime2), N'sddsd', 12, NULL, 1)
INSERT [dbo].[comments] ([Id], [AccountId], [NgayComment], [Note], [SanphamId], [IsUserBoughtProduct], [TinhtrangcommentId]) VALUES (59, 4, CAST(N'2024-06-11T18:35:33.9691739' AS DateTime2), N'Hello', 12, NULL, 1)
INSERT [dbo].[comments] ([Id], [AccountId], [NgayComment], [Note], [SanphamId], [IsUserBoughtProduct], [TinhtrangcommentId]) VALUES (60, 4, CAST(N'2024-06-11T18:35:42.8944475' AS DateTime2), N'hello', 16, NULL, 1)
INSERT [dbo].[comments] ([Id], [AccountId], [NgayComment], [Note], [SanphamId], [IsUserBoughtProduct], [TinhtrangcommentId]) VALUES (61, 6, CAST(N'2024-06-11T18:36:01.4069526' AS DateTime2), N'Hello', 16, NULL, 2)
INSERT [dbo].[comments] ([Id], [AccountId], [NgayComment], [Note], [SanphamId], [IsUserBoughtProduct], [TinhtrangcommentId]) VALUES (62, 7, CAST(N'2024-06-15T12:46:28.7310280' AS DateTime2), N'Hello
', 2, NULL, 2)
INSERT [dbo].[comments] ([Id], [AccountId], [NgayComment], [Note], [SanphamId], [IsUserBoughtProduct], [TinhtrangcommentId]) VALUES (63, 7, CAST(N'2024-06-15T12:46:44.1963907' AS DateTime2), N'Hello', 16, NULL, 1)
INSERT [dbo].[comments] ([Id], [AccountId], [NgayComment], [Note], [SanphamId], [IsUserBoughtProduct], [TinhtrangcommentId]) VALUES (64, 4, CAST(N'2024-06-15T17:44:13.3777411' AS DateTime2), N'Hello', 18, NULL, 2)
INSERT [dbo].[comments] ([Id], [AccountId], [NgayComment], [Note], [SanphamId], [IsUserBoughtProduct], [TinhtrangcommentId]) VALUES (65, 4, CAST(N'2024-06-15T17:44:25.2021045' AS DateTime2), N'Hello', 17, NULL, 1)
SET IDENTITY_INSERT [dbo].[comments] OFF
GO
INSERT [dbo].[contacts] ([Email], [Id]) VALUES (N'ngdksfk@gmail.com', 0)
GO
SET IDENTITY_INSERT [dbo].[giohangs] ON 

INSERT [dbo].[giohangs] ([Id]) VALUES (1)
INSERT [dbo].[giohangs] ([Id]) VALUES (2)
INSERT [dbo].[giohangs] ([Id]) VALUES (3)
INSERT [dbo].[giohangs] ([Id]) VALUES (4)
INSERT [dbo].[giohangs] ([Id]) VALUES (5)
INSERT [dbo].[giohangs] ([Id]) VALUES (6)
INSERT [dbo].[giohangs] ([Id]) VALUES (7)
INSERT [dbo].[giohangs] ([Id]) VALUES (8)
SET IDENTITY_INSERT [dbo].[giohangs] OFF
GO
SET IDENTITY_INSERT [dbo].[hangs] ON 

INSERT [dbo].[hangs] ([Id], [TenHang], [Image], [Mota], [Link]) VALUES (1, N'MSI', NULL, NULL, NULL)
INSERT [dbo].[hangs] ([Id], [TenHang], [Image], [Mota], [Link]) VALUES (2, N'Kingston', NULL, NULL, NULL)
INSERT [dbo].[hangs] ([Id], [TenHang], [Image], [Mota], [Link]) VALUES (3, N'Crucial', NULL, NULL, NULL)
INSERT [dbo].[hangs] ([Id], [TenHang], [Image], [Mota], [Link]) VALUES (4, N'Asus', NULL, NULL, NULL)
INSERT [dbo].[hangs] ([Id], [TenHang], [Image], [Mota], [Link]) VALUES (5, N'Hp', NULL, NULL, NULL)
INSERT [dbo].[hangs] ([Id], [TenHang], [Image], [Mota], [Link]) VALUES (6, N'Geil', NULL, NULL, NULL)
INSERT [dbo].[hangs] ([Id], [TenHang], [Image], [Mota], [Link]) VALUES (7, N'Lenovo', NULL, NULL, NULL)
INSERT [dbo].[hangs] ([Id], [TenHang], [Image], [Mota], [Link]) VALUES (8, N'SAMSUNG', NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[hangs] OFF
GO
SET IDENTITY_INSERT [dbo].[hoadons] ON 

INSERT [dbo].[hoadons] ([Id], [NgayLap], [NgayThanhToan], [TongTien]) VALUES (1, CAST(N'2024-05-26T15:57:53.8002446' AS DateTime2), NULL, NULL)
INSERT [dbo].[hoadons] ([Id], [NgayLap], [NgayThanhToan], [TongTien]) VALUES (2, CAST(N'2024-05-26T16:01:55.0872410' AS DateTime2), NULL, NULL)
INSERT [dbo].[hoadons] ([Id], [NgayLap], [NgayThanhToan], [TongTien]) VALUES (3, CAST(N'2024-05-26T16:05:31.3621748' AS DateTime2), NULL, NULL)
INSERT [dbo].[hoadons] ([Id], [NgayLap], [NgayThanhToan], [TongTien]) VALUES (4, CAST(N'2024-06-01T17:52:44.8011835' AS DateTime2), NULL, NULL)
INSERT [dbo].[hoadons] ([Id], [NgayLap], [NgayThanhToan], [TongTien]) VALUES (5, CAST(N'2024-06-01T17:53:33.9731887' AS DateTime2), NULL, NULL)
INSERT [dbo].[hoadons] ([Id], [NgayLap], [NgayThanhToan], [TongTien]) VALUES (6, CAST(N'2024-06-02T09:05:37.8741864' AS DateTime2), NULL, NULL)
INSERT [dbo].[hoadons] ([Id], [NgayLap], [NgayThanhToan], [TongTien]) VALUES (7, CAST(N'2024-06-02T10:05:58.1873204' AS DateTime2), NULL, NULL)
INSERT [dbo].[hoadons] ([Id], [NgayLap], [NgayThanhToan], [TongTien]) VALUES (8, CAST(N'2024-06-02T12:16:54.9727965' AS DateTime2), NULL, NULL)
INSERT [dbo].[hoadons] ([Id], [NgayLap], [NgayThanhToan], [TongTien]) VALUES (9, CAST(N'2024-06-02T14:22:55.0143830' AS DateTime2), NULL, NULL)
INSERT [dbo].[hoadons] ([Id], [NgayLap], [NgayThanhToan], [TongTien]) VALUES (10, CAST(N'2024-06-02T18:54:14.5683196' AS DateTime2), NULL, NULL)
INSERT [dbo].[hoadons] ([Id], [NgayLap], [NgayThanhToan], [TongTien]) VALUES (11, CAST(N'2024-06-06T20:34:47.4689509' AS DateTime2), NULL, NULL)
INSERT [dbo].[hoadons] ([Id], [NgayLap], [NgayThanhToan], [TongTien]) VALUES (12, CAST(N'2024-06-06T20:38:09.1669586' AS DateTime2), NULL, NULL)
INSERT [dbo].[hoadons] ([Id], [NgayLap], [NgayThanhToan], [TongTien]) VALUES (13, CAST(N'2024-06-06T20:40:27.6664635' AS DateTime2), NULL, NULL)
INSERT [dbo].[hoadons] ([Id], [NgayLap], [NgayThanhToan], [TongTien]) VALUES (14, CAST(N'2024-06-06T20:45:36.0967672' AS DateTime2), NULL, NULL)
INSERT [dbo].[hoadons] ([Id], [NgayLap], [NgayThanhToan], [TongTien]) VALUES (15, CAST(N'2024-06-06T20:56:25.3279886' AS DateTime2), NULL, NULL)
INSERT [dbo].[hoadons] ([Id], [NgayLap], [NgayThanhToan], [TongTien]) VALUES (16, CAST(N'2024-06-06T21:12:27.9001015' AS DateTime2), NULL, NULL)
INSERT [dbo].[hoadons] ([Id], [NgayLap], [NgayThanhToan], [TongTien]) VALUES (17, CAST(N'2024-06-10T21:49:25.3803193' AS DateTime2), NULL, NULL)
INSERT [dbo].[hoadons] ([Id], [NgayLap], [NgayThanhToan], [TongTien]) VALUES (18, CAST(N'2024-06-10T21:49:43.8996402' AS DateTime2), NULL, NULL)
INSERT [dbo].[hoadons] ([Id], [NgayLap], [NgayThanhToan], [TongTien]) VALUES (19, CAST(N'2024-06-11T17:58:28.0865232' AS DateTime2), NULL, NULL)
INSERT [dbo].[hoadons] ([Id], [NgayLap], [NgayThanhToan], [TongTien]) VALUES (20, CAST(N'2024-06-11T18:30:34.0914776' AS DateTime2), NULL, NULL)
INSERT [dbo].[hoadons] ([Id], [NgayLap], [NgayThanhToan], [TongTien]) VALUES (21, CAST(N'2024-06-15T12:40:44.9395715' AS DateTime2), NULL, NULL)
INSERT [dbo].[hoadons] ([Id], [NgayLap], [NgayThanhToan], [TongTien]) VALUES (22, CAST(N'2024-06-15T12:41:15.3447459' AS DateTime2), NULL, NULL)
INSERT [dbo].[hoadons] ([Id], [NgayLap], [NgayThanhToan], [TongTien]) VALUES (23, CAST(N'2024-06-15T12:41:26.4263106' AS DateTime2), NULL, NULL)
INSERT [dbo].[hoadons] ([Id], [NgayLap], [NgayThanhToan], [TongTien]) VALUES (24, CAST(N'2024-06-15T12:41:42.3405139' AS DateTime2), NULL, NULL)
INSERT [dbo].[hoadons] ([Id], [NgayLap], [NgayThanhToan], [TongTien]) VALUES (25, CAST(N'2024-06-15T12:42:00.6930833' AS DateTime2), NULL, NULL)
INSERT [dbo].[hoadons] ([Id], [NgayLap], [NgayThanhToan], [TongTien]) VALUES (26, CAST(N'2024-06-15T12:43:58.3489658' AS DateTime2), NULL, NULL)
INSERT [dbo].[hoadons] ([Id], [NgayLap], [NgayThanhToan], [TongTien]) VALUES (27, CAST(N'2024-06-15T12:44:51.9995106' AS DateTime2), NULL, NULL)
INSERT [dbo].[hoadons] ([Id], [NgayLap], [NgayThanhToan], [TongTien]) VALUES (28, CAST(N'2024-06-15T12:47:41.8366359' AS DateTime2), NULL, NULL)
INSERT [dbo].[hoadons] ([Id], [NgayLap], [NgayThanhToan], [TongTien]) VALUES (29, CAST(N'2024-06-15T14:06:42.4643951' AS DateTime2), NULL, NULL)
INSERT [dbo].[hoadons] ([Id], [NgayLap], [NgayThanhToan], [TongTien]) VALUES (30, CAST(N'2024-06-15T14:10:38.2871153' AS DateTime2), NULL, NULL)
INSERT [dbo].[hoadons] ([Id], [NgayLap], [NgayThanhToan], [TongTien]) VALUES (31, CAST(N'2024-06-15T14:11:59.2840697' AS DateTime2), NULL, NULL)
INSERT [dbo].[hoadons] ([Id], [NgayLap], [NgayThanhToan], [TongTien]) VALUES (32, CAST(N'2024-06-15T14:53:26.4478856' AS DateTime2), NULL, NULL)
INSERT [dbo].[hoadons] ([Id], [NgayLap], [NgayThanhToan], [TongTien]) VALUES (33, CAST(N'2024-06-15T14:57:16.4101514' AS DateTime2), NULL, NULL)
INSERT [dbo].[hoadons] ([Id], [NgayLap], [NgayThanhToan], [TongTien]) VALUES (34, CAST(N'2024-06-15T14:57:55.4619461' AS DateTime2), NULL, NULL)
INSERT [dbo].[hoadons] ([Id], [NgayLap], [NgayThanhToan], [TongTien]) VALUES (35, CAST(N'2024-06-15T14:58:35.7642060' AS DateTime2), NULL, NULL)
INSERT [dbo].[hoadons] ([Id], [NgayLap], [NgayThanhToan], [TongTien]) VALUES (36, CAST(N'2024-06-15T14:59:04.7400932' AS DateTime2), NULL, NULL)
INSERT [dbo].[hoadons] ([Id], [NgayLap], [NgayThanhToan], [TongTien]) VALUES (37, CAST(N'2024-06-15T14:59:24.0179517' AS DateTime2), NULL, NULL)
INSERT [dbo].[hoadons] ([Id], [NgayLap], [NgayThanhToan], [TongTien]) VALUES (38, CAST(N'2024-06-15T15:00:49.7531061' AS DateTime2), NULL, NULL)
INSERT [dbo].[hoadons] ([Id], [NgayLap], [NgayThanhToan], [TongTien]) VALUES (39, CAST(N'2024-06-15T15:02:09.1691178' AS DateTime2), NULL, NULL)
INSERT [dbo].[hoadons] ([Id], [NgayLap], [NgayThanhToan], [TongTien]) VALUES (40, CAST(N'2024-06-15T15:03:00.5783719' AS DateTime2), NULL, NULL)
INSERT [dbo].[hoadons] ([Id], [NgayLap], [NgayThanhToan], [TongTien]) VALUES (41, CAST(N'2024-06-15T15:03:19.4774354' AS DateTime2), NULL, NULL)
INSERT [dbo].[hoadons] ([Id], [NgayLap], [NgayThanhToan], [TongTien]) VALUES (42, CAST(N'2024-06-15T17:36:57.3193189' AS DateTime2), NULL, NULL)
INSERT [dbo].[hoadons] ([Id], [NgayLap], [NgayThanhToan], [TongTien]) VALUES (43, CAST(N'2024-06-15T17:37:28.6077805' AS DateTime2), NULL, NULL)
INSERT [dbo].[hoadons] ([Id], [NgayLap], [NgayThanhToan], [TongTien]) VALUES (44, CAST(N'2024-06-15T17:38:59.4285686' AS DateTime2), NULL, NULL)
INSERT [dbo].[hoadons] ([Id], [NgayLap], [NgayThanhToan], [TongTien]) VALUES (45, CAST(N'2024-06-15T17:40:53.1940704' AS DateTime2), NULL, NULL)
INSERT [dbo].[hoadons] ([Id], [NgayLap], [NgayThanhToan], [TongTien]) VALUES (46, CAST(N'2024-06-15T19:24:32.0781823' AS DateTime2), NULL, NULL)
INSERT [dbo].[hoadons] ([Id], [NgayLap], [NgayThanhToan], [TongTien]) VALUES (47, CAST(N'2024-06-15T19:42:54.8994424' AS DateTime2), NULL, NULL)
INSERT [dbo].[hoadons] ([Id], [NgayLap], [NgayThanhToan], [TongTien]) VALUES (48, CAST(N'2024-06-15T19:45:29.3558138' AS DateTime2), NULL, NULL)
INSERT [dbo].[hoadons] ([Id], [NgayLap], [NgayThanhToan], [TongTien]) VALUES (49, CAST(N'2024-06-15T19:53:13.6125807' AS DateTime2), NULL, NULL)
SET IDENTITY_INSERT [dbo].[hoadons] OFF
GO
SET IDENTITY_INSERT [dbo].[khos] ON 

INSERT [dbo].[khos] ([Id], [TenKho], [ImageKho], [link], [TrusoId]) VALUES (1, N'a', NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[khos] OFF
GO
SET IDENTITY_INSERT [dbo].[loaisanphams] ON 

INSERT [dbo].[loaisanphams] ([Id], [Name]) VALUES (1, N'Ram')
INSERT [dbo].[loaisanphams] ([Id], [Name]) VALUES (2, N'Laptop')
INSERT [dbo].[loaisanphams] ([Id], [Name]) VALUES (3, N'Pc')
INSERT [dbo].[loaisanphams] ([Id], [Name]) VALUES (4, N'Linh Kiện')
SET IDENTITY_INSERT [dbo].[loaisanphams] OFF
GO
SET IDENTITY_INSERT [dbo].[ranks] ON 

INSERT [dbo].[ranks] ([Id], [TenRank]) VALUES (1, N'Admin')
INSERT [dbo].[ranks] ([Id], [TenRank]) VALUES (2, N'User')
SET IDENTITY_INSERT [dbo].[ranks] OFF
GO
SET IDENTITY_INSERT [dbo].[sales] ON 

INSERT [dbo].[sales] ([Id], [Name], [Link], [GiaSale]) VALUES (1, N'22', NULL, NULL)
SET IDENTITY_INSERT [dbo].[sales] OFF
GO
SET IDENTITY_INSERT [dbo].[sanphams] ON 

INSERT [dbo].[sanphams] ([Id], [TenSanPham], [Gia], [Image1], [Image2], [Image3], [Mota], [Link], [ImageUrl], [ImageUrls], [KhoId], [SaleId], [HangId], [LoaiId], [loaisanphamId], [GiohangId]) VALUES (2, N'Laptop Msi', CAST(12999000.00 AS Decimal(18, 2)), N'LaptopMsi_1.png', N'LaptopMsi_1_img2.png', N'LaptopMsi_1_img3.png', N'sdds', NULL, NULL, NULL, 1, 1, 1, 2, NULL, NULL)
INSERT [dbo].[sanphams] ([Id], [TenSanPham], [Gia], [Image1], [Image2], [Image3], [Mota], [Link], [ImageUrl], [ImageUrls], [KhoId], [SaleId], [HangId], [LoaiId], [loaisanphamId], [GiohangId]) VALUES (12, N'Laptop Lenovo LOQ Gaming', CAST(22990000.00 AS Decimal(18, 2)), N'Laptop_1_2.jpg', N'Laptop_1_3.jpg', N'Laptop_1_1.jpg', N'Laptop Lenovo LOQ Gaming 15IAX9 i5 12450HX/16GB/512GB/6GB RTX3050/144Hz/Win11 (83GS000JVN) ', NULL, NULL, NULL, 1, 1, 5, 2, NULL, NULL)
INSERT [dbo].[sanphams] ([Id], [TenSanPham], [Gia], [Image1], [Image2], [Image3], [Mota], [Link], [ImageUrl], [ImageUrls], [KhoId], [SaleId], [HangId], [LoaiId], [loaisanphamId], [GiohangId]) VALUES (14, N'RAM LAPTOP KINGSTON', CAST(699000.00 AS Decimal(18, 2)), N'Ram_1_1.jpg', N'Ram_1_2.jpg', N'Ram_1_3.jpg', N'4GB (1X4GB) DDR3 1600MHZ', N'ram-latop-kingston', NULL, NULL, 1, 1, 1, 1, NULL, NULL)
INSERT [dbo].[sanphams] ([Id], [TenSanPham], [Gia], [Image1], [Image2], [Image3], [Mota], [Link], [ImageUrl], [ImageUrls], [KhoId], [SaleId], [HangId], [LoaiId], [loaisanphamId], [GiohangId]) VALUES (15, N'PC GAMING HACOM SNIPER I5 V2', CAST(3299999.00 AS Decimal(18, 2)), N'CPU_1_1.jpg', N'CPU_1_2.jpg', N'CPU_1_3.jpg', N'Không như những chiếc máy lắp sẵn đến từ các hãng lớn chỉ cover người dùng trong 12 tháng. HACOM duy trì chính sách bảo hành theo linh kiện cho tất cả những bộ máy xuất xưởng, nghĩa là khách hàng sẽ được hưởng trọn toàn bộ những dịch vụ sau bán hàng theo cam kết của nhà sản xuất, thường lên đến 3 năm (hoặc hơn) cho CPU, VGA, RAM, Bo mạch chủ.', N'vo-pc-gamming-sniper', NULL, NULL, 1, 1, 2, 3, NULL, NULL)
INSERT [dbo].[sanphams] ([Id], [TenSanPham], [Gia], [Image1], [Image2], [Image3], [Mota], [Link], [ImageUrl], [ImageUrls], [KhoId], [SaleId], [HangId], [LoaiId], [loaisanphamId], [GiohangId]) VALUES (16, N'Bàn phím Machenike K600T-B82 White Violet', CAST(7299000.00 AS Decimal(18, 2)), N'LK_Phim_1_1.png', N'LK_Phim_1_2.png', N'LK_Phim_1_3.png', N'Có kích thước 332.5 x 152 x 42mm và trọng lượng 775g là lựa chọn lý tưởng để bạn đem theo mọi nơi, kèm theo đó Machenike K600T-B82 White Violet có cáp USB-C có thể tháo rời giúp bạn dễ dàng lưu trữ và mang theo bàn phím mà không cần lo lắng về việc vướng víu.Kết nối được với hầu hết với các thiết bị máy tính hiện đại, tương thích với cả hệ điều hành Windows và macOS, đảm bảo sự linh hoạt và tiện lợi.', N'ban-phim-Machenike-K600T-B82-White-Violet', NULL, NULL, 1, 1, 4, 4, NULL, NULL)
INSERT [dbo].[sanphams] ([Id], [TenSanPham], [Gia], [Image1], [Image2], [Image3], [Mota], [Link], [ImageUrl], [ImageUrls], [KhoId], [SaleId], [HangId], [LoaiId], [loaisanphamId], [GiohangId]) VALUES (17, N'Tai nghe Razer Kraken Kitty Chroma USB - Quartz', CAST(3499990.00 AS Decimal(18, 2)), N'LK_TaiNghe_1_1.png', N'LK_TaiNghe_1_3.jpg', N'LK_TaiNghe_1_1.png', N'ai nghe Razer Kraken Kitty Chroma USB - Quartz | Có dây là một thiết kế tai nghe độc đáo và mới lạ của Razer tạo nên một vẻ ngoài game thủ kiểu mèo sát thủ với chiếc tai nghe Kitty của bạn. Thể hiện cá tính và đam mê độc đáo của riêng bạn theo nhiều cách với nhiều màu sắc nhất có thể với Razer Kraken phiên bản Mèo Kitty, một chiếc tai nghe gaming kết nối qua USB và led RGB Chroma tuyệt vời.', N'ta-nghe-Razer-Kraken-Kitty-Chroma-USB-Quartz', NULL, NULL, 1, 1, 5, 4, NULL, NULL)
INSERT [dbo].[sanphams] ([Id], [TenSanPham], [Gia], [Image1], [Image2], [Image3], [Mota], [Link], [ImageUrl], [ImageUrls], [KhoId], [SaleId], [HangId], [LoaiId], [loaisanphamId], [GiohangId]) VALUES (18, N'LAPTOP ACER NITRO V ANV15-51-58AN', CAST(19999000.00 AS Decimal(18, 2)), N'Laptop_2_1.jpg', N'Laptop_2_2.jpg', N'Laptop_2_3.jpg', N'Cấu hình mạnh luôn là ưu tiên hàng đầu của một chiếc Laptop Gaming hiệu năng cao. Acer Gaming Nitro V được trang bị CPU Intel® Core™ i5-13420H thế hệ 13 mới nhất với 8 nhân và 12 luồng cùng với VGA RTX 2050, giúp Gamers tận hưởng các tựa game từ AAA đến game Esport. Kết hợp cùng bộ nhớ RAM DDR5 5200Mhz, khả năng xử lý đa nhiệm và đa tác vụ của máy càng được tăng tốc tối đa.', N'LAPTOP-ACER-NITRO-V-ANV15-51-58AN', NULL, NULL, 1, 1, 1, 2, NULL, NULL)
INSERT [dbo].[sanphams] ([Id], [TenSanPham], [Gia], [Image1], [Image2], [Image3], [Mota], [Link], [ImageUrl], [ImageUrls], [KhoId], [SaleId], [HangId], [LoaiId], [loaisanphamId], [GiohangId]) VALUES (19, N'LAPTOP MSI GAMING SWORD 16 HX B14VFKG-045VN', CAST(39999000.00 AS Decimal(18, 2)), N'Laptop3_1.jpg', N'Laptop3_2.jpg', N'Laptop3_3.jpg', N'CPU: Intel® Core™ i7-14700HX RAM: 16GB DDR5 5600Mhz (8GBx2)(Tối đa 96GB) Ổ cứng: 1TB NVMe PCIe Gen4x4 VGA: NVIDIA® GeForce RTX™ 4060 Laptop GPU 8GB GDDR6 Màn hình: 16" 16:10 QHD+(2560 x 1600), 240Hz, 100% DCI-P3, IPS-level panel Màu: Xám', N'LAPTOP-MSI-GAMING-SWORD-16-HX-B14VFKG-045VN', NULL, NULL, 1, 1, 1, 2, NULL, NULL)
INSERT [dbo].[sanphams] ([Id], [TenSanPham], [Gia], [Image1], [Image2], [Image3], [Mota], [Link], [ImageUrl], [ImageUrls], [KhoId], [SaleId], [HangId], [LoaiId], [loaisanphamId], [GiohangId]) VALUES (20, N'APTOP MSI GAMING CYBORG 15 AI', CAST(29599000.00 AS Decimal(18, 2)), N'Laptop4_1.jpg', N'Laptop4_2.jpg', N'Laptop4_3.jpg', N'VCPU: Intel® Ultra Core 7-155H RAM: 16GB (8GBx2) DDR5 5600Mhz (Tối đa 96GB) Ổ cứng: 512GB SSD M.2 2280 PCIe 4.0x4 NVMe (Nâng cấp thay thế VGA: Nvidia Geforce RTX 4050 6GB GDDR6 Màn hình: 15.6" FHD ( 1920x1080 ), IPS-level, 144hz Màu: Đen', N'APTOP-MSI-GAMING-CYBORG -5-AI', NULL, NULL, 1, 1, 1, 2, NULL, NULL)
INSERT [dbo].[sanphams] ([Id], [TenSanPham], [Gia], [Image1], [Image2], [Image3], [Mota], [Link], [ImageUrl], [ImageUrls], [KhoId], [SaleId], [HangId], [LoaiId], [loaisanphamId], [GiohangId]) VALUES (21, N'LAPTOP ACER GAMING ASPIRE 7 A715-76G-5806', CAST(19999000.00 AS Decimal(18, 2)), N'Laptop5_1.jpg', N'Laptop5_2.jpg', N'Laptop5_3.jpg', N'CPU: Intel Core i5 12450H RAM: 16GB (2x 8GB) DDR4-3200MHz (2 khe, có thể thay thế, tối đa 32GB) Ổ cứng: 512GB SSD M.2 2280 PCIe NVMe (2 khe, rút ra thay thế được, tối đa 1TB SSD PCIe Gen4) VGA: NVIDIA GeForce RTX 3050 4GB GDDR6 Màn hình: 15.6 inch FHD IPS (1920 x 1080) Slim Benzel 144Hz; ComfyView IPS LED Màu: Đen', N'LAPTOP-ACER-GAMING-ASPIRE-7-A715-76G-5806', NULL, NULL, 1, 1, 4, 2, NULL, NULL)
INSERT [dbo].[sanphams] ([Id], [TenSanPham], [Gia], [Image1], [Image2], [Image3], [Mota], [Link], [ImageUrl], [ImageUrls], [KhoId], [SaleId], [HangId], [LoaiId], [loaisanphamId], [GiohangId]) VALUES (22, N'LAPTOP HP GAMING VICTUS 16-R0129TX', CAST(27999000.00 AS Decimal(18, 2)), N'Laptop6_1.jpg', N'Laptop6_2.jpg', N'Laptop6_3.jpg', N'CPU: Intel® Core™ i7 13700H RAM: 16GB DDR5-4800 MHz RAM (Còn trống 1 khe) Ổ cứng: 512GB PCIe® NVMe™ M.2 SSD VGA: NVIDIA® GeForce RTX 3050 4GB Màn hình: 16" FHD, 144 Hz, IPS, micro-edge, anti-glare, 250 nits, 45% NTSC Màu: Đen OS: Windows 11', N'LAPTOP-HP-GAMING-VICTUS-16-R0129TX', NULL, NULL, 1, 1, 5, 2, NULL, NULL)
INSERT [dbo].[sanphams] ([Id], [TenSanPham], [Gia], [Image1], [Image2], [Image3], [Mota], [Link], [ImageUrl], [ImageUrls], [KhoId], [SaleId], [HangId], [LoaiId], [loaisanphamId], [GiohangId]) VALUES (23, N'LAPTOP LENOVO GAMING LOQ 15IRX9', CAST(26299000.00 AS Decimal(18, 2)), N'Laptop7_1.jpg', N'Laptop7_2.jpg', N'Laptop3_3.jpg', N'CPU: Intel® Core™ i5-13450HX RAM: 16GB (16GBx1) DDR5-4800 SO-DIMM (Còn trống 1 khe, tối đa 32GB) Ổ cứng: 512GB PCIe® 4.0 NVMe™ M.2 SSD (Còn trống 1 khe M2, Tối đa 1TB) VGA: NVIDIA® GeForce RTX™ 4050 Laptop GPU 6GB GDDR6 Màn hình: 15.6" FHD (1920x1080) IPS 300nits Anti-glare, 100% sRGB, 144Hz, G-SYNC® Chất liệu : Chất liệu : Kim loại (Mặt A), Nhựa Màu sắc: Xám OS: Windows 11 Home', N'LAPTOP-LENOVO-GAMING-LOQ-15IRX9', NULL, NULL, 1, 1, 7, 2, NULL, NULL)
INSERT [dbo].[sanphams] ([Id], [TenSanPham], [Gia], [Image1], [Image2], [Image3], [Mota], [Link], [ImageUrl], [ImageUrls], [KhoId], [SaleId], [HangId], [LoaiId], [loaisanphamId], [GiohangId]) VALUES (24, N'LAPTOP LENOVO LEGION PRO 5 16IRX9', CAST(53499000.00 AS Decimal(18, 2)), N'Laptop8_1.jpg', N'Laptop8_2.jpg', N'Laptop8_3.jpg', N'CPU: Intel® Core™ i9-14900HX, 24C (8P + 16E) RAM: 32GB (2x16GB) SO-DIMM DDR5-5600 Ổ cứng: 1TB SSD M.2 2280 PCIe® 4.0x4 NVMe® (Còn trống 1 khe M2) VGA: NVIDIA® GeForce RTX™ 4070 8GB GDDR6 Màn hình: 16" WQXGA (2560x1600) IPS 500nits Anti-glare, 100% DCI-P3, 240Hz, DisplayHDR™ 400, Dolby® Vision®, G-SYNC®, Low Blue Light, High Gaming Performance Màu sắc: Xám Chất liệu: Nhôm (Mặt A) Nhựa ABS OS: Windows® 11 Home', N'LAPTOP-LENOVO-LEGION-PRO-5-16IRX9', NULL, NULL, 1, 1, 7, 2, NULL, NULL)
INSERT [dbo].[sanphams] ([Id], [TenSanPham], [Gia], [Image1], [Image2], [Image3], [Mota], [Link], [ImageUrl], [ImageUrls], [KhoId], [SaleId], [HangId], [LoaiId], [loaisanphamId], [GiohangId]) VALUES (25, N'LAPTOP LENOVO LEGION 5 15IAH7', CAST(21999000.00 AS Decimal(18, 2)), N'Laptop9_1.jpg', N'Laptop9_2.jpg', N'Laptop9_3.jpg', N'CPU: Intel Core i5-12500H RAM: 16GB (2x 8GB) SO-DIMM DDR5-4800MHz (Tối đa 16GB) Ổ cứng: 512GB SSD M.2 2280 PCIe 4.0x4 NVMe (Còn trống 1) VGA: NVIDIA® GeForce RTX™ 3050 4GB GDDR6 Màn hình: 15.6" FHD (1920x1080) IPS 300nits Anti-glare, 100% sRGB, 165Hz, Dolby® Vision™, G-SYNC® Chất liệu : Nhôm ( Mặt A ), nhựa PC-ABS Màu: Xám OS: Windows 11 Home', N'LAPTOP-LENOVO-LEGION-5-15IAH7', NULL, NULL, 1, 1, 7, 2, NULL, NULL)
INSERT [dbo].[sanphams] ([Id], [TenSanPham], [Gia], [Image1], [Image2], [Image3], [Mota], [Link], [ImageUrl], [ImageUrls], [KhoId], [SaleId], [HangId], [LoaiId], [loaisanphamId], [GiohangId]) VALUES (26, N'CARD MÀN HÌNH ASUS ROG STRIX RTX 4080 SUPER-O16G-GAMING', CAST(37999000.00 AS Decimal(18, 2)), N'LK_3_2.jpg', N'LK_3_1.jpg', N'LK_5_3.jpg', N'Nhân đồ họa: NVIDIA® GeForce RTX™ 4080 Super Nhân CUDA: 10420 Dung lượng bộ nhớ: 16GB GDDR6X Tốc độ bộ nhớ: 23 Gbps Giao diện bộ nhớ: 256-bit Nguồn khuyến nghị: 850W', NULL, NULL, NULL, 1, 1, 4, 3, NULL, NULL)
INSERT [dbo].[sanphams] ([Id], [TenSanPham], [Gia], [Image1], [Image2], [Image3], [Mota], [Link], [ImageUrl], [ImageUrls], [KhoId], [SaleId], [HangId], [LoaiId], [loaisanphamId], [GiohangId]) VALUES (27, N'MAINBOARD ASUS ROG MAXIMUS Z790 DARK HERO', CAST(17898000.00 AS Decimal(18, 2)), N'LK_4_1.jpg', N'LK_4_2.jpg', N'LK_4_3.jpg', N'Chipset: Intel Z790 Socket: LGA 1700 Form factor: ATX Memory: 4 khe DDR5 ( Tối đa 192GB)', NULL, NULL, NULL, 1, 1, 5, 3, NULL, NULL)
INSERT [dbo].[sanphams] ([Id], [TenSanPham], [Gia], [Image1], [Image2], [Image3], [Mota], [Link], [ImageUrl], [ImageUrls], [KhoId], [SaleId], [HangId], [LoaiId], [loaisanphamId], [GiohangId]) VALUES (28, N'NGUỒN  ASUS TUF GAMING 650W BRONZE', CAST(1459000.00 AS Decimal(18, 2)), N'LK_5_1.jpg', N'LK_5_2.jpg', N'LK_5_3.jpg', N'Tụ điện và cuộn cảm được kiểm tra khắt khe để đạt được Chứng nhận cấp Quân sự. Vòng bi quạt bi kép có độ bền gấp đôi so với các thiết kế vòng bi khác Một lớp phủ PCB bảo vệ chống lại độ ẩm, bụi và nhiệt độ khắc nghiệt. 80 Plus Certified được kiểm tra với các thành phần chất lượng cao mà vượt qua thử nghiệm nghiêm ngặt. Thiết kế quạt công nghệ hướng trục có trục quạt nhỏ hơn tạo điều kiện cho các cánh quạt dài hơn và vòng chắn giúp tăng áp suất không khí đi xuống. Công nghệ 0dB cho phép bạn chơi game nhẹ trong khoảng lặng tương đối. Các dây cáp có tay cầm giúp thiết bị của bạn trông sạch sẽ về mặt chiến thuật. Đầu nối CPU 8 chân 80cm (EPS 12V)', NULL, NULL, NULL, 1, 1, 5, 3, NULL, NULL)
INSERT [dbo].[sanphams] ([Id], [TenSanPham], [Gia], [Image1], [Image2], [Image3], [Mota], [Link], [ImageUrl], [ImageUrls], [KhoId], [SaleId], [HangId], [LoaiId], [loaisanphamId], [GiohangId]) VALUES (29, N'CHUỘT GAME LOGITECH G502X TRẮNG (910-006148)', CAST(1756000.00 AS Decimal(18, 2)), N'LK_6_1.jpg', N'LK_6_2.jpg', N'LK_6_3.jpg', N'Chuột game Logitech G502X Phiên bản nâng cấp thiết kế từ Logitech G502 Chuẩn kết nối: Dây USB Switch LIGHTFORCE với công nghệ lai giữa quang học và cơ học Mắt cảm biến Hero 25k DPI cao cấp Nút cuộn 4 chiều 2 chế độ lăn', N'CHUOT-GAME-LOGITECH-G502X-TRANG (910-006148)', NULL, NULL, 1, 1, 6, 4, NULL, NULL)
INSERT [dbo].[sanphams] ([Id], [TenSanPham], [Gia], [Image1], [Image2], [Image3], [Mota], [Link], [ImageUrl], [ImageUrls], [KhoId], [SaleId], [HangId], [LoaiId], [loaisanphamId], [GiohangId]) VALUES (30, N'Ổ CỨNG SSD KINGSTON KC600 512GB 2.5 INCH SATA3', CAST(14999000.00 AS Decimal(18, 2)), N'Ram_2_1.jpg', N'Ram_2_2.jpg', N'Ram_2_3.jpg', N'Dung lượng: 512GB Kích thước: 2.5" Kết nối: SATA 3 NAND: 3D-NAND Tốc độ đọc/ghi (tối đa): 550MB/s | 500MB/s', N'SSD-KINGSTON-KC600-512GB 2.5-INCH-SATA3', NULL, NULL, 1, 1, 2, 1, NULL, NULL)
INSERT [dbo].[sanphams] ([Id], [TenSanPham], [Gia], [Image1], [Image2], [Image3], [Mota], [Link], [ImageUrl], [ImageUrls], [KhoId], [SaleId], [HangId], [LoaiId], [loaisanphamId], [GiohangId]) VALUES (31, N'Ổ CỨNG SSD KINGSTON KC3000 1024GB NVME M.2 2280 PCIE GEN 4 X 4 (ĐỌC 7000MB/S, GHI 6000MB/S)-(SKC3000S/1024G)', CAST(2749000.00 AS Decimal(18, 2)), N'Ram_3_1.jpg', N'Ram_3_2.jpg', N'Ram_3_3.jpg', N'Ổ cứng tốc độ cao chuẩn NVME PCIe Gen 4 Tốc độ đọc: 7000Mb/s Tốc độ ghi: 6000Mb/s Dung lượng: 1TB', N'SSD-KINGSTON-KC3000-1024GB-NVME-M.2-2280-PCIE-GEN-4 X 4', NULL, NULL, 1, 1, 2, 1, NULL, NULL)
INSERT [dbo].[sanphams] ([Id], [TenSanPham], [Gia], [Image1], [Image2], [Image3], [Mota], [Link], [ImageUrl], [ImageUrls], [KhoId], [SaleId], [HangId], [LoaiId], [loaisanphamId], [GiohangId]) VALUES (32, N'Ổ CỨNG SSD SAMSUNG 990 PRO 4TB PCIE NVME 4.0X4 (ĐỌC 7450MB/S - GHI 6900MB/S) - (MZ-V9P4T0BW)', CAST(10599000.00 AS Decimal(18, 2)), N'Ram_4_3.jpg', N'Ram_4_1.jpg', N'Ram_4_2.jpg', N'Chuẩn SSD: M.2 PCIe Gen4.0 x4 NVMe 2.0 Tốc độ đọc: 7450 MB/s Tốc độ ghi: 6900 MB/s', N'SSD-SAMSUNG-990-PRO-4TB-PCIE-NVME', NULL, NULL, 1, 1, 1, 1, NULL, NULL)
INSERT [dbo].[sanphams] ([Id], [TenSanPham], [Gia], [Image1], [Image2], [Image3], [Mota], [Link], [ImageUrl], [ImageUrls], [KhoId], [SaleId], [HangId], [LoaiId], [loaisanphamId], [GiohangId]) VALUES (33, N'SSD WD SN580 BLUE 2TB M.2 2280 PCIE NVME 4X4', CAST(4599000.00 AS Decimal(18, 2)), N'Ram_5_1.jpg', N'Ram_5_2.jpg', N'Ram_5_3.jpg', N'SSD WD SN580 BLUE 2TB M.2 2280 PCIE NVME 4X4', N'SSD-WD-SN580-BLUE-2TB-M.2-2280-PCIE-NVME-4X4', NULL, NULL, 1, 1, 7, 1, NULL, NULL)
INSERT [dbo].[sanphams] ([Id], [TenSanPham], [Gia], [Image1], [Image2], [Image3], [Mota], [Link], [ImageUrl], [ImageUrls], [KhoId], [SaleId], [HangId], [LoaiId], [loaisanphamId], [GiohangId]) VALUES (34, N'Ổ CỨNG SSD SAMSUNG 990 PRO WITH HEATSINK 4TB PCIE NVME 4.0X4 (ĐỌC 7450MB/S - GHI 6900MB/S - (MZ-V9P4T0CW))', CAST(12899000.00 AS Decimal(18, 2)), N'Ram_6_3.jpg', N'Ram_6_2.jpg', N'Ram_6_1.jpg', N'Dung lượng ổ cứng: 4 TB Form Factor: M.2 2280 Chuẩn kết nối: PCIe Gen 4.0 x4 NVMe Tốc độ đọc tuần tự: 7450 MB/s Tốc độ ghi tuần tự: 6900 MB/s Độ bền (TBW): 600 TB', N'SSD-SAMSUNG-990-PRO', NULL, NULL, 1, 1, 6, 1, NULL, NULL)
INSERT [dbo].[sanphams] ([Id], [TenSanPham], [Gia], [Image1], [Image2], [Image3], [Mota], [Link], [ImageUrl], [ImageUrls], [KhoId], [SaleId], [HangId], [LoaiId], [loaisanphamId], [GiohangId]) VALUES (35, N'MÀN HÌNH GAMING LG 27GR75Q-B (27 INCH/QHD/IPS/165HZ/1MS)', CAST(6389000.00 AS Decimal(18, 2)), N'pc_2_1.jpg', N'pc_2_2.jpg', N'pc_2_3.jpg', N'Kích thước: 27 inch Độ phân giải: QHD 2560 x 1440 Tấm nền: IPS Tần số quét: 165Hz Thời gian phản hồi: 1ms Tỉ lệ tương phản: 1000:1 Độ sáng: 300 nits VESA: 100x100mm Cổng kết nối: HDMI, DisplayPort, Audio 3.5mm', N'MAN-HINH-GAMING-LG 27GR75Q-B', NULL, NULL, 1, 1, 4, 3, NULL, NULL)
INSERT [dbo].[sanphams] ([Id], [TenSanPham], [Gia], [Image1], [Image2], [Image3], [Mota], [Link], [ImageUrl], [ImageUrls], [KhoId], [SaleId], [HangId], [LoaiId], [loaisanphamId], [GiohangId]) VALUES (36, N'MÀN HÌNH GAMING AOC AG275QXL/74 (27 INCH/QHD/IPS/170HZ/1MS)', CAST(9095000.00 AS Decimal(18, 2)), N'pc_3_1.jpg', N'pc_3_2.jpg', N'pc_3_3.jpg', N'Kích thước: 27 " Độ phân giải: 2k 2560 x 1440 Tần số quét : 170hz Độ sáng: 400 cd/m3 Thời gian đáp ứng : 1ms (GtG) Màu sắc hiển thị: 1.07b Góc nhìn (CR10): 178°(H)/178°(V) Kết nối: HDMI 2.0 x 2, DisplayPort 1.4 x 2, 2x USB 3.2 Type A, 1x USB Type B, 1x Audio out (headphone), 1x Audio out (microphone) Phụ kiện : cáp nguồn, cáp DisplayPort, cáp HDMI', N'MAN-HINH-GAMING-AOC-AG275QXL/74', NULL, NULL, 1, 1, 8, 3, NULL, NULL)
INSERT [dbo].[sanphams] ([Id], [TenSanPham], [Gia], [Image1], [Image2], [Image3], [Mota], [Link], [ImageUrl], [ImageUrls], [KhoId], [SaleId], [HangId], [LoaiId], [loaisanphamId], [GiohangId]) VALUES (37, N'AY CẦM CHƠI GAME KHÔNG DÂY XBOX SERIES X CONTROLLER - FIRE VAPOR SPECIAL EDITION', CAST(1599000.00 AS Decimal(18, 2)), N'LK_7_3.jpg', N'LK_7_2.jpg', N'LK_7_1.jpg', N'Kết nối với bảng điều khiển Xbox bằng Xbox Wireless. Kết nối không dây với PC, máy tính bảng, iOS và Android chạy Windows 10/11 bằng Bluetooth. Tương thích với: Xbox Series X, Xbox Series S, Windows 10/11, Android, and iOS. Pin: Pin AA cho thời gian sử dụng lên tới 40 giờ', N'TAY-CAM-CHOI-GAME-XBOX-SERIES-X-CONTROLLER - FIRE-VAPOR-SPECIAL EDITION', NULL, NULL, 1, 1, 5, 4, NULL, NULL)
INSERT [dbo].[sanphams] ([Id], [TenSanPham], [Gia], [Image1], [Image2], [Image3], [Mota], [Link], [ImageUrl], [ImageUrls], [KhoId], [SaleId], [HangId], [LoaiId], [loaisanphamId], [GiohangId]) VALUES (38, N'BÀN PHÍM CƠ VGN N75 PRO ORANGE VAPORWARE SWITCH (3 MODES)', CAST(1229000.00 AS Decimal(18, 2)), N'LK_8_1.jpg', N'LK_8_2.jpg', N'LK_8_3.jpg', N'Bàn Phím Cơ VGN N75 PRO Orange Chuẩn kêt nối: Wireless 2.4Ghz / Bluetooth / Dây USB Layout 75% 82 phím gọn nhẹ, đầy đủ chức năng Kết cấu Gasket Mount - Có foam Poron và lót đáy Silicone Switch Vaporware (Tactile) - Mạch hỗ trợ Hotswap switch 5pin Keycap PBT Doubleshot Led RGB 16.8 triệu màu Tích hợp núm xoay volume bằng kim loại Dung lượng pin 4000mAh', N'PHIM-CO-VGN-N75-PRO-ORANGE-VAPORWARE-SWITCH', NULL, NULL, 1, 1, 4, 4, NULL, NULL)
INSERT [dbo].[sanphams] ([Id], [TenSanPham], [Gia], [Image1], [Image2], [Image3], [Mota], [Link], [ImageUrl], [ImageUrls], [KhoId], [SaleId], [HangId], [LoaiId], [loaisanphamId], [GiohangId]) VALUES (39, N'BÀN PHÍM CƠ AKKO 3087 RF ONE PIECE - LUFFY (AKKO SWITCH V3 - CREAM YELLOW)', CAST(1399999.00 AS Decimal(18, 2)), N'LK_9_1.jpg', N'LK_9_2.jpg', N'LK_9_3.jpg', N'Model: 3087 (TKL, 87 keys) Kết nối: USB Type-C to Type-A (dây có thể tháo rời) hoặc không dây 2.4Ghz (sử dụng pin AAA) Kích thước: 360 x 140 x 40mm | Trọng lượng ~ 0.95 kg Tích hợp sẵn foam tiêu âm PCB Hỗ trợ NKRO / Multimedia / Macro / Khóa phím windows Keycap: PBT Dye-Subbed, OEM profile Loại switch: Akko switch v3 (Cream Blue / Cream Yellow) Phụ kiện: 1 sách hướng dẫn sử dụng + 1 keypuller + 1 cover che bụi + 1 dây cáp USB Type-C to USB + 2 pin AAA + Keycap tặng kèm Tương thích: Windows / MacOS / Linux Bàn phím AKKO khi kết nối với MacOS: (Ctrl -> Control | Windows -> Command | Alt -> Option, Mojave OS trở lên sẽ điều chỉnh được thứ tự của các phím này)', N'BAN-PHIM-CO-AKKO-3087-RF-ONE-PIECE - LUFFY', NULL, NULL, 1, 1, 7, 4, NULL, NULL)
SET IDENTITY_INSERT [dbo].[sanphams] OFF
GO
SET IDENTITY_INSERT [dbo].[tinhtrangcomments] ON 

INSERT [dbo].[tinhtrangcomments] ([Id], [Name]) VALUES (1, N'Đã mua hàng')
INSERT [dbo].[tinhtrangcomments] ([Id], [Name]) VALUES (2, N'Chưa mua hàng')
SET IDENTITY_INSERT [dbo].[tinhtrangcomments] OFF
GO
ALTER TABLE [dbo].[accounts]  WITH CHECK ADD  CONSTRAINT [FK_accounts_giohangs_GiohangId] FOREIGN KEY([GiohangId])
REFERENCES [dbo].[giohangs] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[accounts] CHECK CONSTRAINT [FK_accounts_giohangs_GiohangId]
GO
ALTER TABLE [dbo].[accounts]  WITH CHECK ADD  CONSTRAINT [FK_accounts_ranks_RankId] FOREIGN KEY([RankId])
REFERENCES [dbo].[ranks] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[accounts] CHECK CONSTRAINT [FK_accounts_ranks_RankId]
GO
ALTER TABLE [dbo].[chitietgiohangs]  WITH CHECK ADD  CONSTRAINT [FK_chitietgiohangs_comments_CommentId] FOREIGN KEY([CommentId])
REFERENCES [dbo].[comments] ([Id])
GO
ALTER TABLE [dbo].[chitietgiohangs] CHECK CONSTRAINT [FK_chitietgiohangs_comments_CommentId]
GO
ALTER TABLE [dbo].[chitietgiohangs]  WITH CHECK ADD  CONSTRAINT [FK_chitietgiohangs_giohangs_GioHangId] FOREIGN KEY([GioHangId])
REFERENCES [dbo].[giohangs] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[chitietgiohangs] CHECK CONSTRAINT [FK_chitietgiohangs_giohangs_GioHangId]
GO
ALTER TABLE [dbo].[chitietgiohangs]  WITH CHECK ADD  CONSTRAINT [FK_chitietgiohangs_sanphams_SanphamId] FOREIGN KEY([SanphamId])
REFERENCES [dbo].[sanphams] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[chitietgiohangs] CHECK CONSTRAINT [FK_chitietgiohangs_sanphams_SanphamId]
GO
ALTER TABLE [dbo].[chitiethoadons]  WITH CHECK ADD  CONSTRAINT [FK_chitiethoadons_accounts_AccountId] FOREIGN KEY([AccountId])
REFERENCES [dbo].[accounts] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[chitiethoadons] CHECK CONSTRAINT [FK_chitiethoadons_accounts_AccountId]
GO
ALTER TABLE [dbo].[chitiethoadons]  WITH CHECK ADD  CONSTRAINT [FK_chitiethoadons_hoadons_HoaDonId] FOREIGN KEY([HoaDonId])
REFERENCES [dbo].[hoadons] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[chitiethoadons] CHECK CONSTRAINT [FK_chitiethoadons_hoadons_HoaDonId]
GO
ALTER TABLE [dbo].[chitiethoadons]  WITH CHECK ADD  CONSTRAINT [FK_chitiethoadons_sanphams_SanphamId] FOREIGN KEY([SanphamId])
REFERENCES [dbo].[sanphams] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[chitiethoadons] CHECK CONSTRAINT [FK_chitiethoadons_sanphams_SanphamId]
GO
ALTER TABLE [dbo].[chiTietLSHDs]  WITH CHECK ADD  CONSTRAINT [FK_chiTietLSHDs_accounts_AccountId] FOREIGN KEY([AccountId])
REFERENCES [dbo].[accounts] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[chiTietLSHDs] CHECK CONSTRAINT [FK_chiTietLSHDs_accounts_AccountId]
GO
ALTER TABLE [dbo].[chiTietLSHDs]  WITH CHECK ADD  CONSTRAINT [FK_chiTietLSHDs_sanphams_SanphamId] FOREIGN KEY([SanphamId])
REFERENCES [dbo].[sanphams] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[chiTietLSHDs] CHECK CONSTRAINT [FK_chiTietLSHDs_sanphams_SanphamId]
GO
ALTER TABLE [dbo].[comments]  WITH CHECK ADD  CONSTRAINT [FK_comments_accounts_AccountId] FOREIGN KEY([AccountId])
REFERENCES [dbo].[accounts] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[comments] CHECK CONSTRAINT [FK_comments_accounts_AccountId]
GO
ALTER TABLE [dbo].[comments]  WITH CHECK ADD  CONSTRAINT [FK_comments_sanphams_SanphamId] FOREIGN KEY([SanphamId])
REFERENCES [dbo].[sanphams] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[comments] CHECK CONSTRAINT [FK_comments_sanphams_SanphamId]
GO
ALTER TABLE [dbo].[comments]  WITH CHECK ADD  CONSTRAINT [FK_comments_tinhtrangcomments_TinhtrangcommentId] FOREIGN KEY([TinhtrangcommentId])
REFERENCES [dbo].[tinhtrangcomments] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[comments] CHECK CONSTRAINT [FK_comments_tinhtrangcomments_TinhtrangcommentId]
GO
ALTER TABLE [dbo].[khos]  WITH CHECK ADD  CONSTRAINT [FK_khos_trusos_TrusoId] FOREIGN KEY([TrusoId])
REFERENCES [dbo].[trusos] ([Id])
GO
ALTER TABLE [dbo].[khos] CHECK CONSTRAINT [FK_khos_trusos_TrusoId]
GO
ALTER TABLE [dbo].[sanphams]  WITH CHECK ADD  CONSTRAINT [FK_sanphams_giohangs_GiohangId] FOREIGN KEY([GiohangId])
REFERENCES [dbo].[giohangs] ([Id])
GO
ALTER TABLE [dbo].[sanphams] CHECK CONSTRAINT [FK_sanphams_giohangs_GiohangId]
GO
ALTER TABLE [dbo].[sanphams]  WITH CHECK ADD  CONSTRAINT [FK_sanphams_hangs_HangId] FOREIGN KEY([HangId])
REFERENCES [dbo].[hangs] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[sanphams] CHECK CONSTRAINT [FK_sanphams_hangs_HangId]
GO
ALTER TABLE [dbo].[sanphams]  WITH CHECK ADD  CONSTRAINT [FK_sanphams_khos_KhoId] FOREIGN KEY([KhoId])
REFERENCES [dbo].[khos] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[sanphams] CHECK CONSTRAINT [FK_sanphams_khos_KhoId]
GO
ALTER TABLE [dbo].[sanphams]  WITH CHECK ADD  CONSTRAINT [FK_sanphams_loaisanphams_loaisanphamId] FOREIGN KEY([loaisanphamId])
REFERENCES [dbo].[loaisanphams] ([Id])
GO
ALTER TABLE [dbo].[sanphams] CHECK CONSTRAINT [FK_sanphams_loaisanphams_loaisanphamId]
GO
ALTER TABLE [dbo].[sanphams]  WITH CHECK ADD  CONSTRAINT [FK_sanphams_sales_SaleId] FOREIGN KEY([SaleId])
REFERENCES [dbo].[sales] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[sanphams] CHECK CONSTRAINT [FK_sanphams_sales_SaleId]
GO
