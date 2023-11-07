using CTN4_Data.Models.DB_CTN4;
using CTN4_Serv.Service;
using CTN4_Serv.Service.IService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CTN4_View_Admin.Controllers.QuanLY
{
    [Area("admin")]
    public class KhuyenMaiController : Controller
    {
        public IKhuyenMaiService _sv;
        public ISanPhamService _sp;
        public KhuyenMaiController()
        {
            _sp = new SanPhamService();
            _sv = new KhuyenMaiService();
        }
        // GET: KhuyenMaiController
        [HttpGet]
        public ActionResult Index()
        {
            var a = _sv.GetAll();
            
            return View(a);
        }

        // GET: KhuyenMaiController/Details/5
        public ActionResult Details(Guid id)
        {
            var a = _sv.GetById(id);
            return View(a);
        }

        // GET: KhuyenMaiController/Create
        public ActionResult Create()
        {
            var lstSp = _sp.GetAll();
            ViewBag.lstSp = lstSp;
            return View();
        }

        // POST: KhuyenMaiController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(KhuyenMai a)
        {
            if (_sv.Them(a)) // Nếu thêm thành công
            {

                return RedirectToAction("Index");
            }

            return View();
        }

        // GET: KhuyenMaiController/Edit/5
        public ActionResult Edit(Guid id)
        {
            var lstSp = _sp.GetAll();
            ViewBag.lstSp = lstSp;
            var a = _sv.GetById(id);
            return View(a);
        }

        // POST: KhuyenMaiController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(KhuyenMai a)
        {
            if (_sv.Sua(a))
            {
                return RedirectToAction("Index");

            }
            return View();
        }

        [HttpPost]
        public ActionResult UpdateGiaSanPham(string [] Ids, float giamTheoTien, float giamTheoPh)
        {
            foreach (var item in Ids)
            {
                var sp = _sp.GetById(Guid.Parse(item.ToString()));
                if(giamTheoTien > 0)
                {
                    sp.GiaNiemYet = sp.GiaNiemYet - giamTheoTien;
                }
              // chỉ đc giảm theo tiền hoặc % không có giảm cả 2
                else if(giamTheoPh > 0)
                {
                    sp.GiaNiemYet = sp.GiaNiemYet - (sp.GiaNiemYet * giamTheoPh/100);
                }             
                _sp.Sua(sp);
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
