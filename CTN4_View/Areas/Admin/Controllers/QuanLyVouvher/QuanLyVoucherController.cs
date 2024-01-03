﻿using CTN4_Data.Models.DB_CTN4;
using CTN4_Serv.Service.IService;
using CTN4_Serv.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using X.PagedList;
using CTN4_View.Areas.Admin.Viewmodel;
using CTN4_Serv.ViewModel;

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

        [HttpGet]
        public ActionResult Index(string MaGiam, int? size, int? page) /*, DateTime Ngaybatdau, DateTime Ngayketthuc*//*, float from, float to*/
        {
            var a = _gg.GetAll().Where(c => c.Is_detele == true).ToList().AsQueryable();

            page = page ?? 1;

            

            if (!string.IsNullOrEmpty(MaGiam))
            {
                a = a.Where(c => c.MaGiam.Contains(MaGiam, StringComparison.OrdinalIgnoreCase)); // Chắc chắn chuyển kết quả thành danh sách

            }

            int pageSize = size ?? 10;
            var pageNumber = page ?? 1;
            var pagedList = a.ToPagedList(pageNumber, pageSize);
            //var pagedList = a.Where(c => c.Is_detele == true).ToPagedList(pageNumber, pageSize);

            return View(pagedList);
        }
      






        // lọc




        //public IActionResult GiamHet()
        //{
        //    var hd = _gg.GetAll();
        //    var view = new GiamGiaViewModel()
        //    {
        //        GiamGias = hd.ToList(),
        //    };
        //    return View("Index", view);



        //}
        //public IActionResult GiamTien(int? page, bool loaiGiamGia = false)
        //{
        //    var hd = _gg.GetAll();
        //    var pageNumber = page ?? 1;
        //    var pageSize = 5; // Số lượng phần tử trên mỗi trang

        //    var view = new GiamGiaViewModel()
        //    {
        //        GiamGias = hd.Where(c => c.LoaiGiamGia == loaiGiamGia).ToPagedList(pageNumber, pageSize).ToList(),
        //    };
        //    return View("Index", view);
        //}

        //public IActionResult GiamPhanTram(int? page, bool loaiGiamGia = true)
        //{
        //    var hd = _gg.GetAll();
        //    var pageNumber = page ?? 1;
        //    var pageSize = 5; // Số lượng phần tử trên mỗi trang

        //    var view = new GiamGiaViewModel()
        //    {
        //        GiamGias = hd.Where(c => c.LoaiGiamGia == loaiGiamGia).ToPagedList(pageNumber, pageSize).ToList(),
        //    };
        //    return View("Index", view);
        //}

        public IActionResult TatCa(int? page)
        {
            var giamGias = _gg.GetAll().Where(c => c.Is_detele == true).ToList();/*.Where(c => c.LoaiGiamGia == true || false).ToList()*/;
            int pageNumber = page ?? 1;
            int pageSize = 10; // Số lượng item trên mỗi trang

            var pagedList = giamGias.ToPagedList(pageNumber, pageSize);

            return View("Index", pagedList);
        }
        //public IActionResult CacMaDangHien(int? page)
        //{
        //    var giamGias = _gg.GetAll().Where(c => c.Is_detele == true).ToList();/*.Where(c => c.LoaiGiamGia == true || false).ToList()*/;
        //    int pageNumber = page ?? 1;
        //    int pageSize = 10; // Số lượng item trên mỗi trang

        //    var pagedList = giamGias.ToPagedList(pageNumber, pageSize);

        //    return View("Index", pagedList);
        //}
        public IActionResult GiamTien(int? page)
        {
            var giamGias = _gg.GetAll().Where(c => c.LoaiGiamGia == false).ToList();
            int pageNumber = page ?? 1;
            int pageSize = 10; // Số lượng item trên mỗi trang

            var pagedList = giamGias.ToPagedList(pageNumber, pageSize);

            return View("Index", pagedList);
        } 

        public IActionResult GiamPhanTram(int? page)
        {
            var giamGias = _gg.GetAll().Where(c => c.LoaiGiamGia == true).ToList();
            int pageNumber = page ?? 1;
            int pageSize = 10;

            var pagedList = giamGias.ToPagedList(pageNumber, pageSize);

            return View("Index", pagedList);
        }
        public IActionResult XemDaBiAn(int? page)
        {
            var giamGias = _gg.GetAll().Where(c => c.Is_detele == false).ToList();
            int pageNumber = page ?? 1;
            int pageSize = 10; // Số lượng item trên mỗi trang

            var pagedList = giamGias.ToPagedList(pageNumber, pageSize);

            return View("Index", pagedList);

        }
        //public IActionResult CacMaDaAn(int? page)
        //{
        //    var giamGias = _gg.GetAll().Where(c => c.Is_detele != true).ToList();
        //    int pageNumber = page ?? 1;
        //    int pageSize = 10;

        //    var pagedList = giamGias.ToPagedList(pageNumber, pageSize);

        //    return View("Index", pagedList);
        //}


        //public IActionResult Index(int page = 1)
        //{
        //    // Lấy dữ liệu từ nguồn dữ liệu (database, API, ...)
        //    var allItems = GetDataFromSource();

        //    // Số phần tử trên mỗi trang
        //    int pageSize = 10;

        //    // Tính toán tổng số trang
        //    int totalItems = allItems.Count();
        //    int totalPages = (int)Math.Ceiling(totalItems / (double)pageSize);

        //    // Lấy phần của dữ liệu tương ứng với trang hiện tại
        //    var itemsOnPage = allItems.Skip((page - 1) * pageSize).Take(pageSize).ToList();

        //    // Tạo ViewModel và truyền dữ liệu đến View
        //    var viewModel = new PaginatedListViewModel<Item>
        //    {
        //        Items = itemsOnPage,
        //        PageIndex = page,
        //        TotalPages = totalPages
        //    };

        //    return View(viewModel);
        //}
        //public IActionResult GiamGiaPage(int? size, string searchString, int? page)
        //{
        //    // Tạo danh sách kích thước trang để hiển thị trong DropDownList


        //    // Xác định kích thước trang hiện tại từ DropDownList

        //    ViewBag.currentSize = size;

        //    // Xác định trang hiện tại
        //    page = page ?? 1;
        //    int pageNumber = page ?? 1;

        //    // Xác định kích thước trang
        //    int pageSize = size ?? 10;

        //    // Lấy danh sách giảm giá từ dữ liệu (điều này phải thay đổi tùy thuộc vào mô hình của bạn)
        //    var allGiamGia = _gg.GetAll();

        //    // Tìm kiếm nếu có
        //    //if (!string.IsNullOrEmpty(searchString))
        //    //{
        //    //    allGiamGia = allGiamGia.Where(c => c.MaGiam.Contains(searchString));
        //    //}

        //    // Sử dụng PagedList để phân trang
        //    var pagedList = allGiamGia.ToPagedList(pageNumber, pageSize);

        //    return View(pagedList);
        //}
        //public IActionResult Loc(bool LoaiGiamGia)
        //{


        //    LoaiGiamGia = LoaiGiamGia == false;
        //    var danhsach = _gg.GetAll();
        //    danhsach.Insert(0, new GiamGia { LoaiGiamGia == false, GiamGiaChiTiets = "---Hình thức giảm---" });
        //    ViewBag.MaGiam.LoaiGiamGia = new SelectList(danhsach, "LoaiGiamGia", "LoaiGiamGiaName", LoaiGiamGia);
        //    var Loc = _gg.GetAll().Where(c => c.LoaiGiamGia == LoaiGiamGia);
        //    LoaiGiamGia = LoaiGiamGia == false; // Đặt giá trị mặc định nếu LoaiGiamGia là null
        //    var danhsach = _gg.GetAll();

        //    //// Thêm một phần tử đầu tiên với giá trị mặc định
        //    //danhsach.Insert(0, new GiamGia { LoaiGiamGia = false, GiamGiaChiTiets = "---Hình thức giảm---" });

        //    //// Tạo SelectList với danh sách giảm giá và chọn giá trị mặc định
        //    //ViewBag.MaGiam.LoaiGiamGia = new SelectList(danhsach, "LoaiGiamGia", "LoaiGiamGia"); // LoaiGiamGiaName đã được loại bỏ ở đây

        //    //// Lọc danh sách giảm giá dựa trên giá trị của LoaiGiamGia
        //    //var Loc = _gg.GetAll().Where(c => LoaiGiamGia == false || c.LoaiGiamGia == LoaiGiamGia);

        //    return View(LoaiGiamGia);


        //}



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
            //if (ModelState.IsValid)
            //{
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

            //return View();
        }
        //public ActionResult Edit(Guid id)
        //{
        //    var a = _gg.GetById(id);
        //    return View(a);
        //}
        //// POST: PhanLoaiController/Edit/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit(GiamGia a)
        //{

        //    //var tontai = _gg.GetAll().FirstOrDefault(c => c.MaGiam == a.MaGiam && c.Id != a.Id);
        //    //if (tontai != null)
        //    //{
        //    //    ModelState.AddModelError("MaGiam", "Mã giảm không được trùng.");
        //    //    return View(a);
        //    //}

        //        if (_gg.Sua(a)) // Nếu sửa thành công
        //        {
        //            return RedirectToAction("Index");

        //        }
        //        return View();



        //}

        public ActionResult Edit(Guid id)
        {
            var a = _gg.GetById(id);

            // Kiểm tra điều kiện NgayBatDau
            if (a.NgayBatDau <= DateTime.Now)
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

                // Kiểm tra điều kiện NgayBatDau
                //if (a.NgayBatDau <= DateTime.Now)
                //{
                //    ModelState.Remove("NgayBatDau");
                //    ModelState.AddModelError("NgayBatDau", "Không thể sửa đổi khi đã đến thời gian áp dụng.");
                //}




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

