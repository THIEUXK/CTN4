using CTN4_Data.Models.DB_CTN4;
using CTN4_Serv.Service;
using CTN4_Serv.Service.IService;
using CTN4_Serv.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CTN4_View_Admin.Controllers.QuanLY
{
    [Area("admin")]
    public class NhanVienController : Controller
    {
        public INhanVienService _sv;
        public IChucVuService _chucVuService;

        public NhanVienController()
        {
            _sv = new NhanVienService();
            _chucVuService = new ChucVuService();
        }
        // GET: NhanVienController
        [HttpGet]
        public ActionResult Index()
        {
            var a = _sv.GetAlls();
            return View(a);
        }

        // GET: NhanVienController/Details/5
        public ActionResult Details(Guid id)
        {
            var a = _sv.GetById(id);
            return View(a);
        }

        // GET: NhanVienController/Create
        public ActionResult Create()
        {
            var viewModel = new NhanVienView()
            {
                selectListItemChucVus = _chucVuService.GetAll().Select(s => new SelectListItem
                {
                    Value = s.Id.ToString(),
                    Text = s.TenChucVu
                }).ToList(),
            };
            return View(viewModel);
        }

        // POST: NhanVienController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(NhanVienView p, [Bind] IFormFile imageFile)
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
                p.AnhDaiDien = imageFile.FileName;

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
                var b = new NhanVien()
                {

                    Id = Guid.NewGuid(),
                    Ho = p.Ho,
                    Ten = p.Ten,
                    TenDangNhap = p.TenDangNhap,
                    MatKhau = p.MatKhau,
                    GioiTinh = p.GioiTinh,
                    Email = p.Email,
                    SDT = p.SDT,
                    DiaChi = p.DiaChi,
                    IdChucVu = Guid.Parse(p.IdChucVu.Value.ToString()),
                    Trangthai = true,
                    AnhDaiDien = p.AnhDaiDien,

                };
                if (_sv.Them(b)) // Nếu thêm thành công
                {

                    return RedirectToAction("Index");
                }
                var viewModel = new NhanVienView()
                {
                    selectListItemChucVus = _chucVuService.GetAll().Select(s => new SelectListItem
                    {
                        Value = s.Id.ToString(),
                        Text = s.TenChucVu
                    }).ToList(),

                };
                return View(viewModel);
            }
            else
            {
                var Loi = "Không đúng định dạng ảnh";
                TempData["Loi"] = Loi;
                return RedirectToAction("Index", new { Loi });
            }
        }

        // GET: NhanVienController/Edit/5
        public ActionResult Edit(Guid id)
        {

            var viewModel = new NhanVienView()
            {
                selectListItemChucVus = _chucVuService.GetAll().Select(s => new SelectListItem
                {
                    Value = s.Id.ToString(),
                    Text = s.TenChucVu
                }).ToList(),
                //nhanViens = _sv.GetById(id),
                Id =id,
                Ho = _sv.GetById(id).Ho,
                Ten = _sv.GetById(id).Ten,
                TenDangNhap = _sv.GetById(id).TenDangNhap,
                MatKhau = _sv.GetById(id).MatKhau,
                GioiTinh = _sv.GetById(id).GioiTinh,
                Email = _sv.GetById(id).Email,
                SDT = _sv.GetById(id).SDT,
                DiaChi = _sv.GetById(id).DiaChi,
                IdChucVu = Guid.Parse(_sv.GetById(id).IdChucVu.Value.ToString()),
                Trangthai = _sv.GetById(id).Trangthai,
                AnhDaiDien = _sv.GetById(id).AnhDaiDien,
            };
            return View(viewModel);
        }

        // POST: NhanVienController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(NhanVienView p, [Bind] IFormFile imageFile, string anhdaidiencheck)
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
                p.AnhDaiDien = imageFile.FileName;
            }
            else
            {
                p.AnhDaiDien = anhdaidiencheck;
            }

             var b = new NhanVien()
                {

                    Id =p.Id,
                    Ho = p.Ho,
                    Ten = p.Ten,
                    TenDangNhap = p.TenDangNhap,
                    MatKhau = p.MatKhau,
                    GioiTinh = p.GioiTinh,
                    Email = p.Email,
                    SDT = p.SDT,
                    DiaChi = p.DiaChi,
                    IdChucVu = Guid.Parse(p.IdChucVu.Value.ToString()),
                    Trangthai = p.Trangthai,
                    AnhDaiDien = p.AnhDaiDien,
                    

                };
            if (_sv.Sua(b))
            {
                return RedirectToAction("Index");

            }

            return RedirectToAction("Edit", p.Id);
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

