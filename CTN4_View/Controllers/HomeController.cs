
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using CTN4_View.Models;

namespace CTN4_View.Controllers
{
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

        public IActionResult blog()
        {
            return View();
        }
        public IActionResult cart()
        {
            return View();
        }
        public IActionResult category()
        {
            return View();
        }
        public IActionResult confirmation()
        {
            return View();
        }
        public IActionResult contact()
        {
            return View();
        }
        public IActionResult checkout()
        {
            return View();
        }
        public IActionResult elements()
        {
            return View();
        }
        public IActionResult login()
        {
            return View();
        }
        public IActionResult singleblog()
        {
            return View();
        }
        public IActionResult singleproduct()
        {
            return View();
        }
        public IActionResult tracking()
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