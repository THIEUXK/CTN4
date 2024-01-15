using ClosedXML.Excel;
using CTN4_Data.DB_Context;
using CTN4_Data.Models;
using CTN4_Data.Models.DB_CTN4;
using CTN4_Serv.Service;
using CTN4_Serv.Service.IService;
using CTN4_Serv.Service.Service;
using CTN4_Serv.ServiceJoin;
using CTN4_Serv.ViewModel;
using CTN4_Serv.ViewModel.banhangview;
using CTN4_View.Areas.Admin.Controllers.QuanLyHoaDonThieuxk.viewMode;
using CTN4_View.Areas.Admin.Viewmodel;
using CTN4_View.Controllers.Shop.ViewModelThieuxk;
using CTN4_View_Admin.Controllers.Shop;
using DocumentFormat.OpenXml.Office2010.Excel;
using DocumentFormat.OpenXml.Spreadsheet;
using DocumentFormat.OpenXml.Wordprocessing;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Diagnostics.Tracing.Parsers.IIS_Trace;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Newtonsoft.Json;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml.Linq;
using X.PagedList;

namespace CTN4_View.Areas.Admin.Controllers.QuanLyHoaDonThieuxk
{
    [Area("admin")]
    public class QuanLyHoaDonController : Controller
    {
        #region ctor
        private readonly HttpClient _httpClient;
        public IHoaDonService _hoaDonService;
        public IHoaDonChiTietService _hoaDonChiTietService;
        public ILichSuHoaDonService _LichSuHoaDonService;
        public IChatLieuService _chatLieuService;
        public INSXService _nsxService;
        public ISanPhamService _spService;
        public ISanPhamService _sanPhamService;
        public IMauService _mauService;
        public ISizeService _sizeService;
        public SanPhamCuaHangService _sanPhamCuaHangService;
        public DB_CTN4_ok _db;
        public IAnhService _anhService;
        public ISanPhamChiTietService _sanPhamChiTietService;
        public IKhuyenMaiSanPhamService _KhuyenMaiSanPhams;
        public IGiamGiaService _giamGiaService;
        public IMauService _mauSacService;
        public DB_CTN4_ok _CTN4_Ok;
        public IGiamGiaChiTietService _GiamGiaChiTietService;
        public IDanhGiaSanPhamService _danhGiaSanPhamService;

        public QuanLyHoaDonController(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient?.DefaultRequestHeaders.Add("token", "fa31ddca-73b0-11ee-b394-8ac29577e80e");
            _httpClient?.DefaultRequestHeaders.Add("shop_id", "4189141");
            _hoaDonChiTietService = new HoaDonChiTietService();
            _hoaDonService = new HoaDonService();
            _LichSuHoaDonService = new LichSuHoaDonService();
            _sanPhamChiTietService = new SanPhamChiTietService();
            _chatLieuService = new ChatLieuService();
            _mauService = new MauService();
            _nsxService = new NSXService();
            _spService = new SanPhamService();
            _sizeService = new SizeService();
            _sanPhamCuaHangService = new SanPhamCuaHangService();
            _db = new DB_CTN4_ok();
            _anhService = new AnhService();
            _sanPhamService = new SanPhamService();
            _KhuyenMaiSanPhams = new KhuyenMaiSanPhamService();
            _giamGiaService = new GiamGiaService();
            _mauSacService = new MauService();
            _CTN4_Ok = new DB_CTN4_ok();
            _GiamGiaChiTietService = new GiamGiaChiTietService();
            _danhGiaSanPhamService = new DanhGiaSanPhamService();
        }
        #endregion
        public IActionResult Index()
        {
            var nvnew = SessionServices.NhanVienSS(HttpContext.Session, "ACA");
            if (nvnew.Count() != 0)
            {
                var hd = _hoaDonService.GetAll().Where(c => c.Is_detele == true).ToList();
                var view = new ThieuxkViewAdmin()
                {
                    hoaDons = hd,
                };
                return View(view);
            }
            else
            {
                return RedirectToAction("DangNhap", "Home");
            }
        }
        public IActionResult XemChiTiet(int id)
        {
            var nvnew = SessionServices.NhanVienSS(HttpContext.Session, "ACA");
            if (nvnew.Count() != 0)
            {
                var sanphamctnew = SessionBan.SanPhamTamSS(HttpContext.Session, "SanPhamTamSS");
                if (sanphamctnew.Count == 0)
                {
                    var spt = new SanPhamTam()
                    {
                        idHD = id
                    };
                    sanphamctnew.Add(spt);
                    SessionBan.SetObjToJson(HttpContext.Session, "SanPhamTamSS", sanphamctnew);
                }
                else
                {
                    sanphamctnew.RemoveAt(0);
                    var spt = new SanPhamTam()
                    {
                        idHD = id
                    };
                    sanphamctnew.Add(spt);
                    SessionBan.SetObjToJson(HttpContext.Session, "SanPhamTamSS", sanphamctnew);
                }
                var KhuyenMaiSp = _KhuyenMaiSanPhams.GetAll().Where(c => c.KhuyenMai.Mua1tang1 == true && c.KhuyenMai.NgayBatDau <= DateTime.Now && c.KhuyenMai.NgayKetThuc >= DateTime.Now && c.KhuyenMai.Is_Detele == true).ToList();
                var g = new List<Guid>();
                foreach (var item in KhuyenMaiSp)
                {
                    // Kiểm tra xem Mau.Id đã xuất hiện trong danh sách chưa
                    if (!g.Contains((Guid)item.IdSanPham))
                    {
                        g.Add((Guid)item.IdSanPham);
                    }
                }
                var hd = _hoaDonService.GetById(id);
                if (hd.TrangThai == "Đang Tạo")
                {
                    return RedirectToAction("TaoHoaDon", new { id = id });
                }
                var hdct = _hoaDonChiTietService.GetAll().Where(c => c.IdHoaDon == id).ToList();
                var lshd = _LichSuHoaDonService.GetAll().Where(c => c.IdHoaDonn == id).ToList();
                int tongSoLuongSP = 0;
                float tongTienSP = 0;
                foreach (var a in hdct)
                {
                    tongSoLuongSP += a.SoLuong;
                }
                //foreach (var a in hdct)
                //{
                //    if (g.Contains(a.SanPhamChiTiet.SanPham.Id))
                //    {
                //        tongTienSP += a.GiaTien * a.SoLuong/2;
                //    }
                //    else
                //    {
                //        tongTienSP += a.GiaTien * a.SoLuong / 2;
                //    }

                //}
                var c = _GiamGiaChiTietService.GetAll().Where(c => c.IdHoaDon == id).ToList();

                var view = new ThieuxkViewAdmin()
                {
                    check11 = g,
                    GiamGiaChiTiets = c,
                    HoaDon = hd,
                    hoaDonChiTiets = hdct,
                    soLuongTong = tongSoLuongSP,
                    TongTienHang = hd.TienHang,
                    LichSuHoaDon = lshd.OrderByDescending(c => c.ThoiGianlam).ToList()
                };
                return View(view);
            }
            else
            {
                return RedirectToAction("DangNhap", "Home");
            }
        }
        #region quan ly hoa don
        public IActionResult SuaDiaChiVaThongTin(int id, string ten, string sdt, string email)
        {
            var nvnew = SessionServices.NhanVienSS(HttpContext.Session, "ACA");
            if (nvnew.Count() != 0)
            {
                var hd = _hoaDonService.GetById(id);
                if (hd.TrangThai == "Đơn hàng bị hủy")
                {
                    var message = "Đơn hàng đã bị hủy";
                    TempData["TB1"] = message;
                    return RedirectToAction("XemChiTiet", new { id = id, message });
                }
                if (hd.TrangThai == "Giao hàng thành công")
                {
                    var message = "Đơn hàng đã giao hàng thành công";
                    TempData["TB1"] = message;
                    return RedirectToAction("XemChiTiet", new { id = id, message });
                }
                if (hd.TrangThai == "Đưa hàng thành công")
                {
                    var message = "Đơn hàng đã đưa hàng thành công";
                    TempData["TB1"] = message;
                    return RedirectToAction("XemChiTiet", new { id = id, message });
                }
                if (ten == null || (sdt == null && email == null))
                {
                    {
                        var message = "hãy nhớ điền số điện thoại hoặc Email của bạn còn tên là bắt buộc";
                        TempData["TB1"] = message;
                        return RedirectToAction("XemChiTiet", new { id = id, message });
                    }
                }
                if (sdt != null)
                {
                    if (sdt.Length < 10 || sdt.Length > 13)
                    {
                        {
                            var message = "Số điện thoại phải từ 10 số trở lên";
                            TempData["TB1"] = message;
                            return RedirectToAction("XemChiTiet", new { id = id, message });
                        }
                    }
                }
                if (email != null)
                {
                    if (!IsValidGmail(email))
                    {
                        var message = "Email không hợp lệ";
                        TempData["TB1"] = message;
                        return RedirectToAction("XemChiTiet", new { id = id, message });
                    }
                }
                hd.TenKhachHang = ten;
                hd.SDTNguoiNhan = sdt;
                hd.Email = email;
                if (_hoaDonService.Sua(hd) == true)
                {
                    var li = new LichSuDonHang()
                    {
                        GhiChu = null,
                        ThaoTac = $"Sửa thông tin khách hàng đơn hàng {hd.MaHoaDon} thành tên:{ten},sđt:{sdt},email:{email} ",
                        IdHoaDonn = id,
                        ThoiGianlam = DateTime.Now,
                        NguoiThucHien = nvnew[0].TenDangNhap,
                        TrangThai = true,
                        Is_detele = true
                    };
                    _LichSuHoaDonService.Them(li);
                }

                return RedirectToAction("XemChiTiet", new { id = id });
            }
            else
            {
                return RedirectToAction("DangNhap", "Home");
            }
        }
        public IActionResult HoantacXacNhanNhanHang(int id, string LyDo)
        {
            var nvnew = SessionServices.NhanVienSS(HttpContext.Session, "ACA");
            if (nvnew.Count() != 0)
            {
                if (LyDo == null)
                {
                    var message = "hãy điền lý do hoàn tác";
                    TempData["TB1"] = message;
                    return RedirectToAction("XemChiTiet", new { id = id, message });
                }
                var hd = _hoaDonService.GetById(id);
                if (hd.TrangThai == "Đơn hàng bị hủy")
                {
                    var message = "Đơn hàng đã bị hủy";
                    TempData["TB1"] = message;
                    return RedirectToAction("XemChiTiet", new { id = id, message });
                }
                if (hd.TrangThai == "Giao hàng thành công")
                {
                    var message = "Đơn hàng đã giao hàng thành công";
                    TempData["TB1"] = message;
                    return RedirectToAction("XemChiTiet", new { id = id, message });
                }
                if (hd.TrangThai == "Đưa hàng thành công")
                {
                    var message = "Đơn hàng đã đưa hàng thành công";
                    TempData["TB1"] = message;
                    return RedirectToAction("XemChiTiet", new { id = id, message });
                }
                if (hd.TrangThaiThanhToan == true)
                {
                    var message = "Đơn hàng hiện đã được thanh toán";
                    TempData["TB1"] = message;
                    return RedirectToAction("XemChiTiet", new { id = id, message });
                }
                if (hd.NgayGiao != null)
                {
                    var message = "Đơn hàng đang được giao";
                    TempData["TB1"] = message;
                    return RedirectToAction("XemChiTiet", new { id = id, message });
                }
                if (hd.NgayNhan != null)
                {
                    var message = "Đơn hàng hiện đã được đưa cho khách";
                    TempData["TB1"] = message;
                    return RedirectToAction("XemChiTiet", new { id = id, message });
                }

                hd.TrangThai = "Đang chờ xử lí";
                if (_hoaDonService.Sua(hd) == true)
                {
                    var li = new LichSuDonHang()
                    {
                        GhiChu = LyDo,
                        ThaoTac = $"Hoàn tác xác nhận đơn hàng {hd.MaHoaDon} ",
                        IdHoaDonn = id,
                        ThoiGianlam = DateTime.Now,
                        NguoiThucHien = nvnew[0].TenDangNhap,
                        TrangThai = true,
                        Is_detele = false
                    };
                    _LichSuHoaDonService.Them(li);
                }

                return RedirectToAction("XemChiTiet", new { id = id });
            }
            else
            {
                return RedirectToAction("DangNhap", "Home");
            }
        }
        public IActionResult CapNhat(int id)
        {
            var nvnew = SessionServices.NhanVienSS(HttpContext.Session, "ACA");
            if (nvnew.Count() != 0)
            {
                var hd = _hoaDonService.GetById(id);
                if (hd.TrangThai == "Đơn hàng bị hủy")
                {
                    var message = "Đơn hàng đã bị hủy";
                    TempData["TB1"] = message;
                    return RedirectToAction("XemChiTiet", new { id = id, message });
                }
                if (hd.TrangThai == "Giao hàng thành công")
                {
                    var message = "Đơn hàng đã giao hàng thành công";
                    TempData["TB1"] = message;
                    return RedirectToAction("XemChiTiet", new { id = id, message });
                }
                if (hd.TrangThai == "Đưa hàng thành công")
                {
                    var message = "Đơn hàng đã đưa hàng thành công";
                    TempData["TB1"] = message;
                    return RedirectToAction("XemChiTiet", new { id = id, message });
                }
                var hdct = _hoaDonChiTietService.GetAll().Where(c => c.IdHoaDon == id && c.Is_detele == true && c.TrangThai == true);
                float tong = 0;
                foreach (var cd in hdct)
                {
                    tong += cd.GiaTien * cd.SoLuong;
                }
                hd.TienHang = tong;
                hd.TongTien = tong + hd.TienShip - hd.TienGiam;
                if (_hoaDonService.Sua(hd) == true)
                {
                    var li = new LichSuDonHang()
                    {
                        GhiChu = null,
                        ThaoTac = $"Cập nhật đơn hàng {hd.MaHoaDon} ",
                        IdHoaDonn = id,
                        ThoiGianlam = DateTime.Now,
                        NguoiThucHien = nvnew[0].TenDangNhap,
                        TrangThai = true,
                        Is_detele = false
                    };
                    _LichSuHoaDonService.Them(li);
                }
                return RedirectToAction("XemChiTiet", new { id = id });
            }
            else
            {
                return RedirectToAction("DangNhap", "Home");
            }
        }
        public IActionResult XacNhanNhanHang2(int id)
        {
            var nvnew = SessionServices.NhanVienSS(HttpContext.Session, "ACA");
            if (nvnew.Count() != 0)
            {
                var hd = _hoaDonService.GetById(id);
                if (hd.TrangThai == "Đơn hàng bị hủy")
                {
                    var message = "Đơn hàng đã bị hủy";
                    TempData["TB1"] = message;
                    return RedirectToAction("XemChiTiet", new { id = id, message });
                }
                if (hd.TrangThai == "Giao hàng thành công")
                {
                    var message = "Đơn hàng đã giao hàng thành công";
                    TempData["TB1"] = message;
                    return RedirectToAction("XemChiTiet", new { id = id, message });
                }
                if (hd.TrangThai == "Đưa hàng thành công")
                {
                    var message = "Đơn hàng đã đưa hàng thành công";
                    TempData["TB1"] = message;
                    return RedirectToAction("XemChiTiet", new { id = id, message });
                }
                hd.TrangThai = "Đang chuẩn bị hàng";
                if (_hoaDonService.Sua(hd) == true)
                {
                    var li = new LichSuDonHang()
                    {
                        GhiChu = null,
                        ThaoTac = $"Xác nhận đơn hàng {hd.MaHoaDon} ",
                        IdHoaDonn = id,
                        ThoiGianlam = DateTime.Now,
                        NguoiThucHien = nvnew[0].TenDangNhap,
                        TrangThai = true,
                        Is_detele = true
                    };
                    _LichSuHoaDonService.Them(li);
                }
                return RedirectToAction("XemChiTiet", new { id = id });
            }
            else
            {
                return RedirectToAction("DangNhap", "Home");
            }
        }
        public IActionResult HoantacXacNhanGiaoHang(int id, string LyDo)
        {
            var nvnew = SessionServices.NhanVienSS(HttpContext.Session, "ACA");
            if (nvnew.Count() != 0)
            {
                if (LyDo == null)
                {
                    var message = "hãy điền lý do hoàn tác";
                    TempData["TB1"] = message;
                    return RedirectToAction("XemChiTiet", new { id = id, message });
                }
                var hd = _hoaDonService.GetById(id);
                if (hd.TrangThai == "Đơn hàng bị hủy")
                {
                    var message = "Đơn hàng đã bị hủy";
                    TempData["TB1"] = message;
                    return RedirectToAction("XemChiTiet", new { id = id, message });
                }
                if (hd.TrangThai == "Giao hàng thành công")
                {
                    var message = "Đơn hàng đã giao hàng thành công";
                    TempData["TB1"] = message;
                    return RedirectToAction("XemChiTiet", new { id = id, message });
                }
                if (hd.TrangThai == "Đưa hàng thành công")
                {
                    var message = "Đơn hàng đã đưa hàng thành công";
                    TempData["TB1"] = message;
                    return RedirectToAction("XemChiTiet", new { id = id, message });
                }
                if (hd.TrangThai == "Hàng của bạn đang được giao")
                {
                    hd.TrangThai = "Đang chuẩn bị hàng";
                    hd.NgayGiao = null;
                    if (_hoaDonService.Sua(hd) == true)
                    {
                        var li = new LichSuDonHang()
                        {
                            GhiChu = LyDo,
                            ThaoTac = $"Hoàn tác xác nhận giao hàng đơn hàng {hd.MaHoaDon} ",
                            IdHoaDonn = id,
                            ThoiGianlam = DateTime.Now,
                            NguoiThucHien = nvnew[0].TenDangNhap,
                            TrangThai = true,
                            Is_detele = false
                        };
                        _LichSuHoaDonService.Them(li);
                    }
                }
                else
                {
                    var message = "Không thể hoàn tác vì đơn hàng không còn được giao!";
                    TempData["TB1"] = message;
                    return RedirectToAction("XemChiTiet", new { id = id, message });
                }

                return RedirectToAction("XemChiTiet", new { id = id });
            }
            else
            {
                return RedirectToAction("DangNhap", "Home");
            }
        }
        public IActionResult XacNhanGiaoHang(int id)
        {
            var nvnew = SessionServices.NhanVienSS(HttpContext.Session, "ACA");
            if (nvnew.Count() != 0)
            {
                var hd = _hoaDonService.GetById(id);
                if (hd.TrangThai == "Đơn hàng bị hủy")
                {
                    var message = "Đơn hàng đã bị hủy";
                    TempData["TB1"] = message;
                    return RedirectToAction("XemChiTiet", new { id = id, message });
                }
                if (hd.TrangThai == "Giao hàng thành công")
                {
                    var message = "Đơn hàng đã giao hàng thành công";
                    TempData["TB1"] = message;
                    return RedirectToAction("XemChiTiet", new { id = id, message });
                }
                if (hd.TrangThai == "Đưa hàng thành công")
                {
                    var message = "Đơn hàng đã đưa hàng thành công";
                    TempData["TB1"] = message;
                    return RedirectToAction("XemChiTiet", new { id = id, message });
                }
                var hdct = _hoaDonChiTietService.GetAll().Where(c => c.IdHoaDon == id).ToList();
                if (hdct.Count == 0)
                {
                    var message = "Đơn hàng không thể giao khi chưa có sản phẩm nào";
                    TempData["TB1"] = message;
                    return RedirectToAction("XemChiTiet", new { id = id, message });
                }
                if (hd.TrangThai == "Đang chuẩn bị hàng")
                {
                    hd.TrangThai = "Hàng của bạn đang được giao";
                    hd.NgayGiao = DateTime.Now;
                    if (_hoaDonService.Sua(hd) == true)
                    {
                        var li = new LichSuDonHang()
                        {
                            GhiChu = null,
                            ThaoTac = $"Xác nhận giao hàng đơn hàng {hd.MaHoaDon} ",
                            IdHoaDonn = id,
                            ThoiGianlam = DateTime.Now,
                            NguoiThucHien = nvnew[0].TenDangNhap,
                            TrangThai = true,
                            Is_detele = true
                        };
                        _LichSuHoaDonService.Them(li);
                    }
                }
                else
                {
                    var message = "Đơn hàng chưa được xác nhận !";
                    TempData["TB1"] = message;
                    return RedirectToAction("XemChiTiet", new { id = id, message });
                }

                return RedirectToAction("XemChiTiet", new { id = id });
            }
            else
            {
                return RedirectToAction("DangNhap", "Home");
            }
        }
        public IActionResult HoantacXacNhanThanhToan(int id, string LyDo)
        {
            var nvnew = SessionServices.NhanVienSS(HttpContext.Session, "ACA");
            if (nvnew.Count() != 0)
            {
                if (LyDo == null)
                {
                    var message = "hãy điền lý do hoàn tác";
                    TempData["TB1"] = message;
                    return RedirectToAction("XemChiTiet", new { id = id, message });
                }
                var hd = _hoaDonService.GetById(id);
                if (hd.TrangThai == "Đơn hàng bị hủy")
                {
                    var message = "Đơn hàng đã bị hủy";
                    TempData["TB1"] = message;
                    return RedirectToAction("XemChiTiet", new { id = id, message });
                }
                if (hd.TrangThai == "Giao hàng thành công")
                {
                    var message = "Đơn hàng đã giao hàng thành công";
                    TempData["TB1"] = message;
                    return RedirectToAction("XemChiTiet", new { id = id, message });
                }
                if (hd.TrangThai == "Đưa hàng thành công")
                {
                    var message = "Đơn hàng đã đưa hàng thành công";
                    TempData["TB1"] = message;
                    return RedirectToAction("XemChiTiet", new { id = id, message });
                }
                if (hd.TrangThai != "Giao hàng thành công"&& hd.TrangThai != "Đưa hàng thành công")
                {
                    hd.TrangThaiThanhToan = false;
                    if (_hoaDonService.Sua(hd) == true)
                    {
                        var li = new LichSuDonHang()
                        {
                            GhiChu = LyDo,
                            ThaoTac = $"Hoàn tác xác nhận thanh toán đơn hàng {hd.MaHoaDon} ",
                            IdHoaDonn = id,
                            ThoiGianlam = DateTime.Now,
                            NguoiThucHien = nvnew[0].TenDangNhap,
                            TrangThai = true,
                            Is_detele = false
                        };
                        _LichSuHoaDonService.Them(li);
                    }
                }
                else
                {
                    var message = "Đơn hàng đã hoàn thành không thể hoàn tác !";
                    TempData["TB3"] = message;
                    return RedirectToAction("XemChiTiet", new { id = id, message });
                }



                return RedirectToAction("XemChiTiet", new { id = id });
            }
            else
            {
                return RedirectToAction("DangNhap", "Home");
            }
        }
        public IActionResult HoanTacDua(int id, string LyDo)
        {
            var nvnew = SessionServices.NhanVienSS(HttpContext.Session, "ACA");
            if (nvnew.Count() != 0)
            {
                if (LyDo == null)
                {
                    var message = "hãy điền lý do hoàn tác";
                    TempData["TB1"] = message;
                    return RedirectToAction("XemChiTiet", new { id = id, message });
                }
                var hd = _hoaDonService.GetById(id);
                if (hd.TrangThai == "Đơn hàng bị hủy")
                {
                    var message = "Đơn hàng đã bị hủy";
                    TempData["TB1"] = message;
                    return RedirectToAction("XemChiTiet", new { id = id, message });
                }
                if (hd.TrangThai == "Đưa hàng thành công")
                {
                    hd.TrangThai = "Đang chuẩn bị hàng";
                    if (_hoaDonService.Sua(hd) == true)
                    {
                        var li = new LichSuDonHang()
                        {
                            GhiChu = LyDo,
                            ThaoTac = $"Hoàn tác xác nhận đưa hàng đơn hàng {hd.MaHoaDon} ",
                            IdHoaDonn = id,
                            ThoiGianlam = DateTime.Now,
                            NguoiThucHien = nvnew[0].TenDangNhap,
                            TrangThai = true,
                            Is_detele = false
                        };
                        _LichSuHoaDonService.Them(li);
                    }
                }
                else
                {
                    var message = "Đơn hàng đã hoàn thành không thể hoàn tác !";
                    TempData["TB3"] = message;
                    return RedirectToAction("XemChiTiet", new { id = id, message });
                }



                return RedirectToAction("XemChiTiet", new { id = id });
            }
            else
            {
                return RedirectToAction("DangNhap", "Home");
            }
        }
        public IActionResult HoanTacGiaoTC(int id, string LyDo)
        {
            var nvnew = SessionServices.NhanVienSS(HttpContext.Session, "ACA");
            if (nvnew.Count() != 0)
            {
                if (LyDo == null)
                {
                    var message = "hãy điền lý do hoàn tác";
                    TempData["TB1"] = message;
                    return RedirectToAction("XemChiTiet", new { id = id, message });
                }
                var hd = _hoaDonService.GetById(id);
                if (hd.TrangThai == "Đơn hàng bị hủy")
                {
                    var message = "Đơn hàng đã bị hủy";
                    TempData["TB1"] = message;
                    return RedirectToAction("XemChiTiet", new { id = id, message });
                }
                if (hd.TrangThai == "Giao hàng thành công")
                {
                    hd.TrangThai = "Hàng của bạn đang được giao";
                    if (_hoaDonService.Sua(hd) == true)
                    {
                        var li = new LichSuDonHang()
                        {
                            GhiChu = LyDo,
                            ThaoTac = $"Hoàn tác xác nhận nhận hàng đơn hàng {hd.MaHoaDon} ",
                            IdHoaDonn = id,
                            ThoiGianlam = DateTime.Now,
                            NguoiThucHien = nvnew[0].TenDangNhap,
                            TrangThai = true,
                            Is_detele = false
                        };
                        _LichSuHoaDonService.Them(li);
                    }
                }
                else
                {
                    var message = "Đơn hàng đã hoàn thành không thể hoàn tác !";
                    TempData["TB3"] = message;
                    return RedirectToAction("XemChiTiet", new { id = id, message });
                }



                return RedirectToAction("XemChiTiet", new { id = id });
            }
            else
            {
                return RedirectToAction("DangNhap", "Home");
            }
        }
        public IActionResult HoanTacGiaoThatBai(int id, string LyDo)
        {
            var nvnew = SessionServices.NhanVienSS(HttpContext.Session, "ACA");
            if (nvnew.Count() != 0)
            {
                if (LyDo == null)
                {
                    var message = "hãy điền lý do hoàn tác";
                    TempData["TB1"] = message;
                    return RedirectToAction("XemChiTiet", new { id = id, message });
                }

                var hd = _hoaDonService.GetById(id);
                if (hd.TrangThai == "Đơn hàng bị hủy")
                {
                    var message = "Đơn hàng đã bị hủy";
                    TempData["TB1"] = message;
                    return RedirectToAction("XemChiTiet", new { id = id, message });
                }
                if (hd.TrangThai == "Giao hàng thất bại")
                {
                    hd.TrangThai = "Hàng của bạn đang được giao";
                    if (_hoaDonService.Sua(hd) == true)
                    {
                        var li = new LichSuDonHang()
                        {
                            GhiChu = LyDo,
                            ThaoTac = $"Hoàn tác xác nhận gao đơn hàng {hd.MaHoaDon} thất bại",
                            IdHoaDonn = id,
                            ThoiGianlam = DateTime.Now,
                            NguoiThucHien = nvnew[0].TenDangNhap,
                            TrangThai = true,
                            Is_detele = false
                        };
                        _LichSuHoaDonService.Them(li);
                    }
                }
                else
                {
                    var message = "Đơn hàng đã hoàn thành không thể hoàn tác !";
                    TempData["TB3"] = message;
                    return RedirectToAction("XemChiTiet", new { id = id, message });
                }



                return RedirectToAction("XemChiTiet", new { id = id });
            }
            else
            {
                return RedirectToAction("DangNhap", "Home");
            }
        }
        public IActionResult XacNhanThanhToan(int id)
        {
            var nvnew = SessionServices.NhanVienSS(HttpContext.Session, "ACA");
            if (nvnew.Count() != 0)
            {
                var hd = _hoaDonService.GetById(id);
                if (hd.TrangThai == "Đang chờ xử lí")
                {
                    var message = "Đơn hàng chưa được xác nhận";
                    TempData["TB1"] = message;
                    return RedirectToAction("XemChiTiet", new { id = id, message });
                }
                if (hd.TrangThai == "Đơn hàng bị hủy")
                {
                    var message = "Đơn hàng đã bị hủy";
                    TempData["TB1"] = message;
                    return RedirectToAction("XemChiTiet", new { id = id, message });
                }
                if (hd.TrangThai == "Giao hàng thành công")
                {
                    var message = "Đơn hàng đã giao hàng thành công";
                    TempData["TB1"] = message;
                    return RedirectToAction("XemChiTiet", new { id = id, message });
                }
                if (hd.TrangThai == "Đưa hàng thành công")
                {
                    var message = "Đơn hàng đã đưa hàng thành công";
                    TempData["TB1"] = message;
                    return RedirectToAction("XemChiTiet", new { id = id, message });
                }
                if (hd.TrangThai != "Giao hàng thành công")
                {
                    hd.TrangThaiThanhToan = true;
                    if (_hoaDonService.Sua(hd) == true)
                    {
                        var li = new LichSuDonHang()
                        {
                            GhiChu = null,
                            ThaoTac = $"Xác nhận thanh toán đơn hàng {hd.MaHoaDon} ",
                            IdHoaDonn = id,
                            ThoiGianlam = DateTime.Now,
                            NguoiThucHien = nvnew[0].TenDangNhap,
                            TrangThai = true,
                            Is_detele = false
                        };
                        _LichSuHoaDonService.Them(li);
                    }
                }
                else
                {
                    var message = "Đơn hàng chưa được xác nhận !";
                    TempData["TB3"] = message;
                    return RedirectToAction("XemChiTiet", new { id = id, message });
                }



                return RedirectToAction("XemChiTiet", new { id = id });
            }
            else
            {
                return RedirectToAction("DangNhap", "Home");
            }
        }
        public IActionResult XacNhanNhanHang(int id)
        {
            var nvnew = SessionServices.NhanVienSS(HttpContext.Session, "ACA");
            if (nvnew.Count() != 0)
            {
                var hd = _hoaDonService.GetById(id);
                if (hd.TrangThai == "Đơn hàng bị hủy")
                {
                    var message = "Đơn hàng đã bị hủy";
                    TempData["TB1"] = message;
                    return RedirectToAction("XemChiTiet", new { id = id, message });
                }
                if (hd.TrangThai == "Hàng của bạn đang được giao" && hd.TrangThaiThanhToan == true)
                {
                    hd.TrangThai = "Giao hàng thành công";
                    hd.NgayNhan = DateTime.Now;
                    if (_hoaDonService.Sua(hd) == true)
                    {
                        var li = new LichSuDonHang()
                        {
                            GhiChu = null,
                            ThaoTac = $"Xác nhận nhận hàng của đơn hàng {hd.MaHoaDon} ",
                            IdHoaDonn = id,
                            ThoiGianlam = DateTime.Now,
                            NguoiThucHien = nvnew[0].TenDangNhap,
                            TrangThai = true,
                            Is_detele = true
                        };
                        _LichSuHoaDonService.Them(li);
                        var allhdct = _hoaDonChiTietService.GetAll().Where(c => c.IdHoaDon == id && c.Is_detele == true && c.TrangThai == true).ToList();
                        var ids = new List<Guid>();
                        foreach (var a in allhdct)
                        {
                            if (!ids.Contains(a.SanPhamChiTiet.SanPham.Id))
                            {
                                ids.Add(a.SanPhamChiTiet.SanPham.Id);
                            }
                        }
                        if (hd.KhachHang != null)
                        {
                            var listDanhGia = _danhGiaSanPhamService.GetAll().Where(c => c.IdKhachHang == hd.KhachHang.Id && ids.Contains((Guid)c.IdSanPham));
                            foreach (var b in listDanhGia)
                            {
                                b.SoSua = 1;
                                _danhGiaSanPhamService.Sua(b);
                            }
                        }

                    }

                }
                else
                {
                    var message = "Đơn hàng phải được giao vào thanh toán !";
                    TempData["TB2"] = message;
                    return RedirectToAction("XemChiTiet", new { id = id, message });
                }


                return RedirectToAction("XemChiTiet", new { id = id });
            }
            else
            {
                return RedirectToAction("DangNhap", "Home");
            }
        }
        public IActionResult XacNhanDuaHang(int id)
        {
            var nvnew = SessionServices.NhanVienSS(HttpContext.Session, "ACA");
            if (nvnew.Count() != 0)
            {
                var hd = _hoaDonService.GetById(id);
                if (hd.TrangThai == "Đơn hàng bị hủy")
                {
                    var message = "Đơn hàng đã bị hủy";
                    TempData["TB1"] = message;
                    return RedirectToAction("XemChiTiet", new { id = id, message });
                }
                if (hd.TrangThai == "Đang chuẩn bị hàng" && hd.TrangThaiThanhToan == true)
                {
                    hd.TrangThai = "Đưa hàng thành công";
                    if (_hoaDonService.Sua(hd) == true)
                    {
                        var li = new LichSuDonHang()
                        {
                            GhiChu = null,
                            ThaoTac = $"Xác nhận đưa hàng của đơn hàng {hd.MaHoaDon} ",
                            IdHoaDonn = id,
                            ThoiGianlam = DateTime.Now,
                            NguoiThucHien = nvnew[0].TenDangNhap,
                            TrangThai = true,
                            Is_detele = true
                        };
                        _LichSuHoaDonService.Them(li);
                        var allhdct = _hoaDonChiTietService.GetAll().Where(c => c.IdHoaDon == id && c.Is_detele == true && c.TrangThai == true).ToList();
                        var ids = new List<Guid>();
                        foreach (var a in allhdct)
                        {
                            if (!ids.Contains(a.SanPhamChiTiet.SanPham.Id))
                            {
                                ids.Add(a.SanPhamChiTiet.SanPham.Id);
                            }
                        }
                        if (hd.KhachHang != null)
                        {
                            var listDanhGia = _danhGiaSanPhamService.GetAll().Where(c => c.IdKhachHang == hd.KhachHang.Id && ids.Contains((Guid)c.IdSanPham));
                            foreach (var b in listDanhGia)
                            {
                                b.SoSua = 1;
                                _danhGiaSanPhamService.Sua(b);
                            }
                        }
                    }
                }
                else
                {
                    var message = "Đơn hàng chưa đủ điều kiện để xác nhận đưa !";
                    TempData["TB2"] = message;
                    return RedirectToAction("XemChiTiet", new { id = id, message });
                }


                return RedirectToAction("XemChiTiet", new { id = id });
            }
            else
            {
                return RedirectToAction("DangNhap", "Home");
            }
        }
        public IActionResult GiaoHangThatBai(int id)
        {
            var nvnew = SessionServices.NhanVienSS(HttpContext.Session, "ACA");
            if (nvnew.Count() != 0)
            {
                var hd = _hoaDonService.GetById(id);
                if (hd.TrangThai == "Đơn hàng bị hủy")
                {
                    var message = "Đơn hàng đã bị hủy";
                    TempData["TB1"] = message;
                    return RedirectToAction("XemChiTiet", new { id = id, message });
                }
                if (hd.NgayGiao != null)
                {
                    hd.TrangThai = "Giao hàng thất bại";
                    if (_hoaDonService.Sua(hd) == true)
                    {
                        var li = new LichSuDonHang()
                        {
                            GhiChu = null,
                            ThaoTac = $"Giao hàng thất bại đơn hàng {hd.MaHoaDon} và sẽ ngừng giao",
                            IdHoaDonn = id,
                            ThoiGianlam = DateTime.Now,
                            NguoiThucHien = nvnew[0].TenDangNhap,
                            TrangThai = true,
                            Is_detele = true
                        };
                        _LichSuHoaDonService.Them(li);
                    }
                }
                else
                {
                    var message = "Đơn hàng không thể giao hàng thất bại khi chưa giao hàng";
                    TempData["TB4"] = message;
                    return RedirectToAction("XemChiTiet", new { id = id, message });
                }

                return RedirectToAction("XemChiTiet", new { id = id });
            }
            else
            {
                return RedirectToAction("DangNhap", "Home");
            }
        }
        public IActionResult GiaoHangThatBaiThem1(int id)
        {
            var nvnew = SessionServices.NhanVienSS(HttpContext.Session, "ACA");
            if (nvnew.Count() != 0)
            {
                var hd = _hoaDonService.GetById(id);
                if (hd.TrangThai == "Đơn hàng bị hủy")
                {
                    var message = "Đơn hàng đã bị hủy";
                    TempData["TB1"] = message;
                    return RedirectToAction("XemChiTiet", new { id = id, message });
                }
                if (hd.NgayGiao != null)
                {
                    var li = new LichSuDonHang()
                    {
                        GhiChu = null,
                        ThaoTac = $"Giao hàng thất bại đơn hàng {hd.MaHoaDon} và sẽ tiếp tục được giao",
                        IdHoaDonn = id,
                        ThoiGianlam = DateTime.Now,
                        NguoiThucHien = nvnew[0].TenDangNhap,
                        TrangThai = true,
                        Is_detele = true
                    };
                    _LichSuHoaDonService.Them(li);
                }
                else
                {
                    var message = "Đơn hàng không thể giao hàng thất bại khi chưa giao hàng";
                    TempData["TB4"] = message;
                    return RedirectToAction("XemChiTiet", new { id = id, message });
                }


                return RedirectToAction("XemChiTiet", new { id = id });
            }
            else
            {
                return RedirectToAction("DangNhap", "Home");
            }
        }
        public IActionResult BoSanPhamNay(int id, Guid idCT, string LyDo)
        {
            var nvnew = SessionServices.NhanVienSS(HttpContext.Session, "ACA");
            if (nvnew.Count() != 0)
            {
                if (LyDo != null)
                {
                    var hd = _hoaDonService.GetById(id);
                    if (hd.TrangThai == "Đơn hàng bị hủy")
                    {
                        var message = "Đơn hàng đã bị hủy";
                        TempData["TB1"] = message;
                        return RedirectToAction("XemChiTiet", new { id = id, message });
                    }
                    if (hd.TrangThai == "Giao hàng thành công")
                    {
                        var message = "Đơn hàng đã giao hàng thành công";
                        TempData["TB1"] = message;
                        return RedirectToAction("XemChiTiet", new { id = id, message });
                    }
                    if (hd.TrangThai == "Đưa hàng thành công")
                    {
                        var message = "Đơn hàng đã đưa hàng thành công";
                        TempData["TB1"] = message;
                        return RedirectToAction("XemChiTiet", new { id = id, message });
                    }
                    var hdct = _hoaDonChiTietService.GetById(idCT);
                    var KhuyenMaiSp = _KhuyenMaiSanPhams.GetAll().Where(c => c.KhuyenMai.Mua1tang1 == true && c.KhuyenMai.NgayBatDau <= DateTime.Now && c.KhuyenMai.NgayKetThuc >= DateTime.Now && c.KhuyenMai.Is_Detele == true).ToList();
                    var g = new List<Guid>();
                    foreach (var item in KhuyenMaiSp)
                    {
                        // Kiểm tra xem Mau.Id đã xuất hiện trong danh sách chưa
                        if (!g.Contains((Guid)item.IdSanPham))
                        {
                            g.Add((Guid)item.IdSanPham);
                        }
                    }
                    if (hd.Is_detele != false)
                    {
                        var spct = _sanPhamChiTietService.GetById(hdct.IdSanPhamChiTiet);
                        spct.SoLuong += hdct.SoLuong;
                        if (_sanPhamChiTietService.Sua(spct) == false)
                        {
                            var message = "Đơn hàng không thể thay đổi(3)";
                            TempData["TB5"] = message;
                            return RedirectToAction("XemChiTiet", new { id = id, message });
                        }
                        hd.TongTien -= hdct.GiaTien * hdct.SoLuong;
                        if (_hoaDonService.Sua(hd) == false || _hoaDonChiTietService.Xoa(hdct.Id) == false)
                        {
                            var message = "Đơn hàng không thể thay đổi(1)";
                            TempData["TB5"] = message;
                            return RedirectToAction("XemChiTiet", new { id = id, message });
                        }
                            var li = new LichSuDonHang()
                            {
                                GhiChu = LyDo,
                                ThaoTac = $"Bỏ sản phẩm {spct.SanPham.TenSanPham} khỏi đơn hàng {hd.MaHoaDon}",
                                IdHoaDonn = id,
                                ThoiGianlam = DateTime.Now,
                                NguoiThucHien = nvnew[0].TenDangNhap,
                                TrangThai = true,
                                Is_detele = true
                            };
                            _LichSuHoaDonService.Them(li);
                    }
                    else
                    {
                        var message = "Đơn hàng không thể thay đổi";
                        TempData["TB5"] = message;
                        return RedirectToAction("XemChiTiet", new { id = id, message });
                    }
                    return RedirectToAction("XemChiTiet", new { id = id });
                }
                else
                {
                    var message = "Hãy điền lý do bỏ sản phẩm khỏi đơn";
                    TempData["TB4"] = message;
                    return RedirectToAction("XemChiTiet", new { id = id, message });
                }
            }
            else
            {
                return RedirectToAction("DangNhap", "Home");
            }
        }
        public IActionResult BoSanPham(Guid idHDCT, int idHD, string LyDo)
        {
            var nvnew = SessionServices.NhanVienSS(HttpContext.Session, "ACA");
            if (nvnew.Count() != 0)
            {
                if (LyDo != null)
                {
                    var hd = _hoaDonService.GetById(idHD);
                    if (hd.TrangThai == "Đơn hàng bị hủy")
                    {
                        var message = "Đơn hàng đã bị hủy";
                        TempData["TB1"] = message;
                        return RedirectToAction("XemChiTiet", new { id = idHD, message });
                    }
                    if (hd.TrangThai == "Giao hàng thành công")
                    {
                        var message = "Đơn hàng đã giao hàng thành công";
                        TempData["TB1"] = message;
                        return RedirectToAction("XemChiTiet", new { id = idHD, message });
                    }
                    if (hd.TrangThai == "Đưa hàng thành công")
                    {
                        var message = "Đơn hàng đã đưa hàng thành công";
                        TempData["TB1"] = message;
                        return RedirectToAction("XemChiTiet", new { id = idHD, message });
                    }
                    var hdct = _hoaDonChiTietService.GetById(idHDCT);
                    if (hd.Is_detele != false)
                    {
                        hd.TongTien -= hdct.GiaTien * hdct.SoLuong;
                        hdct.TrangThai = false;

                        if (_hoaDonService.Sua(hd) == false || _hoaDonChiTietService.Sua(hdct) == false)
                        {
                            var message = "Đơn hàng không thể thay đổi(1)";
                            TempData["TB5"] = message;
                            return RedirectToAction("XemChiTiet", new { id = idHD, message });
                        }
                        var li = new LichSuDonHang()
                        {
                            GhiChu = LyDo,
                            ThaoTac = $"Trả sản phẩm {hdct.SanPhamChiTiet.SanPham.TenSanPham} ",
                            IdHoaDonn = idHD,
                            ThoiGianlam = DateTime.Now,
                            NguoiThucHien = nvnew[0].TenDangNhap,
                            TrangThai = true,
                            Is_detele = true
                        };
                        if (_LichSuHoaDonService.Them(li) == false)
                        {
                            var message = "Đơn hàng không thể thay đổi(2)";
                            TempData["TB5"] = message;
                            return RedirectToAction("XemChiTiet", new { id = idHD, message });
                        }
                        var spct = _sanPhamChiTietService.GetById(hdct.IdSanPhamChiTiet);
                        spct.SoLuong += hdct.SoLuong;
                        if (_sanPhamChiTietService.Sua(spct) == false)
                        {
                            var message = "Đơn hàng không thể thay đổi(3)";
                            TempData["TB5"] = message;
                            return RedirectToAction("XemChiTiet", new { id = idHD, message });
                        }
                    }
                    else
                    {
                        var message = "Đơn hàng không thể thay đổi";
                        TempData["TB5"] = message;
                        return RedirectToAction("XemChiTiet", new { id = idHD, message });
                    }

                    return RedirectToAction("XemChiTiet", new { id = idHD });
                }
                else
                {
                    var message = "Hãy điền lý do trả hàng";
                    TempData["TB4"] = message;
                    return RedirectToAction("XemChiTiet", new { id = idHD, message });
                }
            }
            else
            {
                return RedirectToAction("DangNhap", "Home");
            }
        }
        public IActionResult HoanTacSp(Guid idHDCT, int idHD, string LyDo)
        {
            var nvnew = SessionServices.NhanVienSS(HttpContext.Session, "ACA");
            if (nvnew.Count() != 0)
            {
                if (LyDo != null)
                {
                    var hd = _hoaDonService.GetById(idHD);
                    if (hd.TrangThai == "Đơn hàng bị hủy")
                    {
                        var message = "Đơn hàng đã bị hủy";
                        TempData["TB1"] = message;
                        return RedirectToAction("XemChiTiet", new { id = idHD, message });
                    }
                    if (hd.TrangThai == "Giao hàng thành công")
                    {
                        var message = "Đơn hàng đã giao hàng thành công";
                        TempData["TB1"] = message;
                        return RedirectToAction("XemChiTiet", new { id = idHD, message });
                    }
                    if (hd.TrangThai == "Đưa hàng thành công")
                    {
                        var message = "Đơn hàng đã đưa hàng thành công";
                        TempData["TB1"] = message;
                        return RedirectToAction("XemChiTiet", new { id = idHD, message });
                    }
                    var hdct = _hoaDonChiTietService.GetById(idHDCT);
                    if (hd.Is_detele != false)
                    {
                        hd.TongTien += hdct.GiaTien * hdct.SoLuong;
                        hdct.TrangThai = true;
                        if (_hoaDonService.Sua(hd) == false || _hoaDonChiTietService.Sua(hdct) == false)
                        {
                            var message = "Đơn hàng không thể thay đổi(1)";
                            TempData["TB5"] = message;
                            return RedirectToAction("XemChiTiet", new { id = idHD, message });
                        }
                        var li = new LichSuDonHang()
                        {
                            GhiChu = LyDo,
                            ThaoTac = $"Hoàn tác trả sản phẩm {hdct.SanPhamChiTiet.SanPham.TenSanPham} của đơn hàng {hd.MaHoaDon} ",
                            IdHoaDonn = idHD,
                            ThoiGianlam = DateTime.Now,
                            NguoiThucHien = nvnew[0].TenDangNhap,
                            TrangThai = true,
                            Is_detele = true
                        };
                        if (_LichSuHoaDonService.Them(li) == false)
                        {
                            var message = "Đơn hàng không thể thay đổi(2)";
                            TempData["TB5"] = message;
                            return RedirectToAction("XemChiTiet", new { id = idHD, message });
                        }
                        var spct = _sanPhamChiTietService.GetById(hdct.IdSanPhamChiTiet);
                        spct.SoLuong -= hdct.SoLuong;
                        if (_sanPhamChiTietService.Sua(spct) == false)
                        {
                            var message = "Đơn hàng không thể thay đổi(3)";
                            TempData["TB5"] = message;
                            return RedirectToAction("XemChiTiet", new { id = idHD, message });
                        }

                    }
                    else
                    {
                        var message = "Đơn hàng không thể thay đổi";
                        TempData["TB5"] = message;
                        return RedirectToAction("XemChiTiet", new { id = idHD, message });
                    }

                    return RedirectToAction("XemChiTiet", new { id = idHD });
                }
                else
                {
                    var message = "Hãy điền lý do trả hàng";
                    TempData["TB4"] = message;
                    return RedirectToAction("XemChiTiet", new { id = idHD, message });
                }
            }
            else
            {
                return RedirectToAction("DangNhap", "Home");
            }
        }
        public IActionResult ThemBinhLuan(int IdHoaDon, string BinhLuan)
        {

            var nvnew = SessionServices.NhanVienSS(HttpContext.Session, "ACA");
            if (nvnew.Count() != 0)
            {
                if (BinhLuan == null)
                {
                    return RedirectToAction("XemChiTiet", new { id = IdHoaDon });
                }
                var li = new LichSuDonHang()
                {
                    GhiChu = BinhLuan,
                    IdHoaDonn = IdHoaDon,
                    ThoiGianlam = DateTime.Now,
                    NguoiThucHien = nvnew[0].TenDangNhap,
                    TrangThai = false,
                    Is_detele = true
                };
                if (_LichSuHoaDonService.Them(li) == false)
                {
                    var message = "Thêm thất bại";
                    TempData["TBLS"] = message;
                    return RedirectToAction("XemChiTiet", new { id = IdHoaDon, message });
                }
                return RedirectToAction("XemChiTiet", new { id = IdHoaDon });
            }
            else
            {
                return RedirectToAction("DangNhap", "Home");
            }
        }
        public IActionResult SuaGhiChu(int IdHoaDon, string GhiChu)
        {
            var nvnew = SessionServices.NhanVienSS(HttpContext.Session, "ACA");
            if (nvnew.Count() != 0)
            {
                var hd = _hoaDonService.GetById(IdHoaDon);
                if (hd.TrangThai == "Đơn hàng bị hủy")
                {
                    var message = "Đơn hàng đã bị hủy";
                    TempData["TB1"] = message;
                    return RedirectToAction("XemChiTiet", new { id = IdHoaDon, message });
                }
                if (hd.TrangThai == "Giao hàng thành công")
                {
                    var message = "Đơn hàng đã giao hàng thành công";
                    TempData["TB1"] = message;
                    return RedirectToAction("XemChiTiet", new { id = IdHoaDon, message });
                }
                if (hd.TrangThai == "Đưa hàng thành công")
                {
                    var message = "Đơn hàng đã đưa hàng thành công";
                    TempData["TB1"] = message;
                    return RedirectToAction("XemChiTiet", new { id = IdHoaDon, message });
                }
                if (hd.TrangThaiThanhToan == true)
                {
                    hd.GhiChu = GhiChu;
                    if (_hoaDonService.Sua(hd) == true)
                    {
                        var li = new LichSuDonHang()
                        {
                            GhiChu = null,
                            ThaoTac = $"Sửa lại ghi chú thành : {GhiChu}",
                            IdHoaDonn = IdHoaDon,
                            ThoiGianlam = DateTime.Now,
                            NguoiThucHien = nvnew[0].TenDangNhap,
                            TrangThai = true,
                            Is_detele = true
                        };
                        _LichSuHoaDonService.Them(li);
                    }
                }
                else
                {
                    var message = "Đơn hàng phải được giao vào thanh toán !";
                    TempData["TB2"] = message;
                    return RedirectToAction("XemChiTiet", new { id = IdHoaDon, message });
                }


                return RedirectToAction("XemChiTiet", new { id = IdHoaDon });
            }
            else
            {
                return RedirectToAction("DangNhap", "Home");
            }
        }
        public IActionResult HuyDonMatHang(int id, string LyDo2)
        {
            var nvnew = SessionServices.NhanVienSS(HttpContext.Session, "ACA");
            if (nvnew.Count() != 0)
            {
                var hd = _hoaDonService.GetById(id);
                if (LyDo2 != null)
                {
                    hd.TrangThai = "Đơn hàng bị hủy";
                    if (_hoaDonService.Sua(hd) == true)
                    {
                        var li = new LichSuDonHang()
                        {
                            GhiChu = LyDo2,
                            ThaoTac = $"Hủy đơn hàng ,{hd.MaHoaDon} bị mất",
                            IdHoaDonn = id,
                            ThoiGianlam = DateTime.Now,
                            NguoiThucHien = nvnew[0].TenDangNhap,
                            TrangThai = true,
                            Is_detele = true
                        };
                        _LichSuHoaDonService.Them(li);
                    }
                }
                else
                {
                    var message = "Hãy điền lý do hủy đơn";
                    TempData["TB4"] = message;
                    return RedirectToAction("XemChiTiet", new { id = id, message });
                }

                return RedirectToAction("XemChiTiet", new { id = id });
            }
            else
            {
                return RedirectToAction("DangNhap", "Home");
            }
        }
        public IActionResult HuyDonConHang(int id, string LyDo)
        {
            var nvnew = SessionServices.NhanVienSS(HttpContext.Session, "ACA");
            if (nvnew.Count() != 0)
            {
                var hd = _hoaDonService.GetById(id);
                if (LyDo != null)
                {
                    hd.TrangThai = "Đơn hàng bị hủy";
                    var hdct = _hoaDonChiTietService.GetAll().Where(c => c.IdHoaDon == id&&c.TrangThai==true);

                    foreach (var a in hdct)
                    {
                        var spct = _sanPhamChiTietService.GetById(a.IdSanPhamChiTiet);
                        spct.SoLuong += a.SoLuong;
                        _sanPhamChiTietService.Sua(spct);
                    }
                    if (_hoaDonService.Sua(hd) == true)
                    {
                        var li = new LichSuDonHang()
                        {
                            GhiChu = LyDo,
                            ThaoTac = $"Hủy đơn hàng {hd.MaHoaDon} với còn hàng",
                            IdHoaDonn = id,
                            ThoiGianlam = DateTime.Now,
                            NguoiThucHien = nvnew[0].TenDangNhap,
                            TrangThai = true,
                            Is_detele = true
                        };
                        _LichSuHoaDonService.Them(li);
                    }
                }
                else
                {
                    var message = "Hãy điền lý do hủy đơn";
                    TempData["TB4"] = message;
                    return RedirectToAction("XemChiTiet", new { id = id, message });
                }
                return RedirectToAction("XemChiTiet", new { id = id });
            }
            else
            {
                return RedirectToAction("DangNhap", "Home");
            }
        }
        #endregion

        #region sap xep va loc
        public IActionResult XemChuaXacNhan()
        {
            var hd = _hoaDonService.GetAll();
            var view = new ThieuxkViewAdmin()
            {
                hoaDons = hd.Where(c => c.TrangThai == "Đang chờ xử lí" || c.TrangThai == "Đang Tạo" && c.Is_detele == true).ToList(),
            };
            return View("Index", view);
        }
        public IActionResult XemDaBiAn()
        {
            var hd = _hoaDonService.GetAll();
            var view = new ThieuxkViewAdmin()
            {
                hoaDons = hd.Where(c => c.Is_detele == false).ToList(),
            };
            return View("Index", view);
        }
        public IActionResult XemDaXacNhan()
        {
            var hd = _hoaDonService.GetAll();
            var view = new ThieuxkViewAdmin()
            {
                hoaDons = hd.Where(c => c.TrangThai != "Đang chờ xử lí" && c.TrangThai != "Đang Tạo" && c.Is_detele == true).ToList(),
            };
            return View("Index", view);
        }
        public IActionResult TimKiem(string? ten)
        {
            if (ten == null)
            {
                return RedirectToAction("Index");
            }
            List<HoaDon> hd = _hoaDonService
                .GetAll()
                .Where(c =>

                        c.MaHoaDon != null && c.MaHoaDon.ToLower().Contains(ten.ToLower()) ||
                        c.TenKhachHang != null && c.TenKhachHang.ToLower().Contains(ten.ToLower()) ||
                        (c.SDTNguoiNhan != null && c.SDTNguoiNhan.Contains(ten.ToLower())) ||
                        (c.Email != null && c.Email.ToLower().Contains(ten.ToLower()))

                )
                .ToList();

            if (hd.Count == 0)
            {
                var message = "không tìm thấy  !";
                TempData["TB1"] = message;
                return RedirectToAction("Index", new { message });
            }
            var view = new ThieuxkViewAdmin()
            {
                hoaDons = hd,
            };
            return View("Index", view);
        }
        public IActionResult TimKiemNgay(DateTime NgayDau, DateTime NgayCuoi)
        {
            if (NgayDau == NgayCuoi)
            {
                var message = "hãy chọn ngày bắt đầu và chọn khoản kết thúc của bạn !";
                TempData["TB1"] = message;
                return RedirectToAction("Index", new { message });
            }
            else if (NgayDau > NgayCuoi)
            {
                var message = "Ngày bắt đầu phải nhỏ hơn ngày kết thúc !";
                TempData["TB1"] = message;
                return RedirectToAction("Index", new { message });
            }
            else
            {
                var hd = _hoaDonService.GetAll().Where(c => (c.NgayTaoHoaDon > NgayDau && c.NgayTaoHoaDon < NgayCuoi)||(c.NgayDat > NgayDau && c.NgayDat < NgayCuoi) && c.Is_detele == true).ToList();
                var view = new ThieuxkViewAdmin()
                {
                    hoaDons = hd,
                };
                return View("Index", view);
            }

        }
        public IActionResult XemDaGiao()
        {
            var hd = _hoaDonService.GetAll();
            var view = new ThieuxkViewAdmin()
            {
                hoaDons = hd.Where(c => c.NgayGiao != null && c.Is_detele == true).ToList(),
            };
            return View("Index", view);
        }
        public IActionResult XemChuaGiao()
        {
            var hd = _hoaDonService.GetAll();
            var view = new ThieuxkViewAdmin()
            {
                hoaDons = hd.Where(c => c.NgayGiao == null && c.Is_detele == true&&c.TrangThai!="Đưa hàng thành công").ToList(),
            };
            return View("Index", view);
        }
        public IActionResult XemChuThanhToan()
        {
            var hd = _hoaDonService.GetAll();
            var view = new ThieuxkViewAdmin()
            {
                hoaDons = hd.Where(c => c.TrangThaiThanhToan == false && c.Is_detele == true).ToList(),
            };
            return View("Index", view);
        }
        public IActionResult XemDaThanhToan()
        {
            var hd = _hoaDonService.GetAll();
            var view = new ThieuxkViewAdmin()
            {
                hoaDons = hd.Where(c => c.TrangThaiThanhToan == true && c.Is_detele == true).ToList(),
            };
            return View("Index", view);
        }
        public IActionResult XemDaGiaoHoanTat()
        {
            var hd = _hoaDonService.GetAll();
            var view = new ThieuxkViewAdmin()
            {
                hoaDons = hd.Where(c => c.TrangThai == "Giao hàng thành công" && c.Is_detele == true).ToList(),
            };
            return View("Index", view);
        }
        public IActionResult XemDaMuaTaiQuayThanhCong()
        {
            var hd = _hoaDonService.GetAll();
            var view = new ThieuxkViewAdmin()
            {
                hoaDons = hd.Where(c => c.TrangThai == "Đưa hàng thành công" && c.Is_detele == true).ToList(),
            };
            return View("Index", view);
        }
        public IActionResult XemDaGiaoThatBai()
        {
            var hd = _hoaDonService.GetAll();
            var view = new ThieuxkViewAdmin()
            {
                hoaDons = hd.Where(c => c.TrangThai == "Giao hàng thất bại" && c.Is_detele == true && c.Is_detele == true).ToList(),
            };
            return View("Index", view);
        }
        public IActionResult XemDaBiHuy()
        {
            var hd = _hoaDonService.GetAll();
            var view = new ThieuxkViewAdmin()
            {
                hoaDons = hd.Where(c => c.TrangThai == "Đơn hàng bị hủy" && c.Is_detele == true).ToList(),
            };
            return View("Index", view);
        }
        public IActionResult XapXepMoiNhat()
        {
            var hd = _hoaDonService.GetAll();
            var view = new ThieuxkViewAdmin()
            {
                hoaDons = hd.Where(c => c.Is_detele == true && c.NgayTaoHoaDon == null && c.Is_detele == true).OrderByDescending(c => c.NgayDat).ToList(),
            };
            return View("Index", view);
        }
        public IActionResult XapXepCuNhat()
        {
            var hd = _hoaDonService.GetAll();
            var view = new ThieuxkViewAdmin()
            {
                hoaDons = hd.Where(c => c.Is_detele == true && c.NgayTaoHoaDon == null).OrderBy(c => c.NgayDat).ToList(),
            };
            return View("Index", view);
        }
        public IActionResult XapXepMoiNhat1()
        {
            var hd = _hoaDonService.GetAll();
            var view = new ThieuxkViewAdmin()
            {
                hoaDons = hd.Where(c => c.Is_detele == true && c.NgayDat == null).OrderByDescending(c => c.NgayTaoHoaDon).ToList(),
            };
            return View("Index", view);
        }
        public IActionResult XapXepCuNhat1()
        {
            var hd = _hoaDonService.GetAll();
            var view = new ThieuxkViewAdmin()
            {
                hoaDons = hd.Where(c => c.Is_detele == true && c.NgayDat == null).OrderBy(c => c.NgayTaoHoaDon).ToList(),
            };
            return View("Index", view);
        }
        public IActionResult XapXepTienCaoNhat()
        {
            var hd = _hoaDonService.GetAll();
            var view = new ThieuxkViewAdmin()
            {
                hoaDons = hd.Where(c => c.Is_detele == true).OrderByDescending(c => c.TongTien).ToList(),
            };
            return View("Index", view);
        }
        public IActionResult XapXepTienThapNhat()
        {
            var hd = _hoaDonService.GetAll();
            var view = new ThieuxkViewAdmin()
            {
                hoaDons = hd.Where(c => c.Is_detele == true).OrderBy(c => c.TongTien).ToList(),
            };
            return View("Index", view);
        }
        #endregion

        #region chuc nang nhanh

        [HttpGet("/QuanLyHd/XuatEx")]
        public JsonResult XuatEx(int IdHD)
        {
            var wb = new XLWorkbook();
            var ws = wb.Worksheets.Add("Contacts");
            ws.Cell("A1").Value = "Hóa Đơn";
            ws.Cell("A2").Value = "Mã hóa đơn";
            ws.Cell("A3").Value = "Ngày tạo hóa đơn";
            ws.Cell("A4").Value = "Trạng thái";
            ws.Cell("A5").Value = "Tổng tiền";
            ws.Cell("A6").Value = "Tiền ship";
            ws.Cell("A7").Value = "Ngày giao";
            ws.Cell("A8").Value = "Ngày nhận";
            ws.Cell("A9").Value = "Tên khách hàng";
            ws.Cell("A10").Value = "Email";
            //ws.Cell("A11").Value = "Số điện thoại";
            ws.Cell("A12").Value = "Địa chỉ";
            ws.Cell("A13").Value = "Thanh toán";



            var hd = _hoaDonService.GetById(IdHD);

            ws.Cell("B2").Value = hd.MaHoaDon;
            ws.Cell("B3").Value = hd.NgayTaoHoaDon;
            ws.Cell("B4").Value = hd.TrangThai;
            ws.Cell("B5").Value = hd.TongTien;
            ws.Cell("B6").Value = hd.TienShip;
            ws.Cell("B7").Value = hd.NgayGiao;
            ws.Cell("B8").Value = hd.NgayNhan;
            ws.Cell("B9").Value = hd.TenKhachHang;
            ws.Cell("B10").Value = hd.Email;
            ws.Cell("B11").Value = hd.SDTNguoiNhan;
            ws.Cell("B12").Value = hd.DiaChi;
            ws.Cell("B13").Value = hd.TrangThaiThanhToan == true ? "Đã thanh toán" : "Chưa thanh toán";

            ws.Cell("A15").Value = "Hóa Đơn Chi Tiết";
            ws.Cell("A16").Value = "Tên sản phẩm";
            ws.Cell("B16").Value = "Màu";
            ws.Cell("C16").Value = "Size";
            ws.Cell("D16").Value = "Nsx";
            ws.Cell("E16").Value = "Chất liệu";
            ws.Cell("F16").Value = "Giá";
            ws.Cell("G16").Value = "Số lượng";
            ws.Cell("H16").Value = "Thành tiền";
            ws.Cell("I16").Value = "Trạng thái";

            var hdct = _hoaDonChiTietService.GetAll().Where(c => c.IdHoaDon == IdHD).ToList();

            int row = 17;
            for (int i = 0; i < hdct.Count; i++)
            {

                ws.Cell("A" + row).Value = hdct[i].SanPhamChiTiet.SanPham.TenSanPham;
                ws.Cell("B" + row).Value = hdct[i].SanPhamChiTiet.Mau.TenMau;
                ws.Cell("C" + row).Value = hdct[i].SanPhamChiTiet.Size.CoSize;
                ws.Cell("D" + row).Value = hdct[i].SanPhamChiTiet.SanPham.NSX.TenNSX;
                ws.Cell("E" + row).Value = hdct[i].SanPhamChiTiet.SanPham.ChatLieu.TenChatLieu;
                ws.Cell("F" + row).Value = hdct[i].GiaTien;
                ws.Cell("G" + row).Value = hdct[i].SoLuong;
                ws.Cell("H" + row).Value = hdct[i].GiaTien * hdct[i].SoLuong;
                ws.Cell("I" + row).Value = hdct[i].Is_detele == true ? "Bình thường" : "Sản phẩm bị đổi trả";
                row++;
            }

            string fileName = "Ex" + DateTime.Now.Ticks + ".xlsx";

            var path = Path.Combine(
                Directory.GetCurrentDirectory(), "wwwroot", "ex", fileName);
            var rngTable = ws.Range("A1:B13");
            var rngHeaders = rngTable.Range("A1:B1"); // The address is relative to rngTable (NOT the worksheet)
            rngHeaders.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
            rngHeaders.Style.Font.Bold = true;
            rngHeaders.Style.Fill.BackgroundColor = XLColor.Aqua;
            rngTable.Style.Border.BottomBorder = XLBorderStyleValues.Thin;
            //Add a thick outside border
            rngTable.Style.Border.OutsideBorder = XLBorderStyleValues.Thick;
            rngTable.Row(1).Merge(); // We could've also used: rngTable.Range("A1:E1").Merge()

            var rngTable2 = ws.Range($"A15:I{16 + hdct.Count()}");
            var rngHeaders2 = rngTable2.Range("A15:I15");
            rngHeaders2.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
            rngHeaders2.Style.Font.Bold = true;
            rngHeaders2.Style.Fill.BackgroundColor = XLColor.Aqua;
            rngTable2.Style.Border.BottomBorder = XLBorderStyleValues.Thin;
            //Add a thick outside border
            rngTable2.Style.Border.OutsideBorder = XLBorderStyleValues.Thick;
            rngTable2.Row(1).Merge(); // We could've also used: rngTable.Range("A1:E1").Merge()
            ws.Columns(1, 100).AdjustToContents();
            wb.SaveAs(path);
            return Json(fileName, new System.Text.Json.JsonSerializerOptions());
        }
        [HttpPost("/QuanLyHd/XuatEx2")]
        public JsonResult XuatEx2([FromBody] EXview exview)
        {
            var Filenameok = new List<string>();

            foreach (var IdHD in exview.IdHD)
            {
                var wb = new XLWorkbook();
                var ws = wb.Worksheets.Add("Contacts");
                ws.Cell("A1").Value = "Hóa Đơn";
                ws.Cell("A2").Value = "Mã hóa đơn";
                ws.Cell("A3").Value = "Ngày tạo hóa đơn";
                ws.Cell("A4").Value = "Trạng thái";
                ws.Cell("A5").Value = "Tổng tiền";
                ws.Cell("A6").Value = "Tiền ship";
                ws.Cell("A7").Value = "Ngày giao";
                ws.Cell("A8").Value = "Ngày nhận";
                ws.Cell("A9").Value = "Tên khách hàng";
                ws.Cell("A10").Value = "Email";
                //ws.Cell("A11").Value = "Số điện thoại";
                ws.Cell("A12").Value = "Địa chỉ";
                ws.Cell("A13").Value = "Thanh toán";



                var hd = _hoaDonService.GetById(IdHD);

                ws.Cell("B2").Value = hd.MaHoaDon;
                ws.Cell("B3").Value = hd.NgayTaoHoaDon;
                ws.Cell("B4").Value = hd.TrangThai;
                ws.Cell("B5").Value = hd.TongTien;
                ws.Cell("B6").Value = hd.TienShip;
                ws.Cell("B7").Value = hd.NgayGiao;
                ws.Cell("B8").Value = hd.NgayNhan;
                ws.Cell("B9").Value = hd.TenKhachHang;
                ws.Cell("B10").Value = hd.Email;
                ws.Cell("B11").Value = hd.SDTNguoiNhan;
                ws.Cell("B12").Value = hd.DiaChi;
                ws.Cell("B13").Value = hd.TrangThaiThanhToan == true ? "Đã thanh toán" : "Chưa thanh toán";

                ws.Cell("A15").Value = "Hóa Đơn Chi Tiết";
                ws.Cell("A16").Value = "Tên sản phẩm";
                ws.Cell("B16").Value = "Màu";
                ws.Cell("C16").Value = "Size";
                ws.Cell("D16").Value = "Nsx";
                ws.Cell("E16").Value = "Chất liệu";
                ws.Cell("F16").Value = "Giá";
                ws.Cell("G16").Value = "Số lượng";
                ws.Cell("H16").Value = "Thành tiền";
                ws.Cell("I16").Value = "Trạng thái";

                var hdct = _hoaDonChiTietService.GetAll().Where(c => c.IdHoaDon == IdHD).ToList();

                int row = 17;
                for (int i = 0; i < hdct.Count; i++)
                {

                    ws.Cell("A" + row).Value = hdct[i].SanPhamChiTiet.SanPham.TenSanPham;
                    ws.Cell("B" + row).Value = hdct[i].SanPhamChiTiet.Mau.TenMau;
                    ws.Cell("C" + row).Value = hdct[i].SanPhamChiTiet.Size.CoSize;
                    ws.Cell("D" + row).Value = hdct[i].SanPhamChiTiet.SanPham.NSX.TenNSX;
                    ws.Cell("E" + row).Value = hdct[i].SanPhamChiTiet.SanPham.ChatLieu.TenChatLieu;
                    ws.Cell("F" + row).Value = hdct[i].GiaTien;
                    ws.Cell("G" + row).Value = hdct[i].SoLuong;
                    ws.Cell("H" + row).Value = hdct[i].GiaTien * hdct[i].SoLuong;
                    ws.Cell("I" + row).Value = hdct[i].Is_detele == true ? "Bình thường" : "Sản phẩm bị đổi trả";
                    row++;
                }

                string fileName = "Ex" + DateTime.Now.Ticks + ".xlsx";

                var path = Path.Combine(
                    Directory.GetCurrentDirectory(), "wwwroot", "ex", fileName);
                var rngTable = ws.Range("A1:B13");
                var rngHeaders = rngTable.Range("A1:B1"); // The address is relative to rngTable (NOT the worksheet)
                rngHeaders.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                rngHeaders.Style.Font.Bold = true;
                rngHeaders.Style.Fill.BackgroundColor = XLColor.Aqua;
                rngTable.Style.Border.BottomBorder = XLBorderStyleValues.Thin;
                //Add a thick outside border
                rngTable.Style.Border.OutsideBorder = XLBorderStyleValues.Thick;
                rngTable.Row(1).Merge(); // We could've also used: rngTable.Range("A1:E1").Merge()

                var rngTable2 = ws.Range($"A15:I{16 + hdct.Count()}");
                var rngHeaders2 = rngTable2.Range("A15:I15");
                rngHeaders2.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                rngHeaders2.Style.Font.Bold = true;
                rngHeaders2.Style.Fill.BackgroundColor = XLColor.Aqua;
                rngTable2.Style.Border.BottomBorder = XLBorderStyleValues.Thin;
                //Add a thick outside border
                rngTable2.Style.Border.OutsideBorder = XLBorderStyleValues.Thick;
                rngTable2.Row(1).Merge(); // We could've also used: rngTable.Range("A1:E1").Merge()
                ws.Columns(1, 100).AdjustToContents();
                wb.SaveAs(path);

                Filenameok.Add(fileName);
            }
            return Json(Filenameok, new System.Text.Json.JsonSerializerOptions());
        }
        [HttpPost("/QuanLyHd/XuatEx3")]
        public JsonResult XacNhanDonHangNhanh([FromBody] EXview exview)
        {
            var Filenameok = new List<string>();

            foreach (var IdHD in exview.IdHD)
            {
                var kt = _hoaDonService.GetById(IdHD);
                if (kt.TrangThai != "Đang chờ xử lí")
                {
                    return Json("that bai 1", new System.Text.Json.JsonSerializerOptions());
                }
                var nvnew = SessionServices.NhanVienSS(HttpContext.Session, "ACA");
                if (nvnew.Count() != 0)
                {

                    var hd = _hoaDonService.GetById(IdHD);
                    hd.TrangThai = "Đang chuẩn bị hàng";
                    if (_hoaDonService.Sua(hd) == true)
                    {
                        var li = new LichSuDonHang()
                        {
                            GhiChu = null,
                            ThaoTac = $"Xác nhận đơn hàng {hd.MaHoaDon} ",
                            IdHoaDonn = IdHD,
                            ThoiGianlam = DateTime.Now,
                            NguoiThucHien = nvnew[0].TenDangNhap,
                            TrangThai = true,
                            Is_detele = true
                        };
                        _LichSuHoaDonService.Them(li);
                    }
                }
                else
                {
                    return Json("that bai", new System.Text.Json.JsonSerializerOptions());
                }
            }
            return Json("ok", new System.Text.Json.JsonSerializerOptions());
        }

        [HttpPost("/QuanLyHd/AnHD")]
        public JsonResult AnDonHangNhanh([FromBody] EXview exview)
        {
            var Filenameok = new List<string>();

            foreach (var IdHD in exview.IdHD)
            {
                var kt = _hoaDonService.GetById(IdHD);
                if (kt.TrangThai != "Đơn hàng bị hủy"&& kt.TrangThai != "Đưa hàng thành công" && kt.TrangThai != "Giao hàng thành công")
                {
                    return Json("that bai 1", new System.Text.Json.JsonSerializerOptions());
                }
                var nvnew = SessionServices.NhanVienSS(HttpContext.Session, "ACA");
                if (nvnew.Count() != 0)
                {

                    var hd = _hoaDonService.GetById(IdHD);
                    hd.Is_detele = false;
                    if (_hoaDonService.Sua(hd) == true)
                    {
                        var li = new LichSuDonHang()
                        {
                            GhiChu = null,
                            ThaoTac = $"Ẩn đơn hàng {hd.MaHoaDon} ",
                            IdHoaDonn = IdHD,
                            ThoiGianlam = DateTime.Now,
                            NguoiThucHien = nvnew[0].TenDangNhap,
                            TrangThai = true,
                            Is_detele = false
                        };
                        _LichSuHoaDonService.Them(li);
                    }
                }
                else
                {
                    return Json("that bai", new System.Text.Json.JsonSerializerOptions());
                }
            }
            return Json("ok", new System.Text.Json.JsonSerializerOptions());
        }
        [HttpPost("/QuanLyHd/HienHD")]
        public JsonResult HienDonHangNhanh([FromBody] EXview exview)
        {
            var Filenameok = new List<string>();

            foreach (var IdHD in exview.IdHD)
            {
                var kt = _hoaDonService.GetById(IdHD);
                if (kt.Is_detele == true)
                {
                    return Json("that bai 1", new System.Text.Json.JsonSerializerOptions());
                }
                var nvnew = SessionServices.NhanVienSS(HttpContext.Session, "ACA");
                if (nvnew.Count() != 0)
                {

                    var hd = _hoaDonService.GetById(IdHD);
                    hd.Is_detele = true;
                    if (_hoaDonService.Sua(hd) == true)
                    {
                        var li = new LichSuDonHang()
                        {
                            GhiChu = null,
                            ThaoTac = $"Hiện đơn hàng {hd.MaHoaDon} ",
                            IdHoaDonn = IdHD,
                            ThoiGianlam = DateTime.Now,
                            NguoiThucHien = nvnew[0].TenDangNhap,
                            TrangThai = true,
                            Is_detele = false
                        };
                        _LichSuHoaDonService.Them(li);
                    }
                }
                else
                {
                    return Json("that bai", new System.Text.Json.JsonSerializerOptions());
                }
            }
            return Json("ok", new System.Text.Json.JsonSerializerOptions());
        }
        #endregion

        #region mua hang tai quay
        static bool IsValidGmail(string email)
        {
            // Định nghĩa một biểu thức chính quy cho địa chỉ Gmail
            string pattern = @"^[a-zA-Z0-9._%+-]+@gmail\.com$";

            // Sử dụng Regex.IsMatch để kiểm tra xem địa chỉ email có khớp với biểu thức không
            return Regex.IsMatch(email, pattern);
        }
        public IActionResult TaoHoaDonnew()
        {
            var nvnew = SessionServices.NhanVienSS(HttpContext.Session, "ACA");
            if (nvnew.Count() != 0)
            {
                int idHoaDon;
                var hh = _hoaDonService.GetAll().ToList();
                if (hh.Count == 0)
                {
                    idHoaDon = 1;
                }
                else
                {
                    idHoaDon = hh.Max(c => c.Id) + 1;
                }
                var hdnew = new HoaDon()
                {
                    MaHoaDon = $"HD0{idHoaDon}",
                    TrangThai = "Đang Tạo",
                    NgayTaoHoaDon = DateTime.Now,
                    TrangThaiThanhToan = false,
                    Is_detele = true,
                };
                if (_hoaDonService.Them(hdnew) == false)
                {
                    var message = "lỗi tạo hóa đơn thất bại!";
                    TempData["TB1"] = message;
                    return RedirectToAction("Index", new { message });
                }
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("DangNhap", "Home");
            }
        }
        public IActionResult TaoHoaDon(int id)
        {
            var nvnew = SessionServices.NhanVienSS(HttpContext.Session, "ACA");
            if (nvnew.Count() != 0)
            {
                var giamgianew = SessionBan.GiamGiaSS(HttpContext.Session, "GiamGia2");
                giamgianew.Clear();
                float tong = 0;
                var hd = _hoaDonService.GetById(id);
                HttpResponseMessage responseProvin = _httpClient.GetAsync("https://online-gateway.ghn.vn/shiip/public-api/master-data/province").Result;
                Provin lstprovin = new Provin();
                if (responseProvin.IsSuccessStatusCode)
                {
                    string jsonData2 = responseProvin.Content.ReadAsStringAsync().Result;
                    lstprovin = JsonConvert.DeserializeObject<Provin>(jsonData2);
                    ViewBag.Provin = new SelectList(lstprovin.data, "ProvinceID", "ProvinceName");
                }
                var sanphamctnew = SessionBan.SanPhamTamSS(HttpContext.Session, "SanPhamTamSS");
                if (sanphamctnew.Count == 0)
                {
                    var spt = new SanPhamTam()
                    {
                        idHD = id
                    };
                    sanphamctnew.Add(spt);
                    SessionBan.SetObjToJson(HttpContext.Session, "SanPhamTamSS", sanphamctnew);
                }
                else
                {
                    sanphamctnew.RemoveAt(0);
                    var spt = new SanPhamTam()
                    {
                        idHD = id
                    };
                    sanphamctnew.Add(spt);
                    SessionBan.SetObjToJson(HttpContext.Session, "SanPhamTamSS", sanphamctnew);
                }
                var gh = _hoaDonService.GetAll().FirstOrDefault(c => c.Id == id);
                IEnumerable<HoaDonChiTiet> ghct = _hoaDonChiTietService.GetAll().Where(c => c.IdHoaDon == id);
                var KhuyenMaiSp = _KhuyenMaiSanPhams.GetAll().Where(c => c.KhuyenMai.Mua1tang1 == true && c.KhuyenMai.NgayBatDau <= DateTime.Now && c.KhuyenMai.NgayKetThuc >= DateTime.Now && c.KhuyenMai.Is_Detele == true).ToList();
                var g = new List<Guid>();
                foreach (var item in KhuyenMaiSp)
                {
                    // Kiểm tra xem Mau.Id đã xuất hiện trong danh sách chưa
                    if (!g.Contains((Guid)item.IdSanPham))
                    {
                        g.Add((Guid)item.IdSanPham);
                    }
                }
                foreach (var x in ghct)
                {

                    if (g.Contains(x.SanPhamChiTiet.SanPham.Id))
                    {
                        tong += float.Parse(x.SanPhamChiTiet.SanPham.GiaNiemYet.ToString()) * (x.SoLuong / 2);
                    }
                    else
                    {
                        tong += float.Parse(x.SanPhamChiTiet.SanPham.GiaNiemYet.ToString()) * (x.SoLuong);
                    }


                }
                var a = _hoaDonChiTietService.GetAll().Where(c => c.IdHoaDon == id).ToList();
                var giamgia = _giamGiaService.GetAll().Where(c => c.TrangThai == true && c.Is_detele == true && c.NgayBatDau <= DateTime.Now && c.NgayKetThuc >= DateTime.Now).ToList();

                var view = new Thi1View()
                {
                    check11 = g,
                    HoaDon = hd,
                    GiamGias = giamgia,
                    HoaDonChiTiets = a,
                    TongTien = tong,
                };

                return View(view);
            }
            else
            {
                return RedirectToAction("DangNhap", "Home");
            }
        }
        public IActionResult xoaKhoiHoaDon(Guid idHDCT, int id)
        {
            var nvnew = SessionServices.NhanVienSS(HttpContext.Session, "ACA");
            if (nvnew.Count() != 0)
            {
                var hdct = _hoaDonChiTietService.GetById(idHDCT);
                var spct = _sanPhamChiTietService.GetById(hdct.IdSanPhamChiTiet);
                var KhuyenMaiSp = _KhuyenMaiSanPhams.GetAll().Where(c => c.KhuyenMai.Mua1tang1 == true && c.KhuyenMai.NgayBatDau <= DateTime.Now && c.KhuyenMai.NgayKetThuc >= DateTime.Now && c.KhuyenMai.Is_Detele == true).ToList();
                var g = new List<Guid>();
                foreach (var item in KhuyenMaiSp)
                {
                    // Kiểm tra xem Mau.Id đã xuất hiện trong danh sách chưa
                    if (!g.Contains((Guid)item.IdSanPham))
                    {
                        g.Add((Guid)item.IdSanPham);
                    }
                }
                spct.SoLuong += hdct.SoLuong;
                if (_sanPhamChiTietService.Sua(spct) == false)
                {
                    var message = $"bỏ thất bại(1)";
                    TempData["TB2"] = message;
                    return RedirectToAction("TaoHoaDon", new { id = id, message });
                }
                if (_hoaDonChiTietService.Xoa(hdct.Id) == false)
                {
                    var message = $"bỏ thất bại(1)";
                    TempData["TB2"] = message;
                    return RedirectToAction("TaoHoaDon", new { id = id, message });
                }
                return RedirectToAction("TaoHoaDon", new { id = id });
            }
            else
            {
                return RedirectToAction("DangNhap", "Home");
            }
        }
        public IActionResult sanphammua()
        {
            var nvnew = SessionServices.NhanVienSS(HttpContext.Session, "ACA");
            if (nvnew.Count() != 0)
            {
                var sanPhamList = _sanPhamService.GetAll();
                var khuyenMaiSp = _KhuyenMaiSanPhams.GetAll().Where(c => c.KhuyenMai.TrangThai == true && c.KhuyenMai.Is_Detele == true && c.KhuyenMai.NgayBatDau <= DateTime.Now && c.KhuyenMai.NgayKetThuc >= DateTime.Now).ToList();

                var view = new Thi1View()
                {
                    sanPhams = sanPhamList,
                    KhuyenMaiSanPhams = khuyenMaiSp,
                };
                return View(view);
            }
            else
            {
                return RedirectToAction("DangNhap", "Home");
            }
        }
        public IActionResult HienThiSanPhamChiTietMua(Guid id)
        {
            var nvnew = SessionServices.NhanVienSS(HttpContext.Session, "ACA");
            if (nvnew.Count() != 0)
            {
                var listsp1 = _sanPhamCuaHangService.GetAllSpcts(id).Where(c => c.Is_detele == true).ToList();
                var anh = _anhService.GetAll().Where(c => c.SanPhamChiTiet.SanPham.Id == id).ToList();
                var giamgia = _giamGiaService.GetAll().Where(c => c.TrangThai == true && c.Is_detele == true && c.NgayBatDau <= DateTime.Now && c.NgayKetThuc >= DateTime.Now).ToList();
                var listsp = _sanPhamCuaHangService.GetAll();
                var mau = _mauSacService.GetAll().ToList();
                var spctcuthe = _CTN4_Ok.SanPhamChiTiets.Include(c => c.Size).ToList().Where(c => c.IdSp == id && c.Is_detele == true);
                var view = new SanPhamBan()
                {
                    sanPham = _sanPhamCuaHangService.GetById(id),
                    Anh = _sanPhamCuaHangService.GeAnhs(id),
                    sanPhamChiTiets = listsp1,
                    maus = mau,
                    sizect = spctcuthe.ToList(),
                    anhs = anh,
                    sanPhams = listsp,
                    giamgias = giamgia
                };
                return View(view);
            }
            else
            {
                return RedirectToAction("DangNhap", "Home");
            }
        }
        public IActionResult TimKiemSp(string Ten)
        {
            var nvnew = SessionServices.NhanVienSS(HttpContext.Session, "ACA");
            if (nvnew.Count() != 0)
            {
                if (Ten==null)
                {
                    var message = "Hãy điền tên sản phẩm muốn tìm";
                    TempData["TB2"] = message;
                    return RedirectToAction("sanphammua", new { message });
                }
                var sanPhamList = _sanPhamService.GetAll().Where(c=>c.TenSanPham.ToLower().Contains(Ten.ToLower())).ToList();
                var khuyenMaiSp = _KhuyenMaiSanPhams.GetAll().Where(c => c.KhuyenMai.TrangThai == true && c.KhuyenMai.Is_Detele == true && c.KhuyenMai.NgayBatDau <= DateTime.Now && c.KhuyenMai.NgayKetThuc >= DateTime.Now).ToList();
                if (sanPhamList.Count == 0){
                    var message = "Không tìm thấy !";
                    TempData["TB2"] = message;
                    return RedirectToAction("sanphammua", new { message });
                }
                var view = new Thi1View()
                {
                    sanPhams = sanPhamList,
                    KhuyenMaiSanPhams = khuyenMaiSp,
                };
                return View("sanphammua",view);
            }
            else
            {
                return RedirectToAction("DangNhap", "Home");
            }
        }
        public IActionResult TimKiemSp2(int BatDau,int KetThuc)
        {
            var nvnew = SessionServices.NhanVienSS(HttpContext.Session, "ACA");
            if (nvnew.Count() != 0)
            {
                if (KetThuc == 0)
                {
                    var message = "Hãy điền số tiên kết thúc để có thể lọc";
                    TempData["TB2"] = message;
                    return RedirectToAction("sanphammua", new { message });
                }
                if (KetThuc <= BatDau)
                {
                    var message = "Hãy điền bắt đầu nhỏ hơn số kết thúc";
                    TempData["TB2"] = message;
                    return RedirectToAction("sanphammua", new { message });
                }
                
                
                var sanPhamList = _sanPhamService.GetAll().Where(c =>BatDau<= c.GiaNiemYet&& c.GiaNiemYet<=KetThuc).ToList();
                var khuyenMaiSp = _KhuyenMaiSanPhams.GetAll().Where(c => c.KhuyenMai.TrangThai == true && c.KhuyenMai.Is_Detele == true && c.KhuyenMai.NgayBatDau <= DateTime.Now && c.KhuyenMai.NgayKetThuc >= DateTime.Now).ToList();

                var view = new Thi1View()
                {
                    sanPhams = sanPhamList,
                    KhuyenMaiSanPhams = khuyenMaiSp,
                };
                return View("sanphammua", view);
            }
            else
            {
                return RedirectToAction("DangNhap", "Home");
            }
        }
        public IActionResult chonMau(Guid IdSanPham, Guid IdMau)
        {
            var nvnew = SessionServices.NhanVienSS(HttpContext.Session, "ACA");
            if (nvnew.Count() != 0)
            {
                var listsp1 = _sanPhamCuaHangService.GetAllSpcts(IdSanPham).Where(c => c.Is_detele == true).ToList();
                var anh = _anhService.GetAll().Where(c => c.SanPhamChiTiet.SanPham.Id == IdSanPham).ToList();

                var listsp = _sanPhamCuaHangService.GetAll();
                var mau = _mauSacService.GetAll().Distinct().ToList();
                var size = _sizeService.GetAll().Distinct().ToList();
                var spctcuthe = _CTN4_Ok.SanPhamChiTiets.Include(c => c.Size).Where(c => c.IdMau == IdMau && c.IdSp == IdSanPham && c.Is_detele == true).ToList();
                var mauluu = _mauSacService.GetAll().FirstOrDefault(c => c.Id == IdMau);
                var giamgia = _giamGiaService.GetAll().Where(c => c.TrangThai == true && c.Is_detele == true && c.NgayBatDau <= DateTime.Now && c.NgayKetThuc >= DateTime.Now).ToList();
                // Đọc dữ liệu từ Session xem trong Cart nó có cái gì chưa?

                var view = new SanPhamBan()
                {
                    sanPham = _sanPhamCuaHangService.GetById(IdSanPham),
                    sanPhamChiTiets = listsp1,
                    maus = mau,
                    sizect = spctcuthe.ToList(),
                    anhs = anh.Where(c => c.SanPhamChiTiet.IdMau == IdMau && c.SanPhamChiTiet.IdSp == IdSanPham).ToList(),
                    sanPhams = listsp,
                    idmau = IdMau,
                    giamgias = giamgia
                };
                return View("HienThiSanPhamChiTietMua", view);
            }
            else
            {
                return RedirectToAction("DangNhap", "Home");
            }
        }
        public IActionResult chonSize(Guid IdSanPham, Guid idSize, Guid IdMau)
        {
            var nvnew = SessionServices.NhanVienSS(HttpContext.Session, "ACA");
            if (nvnew.Count() != 0)
            {
                if (IdMau == Guid.Parse("00000000-0000-0000-0000-000000000000"))
                {
                    var message = "Chọn màu sắc trước !";
                    TempData["ErrorMessage"] = message;
                    return RedirectToAction("HienThiSanPhamChiTietMua", new { id = IdSanPham, message });
                }

                var kichCo = _sizeService.GetById(idSize);
                var listsp1 = _sanPhamCuaHangService.GetAllSpcts(IdSanPham).Where(c => c.Is_detele == true).ToList();
                var anh = _anhService.GetAll().Where(c => c.SanPhamChiTiet.SanPham.Id == IdSanPham).ToList();
                var listsp = _sanPhamCuaHangService.GetAll();
                var mau = _mauSacService.GetAll().Distinct().ToList();
                var size = _CTN4_Ok.SanPhamChiTiets.Include(c => c.Size).Where(c => c.IdMau == IdMau && c.IdSp == IdSanPham).ToList();
                var spcuthe = _CTN4_Ok.SanPhamChiTiets.FirstOrDefault(c => c.IdMau == IdMau && c.IdSp == IdSanPham && c.IdSize == idSize && c.Is_detele == true);
                var giamgia = _giamGiaService.GetAll().Where(c => c.TrangThai == true && c.Is_detele == true && c.NgayBatDau <= DateTime.Now && c.NgayKetThuc >= DateTime.Now).ToList();
                var view = new SanPhamBan()
                {
                    sanPham = _sanPhamCuaHangService.GetById(IdSanPham),
                    sanPhamChiTiets = listsp1,
                    maus = mau,
                    sizect = size.ToList(),
                    anhs = anh.Where(c => c.SanPhamChiTiet.IdMau == IdMau && c.SanPhamChiTiet.IdSp == IdSanPham).ToList(),
                    sanPhams = listsp,
                    idmau = IdMau,
                    idsize = idSize,
                    soluong = spcuthe.SoLuong,
                    KichCo = kichCo.TenSize,
                    giamgias = giamgia

                };
                return View("HienThiSanPhamChiTietMua", view);
            }
            else
            {
                return RedirectToAction("DangNhap", "Home");
            }
        }
        public IActionResult Themsanphamhoadon(int soluong, Guid IdSanPham, Guid IdSize, Guid IdMau)
        {
            var nvnew = SessionServices.NhanVienSS(HttpContext.Session, "ACA");
            if (nvnew.Count() != 0)
            {
                var sanphamCT = _sanPhamChiTietService.GetAll().FirstOrDefault(c => c.IdMau == IdMau && c.IdSp == IdSanPham && c.IdSize == IdSize && c.Is_detele == true);
                if (IdMau == Guid.Parse("00000000-0000-0000-0000-000000000000") || IdSize == Guid.Parse("00000000-0000-0000-0000-000000000000"))
                {
                    var message1 = "hãy chọn màu và size của bạn !";
                    TempData["TB1"] = message1;
                    return RedirectToAction("HienThiSanPhamChiTietMua", new { id = IdSanPham, message1 });
                }
                if (soluong <= 0)
                {
                    var message2 = "Số lượng phải lớn hơn 0 !";
                    TempData["TB2"] = message2;
                    return RedirectToAction("HienThiSanPhamChiTietMua", new { id = IdSanPham, message2 });
                }
                if (soluong > sanphamCT.SoLuong)
                {
                    var message2 = "Số lượng không đủ!";
                    TempData["TB2"] = message2;
                    return RedirectToAction("HienThiSanPhamChiTietMua", new { id = IdSanPham, message2 });
                }
                var KhuyenMaiSp = _KhuyenMaiSanPhams.GetAll().Where(c => c.KhuyenMai.Mua1tang1 == true && c.KhuyenMai.NgayBatDau <= DateTime.Now && c.KhuyenMai.NgayKetThuc >= DateTime.Now && c.KhuyenMai.Is_Detele == true).ToList();
                var g = new List<Guid>();
                foreach (var item in KhuyenMaiSp)
                {
                    // Kiểm tra xem Mau.Id đã xuất hiện trong danh sách chưa
                    if (!g.Contains((Guid)item.IdSanPham))
                    {
                        g.Add((Guid)item.IdSanPham);
                    }
                }
                var sanphamctnew = SessionBan.SanPhamTamSS(HttpContext.Session, "SanPhamTamSS");
                var hd = _hoaDonService.GetById(sanphamctnew[0].idHD);
                var SP = _hoaDonChiTietService.GetAll().FirstOrDefault(c => c.IdSanPhamChiTiet == sanphamCT.Id && c.IdHoaDon == sanphamctnew[0].idHD);
                if (SP == null)
                {
                    var d = new HoaDonChiTiet()
                    {
                        Id = Guid.NewGuid(),
                        IdSanPhamChiTiet = sanphamCT.Id,
                        IdHoaDon = sanphamctnew[0].idHD,
                        SoLuong = soluong,
                        GiaTien = sanphamCT.SanPham.GiaNiemYet,
                        TrangThai = true,
                        Is_detele = true
                    };
                    if (g.Contains(sanphamCT.SanPham.Id))
                    {
                        d.SoLuong *= 2;
                    }
                    if (_hoaDonChiTietService.Them(d) == true)
                    {
                        var product = _sanPhamChiTietService.GetById(sanphamCT.Id);
                        if (g.Count() != 0)
                        {
                            if (g.Contains(sanphamCT.SanPham.Id))
                            {
                                product.SoLuong -= soluong * 2;
                            }
                            else
                            {
                                product.SoLuong -= soluong;
                            }
                        }
                        else
                        {
                            product.SoLuong -= soluong;
                        }

                        if (_sanPhamChiTietService.Sua(product))
                        {
                            var li = new LichSuDonHang()
                            {
                                GhiChu = null,
                                ThaoTac = $"Thêm sản phẩm sản phẩm {product.SanPham.TenSanPham} vào đơn hàng {hd.MaHoaDon} ",
                                IdHoaDonn = hd.Id,
                                ThoiGianlam = DateTime.Now,
                                NguoiThucHien = nvnew[0].TenDangNhap,
                                TrangThai = true,
                                Is_detele = true
                            };
                            _LichSuHoaDonService.Them(li);
                            return RedirectToAction("XemChiTiet", new { id = sanphamctnew[0].idHD });
                        }
                    }
                }
                else
                {
                    if (g.Count() != 0)
                    {
                        if (g.Contains(SP.SanPhamChiTiet.SanPham.Id))
                        {
                            SP.SoLuong += soluong * 2;
                        }
                        else
                        {
                            SP.SoLuong += soluong;
                        }
                    }
                    else
                    {
                        SP.SoLuong += soluong;
                    }
                    if (_hoaDonChiTietService.Sua(SP) == true)
                    {
                        var product = _sanPhamChiTietService.GetById(sanphamCT.Id);
                        if (g.Contains(SP.SanPhamChiTiet.SanPham.Id))
                        {
                            product.SoLuong -= soluong * 2;
                        }
                        else
                        {
                            product.SoLuong -= soluong;
                        }
                        if (_sanPhamChiTietService.Sua(product))
                        {
                            var li = new LichSuDonHang()
                            {
                                GhiChu = null,
                                ThaoTac = $"Cập nhật số lượng sản phẩm {product.SanPham.TenSanPham} của đơn hàng {hd.MaHoaDon} ",
                                IdHoaDonn = hd.Id,
                                ThoiGianlam = DateTime.Now,
                                NguoiThucHien = nvnew[0].TenDangNhap,
                                TrangThai = true,
                                Is_detele = true
                            };
                            _LichSuHoaDonService.Them(li);
                            return RedirectToAction("XemChiTiet", new { id = sanphamctnew[0].idHD });
                        }

                    }
                }

                var message3 = "Thêm Thất bại";
                TempData["TB2"] = message3;
                return RedirectToAction("HienThiSanPhamChiTietMua", new { id = IdSanPham, message3 });
            }
            else
            {
                return RedirectToAction("DangNhap", "Home");
            }

        }
        public IActionResult SuDunggiamGia(Guid IdGiamGia2, float tienhanga, string DiachiNhanChiTiet, string name, string Sodienthoai, string Email, string addDiaChi, string ghiChu, float tienshipa, float tongtien, int idHD)
        {
            var nvnew = SessionServices.NhanVienSS(HttpContext.Session, "ACA");
            if (nvnew.Count() != 0)
            {
                float tong = 0;
                var hd = _hoaDonService.GetById(idHD);
                HttpResponseMessage responseProvin = _httpClient.GetAsync("https://online-gateway.ghn.vn/shiip/public-api/master-data/province").Result;
                Provin lstprovin = new Provin();
                if (responseProvin.IsSuccessStatusCode)
                {
                    string jsonData2 = responseProvin.Content.ReadAsStringAsync().Result;
                    lstprovin = JsonConvert.DeserializeObject<Provin>(jsonData2);
                    ViewBag.Provin = new SelectList(lstprovin.data, "ProvinceID", "ProvinceName");
                }

                if (addDiaChi != null)
                {

                    var sanphamctnew = SessionBan.SanPhamTamSS(HttpContext.Session, "SanPhamTamSS");
                    if (sanphamctnew.Count == 0)
                    {
                        var spt = new SanPhamTam()
                        {
                            idHD = idHD
                        };
                        sanphamctnew.Add(spt);
                        SessionBan.SetObjToJson(HttpContext.Session, "SanPhamTamSS", sanphamctnew);
                    }
                    else
                    {
                        sanphamctnew.RemoveAt(0);
                        var spt = new SanPhamTam()
                        {
                            idHD = idHD
                        };
                        sanphamctnew.Add(spt);
                        SessionBan.SetObjToJson(HttpContext.Session, "SanPhamTamSS", sanphamctnew);
                    }

                    var gh = _hoaDonService.GetAll().FirstOrDefault(c => c.Id == idHD);
                    IEnumerable<HoaDonChiTiet> ghct = _hoaDonChiTietService.GetAll().Where(c => c.IdHoaDon == idHD);
                    foreach (var x in ghct)
                    {
                        tong += float.Parse(x.SanPhamChiTiet.SanPham.GiaNiemYet.ToString()) * (x.SoLuong);

                    }

                    var a = _hoaDonChiTietService.GetAll().Where(c => c.IdHoaDon == idHD).ToList();
                    var giamgia = _giamGiaService.GetAll().Where(c =>
                        c.TrangThai == true && c.Is_detele == true && c.NgayBatDau <= DateTime.Now &&
                        c.NgayKetThuc >= DateTime.Now).ToList();
                    float tiensaugiam;
                    var giamgia1 = _giamGiaService.GetById(IdGiamGia2);
                    if (giamgia1 == null || giamgia1.NgayBatDau > DateTime.Now || giamgia1.NgayKetThuc < DateTime.Now)
                    {
                        var message = $"Giảm giá {giamgia1.MaGiam} hiện không thể sửa dụng";
                        TempData["TB2"] = message;
                        return RedirectToAction("TaoHoaDon", new { id = idHD, message });
                    }
                    if (giamgia1.SoLuong < 1)
                    {
                        var message = $"Giảm giá {giamgia1.MaGiam} hiện đã hết";
                        TempData["TB2"] = message;
                        return RedirectToAction("TaoHoaDon", new { id = idHD, message });
                    }
                    if (giamgia1.LoaiGiamGia == false)
                    {
                        if (giamgia1.DieuKienGiam <= tienhanga)
                        {
                            tiensaugiam = tienhanga - giamgia1.SoTienGiam;
                        }
                        else
                        {
                            {
                                var message = "Tiền đơn hàng chưa đủ điều kiện để sử dụng mã giảm giá này";
                                TempData["TB2"] = message;
                                return RedirectToAction("TaoHoaDon", new { id = idHD, message });
                            }
                        }
                    }
                    else
                    {
                        if (giamgia1.DieuKienGiam <= tienhanga)
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
                                return RedirectToAction("TaoHoaDon", new { id = idHD, message });
                            }
                        }
                    }

                    var gg = _giamGiaService.GetById(IdGiamGia2);
                    // Đọc dữ liệu từ Session xem trong Cart nó có cái gì chưa?
                    var giamgianew = SessionBan.GiamGiaSS(HttpContext.Session, "GiamGia2");
                    if (giamgianew.Count == 0)
                    {
                        giamgianew.Add(gg);
                        SessionBan.SetObjToJson(HttpContext.Session, "GiamGia2", giamgianew);
                    }
                    else if (giamgianew.Count != 0)
                    {
                        giamgianew.Clear();
                        giamgianew.Add(gg);
                        SessionBan.SetObjToJson(HttpContext.Session, "GiamGia2", giamgianew);
                    }
                    float tiengiam = (tienhanga + tienshipa) - (tiensaugiam + tienshipa);
                    var KhuyenMaiSp = _KhuyenMaiSanPhams.GetAll().Where(c => c.KhuyenMai.Mua1tang1 == true && c.KhuyenMai.NgayBatDau <= DateTime.Now && c.KhuyenMai.NgayKetThuc >= DateTime.Now && c.KhuyenMai.Is_Detele == true).ToList();
                    var g = new List<Guid>();
                    foreach (var item in KhuyenMaiSp)
                    {
                        // Kiểm tra xem Mau.Id đã xuất hiện trong danh sách chưa
                        if (!g.Contains((Guid)item.IdSanPham))
                        {
                            g.Add((Guid)item.IdSanPham);
                        }
                    }
                    foreach (var x in ghct)
                    {

                        if (g.Contains(x.SanPhamChiTiet.SanPham.Id))
                        {
                            tong += float.Parse(x.SanPhamChiTiet.SanPham.GiaNiemYet.ToString()) * (x.SoLuong / 2);
                        }
                        else
                        {
                            tong += float.Parse(x.SanPhamChiTiet.SanPham.GiaNiemYet.ToString()) * (x.SoLuong);
                        }


                    }
                    var view = new Thi1View()
                    {
                        check11 = g,
                        HoaDon = hd,
                        GiamGias = giamgia,
                        HoaDonChiTiets = a,
                        TongTien = tong,
                        IdMaGiam = IdGiamGia2,
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
                    };

                    return View("TaoHoaDon", view);
                }
                else
                {
                    if (responseProvin.IsSuccessStatusCode)
                    {
                        string jsonData2 = responseProvin.Content.ReadAsStringAsync().Result;
                        lstprovin = JsonConvert.DeserializeObject<Provin>(jsonData2);
                        ViewBag.Provin = new SelectList(lstprovin.data, "ProvinceID", "ProvinceName");
                    }
                    var sanphamctnew = SessionBan.SanPhamTamSS(HttpContext.Session, "SanPhamTamSS");
                    if (sanphamctnew.Count == 0)
                    {
                        var spt = new SanPhamTam()
                        {
                            idHD = idHD
                        };
                        sanphamctnew.Add(spt);
                        SessionBan.SetObjToJson(HttpContext.Session, "SanPhamTamSS", sanphamctnew);
                    }
                    else
                    {
                        sanphamctnew.RemoveAt(0);
                        var spt = new SanPhamTam()
                        {
                            idHD = idHD
                        };
                        sanphamctnew.Add(spt);
                        SessionBan.SetObjToJson(HttpContext.Session, "SanPhamTamSS", sanphamctnew);
                    }
                    var gh = _hoaDonService.GetAll().FirstOrDefault(c => c.Id == idHD);
                    IEnumerable<HoaDonChiTiet> ghct = _hoaDonChiTietService.GetAll().Where(c => c.IdHoaDon == idHD);
                    foreach (var x in ghct)
                    {
                        tong += float.Parse(x.SanPhamChiTiet.SanPham.GiaNiemYet.ToString()) * (x.SoLuong);

                    }
                    var a = _hoaDonChiTietService.GetAll().Where(c => c.IdHoaDon == idHD).ToList();
                    var giamgia = _giamGiaService.GetAll().Where(c => c.TrangThai == true && c.Is_detele == true && c.NgayBatDau <= DateTime.Now && c.NgayKetThuc >= DateTime.Now).ToList();
                    float tiensaugiam;
                    var giamgia1 = _giamGiaService.GetById(IdGiamGia2);
                    if (giamgia1 == null || giamgia1.NgayBatDau > DateTime.Now || giamgia1.NgayKetThuc < DateTime.Now)
                    {
                        var message = $"Giảm giá {giamgia1.MaGiam} hiện không thể sửa dụng";
                        TempData["TB2"] = message;
                        return RedirectToAction("TaoHoaDon", new { id = idHD, message });
                    }
                    if (giamgia1.SoLuong < 1)
                    {
                        var message = $"Giảm giá {giamgia1.MaGiam} hiện đã hết";
                        TempData["TB2"] = message;
                        return RedirectToAction("TaoHoaDon", new { id = idHD, message });
                    }
                    if (giamgia1.LoaiGiamGia == false)
                    {
                        if (giamgia1.DieuKienGiam <= tienhanga)
                        {
                            tiensaugiam = tienhanga - giamgia1.SoTienGiam;
                        }
                        else
                        {
                            {
                                var message = "Tiền đơn hàng chưa đủ điều kiện để sử dụng mã giảm giá này";
                                TempData["TB2"] = message;
                                return RedirectToAction("TaoHoaDon", new { id = idHD, message });
                            }
                        }
                    }
                    else
                    {
                        if (giamgia1.DieuKienGiam <= tienhanga)
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
                                return RedirectToAction("TaoHoaDon", new { id = idHD, message });
                            }
                        }
                    }

                    var gg = _giamGiaService.GetById(IdGiamGia2);
                    // Đọc dữ liệu từ Session xem trong Cart nó có cái gì chưa?
                    var giamgianew = SessionBan.GiamGiaSS(HttpContext.Session, "GiamGia2");
                    if (giamgianew.Count == 0)
                    {
                        giamgianew.Add(gg);
                        SessionBan.SetObjToJson(HttpContext.Session, "GiamGia2", giamgianew);
                    }
                    else if (giamgianew.Count != 0)
                    {
                        giamgianew.Clear();
                        giamgianew.Add(gg);
                        SessionBan.SetObjToJson(HttpContext.Session, "GiamGia2", giamgianew);
                    }
                    float tiengiam = (tienhanga + tienshipa) - (tiensaugiam + tienshipa);
                    var KhuyenMaiSp = _KhuyenMaiSanPhams.GetAll().Where(c => c.KhuyenMai.Mua1tang1 == true && c.KhuyenMai.NgayBatDau <= DateTime.Now && c.KhuyenMai.NgayKetThuc >= DateTime.Now && c.KhuyenMai.Is_Detele == true).ToList();
                    var g = new List<Guid>();
                    foreach (var item in KhuyenMaiSp)
                    {
                        // Kiểm tra xem Mau.Id đã xuất hiện trong danh sách chưa
                        if (!g.Contains((Guid)item.IdSanPham))
                        {
                            g.Add((Guid)item.IdSanPham);
                        }
                    }
                    foreach (var x in ghct)
                    {

                        if (g.Contains(x.SanPhamChiTiet.SanPham.Id))
                        {
                            tong += float.Parse(x.SanPhamChiTiet.SanPham.GiaNiemYet.ToString()) * (x.SoLuong / 2);
                        }
                        else
                        {
                            tong += float.Parse(x.SanPhamChiTiet.SanPham.GiaNiemYet.ToString()) * (x.SoLuong);
                        }


                    }
                    var view = new Thi1View()
                    {
                        check11 = g,
                        HoaDon = hd,
                        GiamGias = giamgia,
                        HoaDonChiTiets = a,
                        TongTien = tong,
                        IdMaGiam = IdGiamGia2,
                        tienshipb = tienshipa,
                        tiengiamb = tiengiam,
                        tenmagiam = giamgia1.MaGiam,
                        tienhanga = tienhanga,
                        TienCuoiCungb = tiensaugiam + tienshipa,
                        name = name,
                        ghiChu = ghiChu,
                        Email = Email,
                        Sodienthoai = Sodienthoai,
                        DiachiNhanChiTiet = DiachiNhanChiTiet,
                    };

                    return View("TaoHoaDon", view);

                }
            }
            else
            {
                return RedirectToAction("DangNhap", "Home");
            }
        }
        public IActionResult Chốt(string tenmagiam, bool loaimua, float tiengiama, float tienhanga, string name, string DiachiNhanChiTiet, string Sodienthoai, string Email, string addDiaChi, string ghiChu, float tienshipa, float tongtien, int idHD)
        {
            var nvnew = SessionServices.NhanVienSS(HttpContext.Session, "ACA");
            if (nvnew.Count() != 0)
            {
                if (loaimua == true)
                {
                    if (name == null || (Sodienthoai == null && Email == null))
                    {
                        {
                            var message = "hãy nhớ điền số điện thoại hoặc Email của bạn còn tên là bắt buộc";
                            TempData["TB2"] = message;
                            return RedirectToAction("TaoHoaDon", new { id = idHD, message });
                        }
                    }
                    if (Sodienthoai!=null)
                    {
                        if (Sodienthoai.Length < 10 || Sodienthoai.Length > 13)
                        {
                            {
                                var message = "Số điện thoại phải từ 10 số trở lên";
                                TempData["TB2"] = message;
                                return RedirectToAction("TaoHoaDon", new { id = idHD, message });
                            }
                        }
                    }
                    if (Email != null)
                    {
                        if (!IsValidGmail(Email))
                        {
                            var message = "Email không hợp lệ";
                            TempData["TB2"] = message;
                            return RedirectToAction("TaoHoaDon", new { id = idHD, message });
                        }
                    }
                    var hd = _hoaDonService.GetById(idHD);
                    var hdct = _hoaDonChiTietService.GetAll().Where(c => c.IdHoaDon == idHD);
                    if (hdct.Count() == 0)
                    {
                        var message = "hãy nhớ thêm sản phẩm trước khi chốt";
                        TempData["TB2"] = message;
                        return RedirectToAction("TaoHoaDon", new { id = idHD, message });
                    }
                    if (hd != null)
                    {
                        hd.TrangThai = "Đang chờ xử lí";
                        hd.TongTien = tongtien;
                        hd.TienShip = tienshipa;
                        hd.TienGiam = tiengiama;
                        hd.TienHang = tienhanga;
                        hd.TenKhachHang = name;
                        hd.DiaChi = "Nhận tại quầy";
                        hd.NgayNhan = DateTime.Now;
                        if (Sodienthoai != null)
                        {
                            hd.SDTNguoiNhan = Sodienthoai;
                        }
                        if (Email != null)
                        {
                            hd.Email = Email;
                        }
                        if (_hoaDonService.Sua(hd) == false)
                        {
                            var message = "Lỗi hóa đơn (2)";
                            TempData["TB2"] = message;
                            return RedirectToAction("TaoHoaDon", new { id = idHD, message });
                        }
                        var lichsuhd = new LichSuDonHang()
                        {
                            GhiChu = null,
                            ThaoTac = $"Chốt hóa đơn {hd.MaHoaDon} ",
                            IdHoaDonn = hd.Id,
                            ThoiGianlam = DateTime.Now,
                            NguoiThucHien = nvnew[0].TenDangNhap,
                            TrangThai = true,
                            Is_detele = true
                        };
                        if (_LichSuHoaDonService.Them(lichsuhd) == false)
                        {
                            var message = "Lỗi hóa đơn (3)";
                            TempData["TB2"] = message;
                            return RedirectToAction("TaoHoaDon", new { id = idHD, message });
                        }
                        var giamgianew = SessionBan.GiamGiaSS(HttpContext.Session, "GiamGia2");
                        if (tiengiama != 0)
                        {
                            var giamct = new GiamGiaChiTiet()
                            {
                                IdHoaDon = hd.Id,
                                IdGiamGia = giamgianew[0].Id
                            };
                            var a = _giamGiaService.GetById(giamgianew[0].Id);
                            a.SoLuong -= 1;
                            if (_GiamGiaChiTietService.Them(giamct) == false || _giamGiaService.Sua(a) == false)
                            {
                                var message = "lỗi mã giảm giá";
                                TempData["ErrorMessage"] = message;
                                return RedirectToAction("TaoHoaDon", new { id = idHD, message });
                            }
                        }
                    }
                    else
                    {
                        var message = "Lỗi hóa đơn (1)";
                        TempData["TB2"] = message;
                        return RedirectToAction("TaoHoaDon", new { id = idHD, message });
                    }

                    return RedirectToAction("Index");
                }

                else
                {
                    #region Check validate
                    if (name == null)
                    {
                        {
                            var message = "hãy nhớ điền tên của bạn của bạn";
                            TempData["TB2"] = message;
                            return RedirectToAction("TaoHoaDon", new { id = idHD, message });
                        }
                    }
                    if (DiachiNhanChiTiet == null)
                    {
                        {
                            var message = "hãy nhớ điền địa chỉ chi tiết của bạn";
                            TempData["TB2"] = message;
                            return RedirectToAction("TaoHoaDon", new { id = idHD, message });
                        }
                    }

                    if (Sodienthoai != null)
                    {
                        if (Sodienthoai.Length < 10 || Sodienthoai.Length > 13)
                        {
                            {
                                var message = "Số điện thoại phải từ 10 số trở lên";
                                TempData["TB2"] = message;
                                return RedirectToAction("TaoHoaDon", new { id = idHD, message });
                            }
                        }
                    }
                    if (Email != null)
                    {
                        if (!IsValidGmail(Email))
                        {
                            var message = "Email không hợp lệ";
                            TempData["TB2"] = message;
                            return RedirectToAction("TaoHoaDon", new { id = idHD, message });
                        }
                    }
                    if (Sodienthoai == null)
                    {
                        {
                            var message = "hãy nhớ điền số điện thoại của bạn";
                            TempData["TB2"] = message;
                            return RedirectToAction("TaoHoaDon", new { id = idHD, message });
                        }
                    }
                    if (Email == null)
                    {
                        {
                            var message = "hãy nhớ điền Email của bạn";
                            TempData["TB2"] = message;
                            return RedirectToAction("TaoHoaDon", new { id = idHD, message });
                        }
                    }
                    if (addDiaChi == null)
                    {
                        {
                            var message = "hãy nhớ chọn địa chỉ của bạn";
                            TempData["TB2"] = message;
                            return RedirectToAction("TaoHoaDon", new { id = idHD, message });
                        }
                    }

                    #endregion
                    var hd = _hoaDonService.GetById(idHD);
                    if (hd != null)
                    {
                        hd.TrangThai = "Đang chờ xử lí";
                        hd.TongTien = tongtien;
                        hd.TienShip = tienshipa;
                        hd.TienGiam = tiengiama;
                        hd.TienHang = tienhanga;
                        hd.TenKhachHang = name;
                        hd.Email = Email;
                        hd.SDTNguoiNhan = Sodienthoai;
                        hd.DiaChi = DiachiNhanChiTiet + " " + addDiaChi;
                        hd.GhiChu = ghiChu;
                        if (_hoaDonService.Sua(hd) == false)
                        {
                            var message = "Lỗi hóa đơn (2)";
                            TempData["TB2"] = message;
                            return RedirectToAction("TaoHoaDon", new { id = idHD, message });
                        }
                        var lichsuhd = new LichSuDonHang()
                        {
                            GhiChu = null,
                            ThaoTac = $"Tạo hóa đơn {hd.MaHoaDon} ",
                            IdHoaDonn = hd.Id,
                            ThoiGianlam = DateTime.Now,
                            NguoiThucHien = nvnew[0].TenDangNhap,
                            TrangThai = true,
                            Is_detele = true
                        };
                        if (_LichSuHoaDonService.Them(lichsuhd) == false)
                        {
                            var message = "Lỗi hóa đơn (3)";
                            TempData["TB2"] = message;
                            return RedirectToAction("TaoHoaDon", new { id = idHD, message });
                        }
                        var giamgianew = SessionBan.GiamGiaSS(HttpContext.Session, "GiamGia2");
                        if (tiengiama != 0)
                        {
                            var giamct = new GiamGiaChiTiet()
                            {
                                IdHoaDon = hd.Id,
                                IdGiamGia = giamgianew[0].Id
                            };
                            var a = _giamGiaService.GetById(giamgianew[0].Id);
                            a.SoLuong -= 1;
                            if (_GiamGiaChiTietService.Them(giamct) == false || _giamGiaService.Sua(a) == false)
                            {
                                var message = "lỗi mã giảm giá";
                                TempData["ErrorMessage"] = message;
                                return RedirectToAction("TaoHoaDon", new { id = idHD, message });
                            }
                        }
                    }
                    else
                    {
                        var message = "Lỗi hóa đơn (1)";
                        TempData["TB2"] = message;
                        return RedirectToAction("TaoHoaDon", new { id = idHD, message });
                    }

                    return RedirectToAction("Index");
                }

            }
            else
            {
                return RedirectToAction("DangNhap", "Home");
            }

        }
        public IActionResult ThongTinVocher(Guid idVoucher, Guid idSp)
        {
            var nvnew = SessionServices.NhanVienSS(HttpContext.Session, "ACA");
            if (nvnew.Count() != 0)
            {
                var giamgiact = _giamGiaService.GetById(idVoucher);
                if (giamgiact.LoaiGiamGia == false)
                {

                    var message = $"Nhập Mã {giamgiact.MaGiam} còn ( {giamgiact.SoLuong} lượt). \n" +
                   $"Giảm {giamgiact.SoTienGiam.ToString("N0")}VND cho đơn hàng từ {giamgiact.DieuKienGiam.ToString("N0")}VND";

                    TempData["Notification"] = message;
                    return RedirectToAction("HienThiSanPhamChiTietMua", new { id = idSp, message });
                }
                else
                {
                    var message = $"Nhập Mã {giamgiact.MaGiam} còn ( {giamgiact.SoLuong} lượt). \n" +
                  $"Giảm {giamgiact.PhanTramGiam}% cho đơn hàng từ {giamgiact.DieuKienGiam.ToString("N0")}VND";

                    TempData["Notification"] = message;
                    return RedirectToAction("HienThiSanPhamChiTietMua", new { id = idSp, message });
                }
            }
            else
            {
                return RedirectToAction("DangNhap", "Home");
            }
        }
        [HttpPost("/CheckOut/GetTotalShipping2")]
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
            var hd = _hoaDonService.GetById(shippingOrder.idDon);
            var hdct = _hoaDonChiTietService.GetAll().Where(c => c.IdHoaDon == hd.Id && c.TrangThai == true && c.Is_detele == true);
            int dem = 0;
            foreach (var a in hdct)
            {
                dem += a.SoLuong;
            }
            var url = $"https://online-gateway.ghn.vn/shiip/public-api/v2/shipping-order/fee";
            float tong = 0;
            var content = new StringContent(JsonConvert.SerializeObject(hang), Encoding.UTF8, "application/json");
            var respose = await _httpClient.PostAsync(url, content);
            Shipping shipping = new Shipping();
            if (respose.IsSuccessStatusCode)
            {
                //var luuGio = SessionBan.IdGio(HttpContext.Session, "LuoGio");
                //int dem = 0;
                //var ghct = _GioHangChiTiet.GetAll().Where(c => luuGio.Contains(c.Id));
                //foreach (var a in ghct)
                //{
                //    dem += a.SoLuong;
                //}
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
        public IActionResult CapNhanSoLuong(int soluong, Guid idHdct)
        {
            var nvnew = SessionServices.NhanVienSS(HttpContext.Session, "ACA");
            if (nvnew.Count() != 0)
            {
                var b = _hoaDonChiTietService.GetById(idHdct);
                if (soluong == b.SoLuong)
                {
                    var message = "hãy điền số lượng mong muốn của bạn để được cập nhật";
                    TempData["TB2"] = message;
                    return RedirectToAction("TaoHoaDon", new { id = b.IdHoaDon, message });
                }
                if (soluong > 20)
                {
                    var message = "Số lượng đã vượi quá 20 và hãy liên hệ với quản lý nếu muốn mua sỉ";
                    TempData["TB2"] = message;
                    return RedirectToAction("TaoHoaDon", new { id = b.IdHoaDon, message });
                }
                if (soluong < 1)
                {
                    var message = "Số lượng hiện không thể nhỏ hơn 1";
                    TempData["TB2"] = message;
                    return RedirectToAction("TaoHoaDon", new { id = b.IdHoaDon, message });
                }
                var KhuyenMaiSp = _KhuyenMaiSanPhams.GetAll().Where(c => c.KhuyenMai.Mua1tang1 == true && c.KhuyenMai.NgayBatDau <= DateTime.Now && c.KhuyenMai.NgayKetThuc >= DateTime.Now && c.KhuyenMai.Is_Detele == true).ToList();
                var g = new List<Guid>();
                foreach (var item in KhuyenMaiSp)
                {
                    // Kiểm tra xem Mau.Id đã xuất hiện trong danh sách chưa
                    if (!g.Contains((Guid)item.IdSanPham))
                    {
                        g.Add((Guid)item.IdSanPham);
                    }
                }
                var product = _sanPhamChiTietService.GetById(b.IdSanPhamChiTiet.Value);

                if (g.Contains((Guid)product.IdSp))
                {
                    if (soluong > 10)
                    {
                        var message = "Số lượng sản phẩm này không thể lớn hơn 10 vì đang được mua 1 tặng 1,nếu muốn mua nhiều hãy liên hệ với shop để được mua sỉ";
                        TempData["TB2"] = message;
                        return RedirectToAction("TaoHoaDon", new { id = b.IdHoaDon, message });
                    }
                }

                int soluothem = 0;
                soluothem = soluong - b.SoLuong;
                if (soluothem > product.SoLuong)
                {
                    var message = "Số lượng của sản phẩm này không đủ";
                    TempData["TB2"] = message;
                    return RedirectToAction("TaoHoaDon", new { id = b.IdHoaDon, message });
                }
                else
                {

                    b.SoLuong += soluothem;
                    product.SoLuong -= soluothem;

                    _sanPhamChiTietService.Sua(product);
                    _hoaDonChiTietService.Sua(b);
                    var message = "Thay đổi số lượng thành công";
                    TempData["ErrorMessage2"] = message;
                    return RedirectToAction("TaoHoaDon", new { id = b.IdHoaDon, message });
                }
            }
            else
            {
                return RedirectToAction("DangNhap", "Home");
            }
        }
        public IActionResult CapNhanSoLuong2(int soluong, Guid idHdct)
        {
            var nvnew = SessionServices.NhanVienSS(HttpContext.Session, "ACA");
            if (nvnew.Count() != 0)
            {
                var b = _hoaDonChiTietService.GetById(idHdct);
                if (soluong == b.SoLuong)
                {
                    var message = "hãy điền số lượng mong muốn của bạn để được cập nhật";
                    TempData["TB1"] = message;
                    return RedirectToAction("XemChiTiet", new { id = b.IdHoaDon, message });
                }

                if (soluong > 20)
                {
                    var message = "Số lượng đã vượi quá 20 hãy bảo khách liên hệ với shop để có thể mua sỉ";
                    TempData["TB1"] = message;
                    return RedirectToAction("XemChiTiet", new { id = b.IdHoaDon, message });
                }

                if (soluong < 1)
                {
                    var message = "Số lượng hiện không thể nhỏ hơn 1";
                    TempData["TB1"] = message;
                    return RedirectToAction("XemChiTiet", new { id = b.IdHoaDon, message });
                }

                var KhuyenMaiSp = _KhuyenMaiSanPhams.GetAll().Where(c =>
                    c.KhuyenMai.Mua1tang1 == true && c.KhuyenMai.NgayBatDau <= DateTime.Now &&
                    c.KhuyenMai.NgayKetThuc >= DateTime.Now && c.KhuyenMai.Is_Detele == true).ToList();
                var g = new List<Guid>();
                foreach (var item in KhuyenMaiSp)
                {
                    // Kiểm tra xem Mau.Id đã xuất hiện trong danh sách chưa
                    if (!g.Contains((Guid)item.IdSanPham))
                    {
                        g.Add((Guid)item.IdSanPham);
                    }
                }

                var product = _sanPhamChiTietService.GetById(b.IdSanPhamChiTiet.Value);
                if (g.Contains((Guid)product.IdSp))
                {
                    if (soluong > 10)
                    {
                        var message =
                            "Số lượng sản phẩm này không thể lớn hơn 10 vì đang được mua 1 tặng 1,nếu muốn mua nhiều hãy liên hệ với shop để được mua sỉ";
                        TempData["TB1"] = message;
                        return RedirectToAction("XemChiTiet", new { id = b.IdHoaDon, message });
                    }
                }

                int soluothem = 0;
                soluothem = soluong - b.SoLuong;
                var hd = _hoaDonService.GetById(b.IdHoaDon);
                var hdcta = _hoaDonChiTietService.GetAll().Where(c => c.IdHoaDon == hd.Id);
                int dem = 0;
                float trungbinh1hang = 0;
                foreach (var e in hdcta)
                {
                    dem += e.SoLuong;
                }

                trungbinh1hang = (float)(hd.TienShip / dem);
                if (soluothem > product.SoLuong)
                {
                    var message = "Số lượng của sản phẩm này không đủ";
                    TempData["TB1"] = message;
                    return RedirectToAction("XemChiTiet", new { id = b.IdHoaDon, message });
                }
                else
                {
                    var li = new LichSuDonHang()
                    {
                        GhiChu = null,
                        ThaoTac =
                            $"Sửa số lượng hàng của đơn hàng {b.HoaDon.MaHoaDon}, sản phâm {b.SanPhamChiTiet.SanPham.TenSanPham},size{b.SanPhamChiTiet.Size.CoSize} ,màu {b.SanPhamChiTiet.Mau.TenMau}, từ {b.SoLuong} thành {soluong}",
                        IdHoaDonn = b.IdHoaDon,
                        ThoiGianlam = DateTime.Now,
                        NguoiThucHien = nvnew[0].TenDangNhap,
                        TrangThai = true,
                        Is_detele = true
                    };
                    _LichSuHoaDonService.Them(li);
                    b.SoLuong += soluothem;
                    product.SoLuong -= soluothem;
                    _sanPhamChiTietService.Sua(product);
                    _hoaDonChiTietService.Sua(b);
                    dem -= b.SoLuong;
                    hd.TienShip -= trungbinh1hang * dem;
                    float tong = 0;
                    foreach (var e in hdcta)
                    {
                        tong += e.SoLuong * e.GiaTien;
                    }
                    hd.TongTien = tong + hd.TienShip - hd.TienGiam;
                    _hoaDonService.Sua(hd);
                    var message = "Thay đổi số lượng thành công";
                    TempData["ErrorMessage2"] = message;
                    return RedirectToAction("XemChiTiet", new { id = b.IdHoaDon, message });
                }
            }
            else
            {
                return RedirectToAction("DangNhap", "Home");
            }
        }
        #endregion
    }
}

