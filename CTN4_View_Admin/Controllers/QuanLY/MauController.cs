using CTN4_Data.Models.DB_CTN4;
using CTN4_Serv.Service;
using CTN4_Serv.Service.IService;
using Microsoft.AspNetCore.Mvc;

namespace CTN4_View_Admin.Controllers.QuanLY
{
    public class MauController : Controller
    {
        public IMauService _mau;
        public MauController()
        {
            _mau = new MauService();
        }
        // GET: MauController
        [HttpGet]
        public ActionResult Index()
        {
            var a = _mau.GetAll();
            return View(a);
        }
        // GET: MauController/Details/5
        public ActionResult Details(Guid id)
        {
            var a = _mau.GetById(id);
            return View();
        }

        // GET: MauController/Create
        public ActionResult Create()
        {
            return View();
        }
        // POST: MauController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Mau a)
        {
            if (_mau.Them(a))
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        // GET: MauController/Edit/5
        public ActionResult Edit(Guid id)
        {
            var a = _mau.GetById(id);
            return View(a);
        }
        // POST: MauController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Mau a)
        {
            if (_mau.Sua(a))
            {
                return RedirectToAction("Index");

            }
            return View();
        }

        public ActionResult Delete(Guid id)
        {
            if (_mau.Xoa(id))
            {
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }

    }
}
