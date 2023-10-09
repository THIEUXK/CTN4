using CTN4_Data.Models.DB_CTN4;
using CTN4_Serv.Service;
using CTN4_Serv.Service.IService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CTN4_View_Admin.Controllers.QuanLY
{
    [Area("admin")]
    public class KhuyenMaiController : Controller
    {
        public IKhuyenMaiService _sv;

        public KhuyenMaiController()
        {
            _sv = new KhuyenMaiService();
        }
        // GET: KhuyenMaiController
        [HttpGet]
        public ActionResult Index()
        {
            var a = _sv.GetAll();
            return View(a);
        }

        // GET: KhuyenMaiController/Details/5
        public ActionResult Details(Guid id)
        {
            var a = _sv.GetById(id);
            return View(a);
        }

        // GET: KhuyenMaiController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: KhuyenMaiController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(KhuyenMai a)
        {
            if (_sv.Them(a)) // Nếu thêm thành công
            {

                return RedirectToAction("Index");
            }

            return View();
        }

        // GET: KhuyenMaiController/Edit/5
        public ActionResult Edit(Guid id)
        {
            var a = _sv.GetById(id);
            return View(a);
        }

        // POST: KhuyenMaiController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(KhuyenMai a)
        {
            if (_sv.Sua(a))
            {
                return RedirectToAction("Index");

            }
            return View();
        }


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
