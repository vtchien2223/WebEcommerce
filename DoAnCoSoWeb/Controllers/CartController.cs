using DoAnCoSoWeb.Models;
using DoAnCoSoWeb.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using Newtonsoft.Json;
using System.Linq;
using System.Security.Claims;
using Microsoft.AspNetCore.Http.Extensions;



namespace DoAnCoSoWeb.Controllers
{
    public class CartController : Controller
    {
        private readonly ApplicationDbContext _context;
        private const string CartSession = "CartSession";
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CartController(ApplicationDbContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<IActionResult> Index()
        {
            var accountId = HttpContext.Session.GetInt32("AccountId"); // Lấy AccountId từ session

            if (accountId != null)
            {
                // Tìm giỏ hàng dựa trên AccountId
                var gioHang = _context.giohangs.Include(g => g.chiTietGioHangs).FirstOrDefault(g => g.Account.Id == accountId);

                if (gioHang != null)
                {
                    // Lấy danh sách sản phẩm trong giỏ hàng
                    var danhSachChiTietGioHang = gioHang.chiTietGioHangs;

                    var viewModelGioHang = new CartViewModels
                    {
                        sanphams = await _context.sanphams.ToListAsync(),
                        chiTietGioHangs = danhSachChiTietGioHang
                    };

                    return View(viewModelGioHang);
                }
                else
                {
                    // Xử lý trường hợp không tìm thấy giỏ hàng
                    return View(); // Hoặc chuyển hướng đến trang lỗi
                }
            }
            else
            {
                return RedirectToAction("Login", "Account"); // Nếu AccountId không tồn tại, điều hướng người dùng đến trang đăng nhập
            }
        }

        public IActionResult AddItem(int ProductId, int Quantity)
        {
            var product = _context.sanphams.Find(ProductId);
            var accountId = HttpContext.Session.GetInt32("AccountId"); // Lấy AccountId từ session

            if (accountId != null)
            {
                // Tìm giỏ hàng dựa trên AccountId
                var gioHang = _context.giohangs.Include(g => g.chiTietGioHangs).FirstOrDefault(g => g.Account.Id == accountId);

                if (gioHang == null)
                {
                    // Nếu không tìm thấy giỏ hàng, tạo một giỏ hàng mới
                    gioHang = new Giohang();
                    gioHang.Account.Id = accountId.Value;
                    _context.giohangs.Add(gioHang);
                    _context.SaveChanges();
                }

                // Kiểm tra xem sản phẩm đã có trong giỏ hàng chưa
                var chiTietGioHang = gioHang.chiTietGioHangs.FirstOrDefault(x => x.SanphamId == ProductId);

                if (chiTietGioHang != null)
                {
                    // Nếu đã có, cập nhật số lượng trong cơ sở dữ liệu
                    chiTietGioHang.Quantity += Quantity;
                    _context.Update(chiTietGioHang);
                }
                else
                {
                    // Nếu chưa có, thêm mục mới vào cơ sở dữ liệu
                    chiTietGioHang = new ChiTietGioHang
                    {
                        SanPhams = product,
                        Quantity = Quantity,
                        GioHangId = gioHang.Id
                    };

                    gioHang.chiTietGioHangs.Add(chiTietGioHang);
                    _context.chitietgiohangs.Add(chiTietGioHang);
                }

                _context.SaveChanges(); // Lưu thay đổi vào cơ sở dữ liệu

                return RedirectToAction("Index", "Home"); // Hoặc chuyển hướng đến trang giỏ hàng
            }
            else
            {
                return RedirectToAction("Login", "Account"); // Nếu AccountId không tồn tại, điều hướng người dùng đến trang đăng nhập
            }
        }

        public IActionResult DeleteAll()
        {
            var accountId = HttpContext.Session.GetInt32("AccountId"); // Lấy AccountId từ session

            if (accountId != null)
            {
                // Tìm tất cả các mục trong giỏ hàng dựa trên AccountId
                var items = _context.chitietgiohangs.Where(x => x.GioHangId == accountId);

                if (items.Any())
                {
                    // Xóa tất cả các mục khỏi cơ sở dữ liệu
                    _context.chitietgiohangs.RemoveRange(items);
                    _context.SaveChanges();
                }

                return Json(new
                {
                    status = true
                });
            }
            else
            {
                return RedirectToAction("Login", "Account"); // Nếu AccountId không tồn tại, điều hướng người dùng đến trang đăng nhập
            }
        }


        public IActionResult Delete(int id)
        {
            var accountId = HttpContext.Session.GetInt32("AccountId"); // Lấy AccountId từ session

            if (accountId != null)
            {
                // Tìm mục trong giỏ hàng dựa trên ID sản phẩm và AccountId
                var item = _context.chitietgiohangs.FirstOrDefault(x => x.SanPhams.Id == id && x.GioHangId == accountId);

                if (item != null)
                {
                    // Xóa mục khỏi cơ sở dữ liệu
                    _context.chitietgiohangs.Remove(item);
                    _context.SaveChanges();
                }

                return Json(new
                {
                    status = true
                });
            }
            else
            {
                return RedirectToAction("Login", "Account"); // Nếu AccountId không tồn tại, điều hướng người dùng đến trang đăng nhập
            }
        }

        [HttpPost]
        public IActionResult Update(int id, int quantity)
        {
            var accountId = HttpContext.Session.GetInt32("AccountId"); // Lấy AccountId từ session

            if (accountId != null)
            {
                // Tìm mục trong giỏ hàng dựa trên ID sản phẩm và AccountId
                var item = _context.chitietgiohangs.FirstOrDefault(x => x.SanPhams.Id == id && x.GioHangId == accountId);

                if (item != null)
                {
                    // Cập nhật số lượng trong cơ sở dữ liệu
                    item.Quantity += quantity;
                    if (item.Quantity <= 0)
                    {
                        // Nếu số lượng sau khi cập nhật là 0 hoặc ít hơn, xóa mục khỏi giỏ hàng
                        _context.chitietgiohangs.Remove(item);
                    }
                    else
                    {
                        // Nếu không, cập nhật mục trong cơ sở dữ liệu
                        _context.Update(item);
                    }

                    _context.SaveChanges(); // Lưu thay đổi vào cơ sở dữ liệu

                    return Json(new
                    {
                        status = true
                    });
                }
                else
                {
                    return Json(new
                    {
                        status = false,
                        message = "Không tìm thấy sản phẩm trong giỏ hàng."
                    });
                }
            }
            else
            {
                return RedirectToAction("Login", "Account"); // Nếu AccountId không tồn tại, điều hướng người dùng đến trang đăng nhập
            }
        }

        [HttpGet]
        public async Task<IActionResult> Payment()
        {
            var accountId = HttpContext.Session.GetInt32("AccountId"); // Lấy AccountId từ session

            if (accountId != null)
            {
                // Lấy danh sách sản phẩm từ giỏ hàng của người dùng
                var cartItems = _context.chitietgiohangs
                    .Include(item => item.SanPhams)
                    .Where(item => item.GioHangId == accountId.Value)
                    .ToList();

                // Tạo ViewModel cho View Payment
                var cartViewModel = new CartViewModels
                {
                    chiTietGioHangs = cartItems
                };

                return View(cartViewModel);
            }
            else
            {
                return RedirectToAction("Login", "Account"); // Nếu AccountId không tồn tại, điều hướng người dùng đến trang đăng nhập
            }
        }
        [HttpPost]
        public async Task<IActionResult> Payment(List<int> selectedProducts)
        {
            var accountId = HttpContext.Session.GetInt32("AccountId");

            if (accountId != null)
            {
                if (selectedProducts != null && selectedProducts.Any())
                {
                    // Lấy danh sách sản phẩm đã chọn từ giỏ hàng của tài khoản hiện đang đăng nhập
                    var selectedItems = _context.chitietgiohangs
                        .Include(item => item.SanPhams)
                        .Where(item => selectedProducts.Contains(item.SanphamId) && item.GioHangId == accountId.Value)
                        .ToList();

                    if (selectedItems.Any())
                    {
                        var cartViewModel = new CartViewModels
                        {
                            chiTietGioHangs = selectedItems,
                            selectedProducts = selectedProducts
                        };

                        return View(cartViewModel);
                    }
                }

                // Xử lý khi không có sản phẩm nào được chọn hoặc không tìm thấy sản phẩm
                TempData["ErrorMessage"] = "Vui lòng chọn sản phẩm để thanh toán.";
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
        }



        [HttpPost]
		public IActionResult PaymentConfirmation(CartViewModels model)
		{
			var accountId = _httpContextAccessor.HttpContext.Session.GetInt32("AccountId");

			if (accountId != null)
			{
				var account = _context.accounts.FirstOrDefault(a => a.Id == accountId.Value);
				if (account != null && model.selectedProducts != null && model.selectedProducts.Any())
				{
					var selectedItems = _context.chitietgiohangs
						.Include(item => item.SanPhams)
						.Where(item => model.selectedProducts.Contains(item.SanphamId) && item.GioHangId == accountId.Value)
						.ToList();

					if (selectedItems.Any())
					{
						var order = new Hoadon
						{
							NgayLap = DateTime.Now,
							chiTietHoaDons = new List<ChiTietHoaDon>()
						};

						foreach (var item in selectedItems)
						{
							var detail = new ChiTietHoaDon
							{
								SanphamId = item.SanphamId,
								SoLuong = item.Quantity,
								ThanhTien = item.SanPhams.Gia * item.Quantity,
								AccountId = accountId.Value,
								Phone = account.SoDienThoai,
								DiaChi = account.DiaChi
							};

							order.chiTietHoaDons.Add(detail);
						}

						_context.hoadons.Add(order);
						_context.SaveChanges();

						_context.chitietgiohangs.RemoveRange(selectedItems);
						_context.SaveChanges();

						TempData["SuccessMessage"] = "Đặt hàng thành công!";
						return RedirectToAction("Success");
					}
				}
			}

			TempData["ErrorMessage"] = "Vui lòng chọn sản phẩm để thanh toán.";
			return RedirectToAction("Index");
		}


		public async Task<IActionResult> Success()
        {
            return View();
        }


        public async Task<IActionResult> _Search()
        {
            return View();
        }
    }
}

