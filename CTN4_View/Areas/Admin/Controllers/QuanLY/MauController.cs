 using CTN4_Data.Models.DB_CTN4;
using CTN4_Serv.Service;
using CTN4_Serv.Service.IService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using X.PagedList;

namespace CTN4_View_Admin.Controllers.QuanLY
{
    [Area("admin")]
    public class MauController : Controller
    {
        public IMauService _mau;
        public MauController()
        {
            _mau = new MauService();
        }
        // GET: MauController
        [HttpGet]
        public ActionResult Index(string TenSp, int? page, int? size)
        {
            var sanPhamList = _mau.GetAll().ToList();

            if (!string.IsNullOrEmpty(TenSp))
            {
                sanPhamList = sanPhamList
                    .Where(c => c.TenMau.ToLower().Contains(TenSp.ToLower()))
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
        // GET: MauController/Details/5
        public ActionResult Details(Guid id)
        {
            var a = _mau.GetById(id);
            return View(a);
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
             a.TenMau = a.TenMau?.Trim();
             var check = _mau.GetAll().FirstOrDefault(c=>c.TenMau == a.TenMau);
            // Check for duplicate TenNSX
            if (check != null)
            {
                ModelState.AddModelError("TenMau", "Tên màu sắc đã tồn tại. Vui lòng chọn một tên khác.");
                return View();
            }
            var b = new Mau();
            {
                b.TenMau = a.TenMau;
                b.TrangThai = true;
                b.Is_detele = true;
            }
            if (_mau.Them(b))
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
