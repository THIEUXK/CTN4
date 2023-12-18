using CTN4_Data.Models.DB_CTN4;
using CTN4_Serv.Service;
using CTN4_Serv.Service.IService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CTN4_View_Admin.Controllers.QuanLY
{
    [Area("admin")]
    public class GiamGIaController : Controller
    {
        public IGiamGiaService _gg;

        public GiamGIaController()
        {
            _gg =new GiamGiaService();
        }
        // GET: GiamGIaController
        [HttpGet]
        public ActionResult Index()
        {
             var a = _gg.GetAll();
            return View(a);
        }

        // GET: GiamGIaController/Details/5
        public ActionResult Details(Guid id)
        {
             var a = _gg.GetById(id);
            return View(a);
        }

        // GET: GiamGIaController/Create
        public ActionResult Create()
        {
            return View();
            
        }
        // POST: PhanLoaiController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(GiamGia a)
        {
            if (ModelState.IsValid)
            {
                var tontai = _gg.GetAll().FirstOrDefault(c => c.MaGiam == a.MaGiam && c.Id != a.Id);
                if (tontai != null)
                {
                    ModelState.AddModelError("MaGiam", "Mã giảm không được trùng.");
                    return View(a);
                }

                if (_gg.Them(a)) // Nếu thêm thành công
                {
                   

                    return RedirectToAction("Index");
                }

                return View();
            }
            return View();
        }

        public ActionResult Edit(Guid id)
        {
           var a = _gg.GetById(id);
            return View(a);
        }
        // POST: PhanLoaiController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(GiamGia a)
        {

            //var tontai = _gg.GetAll().FirstOrDefault(c => c.MaGiam == a.MaGiam && c.Id != a.Id);
            //if (tontai != null)
            //{
            //    ModelState.AddModelError("MaGiam", "Mã giảm không được trùng.");
            //    return View(a);
            //}
            if (ModelState.IsValid)
            {
                if (_gg.Sua(a))
                {
                    return RedirectToAction("Index");

                }
                
            }
            return View();
            
           
        }


       
        // GET: GiamGIaController/Delete/5
        public ActionResult Delete(Guid id)
        {
           if (_gg.Xoa(id))
            {
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }
    }
}
