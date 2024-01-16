using CTN4_Data.Models.DB_CTN4;
using CTN4_Serv.Service.IService;
using CTN4_Serv.Service;
using Microsoft.AspNetCore.Mvc;
using CTN4_Serv.ServiceJoin;
using Microsoft.AspNetCore.Mvc.Rendering;
using X.PagedList;

namespace CTN4_View_Admin.Controllers.QuanLY
{
    [Area("admin")]
    public class NSXController : Controller
    {
        public INSXService _nsx;
        public NSXController()
        {
            _nsx = new NSXService();
        }
        // GET: NSXController
        [HttpGet]
        public ActionResult Index(string TenSp, int? page, int? size)
        {
            var sanPhamList = _nsx.GetAll().ToList();

            if (!string.IsNullOrEmpty(TenSp))
            {
                sanPhamList = sanPhamList
                    .Where(c => c.TenNSX.ToLower().Contains(TenSp.ToLower()))
                    .ToList();
            }
            // Thêm phần phân trang vào đây
            int pageSize = size ?? 10;
            var pageNumber = page ?? 1;
            var pagedList = sanPhamList.ToPagedList(pageNumber, pageSize);
            // Tạo danh sách dropdown kích thước trang
            var pageSizeOptions = new List<SelectListItem>
    {
        new SelectListItem { Text = "10", Value = "10" },
        new SelectListItem { Text = "20", Value = "20" },
        new SelectListItem { Text = "25", Value = "25" },
        new SelectListItem { Text = "50", Value = "50" }
    };
            ViewBag.SizeOptions = new SelectList(pageSizeOptions, "Value", "Text", size);

            ViewBag.CurrentSize = size ?? 10; // Kích thước trang mặc định

            return View(pagedList);
        }
        // GET: NSXController/Details/5
        public ActionResult Details(Guid id)
        {
            var a = _nsx.GetById(id);
            return View(a);
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
            a.TenNSX = a.TenNSX?.Trim();
            var check = _nsx.GetAll().FirstOrDefault(c => c.TenNSX == a.TenNSX);
            // Check for duplicate TenNSX
            if (check != null)
            {
                ModelState.AddModelError("TenNSX", "Tên NSX đã tồn tại. Vui lòng chọn một tên khác.");
                return View();
            }

            var b = new NSX
            {
                TenNSX = a.TenNSX,
                GhiChu = a.GhiChu,
                TrangThai = true,
                Is_detele = true
            };

            if (_nsx.Them(b))
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

} }

