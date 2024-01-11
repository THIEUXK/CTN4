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
using System.Text.RegularExpressions;
using CTN4_Data.DB_Context;
using DocumentFormat.OpenXml.Spreadsheet;
using Microsoft.AspNetCore.Mvc.Rendering;

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
        private readonly DB_CTN4_ok _CTN4_Ok;
        private readonly IDanhMucChiTietService _danhMucChiTietService;
        private readonly IEmailService _EmailService;
        public IKhachHangService _KHangService;
        public IDiaChiNhanHangService _diaChiNhanHangService;
        public IGioHangService _GioHangService;
        public IChiTietSanPhamYeuThichService _chiTietSanPhamYeuThichService;
        //public HomeController()
        //{
        //    _phamChiTietService = new SanPhamChiTietService();
        //    _sanPhamCuaHangService = new SanPhamCuaHangService();
        //}


        public HomeController(ILogger<HomeController> logger, IConfiguration config, ITokenService tokenService, ILoginService userRepository, ICurrentUser curent, IKhachHangService khachhang, ISanPhamService sanpham, IHttpClientFactory httpClientFactory, IDiaChiNhanHangService diachi, IGiamGiaService giamgia, IEmailService emailService,IGioHangService gh)

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
            _CTN4_Ok = new DB_CTN4_ok();
            _danhMucChiTietService = new DanhMucChiTietMucChiTietService();
            _EmailService = emailService;
            _diaChiNhanHangService = new DiaChiNhanHangService();
            _GioHangService =gh ;
			 _chiTietSanPhamYeuThichService = new ChiTietSanPhamYeuThichService();
        }

        public IActionResult Index()
        {
            string token = HttpContext.Session.GetString("Token");

            var a = User.Identity.Name;
            var obj = _spService.GetAll();

            var b = _danhMucChiTietService.GetAll().Where(c => c.IdDanhMuc == Guid.Parse("56dd3ee2-c4df-4376-b982-e2c0f7081173")).ToList();
            var c = _danhMucChiTietService.GetAll().Where(c => c.IdDanhMuc == Guid.Parse("f0e98e38-112b-4630-89f1-08dbf336241b")).ToList();
            var SpYt = _chiTietSanPhamYeuThichService.GetAll();
            var view = new SanPhamBanChayView()
            {
                sanPhams = obj,
                danhMucChiTiets = b,
                danhMucChiTiets1 = c,
                sanPhamYeuThiches = SpYt,
            };

            return View(view);
        }
        public IActionResult AddAnhDaiDien(Guid IdKh, [Bind] IFormFile imageFile)
        {
            var khachhang = _khachHangService.GetById(IdKh);
            //var x = imageFile.FileName;
            if (imageFile != null && imageFile.Length > 0) // Không null và không trống
            {
                //Trỏ tới thư mục wwwroot để lát nữa thực hiện việc Copy sang
                var path = Path.Combine(
                    Directory.GetCurrentDirectory(), "wwwroot", "anhdd", imageFile.FileName);
                using (var stream = new FileStream(path, FileMode.Create))
                {
                    // Thực hiện copy ảnh vừa chọn sang thư mục mới (wwwroot)
                    imageFile.CopyTo(stream);
                }
                // Gán lại giá trị cho Description của đối tượng bằng tên file ảnh đã được sao chép
                khachhang.AnhDaiDien = imageFile.FileName;
            }
            else
            {
                var thongbaoAnh = "Hãy Thêm ảnh !";
                TempData["Notification"] = thongbaoAnh;
                return RedirectToAction("UserDetail", new { thongbaoAnh });
            }

            if (_khachHangService.Sua(khachhang)) // Nếu thêm thành công
            {
                return RedirectToAction("UserDetail");
            }
            return RedirectToAction("UserDetail");
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
                if (_diachi.Them(a))
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
            if (string.IsNullOrEmpty(a.Ho) || string.IsNullOrEmpty(a.Ten) || string.IsNullOrEmpty(a.Email) || string.IsNullOrEmpty(a.SDT) || string.IsNullOrEmpty(a.DiaChi))
            {
                ViewBag.Message = "Không được để trống";

                return View("DangKy", a);
            }
            if (!IsValidEmail(a.Email))
            {
                ViewBag.Message = "Định dạng email không hợp lệ";
                return View("DangKy", a);
            }
            var checkma = _khachHangService.GetAll().FirstOrDefault(c => c.TenDangNhap == a.TenDangNhap);
            if (checkma !=null ) {
                ViewBag.Message = "Tên đăng nhập đã sử dụng";
                return View("DangKy", a);
            }
            var checksdt = _khachHangService.GetAll().FirstOrDefault(c => c.SDT == a.SDT);
            if (checksdt != null)
            {
                ViewBag.Message = "Số điện thoại đã sử dụng";
                return View("DangKy", a);
            }
            var checkemail = _khachHangService.GetAll().FirstOrDefault(c => c.Email == a.Email);
            if (checkemail != null)
            {
                ViewBag.Message = "Email đã sử dụng";
                return View("DangKy", a);
            }
            // Kiểm tra độ dài và định dạng số điện thoại
            if (!IsValidPhoneNumber(a.SDT))
            {
                ViewBag.Message = "Số điện thoại không hợp lệ";
                return View("DangKy", a);
            }
            if (a.Ho.Length > 100 || a.Ten.Length > 100 ||
              a.Email.Length > 100 || a.SDT.Length > 100 ||

              a.DiaChi.Length > 100)

            {
                ViewBag.Message = "Dữ liệu không được vượt quá 100 ký tự";
                return View("DangKy", a);
            }

            if (a == null)
            {
                return RedirectToAction(nameof(DangKy));
            }

            a.Id = Guid.NewGuid();
            a.Trangthai = true;
            a.Is_detele = true;
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
        public IActionResult UpdateKh()
        {
            var s = _khachHangService.GetById(_curent.Id);
            return View(s);

        }
        public IActionResult SignUp()
        {

            return View();

        }
        [HttpGet]
        public IActionResult DoimkKh()
        {
            var user = _khachHangService.GetById(_curent.Id);
            return View();
        }
        [HttpPost]
        public IActionResult DoiMatKhaus(DoiMatKhauKh kh)
        {

            if (!ModelState.IsValid)
            {
                return View("DoimkKh", kh);
            }
            // Lấy thông tin người dùng từ cơ sở dữ liệu hoặc bất kỳ nguồn nào khác
            var user = _khachHangService.GetById(_curent.Id);
            // Kiểm tra xem mật khẩu cũ có đúng không
            if (kh.matKhauCu != user.MatKhau)
            {
                ModelState.AddModelError("matKhauCu", "Mật khẩu cũ không đúng.");

                return View("DoimkKh", kh);

            }
            
            // Kiểm tra xác nhận mật khẩu mới
            if (kh.MatKhauMoi != kh.xacNhanMatKhauMoi)
            {
                ModelState.AddModelError("xacNhanMatKhauMoi", "Xác nhận mật khẩu mới không khớp.");
                return View("DoimkKh", kh);
            }

            // Lưu mật khẩu mới vào cơ sở dữ liệu
            user.MatKhau = kh.MatKhauMoi;
            // Lưu người dùng có mật khẩu mới vào cơ sở dữ liệu
            _khachHangService.Sua(user);
            return RedirectToAction("Index", "Home");
        }
        [HttpPost]
        public IActionResult UpdateKhang(KhachHang khachHangForm)
        {

            if (string.IsNullOrEmpty(khachHangForm.Ho) || string.IsNullOrEmpty(khachHangForm.Ten) || string.IsNullOrEmpty(khachHangForm.Email) || string.IsNullOrEmpty(khachHangForm.SDT) || string.IsNullOrEmpty(khachHangForm.DiaChi))
            {
                ViewBag.Message = "Không được để trống";

                return View("UpdateKh", khachHangForm);
            }
            if (!IsValidEmail(khachHangForm.Email))
            {
                ViewBag.Message = "Định dạng email không hợp lệ";
                return View("UpdateKh", khachHangForm);
            }

            // Kiểm tra độ dài và định dạng số điện thoại
            if (!IsValidPhoneNumber(khachHangForm.SDT))
            {
                ViewBag.Message = "Số điện thoại không hợp lệ";
                return View("UpdateKh", khachHangForm);
            }

            // Kiểm tra độ dài các trường dữ liệu
            if (khachHangForm.Ho.Length > 100 || khachHangForm.Ten.Length > 100 ||
                khachHangForm.Email.Length > 100 || khachHangForm.SDT.Length > 100 ||
                khachHangForm.DiaChi.Length > 100)
            {
                ViewBag.Message = "Dữ liệu không được vượt quá 100 ký tự";
                return View("UpdateKh", khachHangForm);
            }
            // Lấy đối tượng KhachHang cần cập nhật dựa trên ID hoặc một thuộc tính khác duy nhất
            var khachHangToUpdate = _khachHangService.GetById(_curent.Id);

            // Cập nhật các thuộc tính của đối tượng KhachHang từ dữ liệu form

            khachHangToUpdate.Ho = khachHangForm.Ho;
            khachHangToUpdate.Ten = khachHangForm.Ten;
            khachHangToUpdate.GioiTinh = khachHangForm.GioiTinh;
            khachHangToUpdate.Email = khachHangForm.Email;
            khachHangToUpdate.SDT = khachHangForm.SDT;
            khachHangToUpdate.DiaChi = khachHangForm.DiaChi;

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
        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        // Hàm kiểm tra định dạng và độ dài số điện thoại
        private bool IsValidPhoneNumber(string phoneNumber)
        {
            // Kiểm tra định dạng và độ dài số điện thoại theo quy tắc của bạn
            if (string.IsNullOrEmpty(phoneNumber))
            {
                return false;
            }

            // Check if the phone number has a length between 10 and 13 characters
            if ( phoneNumber.Length <10 || phoneNumber.Length > 13)

            {
                return false;
            }
            // (Ví dụ: định dạng có thể là số và không có ký tự đặc biệt)
            return Regex.IsMatch(phoneNumber, @"^[0-9]+$") ;
        }
        public IActionResult UserDetail()
        {
            var accnew = SessionServices.KhachHangSS(HttpContext.Session, "ACC");
            if (accnew.Count != 0)
            {
                var a = _curent;
                var user = _khachHangService.GetById(_curent.Id);
                return View(user);
            }
            else
            {
                return RedirectToAction("login", "Home");
            }

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
            if (!ModelState.IsValid)
            {
                ViewBag.Message = "Vui lòng nhập đúng đầu vào.";

                return View(userModel); // Trả về view với model và thông báo lỗi
            }
            if (string.IsNullOrEmpty(userModel.User) || string.IsNullOrEmpty(userModel.Password))
            {
                return (RedirectToAction("Login"));
            }
            var TK = _KHangService.GetAll().FirstOrDefault(c => c.TenDangNhap == userModel.User && c.MatKhau == userModel.Password);
            // Đọc dữ liệu từ Session xem trong Cart nó có cái gì chưa?
            if (TK!=null)
            {
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
                if (accnew.Count != 0)
                {
                    var tkmoi = accnew[0];
                    var gioHang = _GioHangService.GetAll().FirstOrDefault(c => c.IdKhachHang == tkmoi.Id);
                    if (gioHang == null)
                    {
                        var a = new GioHang()
                        {
                            Id = Guid.NewGuid(),
                            IdKhachHang = tkmoi.Id,
                            TrangThai = true
                        };
                        _GioHangService.Them(a);
                    }
                }
            }
            else
            {
                ViewBag.Message = "Tên đăng nhập hoặc mật khẩu không đúng";
                return View("Login");
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
                    ViewBag.Message = "Tên đăng nhập hoặc mật khẩu không đúng";
                    return View("Login");
                }
            }
            else
            {
                ViewBag.Message = "Tên đăng nhập hoặc mật khẩu không đúng";
                return View("Login");
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


        public IActionResult Errors()
        {
            ViewBag.Message = "An error occured...";
            return View();
        }
        public IActionResult Logout()
        {
            // Xóa dữ liệu phiên của người dùng, bao gồm thông tin đăng nhập và token
            HttpContext.Session.Clear();

            // Chuyển hướng người dùng đến trang đăng nhập hoặc trang chính của ứng dụng
            return RedirectToAction("login");
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
        //public IActionResult SanPhamBanChay()
        //{
        //    var spbc = _.GetAllSpct()
        //   .GroupBy(pd => pd.IdSp)
        //   .Select(g => new SanPhamChiTietView()
        //   {
        //       Id = g.Key,
        //       Is_detele = g.FirstOrDefault()?.SanPham?.TenSanPham,
        //       SoLuong = g.Sum(pd => pd.SoLuong)
        //   })
        //   .OrderByDescending(g => g.TotalQuantitySold)
        //   .Take(10)
        //   .ToList();

        //    return View();
        //}

        public ActionResult SuccessPass()
        {
            return View();
        }

        public ActionResult QuenMk()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> QuenMks(MailRequest mailRequest)
        {
            var khachHang = _khachHangService.GetAll().FirstOrDefault(c => c.TenDangNhap == mailRequest.Tendangnhap);
            var checkmail = _khachHangService.GetAll().FirstOrDefault(c => c.Email == mailRequest.ToEmail);


            if (string.IsNullOrEmpty(mailRequest.ToEmail))
            {
                ViewBag.Message = "Không được để trống";

                return View("QuenMk", mailRequest);
            }
            if (khachHang == null || checkmail == null)
            {
                ViewBag.Message = "Tên đăng nhập hoặc email không đúng";
                return View("QuenMk", mailRequest);
            }


            mailRequest.Subject = "Mật khẩu đăng nhập của wed bán túi poro của bạn là:";
            mailRequest.Body = $"Mật khẩu là: {khachHang.MatKhau} ; " +
 $"<a href='https://localhost:7174/'>Ấn vào đây để vào cửa hàng </a>";

            await _EmailService.SendEmailAsync(mailRequest);

            return RedirectToAction(nameof(SuccessPass));
        }
    }

}


