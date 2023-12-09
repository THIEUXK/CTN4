using ClosedXML.Excel;
using CTN4_Data.Models;
using CTN4_Data.Models.DB_CTN4;
using CTN4_Serv.Service;
using CTN4_Serv.Service.IService;
using CTN4_Serv.Service.Service;
using CTN4_Serv.ViewModel.banhangview;
using CTN4_View.Areas.Admin.Controllers.QuanLyHoaDonThieuxk.viewMode;
using CTN4_View.Areas.Admin.Viewmodel;
using DocumentFormat.OpenXml.Office2010.Excel;
using DocumentFormat.OpenXml.Spreadsheet;
using DocumentFormat.OpenXml.Wordprocessing;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CTN4_View.Areas.Admin.Controllers.QuanLyHoaDonThieuxk
{
    [Area("admin")]
    public class QuanLyHoaDonController : Controller
    {
        public IHoaDonService _hoaDonService;
        public IHoaDonChiTietService _hoaDonChiTietService;
        public ILichSuHoaDonService _LichSuHoaDonService;
        private readonly HttpClient _httpClient;
        public QuanLyHoaDonController()
        {
            _hoaDonChiTietService = new HoaDonChiTietService();
            _hoaDonService = new HoaDonService();
            _LichSuHoaDonService = new LichSuHoaDonService();
        }
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
        public IActionResult aa()
        {

            return View();
        }
        public IActionResult XemChiTiet(int id)
        {
            var nvnew = SessionServices.NhanVienSS(HttpContext.Session, "ACA");
            if (nvnew.Count() != 0)
            {
                var hd = _hoaDonService.GetById(id);
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
                var view = new ThieuxkViewAdmin()
                {
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
                var view = new ThieuxkViewAdmin()
                {
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
                var view = new ThieuxkViewAdmin()
                {
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
                var view = new ThieuxkViewAdmin()
                {
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
                var view = new ThieuxkViewAdmin()
                {
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
                var view = new ThieuxkViewAdmin()
                {
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
                var view = new ThieuxkViewAdmin()
                {
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

                        if (_hoaDonService.Sua(hd) == true && _hoaDonChiTietService.Sua(hdct) == true)
                        {
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
                            _LichSuHoaDonService.Them(li);
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
                    var view = new ThieuxkViewAdmin()
                    {
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
                    if (_hoaDonService.Sua(hd) == true && _hoaDonChiTietService.Sua(hdct) == true)
                    {
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
                        _LichSuHoaDonService.Them(li);
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
                var view = new ThieuxkViewAdmin()
                {
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
        public IActionResult ThemBinhLuan(int IdHoaDon, string BinhLuan)
        {
            if (BinhLuan==null)
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
                var view = new ThieuxkViewAdmin()
                {
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
                var view = new ThieuxkViewAdmin()
                {
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
        public IActionResult TaoHoaDon()
        {
            return View();
        }

    }
}
