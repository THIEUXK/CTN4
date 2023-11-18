using CTN4_Data.Models.DB_CTN4;
using CTN4_Serv.Service;
using CTN4_Serv.Service.IService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CTN4_View.Areas.Admin.Controllers.QuanLySpbc
{
    [Area("admin")]
    public class QuanLySpBcController : Controller
    {
        public ISanPhamChiTietService _sanPhamChiTietService;
        public ISanPhamService _sanPhamSv;
        public IHoaDonService _hoaDonService;
        public IHoaDonChiTietService _hoaDonChiTietService;


        public QuanLySpBcController()
        {
            _sanPhamChiTietService = new SanPhamChiTietService();
            _sanPhamSv = new SanPhamService();
            _hoaDonService = new HoaDonService();
            _hoaDonChiTietService = new HoaDonChiTietService();
        }
        // GET: QuanLySpBcController
        [HttpGet]
        public ActionResult AllSpindex()
        {
            var listsp = _hoaDonChiTietService.GetAll();
            var sp = _sanPhamSv.GetAll();
            var tensp = new List<string>();
            foreach (var a in listsp)
            {
                if (!tensp.Contains(a.SanPhamChiTiet.SanPham.TenSanPham))
                {
                    tensp.Add(a.SanPhamChiTiet.SanPham.TenSanPham);

                }

            }
            var sanPhamHungViews = new List<SanPhamHungView>();
            foreach (var b in tensp)
            {
                var listSpHien = listsp.Where(c => c.SanPhamChiTiet.SanPham.TenSanPham == b);
                var c = new SanPhamHungView
                {
                    TenSp = b,
                    AnhDaiDien= listSpHien.FirstOrDefault(c => c.SanPhamChiTiet.SanPham.TenSanPham == b).SanPhamChiTiet.SanPham.AnhDaiDien,
                    soluotmua = listSpHien.Count(),
                    GiaSanPham =listSpHien.FirstOrDefault(c => c.SanPhamChiTiet.SanPham.TenSanPham == b).SanPhamChiTiet.SanPham.GiaNiemYet,
                    
                };
                sanPhamHungViews.Add(c);
            }
            var view = new SanphamBcView()
            {
                SanPhamHungs = sanPhamHungViews.OrderByDescending(c=>c.soluotmua).ToList()

            };
            return View(view);
        }

        
    }
}
