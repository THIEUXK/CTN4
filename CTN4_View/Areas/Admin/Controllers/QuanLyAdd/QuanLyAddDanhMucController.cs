//using CTN4_Data.Migrations;
using CTN4_Data.Models.DB_CTN4;
using CTN4_Serv.Service;
using CTN4_Serv.Service.IService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CTN4_View.Areas.Admin.Controllers.QuanLyAdd
{
    [Area("admin")]
    public class QuanLyAddDanhMucController : Controller
    {
        public IDanhMucService _danhMucService;
        public IDanhMucChiTietService _danhMucChiTietService;
        public ISanPhamService _sanPhamService;
        public QuanLyAddDanhMucController()
        {
            _danhMucService = new DanhMucMucService();
            _danhMucChiTietService = new DanhMucChiTietMucChiTietService();
            _sanPhamService = new SanPhamService();
        }
        // GET: QuanLyAddDanhMucController

        public ActionResult ThemSanPhamDanhMuc(Guid id)
        {
            var danhmuc = _danhMucService.GetById(id);
            var danhmucCt = _danhMucChiTietService.GetAll().Where(c => c.IdDanhMuc == id).ToList();
            var tensp = new List<Guid>();
            var tensp2 = new List<SanPham>();
            foreach (var x in danhmucCt)
            {
                tensp.Add((Guid)x.IdSanPham);
            }
            var sanPham = _sanPhamService.GetAll();
            foreach (var x in sanPham)
            {
                if (!tensp.Contains(x.Id))
                {
                    tensp2.Add(x);

                }
            }

            var view = new ViewModelAddDanhMuc()
            {
                danhMuc = danhmuc,
                danhMucChiTiets = danhmucCt,
                sanPhams = tensp2
            };
            return View(view);
        }

        // GET: QuanLyAddDanhMucController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: QuanLyAddDanhMucController/Create
        public ActionResult TaoMoiDanhMuc(Guid idsp, Guid iddm)
        {
            var danhmucct = new DanhMucChiTiet()
            {
                IdDanhMuc = iddm,
                IdSanPham = idsp,
            };
            _danhMucChiTietService.Them(danhmucct);
            return RedirectToAction("ThemSanPhamDanhMuc",new{id=iddm});
        }
        public ActionResult BoSpDanhMuc(Guid idsp, Guid iddm)
        {
           
            var a = _danhMucChiTietService.GetAll().FirstOrDefault(c=>c.IdSanPham == idsp && c.IdDanhMuc == iddm);
            _danhMucChiTietService.Xoa(a.Id);
            return RedirectToAction("Details","DanhMuc",new {id=iddm});
        }

        // POST: QuanLyAddDanhMucController/Create
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

        // GET: QuanLyAddDanhMucController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: QuanLyAddDanhMucController/Edit/5
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

        // GET: QuanLyAddDanhMucController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: QuanLyAddDanhMucController/Delete/5
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
