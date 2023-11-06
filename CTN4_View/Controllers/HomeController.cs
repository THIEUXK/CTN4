
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
using NuGet.Common;
using CTN4_Serv.Service.Service;
using Newtonsoft.Json;
using System.Net.Http;

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
		private readonly ICurrentUser _curent;
        private readonly IKhachHangService _khachHangService;
		private readonly ISanPhamService _spService;
		private string generatedToken = null;
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IDiaChiNhanHangService _diachi;
        private readonly IGiamGiaService _giamgiact;

        public IKhachHangService _KHangService;
        //public HomeController()
        //{
        //    _phamChiTietService = new SanPhamChiTietService();
        //    _sanPhamCuaHangService = new SanPhamCuaHangService();
        //}


        public HomeController(ILogger<HomeController> logger, IConfiguration config, ITokenService tokenService, ILoginService userRepository,ICurrentUser curent,IKhachHangService khachhang,ISanPhamService sanpham, IHttpClientFactory httpClientFactory ,IDiaChiNhanHangService diachi,IGiamGiaService giamgia)

        {
            _spService = sanpham;
            _khachHangService = khachhang;
            _KHangService = new KhachHangService();
            _curent = curent;
            _diachi = diachi;
			_logger = logger;
             _phamChiTietService = new SanPhamChiTietService();
            _sanPhamCuaHangService = new SanPhamCuaHangService();
            _config = config;
            _tokenService = tokenService;
            _userRepository = userRepository;
            _httpClientFactory = httpClientFactory;
            _giamgiact = giamgia;
        }

        public IActionResult Index()
        {
			string token = HttpContext.Session.GetString("Token");

            var a = User.Identity.Name;
            var obj = _spService.GetAll();
			return View(obj);
        }
        public async Task<IActionResult> Themdiachi()
        {
            // Tạo một instance của HttpClient từ factory
            var client = _httpClientFactory.CreateClient();


            // Đặt URL của API bạn muốn gọi
            string apiUrl = "https://provinces.open-api.vn/api/p/";


            // Gọi API bằng phương thức GET
            HttpResponseMessage response = await client.GetAsync(apiUrl);

            if (response.IsSuccessStatusCode)
            {
                // Đọc dữ liệu từ response và chuyển đổi thành chuỗi hoặc object tùy vào API của bạn
                string responseData = await response.Content.ReadAsStringAsync();
                // Xử lý dữ liệu ở đây
                List<DiaChiNhanHang> diaChiNhanHangList = JsonConvert.DeserializeObject<List<DiaChiNhanHang>>(responseData);
                return View(diaChiNhanHangList); // Trả về kết quả thành công
            }
            else
            {
                // Xử lý lỗi ở đây, ví dụ: response.StatusCode, response.ReasonPhrase
                return BadRequest("Failed to fetch data from API");
            }
            
        }
        [HttpPost]
        public IActionResult themdiachis(DiaChiNhanHang a)
        {
            try
            {
                if (a == null)
                {
                    return RedirectToAction(nameof(Themdiachi));
                }
                a.Id = Guid.NewGuid();
                a.TrangThai = false;
                a.IdKhachHang = _curent.Id;
                if(_diachi.Them(a))
                {
                    return RedirectToAction("Index");
                }
                return RedirectToAction("Themdiachi");
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            

        } 
        public IActionResult blog()
        {
            return View();
        }
        [AllowAnonymous]
        [Route("DangKy")]
        [HttpGet]
        public IActionResult DangKy()
        {
            return View();
        }
    
        [HttpPost]
        public IActionResult DangKys(KhachHang a)
        {
            if (a == null)
            {
                return RedirectToAction(nameof(DangKy));
            }
            
            a.Id = Guid.NewGuid();
            a.Trangthai = true;
            a.AnhDaiDien = "Fall";
            _khachHangService.Them(a);
            return RedirectToAction(nameof(login));
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
        [HttpGet]
        public IActionResult UpdateKh() {
            var s = _khachHangService.GetById(_curent.Id);
            return View(s);
          
         }
        public IActionResult SignUp()
        {

            return View();

        }
        [HttpPost]
        public IActionResult UpdateKhang(KhachHang khachHangForm)
        {
            // Lấy đối tượng KhachHang cần cập nhật dựa trên ID hoặc một thuộc tính khác duy nhất
            var khachHangToUpdate = _khachHangService.GetById(_curent.Id);

            // Cập nhật các thuộc tính của đối tượng KhachHang từ dữ liệu form
            
            khachHangToUpdate.Ho = khachHangForm.Ho;
            khachHangToUpdate.Ten = khachHangForm.Ten;
            khachHangToUpdate.TenDangNhap = khachHangForm.TenDangNhap;
            khachHangToUpdate.MatKhau = khachHangForm.MatKhau;
            khachHangToUpdate.GioiTinh = khachHangForm.GioiTinh;
            khachHangToUpdate.Email = khachHangForm.Email;
            khachHangToUpdate.SDT = khachHangForm.SDT;
            khachHangToUpdate.DiaChi = khachHangForm.DiaChi;
            khachHangToUpdate.AnhDaiDien = khachHangForm.AnhDaiDien;

            // Thực hiện cập nhật thông tin KhachHang
            var result = _khachHangService.Sua(khachHangToUpdate);

            if (result)
            {
                // Cập nhật thành công, chuyển hướng về trang danh sách hoặc trang chi tiết
                return RedirectToAction(nameof(Index));
            }
            else
            {
                // Có lỗi trong quá trình cập nhật, xử lý lỗi tại đây nếu cần
                // Ví dụ: ModelState.AddModelError("TenThuocTinh", "Thông báo lỗi");
                return RedirectToAction(nameof(UpdateKh)); // Hiển thị lại form với dữ liệu đã nhập và thông báo lỗi
            }
        }
        public IActionResult UserDetail()
		{
            var a = _curent;
            var user = _khachHangService.GetById(_curent.Id);
			return View(user);
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
                return (RedirectToAction("Login"));
            }
            var TK = _KHangService.GetAll().FirstOrDefault(c=>c.TenDangNhap==userModel.User&&c.MatKhau==userModel.Password);
            // Đọc dữ liệu từ Session xem trong Cart nó có cái gì chưa?
            var accnew = SessionServices.KhachHangSS(HttpContext.Session, "ACC");
            if (accnew.Count == 0)
            {
                accnew.Add(TK); 
                SessionServices.SetObjToJson(HttpContext.Session, "ACC", accnew);
            }
            else if (accnew.Count != 0)
            {
                    accnew.Clear();
                    accnew.Add(TK); 
                    SessionServices.SetObjToJson(HttpContext.Session, "ACC", accnew);
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

					
					return RedirectToAction("Index");
                }
                else
                {
                    return (RedirectToAction("Login"));
                }
            }
            else
            {
                return (RedirectToAction("Login"));
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
                return RedirectToAction(nameof(login));
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