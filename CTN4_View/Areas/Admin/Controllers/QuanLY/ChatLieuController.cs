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
    public class ChatLieuController : Controller
    {
        public IChatLieuService _sv;

        public ChatLieuController()
        {
            _sv = new ChatLieuService();
        }
        // GET: PhanLoaiController
        [HttpGet]
        public ActionResult Index(string TenSp, int? page, int? size)
        {
            var sanPhamList = _sv.GetAll().ToList();

            if (!string.IsNullOrEmpty(TenSp))
            {
                sanPhamList = sanPhamList
                    .Where(c => c.TenChatLieu.ToLower().Contains(TenSp.ToLower()))
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


        // GET: PhanLoaiController/Details/5
        public ActionResult Details(Guid id)
        {
            var a = _sv.GetById(id);
            return View(a);
        }

        // GET: PhanLoaiController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PhanLoaiController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ChatLieu a)
        {
            a.TenChatLieu = a.TenChatLieu?.Trim();
            // Kiểm tra xem đã tồn tại danh mục có tên như a.TenDanhMuc chưa
            var existingDanhMuc = _sv.GetAll().FirstOrDefault(c => c.TenChatLieu == a.TenChatLieu);

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
            ModelState.AddModelError("TenChatLieu", "Tên chất liệu đã tồn tại.");

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
        public ActionResult Edit(ChatLieu a)
        {
            a.TenChatLieu = a.TenChatLieu?.Trim();
            var check = _sv.GetAll().FirstOrDefault(c => c.TenChatLieu == a.TenChatLieu);
            // Check for duplicate TenNSX
            if (check != null)
            {
                ModelState.AddModelError("TenChatLieu", "Tên chất liệu đã tồn tại. Vui lòng chọn một tên khác.");
                return View();
            }

            var b = new ChatLieu();
            b.Id = a.Id;
            b.TenChatLieu = a.TenChatLieu;
            b.GhiChu = a.GhiChu;
            b.TrangThai = a.TrangThai;
            b.Is_detele = a.Is_detele;

            if (_sv.Sua(b))
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
