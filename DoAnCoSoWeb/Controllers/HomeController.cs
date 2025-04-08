using DoAnCoSoWeb.Models;
using DoAnCoSoWeb.Repository;
using DoAnCoSoWeb.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace DoAnCoSoWeb.Controllers
{
	public class HomeController : Controller
	{
		private readonly ApplicationDbContext _context;

		public HomeController(ApplicationDbContext context)
		{
			_context = context;
		}

        /*public async Task<IActionResult> Index(string sortOrder, decimal? minPrice, decimal? maxPrice, string hangId)
		{
			var sanphams = _context.sanphams.AsQueryable();
			var hangs = await _context.hangs.ToListAsync();

			// Lọc sản phẩm theo hãng
			if (!string.IsNullOrEmpty(hangId))
			{
				if (int.TryParse(hangId, out int hangIdInt))
				{
					sanphams = sanphams.Where(s => s.HangId == hangIdInt);
				}
			}

			// Lọc sản phẩm theo khoảng giá
			if (minPrice.HasValue)
			{
				sanphams = sanphams.Where(s => s.Gia >= minPrice.Value);
			}

			if (maxPrice.HasValue)
			{
				sanphams = sanphams.Where(s => s.Gia <= maxPrice.Value);
			}

			// Sắp xếp sản phẩm
			sanphams = sortOrder switch
			{
				"lowToHigh" => sanphams.OrderBy(s => s.Gia),
				"highToLow" => sanphams.OrderByDescending(s => s.Gia),
				_ => sanphams
			};

			// Truy vấn cơ sở dữ liệu để lấy thông tin số lượng đã bán của mỗi sản phẩm
			var soldQuantities = await _context.chitiethoadons
				.GroupBy(c => c.SanphamId)
				.Select(g => new
				{
					SanPhamId = g.Key,
					SoLuongDaBan = g.Sum(x => x.SoLuong)
				})
				.ToDictionaryAsync(x => x.SanPhamId, x => x.SoLuongDaBan);

			// Lấy sản phẩm có IdSale là 1
			var saleProducts = await _context.sanphams
				.Where(s => s.SaleId == 1)
				.ToListAsync();
			var pcProducts = await _context.sanphams
				.Where(s => s.LoaiId == 1)
				.ToListAsync();
			var laptopProducts = await _context.sanphams
				.Where(s => s.LoaiId == 2)
				.ToListAsync();
			var linhkienProducts = await _context.sanphams
				.Where(s => s.LoaiId == 3)
				.ToListAsync();
			var gearProducts = await _context.sanphams
				.Where(s => s.LoaiId == 4)
				.ToListAsync();
			var viewModel = new HomeViewModels
			{
				hangs = hangs,
				sanphams = await sanphams.ToListAsync(),
				soldQuantities = soldQuantities,
				MinPrice = minPrice,
				MaxPrice = maxPrice,
				SaleProducts = saleProducts,
				PCProducts = pcProducts,
				LaptopProducts = laptopProducts,
				LinhKienProducts = linhkienProducts,
				GearProducts = gearProducts
			};

			return View(viewModel);
		}*/
        public async Task<IActionResult> Index(string sortOrder, decimal? minPrice, decimal? maxPrice, string hangId)
        {
            var sanphams = _context.sanphams.AsQueryable();
            var hangs = await _context.hangs.ToListAsync();

            // Lọc sản phẩm theo hãng
            if (!string.IsNullOrEmpty(hangId))
            {
                if (int.TryParse(hangId, out int hangIdInt))
                {
                    sanphams = sanphams.Where(s => s.HangId == hangIdInt);
                }
            }

            // Lọc sản phẩm theo khoảng giá
            if (minPrice.HasValue)
            {
                sanphams = sanphams.Where(s => s.Gia >= minPrice.Value);
            }

            if (maxPrice.HasValue)
            {
                sanphams = sanphams.Where(s => s.Gia <= maxPrice.Value);
            }

            // Sắp xếp sản phẩm
            sanphams = sortOrder switch
            {
                "lowToHigh" => sanphams.OrderBy(s => s.Gia),
                "highToLow" => sanphams.OrderByDescending(s => s.Gia),
                _ => sanphams
            };

            // Truy vấn cơ sở dữ liệu để lấy thông tin số lượng đã bán của mỗi sản phẩm
            var soldQuantities = await _context.chitiethoadons
                .GroupBy(c => c.SanphamId)
                .Select(g => new
                {
                    SanPhamId = g.Key,
                    SoLuongDaBan = g.Sum(x => x.SoLuong)
                })
                /*.Where(x => x.SoLuongDaBan > 10) // Chỉ lấy những sản phẩm có số lượng bán lớn hơn 10*/
                .ToDictionaryAsync(x => x.SanPhamId, x => x.SoLuongDaBan);

            // Lấy sản phẩm có IdSale là 1
            /*var saleProducts = await _context.sanphams
                .Where(s => s.SaleId == 1)
                .ToListAsync();
            var pcProducts = await _context.sanphams
                .Where(s => s.LoaiId == 1)
                .ToListAsync();
            var laptopProducts = await _context.sanphams
                .Where(s => s.LoaiId == 2)
                .ToListAsync();
            var linhkienProducts = await _context.sanphams
                .Where(s => s.LoaiId == 3)
                .ToListAsync();
            var gearProducts = await _context.sanphams
                .Where(s => s.LoaiId == 4)
                .ToListAsync();*/
            var saleProducts = await _context.sanphams
                .Where(s => s.SaleId == 1)
                .Take(6)
                .ToListAsync();

            var pcProducts = await _context.sanphams
                .Where(s => s.LoaiId == 1)
                .Take(6)
                .ToListAsync();

            var laptopProducts = await _context.sanphams
                .Where(s => s.LoaiId == 2)
                .Take(6)
                .ToListAsync();

            var linhkienProducts = await _context.sanphams
                .Where(s => s.LoaiId == 3)
                .Take(6)
                .ToListAsync();

            var gearProducts = await _context.sanphams
                .Where(s => s.LoaiId == 4)
                .Take(6)
                .ToListAsync();

            var viewModel = new HomeViewModels
            {
                hangs = hangs,
                sanphams = await sanphams.ToListAsync(),
                soldQuantities = soldQuantities,
                MinPrice = minPrice,
                MaxPrice = maxPrice,
                SaleProducts = saleProducts,
                PCProducts = pcProducts,
                LaptopProducts = laptopProducts,
                LinhKienProducts = linhkienProducts,
                GearProducts = gearProducts
            };

            return View(viewModel);
        }


        public IActionResult MostSold()
		{
			var mostSoldProducts = _context.chitiethoadons
				.GroupBy(c => c.SanphamId)
				.Select(g => new
				{
					SanPhamId = g.Key,
					SoLuongMua = g.Sum(x => x.SoLuong)
				})
				.OrderByDescending(x => x.SoLuongMua)
				.ToList();

			var mostSoldProductIds = mostSoldProducts.Select(x => x.SanPhamId).ToList();

			var sanphams = _context.sanphams
				.Where(s => mostSoldProductIds.Contains(s.Id))
				.ToList();

			var sortedSanphams = sanphams
				.OrderByDescending(s => mostSoldProductIds.IndexOf(s.Id))
				.ToList();

			var viewModel = new HomeViewModels
			{
				sanphams = sortedSanphams,
				soldQuantities = mostSoldProducts.ToDictionary(x => x.SanPhamId, x => x.SoLuongMua)
			};

			return View(viewModel);
		}

		[HttpGet]
		public IActionResult IsLoggedIn()
		{
			var status = User.Identity.IsAuthenticated;
			return Json(new { status });
		}

		public async Task<IActionResult> ProdDetail(long id, int page = 1)
		{
			if (id <= 0)
			{
				return RedirectToAction("Index", "Error");
			}

			var product = await _context.sanphams.FirstOrDefaultAsync(m => m.Id == id);
			if (product == null)
			{
				var errorViewModel = new ErrorViewModel
				{
					RequestId = "Product Error",
				};
				return View("Error", errorViewModel);
			}

			int pageSize = 10;
			var comments = await _context.comments
				.Where(c => c.SanphamId == id)
				.Include(c => c.Account)
				.Include(c => c.Tinhtrangcomment)
				.OrderByDescending(c => c.NgayComment)
				.Skip((page - 1) * pageSize)
				.Take(pageSize)
				.ToListAsync();

			var totalComments = await _context.comments.CountAsync(c => c.SanphamId == id);

			var viewModel = new HomeViewModels
			{
				sanphams = new List<Sanpham> { product },
				Comments = comments,
				CurrentPage = page,
				TotalPages = (int)Math.Ceiling(totalComments / (double)pageSize)
			};

			return View(viewModel);
		}

		[HttpPost]
		public async Task<IActionResult> AddComment(int productId, string note)
		{
			var accountId = HttpContext.Session.GetInt32("AccountId");
			if (!User.Identity.IsAuthenticated)
			{
				return Unauthorized();
			}

			var userBoughtProduct = await _context.chitiethoadons
				.AnyAsync(hd => hd.AccountId == accountId && hd.SanphamId == productId);

			var commentTinhTrangId = userBoughtProduct ? 1 : 2;

			var comment = new Comment
			{
				AccountId = accountId.Value,
				NgayComment = DateTime.Now,
				Note = note,
				SanphamId = productId,
				TinhtrangcommentId = commentTinhTrangId
			};

			_context.comments.Add(comment);
			await _context.SaveChangesAsync();

			return Json(new { success = true });
		}

        [HttpGet]
        public async Task<IActionResult> _Search(string query, int page = 1)
        {
            if (string.IsNullOrEmpty(query))
            {
                return RedirectToAction("Index");
            }

            int pageSize = 10;

            var products = await _context.sanphams
                .Where(p => p.TenSanPham.Contains(query))
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            var totalProducts = await _context.sanphams
                .Where(p => p.TenSanPham.Contains(query))
                .CountAsync();

            var viewModel = new HomeViewModels
            {
                sanphams = products,
                CurrentPage = page,
                TotalPages = (int)Math.Ceiling(totalProducts / (double)pageSize),
                Query = query // Truyền query vào viewModel để hiển thị lại trên view Search khi cần
            };

            return View("SearchResult", viewModel); // Sử dụng view SearchResult để hiển thị kết quả tìm kiếm
        }


        [HttpGet]
        public IActionResult SearchResult()
        {
            return View();
        }

        public async Task<IActionResult> RamProduct(string sortOrder, decimal? minPrice, decimal? maxPrice, int[] hangIds)
        {
            var hangs = await _context.hangs.ToListAsync();
            var sanphamsQuery = _context.sanphams.Where(m => m.LoaiId == 1);

            if (hangIds != null && hangIds.Any())
            {
                sanphamsQuery = sanphamsQuery.Where(s => hangIds.Contains(s.HangId) && s.LoaiId == 1);
            }
            else
            {
                sanphamsQuery = sanphamsQuery.Where(s => s.LoaiId == 1);
            }

            // Lọc sản phẩm theo khoảng giá
            if (minPrice.HasValue)
            {
                sanphamsQuery = sanphamsQuery.Where(s => s.Gia >= minPrice.Value);
            }

            if (maxPrice.HasValue)
            {
                sanphamsQuery = sanphamsQuery.Where(s => s.Gia <= maxPrice.Value);
            }

            // Truy vấn cơ sở dữ liệu để lấy thông tin số lượng đã bán của mỗi sản phẩm
            var soldQuantities = await _context.chitiethoadons
                .GroupBy(c => c.SanphamId)
                .Select(g => new
                {
                    SanPhamId = g.Key,
                    SoLuongDaBan = g.Sum(x => x.SoLuong)
                })
                .ToDictionaryAsync(x => x.SanPhamId, x => x.SoLuongDaBan);

            // Sắp xếp sản phẩm
            switch (sortOrder)
            {
                case "lowToHigh":
                    sanphamsQuery = sanphamsQuery.OrderBy(s => s.Gia);
                    break;
                case "highToLow":
                    sanphamsQuery = sanphamsQuery.OrderByDescending(s => s.Gia);
                    break;
                case "mostSold":
                    var mostSoldProductIds = await _context.chitiethoadons
                        .GroupBy(c => c.SanphamId)
                        .Select(g => new
                        {
                            SanPhamId = g.Key,
                            SoLuongMua = g.Sum(x => x.SoLuong)
                        })
                        .OrderByDescending(x => x.SoLuongMua)
                        .Select(x => x.SanPhamId)
                        .ToListAsync();

                    sanphamsQuery = sanphamsQuery.Where(s => mostSoldProductIds.Contains(s.Id) && s.LoaiId == 1);
                    break;
                default:
                    // Mặc định không sắp xếp
                    sanphamsQuery = sanphamsQuery.OrderBy(s => s.TenSanPham);
                    break;
            }

            var sanphams = await sanphamsQuery.ToListAsync();
            var viewModel = new HomeViewModels
            {
                hangs = hangs,
                sanphams = sanphams,
                soldQuantities = soldQuantities,
                MinPrice = minPrice,
                MaxPrice = maxPrice,
                SelectedHangIds = hangIds,
                SortOrder = sortOrder
            };

            return View(viewModel);
        }

        public async Task<IActionResult> PcProduct(string sortOrder, decimal? minPrice, decimal? maxPrice, int[] hangIds)
        {
            var hangs = await _context.hangs.ToListAsync();
            var sanphamsQuery = _context.sanphams.Where(m => m.LoaiId == 2);

            if (hangIds != null && hangIds.Any())
            {
                sanphamsQuery = sanphamsQuery.Where(s => hangIds.Contains(s.HangId) && s.LoaiId == 2);
            }
            else
            {
                sanphamsQuery = sanphamsQuery.Where(s => s.LoaiId == 2);
            }

            // Lọc sản phẩm theo khoảng giá
            if (minPrice.HasValue)
            {
                sanphamsQuery = sanphamsQuery.Where(s => s.Gia >= minPrice.Value && s.LoaiId == 2);
            }

            if (maxPrice.HasValue)
            {
                sanphamsQuery = sanphamsQuery.Where(s => s.Gia <= maxPrice.Value && s.LoaiId == 2);
            }

            // Truy vấn cơ sở dữ liệu để lấy thông tin số lượng đã bán của mỗi sản phẩm
            var soldQuantities = await _context.chitiethoadons
                .GroupBy(c => c.SanphamId)
                .Select(g => new
                {
                    SanPhamId = g.Key,
                    SoLuongDaBan = g.Sum(x => x.SoLuong)
                })
                .ToDictionaryAsync(x => x.SanPhamId, x => x.SoLuongDaBan);

            // Sắp xếp sản phẩm
            switch (sortOrder)
            {
                case "lowToHigh":
                    sanphamsQuery = sanphamsQuery.OrderBy(s => s.Gia);
                    break;
                case "highToLow":
                    sanphamsQuery = sanphamsQuery.OrderByDescending(s => s.Gia);
                    break;
                case "mostSold":
                    var mostSoldProductIds = await _context.chitiethoadons
                        .GroupBy(c => c.SanphamId)
                        .Select(g => new
                        {
                            SanPhamId = g.Key,
                            SoLuongMua = g.Sum(x => x.SoLuong)
                        })
                        .OrderByDescending(x => x.SoLuongMua)
                        .Select(x => x.SanPhamId)
                        .ToListAsync();

                    sanphamsQuery = sanphamsQuery.Where(s => mostSoldProductIds.Contains(s.Id));
                    break;
                default:
                    // Mặc định không sắp xếp
                    sanphamsQuery = sanphamsQuery.OrderBy(s => s.TenSanPham);
                    break;
            }

            var sanphams = await sanphamsQuery.ToListAsync();
            var viewModel = new HomeViewModels
            {
                hangs = hangs,
                sanphams = sanphams,
                soldQuantities = soldQuantities,
                MinPrice = minPrice,
                MaxPrice = maxPrice,
                SelectedHangIds = hangIds,
                SortOrder = sortOrder
            };

            return View(viewModel);
        }



        public async Task<IActionResult> LaptopProduct(string sortOrder, decimal? minPrice, decimal? maxPrice, int[] hangIds)
        {
            var hangs = await _context.hangs.ToListAsync();
            var sanphamsQuery = _context.sanphams.Where(m => m.LoaiId == 3);

            if (hangIds != null && hangIds.Any())
            {
                sanphamsQuery = sanphamsQuery.Where(s => hangIds.Contains(s.HangId) && s.LoaiId == 3);
            }
            else
            {
                sanphamsQuery = sanphamsQuery.Where(s => s.LoaiId == 3);
            }

            // Lọc sản phẩm theo khoảng giá
            if (minPrice.HasValue)
            {
                sanphamsQuery = sanphamsQuery.Where(s => s.Gia >= minPrice.Value);
            }

            if (maxPrice.HasValue)
            {
                sanphamsQuery = sanphamsQuery.Where(s => s.Gia <= maxPrice.Value);
            }

            // Truy vấn cơ sở dữ liệu để lấy thông tin số lượng đã bán của mỗi sản phẩm
            var soldQuantities = await _context.chitiethoadons
                .GroupBy(c => c.SanphamId)
                .Select(g => new
                {
                    SanPhamId = g.Key,
                    SoLuongDaBan = g.Sum(x => x.SoLuong)
                })
                .ToDictionaryAsync(x => x.SanPhamId, x => x.SoLuongDaBan);

            // Sắp xếp sản phẩm
            switch (sortOrder)
            {
                case "lowToHigh":
                    sanphamsQuery = sanphamsQuery.OrderBy(s => s.Gia);
                    break;
                case "highToLow":
                    sanphamsQuery = sanphamsQuery.OrderByDescending(s => s.Gia);
                    break;
                case "mostSold":
                    var mostSoldProductIds = await _context.chitiethoadons
                        .GroupBy(c => c.SanphamId)
                        .Select(g => new
                        {
                            SanPhamId = g.Key,
                            SoLuongMua = g.Sum(x => x.SoLuong)
                        })
                        .OrderByDescending(x => x.SoLuongMua)
                        .Select(x => x.SanPhamId)
                        .ToListAsync();

                    sanphamsQuery = sanphamsQuery.Where(s => mostSoldProductIds.Contains(s.Id) && s.LoaiId == 3);
                    break;
                default:
                    // Mặc định không sắp xếp
                    sanphamsQuery = sanphamsQuery.OrderBy(s => s.TenSanPham);
                    break;
            }

            var sanphams = await sanphamsQuery.ToListAsync();
            var viewModel = new HomeViewModels
            {
                hangs = hangs,
                sanphams = sanphams,
                soldQuantities = soldQuantities,
                MinPrice = minPrice,
                MaxPrice = maxPrice,
                SelectedHangIds = hangIds,
                SortOrder = sortOrder
            };

            return View(viewModel);
        }

        public async Task<IActionResult> LinhKiemProduct(string sortOrder, decimal? minPrice, decimal? maxPrice, int[] hangIds)
        {
            var hangs = await _context.hangs.ToListAsync();
            var sanphamsQuery = _context.sanphams.Where(m => m.LoaiId == 4);

            if (hangIds != null && hangIds.Any())
            {
                sanphamsQuery = sanphamsQuery.Where(s => hangIds.Contains(s.HangId) && s.LoaiId == 4);
            }
            else
            {
                sanphamsQuery = sanphamsQuery.Where(s => s.LoaiId == 4);
            }

            // Lọc sản phẩm theo khoảng giá
            if (minPrice.HasValue)
            {
                sanphamsQuery = sanphamsQuery.Where(s => s.Gia >= minPrice.Value);
            }

            if (maxPrice.HasValue)
            {
                sanphamsQuery = sanphamsQuery.Where(s => s.Gia <= maxPrice.Value);
            }

            // Truy vấn cơ sở dữ liệu để lấy thông tin số lượng đã bán của mỗi sản phẩm
            var soldQuantities = await _context.chitiethoadons
                .GroupBy(c => c.SanphamId)
                .Select(g => new
                {
                    SanPhamId = g.Key,
                    SoLuongDaBan = g.Sum(x => x.SoLuong)
                })
                .ToDictionaryAsync(x => x.SanPhamId, x => x.SoLuongDaBan);

            // Sắp xếp sản phẩm
            switch (sortOrder)
            {
                case "lowToHigh":
                    sanphamsQuery = sanphamsQuery.OrderBy(s => s.Gia);
                    break;
                case "highToLow":
                    sanphamsQuery = sanphamsQuery.OrderByDescending(s => s.Gia);
                    break;
                case "mostSold":
                    var mostSoldProductIds = await _context.chitiethoadons
                        .GroupBy(c => c.SanphamId)
                        .Select(g => new
                        {
                            SanPhamId = g.Key,
                            SoLuongMua = g.Sum(x => x.SoLuong)
                        })
                        .OrderByDescending(x => x.SoLuongMua)
                        .Select(x => x.SanPhamId)
                        .ToListAsync();

                    sanphamsQuery = sanphamsQuery.Where(s => mostSoldProductIds.Contains(s.Id) && s.LoaiId == 4);
                    break;
                default:
                    // Mặc định không sắp xếp
                    sanphamsQuery = sanphamsQuery.OrderBy(s => s.TenSanPham);
                    break;
            }

            var sanphams = await sanphamsQuery.ToListAsync();
            var viewModel = new HomeViewModels
            {
                hangs = hangs,
                sanphams = sanphams,
                soldQuantities = soldQuantities,
                MinPrice = minPrice,
                MaxPrice = maxPrice,
                SelectedHangIds = hangIds,
                SortOrder = sortOrder
            };

            return View(viewModel);
        }
    }
}
