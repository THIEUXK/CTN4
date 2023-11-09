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
        public IActionResult XemChiTiet(Guid id)
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
        public IActionResult XacNhanDonHang(Guid id)
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
        public IActionResult XacNhanGiaoHang(Guid id)
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
        public IActionResult XacNhanThanhToan(Guid id)
        {
            var hd = _hoaDonService.GetById(id);
            if (hd.TrangThai == "Đang chuẩn bị hàng")
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
        public IActionResult XacNhanNhanHang(Guid id)
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
        public IActionResult HuyDon(Guid id)
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
    }
}
