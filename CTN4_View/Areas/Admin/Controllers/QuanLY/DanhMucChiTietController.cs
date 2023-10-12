using CTN4_Data.Models.DB_CTN4;
using CTN4_Serv.Service;
using CTN4_Serv.Service.IService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CTN4_View.Areas.Admin.Controllers.QuanLY
{
    [Area("admin")]
    public class DanhMucChiTietController : Controller
    {
        public IDanhMucChiTietService _dmct;
        public DanhMucChiTietController()
        {
            _dmct = new DanhMucChiTietMucChiTietService();
        }
        // GET: HomeController
        [HttpGet]
        public ActionResult Index()
        {
            var a = _dmct.GetAll();
            return View(a);
        }

        // GET: HomeController/Details/5
        public ActionResult Details(Guid id)
        {
            var a = _dmct.GetById(id);
            return View(a);
        }

        // GET: HomeController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SanPhamController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(DanhMucChiTiet p, [Bind] IFormFile imageFile)
        {


            if (_dmct.Them(p)) // Nếu thêm thành công
            {

                return RedirectToAction("Index");
            }

            return View();
        }

        // GET: SanPhamController/Edit/5
        [HttpGet]
        public ActionResult Edit(Guid id)
        {
            var a = _dmct.GetById(id);
            return View(a);
        }

        // POST: SanPhamController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(DanhMucChiTiet p, [Bind] IFormFile imageFile)
        {

            if (_dmct.Sua(p))
            {
                return RedirectToAction("Index");

            }
            return View();
        }

        // GET: SanPhamController/Delete/5
        public ActionResult Delete(Guid id)
        {
            if (_dmct.Xoa(id))
            {
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }
    }
}
