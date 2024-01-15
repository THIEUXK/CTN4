using CTN4_Data.Models.DB_CTN4;
using CTN4_Serv.Service.IService;
using CTN4_Serv.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using X.PagedList;
using CTN4_View.Areas.Admin.Viewmodel;
using CTN4_Serv.ViewModel;
using Microsoft.Diagnostics.Tracing.Parsers.Kernel;
using DocumentFormat.OpenXml.Wordprocessing;

namespace CTN4_View.Areas.Admin.Controllers.QuanLyVouvher
{
    [Area("admin")]
    public class VoucherController : Controller
    {
        public IGiamGiaService _gg;

        public VoucherController()
        {
            _gg = new GiamGiaService();
        }
        // GET: VoucherController
        public class GiamGiaFilter
        {
            public string MaGiam { get; set; }
            public bool? LoaiGiamGia { get; set; }
            public bool? IsDelete { get; set; }
            // Thêm các thuộc tính khác cần lọc tại đây
        }

        [HttpGet]
        public ActionResult Index(string MaGiam, int? size, int? page, bool? loaiGiamGia, bool? Is_detele) /*, DateTime Ngaybatdau, DateTime Ngayketthuc*//*, float from, float to*/
        {



            ViewBag.currentLoaiGiamGia = loaiGiamGia;
            ViewBag.currentIsDelete = Is_detele;
            var a = _gg.GetAll().Where(c => c.Is_detele == true).ToList().AsQueryable();

            page = page ?? 1;



            if (!string.IsNullOrEmpty(MaGiam))
            {
                a = a.Where(c => c.MaGiam.Contains(MaGiam, StringComparison.OrdinalIgnoreCase)); // Chắc chắn chuyển kết quả thành danh sách

            }

            int pageSize = size ?? 15;
            var pageNumber = page ?? 1;
            var pagedList = a.ToPagedList(pageNumber, pageSize);
            //var pagedList = a.Where(c => c.Is_detele == true).ToPagedList(pageNumber, pageSize);

            return View(pagedList);
        }



        #region lọc


        public IActionResult TatCa(int? page, bool Is_detele)
        {
            ViewBag.currentIsDelete = Is_detele;
            var giamGias = _gg.GetAll().Where(c => c.Is_detele == true).ToList();/*.Where(c => c.LoaiGiamGia == true || false).ToList()*/;// lấy hết mã đang hiển thị
            int pageNumber = page ?? 1;
            int pageSize = 15; // Số lượng item trên mỗi trang

            var pagedList = giamGias.ToPagedList(pageNumber, pageSize);

            return View("Index", pagedList);
        }

        public IActionResult GiamTien(int? page, bool loaiGiamGia)
        {
            ViewBag.currentLoaiGiamGia = loaiGiamGia;
            var giamGias = _gg.GetAll().Where(c => c.LoaiGiamGia == false && c.Is_detele == true).ToList();// lấy hết mã đang hiển thị và giảm theo tiền
            int pageNumber = page ?? 1;
            int pageSize = 15; // Số lượng item trên mỗi trang

            var pagedList = giamGias.ToPagedList(pageNumber, pageSize);

            return View("Index", pagedList);
        }

        public IActionResult GiamPhanTram(int? page, bool loaiGiamGia)
        {
            ViewBag.currentLoaiGiamGia = loaiGiamGia;
            var giamGias = _gg.GetAll().Where(c => c.LoaiGiamGia == true && c.Is_detele == true).ToList();// lấy hết mã đang hiển thị và giảm phần trăm
            int pageNumber = page ?? 1;
            int pageSize = 15;

            var pagedList = giamGias.ToPagedList(pageNumber, pageSize);

            return View("Index", pagedList);
        }

        public IActionResult XemDaBiAn(int? page, bool Is_detele = false)
        {
            ViewBag.currentIsDelete = Is_detele;
            var giamGias = _gg.GetAll().Where(c => c.Is_detele == false).ToList();// lấy hết mã đang ẩn
            int pageNumber = page ?? 1;
            int pageSize = 15;

            var pagedList = giamGias.ToPagedList(pageNumber, pageSize);

            return View("Index", pagedList);
        }
        #endregion




        // GET: VoucherController/Details/5
        public ActionResult Details(Guid id)
        {
            var a = _gg.GetById(id);
            return View(a);
        }

        // GET: VoucherController/Create
        public ActionResult Create()
        {
            return View();

        }
        // POST: PhanLoaiController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(GiamGia a)
        {


            a.TrangThai = true;
            a.Is_detele = true;
            var tontai = _gg.GetAll().FirstOrDefault(c => c.MaGiam.ToLower() == a.MaGiam.ToLower() && c.Id != a.Id);
            if (tontai != null)
            {
                ModelState.AddModelError("MaGiam", "Mã giảm không được trùng.");
                return View(a);
            }

            // Kiểm tra thời gian
            if (a.NgayKetThuc <= a.NgayBatDau)
            {
                ModelState.AddModelError("NgayKetThuc", "Thời gian kết thúc phải lớn hơn thời gian bắt đầu.");
                return View(a);
            }

            // Kiểm tra NgayBatDau > Now
            if (a.NgayBatDau <= DateTime.Now)
            {
                ModelState.AddModelError("NgayBatDau", "Thời gian bắt đầu phải lớn hơn thời gian hiện tại.");
                return View(a);
            }


            if (_gg.Them(a)) // Nếu thêm thành công
            {


                return RedirectToAction("Index");
            }
            //}
            return View();


        }


        public ActionResult Edit(Guid id)
        {
            var a = _gg.GetById(id);

            // Kiểm tra điều kiện NgayBatDau
            if (a.NgayBatDau >= DateTime.Now)
            {
                ViewData["IsReadOnly"] = true;
            }
            else
            {
                ViewData["IsReadOnly"] = false;
            }

            return View(a);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(GiamGia a)
        {
            if (a.Is_detele == false)
            {

                a.TrangThai = false;


                if (_gg.Sua(a))
                {

                    return RedirectToAction("Index");
                }

            }
            else
            {


                if (_gg.Sua(a))
                {
                    return RedirectToAction("Index");
                }
            }

            ViewData["IsReadOnly"] = a.NgayBatDau <= DateTime.Now;
            return View(a);
        }


        // GET: GiamGIaController/Delete/5
        public ActionResult Delete(Guid id)
        {
            if (_gg.Xoa(id))
            {
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }
    }
}



