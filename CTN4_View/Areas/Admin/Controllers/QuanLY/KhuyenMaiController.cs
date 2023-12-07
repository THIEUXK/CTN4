using CTN4_Data.Models.DB_CTN4;
using CTN4_Serv.Service;
using CTN4_Serv.Service.IService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json.Serialization;
using System.Text.Json;
using X.PagedList;
using Microsoft.AspNetCore.Mvc.Rendering;

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
        public IKhuyenMaiSanPhamService _kmsp;

        public KhuyenMaiController()
        {
            _sp = new SanPhamService();
            _sv = new KhuyenMaiService();
            _cl = new ChatLieuService();
            _sx = new NSXService();
            _dm = new DanhMucMucService();
            _dmct = new DanhMucChiTietMucChiTietService();
            _kmsp = new KhuyenMaiSanPhamService();
        }
        // GET: KhuyenMaiController
        [HttpGet]
        public ActionResult Index(int? size, string searchString,  int? page)
        {
            var a = _sv.GetAll().AsQueryable();

            List<SelectListItem> items = new List<SelectListItem>();
            items.Add(new SelectListItem { Text = "5", Value = "5" });
            items.Add(new SelectListItem { Text = "10", Value = "10" });
            items.Add(new SelectListItem { Text = "20", Value = "20" });
            items.Add(new SelectListItem { Text = "25", Value = "25" });
            items.Add(new SelectListItem { Text = "50", Value = "50" });

            foreach (var item in items)
            {
                if (item.Value == size.ToString()) item.Selected = true;
            }

            ViewBag.size = items; // ViewBag DropDownList
            ViewBag.currentSize = size; // tạo biến kích thước trang hiện tại
            page = page ?? 1;

            if (!string.IsNullOrEmpty(searchString))
            {
                // Lọc sản phẩm theo tên nếu có chuỗi tìm kiếm
                a = a.Where(p => p.MaKhuyenMai.Contains(searchString, StringComparison.OrdinalIgnoreCase));
            }

            int pageSize = size ?? 5;
            var pageNumber = page ?? 1;
            var pagedList = a.ToPagedList(pageNumber, pageSize);

            return View(pagedList);
        }
        [HttpGet]
        public IActionResult GetActiveKhuyenMai(int? size, string searchString, int? page)
        {
            List<SelectListItem> items = new List<SelectListItem>();
            items.Add(new SelectListItem { Text = "5", Value = "5" });
            items.Add(new SelectListItem { Text = "10", Value = "10" });
            items.Add(new SelectListItem { Text = "20", Value = "20" });
            items.Add(new SelectListItem { Text = "25", Value = "25" });
            items.Add(new SelectListItem { Text = "50", Value = "50" });

            foreach (var item in items)
            {
                if (item.Value == size.ToString()) item.Selected = true;
            }

            ViewBag.size = items; // ViewBag DropDownList
            ViewBag.currentSize = size; // tạo biến kích thước trang hiện tại
            page = page ?? 1;

            var activeKhuyenMaiList = _sv.GetAll().Where(km => km.TrangThai == true).AsQueryable();

            if (!string.IsNullOrEmpty(searchString))
            {
                // Lọc sản phẩm theo tên nếu có chuỗi tìm kiếm
                activeKhuyenMaiList = activeKhuyenMaiList.Where(p => p.MaKhuyenMai.Contains(searchString, StringComparison.OrdinalIgnoreCase));
            }

            const int pageSize = 5;
            var pageNumber = page ?? 1;


            var pagedList = activeKhuyenMaiList.ToPagedList(pageNumber, pageSize);

            return PartialView("_KhuyenMaiList", pagedList);
        }
        [HttpGet]
        public IActionResult GetInactiveKhuyenMai(int? size, string searchString,  int? page)
        {
            List<SelectListItem> items = new List<SelectListItem>();
            items.Add(new SelectListItem { Text = "5", Value = "5" });
            items.Add(new SelectListItem { Text = "10", Value = "10" });
            items.Add(new SelectListItem { Text = "20", Value = "20" });
            items.Add(new SelectListItem { Text = "25", Value = "25" });
            items.Add(new SelectListItem { Text = "50", Value = "50" });

            foreach (var item in items)
            {
                if (item.Value == size.ToString()) item.Selected = true;
            }

            ViewBag.size = items; // ViewBag DropDownList
            ViewBag.currentSize = size; // tạo biến kích thước trang hiện tại
            page = page ?? 1;

            var inactiveKhuyenMaiList = _sv.GetAll().Where(km => !km.TrangThai == true).AsQueryable();

            if (!string.IsNullOrEmpty(searchString))
            {
                // Lọc sản phẩm theo tên nếu có chuỗi tìm kiếm
                inactiveKhuyenMaiList = inactiveKhuyenMaiList.Where(p => p.MaKhuyenMai.Contains(searchString, StringComparison.OrdinalIgnoreCase));
            }

            const int pageSize = 5;
            var pageNumber = page ?? 1;


            var pagedList = inactiveKhuyenMaiList.ToPagedList(pageNumber, pageSize);

            return PartialView("_KhuyenMaiList", pagedList);
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

            if (ModelState.IsValid)
            {
                var tontai = _sv.GetAll().FirstOrDefault(c => c.MaKhuyenMai == a.MaKhuyenMai && c.Id != a.Id);
                if (tontai != null)
                {
                    ModelState.AddModelError("MaKhuyenMai", "Mã khuyến mại không được trùng.");
                    return View(a);
                }
                a.TrangThai = true;
                _sv.Them(a);
                return RedirectToAction("Index");
            }
            return View(a);

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
       
        public ActionResult GetallKm()
        {
            try
            {

                var a = _sp.GetallKM();
                return Json(a);
            }
            catch (Exception)
            {
                return View();
            }
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
        public ActionResult SpKM()
        {
            try
            {

                var a = _sp.GetAllProductWithKhuyenMai();
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
        public ActionResult UpdateGiaSanPham( string id,string[] ids, float giamTheoTien, float giamTheoPh, string tenSanPham, string maSp, string tenChatLieu,
            string tenNSX, string moTa, float giaNhap, float giaBan, float giaNiemYet, string ghiChu, float DongGia, DateTime ngayBatDauDate,DateTime ngayKetThucDate)
        {
            TempData["ErrorMessage"] = "Thông báo lỗi của bạn ở đây.";
            foreach (var item in ids)
            {
                var sp = _sp.GetById(Guid.Parse(item.ToString()));
                if (giamTheoTien > sp.GiaBan || DongGia > sp.GiaBan)
                {
                    TempData["ErrorMessage"] = "Giảm giá không hợp lệ vì vượt quá giá gốc của sản phẩm.";
                    // Xử lý thêm hoặc return nếu cần
                }
                if (giamTheoTien > 0)
                {
                    if (giamTheoTien < sp.GiaBan) // Ensure discount does not exceed original price
                    {
                        sp.GiaNiemYet = sp.GiaBan - giamTheoTien;
                    }
                }
                else if (giamTheoPh > 0)
                {
                    if (giamTheoPh <= 100) // Ensure percentage discount is valid
                    {
                        sp.GiaNiemYet = sp.GiaBan - (sp.GiaBan * giamTheoPh / 100);
                    }
                }
                else if (DongGia > 0)
                {
                    if (DongGia < sp.GiaBan) // Ensure fixed price does not exceed original price
                    {
                        sp.GiaNiemYet = DongGia;
                    }
                }

                KhuyenMaiSanPham km = new KhuyenMaiSanPham()
                {
                    Id = Guid.NewGuid(),
                    IdkhuyenMai = Guid.Parse(id),
                    IdSanPham = Guid.Parse(item)
                };
                _kmsp.Them(km);
                _sp.Sua(sp);
            }

            // Filtering products based on criteria
            var filteredProducts = _sp.GetAll();
            if (!string.IsNullOrEmpty(maSp))
            {
                filteredProducts = (List<SanPham>)filteredProducts.Where(p => p.MaSp == maSp);
            }
            if (!string.IsNullOrEmpty(tenSanPham))
            {
                filteredProducts = (List<SanPham>)filteredProducts.Where(p => p.TenSanPham == tenSanPham);
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