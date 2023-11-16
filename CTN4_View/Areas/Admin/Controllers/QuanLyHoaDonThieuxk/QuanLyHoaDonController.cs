using CTN4_Data.Models;
using CTN4_Data.Models.DB_CTN4;
using CTN4_Serv.Service;
using CTN4_Serv.Service.IService;
using CTN4_Serv.Service.Service;
using CTN4_View.Areas.Admin.Viewmodel;
using Microsoft.AspNetCore.Mvc;

namespace CTN4_View.Areas.Admin.Controllers.QuanLyHoaDonThieuxk
{
    [Area("admin")]
    public class QuanLyHoaDonController : Controller
    {
        public IHoaDonService _hoaDonService;
        public IHoaDonChiTietService _hoaDonChiTietService;
        public ILichSuHoaDonService _LichSuHoaDonService;
        public QuanLyHoaDonController()
        {
            _hoaDonChiTietService = new HoaDonChiTietService();
            _hoaDonService = new HoaDonService();
            _LichSuHoaDonService = new LichSuHoaDonService();
        }
        public IActionResult Index()
        {
            var hd = _hoaDonService.GetAll();
            var view = new ThieuxkViewAdmin()
            {
                hoaDons = hd,
            };
            return View(view);
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
        public IActionResult XacNhanDonHang(int id)
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
        public IActionResult HuyDon(int id)
        {
            var nvnew = SessionServices.NhanVienSS(HttpContext.Session, "ACA");
            if (nvnew.Count() != 0)
            {
                var hd = _hoaDonService.GetById(id);
            if (hd.NgayGiao == null)
            {
                hd.Is_detele = false;
                hd.TrangThai = "đơn hàng đã bị hủy";
                if (_hoaDonService.Sua(hd) == true)
                {
                    var li = new LichSuDonHang()
                    {
                        GhiChu = null,
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
                var message = "Đơn hàng không thể hủy vì đang được giao";
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
        public IActionResult BoSanPham(Guid idHDCT, int idHD)
        {
            var nvnew = SessionServices.NhanVienSS(HttpContext.Session, "ACA");
            if (nvnew.Count() != 0)
            {
                var hd = _hoaDonService.GetById(idHD);
                var hdct = _hoaDonChiTietService.GetById(idHDCT);
                if (hd.Is_detele != false)
                {
                    hd.TongTien -= hdct.GiaTien * hdct.SoLuong;
                    hdct.TrangThai = false;

                    if (_hoaDonService.Sua(hd) == true&& _hoaDonChiTietService.Sua(hdct)==true)
                    {
                        var li = new LichSuDonHang()
                        {
                            GhiChu = null,
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
                hoaDons = hd.Where(c => c.TrangThai == "Đang chờ xử lí").ToList(),
            };
            return View("Index", view);
        }
        public IActionResult XemDaXacNhan()
        {
            var hd = _hoaDonService.GetAll();
            var view = new ThieuxkViewAdmin()
            {
                hoaDons = hd.Where(c => c.TrangThai != "Đang chờ xử lí").ToList(),
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
                var hd = _hoaDonService.GetAll().Where(c => c.NgayTaoHoaDon > NgayDau && c.NgayTaoHoaDon < NgayCuoi).ToList();
                var view = new ThieuxkViewAdmin()
                {
                    hoaDons = hd,
                };
                return View("Index", view);
            }

        }
        public IActionResult ThemBinhLuan(int IdHoaDon, string BinhLuan)
        {
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
                hoaDons = hd.Where(c => c.NgayGiao != null).ToList(),
            };
            return View("Index", view);
        }
        public IActionResult XemChuaGiao()
        {
            var hd = _hoaDonService.GetAll();
            var view = new ThieuxkViewAdmin()
            {
                hoaDons = hd.Where(c => c.NgayGiao == null).ToList(),
            };
            return View("Index", view);
        }
        public IActionResult XemChuThanhToan()
        {
            var hd = _hoaDonService.GetAll();
            var view = new ThieuxkViewAdmin()
            {
                hoaDons = hd.Where(c => c.TrangThaiThanhToan == false).ToList(),
            };
            return View("Index", view);
        }
        public IActionResult XemDaThanhToan()
        {
            var hd = _hoaDonService.GetAll();
            var view = new ThieuxkViewAdmin()
            {
                hoaDons = hd.Where(c => c.TrangThaiThanhToan == true).ToList(),
            };
            return View("Index", view);
        }
        public IActionResult XemDaGiaoHoanTat()
        {
            var hd = _hoaDonService.GetAll();
            var view = new ThieuxkViewAdmin()
            {
                hoaDons = hd.Where(c => c.TrangThai == "Giao hàng thành công").ToList(),
            };
            return View("Index", view);
        }
        public IActionResult XemDaGiaoThatBai()
        {
            var hd = _hoaDonService.GetAll();
            var view = new ThieuxkViewAdmin()
            {
                hoaDons = hd.Where(c => c.TrangThai == "Giao hàng thất bại").ToList(),
            };
            return View("Index", view);
        }
        public IActionResult XemDaBiHuy()
        {
            var hd = _hoaDonService.GetAll();
            var view = new ThieuxkViewAdmin()
            {
                hoaDons = hd.Where(c => c.Is_detele == false).ToList(),
            };
            return View("Index", view);
        }

        public IActionResult SuaGhiChu(int IdHoaDon,string GhiChu)
        {

            var nvnew = SessionServices.NhanVienSS(HttpContext.Session, "ACA");
            if (nvnew.Count() != 0)
            {
                var hd = _hoaDonService.GetById(IdHoaDon);
                if (hd.TrangThai == "Hàng của bạn đang được giao" && hd.TrangThaiThanhToan == true)
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
    }
}
