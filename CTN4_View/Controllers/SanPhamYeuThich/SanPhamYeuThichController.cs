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
                var tkmoi = accnew[0];
                var DSYT = _YT.GetAll().FirstOrDefault(c => c.IdKhachHang == tkmoi.Id&&c.SanPham.TrangThai==true&&c.SanPham.Is_detele==true);
                var SPYT = new ChiTietSanPhamYeuThich()
                {
                    IdSanPham = IdSanPham,
                    IdKhachHang = accnew[0].Id,
                };
                if (_YT.Them(SPYT))
                {
                    return RedirectToAction("HienThiSanPham", "HienThiSanPham");
                }

            }
            else
            {

                return RedirectToAction("login", "Home");
            }
            return RedirectToAction("HienThiSanPham", "HienThiSanPham");

        }
        public IActionResult Index(/*Guid IdKhachHang*/)
        {
            var accnew = SessionServices.KhachHangSS(HttpContext.Session, "ACC");
            if (accnew.Count != 0)
            {
                var a = _YT.GetAll().Where(c => c.IdKhachHang == accnew[0].Id &&c.SanPham.TrangThai==true&&c.SanPham.Is_detele==true).ToList();
                var view = new SanPhamYeuThichView()
                {
                    chiTietSanPhamYeuThiches = a,
                    KhachHang = accnew[0],
                };
                return View(view);
            }
            else
            {
                return RedirectToAction("HienThiSanPham", "HienThiSanPham");
            }
            

            //var a = _YT.GetAll();
            //return View(a);

        }
        public IActionResult XoaKhoiYeuTich(Guid idSP, Guid IdKhachHang)
        {
            var lisSpYT = _YT.GetAll().FirstOrDefault(c => c.IdKhachHang == IdKhachHang && c.IdSanPham == idSP);
            Guid idYT = lisSpYT.Id;

            _YT.Xoa(idYT);
            return RedirectToAction("Index");

        }
        public IActionResult XoaKhoiYeuTich1(Guid idSP)
        {
            var lisSpYT = _YT.GetAll().FirstOrDefault(c => c.IdSanPham == idSP);
            Guid idYT = lisSpYT.Id;

            _YT.Xoa(idYT);
            return RedirectToAction("HienThiSanPham", "HienThiSanPham");

        }
    }
}
