using CTN4_Data.Models.DB_CTN4;
using CTN4_Serv.Service;
using CTN4_Serv.Service.IService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using X.PagedList;

namespace CTN4_View_Admin.Controllers.QuanLY
{
    [Area("admin")]
    public class SizeController : Controller
    {
        public ISizeService _sv;


        public SizeController()
        {
            _sv = new SizeService();
        }
        // GET: SizeController
        [HttpGet]
        public ActionResult Index(string TenSp, int? page, int? size)
        {
            var sanPhamList = _sv.GetAll().ToList();

            if (!string.IsNullOrEmpty(TenSp))
            {
                sanPhamList = sanPhamList
                    .Where(c => c.TenSize.ToLower().Contains(TenSp.ToLower()))
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

        // GET: SizeController/Details/5
        public ActionResult Details(Guid id)
        {
            var a = _sv.GetById(id);
            return View(a);
        }

        // GET: SizeController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SizeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Size a)
        {
             a.TenSize = a.TenSize?.Trim();
            a.CoSize = a.CoSize?.Trim();
            // Kiểm tra xem đã tồn tại danh mục có tên như a.TenDanhMuc chưa
            var existingDanhMuc = _sv.GetAll().FirstOrDefault(c => c.TenSize == a.TenSize);
            var existingDanhMuc1 = _sv.GetAll().FirstOrDefault(c => c.CoSize == a.CoSize);
            // Check for duplicate TenNSX
           if (existingDanhMuc == null ||  existingDanhMuc1 == null )
            {
               ModelState.AddModelError("TenSize", "Tên size đã tồn tại. Vui lòng chọn một tên khác.");
            ModelState.AddModelError("CoSize", "Cỡ size đã tồn tại. Vui lòng chọn một tên khác.");
            return View();
            }
            var b = new Size();
            {
                b.TenSize = a.TenSize;
                b.CoSize = a.CoSize;
                b.TrangThai = true;
                b.Is_detele = true;

            }
            if (_sv.Them(b)) // Nếu thêm thành công
            {

                return RedirectToAction("Index");
            }

            return View();
        }

        // GET: SizeController/Edit/5
        public ActionResult Edit(Guid id)
        {
            var a = _sv.GetById(id);
            return View(a);
        }

        // POST: SizeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Size a)
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

