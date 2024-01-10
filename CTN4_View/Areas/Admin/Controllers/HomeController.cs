
using CTN4_Data.Models.DB_CTN4;
using CTN4_Serv.Service;
using CTN4_Serv.Service.IService;
using CTN4_Serv.ViewModel;
using DocumentFormat.OpenXml.Wordprocessing;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Scripting;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Text.RegularExpressions;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

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
        private readonly ILichSuHoaDonService _ls;
        public IGioHangService _GioHangService;

        private readonly IHoaDonService _hd;
        public HomeController(ILogger<HomeController> logger, ITokenService tokenService, ILoginService userRepository, IConfiguration config, ICurrentUser curent,
          INhanVienService nhanvien, ISanPhamService Sp, IGiamGiaService giamgia, ILichSuHoaDonService lichsu,IHoaDonService hoaDon, IGioHangService gioHangService)

        {
            _logger = logger;
            _config = config;
            _tokenService = tokenService;
            _userRepository = userRepository;
            _curent = curent;
            _nhanvienService = nhanvien;
            _spsv = Sp;
            _giamgia = giamgia;
            _ls = lichsu;
            _hd = hoaDon;
            _GioHangService = gioHangService;
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
        [HttpGet]
        public IActionResult Doimk()
        {

            return View();
        }
        public IActionResult ThongKeDt()
        {
            int[] thongKeDTArray = _hd.ThongKeTongTienHoaDonTheoThangTrongNam();

            return Json(thongKeDTArray);
        }
        [HttpPost]
        public IActionResult DoiMatKhau(DoiMatKhauKh kh)
        {
            if (!ModelState.IsValid)
            {

                return View("Doimk", kh);
            }
            // Lấy thông tin người dùng từ cơ sở dữ liệu hoặc bất kỳ nguồn nào khác
            var user = _nhanvienService.GetByIdChucVu(_curent.Id);
            // Kiểm tra xem mật khẩu cũ có đúng không
            if (kh.matKhauCu != user.MatKhau)
            {
                ModelState.AddModelError("matKhauCu", "Mật khẩu cũ không đúng.");
                return View("Doimk", kh);
            }

            // Kiểm tra xác nhận mật khẩu mới
            if (kh.MatKhauMoi != kh.xacNhanMatKhauMoi)
            {
                ModelState.AddModelError("xacNhanMatKhauMoi", "Xác nhận mật khẩu mới không khớp.");
                return View("Doimk", kh);
            }

            // Lưu mật khẩu mới vào cơ sở dữ liệu
            user.MatKhau = kh.MatKhauMoi;
            // Lưu người dùng có mật khẩu mới vào cơ sở dữ liệu
            _nhanvienService.Sua(user);
            return RedirectToAction("Index", "QuanLyHoaDon");
        }
        [AllowAnonymous]
        [HttpPost]
        public IActionResult DangNhapa(LoginAdmin userModel)
        {
            var TK = _nhanvienService.GetAll().FirstOrDefault(c => c.TenDangNhap == userModel.User && c.MatKhau == userModel.Password);
            if (TK == null)
            {

                ViewBag.Message = "Vui lòng nhập đúng đầu vào.";
                return View("DangNhap", userModel);
            }
            // Đọc dữ liệu từ Session xem trong Cart nó có cái gì chưa?
            var nvnew = SessionServices.NhanVienSS(HttpContext.Session, "ACA");
            if (nvnew.Count == 0)
            {

                nvnew.Add(TK);
                SessionServices.SetObjToJson(HttpContext.Session, "ACA", nvnew);
            }
            else if (nvnew.Count != 0)
            {
                nvnew.Clear();
                nvnew.Add(TK);
                SessionServices.SetObjToJson(HttpContext.Session, "ACA", nvnew);
            }
           
            if (!ModelState.IsValid)
            {
                ViewBag.Message = "Vui lòng nhập đúng đầu vào.";
                return View("DangNhap", userModel); // Trả về view với model và thông báo lỗi
            }
            if (string.IsNullOrEmpty(userModel.User) || string.IsNullOrEmpty(userModel.Password))
            {

                ViewBag.Message = "Vui lòng nhập đúng đầu vào.";
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
                 
                    HttpContext.Session.SetString("Token", generatedToken);
                    return RedirectToAction("Index", "QuanLyHoaDon");
                }
                else
                {

                    ViewBag.Message = "Vui lòng nhập đúng đầu vào.";
                    return View("DangNhap", userModel);
                }
            }
            else
            {

                ViewBag.Message = "Vui lòng nhập đúng đầu vào.";
                return View("DangNhap", userModel);
            }
        }
        private NhanVien GetUser(LoginAdmin userModel)
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
                return RedirectToAction("Index","QuanLyHoaDon");
            }

            ViewBag.Message = BuildMessage(token, 50);
            return View("Index", "QuanLyHoaDon");
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
        [HttpGet]
        public IActionResult UpdateNV()
        {
            var s = _nhanvienService.GetByIdChucVu(_curent.Id);
            return View(s);

        }
        
            public IActionResult GetBestSellingProducts()
            {
                // Gọi hàm ThongKeSanPhamBanChay để lấy danh sách sản phẩm bán chạy
                var bestSellingProducts = _hd.ThongKeSanPhamBanChay();

                // Trả về dữ liệu dưới dạng JSON cmm
                return Json(bestSellingProducts);
            }
        [HttpPost]
        public IActionResult ThongKenam(int nam)
        {

            // Gọi hàm ThongKeSanPhamBanChay để lấy danh sách sản phẩm bán chạy
            var soLuongDonHangTheoThang = _hd.ThongKeSoLuongDonHangTheoThangTrongNam(nam);

            // Trả về dữ liệu dưới dạng JSON
                return Json(soLuongDonHangTheoThang);
        }
        [HttpPost]
        public IActionResult UpdateNv(NhanVien khachHangForm)
        {
            if (string.IsNullOrEmpty(khachHangForm.Ho) || string.IsNullOrEmpty(khachHangForm.Ten) || string.IsNullOrEmpty(khachHangForm.Email) || string.IsNullOrEmpty(khachHangForm.SDT) || string.IsNullOrEmpty(khachHangForm.DiaChi))
            {
                ViewBag.Message = "Không được để trống";

                return View("UpdateNV", khachHangForm);
            }
            if (!IsValidEmail(khachHangForm.Email))
            {
                ViewBag.Message = "Định dạng email không hợp lệ";
                return View("UpdateNV", khachHangForm);
            }

            // Kiểm tra độ dài và định dạng số điện thoại
            if (!IsValidPhoneNumber(khachHangForm.SDT))
            {
                ViewBag.Message = "Số điện thoại không hợp lệ";
                return View("UpdateNV", khachHangForm);
            }

            // Kiểm tra độ dài các trường dữ liệu
            if (khachHangForm.Ho.Length > 100 || khachHangForm.Ten.Length > 100 ||
                khachHangForm.Email.Length > 100 || khachHangForm.SDT.Length > 100 ||
                khachHangForm.DiaChi.Length > 100)
            {
                ViewBag.Message = "Dữ liệu không được vượt quá 100 ký tự";
                return View("UpdateNV", khachHangForm);
            }

            // Lấy đối tượng KhachHang cần cập nhật dựa trên ID hoặc một thuộc tính khác duy nhất
            var khachHangToUpdate = _nhanvienService.GetByIdChucVu(_curent.Id);

            // Cập nhật các thuộc tính của đối tượng KhachHang từ dữ liệu form

            khachHangToUpdate.Ho = khachHangForm.Ho;
            khachHangToUpdate.Ten = khachHangForm.Ten;
            khachHangToUpdate.TenDangNhap = khachHangForm.TenDangNhap;
            khachHangToUpdate.MatKhau = khachHangForm.MatKhau;
            khachHangToUpdate.GioiTinh = khachHangForm.GioiTinh;
            khachHangToUpdate.Email = khachHangForm.Email;
            khachHangToUpdate.SDT = khachHangForm.SDT;
            khachHangToUpdate.DiaChi = khachHangForm.DiaChi;
            khachHangToUpdate.Trangthai = true;


            // Thực hiện cập nhật thông tin KhachHang
            var result = _nhanvienService.Sua(khachHangToUpdate);

            if (result)
            {
                // Cập nhật thành công, chuyển hướng về trang danh sách hoặc trang chi tiết
                return RedirectToAction("Index", "QuanLyHoaDon");
            }
            else
            {
                // Có lỗi trong quá trình cập nhật, xử lý lỗi tại đây nếu cần
                // Ví dụ: ModelState.AddModelError("TenThuocTinh", "Thông báo lỗi");
                return RedirectToAction(nameof(UpdateNV)); // Hiển thị lại form với dữ liệu đã nhập và thông báo lỗi
            }
        }
        [HttpGet]
        public IActionResult thongkels()
        {
          return View();
        }
        public IActionResult thongke()
        {
            int[] thongKeArray = _hd.ThongKeSoLuongDonHangTheoThangTrongNam();

            return Json(thongKeArray);
        }

        public IActionResult thongkeHd()
        {
            int[] thongKeArray = _hd.ThongKeTongTienHoaDonTheoThangTrongNam();

            return Json(thongKeArray);
        }
        [HttpPost]
        public IActionResult thongkeTrongKhoang(string ngaybatdau, string ngayketthuc)
        {
            if (ngaybatdau == null ||ngayketthuc == null)
            {
                int[] thongKeArray = _hd.ThongKeTongTienHoaDonTheoThangTrongNam();

                return Json(thongKeArray);
            }
            DateTime startDate = DateTime.Parse(ngaybatdau);
            DateTime endDate = DateTime.Parse(ngayketthuc);

            int[] thongKetheo = _hd.ThongKeSoLuongDonHangTrongKhoangThoiGian(startDate, endDate);

            return Json(thongKetheo);
        }
        [HttpPost]
        public IActionResult thongkeTrongKhoangTien(string ngaybatdau, string ngayketthuc)
        {
            if (ngaybatdau == null || ngayketthuc == null)
            {
                int[] thongKeArray = _hd.ThongKeTongTienHoaDonTheoThangTrongNam();

                return Json(thongKeArray);
            }
            DateTime startDate = DateTime.Parse(ngaybatdau);
            DateTime endDate = DateTime.Parse(ngayketthuc);

              decimal[] thongKetheo = _hd.ThongKeTongTienDonHangTrongKhoangThoiGian(startDate, endDate);

              return Json(thongKetheo);

         
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
            // (Ví dụ: định dạng có thể là số và không có ký tự đặc biệt)
            if (string.IsNullOrEmpty(phoneNumber))
            {
                return false;
            }

            // Check if the phone number has a length between 10 and 13 characters
            if (phoneNumber.Length < 10 || phoneNumber.Length > 13)
            {
                return false;
            }
            // (Ví dụ: định dạng có thể là số và không có ký tự đặc biệt)
            return Regex.IsMatch(phoneNumber, @"^[0-9]+$") && phoneNumber.Length <= 20;
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