using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CTN4_View_Admin.Controllers
{
    [Area("admin")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult BangQuanLy()
        {
            return View();
        }
        public IActionResult DangNhap()
        {
            return View();
        }



    }
}