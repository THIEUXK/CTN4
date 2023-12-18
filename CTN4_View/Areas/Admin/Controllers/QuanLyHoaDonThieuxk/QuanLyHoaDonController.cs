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
using Newtonsoft.Json;
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
                foreach (var a in hdct)
                {
                    tongTienSP += a.GiaTien;
                }
                var c = _GiamGiaChiTietService.GetAll().Where(c => c.IdHoaDon == id).ToList();
                var view = new ThieuxkViewAdmin()
                {
                    GiamGiaChiTiets = c,
                    HoaDon = hd,
                    hoaDonChiTiets = hdct,
                    soLuongTong = tongSoLuongSP,
                    TongTienHang = tongTienSP,
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
        public IActionResult XacNhanNhanHang2(int id)
        {
            var nvnew = SessionServices.NhanVienSS(HttpContext.Session, "ACA");
            if (nvnew.Count() != 0)
            {
                var hd = _hoaDonService.GetById(id);
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
                var hdct1 = _hoaDonChiTietService.GetAll().Where(c => c.IdHoaDon == id).ToList();
                var lshd = _LichSuHoaDonService.GetAll().Where(c => c.IdHoaDonn == id).ToList();
                int tongSoLuongSP = 0;
                float tongTienSP = 0;
                foreach (var a in hdct1)
                {
                    tongSoLuongSP += a.SoLuong;
                }
                foreach (var a in hdct1)
                {
                    tongTienSP += a.GiaTien;
                }
                var c = _GiamGiaChiTietService.GetAll().Where(c => c.IdHoaDon == id).ToList();
                var view = new ThieuxkViewAdmin()
                {
                    GiamGiaChiTiets = c,
                    HoaDon = hd,
                    hoaDonChiTiets = hdct1,
                    LichSuHoaDon = lshd.OrderByDescending(c => c.ThoiGianlam).ToList(),
                    TongTienHang = tongTienSP,
                    soLuongTong = tongSoLuongSP
                };
                return View("XemChiTiet", view);
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

                var hdct1 = _hoaDonChiTietService.GetAll().Where(c => c.IdHoaDon == id).ToList();
                var lshd = _LichSuHoaDonService.GetAll().Where(c => c.IdHoaDonn == id).ToList();
                int tongSoLuongSP = 0;
                float tongTienSP = 0;
                foreach (var a in hdct1)
                {
                    tongSoLuongSP += a.SoLuong;
                }
                foreach (var a in hdct1)
                {
                    tongTienSP += a.GiaTien;
                }
                var c = _GiamGiaChiTietService.GetAll().Where(c => c.IdHoaDon == id).ToList();
                var view = new ThieuxkViewAdmin()
                {
                    GiamGiaChiTiets = c,
                    HoaDon = hd,
                    hoaDonChiTiets = hdct1,
                    LichSuHoaDon = lshd.OrderByDescending(c => c.ThoiGianlam).ToList(),
                    TongTienHang = tongTienSP,
                    soLuongTong = tongSoLuongSP
                };
                return View("XemChiTiet", view);
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
                            Is_detele = true
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



                var hdct1 = _hoaDonChiTietService.GetAll().Where(c => c.IdHoaDon == id).ToList();
                var lshd = _LichSuHoaDonService.GetAll().Where(c => c.IdHoaDonn == id).ToList();
                int tongSoLuongSP = 0;
                float tongTienSP = 0;
                foreach (var a in hdct1)
                {
                    tongSoLuongSP += a.SoLuong;
                }
                foreach (var a in hdct1)
                {
                    tongTienSP += a.GiaTien;
                }
                var c = _GiamGiaChiTietService.GetAll().Where(c => c.IdHoaDon == id).ToList();
                var view = new ThieuxkViewAdmin()
                {
                    GiamGiaChiTiets = c,
                    HoaDon = hd,
                    hoaDonChiTiets = hdct1,
                    LichSuHoaDon = lshd.OrderByDescending(c => c.ThoiGianlam).ToList(),
                    TongTienHang = tongTienSP,
                    soLuongTong = tongSoLuongSP
                };
                return View("XemChiTiet", view);
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
                    }
                }
                else
                {
                    var message = "Đơn hàng phải được giao vào thanh toán !";
                    TempData["TB2"] = message;
                    return RedirectToAction("XemChiTiet", new { id = id, message });
                }


                var hdct1 = _hoaDonChiTietService.GetAll().Where(c => c.IdHoaDon == id).ToList();
                var lshd = _LichSuHoaDonService.GetAll().Where(c => c.IdHoaDonn == id).ToList();
                int tongSoLuongSP = 0;
                float tongTienSP = 0;
                foreach (var a in hdct1)
                {
                    tongSoLuongSP += a.SoLuong;
                }
                foreach (var a in hdct1)
                {
                    tongTienSP += a.GiaTien;
                }
                var c = _GiamGiaChiTietService.GetAll().Where(c => c.IdHoaDon == id).ToList();
                var view = new ThieuxkViewAdmin()
                {
                    GiamGiaChiTiets = c,
                    HoaDon = hd,
                    hoaDonChiTiets = hdct1,
                    LichSuHoaDon = lshd.OrderByDescending(c => c.ThoiGianlam).ToList(),
                    TongTienHang = tongTienSP,
                    soLuongTong = tongSoLuongSP
                };
                return View("XemChiTiet", view);
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
                if (hd.NgayGiao != null)
                {
                    hd.TrangThai = "Giao hàng thất bại";
                    if (_hoaDonService.Sua(hd) == true)
                    {
                        var li = new LichSuDonHang()
                        {
                            GhiChu = null,
                            ThaoTac = $"Giao hàng thất bại đơn hàng {hd.MaHoaDon} ",
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


                var hdct1 = _hoaDonChiTietService.GetAll().Where(c => c.IdHoaDon == id).ToList();
                var lshd = _LichSuHoaDonService.GetAll().Where(c => c.IdHoaDonn == id).ToList();
                var c = _GiamGiaChiTietService.GetAll().Where(c => c.IdHoaDon == id).ToList();
                var view = new ThieuxkViewAdmin()
                {
                    GiamGiaChiTiets = c,
                    HoaDon = hd,
                    hoaDonChiTiets = hdct1,
                    LichSuHoaDon = lshd.OrderByDescending(c => c.ThoiGianlam).ToList()

                };
                return View("XemChiTiet", view);
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
                if (hd.NgayGiao != null)
                {
                    var li = new LichSuDonHang()
                    {
                        GhiChu = null,
                        ThaoTac = $"Giao hàng thất bại đơn hàng {hd.MaHoaDon}",
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


                var hdct1 = _hoaDonChiTietService.GetAll().Where(c => c.IdHoaDon == id).ToList();
                var lshd = _LichSuHoaDonService.GetAll().Where(c => c.IdHoaDonn == id).ToList();
                var c = _GiamGiaChiTietService.GetAll().Where(c => c.IdHoaDon == id).ToList();
                var view = new ThieuxkViewAdmin()
                {
                    GiamGiaChiTiets = c,
                    HoaDon = hd,
                    hoaDonChiTiets = hdct1,
                    LichSuHoaDon = lshd.OrderByDescending(c => c.ThoiGianlam).ToList()

                };
                return View("XemChiTiet", view);
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
                            ThaoTac = $"Bỏ sản phẩm {hdct.SanPhamChiTiet.SanPham.TenSanPham} ",
                            IdHoaDonn = idHD,
                            ThoiGianlam = DateTime.Now,
                            NguoiThucHien = nvnew[0].TenDangNhap,
                            TrangThai = true,
                            Is_detele = true
                        };
                        if (_LichSuHoaDonService.Them(li)==false)
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

                    var hdct1 = _hoaDonChiTietService.GetAll().Where(c => c.IdHoaDon == idHD).ToList();
                    var lshd = _LichSuHoaDonService.GetAll().Where(c => c.IdHoaDonn == idHD).ToList();
                    int tongSoLuongSP = 0;
                    float tongTienSP = 0;
                    foreach (var a in hdct1)
                    {
                        tongSoLuongSP += a.SoLuong;
                    }
                    foreach (var a in hdct1)
                    {
                        tongTienSP += a.GiaTien;
                    }
                    var c = _GiamGiaChiTietService.GetAll().Where(c => c.IdHoaDon == idHD).ToList();
                    var view = new ThieuxkViewAdmin()
                    {
                        GiamGiaChiTiets = c,
                        HoaDon = hd,
                        hoaDonChiTiets = hdct1,
                        LichSuHoaDon = lshd.OrderByDescending(c => c.ThoiGianlam).ToList(),
                        TongTienHang = tongTienSP,
                        soLuongTong = tongSoLuongSP
                    };
                    return View("XemChiTiet", view);
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
        public IActionResult HoanTacSp(Guid idHDCT, int idHD)
        {
            var nvnew = SessionServices.NhanVienSS(HttpContext.Session, "ACA");
            if (nvnew.Count() != 0)
            {
                var hd = _hoaDonService.GetById(idHD);
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
                        GhiChu = null,
                        ThaoTac = $"Hoàn tác sản phẩm {hdct.SanPhamChiTiet.SanPham.TenSanPham} ",
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

                var hdct1 = _hoaDonChiTietService.GetAll().Where(c => c.IdHoaDon == idHD).ToList();
                var lshd = _LichSuHoaDonService.GetAll().Where(c => c.IdHoaDonn == idHD).ToList();
                int tongSoLuongSP = 0;
                float tongTienSP = 0;
                foreach (var a in hdct1)
                {
                    tongSoLuongSP += a.SoLuong;
                }
                foreach (var a in hdct1)
                {
                    tongTienSP += a.GiaTien;
                }
                var c = _GiamGiaChiTietService.GetAll().Where(c => c.IdHoaDon == idHD).ToList();
                var view = new ThieuxkViewAdmin()
                {
                    GiamGiaChiTiets = c,
                    HoaDon = hd,
                    hoaDonChiTiets = hdct1,
                    LichSuHoaDon = lshd.OrderByDescending(c => c.ThoiGianlam).ToList(),
                    TongTienHang = tongTienSP,
                    soLuongTong = tongSoLuongSP
                };
                return View("XemChiTiet", view);
            }
            else
            {
                return RedirectToAction("DangNhap", "Home");
            }
        }
        public IActionResult ThemBinhLuan(int IdHoaDon, string BinhLuan)
        {
            if (BinhLuan == null)
            {
                return RedirectToAction("XemChiTiet", new { id = IdHoaDon });
            }
            var nvnew = SessionServices.NhanVienSS(HttpContext.Session, "ACA");
            if (nvnew.Count() != 0)
            {
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


                var hdct1 = _hoaDonChiTietService.GetAll().Where(c => c.IdHoaDon == IdHoaDon).ToList();
                var lshd = _LichSuHoaDonService.GetAll().Where(c => c.IdHoaDonn == IdHoaDon).ToList();
                var c = _GiamGiaChiTietService.GetAll().Where(c => c.IdHoaDon == IdHoaDon).ToList();
                var view = new ThieuxkViewAdmin()
                {
                    GiamGiaChiTiets = c,
                    HoaDon = hd,
                    hoaDonChiTiets = hdct1,
                    LichSuHoaDon = lshd.OrderByDescending(c => c.ThoiGianlam).ToList()

                };
                return View("XemChiTiet", view);
            }
            else
            {
                return RedirectToAction("DangNhap", "Home");
            }
        }
        public IActionResult HuyDon(int id, string LyDo)
        {
            var nvnew = SessionServices.NhanVienSS(HttpContext.Session, "ACA");
            if (nvnew.Count() != 0)
            {
                var hd = _hoaDonService.GetById(id);
                if (LyDo != null)
                {
                    hd.TrangThai = "Đơn hàng bị hủy";
                    if (_hoaDonService.Sua(hd) == true)
                    {
                        var li = new LichSuDonHang()
                        {
                            GhiChu = LyDo,
                            ThaoTac = $"Hủy đơn hàng {hd.MaHoaDon} ",
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


                var hdct1 = _hoaDonChiTietService.GetAll().Where(c => c.IdHoaDon == id).ToList();
                var lshd = _LichSuHoaDonService.GetAll().Where(c => c.IdHoaDonn == id).ToList();
                int tongSoLuongSP = 0;
                float tongTienSP = 0;
                foreach (var a in hdct1)
                {
                    tongSoLuongSP += a.SoLuong;
                }
                foreach (var a in hdct1)
                {
                    tongTienSP += a.GiaTien;
                }
                var c = _GiamGiaChiTietService.GetAll().Where(c => c.IdHoaDon == id).ToList();
                var view = new ThieuxkViewAdmin()
                {
                    GiamGiaChiTiets = c,
                    HoaDon = hd,
                    hoaDonChiTiets = hdct1,
                    LichSuHoaDon = lshd.OrderByDescending(c => c.ThoiGianlam).ToList(),
                    TongTienHang = tongTienSP,
                    soLuongTong = tongSoLuongSP
                };
                return View("XemChiTiet", view);
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
                hoaDons = hd.Where(c => c.TrangThai == "Đang chờ xử lí" && c.Is_detele == true).ToList(),
            };
            return View("Index", view);
        }
        public IActionResult XemDaXacNhan()
        {
            var hd = _hoaDonService.GetAll();
            var view = new ThieuxkViewAdmin()
            {
                hoaDons = hd.Where(c => c.TrangThai != "Đang chờ xử lí" && c.Is_detele == true).ToList(),
            };
            return View("Index", view);
        }
        public IActionResult TimKiem(string ten)
        {
            if (ten == null)
            {
                return RedirectToAction("Index");
            }
            var hd = _hoaDonService.GetAll();
            var view = new ThieuxkViewAdmin()
            {
                hoaDons = hd.Where(c => c.MaHoaDon.ToLower().Contains(ten.ToLower()) || c.TenKhachHang.ToLower().Contains(ten.ToLower())).ToList(),
            };
            return View("Index", view);
        }
        public IActionResult TimKiemNgay(DateTime NgayDau, DateTime NgayCuoi)
        {
            if (NgayDau == DateTime.Parse("01/01/0001 12:00:00 SA") || NgayCuoi == DateTime.Parse("01/01/0001 12:00:00 SA"))
            {
                return RedirectToAction("Index");
            }
            else if (NgayDau > NgayCuoi)
            {
                var message = "Ngày bắt đầu phải nhỏ hơn ngày kết thúc !";
                TempData["TB1"] = message;
                return RedirectToAction("Index", new { message });
            }
            else
            {
                var hd = _hoaDonService.GetAll().Where(c => c.NgayTaoHoaDon > NgayDau && c.NgayTaoHoaDon < NgayCuoi && c.Is_detele == true).ToList();
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
                hoaDons = hd.Where(c => c.NgayGiao == null && c.Is_detele == true).ToList(),
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
                hoaDons = hd.Where(c => c.TrangThai == "Đơn hàng bị hủy").ToList(),
            };
            return View("Index", view);
        }
        public IActionResult XapXepMoiNhat()
        {
            var hd = _hoaDonService.GetAll();
            var view = new ThieuxkViewAdmin()
            {
                hoaDons = hd.Where(c => c.Is_detele == true).OrderByDescending(c => c.NgayTaoHoaDon).ToList(),
            };
            return View("Index", view);
        }
        public IActionResult XapXepCuNhat()
        {
            var hd = _hoaDonService.GetAll();
            var view = new ThieuxkViewAdmin()
            {
                hoaDons = hd.Where(c => c.Is_detele == true).OrderBy(c => c.NgayTaoHoaDon).ToList(),
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
        public JsonResult XuatEx2([FromBody] Thi1View Viewaa)
        {
            var Filenameok = new List<string>();

            foreach (var IdHD in Viewaa.IdHD)
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
        public JsonResult XacNhanDonHangNhanh([FromBody] Thi1View Viewaa)
        {
            var Filenameok = new List<string>();

            foreach (var IdHD in Viewaa.IdHD)
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
                    var hdct1 = _hoaDonChiTietService.GetAll().Where(c => c.IdHoaDon == IdHD).ToList();
                    var lshd = _LichSuHoaDonService.GetAll().Where(c => c.IdHoaDonn == IdHD).ToList();
                    int tongSoLuongSP = 0;
                    float tongTienSP = 0;
                    foreach (var a in hdct1)
                    {
                        tongSoLuongSP += a.SoLuong;
                    }
                    foreach (var a in hdct1)
                    {
                        tongTienSP += a.GiaTien;
                    }
                    var view = new ThieuxkViewAdmin()
                    {
                        HoaDon = hd,
                        hoaDonChiTiets = hdct1,
                        LichSuHoaDon = lshd.OrderByDescending(c => c.ThoiGianlam).ToList(),
                        TongTienHang = tongTienSP,
                        soLuongTong = tongSoLuongSP
                    };
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
        public IActionResult TaoHoaDonnew()
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
        public IActionResult TaoHoaDon(int id)
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
            foreach (var x in ghct)
            {
                tong += float.Parse(x.SanPhamChiTiet.SanPham.GiaNiemYet.ToString()) * (x.SoLuong);

            }
            var a = _hoaDonChiTietService.GetAll().Where(c => c.IdHoaDon == id).ToList();
            var giamgia = _giamGiaService.GetAll().Where(c => c.TrangThai == true && c.Is_detele == true && c.NgayBatDau <= DateTime.Now && c.NgayKetThuc >= DateTime.Now).ToList();
            var view = new Thi1View()
            {
                HoaDon = hd,
                GiamGias = giamgia,
                HoaDonChiTiets = a,
                TongTien = tong,
            };

            return View(view);
        }
        public IActionResult xoaKhoiHoaDon(Guid idHDCT,int id)
        {
            var hdct = _hoaDonChiTietService.GetById(idHDCT);
            var spct = _sanPhamChiTietService.GetById(hdct.IdSanPhamChiTiet);
            spct.SoLuong += hdct.SoLuong;
            if (_sanPhamChiTietService.Sua(spct) == false)
            {
                var message = $"bỏ thất bại(1)";
                TempData["TB2"] = message;
                return RedirectToAction("TaoHoaDon", new { id = id, message });
            }
            if (_hoaDonChiTietService.Xoa(hdct.Id)==false)
            {
                var message = $"bỏ thất bại(1)";
                TempData["TB2"] = message;
                return RedirectToAction("TaoHoaDon", new { id = id, message });
            }
            return RedirectToAction("TaoHoaDon", new { id = id });
        }
        public IActionResult sanphammua()
        {

            var sanPhamList = _sanPhamService.GetAll();
            var khuyenMaiSp = _KhuyenMaiSanPhams.GetAll().Where(c => c.KhuyenMai.TrangThai == true && c.KhuyenMai.Is_Detele == false && c.KhuyenMai.NgayBatDau <= DateTime.Now && c.KhuyenMai.NgayKetThuc >= DateTime.Now).ToList();

            var view = new Thi1View()
            {
                sanPhams = sanPhamList,
                KhuyenMaiSanPhams = khuyenMaiSp,
            };
            return View(view);
        }
        public IActionResult HienThiSanPhamChiTietMua(Guid id)
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
        public IActionResult chonMau(Guid IdSanPham, Guid IdMau)
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
        public IActionResult chonSize(Guid IdSanPham, Guid idSize, Guid IdMau)
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
        public IActionResult Themsanphamhoadon(int soluong, Guid IdSanPham, Guid IdSize, Guid IdMau)
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
            var sanphamctnew = SessionBan.SanPhamTamSS(HttpContext.Session, "SanPhamTamSS");
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
                if (_hoaDonChiTietService.Them(d) == true)
                {
                    var product = _sanPhamChiTietService.GetById(sanphamCT.Id);
                    product.SoLuong -= soluong;
                    if (_sanPhamChiTietService.Sua(product))
                    {
                        return RedirectToAction("TaoHoaDon", new { id = sanphamctnew[0].idHD });
                    }
                }
            }
            else
            {
                SP.SoLuong += soluong;
                if (_hoaDonChiTietService.Sua(SP) == true)
                {
                    var product = _sanPhamChiTietService.GetById(sanphamCT.Id);
                    product.SoLuong -= soluong;
                    if (_sanPhamChiTietService.Sua(product))
                    {
                        return RedirectToAction("TaoHoaDon", new { id = sanphamctnew[0].idHD });
                    }
                }
            }

            var message3 = "Thêm Thất bại";
            TempData["TB2"] = message3;
            return RedirectToAction("HienThiSanPhamChiTietMua", new { id = IdSanPham, message3 });


        }
        public IActionResult SuDunggiamGia(Guid IdGiamGia2, float tienhanga, string DiachiNhanChiTiet, string name, string Sodienthoai, string Email, string addDiaChi, string ghiChu, float tienshipa, float tongtien, int idHD)
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
                    if (giamgia1.DieuKienGiam < tienhanga)
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
                var view = new Thi1View()
                {

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
                    if (giamgia1.DieuKienGiam < tienhanga)
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
                var view = new Thi1View()
                {
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
        public IActionResult Chốt(string tenmagiam, float tiengiama, float tienhanga, string name, string DiachiNhanChiTiet, string Sodienthoai, string Email, string addDiaChi, string ghiChu, float tienshipa, float tongtien, int idHD)
        {
            var nvnew = SessionServices.NhanVienSS(HttpContext.Session, "ACA");
            if (nvnew.Count() != 0)
            {
                #region Check validate
                if (name == null)
                {
                    {
                        var message = "hãy nhớ điền tên của bạn của bạn";
                        TempData["TB2"] = message;
                        return RedirectToAction("TaoHoaDon", new { message });
                    }
                }
                if (DiachiNhanChiTiet == null)
                {
                    {
                        var message = "hãy nhớ điền địa chỉ chi tiết của bạn";
                        TempData["TB2"] = message;
                        return RedirectToAction("TaoHoaDon", new { message });
                    }
                }
                if (Sodienthoai == null)
                {
                    {
                        var message = "hãy nhớ điền số điện thoại của bạn";
                        TempData["TB2"] = message;
                        return RedirectToAction("TaoHoaDon", new { message });
                    }
                }
                if (Sodienthoai == null)
                {
                    {
                        var message = "hãy nhớ điền Email của bạn";
                        TempData["TB2"] = message;
                        return RedirectToAction("TaoHoaDon", new { message });
                    }
                }
                if (addDiaChi == null)
                {
                    {
                        var message = "hãy nhớ chọn địa chỉ của bạn";
                        TempData["TB2"] = message;
                        return RedirectToAction("TaoHoaDon", new { message });
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
                    return RedirectToAction("TaoHoaDon", new { id = idHD, message });
                }

                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("DangNhap", "Home");
            }
        }
        #endregion
    }

}

