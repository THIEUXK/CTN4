using CTN4_Data.Models.DB_CTN4;
using CTN4_Serv.Service;
using CTN4_Serv.Service.IService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
            var x = imageFile.FileName;
            if (imageFile != null && imageFile.Length > 0) // Không null và không trống
            {
                //Trỏ tới thư mục wwwroot để lát nữa thực hiện việc Copy sang
                var path = Path.Combine(
                    Directory.GetCurrentDirectory(), "wwwroot", "image", imageFile.FileName);
                using (var stream = new FileStream(path, FileMode.Create))
                {
                    // Thực hiện copy ảnh vừa chọn sang thư mục mới (wwwroot)
                    imageFile.CopyTo(stream);
                }

                // Gán lại giá trị cho Description của đối tượng bằng tên file ảnh đã được sao chép
                a.AnhDaiDien = imageFile.FileName;
            }
            if (_kh.Them(a)) // Nếu thêm thành công
            {

                return RedirectToAction("Index");
            }

            return View();
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
        public ActionResult Edit(KhachHang a, [Bind] IFormFile imageFile)
        {
            if (imageFile != null && imageFile.Length > 0) // Không null và không trống
            {
                //Trỏ tới thư mục wwwroot để lát nữa thực hiện việc Copy sang
                var path = Path.Combine(
                    Directory.GetCurrentDirectory(), "wwwroot", "image", imageFile.FileName);
                using (var stream = new FileStream(path, FileMode.Create))
                {
                    // Thực hiện copy ảnh vừa chọn sang thư mục mới (wwwroot)
                    imageFile.CopyTo(stream);
                }

                // Gán lại giá trị cho Description của đối tượng bằng tên file ảnh đã được sao chép
                a.AnhDaiDien = imageFile.FileName;
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
