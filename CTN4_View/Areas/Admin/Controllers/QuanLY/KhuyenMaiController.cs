using CTN4_Data.Models.DB_CTN4;
using CTN4_Serv.Service;
using CTN4_Serv.Service.IService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json.Serialization;
using System.Text.Json;
using X.PagedList;

namespace CTN4_View_Admin.Controllers.QuanLY
{
    [Area("admin")]
    public class KhuyenMaiController : Controller
    {
        public IKhuyenMaiService _sv;
        public ISanPhamService _sp;
        public IChatLieuService _cl;
        public INSXService _sx;
        public IDanhMucService _dm;
        public IDanhMucChiTietService _dmct;

        public KhuyenMaiController()
        {
            _sp = new SanPhamService();
            _sv = new KhuyenMaiService();
            _cl = new ChatLieuService();
            _sx = new NSXService();
            _dm = new DanhMucMucService();
            _dmct = new DanhMucChiTietMucChiTietService();
        }
        // GET: KhuyenMaiController
        [HttpGet]
        public ActionResult Index(string searchString, int? page)
        {
            const int pageSize = 10;
            var pageNumber = page ?? 1;

            var a = _sv.GetAll();

            if (!string.IsNullOrEmpty(searchString))
            {
                // Lọc sản phẩm theo tên nếu có chuỗi tìm kiếm
                a = _sv.GetAll().Where(p => p.MaKhuyenMai.Contains(searchString, StringComparison.OrdinalIgnoreCase)).ToList();
            }

            var pagedList = a.ToPagedList(pageNumber, pageSize);

            return View(pagedList);
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
               return View();
            }
        }
        public ActionResult SearchFull(string dieukien)
        {
         
                var search = _sp.TimSanPhamTheoDieuKien(dieukien);
                return Json(search);
           
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
        public ActionResult UpdateGiaSanPham(string[] ids, float giamTheoTien, float giamTheoPh, string tenSanPham, string maSp, string tenChatLieu,
            string tenNSX, string moTa, float giaNhap, float giaBan, float giaNiemYet, string ghiChu, float DongGia)
        {
            TempData["ErrorMessage"] = "Thông báo lỗi của bạn ở đây.";
            foreach (var item in ids)
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