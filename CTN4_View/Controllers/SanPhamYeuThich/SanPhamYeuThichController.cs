using CTN4_Data.Models.DB_CTN4;
using CTN4_Serv.Service;
using CTN4_Serv.Service.IService;
using Microsoft.AspNetCore.Mvc;

namespace CTN4_View.Controllers.SanPhamYeuThich
{
    public class SanPhamYeuThichController : Controller
    {
        public IChiTietSanPhamYeuThichService _YT;
        public SanPhamYeuThichController()
        {
            _YT = new ChiTietSanPhamYeuThichService();
        }
        public IActionResult ThemYeuThich(Guid IdSanPham) 
        {
            var accnew = SessionServices.KhachHangSS(HttpContext.Session, "ACC");
            if (accnew.Count != 0)
            {
                var SPYT = new ChiTietSanPhamYeuThich() 
                {
                    IdSanPham = IdSanPham,
                    IdKhachHang = accnew[0].Id,
                };
                if(_YT.Them (SPYT))
                {
                    return RedirectToAction("Index");
                }

            }
            else 
            {

                return RedirectToAction("login", "Home");
            }
            return RedirectToAction("Index");

        }
        public IActionResult Index()
        {
            var a=  _YT.GetAll();
            return View(a);
        }
    }
}
