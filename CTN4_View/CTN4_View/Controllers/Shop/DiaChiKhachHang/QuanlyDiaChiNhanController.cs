using CTN4_Data.Models.DB_CTN4;
using CTN4_Serv.Service;
using CTN4_Serv.Service.IService;
using CTN4_View.Controllers.Shop.DiaChiKhachHang.ViewMoel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CTN4_View.Controllers.Shop.NewFolder
{

    public class QuanlyDiaChiNhanController : Controller
    {
        public IDiaChiNhanHangService _DiaChiNhanHangService;
        public QuanlyDiaChiNhanController()
        {
            _DiaChiNhanHangService = new DiaChiNhanHangService();
        }
        public IActionResult Index()
        {
            var accnew = SessionServices.KhachHangSS(HttpContext.Session, "ACC");

            if (accnew.Count != 0)
            {
                var listDiaChi = _DiaChiNhanHangService.GetAll().Where(c => c.IdKhachHang == accnew[0].Id && c.Is_detele == true).ToList();
                var view = new DiaChiKhachHangView()
                {
                    DiaChiNhanHangs = listDiaChi
                };

                return View(view);
            }
            return RedirectToAction("login", "Home");
        }
        public IActionResult BoDiaChi(Guid id)
        {
            var accnew = SessionServices.KhachHangSS(HttpContext.Session, "ACC");

            if (accnew.Count != 0)
            {
                var a = _DiaChiNhanHangService.GetById(id);
                a.TrangThai = false;
                a.Is_detele = false;
                _DiaChiNhanHangService.Sua(a);
                var listDiaChi = _DiaChiNhanHangService.GetAll().Where(c => c.IdKhachHang == accnew[0].Id && c.Is_detele == true).ToList();
                var view = new DiaChiKhachHangView()
                {
                    DiaChiNhanHangs = listDiaChi
                };
                return View("Index", view);
            }
            return RedirectToAction("login", "Home");
        }
        public IActionResult SetChinh(Guid id)
        {
            var accnew = SessionServices.KhachHangSS(HttpContext.Session, "ACC");

            if (accnew.Count != 0)
            {
                var b = _DiaChiNhanHangService.GetAll().Where(c => c.TrangThai == true);
                foreach (var dc in b)
                {
                    dc.TrangThai = false;
                    _DiaChiNhanHangService.Sua(dc);
                }
                var a = _DiaChiNhanHangService.GetById(id);
                a.TrangThai = true;
                _DiaChiNhanHangService.Sua(a);
                var listDiaChi = _DiaChiNhanHangService.GetAll().Where(c => c.IdKhachHang == accnew[0].Id && c.Is_detele == true).ToList();
                var view = new DiaChiKhachHangView()
                {
                    DiaChiNhanHangs = listDiaChi
                };

                return View("Index", view);
            }
            return RedirectToAction("login", "Home");
        }
        public IActionResult DoiDiaChiCuThe(Guid id, string TenCuthe)
        {
            var accnew = SessionServices.KhachHangSS(HttpContext.Session, "ACC");

            if (accnew.Count != 0)
            {
                var a = _DiaChiNhanHangService.GetById(id);
                a.name = TenCuthe;
                _DiaChiNhanHangService.Sua(a);
                var listDiaChi = _DiaChiNhanHangService.GetAll().Where(c => c.IdKhachHang == accnew[0].Id && c.Is_detele == true).ToList();
                var view = new DiaChiKhachHangView()
                {
                    DiaChiNhanHangs = listDiaChi
                };

                return View("Index", view);
            }
            return RedirectToAction("login", "Home");
        }
    }
}
