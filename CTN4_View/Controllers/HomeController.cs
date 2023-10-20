
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using CTN4_Serv.Service.IService;
using CTN4_View.Models;
using CTN4_Data.Models.DB_CTN4;
using CTN4_Serv.Service;
using CTN4_Serv.ServiceJoin;
using CTN4_Ser.ViewModel;
using Microsoft.AspNetCore.Authorization;
using CTN4_Serv.ViewModel;

namespace CTN4_View.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ISanPhamChiTietService _phamChiTietService;
        private readonly SanPhamCuaHangService _sanPhamCuaHangService;
        private readonly IConfiguration _config;
        private readonly ILoginService _userRepository;
        private readonly ITokenService _tokenService;
        private string generatedToken = null;
        //public HomeController()
        //{
        //    _phamChiTietService = new SanPhamChiTietService();
        //    _sanPhamCuaHangService = new SanPhamCuaHangService();
        //}

        public HomeController(ILogger<HomeController> logger, IConfiguration config, ITokenService tokenService, ILoginService userRepository)
        {
            _logger = logger;
             _phamChiTietService = new SanPhamChiTietService();
            _sanPhamCuaHangService = new SanPhamCuaHangService();
            _config = config;
            _tokenService = tokenService;
            _userRepository = userRepository;
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
        [AllowAnonymous]
        [Route("login")]
        [HttpGet]
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
            return View(new CTN4_Data.Models.DB_CTN4.ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        [AllowAnonymous]
        [Route("login")]
        [HttpPost]
        public IActionResult Login(Loginviewmodel userModel)
        {
            if (string.IsNullOrEmpty(userModel.User) || string.IsNullOrEmpty(userModel.Password))
            {
                return (RedirectToAction(""));
            }

            IActionResult response = Unauthorized();
            var validUser = GetUserKH(userModel);

            if (validUser != null)
            {
                generatedToken = _tokenService.BuildTokens(_config["Jwt:Key"].ToString(), _config["Jwt:Issuer"].ToString(),
                validUser);

                if (generatedToken != null)
                {
                    HttpContext.Session.SetString("Token", generatedToken);
                    return RedirectToAction("MainWindow");
                }
                else
                {
                    return (RedirectToAction(""));
                }
            }
            else
            {
                return (RedirectToAction(""));
            }
        }
        private KhachHang GetUserKH(Loginviewmodel userModel)
        {
            //Write your code here to authenticate the user
            return _userRepository.GetUserKH(userModel);
        }

        [Authorize]
        [Route("mainwindow")]
        [HttpGet]
        public IActionResult MainWindow()
        {
            string token = HttpContext.Session.GetString("Token");

            if (token == null)
            {
                return (RedirectToAction("Index"));
            }

            if (!_tokenService.IsTokenValid(_config["Jwt:Key"].ToString(),
                _config["Jwt:Issuer"].ToString(), token))
            {
                return (RedirectToAction("Index"));
            }

            ViewBag.Message = BuildMessage(token, 50);
            return View();
        }

        public IActionResult Errors()
        {
            ViewBag.Message = "An error occured...";
            return View();
        }
        private string BuildMessage(string stringToSplit, int chunkSize)
        {
            var data = Enumerable.Range(0, stringToSplit.Length / chunkSize)
                .Select(i => stringToSplit.Substring(i * chunkSize, chunkSize));

            string result = "The generated token is:";

            foreach (string str in data)
            {
                result += Environment.NewLine + str;
            }

            return result;
        }
    }
}