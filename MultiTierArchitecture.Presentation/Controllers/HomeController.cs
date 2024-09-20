using Microsoft.AspNetCore.Mvc;
using MultiTierArchitecture.Business.Abstract;
using MultiTierArchitecture.Presentation.Models;
using System.Diagnostics;

namespace MultiTierArchitecture.Presentation.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IContentService _contentService;

        public HomeController(ILogger<HomeController> logger, IContentService contentService)
        {
            _logger = logger;
            _contentService = contentService;
        }

        // Ýçeriklerin listelenmesi için Index metodu
        public async Task<IActionResult> Index()
        {
            // await ile asenkron metodu bekle
            var contents = await _contentService.GetAllAsync();
            return View(contents); // Modeli View'a gönder
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
