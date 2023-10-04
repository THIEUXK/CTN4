using CTN4_Data.Models.DB_CTN4;
using CTN4_Serv.Service.IService;
using CTN4_Serv.Service;
using Microsoft.AspNetCore.Mvc;

namespace CTN4_View_Admin.Controllers.QuanLY
{
    public class NSXController : Controller
    {
        public INSXService _nsx;
        public NSXController()
        {
            _nsx = new NSXService();
        }
        // GET: NSXController
        [HttpGet]
        public ActionResult Index()
        {
            var a = _nsx.GetAll();
            return View(a);
        }
        // GET: NSXController/Details/5
        public ActionResult Details(Guid id)
        {
            var a = _nsx.GetById(id);
            return View();
        }

        // GET: NSXController/Create
        public ActionResult Create()
        {
            return View();
        }
        // POST: NSXController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(NSX a)
        {
            if (_nsx.Them(a))
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        // GET: NSXController/Edit/5
        public ActionResult Edit(Guid id)
        {
            var a = _nsx.GetById(id);
            return View(a);
        }
        // POST: NSXController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(NSX a)
        {
            if (_nsx.Sua(a))
            {
                return RedirectToAction("Index");

            }
            return View();
        }

        public ActionResult Delete(Guid id)
        {
            if (_nsx.Xoa(id))
            {
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }

    }
}
