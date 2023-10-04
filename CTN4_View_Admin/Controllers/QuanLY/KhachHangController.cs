using CTN4_Data.Models.DB_CTN4;
using CTN4_Serv.Service;
using CTN4_Serv.Service.IService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CTN4_View_Admin.Controllers.QuanLY
{
    public class KhachHangController : Controller
    {
         public IKhachHangService _kh;

        public KhachHangController()
        {
            _kh = new KhachHangService();
        }
        // GET: KhachHangController
        [HttpGet]
        public ActionResult Index()
        {
            var a = _kh.GetAll();
            return View(a);
        }

        // GET: KhachHangController/Details/5
        public ActionResult Details(Guid id)
        {
            var a = _kh.GetById(id);
            return View();
        }

        // GET: KhachHangController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: KhachHangController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(KhachHang a)
        {
            if (_kh.Them(a))
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        
        // GET: KhuyenMaiController/Edit/5
        public ActionResult Edit(Guid id)
        {
            var a = _kh.GetById(id);
            return View(a);
        }
        // POST: KhachHangController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(KhachHang a)
        {
            if (_kh.Sua(a))
            {
                return RedirectToAction("Index");

            }
            return View();
        }

         public ActionResult Delete(Guid id)
        {
            if (_kh.Xoa(id))
            {
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }
    }
}
