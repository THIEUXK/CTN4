using CTN4_Data.Models.DB_CTN4;
using CTN4_Serv.Service.IService;
using CTN4_Serv.Service;
using CTN4_Serv.ServiceJoin;
using CTN4_Serv.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Net.Http;
using CTN4_Serv.ViewModel.banhangview;
using System.Text;
using CTN4_View.Areas.Admin.Viewmodel;
using CTN4_Serv.Service.Service;
using Microsoft.AspNetCore.Authorization;
using System.Text.RegularExpressions;
using CTN4_View.Controllers.Shop.ViewModelThieuxk;
using CTN4_View_Admin.Controllers.Shop;
using DocumentFormat.OpenXml.Spreadsheet;
using DocumentFormat.OpenXml.Wordprocessing;
using DocumentFormat.OpenXml.Office2010.Excel;

namespace CTN4_View.Controllers.Shop
{
    public class BanHangController : Controller
    {
        #region Ctro
        private readonly HttpClient _httpClient;

        private readonly SanPhamCuaHangService _sanPhamCuaHangService;
        public IGioHangService _GioHang;
        public IGioHangChiTietService _GioHangChiTiet;
        public GioHangjoiin _GioHangjoiin;
        public IHoaDonService _HoaDonService;
        public IHoaDonChiTietService _HoaDonChiTiet;
        public ISanPhamChiTietService _SanPhamChiTiet;
        public ISanPhamService _sanPhamService;
        public IAnhService _anhService;
        public IPhuongThucThanhToanService _phuongThucThanhToanService;
        public IDiaChiNhanHangService _diaChiNhanHangService;
        public IKhachHangService _khachHangService;
        public IGiamGiaService _giamGiaService;
        public IGiamGiaChiTietService _giamGiaChiTietService;
        public readonly string _clientId;
        public readonly string _Secretkey;
        public readonly IVnPayService _ivnPayService;
        public readonly ICurrentUser _CurrentUser;
        public ILichSuHoaDonService _LichSuHoaDonService;
        public IKhuyenMaiSanPhamService _KKhuyenMaiSanPhamService;
        public BanHangController(IConfiguration config, IVnPayService vnpay, ICurrentUser currentUser, IGioHangService giohang)
        {
            _KKhuyenMaiSanPhamService = new KhuyenMaiSanPhamService();
            _diaChiNhanHangService = new DiaChiNhanHangService();
            _sanPhamCuaHangService = new SanPhamCuaHangService();
            _GioHang = giohang;
            _GioHangChiTiet = new GioHangChiTietService();
            _GioHangjoiin = new GioHangjoiin();
            _HoaDonService = new HoaDonService();
            _HoaDonChiTiet = new HoaDonChiTietService();
            _SanPhamChiTiet = new SanPhamChiTietService();
            _httpClient = new HttpClient();
            _sanPhamService = new SanPhamService();
            _anhService = new AnhService();
            _khachHangService = new KhachHangService();
            _phuongThucThanhToanService = new PhuongThucThanhToanService();
            _giamGiaChiTietService = new GiamGiaChiTietService();
            _giamGiaService = new GiamGiaService();
            _httpClient.DefaultRequestHeaders.Add("token", "fa31ddca-73b0-11ee-b394-8ac29577e80e");
            _httpClient.DefaultRequestHeaders.Add("shop_id", "4189141");
            _ivnPayService = vnpay;
            _clientId = config["PaypalSettings:ClientId"];
            _Secretkey = config["PaypalSettings:SecretKey"];
            _CurrentUser = currentUser;
            _LichSuHoaDonService = new LichSuHoaDonService();

        }
        #endregion

        #region Gio Hang
        [HttpGet]
        public IActionResult GioHang()
        {
            var accnew = SessionServices.KhachHangSS(HttpContext.Session, "ACC");
            float tong = 0;
            if (accnew.Count != 0)
            {
                var tkmoi = accnew[0];
                var gioHang = _GioHang.GetAll().FirstOrDefault(c => c.IdKhachHang == tkmoi.Id);
                if (gioHang == null)
                {
                    var a = new GioHang()
                    {
                        Id = Guid.NewGuid(),
                        IdKhachHang = tkmoi.Id,
                        TrangThai = true
                    };
                    _GioHang.Them(a);
                }
                var gh = _GioHang.GetAll().FirstOrDefault(c => c.IdKhachHang == accnew[0].Id);
                IEnumerable<GioHangChiTiet> ghct = _GioHangjoiin.GetAll().Where(c => c.IdGioHang == gh.Id);
                foreach (var x in ghct)
                {
                    tong += float.Parse(x.SanPhamChiTiet.SanPham.GiaNiemYet.ToString()) * (x.SoLuong);
                }
                var anh = _anhService.GetAll().ToList();
                var KhuyenMaiSp = _KKhuyenMaiSanPhamService.GetAll().Where(c => c.KhuyenMai.Mua1tang1 == true && c.KhuyenMai.NgayBatDau <= DateTime.Now && c.KhuyenMai.NgayKetThuc >= DateTime.Now && c.KhuyenMai.Is_Detele == true).ToList();
                var g = new List<Guid>();
                foreach (var item in KhuyenMaiSp)
                {
                    // Kiểm tra xem Mau.Id đã xuất hiện trong danh sách chưa
                    if (!g.Contains((Guid)item.IdSanPham))
                    {
                        g.Add((Guid)item.IdSanPham);
                    }
                }
                var view2 = new GioHangView()
                {
                    check11 = g,
                    GioHangChiTiets = ghct,
                    TongTien = tong,
                    anhs = anh
                };
                return View(view2);
            }
            else
            {
                return RedirectToAction("login", "Home");
            }

        }
        public IActionResult XoaChiTietGioHang(Guid id)
        {
            var b = _GioHangChiTiet.GetById(id);
            var product = _SanPhamChiTiet.GetById(b.IdSanPhamChiTiet.Value);
            if (_GioHangChiTiet.Xoa(id))
            {
                product.SoLuong += b.SoLuong;
                if (_SanPhamChiTiet.Sua(product))
                {
                    return RedirectToAction("GioHang");
                }

            }
            var message = "Xóa Thất Bại";
            TempData["ErrorMessage"] = message;
            return RedirectToAction("GioHang", "BanHang", new { message });

        }
        public IActionResult ThemVaoGio(int soluong, Guid IdSanPham, Guid IdSize, Guid IdMau)
        {
            if (IdSize == Guid.Parse("00000000-0000-0000-0000-000000000000") || IdMau == Guid.Parse("00000000-0000-0000-0000-000000000000"))
            {
                var message2 = "Hãy chọn màu và size trước khi thêm vào giỏ hàng !";
                TempData["TB2"] = message2;
                return RedirectToAction("HienThiSanPhamChiTiet", "HienThiSanPham", new { id = IdSanPham, message2 });
            }
            var accnew = SessionServices.KhachHangSS(HttpContext.Session, "ACC");
            if (accnew.Count != 0)
            {
                var checksp = _SanPhamChiTiet.GetAll().FirstOrDefault(c => c.IdSp == IdSanPham && c.IdSize == IdSize && c.IdMau == IdMau);
                if (checksp.TrangThai!=true||checksp.Is_detele!=true|| checksp.SanPham.TrangThai != true || checksp.SanPham.Is_detele != true)
                {
                    var message2 = "Sản phẩm này đang gặp vấn đền hãy quay lại sau !";
                    TempData["TB2"] = message2;
                    return RedirectToAction("HienThiSanPhamChiTiet", "HienThiSanPham", new { id = IdSanPham, message2 });
                }
                var KhuyenMaiSp = _KKhuyenMaiSanPhamService.GetAll().Where(c => c.KhuyenMai.Mua1tang1 == true && c.KhuyenMai.NgayBatDau <= DateTime.Now && c.KhuyenMai.NgayKetThuc >= DateTime.Now && c.KhuyenMai.Is_Detele == true).ToList();
                var g = new List<Guid>();
                foreach (var item in KhuyenMaiSp)
                {
                    // Kiểm tra xem Mau.Id đã xuất hiện trong danh sách chưa
                    if (!g.Contains((Guid)item.IdSanPham))
                    {
                        g.Add((Guid)item.IdSanPham);
                    }
                }
                if (g.Contains(checksp.SanPham.Id))
                {
                    if (soluong * 2 > checksp.SoLuong)
                    {
                        var message2 = "Số lượng không đủ vì đây là sản phẩm mua 1 tặng 1 !";
                        TempData["TB2"] = message2;
                        return RedirectToAction("HienThiSanPhamChiTiet", "HienThiSanPham", new { id = IdSanPham, message2 });
                    }
                }
                if (soluong > 20)
                {
                    var message2 = "Sản phẩm này trong giỏ hàng đã vượt quá 20 sản phẩm vui lòng liên hệ shop để mua sỉ hoặc kiểm tra lại số lượng trong giỏ hàng!";
                    TempData["TB2"] = message2;
                    return RedirectToAction("HienThiSanPhamChiTiet", "HienThiSanPham", new { id = IdSanPham, message2 });
                }
                if (soluong > checksp.SoLuong)
                {
                    var message2 = "Số lượng không đủ !";
                    TempData["TB2"] = message2;
                    return RedirectToAction("HienThiSanPhamChiTiet", "HienThiSanPham", new { id = IdSanPham, message2 });
                }
                if (IdMau == Guid.Parse("00000000-0000-0000-0000-000000000000") || IdSize == Guid.Parse("00000000-0000-0000-0000-000000000000"))
                {
                    var message1 = "hãy chọn màu và size của bạn !";
                    TempData["TB1"] = message1;
                    return RedirectToAction("HienThiSanPhamChiTiet", "HienThiSanPham", new { id = IdSanPham, message1 });
                }
                if (soluong <= 0)
                {
                    var message2 = "Số lượng phải lớn hơn 0 !";
                    TempData["TB2"] = message2;
                    return RedirectToAction("HienThiSanPhamChiTiet", "HienThiSanPham", new { id = IdSanPham, message2 });
                }

                var tkmoi = accnew[0];
                if (tkmoi != null)
                {
                    var sanphamCT = _SanPhamChiTiet.GetAll().FirstOrDefault(c => c.IdSp == IdSanPham && c.IdSize == IdSize && c.IdMau == IdMau);
                    var gioHang = _GioHang.GetAll().FirstOrDefault(c => c.IdKhachHang == tkmoi.Id);
                    if (gioHang == null)
                    {
                        var a = new GioHang()
                        {
                            Id = Guid.NewGuid(),
                            IdKhachHang = tkmoi.Id,
                            TrangThai = true
                        };
                        _GioHang.Them(a);
                    }
                    {
                        var SP = _GioHangChiTiet.GetAll().FirstOrDefault(c => c.IdSanPhamChiTiet == sanphamCT.Id && c.IdGioHang == gioHang.Id);
                        if (SP == null)
                        {
                            var d = new GioHangChiTiet()
                            {
                                Id = Guid.NewGuid(),
                                IdSanPhamChiTiet = sanphamCT.Id,
                                IdGioHang = _GioHang.GetAll().FirstOrDefault(c => c.IdKhachHang == tkmoi.Id).Id,
                                SoLuong = soluong,
                            };
                            if (_GioHangChiTiet.Them(d))
                            {
                                var product = _SanPhamChiTiet.GetById(sanphamCT.Id);
                                product.SoLuong -= soluong;
                                if (_SanPhamChiTiet.Sua(product))
                                {
                                    return RedirectToAction("GioHang");
                                }
                            }
                        }
                        else
                        {
                            SP.SoLuong += soluong;
                            if (SP.SoLuong > 20)
                            {
                                var message2 = "Sản phẩm này trong giỏ hàng đã vượt quá 20 sản phẩm vui lòng liên hệ shop để mua sỉ hoặc kiểm tra lại số lượng trong giỏ hàng!";
                                TempData["TB2"] = message2;
                                return RedirectToAction("HienThiSanPhamChiTiet", "HienThiSanPham", new { id = IdSanPham, message2 });
                            }
                            if (_GioHangChiTiet.Sua(SP))
                            {
                                var product = _SanPhamChiTiet.GetById(sanphamCT.Id);
                                product.SoLuong -= soluong;
                                if (_SanPhamChiTiet.Sua(product))
                                {
                                    return RedirectToAction("GioHang");
                                }
                            }
                        }
                    }
                    var message3 = "Thêm thất bại !";
                    TempData["TB1"] = message3;
                    return RedirectToAction("HienThiSanPhamChiTiet", "HienThiSanPham", new { id = IdSanPham, message3 });

                }
            }
            else
            {
                return RedirectToAction("login", "Home");
            }

            var message4 = "Thêm thất bại !";
            TempData["TB1"] = message4;
            return RedirectToAction("HienThiSanPhamChiTiet", "HienThiSanPham", new { id = IdSanPham, message4 });
        }
        public IActionResult CapNhanSoLuong(Guid id, int soluong)
        {
            var b = _GioHangChiTiet.GetById(id);
            if (soluong == b.SoLuong)
            {
                var message = "hãy điền số lượng mong muốn của bạn để được cập nhật";
                TempData["ErrorMessage"] = message;
                return RedirectToAction("GioHang", "BanHang", new { message });
            }
            if (soluong > 20)
            {
                var message = "Số lượng đã vượi quá 20 hãy liên hệ với shop để có thể mua sỉ";
                TempData["ErrorMessage"] = message;
                return RedirectToAction("GioHang", "BanHang", new { message });
            }
            if (soluong < 1)
            {
                var message = "Số lượng hiện không thể nhỏ hơn 1";
                TempData["ErrorMessage"] = message;
                return RedirectToAction("GioHang", "BanHang", new { message });
            }
            var KhuyenMaiSp = _KKhuyenMaiSanPhamService.GetAll().Where(c => c.KhuyenMai.Mua1tang1 == true && c.KhuyenMai.NgayBatDau <= DateTime.Now && c.KhuyenMai.NgayKetThuc >= DateTime.Now && c.KhuyenMai.Is_Detele == true).ToList();
            var g = new List<Guid>();
            foreach (var item in KhuyenMaiSp)
            {
                // Kiểm tra xem Mau.Id đã xuất hiện trong danh sách chưa
                if (!g.Contains((Guid)item.IdSanPham))
                {
                    g.Add((Guid)item.IdSanPham);
                }
            }
            var product = _SanPhamChiTiet.GetById(b.IdSanPhamChiTiet.Value);

            if (g.Contains((Guid)product.IdSp))
            {
                if (soluong > 10)
                {
                    var message = "Số lượng sản phẩm này không thể lớn hơn 10 vì đang được mua 1 tặng 1,nếu muốn mua nhiều hãy liên hệ với shop để được mua sỉ";
                    TempData["ErrorMessage"] = message;
                    return RedirectToAction("GioHang", "BanHang", new { message });
                }
            }

            int soluothem = 0;
            soluothem = soluong - b.SoLuong;
            if (soluothem > product.SoLuong)
            {
                var message = "Số lượng của sản phẩm này không đủ";
                TempData["ErrorMessage"] = message;
                return RedirectToAction("GioHang", "BanHang", new { message });
            }
            else
            {
                b.SoLuong += soluothem;
                product.SoLuong -= soluothem;
                _SanPhamChiTiet.Sua(product);
                _GioHangChiTiet.Sua(b);
                var message = "Thay đổi số lượng thành công";
                TempData["ErrorMessage2"] = message;
                return RedirectToAction("GioHang", "BanHang", new { message });
            }
        }
        [HttpPost("/CheckOut/ChotGio")]
        public JsonResult ChotHang(List<Guid> selectedIds)
        {
            var luuGio = SessionBan.IdGio(HttpContext.Session, "LuoGio");
            if (luuGio.Count == 0)
            {
                foreach (var a in selectedIds)
                {
                    luuGio.Add(a);
                    SessionBan.SetObjToJson(HttpContext.Session, "LuoGio", luuGio);
                }
            }
            else
            {
                luuGio.Clear();
                foreach (var a in selectedIds)
                {
                    luuGio.Add(a);
                    SessionBan.SetObjToJson(HttpContext.Session, "LuoGio", luuGio);

                }
            }
            return Json("ok", new System.Text.Json.JsonSerializerOptions());
        }
        [HttpPost("/CheckOut/TinhTongTien")]
        public JsonResult TinhTongTicGio(List<Guid> selectedIds)
        {
            var accnew = SessionServices.KhachHangSS(HttpContext.Session, "ACC");
            float tong = 0;
            if (accnew.Count != 0)
            {
                var tkmoi = accnew[0];
                var gioHang = _GioHang.GetAll().FirstOrDefault(c => c.IdKhachHang == tkmoi.Id);
                if (gioHang == null)
                {
                    var a = new GioHang()
                    {
                        Id = Guid.NewGuid(),
                        IdKhachHang = tkmoi.Id,
                        TrangThai = true
                    };
                    _GioHang.Them(a);
                }
                var gh = _GioHang.GetAll().FirstOrDefault(c => c.IdKhachHang == accnew[0].Id);

                IEnumerable<GioHangChiTiet> ghct = _GioHangjoiin.GetAll().Where(c => c.IdGioHang == gh.Id && selectedIds.Contains(c.Id));
                foreach (var x in ghct)
                {
                    tong += float.Parse(x.SanPhamChiTiet.SanPham.GiaNiemYet.ToString()) * (x.SoLuong);
                }
                return Json(tong, new System.Text.Json.JsonSerializerOptions());
            }
            else
            {
                return Json("LoiDangNhap", new System.Text.Json.JsonSerializerOptions());
            }
        }
        #endregion

        #region Ban Hang
        public IActionResult PaymentCallback()
        {
            var response = _ivnPayService.PaymentExecute(Request.Query);
            response.IdUser = _CurrentUser.Id;
            if (response.PaymentId == "0")
            {
                var message = "Thanh toám thất bại";
                TempData["TB2"] = message;
                return RedirectToAction("ThuTucThanhToan", "BanHang", new { message });
            }
            var LuuTam = SessionBan.ThongTinTamSS(HttpContext.Session, "ACD");
            if (LuuTam.Count != 1)
            {
                var message = "Thanh toám thất bại";
                TempData["TB2"] = message;
                return RedirectToAction("ThuTucThanhToan", "BanHang", new { message });
            }
            int idHoaDon;
            var hh = _HoaDonService.GetAll().ToList();
            if (hh.Count == 0)
            {
                idHoaDon = 1;
            }
            else
            {
                idHoaDon = hh.Max(c => c.Id) + 1;
            }

            var accnew = SessionServices.KhachHangSS(HttpContext.Session, "ACC");
            var gh = _GioHang.GetAll().FirstOrDefault(c => c.IdKhachHang == accnew[0].Id);
            if (accnew.Count != 0 && gh != null)
            {

                var hd = new HoaDon()
                {
                    MaHoaDon = $"HD0{idHoaDon}",
                    DiaChi = LuuTam[0].DiachiNhanChiTiet + " " + LuuTam[0].addDiaChi,
                    TrangThai = "Đang chờ xử lí",
                    TongTien = LuuTam[0].tongtien,
                    TienShip = LuuTam[0].tienship,
                    NgayDat = DateTime.Now,
                    TrangThaiThanhToan = true,
                    Email = LuuTam[0].Email,
                    GhiChu = LuuTam[0].ghiChu,
                    IdKhachHang = accnew[0].Id,
                    IdPhuongThuc = LuuTam[0].idphuongthuc,
                    SDTNguoiNhan = LuuTam[0].Sodienthoai,
                    TenKhachHang = LuuTam[0].name,
                    Is_detele = true,
                };
                if (LuuTam[0].IdDiaChi != Guid.Parse("00000000-0000-0000-0000-000000000000"))
                {
                    hd.IdDiaChiNhanHang = LuuTam[0].IdDiaChi;
                }
                if (_HoaDonService.Them(hd) == false)
                {
                    var message = "thanh toán lỗi(1)";
                    TempData["ErrorMessage"] = message;
                    return RedirectToAction("ThuTucThanhToan", "BanHang", new { message });
                }
                var giamgianew = SessionBan.GiamGiaSS(HttpContext.Session, "GiamGia");
                if (giamgianew.Count != 0)
                {
                    var giamct = new GiamGiaChiTiet()
                    {
                        IdHoaDon = hd.Id,
                        IdGiamGia = giamgianew[0].Id
                    };
                    var a = _giamGiaService.GetById(giamgianew[0].Id);
                    a.SoLuong -= 1;
                    if (_giamGiaChiTietService.Them(giamct) == false || _giamGiaService.Sua(a) == false)
                    {
                        var message = "lỗi mã giảm giá";
                        TempData["ErrorMessage"] = message;
                        return RedirectToAction("ThuTucThanhToan", "BanHang", new { message });
                    }
                }
                var KhuyenMaiSp = _KKhuyenMaiSanPhamService.GetAll().Where(c => c.KhuyenMai.Mua1tang1 == true && c.KhuyenMai.NgayBatDau <= DateTime.Now && c.KhuyenMai.NgayKetThuc >= DateTime.Now && c.KhuyenMai.Is_Detele == true).ToList();
                var g = new List<Guid>();
                foreach (var item in KhuyenMaiSp)
                {
                    // Kiểm tra xem Mau.Id đã xuất hiện trong danh sách chưa
                    if (!g.Contains((Guid)item.IdSanPham))
                    {
                        g.Add((Guid)item.IdSanPham);
                    }
                }
                //Thêm chi tiết hóa đơn cho từng sản phẩm trong giỏ hàng
                var luuGio = SessionBan.IdGio(HttpContext.Session, "LuoGio");
                var lisdiachi1 = _diaChiNhanHangService.GetAll().Where(c => c.IdKhachHang == accnew[0].Id && c.Is_detele == true).ToList();
                var lisdiachi = _diaChiNhanHangService.GetAll().Where(c => c.DiaChi == LuuTam[0].addDiaChi && c.IdKhachHang == accnew[0].Id && c.TienShip == LuuTam[0].tienship && c.Is_detele == true).ToList();
                if (lisdiachi1.Count() < 4 && lisdiachi.Count == 0)
                {
                    int dem = 0;
                    var ghct2 = _GioHangChiTiet.GetAll().Where(c => luuGio.Contains(c.Id));
                    foreach (var a2 in ghct2)
                    {
                        dem += a2.SoLuong;
                    }
                    var diachi = new DiaChiNhanHang()
                    {
                        IdKhachHang = accnew[0].Id,
                        name = LuuTam[0].addDiaChi,
                        DiaChi = LuuTam[0].addDiaChi,
                        TienShip = LuuTam[0].tienship /= dem,
                    };
                    _diaChiNhanHangService.Them(diachi);
                }
                foreach (var ct in _GioHangChiTiet.GetAll().Where(c => c.IdGioHang == gh.Id && luuGio.Contains(c.Id)))
                {
                    var cthd = new HoaDonChiTiet()
                    {
                        Id = Guid.NewGuid(),
                        IdHoaDon = hd.Id, //Id của hóa đơn vừa tạo
                        IdSanPhamChiTiet = ct.IdSanPhamChiTiet,
                        SoLuong = ct.SoLuong,
                        GiaTien = ct.SanPhamChiTiet.SanPham.GiaNiemYet,
                        TrangThai = true,
                        Is_detele = true,
                    };
                    if (g.Contains(ct.SanPhamChiTiet.SanPham.Id))
                    {
                        cthd.SoLuong *= 2;
                    }
                    if (_HoaDonChiTiet.Them(cthd) == false)
                    {
                        var message = "thanh toán lỗi(2)";
                        TempData["ErrorMessage"] = message;
                        return RedirectToAction("ThuTucThanhToan", "BanHang", new { message });
                    }
                    //Trừ số lượng sản phẩm trong CSDL
                    if (_GioHangChiTiet.Xoa(ct.Id) == false) //Xóa các bản ghi mà người dùng thêm vào trong giỏ hàng
                    {
                        var message = "thanh toán lỗi(3)";
                        TempData["ErrorMessage"] = message;
                        return RedirectToAction("ThuTucThanhToan", "BanHang", new { message });
                    }

                }
            }


            else
            {
                return RedirectToAction("login", "Home");

            }

            return RedirectToAction("SauThanhToan", new { id = idHoaDon });
        }
        //Huyen
        [HttpGet("CheckOut/GetListDistrict")]
        public JsonResult GetListDistrict(int idProvin)
        {

            HttpResponseMessage responseDistrict = _httpClient.GetAsync("https://online-gateway.ghn.vn/shiip/public-api/master-data/district?province_id=" + idProvin).Result;

            District lstDistrict = new District();

            if (responseDistrict.IsSuccessStatusCode)
            {
                string jsonData2 = responseDistrict.Content.ReadAsStringAsync().Result;

                lstDistrict = JsonConvert.DeserializeObject<District>(jsonData2);
            }
            return Json(lstDistrict, new System.Text.Json.JsonSerializerOptions());
        }
        //Lấy địa chỉ phường xã
        [HttpGet("/CheckOut/GetListWard")]
        public JsonResult GetListWard(int idWard)
        {


            HttpResponseMessage responseWard = _httpClient.GetAsync("https://online-gateway.ghn.vn/shiip/public-api/master-data/ward?district_id=" + idWard).Result;

            Ward lstWard = new Ward();

            if (responseWard.IsSuccessStatusCode)
            {
                string jsonData2 = responseWard.Content.ReadAsStringAsync().Result;

                lstWard = JsonConvert.DeserializeObject<Ward>(jsonData2);
            }
            return Json(lstWard, new System.Text.Json.JsonSerializerOptions());
        }
        [HttpPost("/CheckOut/GetTotalShipping")]
        public async Task<JsonResult> GetTotalShipping([FromBody] ShippingOrder shippingOrder)
        {
            var hang = new TinhTienShip()
            {
                service_id = shippingOrder.service_id,
                insurance_value = shippingOrder.insurance_value,
                from_district_id = shippingOrder.from_district_id,
                to_district_id = shippingOrder.to_district_id,
                to_ward_code = shippingOrder.to_ward_code.ToString(),
                height = shippingOrder.height,
                length = shippingOrder.length,
                weight = shippingOrder.weight,
                width = shippingOrder.width,
            };
            var url = $"https://online-gateway.ghn.vn/shiip/public-api/v2/shipping-order/fee";
            float tong = 0;
            var content = new StringContent(JsonConvert.SerializeObject(hang), Encoding.UTF8, "application/json");
            var respose = await _httpClient.PostAsync(url, content);
            Shipping shipping = new Shipping();
            if (respose.IsSuccessStatusCode)
            {
                var luuGio = SessionBan.IdGio(HttpContext.Session, "LuoGio");
                int dem = 0;
                var ghct = _GioHangChiTiet.GetAll().Where(c => luuGio.Contains(c.Id));
                foreach (var a in ghct)
                {
                    dem += a.SoLuong;
                }
                string jsonData2 = respose.Content.ReadAsStringAsync().Result;
                shipping = JsonConvert.DeserializeObject<Shipping>(jsonData2);
                HttpContext.Session.SetInt32("shiptotal", shipping.data.total);
                shipping.data.totaloder = shippingOrder.tienhang + (shipping.data.total * dem) - shippingOrder.tiengiam;
                shipping.tienGiam = shippingOrder.tiengiam;
                shipping.data.total *= dem;
                //shipping.data.totaloder = shipping.data.total + int.Parse(tong.ToString());
                return Json(shipping, new System.Text.Json.JsonSerializerOptions());
            }
            else
            {
                shipping.message = "False";

                //shipping.data.totaloder = shipping.data.total + int.Parse(tong.ToString());
                return Json(shipping, new System.Text.Json.JsonSerializerOptions());
            }

        }
        static bool IsValidGmail(string email)
        {
            // Định nghĩa một biểu thức chính quy cho địa chỉ Gmail
            string pattern = @"^[a-zA-Z0-9._%+-]+@gmail\.com$";
            // Sử dụng Regex.IsMatch để kiểm tra xem địa chỉ email có khớp với biểu thức không
            return Regex.IsMatch(email, pattern);
        }
        public IActionResult HoanThanhThanhToan(string tenmagiam, float tiengiama, float tienhanga, string name, string DiachiNhanChiTiet, string Sodienthoai, string Email, string addDiaChi, Guid IdDiaChi, Guid idphuongthuc, string ghiChu, float tienshipa, float tongtien)
        {
            var KhuyenMaiSp = _KKhuyenMaiSanPhamService.GetAll().Where(c => c.KhuyenMai.Mua1tang1 == true && c.KhuyenMai.NgayBatDau <= DateTime.Now && c.KhuyenMai.NgayKetThuc >= DateTime.Now && c.KhuyenMai.Is_Detele == true).ToList();
            var g = new List<Guid>();
            foreach (var item in KhuyenMaiSp)
            {
                // Kiểm tra xem Mau.Id đã xuất hiện trong danh sách chưa
                if (!g.Contains((Guid)item.IdSanPham))
                {
                    g.Add((Guid)item.IdSanPham);
                }
            }
            #region Check validate
            if (Sodienthoai.Length < 10 || Sodienthoai.Length > 13)
            {
                {
                    var message = "Số điện thoại phải từ 10 số trở lên";
                    TempData["TB2"] = message;
                    return RedirectToAction("ThuTucThanhToan", "BanHang", new { message });
                }
            }
            if (!IsValidGmail(Email))
            {
                var message = "Email không hợp lệ";
                TempData["TB2"] = message;
                return RedirectToAction("ThuTucThanhToan", "BanHang", new { message });
            }

            if (name == null)
            {
                {
                    var message = "hãy nhớ điền tên của bạn";
                    TempData["TB2"] = message;
                    return RedirectToAction("ThuTucThanhToan", "BanHang", new { message });
                }
            }
            if (DiachiNhanChiTiet == null)
            {
                {
                    var message = "hãy nhớ điền địa chỉ chi tiết của bạn";
                    TempData["TB2"] = message;
                    return RedirectToAction("ThuTucThanhToan", "BanHang", new { message });
                }
            }
            if (Sodienthoai == null)
            {
                {
                    var message = "hãy nhớ điền số điện thoại của bạn";
                    TempData["TB2"] = message;
                    return RedirectToAction("ThuTucThanhToan", "BanHang", new { message });
                }
            }
            if (Email == null)
            {
                {
                    var message = "hãy nhớ điền Email của bạn";
                    TempData["TB2"] = message;
                    return RedirectToAction("ThuTucThanhToan", "BanHang", new { message });
                }
            }
            if (addDiaChi == null)
            {
                {
                    var message = "hãy nhớ chọn địa chỉ của bạn";
                    TempData["TB2"] = message;
                    return RedirectToAction("ThuTucThanhToan", "BanHang", new { message });
                }
            }
            if (idphuongthuc == Guid.Parse("00000000-0000-0000-0000-000000000000"))
            {
                {
                    var message = "hãy nhớ chọn phương thức thanh toán của bạn";
                    TempData["TB1"] = message;
                    return RedirectToAction("ThuTucThanhToan", "BanHang", new { message });
                }
            }
            #endregion
            #region ma tu sinh
            int idHoaDon;
            var hh = _HoaDonService.GetAll().ToList();
            if (hh.Count == 0)
            {
                idHoaDon = 1;
            }
            else
            {
                idHoaDon = hh.Max(c => c.Id) + 1;
            }
            #endregion
            var accnew = SessionServices.KhachHangSS(HttpContext.Session, "ACC");
            var gh = _GioHang.GetAll().FirstOrDefault(c => c.IdKhachHang == accnew[0].Id);

            if (accnew.Count != 0 && gh != null)
            {
                #region tao hoa don
                var luuGio2 = SessionBan.IdGio(HttpContext.Session, "LuoGio");
                var ghct = _GioHangChiTiet.GetAll().Where(c => c.IdGioHang == gh.Id && luuGio2.Contains(c.Id));
                foreach (var ct in ghct)
                {
                    if (ct.SanPhamChiTiet.TrangThai!=true||ct.SanPhamChiTiet.Is_detele!=true|| ct.SanPhamChiTiet.SanPham.TrangThai != true || ct.SanPhamChiTiet.SanPham.Is_detele != true)
                    {
                            var message = $"Sản phẩm {ct.SanPhamChiTiet.SanPham.TenSanPham} hiện đang gặp vấn đề hãy mua sản phẩm này sau";
                            TempData["ErrorMessage"] = message;
                            return RedirectToAction("ThuTucThanhToan", "BanHang", new { message });
                    }
                    if (g.Contains(ct.SanPhamChiTiet.SanPham.Id))
                    {
                        if ((ct.SoLuong *= 2) > ct.SanPhamChiTiet.SoLuong)
                        {
                            var message = $"Sản phẩm {ct.SanPhamChiTiet.SanPham.TenSanPham} hiện đang được mua 1 tặng 1 hiện tại không thể thanh toán được vì số lượng tặng không đủ xin hay quay lại sau";
                            TempData["ErrorMessage"] = message;
                            return RedirectToAction("ThuTucThanhToan", "BanHang", new { message });
                        }
                    }
                }
                if (idphuongthuc == Guid.Parse("d16ac357-3ced-4c2c-bcdc-d38971211114"))
                {
                    var alTam = new ThongTinTam()
                    {
                        name = name,
                        DiachiNhanChiTiet = DiachiNhanChiTiet,
                        Sodienthoai = Sodienthoai,
                        Email = Email,
                        addDiaChi = addDiaChi,
                        IdDiaChi = IdDiaChi,
                        idphuongthuc = idphuongthuc,
                        ghiChu = ghiChu,
                        tienship = tienshipa,
                        tongtien = tongtien,
                        TienHang = tienhanga,
                        TienGiam = tiengiama,
                    };
                    var LuuTam = SessionBan.ThongTinTamSS(HttpContext.Session, "ACD");
                    if (LuuTam.Count == 0)
                    {
                        LuuTam.Add(alTam);
                        SessionBan.SetObjToJson(HttpContext.Session, "ACD", LuuTam);
                    }
                    else if (LuuTam.Count != 0)
                    {
                        LuuTam.Clear();
                        LuuTam.Add(alTam);
                        SessionBan.SetObjToJson(HttpContext.Session, "ACD", LuuTam);
                    }
                    var model = new PaymentInformationModel()
                    {
                        OrderType = "túi sách",
                        Amount = tongtien,
                        OrderDescription = "Mua Tại Shop Boro",
                        Name = name,
                    };
                    var url = _ivnPayService.CreatePaymentUrl(model, HttpContext);
                    return Redirect(url);
                }
                else
                {
                    var hd = new HoaDon()
                    {
                        MaHoaDon = $"HD0{idHoaDon}",
                        DiaChi = DiachiNhanChiTiet + " " + addDiaChi,
                        TrangThai = "Đang chờ xử lí",
                        TongTien = tongtien,
                        TienShip = tienshipa,
                        TienGiam = tiengiama,
                        TienHang = tienhanga,
                        NgayDat = DateTime.Now,
                        TrangThaiThanhToan = false,
                        Email = Email,
                        GhiChu = ghiChu,
                        IdKhachHang = accnew[0].Id,
                        IdPhuongThuc = idphuongthuc,
                        SDTNguoiNhan = Sodienthoai,
                        TenKhachHang = name,
                        Is_detele = true,
                    };
                    if (IdDiaChi != Guid.Parse("00000000-0000-0000-0000-000000000000"))
                    {
                        hd.IdDiaChiNhanHang = IdDiaChi;
                    }
                    if (_HoaDonService.Them(hd) == false)
                    {
                        var message = "thanh toán lỗi(1)";
                        TempData["ErrorMessage"] = message;
                        return RedirectToAction("ThuTucThanhToan", "BanHang", new { message });
                    }
                    var giamgianew = SessionBan.GiamGiaSS(HttpContext.Session, "GiamGia");
                    if (tiengiama != 0)
                    {
                        var giamct = new GiamGiaChiTiet()
                        {
                            IdHoaDon = hd.Id,
                            IdGiamGia = giamgianew[0].Id
                        };
                        var a = _giamGiaService.GetById(giamgianew[0].Id);
                        a.SoLuong -= 1;
                        if (_giamGiaChiTietService.Them(giamct) == false || _giamGiaService.Sua(a) == false)
                        {
                            var message = "lỗi mã giảm giá";
                            TempData["ErrorMessage"] = message;
                            return RedirectToAction("ThuTucThanhToan", "BanHang", new { message });
                        }
                    }

                    //Thêm chi tiết hóa đơn cho từng sản phẩm trong giỏ hàng
                    var luuGio = SessionBan.IdGio(HttpContext.Session, "LuoGio");
                    var lisdiachi1 = _diaChiNhanHangService.GetAll().Where(c => c.IdKhachHang == accnew[0].Id && c.Is_detele == true).ToList();
                    var lisdiachi = _diaChiNhanHangService.GetAll().Where(c => c.DiaChi == addDiaChi && c.IdKhachHang == accnew[0].Id && c.Is_detele == true).ToList();
                    if (lisdiachi1.Count() < 4 && lisdiachi.Count == 0)
                    {
                        int dem = 0;
                        var ghct2 = _GioHangChiTiet.GetAll().Where(c => luuGio.Contains(c.Id));
                        foreach (var a2 in ghct2)
                        {
                            dem += a2.SoLuong;
                        }
                        var diachi = new DiaChiNhanHang()
                        {
                            IdKhachHang = accnew[0].Id,
                            name = DiachiNhanChiTiet,
                            DiaChi = addDiaChi,
                            TienShip = tienshipa /= dem,
                            Is_detele = true,
                            TrangThai = false
                        };
                        _diaChiNhanHangService.Them(diachi);
                    }
                    foreach (var ct in _GioHangChiTiet.GetAll().Where(c => c.IdGioHang == gh.Id && luuGio.Contains(c.Id)))
                    {
                        var cthd = new HoaDonChiTiet()
                        {
                            Id = Guid.NewGuid(),
                            IdHoaDon = hd.Id, //Id của hóa đơn vừa tạo
                            IdSanPhamChiTiet = ct.IdSanPhamChiTiet,
                            SoLuong = ct.SoLuong,
                            GiaTien = ct.SanPhamChiTiet.SanPham.GiaNiemYet,
                            TrangThai = true,
                            Is_detele = true,
                        };
                        if (g.Contains(ct.SanPhamChiTiet.SanPham.Id))
                        {
                            var spct = _SanPhamChiTiet.GetById(ct.IdSanPhamChiTiet);
                            spct.SoLuong -= ct.SoLuong;
                            cthd.SoLuong *= 2;
                            _SanPhamChiTiet.Sua(spct);
                        }
                        if (_HoaDonChiTiet.Them(cthd) == false)
                        {
                            var message = "thanh toán lỗi(2)";
                            TempData["ErrorMessage"] = message;
                            return RedirectToAction("ThuTucThanhToan", "BanHang", new { message });
                        }
                        //Trừ số lượng sản phẩm trong CSDL
                        if (_GioHangChiTiet.Xoa(ct.Id) == false) //Xóa các bản ghi mà người dùng thêm vào trong giỏ hàng
                        {
                            var message = "thanh toán lỗi(3)";
                            TempData["ErrorMessage"] = message;
                            return RedirectToAction("ThuTucThanhToan", "BanHang", new { message });
                        }

                    }
                }
                #endregion
            }
            else
            {
                return RedirectToAction("login", "Home");

            }

            return RedirectToAction("SauThanhToan", new { id = idHoaDon });
        }
        [HttpGet("/BanHang/ThuTuc")]
        public IActionResult ThuTucThanhToan()
        {
            var giamgianew = SessionBan.GiamGiaSS(HttpContext.Session, "GiamGia");
            giamgianew.Clear();
            HttpResponseMessage responseProvin = _httpClient.GetAsync("https://online-gateway.ghn.vn/shiip/public-api/master-data/province").Result;

            Provin lstprovin = new Provin();

            if (responseProvin.IsSuccessStatusCode)
            {
                string jsonData2 = responseProvin.Content.ReadAsStringAsync().Result;
                lstprovin = JsonConvert.DeserializeObject<Provin>(jsonData2);
                ViewBag.Provin = new SelectList(lstprovin.data, "ProvinceID", "ProvinceName");
            }
            float tong = 0;
            var accnew = SessionServices.KhachHangSS(HttpContext.Session, "ACC");
            if (accnew.Count != 0)
            {
                var luuGio = SessionBan.IdGio(HttpContext.Session, "LuoGio");
                if (luuGio.Count == 0)
                {
                    var message = "Giỏ hàng đang không được tích hãy thêm sản phẩm của bạn để tiến hàng đặt hàng";
                    TempData["TB4"] = message;
                    return RedirectToAction("GioHang", new { message });
                }
                var gh = _GioHang.GetAll().FirstOrDefault(c => c.IdKhachHang == accnew[0].Id);
                IEnumerable<GioHangChiTiet> ghct = _GioHangjoiin.GetAll().Where(c => c.IdGioHang == gh.Id && luuGio.Contains(c.Id));
                if (ghct.Count() == 0)
                {
                    var message = "Giỏ hàng đang trống hãy thêm sản phẩm của bạn để tiến hàng đặt hàng";
                    TempData["TB4"] = message;
                    return RedirectToAction("GioHang", new { message });
                }

                foreach (var x in ghct)
                {
                    tong += float.Parse(x.SanPhamChiTiet.SanPham.GiaNiemYet.ToString()) * (x.SoLuong);

                }
                var a = _GioHangjoiin.GetAll().Where(c => c.IdGioHang == gh.Id && luuGio.Contains(c.Id));
                var nguoidung = _khachHangService.GetAll().FirstOrDefault(c => c.Id == accnew[0].Id);
                var diachinhanhang = _diaChiNhanHangService.GetAll().Where(c => c.IdKhachHang == accnew[0].Id).FirstOrDefault(c => c.TrangThai == true && c.Is_detele == true);
                var giamgia = _giamGiaService.GetAll().Where(c => c.TrangThai == true && c.Is_detele == true && c.NgayBatDau <= DateTime.Now && c.NgayKetThuc >= DateTime.Now).ToList();
                var KhuyenMaiSp = _KKhuyenMaiSanPhamService.GetAll().Where(c => c.KhuyenMai.Mua1tang1 == true && c.KhuyenMai.NgayBatDau <= DateTime.Now && c.KhuyenMai.NgayKetThuc >= DateTime.Now && c.KhuyenMai.Is_Detele == true).ToList();
                var g = new List<Guid>();
                foreach (var item in KhuyenMaiSp)
                {
                    // Kiểm tra xem Mau.Id đã xuất hiện trong danh sách chưa
                    if (!g.Contains((Guid)item.IdSanPham))
                    {
                        g.Add((Guid)item.IdSanPham);
                    }
                }
                var luuGio2 = SessionBan.IdGio(HttpContext.Session, "LuoGio");
                int dem = 0;
                var ghct2 = _GioHangChiTiet.GetAll().Where(c => luuGio.Contains(c.Id));
                foreach (var a2 in ghct)
                {
                    dem += a2.SoLuong;
                }

                if (diachinhanhang != null)
                {
                    diachinhanhang.TienShip *= dem;
                }

                var view2 = new GioHangView()
                {
                    check11 = g,
                    GiamGias = giamgia,
                    DiaChiNhanHang = diachinhanhang,
                    KhachHang = nguoidung,
                    GioHangChiTiets = a,
                    TongTien = tong,
                    listDiaChi = _diaChiNhanHangService.GetAll().Where(c => c.IdKhachHang == accnew[0].Id && c.Is_detele == true).Select(s => new SelectListItem
                    {
                        Value = s.Id.ToString(),
                        Text = s.DiaChi
                    }).ToList(),
                    listPhuongThucs = _phuongThucThanhToanService.GetAll().Select(s => new SelectListItem
                    {
                        Value = s.Id.ToString(),
                        Text = s.TenPhuongThuc
                    }).ToList(),

                };

                return View(view2);
            }
            else
            {
                return RedirectToAction("login", "Home");

            }
        }
        [HttpGet("/CheckOut/chonDiaChi")]
        public async Task<JsonResult> chonDiaChi(Guid idDiaChiKD, float tienhang, float tiengiam, float tongtien)
        {
            float tong = 0;
            var accnew = SessionServices.KhachHangSS(HttpContext.Session, "ACC");
            if (accnew.Count != 0)
            {
                var luuGio = SessionBan.IdGio(HttpContext.Session, "LuoGio");
                if (luuGio.Count == 0)
                {
                    return Json(0, new System.Text.Json.JsonSerializerOptions());
                }
                var gh = _GioHang.GetAll().FirstOrDefault(c => c.IdKhachHang == accnew[0].Id);
                IEnumerable<GioHangChiTiet> ghct = _GioHangjoiin.GetAll().Where(c => c.IdGioHang == gh.Id && luuGio.Contains(c.Id));
                var diaChi = _diaChiNhanHangService.GetAll().FirstOrDefault(c => c.Id == idDiaChiKD);
                foreach (var x in ghct)
                {
                    tong += float.Parse(x.SanPhamChiTiet.SanPham.GiaNiemYet.ToString()) * (x.SoLuong);
                }

                int dem = 0;
                var ghct2 = _GioHangChiTiet.GetAll().Where(c => luuGio.Contains(c.Id));
                foreach (var a in ghct)
                {
                    dem += a.SoLuong;
                }
                Shipping shipping = new Shipping()
                {
                    totaloder = tienhang + (diaChi.TienShip.Value * dem) - tiengiam,
                    TienShip = diaChi.TienShip.Value * dem,
                    tienGiam = tiengiam,
                    DiaChichiTiet = diaChi.name,
                };
                //shipping.data.totaloder = shipping.data.total + int.Parse(tong.ToString());
                return Json(shipping, new System.Text.Json.JsonSerializerOptions());
            }
            return Json(0, new System.Text.Json.JsonSerializerOptions());
        }
        public IActionResult SauThanhToan(int id)
        {
            var b = _HoaDonService.GetById(id);
            var a = _HoaDonChiTiet.GetAll().Where(c => c.IdHoaDon == id).ToList();
            var c = _giamGiaChiTietService.GetAll().Where(c => c.IdHoaDon == id).ToList();
            var view = new ThieuxkView()
            {
                HoaDon = b,
                hoaDonChiTiets = a,
                GiamGiaChiTiets = c
            };
            return View(view);
        }
        public IActionResult SuDunggiamGia(Guid IdGiamGia, float tienhanga, string DiachiNhanChiTiet, string name, string Sodienthoai, string Email, string addDiaChi, Guid IdDiaChi, Guid idphuongthuc, string ghiChu, float tienshipa, float tongtien)
        {
            HttpResponseMessage responseProvin = _httpClient.GetAsync("https://online-gateway.ghn.vn/shiip/public-api/master-data/province").Result;
            Provin lstprovin = new Provin();
            if (responseProvin.IsSuccessStatusCode)
            {
                string jsonData2 = responseProvin.Content.ReadAsStringAsync().Result;
                lstprovin = JsonConvert.DeserializeObject<Provin>(jsonData2);
                ViewBag.Provin = new SelectList(lstprovin.data, "ProvinceID", "ProvinceName");
            }
            float tong = 0;
            var accnew = SessionServices.KhachHangSS(HttpContext.Session, "ACC");
            if (accnew.Count != 0 && addDiaChi != null)
            {
                var luuGio = SessionBan.IdGio(HttpContext.Session, "LuoGio");
                if (luuGio.Count == 0)
                {
                    var message = "Giỏ hàng đang không được tích hãy thêm sản phẩm của bạn để tiến hàng đặt hàng";
                    TempData["TB4"] = message;
                    return RedirectToAction("GioHang", new { message });
                }
                float tiensaugiam;
                var giamgia1 = _giamGiaService.GetById(IdGiamGia);
                if (giamgia1 == null || giamgia1.NgayBatDau > DateTime.Now || giamgia1.NgayKetThuc < DateTime.Now)
                {
                    var message = $"Giảm giá {giamgia1.MaGiam} hiện không thể sửa dụng";
                    TempData["TB2"] = message;
                    return RedirectToAction("ThuTucThanhToan", "BanHang", new { message });
                }
                if (giamgia1.SoLuong < 1)
                {
                    var message = $"Giảm giá {giamgia1.MaGiam} hiện đã hết";
                    TempData["TB2"] = message;
                    return RedirectToAction("ThuTucThanhToan", "BanHang", new { message });
                }
                if (giamgia1.LoaiGiamGia == false)
                {
                    if (giamgia1.DieuKienGiam < tienhanga)
                    {
                        tiensaugiam = tienhanga - giamgia1.SoTienGiam;
                    }
                    else
                    {
                        {
                            var message = "Tiền đơn hàng chưa đủ điều kiện để sử dụng mã giảm giá này";
                            TempData["TB2"] = message;
                            return RedirectToAction("ThuTucThanhToan", "BanHang", new { message });
                        }
                    }
                }
                else
                {
                    if (giamgia1.DieuKienGiam < tienhanga)
                    {
                        var tientru = (tienhanga * giamgia1.PhanTramGiam / 100);
                        if (tientru >= giamgia1.SoTienGiamToiDa)
                        {
                            tientru = giamgia1.SoTienGiamToiDa;
                        }
                        tiensaugiam = tienhanga - tientru;
                    }
                    else
                    {
                        {
                            var message = "Tiền đơn hàng chưa đủ điều kiện để sử dụng mã giảm giá này";
                            TempData["TB2"] = message;
                            return RedirectToAction("ThuTucThanhToan", "BanHang", new { message });
                        }
                    }
                }

                var gg = _giamGiaService.GetById(IdGiamGia);
                // Đọc dữ liệu từ Session xem trong Cart nó có cái gì chưa?
                var giamgianew = SessionBan.GiamGiaSS(HttpContext.Session, "GiamGia");
                if (giamgianew.Count == 0)
                {
                    giamgianew.Add(gg);
                    SessionBan.SetObjToJson(HttpContext.Session, "GiamGia", giamgianew);
                }
                else if (giamgianew.Count != 0)
                {
                    giamgianew.Clear();
                    giamgianew.Add(gg);
                    SessionBan.SetObjToJson(HttpContext.Session, "GiamGia", giamgianew);
                }
                float tiengiam = (tienhanga + tienshipa) - (tiensaugiam + tienshipa);
                var gh = _GioHang.GetAll().FirstOrDefault(c => c.IdKhachHang == accnew[0].Id);
                IEnumerable<GioHangChiTiet> ghct = _GioHangjoiin.GetAll().Where(c => c.IdGioHang == gh.Id && luuGio.Contains(c.Id));
                if (ghct.Count() == 0)
                {
                    var message = "Giỏ hàng đang trống hãy thêm sản phẩm của bạn để tiến hàng đặt hàng";
                    TempData["TB4"] = message;
                    return RedirectToAction("GioHang", new { message });
                }
                foreach (var x in ghct)
                {
                    tong += float.Parse(x.SanPhamChiTiet.SanPham.GiaNiemYet.ToString()) * (x.SoLuong);
                }
                var a = _GioHangjoiin.GetAll().Where(c => c.IdGioHang == gh.Id);
                var nguoidung = _khachHangService.GetAll().FirstOrDefault(c => c.Id == accnew[0].Id);
                var diachinhanhang = _diaChiNhanHangService.GetAll().Where(c => c.IdKhachHang == accnew[0].Id).FirstOrDefault(c => c.TrangThai == true && c.Is_detele == true);
                var giamgia = _giamGiaService.GetAll().Where(c => c.TrangThai == true && c.Is_detele == true && c.NgayBatDau <= DateTime.Now && c.NgayKetThuc >= DateTime.Now).ToList();

                var KhuyenMaiSp = _KKhuyenMaiSanPhamService.GetAll().Where(c => c.KhuyenMai.Mua1tang1 == true && c.KhuyenMai.NgayBatDau <= DateTime.Now && c.KhuyenMai.NgayKetThuc >= DateTime.Now && c.KhuyenMai.Is_Detele == true).ToList();
                var g = new List<Guid>();
                foreach (var item in KhuyenMaiSp)
                {
                    // Kiểm tra xem Mau.Id đã xuất hiện trong danh sách chưa
                    if (!g.Contains((Guid)item.IdSanPham))
                    {
                        g.Add((Guid)item.IdSanPham);
                    }
                }
                var view2 = new GioHangView()
                {
                    check11 = g,
                    IdMaGiam = IdGiamGia,
                    tienshipb = tienshipa,
                    tiengiamb = tiengiam,
                    tenmagiam = giamgia1.MaGiam,
                    tienhanga = tienhanga,
                    TienCuoiCungb = tiensaugiam + tienshipa,
                    name = name,
                    ghiChu = ghiChu,
                    Email = Email,
                    Sodienthoai = Sodienthoai,
                    addDiaChi = addDiaChi,
                    DiachiNhanChiTiet = DiachiNhanChiTiet,
                    IdDiaChi = IdDiaChi,
                    idphuongthuc = idphuongthuc,
                    GiamGias = giamgia,
                    DiaChiNhanHang = diachinhanhang,
                    KhachHang = nguoidung,
                    GioHangChiTiets = a,
                    TongTien = tong,
                    listDiaChi = _diaChiNhanHangService.GetAll().Where(c => c.IdKhachHang == accnew[0].Id && c.Is_detele == true).Select(s => new SelectListItem
                    {
                        Value = s.Id.ToString(),
                        Text = s.DiaChi
                    }).ToList(),
                    listPhuongThucs = _phuongThucThanhToanService.GetAll().Select(s => new SelectListItem
                    {
                        Value = s.Id.ToString(),
                        Text = s.TenPhuongThuc
                    }).ToList(),
                };

                return View("ThuTucThanhToan", view2);
            }
            else if (accnew.Count != 0 && addDiaChi == null)
            {
                float tiensaugiam;
                var giamgia1 = _giamGiaService.GetById(IdGiamGia);
                if (giamgia1 == null || giamgia1.NgayBatDau > DateTime.Now || giamgia1.NgayKetThuc < DateTime.Now)
                {
                    var message = $"Giảm giá {giamgia1.MaGiam} hiện không thể sửa dụng";
                    TempData["TB2"] = message;
                    return RedirectToAction("ThuTucThanhToan", "BanHang", new { message });
                }
                if (giamgia1.LoaiGiamGia == false)
                {
                    if (giamgia1.DieuKienGiam < tienhanga)
                    {
                        tiensaugiam = tienhanga - giamgia1.SoTienGiam;
                    }
                    else
                    {
                        {
                            var message = "Tiền đơn hàng chưa đủ điều kiện để sử dụng mã giảm giá này";
                            TempData["TB2"] = message;
                            return RedirectToAction("ThuTucThanhToan", "BanHang", new { message });
                        }
                    }
                }
                else
                {
                    if (giamgia1.DieuKienGiam < tienhanga)
                    {
                        var tientru = (tienhanga * giamgia1.PhanTramGiam / 100);
                        if (tientru >= giamgia1.SoTienGiamToiDa)
                        {
                            tientru = giamgia1.SoTienGiamToiDa;
                        }
                        tiensaugiam = tienhanga - tientru;
                    }
                    else
                    {
                        {
                            var message = "Tiền đơn hàng chưa đủ điều kiện để sử dụng mã giảm giá này";
                            TempData["TB2"] = message;
                            return RedirectToAction("ThuTucThanhToan", "BanHang", new { message });
                        }
                    }
                }
                var luuGio = SessionBan.IdGio(HttpContext.Session, "LuoGio");
                if (luuGio.Count == 0)
                {
                    var message = "Giỏ hàng đang không được tích hãy thêm sản phẩm của bạn để tiến hàng đặt hàng";
                    TempData["TB4"] = message;
                    return RedirectToAction("GioHang", new { message });
                }

                var gg = _giamGiaService.GetById(IdGiamGia);
                // Đọc dữ liệu từ Session xem trong Cart nó có cái gì chưa?
                var giamgianew = SessionBan.GiamGiaSS(HttpContext.Session, "GiamGia");
                if (giamgianew.Count == 0)
                {
                    giamgianew.Add(gg);
                    SessionBan.SetObjToJson(HttpContext.Session, "GiamGia", giamgianew);
                }
                else if (giamgianew.Count != 0)
                {
                    giamgianew.Clear();
                    giamgianew.Add(gg);
                    SessionBan.SetObjToJson(HttpContext.Session, "GiamGia", giamgianew);
                }
                float tiengiam = (tienhanga + tienshipa) - (tiensaugiam + tienshipa);
                var gh = _GioHang.GetAll().FirstOrDefault(c => c.IdKhachHang == accnew[0].Id);
                IEnumerable<GioHangChiTiet> ghct = _GioHangjoiin.GetAll().Where(c => c.IdGioHang == gh.Id);
                if (ghct.Count() == 0)
                {
                    var message = "Giỏ hàng đang trống hãy thêm sản phẩm của bạn để tiến hàng đặt hàng";
                    TempData["TB4"] = message;
                    return RedirectToAction("GioHang", new { message });
                }
                foreach (var x in ghct)
                {
                    tong += float.Parse(x.SanPhamChiTiet.SanPham.GiaNiemYet.ToString()) * (x.SoLuong);
                }
                var a = _GioHangjoiin.GetAll().Where(c => c.IdGioHang == gh.Id && luuGio.Contains(c.Id));
                var nguoidung = _khachHangService.GetAll().FirstOrDefault(c => c.Id == accnew[0].Id);
                var diachinhanhang = _diaChiNhanHangService.GetAll().Where(c => c.IdKhachHang == accnew[0].Id).FirstOrDefault(c => c.TrangThai == true && c.Is_detele == true);
                var giamgia = _giamGiaService.GetAll().Where(c => c.TrangThai == true && c.Is_detele == true && c.NgayBatDau <= DateTime.Now && c.NgayKetThuc >= DateTime.Now).ToList();
                var KhuyenMaiSp = _KKhuyenMaiSanPhamService.GetAll().Where(c => c.KhuyenMai.Mua1tang1 == true && c.KhuyenMai.NgayBatDau <= DateTime.Now && c.KhuyenMai.NgayKetThuc >= DateTime.Now && c.KhuyenMai.Is_Detele == true).ToList();
                var g = new List<Guid>();
                foreach (var item in KhuyenMaiSp)
                {
                    // Kiểm tra xem Mau.Id đã xuất hiện trong danh sách chưa
                    if (!g.Contains((Guid)item.IdSanPham))
                    {
                        g.Add((Guid)item.IdSanPham);
                    }
                }
                var view2 = new GioHangView()
                {
                    check11 = g,
                    tienshipb = tienshipa,
                    tiengiamb = tiengiam,
                    tenmagiam = giamgia1.MaGiam,
                    tienhanga = tienhanga,
                    TienCuoiCungb = tiensaugiam + tienshipa,
                    name = name,
                    ghiChu = ghiChu,
                    Email = Email,
                    Sodienthoai = Sodienthoai,
                    addDiaChi = addDiaChi,
                    DiachiNhanChiTiet = DiachiNhanChiTiet,
                    IdDiaChi = IdDiaChi,
                    idphuongthuc = idphuongthuc,
                    GiamGias = giamgia,
                    DiaChiNhanHang = diachinhanhang,
                    KhachHang = nguoidung,
                    GioHangChiTiets = a,
                    TongTien = tong,
                    listDiaChi = _diaChiNhanHangService.GetAll().Where(c => c.IdKhachHang == accnew[0].Id && c.Is_detele == true).Select(s => new SelectListItem
                    {
                        Value = s.Id.ToString(),
                        Text = s.DiaChi
                    }).ToList(),
                    listPhuongThucs = _phuongThucThanhToanService.GetAll().Select(s => new SelectListItem
                    {
                        Value = s.Id.ToString(),
                        Text = s.TenPhuongThuc
                    }).ToList(),
                };

                return View("ThuTucThanhToan", view2);
            }
            else
            {
                return RedirectToAction("login", "Home");

            }
        }
        #endregion

        #region Hoa Don
        public IActionResult HoaDon()
        {
            var accnew = SessionServices.KhachHangSS(HttpContext.Session, "ACC");
            if (accnew.Count != 0)
            {
                var a = _HoaDonService.GetAll().Where(c => c.IdKhachHang == accnew[0].Id);
                return View(a);
            }
            else
            {
                return RedirectToAction("login", "Home");
            }

        }
        public IActionResult HoaDonChiTiet(int id)
        {
            var accnew = SessionServices.KhachHangSS(HttpContext.Session, "ACC");
            if (accnew.Count != 0)
            {
                var b = _HoaDonService.GetById(id);

                if (b.IdKhachHang != accnew[0].Id)
                {
                    var message2 = "Hóa đơn này không tồn tại hoặc không thuộc tài khoản của bạn";
                    TempData["TB4"] = message2;
                    return RedirectToAction("HoaDon", new { message2 });
                }
                var a = _HoaDonChiTiet.GetAll().Where(c => c.IdHoaDon == id).ToList();
                var c = _giamGiaChiTietService.GetAll().Where(c => c.IdHoaDon == id).ToList();
                var d = _LichSuHoaDonService.GetAll().Where(c => c.IdHoaDonn == id && c.TrangThai == true && c.Is_detele == true).OrderByDescending(c => c.ThoiGianlam).ToList();

                var view = new ThieuxkView()
                {
                    HoaDon = b,
                    hoaDonChiTiets = a,
                    GiamGiaChiTiets = c,
                    LichSuDonHangs = d,
                };
                return View(view);
            }
            else
            {
                return RedirectToAction("login", "Home");
            }

        }
        public IActionResult LocHD(string MaHD)
        {
            var accnew = SessionServices.KhachHangSS(HttpContext.Session, "ACC");
            if (accnew.Count != 0)
            {

                if (MaHD == null)
                {
                    var message2 = "Hãy điền mã hóa đơn muốn tìm";
                    TempData["TB4"] = message2;
                    return RedirectToAction("HoaDon", new { message2 });
                }
                var a = _HoaDonService.GetAll().Where(c => c.IdKhachHang == accnew[0].Id && c.MaHoaDon.ToLower().Contains(MaHD.ToLower()));
                return View("HoaDon", a);
            }
            else
            {
                return RedirectToAction("login", "Home");
            }
        }
        public IActionResult TimKiemNgay(DateTime NgayDau, DateTime NgayCuoi)
        {
            var accnew = SessionServices.KhachHangSS(HttpContext.Session, "ACC");
            if (accnew.Count != 0)
            {
                if (NgayDau == NgayCuoi)
                {
                    var message = "hãy chọn ngày bắt đầu và chọn khoản kết thúc của bạn !";
                    TempData["TB4"] = message;
                    return RedirectToAction("HoaDon", new { message });
                }
                else if (NgayDau > NgayCuoi)
                {
                    var message = "Ngày bắt đầu phải nhỏ hơn ngày kết thúc !";
                    TempData["TB4"] = message;
                    return RedirectToAction("HoaDon", new { message });
                }
                else
                {
                    var hd = _HoaDonService.GetAll().Where(c => c.NgayDat > NgayDau && c.NgayDat < NgayCuoi&& c.IdKhachHang == accnew[0].Id).ToList();
                    return View("HoaDon", hd);
                }
            }
            else
            {
                return RedirectToAction("login", "Home");
            }

        }
        public IActionResult huydonKH(int id, string LyDo)
        {
            var accnew = SessionServices.KhachHangSS(HttpContext.Session, "ACC");
            if (accnew.Count != 0)
            {
                if (LyDo == null)
                {
                    var message = "hãy điền lý do của bạn";
                    TempData["TB4"] = message;
                    return RedirectToAction("HoaDonChiTiet", new { id = id, message });
                }
                var hd = _HoaDonService.GetById(id);
                if (hd.NgayGiao == null)
                {
                    hd.TrangThai = "Đơn hàng bị hủy";
                    ;
                    if (_HoaDonService.Sua(hd) == true)
                    {
                        var ls = new LichSuDonHang()
                        {
                            TrangThai = true,
                            NguoiThucHien = $"Khách hàng{accnew[0].TenDangNhap}",
                            ThoiGianlam = DateTime.Now,
                            ThaoTac = $"Hủy Đơn hàng {hd.MaHoaDon}",
                            IdHoaDonn = id
                        };
                        _LichSuHoaDonService.Them(ls);
                        var hdct = _HoaDonChiTiet.GetAll().Where(c => c.IdHoaDon == id && c.TrangThai == true);
                        foreach (var a1 in hdct)
                        {
                            var spct = _SanPhamChiTiet.GetById(a1.IdSanPhamChiTiet);
                            spct.SoLuong += a1.SoLuong;
                            _SanPhamChiTiet.Sua(spct);
                        }
                    }
                }
                else
                {
                    var message = "Đơn hàng không thể hủy vì đã và đang được giao";
                    TempData["TB4"] = message;
                    return RedirectToAction("HoaDonChiTiet", new { id = id, message });
                }
                var b = _HoaDonService.GetById(id);
                var a = _HoaDonChiTiet.GetAll().Where(c => c.IdHoaDon == id).ToList();
                return RedirectToAction("HoaDonChiTiet", new { id = id });
            }
            else
            {
                return RedirectToAction("login", "Home");
            }
        }
        #endregion
    }

}