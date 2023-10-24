using CTN4_Data.Models.DB_CTN4;
using CTN4_Serv.Service.IService;
using CTN4_Serv.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CTN4_View_Admin.Controllers
{
    [Area("admin")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IConfiguration _config;
        private readonly ILoginService _userRepository;
        private readonly ITokenService _tokenService;
        private string generatedToken = null;

        public HomeController(ILogger<HomeController> logger, ITokenService tokenService, ILoginService userRepository, IConfiguration config)
        {
            _logger = logger;
            _config = config;
            _tokenService = tokenService;
            _userRepository = userRepository;

        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult BangQuanLy()
        {
            return View();
        }
        [AllowAnonymous]
        [Route("loginadmin")]
        [HttpGet]
        public IActionResult DangNhap()
        {
            return View();
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new CTN4_Data.Models.DB_CTN4.ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        [AllowAnonymous]
        [HttpPost]
        public IActionResult DangNhapa(Loginviewmodel userModel)
        {
            if (string.IsNullOrEmpty(userModel.User) || string.IsNullOrEmpty(userModel.Password))
            {
                return (RedirectToAction(nameof(DangNhap)));
            }

            IActionResult response = Unauthorized();
            var validUser = GetUser(userModel);

            if (validUser != null)
            {
                // truyền vào là loginviewmodel
                generatedToken = _tokenService.BuildToken(_config["Jwt:Key"].ToString(), _config["Jwt:Issuer"].ToString(),
                validUser);

                if (generatedToken != null)
                {
                    ModelState.AddModelError("LoginError", "Tên người dùng hoặc mật khẩu không chính xác");
                    HttpContext.Session.SetString("Token", generatedToken);
                     return RedirectToAction(nameof(Index));
                }
                else
                {
                    return (RedirectToAction("DangNhap"));
                }
            }
            else
            {
                return (RedirectToAction("Index"));
            }
        }
        private NhanVien GetUser(Loginviewmodel userModel)
        {
            //Write your code here to authenticate the user
            return _userRepository.GetUserNV(userModel);
        }

        [Authorize]
        [Route("mainwindows")]
        [HttpGet]
        public IActionResult MainWindows()
        {
            string token = HttpContext.Session.GetString("Token");

            if (token == null)
            {
                return RedirectToAction(nameof(DangNhap));
            }

            if (!_tokenService.IsTokenValid(_config["Jwt:Key"].ToString(),
                _config["Jwt:Issuer"].ToString(), token))
            {
                return RedirectToAction("Index");
            }

            ViewBag.Message = BuildMessage(token, 50);
            return View("Index");
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