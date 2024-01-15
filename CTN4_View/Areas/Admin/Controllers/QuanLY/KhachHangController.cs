using CTN4_Data.Models.DB_CTN4;
using CTN4_Serv.Service;
using CTN4_Serv.Service.IService;
using CTN4_Serv.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CTN4_View_Admin.Controllers.QuanLY
{
    [Area("admin")]
    public class KhachHangController : Controller
    {
        public IKhachHangService _kh;

        public KhachHangController()
        {
            _kh = new KhachHangService();
        }
        // GET: KhachHangController
        [HttpGet]
        public ActionResult Index()
        {
            var a = _kh.GetAll();
            return View(a);
        }

        // GET: KhachHangController/Details/5
        public ActionResult Details(Guid id)
        {
            var a = _kh.GetById(id);
            return View(a);
        }

        // GET: KhachHangController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: KhachHangController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(KhachHang a, [Bind] IFormFile imageFile)
        {
             const int kichThuocToiDa = 2 * 1024 * 1024; // 2MB
             if (imageFile != null && imageFile.Length > 0) // Không null và không trống
                {
                    // Kiểm tra định dạng của ảnh
                if (imageFile.Length > kichThuocToiDa)
                {
                    var thongbaoAnh = "Kích thước ảnh vượt quá 2MB";
                    TempData["Notification"] = thongbaoAnh;
                    return RedirectToAction("Create", new { id = a.Id });
                }
                var allowedExtensions = new[] { ".jpg", ".png", ".jpeg", ".tiff", ".webp", ".gif" };
                var fileExtension = Path.GetExtension(imageFile.FileName).ToLower();

                if (!allowedExtensions.Contains(fileExtension))
                {
                    var thongbaoAnh = "Định dạng ảnh không được chấp nhận. Chỉ chấp nhận các định dạng: " + string.Join(", ", allowedExtensions);
                    TempData["Notification"] = thongbaoAnh;
                    return RedirectToAction("Create", new { id = a.Id });
                }
                    //Trỏ tới thư mục wwwroot để lát nữa thực hiện việc Copy sang
                    var path = Path.Combine(
                        Directory.GetCurrentDirectory(), "wwwroot", "anhdd", imageFile.FileName);
                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        // Thực hiện copy ảnh vừa chọn sang thư mục mới (wwwroot)
                        imageFile.CopyTo(stream);
                    }

                    // Gán lại giá trị cho Description của đối tượng bằng tên file ảnh đã được sao chép
                    a.AnhDaiDien = imageFile.FileName;

                }
                else
                {
                    var thongbaoAnh = "Hay them anh";
                    TempData["Notification"] = thongbaoAnh;
                    return RedirectToAction("Create", new { thongbaoAnh });
                }
                if (System.IO.Path.GetExtension(imageFile.FileName) == ".jpg" ||
                System.IO.Path.GetExtension(imageFile.FileName) == ".png" ||
                System.IO.Path.GetExtension(imageFile.FileName) == ".jpeg" ||
                System.IO.Path.GetExtension(imageFile.FileName) == ".tiff" ||
                System.IO.Path.GetExtension(imageFile.FileName) == ".webp" ||
                System.IO.Path.GetExtension(imageFile.FileName) == ".gif")
                {
                    var b = new KhachHang()
                    {

                        Id = Guid.NewGuid(),
                        Ho = a.Ho,
                        Ten = a.Ten,
                        TenDangNhap = a.TenDangNhap,
                        MatKhau = a.MatKhau,
                        GioiTinh = a.GioiTinh,
                        Email = a.Email,
                        DiaChi = a.DiaChi,
                        SDT = a.SDT,
                        Trangthai = true,
                        Is_detele = true,
                        AnhDaiDien = a.AnhDaiDien,

                    };
                    if (_kh.Them(b)) // Nếu thêm thành công
                    {

                        return RedirectToAction("Index");
                    }
                    
                    return View();
                }
                else
                {
                    var Loi = "Không đúng định dạng ảnh";
                    TempData["Loi"] = Loi;
                    return RedirectToAction("Index", new { Loi });
                }
            }

        // GET: KhuyenMaiController/Edit/5
        public ActionResult Edit(Guid id)
        {
            var a = _kh.GetById(id);
            return View(a);
        }
        // POST: KhachHangController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(KhachHang a, [Bind] IFormFile imageFile, string anhdaidiencheck)
        {
            const int kichThuocToiDa = 2 * 1024 * 1024; // 2MB
            if (imageFile != null && imageFile.Length > 0) // Không null và không trống
            {
                 // Kiểm tra định dạng của ảnh
                if (imageFile.Length > kichThuocToiDa)
                {
                    var thongbaoAnh = "Kích thước ảnh vượt quá 2MB";
                    TempData["Notification"] = thongbaoAnh;
                    return RedirectToAction("Edit", new { id = a.Id });
                }
                var allowedExtensions = new[] { ".jpg", ".png", ".jpeg", ".tiff", ".webp", ".gif" };
                var fileExtension = Path.GetExtension(imageFile.FileName).ToLower();

                if (!allowedExtensions.Contains(fileExtension))
                {
                    var thongbaoAnh = "Định dạng ảnh không được chấp nhận. Chỉ chấp nhận các định dạng: " + string.Join(", ", allowedExtensions);
                    TempData["Notification"] = thongbaoAnh;
                    return RedirectToAction("Edit", new { id = a.Id });
                }
               
                
                //Trỏ tới thư mục wwwroot để lát nữa thực hiện việc Copy sang
                var path = Path.Combine(
                    Directory.GetCurrentDirectory(), "wwwroot", "anhdd", imageFile.FileName);
                using (var stream = new FileStream(path, FileMode.Create))
                {
                    // Thực hiện copy ảnh vừa chọn sang thư mục mới (wwwroot)
                    imageFile.CopyTo(stream);
                }

                // Gán lại giá trị cho Description của đối tượng bằng tên file ảnh đã được sao chép
                a.AnhDaiDien = imageFile.FileName;
            }
            else
            {
                a.AnhDaiDien = anhdaidiencheck;
            }

            if (_kh.Sua(a))
            {
                return RedirectToAction("Index");

            }


            return View();
        }

        public ActionResult Delete(Guid id)
        {
            if (_kh.Xoa(id))
            {
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }
    }
}
