using Microsoft.AspNetCore.Mvc;

namespace MultiTierArchitecture.Presentation.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class MainController : Controller
    {
        // Ana kontrol paneli (Dashboard)
        public IActionResult Index()
        {
            return View();
        }
    }
}