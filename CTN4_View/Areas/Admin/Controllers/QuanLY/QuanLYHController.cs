using CTN4_Data.DB_Context;
using CTN4_Data.Models.DB_CTN4;
using CTN4_Serv.Service;
using CTN4_Serv.Service.IService;
using CTN4_Serv.ServiceJoin;
using CTN4_Serv.ViewModel;
using DocumentFormat.OpenXml.Spreadsheet;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using X.PagedList;

namespace CTN4_View_Admin.Controllers.QuanLY
{
    [Area("admin")]
    public class QuanLYHController : Controller
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

        public QuanLYHController()
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
        // GET: PhanLoaiController
        [HttpGet]
        public ActionResult Index(string TenSp, float? tu, float? den, string colorFilter, string sizeFilter, int? page, int? size)
        {
            var sanPhamList = _sanPhamChiTietService.GetAll();

            if (!string.IsNullOrEmpty(TenSp))
            {
                sanPhamList = sanPhamList
                    .Where(c => c.SanPham.TenSanPham.ToLower().Contains(TenSp.ToLower()))
                    .ToList();
            }

            if (tu != null && den != null)
            {
                sanPhamList = sanPhamList
                    .Where(c => (tu == null || c.SanPham.GiaNiemYet >= tu) && (den == null || c.SanPham.GiaNiemYet <= den))
                    .ToList();
            }

            // Lọc theo màu sắc nếu được chọn
            if (!string.IsNullOrEmpty(colorFilter))
            {
                sanPhamList = sanPhamList
                    .Where(c => c.Mau.TenMau.ToLower() == colorFilter.ToLower())
                    .ToList();
            }

            // Lọc theo kích thước nếu được chọn
            if (!string.IsNullOrEmpty(sizeFilter))
            {
                sanPhamList = sanPhamList
                    .Where(c => c.Size.TenSize.ToLower() == sizeFilter.ToLower())
                    .ToList();
            }

            // Thêm phần phân trang vào đây
            int pageSize = size ?? 5;
            var pageNumber = page ?? 1;
            var pagedList = sanPhamList.ToPagedList(pageNumber, pageSize);

            // Tạo danh sách dropdown kích thước trang
            var pageSizeOptions = new List<SelectListItem>
    {
        new SelectListItem { Text = "5", Value = "5" },
        new SelectListItem { Text = "10", Value = "10" },
        new SelectListItem { Text = "20", Value = "20" },
        new SelectListItem { Text = "25", Value = "25" },
        new SelectListItem { Text = "50", Value = "50" }
    };

            // Tạo danh sách dropdown màu sắc và kích thước
            var colorOptions = sanPhamList.Select(c => c.Mau.TenMau).Distinct().ToList();
            var sizeOptions = sanPhamList.Select(c => c.Size.TenSize).Distinct().ToList();

            ViewBag.SizeOptions = new SelectList(pageSizeOptions, "Value", "Text", size);
            ViewBag.ColorOptions = new SelectList(colorOptions);
            ViewBag.SizeFilter = sizeFilter; // Giữ giá trị đã chọn cho kích thước
            ViewBag.ColorFilter = colorFilter; // Giữ giá trị đã chọn cho màu sắc

            ViewBag.CurrentSize = size ?? 5; // Kích thước trang mặc định

            return View(pagedList);
        }

        // GET: PhanLoaiController/Details/5
        public ActionResult Details(Guid id)
        {
            var SpCT = _sanPhamChiTietService.GetAll().FirstOrDefault(x => x.Id == id);
            var SP = _sanPhamService.GetAll().FirstOrDefault(c => c.Id == SpCT.IdSp);
            var view = new ThieuxkView()
            {
                SanPham = SP,
                SanPhamChiTiet = _sv.GetById(id),
                AhList = _db.Anhs.Where(c => c.IdSanPhamChiTiet == id).ToList(),
                IdMau = (Guid)SpCT.IdMau,

            };
            return View(view);
        }

        [HttpPost]
        public async Task<ActionResult> AddAnh(Guid IdSP, List<IFormFile> imageFile, Guid IdMau, Guid idSPCT)
        {
            var listAnh = imageFile.ToList();
            foreach (var anh in listAnh)
            {
                if (anh != null && anh.Length > 0) // Không null và không trống
                {
                    //Trỏ tới thư mục wwwroot để lát nữa thực hiện việc Copy sang
                    var path = Path.Combine(
                        Directory.GetCurrentDirectory(), "wwwroot", "image", anh.FileName);
                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        anh.CopyTo(stream);
                    }

                }

                if (anh != null)
                {
                    {
                        foreach (var a in _sanPhamChiTietService.GetAll().Where(c => c.IdSp == IdSP && c.IdMau == IdMau))
                        {
                            _db.Anhs.Add(new Anh()
                            {
                                IdSanPhamChiTiet = a.Id,
                                DuongDanAnh = anh.FileName,
                                Is_delete = true,
                                TrangThai = true,
                                TenAnh = anh.FileName
                            });
                            await _db.SaveChangesAsync();
                        }
                    }
                }
            }


            return RedirectToAction("Details", new { id = idSPCT });
        }
        // GET: PhanLoaiController/Create
        public ActionResult Create()
        {
            var viewModel = new SanPhamChiTietView()
            {


                MauItems = _mauService.GetAll().Select(s => new SelectListItem
                {
                    Value = s.Id.ToString(),
                    Text = s.TenMau
                }).ToList(),

                SpItems = _spService.GetAll().Select(s => new SelectListItem
                {
                    Value = s.Id.ToString(),
                    Text = s.TenSanPham
                }).ToList(),
                SizeItems = _sizeService.GetAll().Select(s => new SelectListItem
                {
                    Value = s.Id.ToString(),
                    Text = s.TenSize
                }).ToList(),

            };
            return View(viewModel);
        }

        // POST: PhanLoaiController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SanPhamChiTiet a)
        {
            var b = new SanPhamChiTiet()
            {
                //MaSp = a.MaSp,
                //IdChatLieu = Guid.Parse(a.IdChatLieu.Value.ToString()),
                //IdNSX = Guid.Parse(a.IdNSX.Value.ToString()),
                //IdMau = Guid.Parse(a.IdMau.Value.ToString()),
                //IdSize = Guid.Parse(a.IdSize.Value.ToString()),
                //IdSp = Guid.Parse(a.IdSp.Value.ToString()),
                //SoLuong = a.SoLuong,
                //MoTa = a.MoTa,
                //TrangThai = a.TrangThai,
                //GiaNhap = a.
                //    GiaNhap,
                //GiaBan = a.GiaBan,
                //GiaNiemYet = a.GiaNiemYet,
                //GhiChu = a.GhiChu,
                //Is_detele = a.Is_detele
            };
            if (_sv.Them(b)) // Nếu thêm thành công
            {

                return RedirectToAction("Index");
            }
            var viewModel = new SanPhamChiTietView()
            {
                MauItems = _mauService.GetAll().Select(s => new SelectListItem
                {
                    Value = s.Id.ToString(),
                    Text = s.TenMau
                }).ToList(),
                SpItems = _spService.GetAll().Select(s => new SelectListItem
                {
                    Value = s.Id.ToString(),
                    Text = s.TenSanPham
                }).ToList(),
                SizeItems = _sizeService.GetAll().Select(s => new SelectListItem
                {
                    Value = s.Id.ToString(),
                    Text = s.TenSize
                }).ToList(),

            };

            return View(viewModel);
        }

        // GET: PhanLoaiController/Edit/5
        public ActionResult Edit(Guid id)
        {
            var viewModel = new SanPhamChiTietView()
            {

                MauItems = _mauService.GetAll().Select(s => new SelectListItem
                {
                    Value = s.Id.ToString(),
                    Text = s.TenMau
                }).ToList(),

                SpItems = _spService.GetAll().Select(s => new SelectListItem
                {
                    Value = s.Id.ToString(),
                    Text = s.TenSanPham
                }).ToList(),
                SizeItems = _sizeService.GetAll().Select(s => new SelectListItem
                {
                    Value = s.Id.ToString(),
                    Text = s.TenSize
                }).ToList(),

                SnaSanPhamChiTiet = _sv.GetById(id)

            };
            return View(viewModel);
        }

        // POST: PhanLoaiController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(SanPhamChiTiet a)
        {
            if (_sv.Sua(a))
            {
                return RedirectToAction("Index");

            }
            return View();
        }



        public ActionResult Delete(Guid id)
        {

            var SP = _sanPhamChiTietService.GetById(id);
            if (SP.Is_detele == true)
            {
                SP.Is_detele = false;
                _sanPhamChiTietService.Sua(SP);
            }
            else
            {
                SP.Is_detele = true;
                _sanPhamChiTietService.Sua(SP);
            }
            return RedirectToAction("Details", "SanPham", new { id = SP.IdSp });
        }
        public ActionResult XoaAnh(string NameAnh, Guid IdSP, Guid IdMau, Guid idSPCT)
        {
            var lisSPCT = _sanPhamChiTietService.GetAll().Where(c => c.IdSp == IdSP && c.IdMau == IdMau);
            foreach (var item in lisSPCT)
            {
                _anhService.XoaBySP(item.Id);

            }

            return RedirectToAction("Details", new { id = idSPCT });

        }
    }
}