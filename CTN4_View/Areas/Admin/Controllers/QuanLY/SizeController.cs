using CTN4_Data.Models.DB_CTN4;
using CTN4_Serv.Service;
using CTN4_Serv.Service.IService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CTN4_View_Admin.Controllers.QuanLY
{
    public class SizeController : Controller
    {
        public ISizeService _sv;


        public SizeController()
        {
            _sv = new SizeService();
        }
        // GET: SizeController
        [HttpGet]
        public ActionResult Index()
        {
            var a = _sv.GetAll();
            return View(a);
        }

        // GET: SizeController/Details/5
        public ActionResult Details(Guid id)
        {
            var a = _sv.GetById(id);
            return View(a);
        }

        // GET: SizeController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SizeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Size a)
        {
            if (_sv.Them(a)) // Nếu thêm thành công
            {

                return RedirectToAction("Index");
            }

            return View();
        }

        // GET: SizeController/Edit/5
        public ActionResult Edit(Guid id)
        {
            var a = _sv.GetById(id);
            return View(a);
        }

        // POST: SizeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Size a)
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

