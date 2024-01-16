using CTN4_Data.Models.DB_CTN4;
using CTN4_Serv.Service;
using CTN4_Serv.Service.IService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json.Serialization;
using System.Text.Json;
using X.PagedList;
using Microsoft.AspNetCore.Mvc.Rendering;
using CTN4_View.Areas.Admin.Viewmodel;
using CTN4_Serv.ViewModel;
using System.Drawing;
using System.Net;

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
        public IKhachHangService _kh;
        private readonly IEmailService _EmailService;

        public KhuyenMaiController(IEmailService emailService)
        {
            _sp = new SanPhamService();
            _sv = new KhuyenMaiService();
            _cl = new ChatLieuService();
            _sx = new NSXService();
            _dm = new DanhMucMucService();
            _dmct = new DanhMucChiTietMucChiTietService();
            _kmsp = new KhuyenMaiSanPhamService();
            _kh = new KhachHangService();
            _EmailService = emailService;
        }
        // GET: KhuyenMaiController
        [HttpGet]
        public ActionResult Index(int? size, string searchString,  int? page)
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
                a = a.Where(p => p.MaKhuyenMai.Contains(searchString, StringComparison.OrdinalIgnoreCase));
            }

            int pageSize = size ?? 10;
            var pageNumber = page ?? 1;
            var pagedList = a.ToPagedList(pageNumber, pageSize);

            return View(pagedList);
        }
        public IActionResult DongGia(int? size, int? page)
        {
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
            int pageSize = size ?? 10;
            int pageNumber = page ?? 1;

            var km = _sv.GetAll().Where(c => c.DongGia != 0).ToList();/*.Where(c => c.LoaiGiamGia == true || false).ToList()*/;
            

            var pagedList = km.ToPagedList(pageNumber, pageSize);

            return View("Index", pagedList);
        }

        public IActionResult Mua1Tang1(int? size, int? page)
        {
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
            int pageSize = size ?? 10;
            int pageNumber = page ?? 1;

            var km = _sv.GetAll().Where(c => c.Mua1tang1 == true).ToList();/*.Where(c => c.LoaiGiamGia == true || false).ToList()*/;


            var pagedList = km.ToPagedList(pageNumber, pageSize);

            return View("Index", pagedList);
        }

        public IActionResult PhanTramGiam(int? size, int? page)
        {
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
            int pageSize = size ?? 10;
            int pageNumber = page ?? 1;

            var km = _sv.GetAll().Where(c => c.PhanTramGiamGia != 0).ToList();/*.Where(c => c.LoaiGiamGia == true || false).ToList()*/;


            var pagedList = km.ToPagedList(pageNumber, pageSize);

            return View("Index", pagedList);
        }

        public IActionResult SoTienGiam(int? size, int? page)
        {
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
            int pageSize = size ?? 10;
            int pageNumber = page ?? 1;

            var km = _sv.GetAll().Where(c => c.SoTienGiam != 0).ToList();/*.Where(c => c.LoaiGiamGia == true || false).ToList()*/;


            var pagedList = km.ToPagedList(pageNumber, pageSize);

            return View("Index", pagedList);
        }


        [HttpGet]
        public IActionResult GetActiveKhuyenMai(int? size, string searchString, int? page)
        {
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
            int pageSize = size ?? 10;
            int pageNumber = page ?? 1;

            var b = _sv.GetAll().Where(km => km.TrangThai == true && km.NgayBatDau < DateTime.Now && DateTime.Now <= km.NgayKetThuc).AsQueryable(); ;
            
            if (!string.IsNullOrEmpty(searchString))
            {
                // Lọc sản phẩm theo tên nếu có chuỗi tìm kiếm
                b = b.Where(p => p.MaKhuyenMai.Contains(searchString, StringComparison.OrdinalIgnoreCase));
            }

            var pagedList = b.ToPagedList(pageNumber, pageSize);

            return View(pagedList);
        }
        [HttpGet]
        public IActionResult GetInactiveKhuyenMai(int? size, string searchString,  int? page)
        {
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
            int pageSize = size ?? 10;
            int pageNumber = page ?? 1;

            var inactiveKhuyenMaiList = _sv.GetAll().Where(km => (!km.TrangThai == true || km.NgayBatDau > DateTime.Now) && km.NgayKetThuc >= DateTime.Now).AsQueryable();

            if (!string.IsNullOrEmpty(searchString))
            {
                // Lọc sản phẩm theo tên nếu có chuỗi tìm kiếm
                inactiveKhuyenMaiList = inactiveKhuyenMaiList.Where(p => p.MaKhuyenMai.Contains(searchString, StringComparison.OrdinalIgnoreCase));
            }

            var pagedList = inactiveKhuyenMaiList.ToPagedList(pageNumber, pageSize);

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
        public async Task<ActionResult> Creates([FromForm] KhuyenMai datasubmit, [FromForm] string lstMail)
        {
            var tontai = _sv.GetAll().FirstOrDefault(c => c.MaKhuyenMai.ToLower() == datasubmit.MaKhuyenMai.ToLower() && c.Id != datasubmit.Id);
            // Check tồn tại
            if (tontai != null)
            {
                return Json(new { success = false, errors = new List<string> { "Mã Không được trùng." } });
               
            }

            // Kiểm tra thời gian
            if (datasubmit.NgayKetThuc <= datasubmit.NgayBatDau)
            {
                return Json(new { success = false, errors = new List<string> { "Thời gian kết thúc phải lớn hơn thời gian bắt đầu." } });
            }
            if (datasubmit.NgayKetThuc <= DateTime.Now)
            {
                return Json(new { success = false, errors = new List<string> { "Thời gian kết thúc phải lớn hơn thời gian hiện tại." } });
            }


            // Kiểm tra NgayBatDau > Now
            //if (datasubmit.NgayBatDau <= DateTime.Now)
            //{
            //    ViewBag.Message = "Thời gian bắt đầu phải lớn hơn thời gian hiện tại.";
            //    return View(datasubmit);
            //}

            if (datasubmit.PhanTramGiamGia > 100)
            {
                return Json(new { success = false, errors = new List<string> { "Phần trăm giảm giá không được vượt quá 100%." } });
            }


            if (datasubmit.DongGia > 0 || datasubmit.SoTienGiam > 0  || (datasubmit.PhanTramGiamGia > 0 && datasubmit.PhanTramGiamGia <= 100 )|| datasubmit.Mua1tang1 == true )
            {
                if((datasubmit.DongGia > 0 || datasubmit.SoTienGiam > 0 || datasubmit.PhanTramGiamGia > 0 ) && datasubmit.Mua1tang1 == true)
                {
                    return Json(new { success = false, errors = new List<string> { "Đã chọn mua 1 tặng 1 thì các trường còn lại phải = 0" } });
                }
                else 
                {

                    datasubmit.TrangThai = true;
                    datasubmit.Is_Detele = true;
                    if (_sv.Them(datasubmit))
                    {
                        string imageUrl = "https://png.pngtree.com/png-vector/20210119/ourlarge/pngtree-3d-mega-sale-icon-with-bag-shop-accesories-png-image_2764907.jpg";
                        string base64Image = ConvertImageUrlToBase64(imageUrl);
                        string imageTag = $"<img src='data:image/jpeg;base64,{base64Image}' />";
                        string[] emailAddresses;
                        // Tách địa chỉ email từ chuỗi
                        if (lstMail == null)
                        {
                            emailAddresses = new string[0];
                        }
                        else
                            emailAddresses = lstMail.Split(',');

                        foreach (var emailAddress in emailAddresses)
                        {
                            MailRequest hh = new MailRequest()
                            {
                                Body = "Chào mừng bạn đến với cửa hàng chúng tôi! Chúng tôi đang có khuyến mãi hot, hãy truy cập ngay để không bỏ lỡ: <a href='https://localhost:7174/'>Ấn vào đây để vào cửa hàng </a>",
                                ToEmail = emailAddress.Trim(), // Xóa khoảng trắng từ địa chỉ email
                                Subject = "Cửa hàng đang đại giảm giá"
                            };

                            try
                            {
                                // Gửi email cho từng địa chỉ trong danh sách
                                await _EmailService.SendEmailAsync(hh);
                            }
                            catch (Exception ex)
                            {
                                // Xử lý exception (ghi log, thông báo, ...)
                                Console.WriteLine($"Error sending email to {hh.ToEmail}: {ex.Message}");
                            }

                            // Kiểm soát tốc độ, chờ 1 giây trước khi gửi email tiếp theo
                            //await Task.Delay(1);
                        }
                        return Json(new { success = true, redirectUrl = Url.Action("Index") });
                    }
                }
            }
            else
            {
                return Json(new { success = false, errors = new List<string> { "Vui lòng chỉ được chọn 1 trong 4 trường và lớn hơn 0." } });
            }
            
            return Json(new { success = false, errors = new List<string> { "Không đươc spam." } });
        }

        private string ConvertImageUrlToBase64(string imageUrl)
        {
            using (WebClient client = new WebClient())
            {
                byte[] imageBytes = client.DownloadData(imageUrl);
                return Convert.ToBase64String(imageBytes);
            }
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
        public ActionResult UpdateGiaSanPham(
    string id, string[] ids, float giamTheoTien, float giamTheoPh,
    string tenSanPham, string maSp, string tenChatLieu, string tenNSX,
    string moTa, float giaNhap, float giaBan, float giaNiemYet,
    string ghiChu, float DongGia, DateTime ngayBatDauDate, DateTime ngayKetThucDate)
        {
            TempData["ErrorMessage"] = "";  // Đặt thông báo lỗi về rỗng ban đầu
            DateTime currentDate = DateTime.Now;

            foreach (var itemId in ids)
            {
                var product = _sp.GetById(Guid.Parse(itemId));

                if (IsDiscountValid(giamTheoTien, giamTheoPh, DongGia, product))
                {
                    ApplyDiscount(giamTheoTien, giamTheoPh, DongGia, currentDate, ngayBatDauDate, product);
                    UpdateProductAndAddToPromotion(id, itemId);
                }
                else
                {
                    TempData["ErrorMessage"] = "Giảm giá không hợp lệ vì vượt quá giá gốc của sản phẩm.";
                    break;  // Dừng vòng lặp khi gặp lỗi
                }
            }

            if (!string.IsNullOrEmpty(TempData["ErrorMessage"].ToString()))
            {
                // Nếu có thông báo lỗi, trả về view với thông báo lỗi
                return View();
            }

            var filteredProducts = _sp.GetAll();
            if (!string.IsNullOrEmpty(maSp))
            {
                filteredProducts = filteredProducts.Where(p => p.MaSp == maSp).ToList();
            }
            if (!string.IsNullOrEmpty(tenSanPham))
            {
                filteredProducts = filteredProducts.Where(p => p.TenSanPham == tenSanPham).ToList();
            }

            return View(filteredProducts);
        }

        private bool IsDiscountValid(float giamTheoTien, float giamTheoPh, float DongGia, SanPham product)
        {
            return giamTheoTien < product.GiaBan && giamTheoPh <= 100 && DongGia < product.GiaBan;
        }

        private void ApplyDiscount(float giamTheoTien, float giamTheoPh, float DongGia, DateTime currentDate, DateTime ngayBatDauDate, SanPham product)
        {
            if (currentDate >= ngayBatDauDate)
            {
                if (giamTheoTien > 0 && giamTheoTien < product.GiaBan)
                {
                    product.GiaNiemYet = product.GiaBan - giamTheoTien;
                }
                else if (giamTheoPh > 0 && giamTheoPh <= 100)
                {
                    product.GiaNiemYet = product.GiaBan - (product.GiaBan * giamTheoPh / 100);
                }
                else if (DongGia > 0 && DongGia < product.GiaBan)
                {
                    product.GiaNiemYet = DongGia;
                }
                _sp.Sua(product);
            }
        }

        private void UpdateProductAndAddToPromotion(string promotionId, string productId)
        {
            KhuyenMaiSanPham promotionProduct = new KhuyenMaiSanPham
            {
                Id = Guid.NewGuid(),
                IdkhuyenMai = Guid.Parse(promotionId),
                IdSanPham = Guid.Parse(productId)
            };
            _kmsp.Them(promotionProduct);
        }
        public ActionResult Getallkh()
        {

            var khachHangList = _kh.GetAll();

            // Chỉ lấy thông tin tên và email
            var khachHangInfoList = khachHangList.Select(kh => new
            {
                TenKhachHang = kh.Ten,
                Email = kh.Email
            });

            return Json(khachHangInfoList);
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
        [HttpPost]
        public JsonResult UpdateProductStatus(Guid id)
        {
            var check = _sv.GetAll().FirstOrDefault(c => c.Id == id && ( c.NgayKetThuc  <= DateTime.Now));

            if (check != null)
            {
                KhuyenMai khuyenMai = new KhuyenMai()
                {
                    Id = check.Id,
                    Is_Detele = false
                };
                _sv.CapNhat(id);
                _sv.Sua(khuyenMai);
                

                return Json(new { success = true });
            }

            return Json(new { success = false });
        }


    }
}