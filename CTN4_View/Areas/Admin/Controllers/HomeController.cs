
using CTN4_Data.Models.DB_CTN4;
using CTN4_Serv.Service;
using CTN4_Serv.Service.IService;
using CTN4_Serv.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
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
        private readonly ISanPhamService _spsv;
        private readonly IGiamGiaService _giamgia;
        public HomeController(ILogger<HomeController> logger, ITokenService tokenService, ILoginService userRepository, IConfiguration config, ICurrentUser curent,
          INhanVienService nhanvien, ISanPhamService Sp, IGiamGiaService giamgia)
        {
            _logger = logger;
            _config = config;
            _tokenService = tokenService;
            _userRepository = userRepository;
            _curent = curent;
            _nhanvienService = nhanvien;
            _spsv = Sp;
            _giamgia = giamgia;



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
        public IActionResult Discount()
        {
            // Lấy danh sách sản phẩm từ cơ sở dữ liệu dưới dạng List<SanPham>
            List<SanPham> sanPhamsFromDatabase = _spsv.GetAll(); // Thay thế hàm này bằng hàm lấy sản phẩm từ cơ sở dữ liệu của bạn

            // Chuyển đổi danh sách SanPham thành danh sách ProductDiscountViewModel
            List<ProductDiscountViewModel> products = sanPhamsFromDatabase.Select(sp => new ProductDiscountViewModel
            {
                ProductId = sp.Id,
                ProductName = sp.TenSanPham,
                OriginalPrice = sp.GiaBan,
                IsSelected = false, // Bạn có thể thiết lập giá trị mặc định cho IsSelected ở đây
                DiscountPercentage = 0, // Bạn có thể thiết lập giá trị mặc định cho DiscountPercentage ở đây
                StartDate = DateTime.Now, // Bạn có thể thiết lập giá trị mặc định cho StartDate ở đây
                EndDate = DateTime.Now.AddMonths(1) // Bạn có thể thiết lập giá trị mặc định cho EndDate ở đây
            }).ToList();

            return View(products);

       
        }

        [HttpPost]
        public IActionResult ApplyDiscount(List<ProductDiscountViewModel> products)
        {
            // Xử lý logic giảm giá cho các sản phẩm được chọn và lưu thông tin giảm giá vào cơ sở dữ liệu
            foreach (var product in products)
            {
                if (product.IsSelected)
                {
                    // Xử lý logic giảm giá cho sản phẩm được chọn
                    // Sử dụng product.ProductId, product.DiscountPercentage, product.StartDate, product.EndDate để thực hiện giảm giá
                    // Lưu thông tin giảm giá vào cơ sở dữ liệu
                }
            }

            // Chuyển hướng hoặc trả về trang cần thiết
            return RedirectToAction("Products");
        }

        [HttpPost]
        public IActionResult SelectedProducts(List<ProductDiscountViewModel> products)
        {
            // Xử lý logic khi người dùng lưu danh sách sản phẩm đã chọn
            // Điều này có thể bao gồm việc lưu danh sách sản phẩm vào cơ sở dữ liệu hoặc thực hiện các hành động khác tùy thuộc vào yêu cầu của bạn

            // Chuyển hướng hoặc trả về trang cần thiết
            return RedirectToAction("Products");
        }
    }
}