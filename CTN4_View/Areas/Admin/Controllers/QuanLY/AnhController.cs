using CTN4_Data.Models.DB_CTN4;
using CTN4_Serv.Service;
using CTN4_Serv.Service.IService;
using Microsoft.AspNetCore.Mvc;

namespace CTN4_View_Admin.Controllers.QuanLY
{
    [Area("admin")]
    public class AnhController : Controller
    {
        public IAnhService _anh;
        public AnhController()
        {
            _anh = new AnhService();
        }
        // GET: AnhController
        [HttpGet]
        public ActionResult Index()
        {
            var a = _anh.GetAll();
            return View(a);
        }
        // GET: AnhController/Details/5
        public ActionResult Details(Guid id)
        {
            var a = _anh.GetById(id);
            return View();
        }

        // GET: AnhController/Create
        public ActionResult Create()
        {
            return View();
        }
        // POST: AnhController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Anh a)
        {
            if (_anh.Them(a))
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        // GET: AnhController/Edit/5
        public ActionResult Edit(Guid id)
        {
            var a = _anh.GetById(id);
            return View(a);
        }
        // POST: AnhController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Anh a)
        {
            if (_anh.Sua(a))
            {
                return RedirectToAction("Index");

            }
            return View();
        }

        public ActionResult Delete(Guid id)
        {
            if (_anh.Xoa(id))
            {
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }

        //public IActionResult Index()
        //{
        //    return View();
        //}
    }
}
