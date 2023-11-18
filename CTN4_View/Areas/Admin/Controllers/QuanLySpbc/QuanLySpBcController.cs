using CTN4_Data.Models.DB_CTN4;
using CTN4_Serv.Service;
using CTN4_Serv.Service.IService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CTN4_View.Areas.Admin.Controllers.QuanLySpbc
{
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

        // GET: QuanLySpBcController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: QuanLySpBcController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: QuanLySpBcController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: QuanLySpBcController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: QuanLySpBcController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: QuanLySpBcController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: QuanLySpBcController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
