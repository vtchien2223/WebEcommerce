using DoAnCoSoWeb.Models;
using DoAnCoSoWeb.Repository;
using DoAnCoSoWeb.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace DoAnCoSoWeb.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IWarehouseRepository _warehouseRepository;
        private readonly ICompanyRepository _companyRepository;
        private readonly ISaleRepository _saleRepository;
        private readonly ApplicationDbContext _context;
        public ProductController(ApplicationDbContext context, IProductRepository productRepository, ICategoryRepository categoryRepository,
            IWarehouseRepository warehouseRepository, ICompanyRepository companyRepository, ISaleRepository saleRepository)
        {
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
            _warehouseRepository = warehouseRepository;
            _companyRepository = companyRepository;
            _saleRepository = saleRepository;
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var products = await _productRepository.GetAllAsync();
            return View(products);

        }

        public async Task<IActionResult> Create()
        {
            var category = await _categoryRepository.GetAllAsync();
            ViewBag.Category = new SelectList(category, "Id", "Name");

            var company = await _companyRepository.GetAllAsync();
            ViewBag.Company = new SelectList(company, "Id", "TenHang");

            var sale = await _saleRepository.GetAllAsync();
            ViewBag.Sale = new SelectList(sale, "Id", "Name");

            var warehouse = await _warehouseRepository.GetAllAsync();
            ViewBag.Warehouse = new SelectList(warehouse, "Id", "TenKho");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Sanpham product)
        {
            if (ModelState.IsValid)
            {
                await _productRepository.AddAsync(product);
                return RedirectToAction(nameof(Index));
            }
            var category = await _categoryRepository.GetAllAsync();
            ViewBag.Category = new SelectList(category, "Id", "Name");

            var company = await _companyRepository.GetAllAsync();
            ViewBag.Company = new SelectList(company, "Id", "TenHang");

            var sale = await _saleRepository.GetAllAsync();
            ViewBag.Sale = new SelectList(sale, "Id", "Name");

            var warehouse = await _warehouseRepository.GetAllAsync();
            ViewBag.Warehouse = new SelectList(warehouse, "Id", "TenKho");
            return View(product);
        }

        public IActionResult Display(int id)
        {
            var product = _productRepository.GetByIdAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _productRepository.GetByIdAsync(id.Value);
            if (product == null)
            {
                return NotFound();
            }

            var category = await _categoryRepository.GetAllAsync();
            ViewBag.Category = new SelectList(category, "Id", "Name");

            var company = await _companyRepository.GetAllAsync();
            ViewBag.Company = new SelectList(company, "Id", "TenHang");

            var sale = await _saleRepository.GetAllAsync();
            ViewBag.Sale = new SelectList(sale, "Id", "Name");

            var warehouse = await _warehouseRepository.GetAllAsync();
            ViewBag.Warehouse = new SelectList(warehouse, "Id", "TenKho");

            return View(product);
        }

        // POST: Product/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,TenSanPham,Gia,Mota,Image1,Image2,Image3,LoaiId,HangId,SaleId,KhoId")] Sanpham product)
        {
            if (id != product.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(product);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductExists(product.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));

            }
            return View(product);
        }

        private bool ProductExists(int id)
        {
            return _context.sanphams.Any(e => e.Id == id);
        }


        private async Task<string> SaveImage(IFormFile image)
        {
            var savePath = Path.Combine("wwwroot/image", image.FileName);
            using (var fileStream = new FileStream(savePath, FileMode.Create))
            {
                await image.CopyToAsync(fileStream);
            }
            return "/image/" + image.FileName;
        }

        public async Task<IActionResult> Details(int id)
        {
            var product = await _productRepository.GetByIdAsync(id);
            var category = await _categoryRepository.GetByIdAsync(product.LoaiId);
            ViewBag.Category = category.Name;
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }
        // Show the product delete confirmation
        public async Task<IActionResult> Delete(int id)
        {
            var product = await _productRepository.GetByIdAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            var category = await _categoryRepository.GetAllAsync();
            ViewBag.Category = new SelectList(category, "Id", "Name");

            var company = await _companyRepository.GetAllAsync();
            ViewBag.Company = new SelectList(company, "Id", "TenHang");

            var sale = await _saleRepository.GetAllAsync();
            ViewBag.Sale = new SelectList(sale, "Id", "Name");

            var warehouse = await _warehouseRepository.GetAllAsync();
            ViewBag.Warehouse = new SelectList(warehouse, "Id", "TenKho");
            return View(product);
        }
        [HttpPost]
        public async Task<IActionResult> Delete(int id, Sanpham product, IFormFile imageUrl)
        {
            if (id != product.Id)
            {
                return NotFound();
            }
            await _productRepository.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }


        public async Task<IActionResult> _Search()
        {
            return View();
        }
        public async Task<IActionResult> Filter(int loaiId)
        {
            List<Sanpham> filteredProducts = await _context.sanphams
                .Where(sp => sp.LoaiId == loaiId)
                .ToListAsync();
            return View(filteredProducts);
        }

        public async Task<IActionResult> ListPaymentProduct()
        {
            // Lấy danh sách chi tiết hóa đơn từ cơ sở dữ liệu
            var listPayments = await _context.chitiethoadons
                .Include(c => c.SanPhams) // Bao gồm thông tin sản phẩm
                .Include(c => c.Account)   // Bao gồm thông tin tài khoản
                .ToListAsync();

            // Tạo danh sách ViewModel
            var viewModel = new ProductViewModels
            {
                chiTietHoaDons = listPayments,
                Sanpham = await _context.sanphams.ToListAsync(), // Lấy danh sách sản phẩm
                accounts = await _context.accounts.ToListAsync()  // Lấy danh sách tài khoản
            };

            return View(viewModel);
        }


    }
}

