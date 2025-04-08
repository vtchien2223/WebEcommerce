using DoAnCoSoWeb.Models;
using DoAnCoSoWeb.ViewModels;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Scripting;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc.Rendering;
using DoAnCoSoWeb.Repository;

namespace DoAnCoSoWeb.Controllers
{
    public class UserController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IRankRepository _rankRepository;
        public UserController(ApplicationDbContext context, IRankRepository rankrepository)
        {
            _context = context;
            _rankRepository = rankrepository;
        }

        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public async Task<IActionResult> Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(UserViewModels model)
        {
            var viewModel = new UserViewModels
            {
                Register = model.Register,
            };
            if (model.Register != null)
            {
                var existingUser = await _context.accounts.FirstOrDefaultAsync(u => u.Username == model.Register.Username);
                if (existingUser != null)
                {
                    ViewBag.ErrorMessage = "Tên đăng nhập đã tồn tại.";
                    return View(viewModel);
                }
                model.Register.MatKhau = BCrypt.Net.BCrypt.HashPassword(model.Register.MatKhau);

                // Tạo giỏ hàng mới
                var giohang = new Giohang();
                _context.giohangs.Add(giohang);
                await _context.SaveChangesAsync();

                // Cập nhật ID giỏ hàng vào tài khoản
                model.Register.GiohangId = giohang.Id;
                model.Register.RankId = 2;
                model.Register.AnhDaiDien = "no_avatar.png";
                _context.accounts.Add(model.Register);
                await _context.SaveChangesAsync();
                return RedirectToAction("Login", "User");
            }
            return View(viewModel);
        }

        [HttpGet]
        public async Task<IActionResult> Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(UserViewModels model)
        {
            var viewModel = new UserViewModels
            {
                Register = model.Register,
            };

            if (model.Register != null)
            {
                var user = await _context.accounts.FirstOrDefaultAsync(u => u.Username == model.Register.Username);
                if (user != null && BCrypt.Net.BCrypt.Verify(model.Register.MatKhau, user.MatKhau))
                {
                    var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.Username),
            };

                    var claimsIdentity = new ClaimsIdentity(
                        claims, CookieAuthenticationDefaults.AuthenticationScheme);

                    var authProperties = new AuthenticationProperties
                    {
                    };

                        await HttpContext.SignInAsync(
                        CookieAuthenticationDefaults.AuthenticationScheme,
                        new ClaimsPrincipal(claimsIdentity),
                        authProperties);

                    // Lưu AccountId vào session
                    HttpContext.Session.SetInt32("AccountId", user.Id);

                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ViewBag.ErrorMessage = "Tên đăng nhập hoặc mật khẩu không đúng.";
                    return View(viewModel);
                }
            }
            return View(viewModel);
        }


        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> Info()
        {
            Account user = null;

            if (User.Identity.IsAuthenticated)
            {
                string username = User.Identity.Name;
                if (!string.IsNullOrEmpty(username))
                {
                    user = await _context.accounts.Include(a => a.Rank).FirstOrDefaultAsync(m => m.Username == username);
                }
            }

            if (user == null)
            {
                TempData["ErrorMessage"] = "Không tìm thấy người dùng.";
                return RedirectToAction("Index", "Home"); // Hoặc trang phù hợp nếu không tìm thấy người dùng
            }

            return View(user);
        }

        private async Task<string> SaveImage(IFormFile image)
        {
            var savePath = Path.Combine("wwwroot/image", image.FileName);
            using (var fileStream = new FileStream(savePath, FileMode.Create))
            {
                await image.CopyToAsync(fileStream);
            }
            return  image.FileName;
        }

        [HttpGet]
        public IActionResult EditInfo()
        {
            var accountId = HttpContext.Session.GetInt32("AccountId");
            if (accountId != null)
            {
                var account = _context.accounts
                    .Include(a => a.Rank)
                    .FirstOrDefault(a => a.Id == accountId.Value);

                if (account != null)
                {
                    return View(account);
                }
            }

            TempData["ErrorMessage"] = "Không tìm thấy tài khoản.";
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> EditInfo(Account model, IFormFile AnhDaiDienFile)
        {
            if (ModelState.IsValid)
            {
                var account = await _context.accounts.FindAsync(model.Id);

                if (account != null)
                {
                    // Cập nhật các thuộc tính khác
                    account.Username = model.Username;
                    account.SoDienThoai = model.SoDienThoai;
                    account.Email = model.Email;
                    account.DiaChi = model.DiaChi;
                    account.Rank = model.Rank;

                    // Kiểm tra nếu AnhDaiDienFile không null và có độ dài lớn hơn 0 (tức là người dùng đã chọn một tệp mới)
                    if (AnhDaiDienFile != null && AnhDaiDienFile.Length > 0)
                    {
                        try
                        {
                            // Lưu tên tệp ảnh mới vào cơ sở dữ liệu
                            account.AnhDaiDien = await SaveImage(AnhDaiDienFile);
                        }
                        catch (Exception ex)
                        {
                            // Xử lý lỗi khi lưu ảnh
                            Console.WriteLine($"Lỗi khi lưu ảnh đại diện: {ex.Message}");
                            TempData["ErrorMessage"] = "Có lỗi xảy ra khi lưu ảnh đại diện.";
                            return View(model);
                        }
                    }

                    try
                    {
                        // Cập nhật và lưu thay đổi vào cơ sở dữ liệu
                        _context.Update(account);
                        await _context.SaveChangesAsync();
                        TempData["SuccessMessage"] = "Cập nhật thông tin thành công!";
                        return RedirectToAction("Info", "User"); // Quay lại trang "Info"
                    }
                    catch (Exception ex)
                    {
                        // Ghi log lỗi
                        Console.WriteLine($"Lỗi khi lưu thay đổi: {ex.Message}");
                        TempData["ErrorMessage"] = "Cập nhật thông tin không thành công.";
                        return View(model);
                    }
                }
                else
                {
                    TempData["ErrorMessage"] = "Tài khoản không tồn tại.";
                    return View(model);
                }
            }

            TempData["ErrorMessage"] = "Cập nhật thông tin không thành công.";
            return View(model);
        }



        [HttpGet]
        public IActionResult ChangePassword()
        {
            // Khởi tạo view model với các đối tượng trống
            var viewModel = new UserViewModels
            {
                Register = new Account(),
                ChangePassword = new ChangePasswordViewModel()
            };

            return View(viewModel);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ChangePassword(UserViewModels viewModel)
        {
            // Kiểm tra xem người dùng đã đăng nhập chưa
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "User");
            }

            // Lấy ID của người dùng từ session
            var accountId = HttpContext.Session.GetInt32("AccountId");

            // Kiểm tra xem session có tồn tại không
            if (accountId == null)
            {
                ViewBag.ErrorMessage = "Không tìm thấy tài khoản.";
                return View(viewModel);
            }

            // Lấy tài khoản từ cơ sở dữ liệu bằng ID
            var account = await _context.accounts.FindAsync(accountId);

            if (account == null)
            {
                // Xử lý khi tài khoản không tồn tại
                ViewBag.ErrorMessage = "Không tìm thấy tài khoản.";
                return View(viewModel);
            }

            // Xác minh mật khẩu cũ
            if (!BCrypt.Net.BCrypt.Verify(viewModel.ChangePassword.OldPassword, account.MatKhau))
            {
                // Xử lý khi mật khẩu cũ không khớp
                ViewBag.ErrorMessage = "Mật khẩu cũ không chính xác.";
                return View(viewModel);
            }

            // Cập nhật mật khẩu mới
            account.MatKhau = BCrypt.Net.BCrypt.HashPassword(viewModel.ChangePassword.NewPassword);

            try
            {
                // Lưu thay đổi vào cơ sở dữ liệu
                _context.Update(account);
                await _context.SaveChangesAsync();
                Response.Cookies.Delete("WaterCookie");
                ViewBag.SuccessMessage = "Đổi mật khẩu thành công!";
                return RedirectToAction("Login", "User");
            }
            catch (Exception ex)
            {
                // Xử lý khi có lỗi xảy ra trong quá trình cập nhật mật khẩu
                ViewBag.ErrorMessage = "Đã xảy ra lỗi khi đổi mật khẩu: " + ex.Message;
                return View(viewModel);
            }
        }


        public async Task<IActionResult> _Search()
        {
            return View();
        }


        public async Task<IActionResult> AccountUser()
        {
            var account = await _context.accounts.ToListAsync();
            var modelView = new UserViewModels
            {
                accounts = account,
            };
            return View(modelView);
        }

        [HttpGet]
        public async Task<IActionResult> ChangePasswordUser()
        {
            // Kiểm tra xem người dùng đã đăng nhập chưa
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "User");
            }

            // Lấy ID của người dùng từ session
            var accountId = HttpContext.Session.GetInt32("AccountId");

            // Kiểm tra xem session có tồn tại không
            if (accountId == null)
            {
                ViewBag.ErrorMessage = "Không tìm thấy tài khoản.";
                return RedirectToAction("Login", "User");
            }

            // Lấy tài khoản từ cơ sở dữ liệu bằng ID
            var account = await _context.accounts.FindAsync(accountId);

            if (account == null)
            {
                ViewBag.ErrorMessage = "Không tìm thấy tài khoản.";
                return RedirectToAction("Login", "User");
            }

            var viewModel = new UserViewModels
            {
                ChangePassword = new ChangePasswordViewModel
                {
                    OldPassword = account.MatKhau // Lưu mật khẩu cũ vào ViewModel
                }
            };

            return View(viewModel);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ChangePasswordUser(UserViewModels viewModel)
        {
            // Kiểm tra xem người dùng đã đăng nhập chưa
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "User");
            }

            // Lấy ID của người dùng từ session
            var accountId = HttpContext.Session.GetInt32("AccountId");

            // Kiểm tra xem session có tồn tại không
            if (accountId == null)
            {
                ViewBag.ErrorMessage = "Không tìm thấy tài khoản.";
                return View(viewModel);
            }

            // Lấy tài khoản từ cơ sở dữ liệu bằng ID
            var account = await _context.accounts.FindAsync(accountId);

            if (account == null)
            {
                ViewBag.ErrorMessage = "Không tìm thấy tài khoản.";
                return View(viewModel);
            }

            // Cập nhật mật khẩu mới
            account.MatKhau = BCrypt.Net.BCrypt.HashPassword(viewModel.ChangePassword.NewPassword);

            try
            {
                // Lưu thay đổi vào cơ sở dữ liệu
                _context.Update(account);
                await _context.SaveChangesAsync();
                ViewBag.SuccessMessage = "Đổi mật khẩu thành công!";
                return RedirectToAction("AccountUser", "User");
            }
            catch (Exception ex)
            {
                // Xử lý khi có lỗi xảy ra trong quá trình cập nhật mật khẩu
                ViewBag.ErrorMessage = "Đã xảy ra lỗi khi đổi mật khẩu: " + ex.Message;
                return View(viewModel);
            }
        }

        // Hiển thị hộp thoại xác nhận xóa tài khoản
        [HttpGet]
        public async Task<IActionResult> GetDeleteAccountUser(int id)
        {
            var account = await _context.accounts.FindAsync(id);
            if (account == null)
            {
                ViewBag.ErrorMessage = "Không tìm thấy tài khoản.";
                return RedirectToAction("AccountUser");
            }

            return View(account);
        }

        // Xử lý yêu cầu xóa tài khoản
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteAccountUser(int id)
        {
            var account = await _context.accounts.FindAsync(id);
            if (account == null)
            {
                ViewBag.ErrorMessage = "Không tìm thấy tài khoản.";
                return RedirectToAction("AccountUser");
            }

            try
            {
                _context.accounts.Remove(account);
                await _context.SaveChangesAsync();
                ViewBag.SuccessMessage = "Xóa tài khoản thành công!";
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = "Đã xảy ra lỗi khi xóa tài khoản: " + ex.Message;
            }

            return RedirectToAction("AccountUser");
        }

        /*public async Task<IActionResult> ListPaymentProduct()
        {
            // Lấy danh sách chi tiết hóa đơn từ cơ sở dữ liệu
            var listPayments = await _context.chitiethoadons
                .Include(c => c.SanPhams)
                .Include(c => c.Hoadon)
                .Include(c => c.Account)
                .ToListAsync();

            // Nếu cần thiết, chuyển đổi dữ liệu thành ViewModel
            var viewModel = listPayments.Select(payment => new ChiTietHoaDon
            {
                Id = payment.Id,
                SanphamId = payment.SanphamId,
                SoLuong = payment.SoLuong,
                ThanhTien = payment.ThanhTien,
                AccountId = payment.AccountId,
                Phone = payment.Phone,
                DiaChi = payment.DiaChi
            }).ToList();

            return View(viewModel);
        }*/

        public async Task<IActionResult> ListPaymentProduct()
        {
            // Lấy danh sách chi tiết hóa đơn từ cơ sở dữ liệu
            var listPayments = await _context.chitiethoadons
                .Include(c => c.SanPhams) // Bao gồm thông tin sản phẩm
                .Include(c => c.Account)   // Bao gồm thông tin tài khoản
                .ToListAsync();

            // Tạo danh sách ViewModel
            var viewModel = new CartViewModels
            {
                chiTietHoaDons = listPayments,
                sanphams = await _context.sanphams.ToListAsync(), // Lấy danh sách sản phẩm
                accounts = await _context.accounts.ToListAsync()  // Lấy danh sách tài khoản
            };

            return View(viewModel);
        }

        public async Task<IActionResult> DailyRevenue()
        {
            var thirtyDaysAgo = DateTime.Now.AddDays(-30);

            var dailyRevenues = await _context.chitiethoadons
                .Where(ct => ct.Hoadon.NgayLap.HasValue && ct.Hoadon.NgayLap.Value >= thirtyDaysAgo)
                .GroupBy(ct => ct.Hoadon.NgayLap.Value.Date)
                .Select(g => new DateRevenueViewModel
                {
                    Date = g.Key,
                    Revenue = g.Sum(ct => ct.ThanhTien)
                })
                .OrderBy(dr => dr.Date)
                .ToListAsync();

            var viewModel = new UserViewModels
            {
                DateRevenues = dailyRevenues
            };

            return View(viewModel);
        }



        public async Task<IActionResult> MonthlyRevenue()
        {
            var monthlyRevenues = await _context.chitiethoadons
                .Where(ct => ct.Hoadon.NgayLap.HasValue)
                .GroupBy(ct => new { ct.Hoadon.NgayLap.Value.Year, ct.Hoadon.NgayLap.Value.Month })
                .Select(g => new MonthlyRevenueViewModel
                {
                    Year = g.Key.Year,
                    Month = g.Key.Month,
                    Revenue = g.Sum(ct => ct.ThanhTien)
                })
                .ToListAsync();

            var viewModel = new UserViewModels
            {
                MonthlyRevenues = monthlyRevenues
            };

            return View(viewModel);
        }

        public async Task<IActionResult> YearRevenue()
        {
            var currentYear = DateTime.Now.Year;
            var recentYears = await _context.chitiethoadons
                .Where(ct => ct.Hoadon.NgayLap.HasValue && ct.Hoadon.NgayLap.Value.Year >= currentYear - 2)
                .GroupBy(ct => ct.Hoadon.NgayLap.Value.Year)
                .Select(g => new YearlyRevenueViewModel
                {
                    Year = g.Key,
                    Revenue = g.Sum(ct => ct.ThanhTien)
                })
                .OrderByDescending(y => y.Year)
                .ToListAsync();

            var viewModel = new UserViewModels
            {
                YearlyRevenues = recentYears
            };

            return View(viewModel);
        }
    }   
}
