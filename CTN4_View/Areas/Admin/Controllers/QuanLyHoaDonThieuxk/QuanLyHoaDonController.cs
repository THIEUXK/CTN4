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
            var hdct = _hoaDonChiTietService.GetAll().Where(c=>c.IdHoaDon==id).ToList();
            var view = new ThieuxkViewAdmin()
            {
                HoaDon = hd,
                hoaDonChiTiets=hdct
            };
            return View(view);
        }
    }
}
