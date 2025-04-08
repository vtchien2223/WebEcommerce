using Microsoft.AspNetCore.Mvc;

namespace DoAnCoSoWeb.Controllers
{
    public class SupportController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> _Search()
        {
            return View();
        }
    }
}
