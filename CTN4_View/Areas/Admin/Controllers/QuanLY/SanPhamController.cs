using CTN4_Data.DB_Context;
using CTN4_Data.Models.DB_CTN4;
using CTN4_Serv.Service;
using CTN4_Serv.Service.IService;
using CTN4_Serv.ServiceJoin;
using CTN4_Serv.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

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
        public ActionResult Index()
        {
            var a = _sanPhamCuaHangService.GetAll();
            return View(a);

        }

        // GET: SanPhamController/Details/5
        public ActionResult Details(Guid id)
        {
            var lisanh = _anhService.GetAll();
            var a = _sanPhamService.GetById(id);
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
            string x = null; // Đảm bảo khởi tạo x là null
            x = imageFile.FileName;
            //var x = imageFile.FileName;
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
            var a = new SanPham()
            {
                Id = Guid.NewGuid(),
                MaSp = p.MaSp,
                TenSanPham = p.TenSanPham,
                IdChatLieu = Guid.Parse(p.IdChatLieu.Value.ToString()),
                IdNSX = Guid.Parse(p.IdNSX.Value.ToString()),

                MoTa = p.MoTa,
                TrangThai = p.TrangThai,
                GiaNhap = p.GiaNhap,
                GiaBan = p.GiaBan,
                GiaNiemYet = p.GiaNiemYet,
                GhiChu = p.GhiChu,
                Is_detele = p.Is_detele,
                AnhDaiDien = p.AnhDaiDien,

            };
            if (_sanPhamService.Them(a)) // Nếu thêm thành công
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
                sanPham = _sanPhamService.GetById(id)
            };

            return View(viewModel);
        }

        // POST: SanPhamController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(SanPham p, [Bind] IFormFile imageFile)
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

            if (_sanPhamService.Sua(p))
            {
                return RedirectToAction("Index");

            }
            return View();
        }

        // GET: SanPhamController/Delete/5
        public ActionResult Delete(Guid id)
        {
            if (_sv.Xoa(id))
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