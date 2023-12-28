using CTN4_Data.DB_Context;
using CTN4_Data.Models.DB_CTN4;
using CTN4_Serv.Service;
using CTN4_Serv.Service.IService;
using CTN4_Serv.ServiceJoin;
using CTN4_Serv.ViewModel;
using CTN4_View.Areas.Admin.Controllers.QuanLyAdd;
using DocumentFormat.OpenXml.EMMA;
using DocumentFormat.OpenXml.Office2010.Excel;
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
            var sanPhamList = _sv.GetAll();
            return View(sanPhamList);
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
            const int kichThuocToiDa = 2 * 1024 * 1024; // 2MB
            const int soAnhToiDa = 5;
            var listAnh = imageFile.ToList();
            if (listAnh.Count > soAnhToiDa)
            {
                var thongbaoAnh = $"Chỉ được phép tải lên tối đa {soAnhToiDa} ảnh";
                TempData["Notification"] = thongbaoAnh;
                return RedirectToAction("Details", new { id = idSPCT });
            }
            foreach (var anh in listAnh)
            {

                if (anh != null && anh.Length > 0) // Không null và không trống
                {
                    // Kiểm tra kích thước của tập tin có trong giới hạn không
                    if (anh.Length > kichThuocToiDa)
                    {
                        var thongbaoAnh = "Kích thước ảnh vượt quá 2MB";
                        TempData["Notification"] = thongbaoAnh;
                        return RedirectToAction("Details", new { id = idSPCT });
                    }
                    // Kiểm tra định dạng của ảnh
                    var allowedExtensions = new[] { ".jpg", ".png", ".jpeg", ".tiff", ".webp", ".gif" };
                    var extension = System.IO.Path.GetExtension(anh.FileName).ToLower();
                    if (!allowedExtensions.Contains(extension))
                    {
                        var thongbaoAnh = "Định dạng ảnh không hợp lệ";
                        TempData["Notification"] = thongbaoAnh;
                        return RedirectToAction("Details", new { id = idSPCT });
                    }
                    // Kiểm tra số lượng ảnh đã lưu trong cơ sở dữ liệu
                    var soLuongAnhDaLuu = _db.Anhs.Count(a => a.IdSanPhamChiTiet == idSPCT );
                    if (soLuongAnhDaLuu >= soAnhToiDa)
                    {
                        var thongbaoAnh = $"Số lượng ảnh đã đạt đến giới hạn là {soAnhToiDa}";
                        TempData["Notification"] = thongbaoAnh;
                        return RedirectToAction("Details", new { id = idSPCT });
                    }
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
                SnaSanPhamChiTiet = _sv.GetById(id),
                 IdMau = _sv.GetById(id).IdMau,
                IdSize = _sv.GetById(id).IdSize,
                IdSp = _sv.GetById(id).IdSp,
                Is_detele = _sv.GetById(id).Is_detele,
                TrangThai = _sv.GetById(id).TrangThai,
                SoLuong = _sv.GetById(id).SoLuong,

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
                return RedirectToAction("Details","SanPham",  new { id = a.IdSp });

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

        public ActionResult ThemSanPhamChiTiet(Guid id)
        {


            var viewModel = new SanPhamChiTietView()
            {
                MauItems = _mauService.GetAll().Select(s => new SelectListItem
                {
                    Value = s.Id.ToString(),
                    Text = s.TenMau
                }).ToList(),

                SizeItems = _sizeService.GetAll().Select(s => new SelectListItem
                {
                    Value = s.Id.ToString(),
                    Text = s.TenSize
                }).ToList(),
                IdSp = id,



            };
            return View(viewModel);
        }


        public ActionResult ThemSanPham(SanPhamChiTietView a)
        {


            var check = _sanPhamChiTietService.GetAll().FirstOrDefault(c => c.IdSp == a.IdSp && c.IdMau == a.IdMau && c.IdSize == a.IdSize && c.TrangThai == true && c.Is_detele == true);

            if (check != null)
            {
                var message = "Sản phẩm đã tồn tại !";
                TempData["ErrorMessage"] = message;
                return RedirectToAction("ThemSanPhamChiTiet", new { id = a.IdSp, message });
            }
            var sanPhamChiTiet = new SanPhamChiTiet()
            {
                IdMau = a.IdMau,
                IdSize = a.IdSize,
                IdSp = a.IdSp,
                Is_detele = true,
                TrangThai = true,
                SoLuong = a.SoLuong,

            };
            if (_sanPhamChiTietService.Them(sanPhamChiTiet) == false)
            {
                var message = "Thêm thất bại !";
                TempData["ErrorMessage"] = message;
                return RedirectToAction("ThemSanPhamChiTiet", new { id = a.IdSp, message });
            }
            var message1 = "Thêm thêm thành công !";
            TempData["sussces"] = message1;
            return RedirectToAction("ThemSanPhamChiTiet", new { id = a.IdSp, message1 });
        }
        //public ActionResult BoSpDanhMuc(Guid idsp, Guid iddm)
        //{

        //    var a = _danhMucChiTietService.GetAll().FirstOrDefault(c => c.IdSanPham == idsp && c.IdDanhMuc == iddm);
        //    _danhMucChiTietService.Xoa(a.Id);
        //    return RedirectToAction("Details", "DanhMuc", new { id = iddm });
        //}
    }
}