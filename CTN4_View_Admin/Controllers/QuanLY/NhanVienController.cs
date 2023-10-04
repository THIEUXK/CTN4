using CTN4_Data.Models.DB_CTN4;
using CTN4_Serv.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CTN4_View_Admin.Controllers.QuanLY
{
    public class NhanVienController : Controller
    {
        public NhanVienService _sv;

        public NhanVienController()
        {
            _sv = new NhanVienService();
        }
        // GET: NhanVienController
        [HttpGet]
        public ActionResult Index()
        {
            var a = _sv.GetAll();
            return View(a);
        }

        // GET: NhanVienController/Details/5
        public ActionResult Details(Guid id)
        {
            var a = _sv.GetById(id);
            return View(a);
        }

        // GET: NhanVienController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: NhanVienController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(NhanVien a)
        {
            if (_sv.Them(a)) // Nếu thêm thành công
            {

                return RedirectToAction("Index");
            }

            return View();
        }

        // GET: NhanVienController/Edit/5
        public ActionResult Edit(Guid id)
        {
            var a = _sv.GetById(id);
            return View(a);
        }

        // POST: NhanVienController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(NhanVien a)
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

