using CTN4_Data.Models.DB_CTN4;
using CTN4_Serv.Service;
using CTN4_Serv.Service.IService;
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
        public ActionResult Edit(ChatLieu a)
        {
            var b = new ChatLieu();
            {
                b.TenChatLieu = a.TenChatLieu;
                b.GhiChu = a.GhiChu;
                b.TrangThai = true;
                b.Is_detele = true;
            }
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
