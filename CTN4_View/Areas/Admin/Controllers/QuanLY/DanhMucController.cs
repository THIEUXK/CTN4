using CTN4_Data.Models.DB_CTN4;
using CTN4_Serv.Service;
using CTN4_Serv.Service.IService;
using CTN4_Serv.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace CTN4_View_Admin.Controllers.QuanLY
{
    [Area("admin")]
    public class DanhMucController : Controller
    {
        public IDanhMucService _sv;
        public IDanhMucChiTietService _chiTietdmService;
        public IAnhService _anhService;

        public DanhMucController()
        {
            _sv = new DanhMucMucService();  
            _chiTietdmService= new DanhMucChiTietMucChiTietService(); 
             _anhService = new AnhService();
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
            var lisanh = _anhService.GetAll();
            var a = _sv.GetById(id);
            var ListDmCt = _chiTietdmService.GetAll().Where(c => c.IdDanhMuc == id);

            var view = new ThieuxkView()
            {
                DanhMuc = a,
                danhMucChiTiets = ListDmCt.ToList(),
                AhList = lisanh.ToList(),

            };
            return View(view);
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
