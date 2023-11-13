using CTN4_Serv.Service;
using CTN4_Serv.Service.IService;
using CTN4_View.Areas.Admin.Viewmodel;
using Microsoft.AspNetCore.Mvc;

namespace CTN4_View.Areas.Admin.Controllers.QuanLyHoaDonThieuxk
{
    [Area("admin")]
    public class QuanLyHoaDonController : Controller
    {
        public IHoaDonService _hoaDonService;
        public IHoaDonChiTietService _hoaDonChiTietService;
        public QuanLyHoaDonController()
        {
            _hoaDonChiTietService = new HoaDonChiTietService();
            _hoaDonService = new HoaDonService();
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
            var hd = _hoaDonService.GetById(id);
            var hdct = _hoaDonChiTietService.GetAll().Where(c => c.IdHoaDon == id).ToList();
            var view = new ThieuxkViewAdmin()
            {
                HoaDon = hd,
                hoaDonChiTiets = hdct
            };
            return View(view);
        }
        public IActionResult XacNhanDonHang(int id)
        {
            var hd = _hoaDonService.GetById(id);
            hd.TrangThai = "Đang chuẩn bị hàng";
            _hoaDonService.Sua(hd);
            var hdct = _hoaDonChiTietService.GetAll().Where(c => c.IdHoaDon == id).ToList();
            var view = new ThieuxkViewAdmin()
            {
                HoaDon = hd,
                hoaDonChiTiets = hdct
            };
            return View("XemChiTiet", view);
        }
        public IActionResult XacNhanGiaoHang(int id)
        {
            var hd = _hoaDonService.GetById(id);
            if (hd.TrangThai == "Đang chuẩn bị hàng")
            {
                hd.TrangThai = "Hàng của bạn đang được giao";
                hd.NgayGiao = DateTime.Now;
                _hoaDonService.Sua(hd);
            }
            else
            {
                var message = "Đơn hàng chưa được xác nhận !";
                TempData["TB1"] = message;
                return RedirectToAction("XemChiTiet", new { id = id, message });
            }

            var hdct = _hoaDonChiTietService.GetAll().Where(c => c.IdHoaDon == id).ToList();
            var view = new ThieuxkViewAdmin()
            {
                HoaDon = hd,
                hoaDonChiTiets = hdct
            };
            return View("XemChiTiet", view);
        }
        public IActionResult XacNhanThanhToan(int id)
        {
            var hd = _hoaDonService.GetById(id);
            if (hd.TrangThai != "Giao hàng thành công")
            {
                hd.TrangThaiThanhToan = true;
                _hoaDonService.Sua(hd);
            }
            else
            {
                var message = "Đơn hàng chưa được xác nhận !";
                TempData["TB3"] = message;
                return RedirectToAction("XemChiTiet", new { id = id, message });
            }


            var hdct = _hoaDonChiTietService.GetAll().Where(c => c.IdHoaDon == id).ToList();
            var view = new ThieuxkViewAdmin()
            {
                HoaDon = hd,
                hoaDonChiTiets = hdct
            };
            return View("XemChiTiet", view);
        }
        public IActionResult XacNhanNhanHang(int id)
        {
            var hd = _hoaDonService.GetById(id);
            if (hd.TrangThai == "Hàng của bạn đang được giao" && hd.TrangThaiThanhToan == true)
            {
                hd.TrangThai = "Giao hàng thành công";
                hd.NgayNhan = DateTime.Now;
                _hoaDonService.Sua(hd);
            }
            else
            {
                var message = "Đơn hàng phải được giao vào thanh toán !";
                TempData["TB2"] = message;
                return RedirectToAction("XemChiTiet", new { id = id, message });
            }

            var hdct = _hoaDonChiTietService.GetAll().Where(c => c.IdHoaDon == id).ToList();
            var view = new ThieuxkViewAdmin()
            {
                HoaDon = hd,
                hoaDonChiTiets = hdct
            };
            return View("XemChiTiet", view);
        }
        public IActionResult HuyDon(int id)
        {
            var hd = _hoaDonService.GetById(id);
            if (hd.NgayGiao == null)
            {
                hd.Is_detele = false;
                hd.TrangThai = "đơn hàng đã bị hủy";
                _hoaDonService.Sua(hd);
            }
            else
            {
                var message = "Đơn hàng không thể hủy vì đang được giao";
                TempData["TB4"] = message;
                return RedirectToAction("XemChiTiet", new { id = id, message });
            }

            var hdct = _hoaDonChiTietService.GetAll().Where(c => c.IdHoaDon == id).ToList();
            var view = new ThieuxkViewAdmin()
            {
                HoaDon = hd,
                hoaDonChiTiets = hdct
            };
            return View("XemChiTiet", view);
        }
        public IActionResult GiaoHangThatBai(int id)
        {
            var hd = _hoaDonService.GetById(id);
            if (hd.NgayGiao != null)
            {
                hd.TrangThai = "Giao hàng thất bại";
                _hoaDonService.Sua(hd);
            }
            else
            {
                var message = "Đơn hàng không thể giao hàng thất bại khi chưa giao hàng";
                TempData["TB4"] = message;
                return RedirectToAction("XemChiTiet", new { id = id, message });
            }

            var hdct = _hoaDonChiTietService.GetAll().Where(c => c.IdHoaDon == id).ToList();
            var view = new ThieuxkViewAdmin()
            {
                HoaDon = hd,
                hoaDonChiTiets = hdct
            };
            return View("XemChiTiet", view);
        }
        public IActionResult BoSanPham(Guid idHDCT, int idHD)
        {
            var hd = _hoaDonService.GetById(idHD);
            var hdct= _hoaDonChiTietService.GetById(idHDCT);
            if (hd.Is_detele != false)
            {
                hd.TongTien -= hdct.GiaTien;
                hdct.TrangThai = false;
                _hoaDonService.Sua(hd);
            }
            else
            {
                var message = "Đơn hàng không thể thay đổi";
                TempData["TB5"] = message;
                return RedirectToAction("XemChiTiet", new { id = idHD, message });
            }

            var hdct1 = _hoaDonChiTietService.GetAll().Where(c => c.IdHoaDon == idHD).ToList();
            var view = new ThieuxkViewAdmin()
            {
                HoaDon = hd,
                hoaDonChiTiets = hdct1
            };
            return View("XemChiTiet", view);
        }
        public IActionResult HoanTacSp(Guid idHDCT, int idHD)
        {
            var hd = _hoaDonService.GetById(idHD);
            var hdct = _hoaDonChiTietService.GetById(idHDCT);
            if (hd.Is_detele != false)
            {
                hd.TongTien += hdct.GiaTien;
                hdct.TrangThai = true;
                _hoaDonService.Sua(hd);
            }
            else
            {
                var message = "Đơn hàng không thể thay đổi";
                TempData["TB5"] = message;
                return RedirectToAction("XemChiTiet", new { id = idHD, message });
            }

            var hdct1 = _hoaDonChiTietService.GetAll().Where(c => c.IdHoaDon == idHD).ToList();
            var view = new ThieuxkViewAdmin()
            {
                HoaDon = hd,
                hoaDonChiTiets = hdct1
            };
            return View("XemChiTiet", view);
        }
    }
}
