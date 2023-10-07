using CTN4_Data.Models.DB_CTN4;
using CTN4_Serv.Service;
using CTN4_Serv.Service.IService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CTN4_View_Admin.Controllers.QuanLY
{
    [Area("admin")]
    public class PhuongThucThanhToanController : Controller
    {
         public IPhuongThucThanhToanService _pttt;

        public PhuongThucThanhToanController()
        {
            _pttt = new PhuongThucThanhToanService();
        }
        // GET: PhuongThucThanhToanController
        public ActionResult Index()
        {
             var a = _pttt.GetAll();
            return View(a);
        }

        // GET: PhuongThucThanhToanController/Details/5
        public ActionResult Details(Guid id)
        {
            var a = _pttt.GetById(id);
            return View(a);
        }

        // GET: PhuongThucThanhToanController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PhuongThucThanhToanController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PhuongThucThanhToan a)
        {
            if (_pttt.Them(a)) // Nếu thêm thành công
            {

                return RedirectToAction("Index");
            }

            return View();
        }

        // GET: PhuongThucThanhToanController/Edit/5
        public ActionResult Edit(Guid id)
        {
            var a = _pttt.GetById(id);
            return View(a);
        }

        // POST: PhuongThucThanhToanController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(PhuongThucThanhToan a)
        {
             if (_pttt.Sua(a))
            {
                return RedirectToAction("Index");

            }
            return View();
        }

         public ActionResult Delete(Guid id)
        {
            if (_pttt.Xoa(id))
            {
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }
    }
}
