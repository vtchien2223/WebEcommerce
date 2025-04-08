using DoAnCoSoWeb.Migrations;
using DoAnCoSoWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

public class ContactController : Controller
{
    private readonly ApplicationDbContext _context;

    public ContactController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([FromForm] string email)
    {
        if (ModelState.IsValid)
        {
            var contact = new DoAnCoSoWeb.Models.contact { Email = email };
            _context.contacts.Add(contact);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "Home");
        }
        return View();
    }
	[HttpGet]
	public async Task<IActionResult> Index()
	{
		List<DoAnCoSoWeb.Models.contact> contacts = await _context.contacts.ToListAsync(); // Sử dụng namespace đầy đủ
		return View(contacts);
	}
}
