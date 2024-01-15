using CTN4_Data.DB_Context;
using CTN4_Data.Models.DB_CTN4;
using CTN4_Serv.Service;
using CTN4_Serv.Service.IService;
using CTN4_Serv.ServiceJoin;
using CTN4_Serv.ViewModel;
using CTN4_View.Areas.Admin.Viewmodel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using X.PagedList;

namespace CTN4_View_Admin.Controllers.QuanLY
{
    [Area("admin")]
    public class SanPhamController : Controller
    {
        public ISanPhamChiTietService _sv;
        public IChatLieuService _chatLieuService;
        public INSXService _nsxService;
        public ISanPhamService _spService;
        public ISanPhamService _sanPhamService;
        public IMauService _mauService;
        public ISizeService _sizeService;
        public SanPhamCuaHangService _sanPhamCuaHangService;
        public DB_CTN4_ok _db;
        public IAnhService _anhService;
        public ISanPhamChiTietService _sanPhamChiTietService;
        public SanPhamController()
        {
            _sanPhamChiTietService = new SanPhamChiTietService();
            _sv = new SanPhamChiTietService();
            _chatLieuService = new ChatLieuService();
            _mauService = new MauService();
            _nsxService = new NSXService();
            _spService = new SanPhamService();
            _sizeService = new SizeService();
            _sanPhamCuaHangService = new SanPhamCuaHangService();
            _db = new DB_CTN4_ok();
            _anhService = new AnhService();
            _sanPhamService = new SanPhamService();
        }
        // GET: SanPhamController
        [HttpGet]
        public ActionResult Index(string TenSp, float? tu, float? den, int? page, int? size)
        {
            var sanPhamList = _sanPhamCuaHangService.GetAll().Where(c => c.Is_detele == true).ToList();

            if (!string.IsNullOrEmpty(TenSp))
            {
                sanPhamList = sanPhamList
                    .Where(c => c.TenSanPham.ToLower().Contains(TenSp.ToLower()))
                    .ToList();
            }
            if (tu != null && den != null)
            {
                sanPhamList = sanPhamList
                    .Where(c => (tu == null || c.GiaNiemYet >= tu) && (den == null || c.GiaNiemYet <= den))
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
        public IActionResult SanPhamDaXoa(string TenSp, float? tu, float? den, int? page, int? size)
        {
            var sanPhamList = _sanPhamCuaHangService.GetAll().Where(c => c.Is_detele == false).ToList();

            if (!string.IsNullOrEmpty(TenSp))
            {
                sanPhamList = sanPhamList
                    .Where(c => c.TenSanPham.ToLower().Contains(TenSp.ToLower()))
                    .ToList();
            }
            if (tu != null && den != null)
            {
                sanPhamList = sanPhamList
                    .Where(c => (tu == null || c.GiaNiemYet >= tu) && (den == null || c.GiaNiemYet <= den))
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

            ViewBag.CurrentSize = size ?? 5; // Kích thước trang mặc định


            return View("Index", pagedList);
        }
        // GET: SanPhamController/Details/5
        public ActionResult Details(Guid id)
        {
            var lisanh = _anhService.GetAll();
            var a = _sanPhamService.GetAll().FirstOrDefault(c => c.Id == id);
            var listSPCT = _sanPhamChiTietService.GetAll().Where(c => c.IdSp == id);

            var view = new ThieuxkView()
            {
                SanPham = a,
                sanPhamChiTiets = listSPCT.ToList(),
                AhList = lisanh.ToList(),

            };
            return View(view);
        }

        // GET: SanPhamController/Create
        public ActionResult Create()
        {
            var viewModel = new SanPhamView()
            {
                NsxItems = _nsxService.GetAll().Select(s => new SelectListItem
                {
                    Value = s.Id.ToString(),
                    Text = s.TenNSX
                }).ToList(),
                ChalieuItems = _chatLieuService.GetAll().Select(s => new SelectListItem
                {
                    Value = s.Id.ToString(),
                    Text = s.TenChatLieu
                }).ToList(),
            };
            return View(viewModel);
        }

        // POST: SanPhamController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SanPhamView p, [Bind] IFormFile imageFile)
        {
            const int kichThuocToiDa = 2 * 1024 * 1024; // 2MB
            if (imageFile != null && imageFile.Length > 0) // Không null và không trống
            {
                   // Kiểm tra định dạng của ảnh
                if (imageFile.Length > kichThuocToiDa)
                {
                    var thongbaoAnh = "Kích thước ảnh vượt quá 2MB";
                    TempData["Notification"] = thongbaoAnh;
                    return RedirectToAction("Create", new { id = p.Id });
                }
                var allowedExtensions = new[] { ".jpg", ".png", ".jpeg", ".tiff", ".webp", ".gif" };
                var fileExtension = Path.GetExtension(imageFile.FileName).ToLower();

                if (!allowedExtensions.Contains(fileExtension))
                {
                    var thongbaoAnh = "Định dạng ảnh không được chấp nhận. Chỉ chấp nhận các định dạng: " + string.Join(", ", allowedExtensions);
                    TempData["Notification"] = thongbaoAnh;
                    return RedirectToAction("Create", new { id = p.Id });
                }
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
                var b = new SanPham()
                {

                    Id = Guid.NewGuid(),
                    MaSp = p.MaSp,
                    TenSanPham = p.TenSanPham,
                    IdChatLieu = Guid.Parse(p.IdChatLieu.Value.ToString()),
                    IdNSX = Guid.Parse(p.IdNSX.Value.ToString()),
                    MoTa = p.MoTa,
                    TrangThai = true,
                    GiaNhap = p.GiaNhap,
                    GiaBan = p.GiaBan,
                    GiaNiemYet = p.GiaNiemYet,
                    GhiChu = p.GhiChu,
                    Is_detele = true,
                    AnhDaiDien = p.AnhDaiDien,

                };
                if (_sanPhamService.Them(b)) // Nếu thêm thành công
                {

                    return RedirectToAction("Index");
                }
                var viewModel = new SanPhamView()
                {
                    NsxItems = _nsxService.GetAll().Select(s => new SelectListItem
                    {
                        Value = s.Id.ToString(),
                        Text = s.TenNSX
                    }).ToList(),
                    ChalieuItems = _chatLieuService.GetAll().Select(s => new SelectListItem
                    {
                        Value = s.Id.ToString(),
                        Text = s.TenChatLieu
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
        // GET: SanPhamController/Edit/5

        public ActionResult Edit(Guid id)
        {
            var viewModel = new SanPhamView()
            {
                ChalieuItems = _chatLieuService.GetAll().Select(s => new SelectListItem
                {
                    Value = s.Id.ToString(),
                    Text = s.TenChatLieu
                }).ToList(),
                NsxItems = _nsxService.GetAll().Select(s => new SelectListItem
                {
                    Value = s.Id.ToString(),
                    Text = s.TenNSX
                }).ToList(),
                sanPham = _sanPhamService.GetById(id),
                MaSp = _sanPhamService.GetById(id).MaSp,
                TenSanPham = _sanPhamService.GetById(id).TenSanPham,
                IdChatLieu = Guid.Parse(_sanPhamService.GetById(id).IdChatLieu.Value.ToString()),
                IdNSX = Guid.Parse(_sanPhamService.GetById(id).IdNSX.Value.ToString()),
                MoTa = _sanPhamService.GetById(id).MoTa,
                TrangThai = _sanPhamService.GetById(id).TrangThai,
                GiaNhap = _sanPhamService.GetById(id).GiaNhap,
                GiaBan = _sanPhamService.GetById(id).GiaBan,
                GiaNiemYet = _sanPhamService.GetById(id).GiaNiemYet,
                GhiChu = _sanPhamService.GetById(id).GhiChu,
                Is_detele = _sanPhamService.GetById(id).Is_detele,
                AnhDaiDien = _sanPhamService.GetById(id).AnhDaiDien,
                Id = id,

            };

            return View(viewModel);
        }

        // POST: SanPhamController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(SanPhamView c, [Bind] IFormFile imageFile, string anhdaidiencheck)
        {
            const int kichThuocToiDa = 2 * 1024 * 1024; // 2MB
            if (imageFile != null && imageFile.Length > 0) // Không null và không trống
            {
                 // Kiểm tra định dạng của ảnh
                if (imageFile.Length > kichThuocToiDa)
                {
                    var thongbaoAnh = "Kích thước ảnh vượt quá 2MB";
                    TempData["Notification"] = thongbaoAnh;
                    return RedirectToAction("Edit", new { id = c.Id });
                }
                var allowedExtensions = new[] { ".jpg", ".png", ".jpeg", ".tiff", ".webp", ".gif" };
                var fileExtension = Path.GetExtension(imageFile.FileName).ToLower();

                if (!allowedExtensions.Contains(fileExtension))
                {
                    var thongbaoAnh = "Định dạng ảnh không được chấp nhận. Chỉ chấp nhận các định dạng: " + string.Join(", ", allowedExtensions);
                    TempData["Notification"] = thongbaoAnh;
                    return RedirectToAction("Edit", new { id = c.Id });
                }
               
                
                //Trỏ tới thư mục wwwroot để lát nữa thực hiện việc Copy sang
                var path = Path.Combine(
                    Directory.GetCurrentDirectory(), "wwwroot", "image", imageFile.FileName);
                using (var stream = new FileStream(path, FileMode.Create))
                {
                    // Thực hiện copy ảnh vừa chọn sang thư mục mới (wwwroot)
                    imageFile.CopyTo(stream);
                }

                // Gán lại giá trị cho Description của đối tượng bằng tên file ảnh đã được sao chép
                c.AnhDaiDien = imageFile.FileName;
            }
            else
            {
                c.AnhDaiDien = anhdaidiencheck;
            }

            var p = new SanPham()
            {
                Id = c.Id,
                MaSp = c.MaSp,
                TenSanPham = c.TenSanPham,
                IdChatLieu = Guid.Parse(c.IdChatLieu.Value.ToString()),
                IdNSX = Guid.Parse(c.IdNSX.Value.ToString()),
                MoTa = c.MoTa,
                TrangThai = c.TrangThai,
                GiaNhap = c.GiaNhap,
                GiaBan = c.GiaBan,
                GiaNiemYet = c.GiaNiemYet,
                GhiChu = c.GhiChu,
                Is_detele = c.Is_detele,
                AnhDaiDien = c.AnhDaiDien,

            };
            if (_sanPhamService.Sua(p))
            {
                return RedirectToAction("Index");

            }

            return RedirectToAction("Edit", p.Id);
        }


        // Hàm kiểm tra và xử lý giá trị TenSanPham

        // GET: SanPhamController/Delete/5
        public ActionResult Delete(Guid id)
        {
            var SP = _sanPhamService.GetById(id);
            if (SP.Is_detele == true)
            {
                SP.Is_detele = false;
                SP.TrangThai = false;
                _sanPhamService.Sua(SP);
            }
            else
            {
                SP.Is_detele = true;
                SP.TrangThai = true;
                _sanPhamService.Sua(SP);
            }
            return RedirectToAction("Index");
        }
        public ActionResult XoaLuon(Guid id)
        {
            if (_sanPhamService.Xoa(id))
            {
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }
        public ActionResult XoaAnh(Guid id, Guid IdSp)
        {
            if (_anhService.Xoa(id))
            {
                return RedirectToAction("Details", new { id = IdSp });
            }
            return RedirectToAction("Details", new { id = IdSp });
        }

    }
}