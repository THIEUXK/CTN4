using CTN4_Data.Models.DB_CTN4;
using CTN4_Serv.Service;
using CTN4_Serv.Service.IService;
using Microsoft.AspNetCore.Mvc;

namespace CTN4_View_Admin.Controllers.QuanLY
{
    public class DanhMucController : Controller
    {
        public IDanhMucService _sv;

        public DanhMucController()
        {
            _sv = new DanhMucMucService();  
        }
        // GET: PhanLoaiController
        [HttpGet]
        public ActionResult Index()
        {
            var a = _sv.GetAll();
            return View(a);
        }

        // GET: PhanLoaiController/Details/5
        public ActionResult Details(Guid id)
        {
            var a = _sv.GetById(id);
            return View(a);
        }

        // GET: PhanLoaiController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PhanLoaiController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(DanhMuc a)
        {
            if (_sv.Them(a)) // Nếu thêm thành công
            {

                return RedirectToAction("Index");
            }

            return View();
        }

        // GET: PhanLoaiController/Edit/5
        public ActionResult Edit(Guid id)
        {
            var a = _sv.GetById(id);
            return View(a);
        }

        // POST: PhanLoaiController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(DanhMuc a)
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
