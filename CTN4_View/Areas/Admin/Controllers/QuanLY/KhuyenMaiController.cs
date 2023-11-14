using CTN4_Data.Models.DB_CTN4;
using CTN4_Serv.Service;
using CTN4_Serv.Service.IService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json.Serialization;
using System.Text.Json;

namespace CTN4_View_Admin.Controllers.QuanLY
{
    [Area("admin")]
    public class KhuyenMaiController : Controller
    {
        public IKhuyenMaiService _sv;
        public ISanPhamService _sp;
        public IChatLieuService _cl;
        public INSXService _sx;

        public KhuyenMaiController()
        {
            _sp = new SanPhamService();
            _sv = new KhuyenMaiService();
            _cl = new ChatLieuService();
            _sx = new NSXService();
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
        public ActionResult Creates(KhuyenMai a)
        {

            a.TrangThai = true;
             a.Is_Detele = true;
            _sv.Them(a);
             return RedirectToAction("Index");
            
            
           
        }

        // GET: KhuyenMaiController/Edit/5
        public ActionResult Edit(Guid id)
        {
            ViewBag.lstcl = _cl.GetAll();
            ViewBag.lstnsx = _sx.GetAll();
            var lstSp = _sp.GetAll();

            
                ViewBag.lstSp2 = lstSp;
            
           
            ViewBag.lstSp = lstSp;

            var a = _sv.GetById(id);
            return View(a);
        }

        [HttpGet]
        public ActionResult SearchProduct( string name)
        {
            var obj = _sp.GetAllBySearch(name); 
            return Json(obj);
        }
        public ActionResult GetallNsx()
        {
         
            var a = _sx.GetAll();
            return Json(a);
        }

        public ActionResult Getallsp()
        {
            try
            {
               
                var a = _sp.GetAllProduct();
                return Json(a);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public ActionResult Getallcl()
        {

            var a = _cl.GetAll();
            return Json(a);
        }
        // POST: KhuyenMaiController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(KhuyenMai a)
        {
            if (_sv.Sua(a))
            {
                a.TrangThai = true;
                a.Is_Detele = true;
                return RedirectToAction("Index");

            }
            return View();
        }

        [HttpPost]
        public ActionResult UpdateGiaSanPham(string[] Ids, float giamTheoTien, float giamTheoPh, string tenSanPham, string maSp, string tenChatLieu,
            string tenNSX, string moTa, float giaNhap, float giaBan, float giaNiemYet, string ghiChu, float DongGia)
        {
            TempData["ErrorMessage"] = "Thông báo lỗi của bạn ở đây.";
            foreach (var item in Ids)
            {
                var sp = _sp.GetById(Guid.Parse(item.ToString()));
                if (giamTheoTien > 0)
                {
                    sp.GiaNiemYet = sp.GiaBan - giamTheoTien;
                }
                // chỉ đc giảm theo tiền hoặc % không có giảm cả 2
                else if (giamTheoPh > 0)
                {
                    sp.GiaNiemYet = sp.GiaBan - (sp.GiaBan * giamTheoPh / 100);
                }else if(DongGia > 0)
                {
                    sp.GiaNiemYet = DongGia;
                }
                _sp.Sua(sp);
            }
            //if (TempData.ContainsKey("ErrorMessage"))
            //{
            //    ViewBag.ErrorMessage = TempData["ErrorMessage"];
            //}
            var filteredProducts = _sp.GetAll();
            if (!string.IsNullOrEmpty(maSp))
            {
                filteredProducts = (List<SanPham>)filteredProducts.Where(p => p.MaSp == maSp);
            }
            if (!string.IsNullOrEmpty(tenSanPham))
            {
                filteredProducts = (List<SanPham>)filteredProducts.Where(p => p.TenSanPham == tenSanPham);
            }
            if (!string.IsNullOrEmpty(maSp))
            {
                filteredProducts = (List<SanPham>)filteredProducts.Where(p => p.MaSp == maSp);
            }
            return View(filteredProducts);
        }
        [HttpPost]
        public ActionResult HuyApDungKm(string[] Ids)
        {
            foreach (var item in Ids)
            {
                var sp = _sp.GetById(Guid.Parse(item.ToString()));
                sp.GiaNiemYet = sp.GiaBan;
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