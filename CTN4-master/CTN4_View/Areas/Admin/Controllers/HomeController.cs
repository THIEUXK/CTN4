
using CTN4_Data.Models.DB_CTN4;
using CTN4_Serv.Service;
using CTN4_Serv.Service.IService;
using CTN4_Serv.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Scripting;
using Newtonsoft.Json;
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
		private readonly ICurrentUser _curent;
        private readonly INhanVienService _nhanvienService;
		private string generatedToken = null;
        private readonly IHttpClientFactory _httpClientFactory;
        public HomeController(ILogger<HomeController> logger, ITokenService tokenService, ILoginService userRepository, IConfiguration config,ICurrentUser curent,
          INhanVienService nhanvien)
        {
            _logger = logger;
            _config = config;
            _tokenService = tokenService;
            _userRepository = userRepository;
            _curent = curent;
            _nhanvienService = nhanvien;
           


        }

        public IActionResult Index()
        {
            string token = HttpContext.Session.GetString("Token");

            var a = User.Identity.Name;
           
           
            return View();
        }
        
    
        // [Authorize(Policy = "Nhân viên")]
        public IActionResult BangQuanLy()
        {
            return View();
        }
     
		public IActionResult UserDetails()
		{

			var user = _nhanvienService.GetByIdChucVu(_curent.Id);
            
			return View(user);
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
        public IActionResult Doimk()
        {
            var user = _nhanvienService.GetByIdChucVu(_curent.Id);
            return View(user);
        }
        [HttpPost]
        public IActionResult DoiMatKhau(string matKhauCu, string matKhauMoi, string xacNhanMatKhauMoi)
        {
            // Lấy thông tin người dùng từ cơ sở dữ liệu hoặc bất kỳ nguồn nào khác
            var user = _nhanvienService.GetByIdChucVu(_curent.Id);
            // Kiểm tra xem mật khẩu cũ có đúng không
            if (matKhauCu != user.MatKhau)
            {
                ModelState.AddModelError("matKhauCu", "Mật khẩu cũ không đúng.");
                return View();
            }

            // Kiểm tra xác nhận mật khẩu mới
            if (matKhauMoi != xacNhanMatKhauMoi)
            {
                ModelState.AddModelError("xacNhanMatKhauMoi", "Xác nhận mật khẩu mới không khớp.");
                return View();
            }

            // Lưu mật khẩu mới vào cơ sở dữ liệu
            user.MatKhau = matKhauMoi;
            // Lưu người dùng có mật khẩu mới vào cơ sở dữ liệu
            _nhanvienService.Sua(user);
            return RedirectToAction("Index", "Home");
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
                return (RedirectToAction("DangNhap"));
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

		public IActionResult Logouts()
		{
			// Xóa dữ liệu phiên của người dùng, bao gồm thông tin đăng nhập và token
			HttpContext.Session.Clear();

			// Chuyển hướng người dùng đến trang đăng nhập hoặc trang chính của ứng dụng
			return RedirectToAction(nameof(DangNhap));
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