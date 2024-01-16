using CTN4_Data.Models.DB_CTN4;
using CTN4_Serv.Service;
using CTN4_Serv.Service.IService;
using CTN4_Serv.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using X.PagedList;

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
            _chiTietdmService = new DanhMucChiTietMucChiTietService();
            _anhService = new AnhService();
        }
        // GET: PhanLoaiController
        [HttpGet]
        public ActionResult Index(int? size, string searchString, int? page)
        {
            var a = _sv.GetAll().AsQueryable();

            List<SelectListItem> items = new List<SelectListItem>();

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
                a = a.Where(p => p.TenDanhMuc.Contains(searchString, StringComparison.OrdinalIgnoreCase));
            }

            int pageSize = size ?? 10;
            var pageNumber = page ?? 1;
            var pagedList = a.ToPagedList(pageNumber, pageSize);

            return View(pagedList);
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
            a.TenDanhMuc = a.TenDanhMuc?.Trim();
            // Kiểm tra xem đã tồn tại danh mục có tên như a.TenDanhMuc chưa
            var existingDanhMuc = _sv.GetAll().FirstOrDefault(c => c.TenDanhMuc == a.TenDanhMuc);

            if (existingDanhMuc == null)
            {
                // Nếu không tồn tại, thêm danh mục mới
                if (_sv.Them(a))
                {
                    return RedirectToAction("Index");
                }
                return View();
            }

            // Nếu đã tồn tại, có thể xử lý theo nhu cầu của bạn
            // Ví dụ: Hiển thị thông báo lỗi về trùng lặp
            ModelState.AddModelError("TenDanhMuc", "Danh mục đã tồn tại.");

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
            var SP = _sv.GetById(id);
            if (SP.Is_detele == true)
            {
                SP.Is_detele = false;
                _sv.Sua(SP);
            }
            else
            {
                SP.Is_detele = true;
                _sv.Sua(SP);
            }
            return RedirectToAction("Index");
        }

        //public ActionResult Delete(Guid id)
        //{
        //    if (_sv.Xoa(id))
        //    {
        //        return RedirectToAction("Index");
        //    }
        //    return RedirectToAction("Index");
        //}
    }
}
