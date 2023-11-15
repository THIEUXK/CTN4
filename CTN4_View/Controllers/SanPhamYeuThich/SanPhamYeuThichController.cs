using CTN4_Data.Models.DB_CTN4;
using CTN4_Serv.Service;
using CTN4_Serv.Service.IService;
using CTN4_Serv.ViewModel;
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
            var accnew = SessionServices.KhachHangSS(HttpContext.Session, "ACC");
            var a=  _YT.GetAll();
            var view = new SanPhamYeuThichView(){
                chiTietSanPhamYeuThiches=a,
                KhachHang = accnew[0],
            };
                 
            return View(view);
        }
        public IActionResult XoaKhoiYeuTich(Guid idSP,Guid IdKhachHang)
        {
           var lisSpYT= _YT.GetAll().FirstOrDefault(c=>c.IdKhachHang == IdKhachHang&&c.IdSanPham==idSP);
            Guid idYT = lisSpYT.Id;

            _YT.Xoa(idYT);
            return RedirectToAction("Index");

        }
        public IActionResult XoaKhoiYeuTich1(Guid idSP)
        {
           var lisSpYT= _YT.GetAll().FirstOrDefault(c=>c.IdSanPham == idSP);
            Guid idYT = lisSpYT.Id;

            _YT.Xoa(idYT);
             return RedirectToAction("HienThiSanPham","HienThiSanPham");

        }
    }
}
