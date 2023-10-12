using CTN4_Data.Models.DB_CTN4;
using CTN4_Serv.Service.IService;
using CTN4_Serv.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CTN4_View.Areas.Admin.Controllers.QuanLY
{
    public class SanPhamChiTietController : Controller
    {
        public ISanPhamChiTietService _sv;

        public SanPhamChiTietController()
        {
            _sv = new SanPhamChiTietService();
        }
        // GET: SanPhamChiTietController
        // GET: SanPhamController
        [HttpGet]
        public ActionResult Index()
        {
            var a = _sv.GetAll();
            return View(a);
        }

        // GET: SanPhamController/Details/5
        public ActionResult Details(Guid id)
        {
            var a = _sv.GetById(id);
            return View(a);
        }

        // GET: SanPhamController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SanPhamController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SanPhamChiTiet p, [Bind] IFormFile imageFile)
        {
       

            if (_sv.Them(p)) // Nếu thêm thành công
            {

                return RedirectToAction("Index");
            }

            return View();
        }

        // GET: SanPhamController/Edit/5
        [HttpGet]
        public ActionResult Edit(Guid id)
        {
            var a = _sv.GetById(id);
            return View(a);
        }

        // POST: SanPhamController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(SanPhamChiTiet p, [Bind] IFormFile imageFile)
        {
          
            if (_sv.Sua(p))
            {
                return RedirectToAction("Index");

            }
            return View();
        }

        // GET: SanPhamController/Delete/5
        public ActionResult Delete(Guid id)
        {
            if (_sv.Xoa(id))
            {
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }
    }
}
