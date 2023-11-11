using CTN4_Serv.Service.IService;
using CTN4_Serv.Service;
using CTN4_Serv.ServiceJoin;
using CTN4_Serv.ViewModel;
using Microsoft.AspNetCore.Mvc;
using CTN4_Data.Models.DB_CTN4;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore;
using X.PagedList;
using X.PagedList.Mvc.Core;
using CTN4_Data.DB_Context;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CTN4_View.Controllers.Shop
{
    public class HienThiSanPhamController : Controller
    {

        private readonly SanPhamCuaHangService _sanPhamCuaHangService;
        public IGioHangService _GioHang;
        public IGioHangChiTietService _GioHangChiTiet;
        public GioHangjoiin _GioHangjoiin;
        public IDanhMucService _danhMucService;
        public IDanhMucChiTietService _danhMucChiTiet;
        public IMauService _mauSacService;
        public IChatLieuService _chatLieuService;
        public ISizeService _sizeService;
        public ISanPhamChiTietService _sanPhamChiTietService;
        public IAnhService _anhService;
        public IGiamGiaService _giamGiaService;
        public DanhMucJoin _DanhMucjoiin;
        public DB_CTN4_ok _CTN4_Ok;
        public int pageSize = 6;
        public PagingInfo _pagingInfo;

        public HienThiSanPhamController()
        {
            _sanPhamCuaHangService = new SanPhamCuaHangService();
            _GioHang = new GioHangService();
            _GioHangChiTiet = new GioHangChiTietService();
            _GioHangjoiin = new GioHangjoiin();
            _danhMucService = new DanhMucMucService();
            _danhMucChiTiet = new DanhMucChiTietMucChiTietService();
            _mauSacService = new MauService();
            _sizeService = new SizeService();
            _chatLieuService = new ChatLieuService();
            _anhService = new AnhService();
            _giamGiaService = new GiamGiaService();
            _pagingInfo = new PagingInfo();
            _CTN4_Ok = new DB_CTN4_ok();
        }
        public IActionResult HienThiSanPham(int page, string TenSp)
        {

            if (page == null) { page = 1; }
            var danhMuc = _danhMucService.GetAll();
            var danhMucChiTiets = _danhMucChiTiet.GetAll();
            var listSp = _sanPhamCuaHangService.GetAll().Where(c => c.Is_detele == true).ToList();
            //var mauSacs = _mauSacService.GetAll();
            var chatLieus = _chatLieuService.GetAll();
            //var listSpct = _sanPhamChiTietService.GetAll();

            //var Paging = _CTN4_Ok.SanPhamChiTiets.Include(c => c.ChatLieu).Include(c => c.NSX).Include(c => c.Mau).Include(c => c.Size).Include(c => c.SanPham).Skip((page - 1) * pageSize).Take(pageSize).ToList();

            var view = new HienThiSanPhamView()
            {
                danhMucs = danhMuc,
                danhMucChiTiets = danhMucChiTiets,
                sanPhams = listSp,
                // maus = mauSacs,
                chatLieus = chatLieus,
                //sanPhamChiTiets = listSpct,
                sanphampaging = listSp.Skip((page - 1) * pageSize).Take(pageSize).ToList(),
                pagingInfo = new PagingInfo()
                {
                    TotalItems = listSp.Count(),
                    CurrentPage = page,
                    ItemsPerPage = 6,

                }

            };
            //if (!string.IsNullOrEmpty(TenSp))
            //{
            //    listSp = _sanPhamChiTietService.GetAll().Where(c => c.SanPham.TenSanPham.Contains(TenSp)).ToList();
            //}
            return View(view);
        }
        public IActionResult HienThiSanPhamChiTiet(Guid id)
        {
            var listsp1 = _sanPhamCuaHangService.GetAllSpcts(id).Where(c => c.Is_detele == true).ToList();
            var anh = _anhService.GetAll().Where(c => c.SanPhamChiTiet.SanPham.Id == id).ToList();
            var giamgia = _giamGiaService.GetAll().Where(c => c.TrangThai == true && c.Is_detele == true && c.NgayBatDau <= DateTime.Now && c.NgayKetThuc >= DateTime.Now).ToList();
            var listsp = _sanPhamCuaHangService.GetAll();
            var mau = _mauSacService.GetAll().ToList();
            //var size = _sizeService.GetAll().Distinct().ToList();
            //var spctcuthe = _sanPhamChiTietService.GetAll().Where(c=>c.IdSp== id).ToList();
            var spctcuthe = _CTN4_Ok.SanPhamChiTiets.Include(c => c.Size).ToList().Where(c => c.IdSp == id && c.Is_detele == true);
            var view = new SanPhamBan()
            {
                sanPham = _sanPhamCuaHangService.GetById(id),
                Anh = _sanPhamCuaHangService.GeAnhs(id),
                sanPhamChiTiets = listsp1,
                maus = mau,
                sizect = spctcuthe.ToList(),
                anhs = anh,
                sanPhams = listsp,
                giamgias = giamgia
            };
            return View(view);

        }

        public IActionResult chonMau(Guid IdSanPham, Guid IdMau)
        {
            var listsp1 = _sanPhamCuaHangService.GetAllSpcts(IdSanPham).Where(c => c.Is_detele == true).ToList();
            var anh = _anhService.GetAll().Where(c => c.SanPhamChiTiet.SanPham.Id == IdSanPham).ToList();

            var listsp = _sanPhamCuaHangService.GetAll();
            var mau = _mauSacService.GetAll().Distinct().ToList();
            var size = _sizeService.GetAll().Distinct().ToList();
            var spctcuthe = _CTN4_Ok.SanPhamChiTiets.Include(c => c.Size).Where(c => c.IdMau == IdMau && c.IdSp == IdSanPham && c.Is_detele == true).ToList();
            var mauluu = _mauSacService.GetAll().FirstOrDefault(c => c.Id == IdMau);
            var giamgia = _giamGiaService.GetAll().Where(c => c.TrangThai == true && c.Is_detele == true && c.NgayBatDau <= DateTime.Now && c.NgayKetThuc >= DateTime.Now).ToList();
            // Đọc dữ liệu từ Session xem trong Cart nó có cái gì chưa?

            var view = new SanPhamBan()
            {
                sanPham = _sanPhamCuaHangService.GetById(IdSanPham),
                sanPhamChiTiets = listsp1,
                maus = mau,
                sizect = spctcuthe.ToList(),
                anhs = anh.Where(c => c.SanPhamChiTiet.IdMau == IdMau && c.SanPhamChiTiet.IdSp == IdSanPham).ToList(),
                sanPhams = listsp,
                idmau = IdMau,
                giamgias = giamgia
            };
            return View("HienThiSanPhamChiTiet", view);
        }
        public IActionResult chonSize(Guid IdSanPham, Guid idSize, Guid IdMau)
        {
            if (IdMau == Guid.Parse("00000000-0000-0000-0000-000000000000"))
            {
                var message = "Chọn màu sắc trước !";
                TempData["ErrorMessage"] = message;
                return RedirectToAction("HienThiSanPhamChiTiet", new { id = IdSanPham, message });
            }

            var kichCo = _sizeService.GetById(idSize);

            var listsp1 = _sanPhamCuaHangService.GetAllSpcts(IdSanPham).Where(c => c.Is_detele == true).ToList();
            var anh = _anhService.GetAll().Where(c => c.SanPhamChiTiet.SanPham.Id == IdSanPham).ToList();
            var listsp = _sanPhamCuaHangService.GetAll();
            var mau = _mauSacService.GetAll().Distinct().ToList();
            var size = _CTN4_Ok.SanPhamChiTiets.Include(c => c.Size).Where(c => c.IdMau == IdMau && c.IdSp == IdSanPham).ToList();
            var spcuthe = _CTN4_Ok.SanPhamChiTiets.FirstOrDefault(c => c.IdMau == IdMau && c.IdSp == IdSanPham && c.IdSize == idSize && c.Is_detele == true);
            var giamgia = _giamGiaService.GetAll().Where(c => c.TrangThai == true && c.Is_detele == true && c.NgayBatDau <= DateTime.Now && c.NgayKetThuc >= DateTime.Now).ToList();
            var view = new SanPhamBan()
            {
                sanPham = _sanPhamCuaHangService.GetById(IdSanPham),
                sanPhamChiTiets = listsp1,
                maus = mau,
                sizect = size.ToList(),
                anhs = anh.Where(c => c.SanPhamChiTiet.IdMau == IdMau && c.SanPhamChiTiet.IdSp == IdSanPham).ToList(),
                sanPhams = listsp,
                idmau = IdMau,
                idsize = idSize,
                soluong = spcuthe.SoLuong,
                KichCo = kichCo.TenSize,
                giamgias = giamgia

            };
            return View("HienThiSanPhamChiTiet", view);
        }
        public IActionResult ThongTinVocher(Guid idVoucher, Guid idSp)
        {

            var giamgiact = _giamGiaService.GetById(idVoucher);
            if (giamgiact.LoaiGiamGia == true)
            {

                var message = $"Nhập Mã {giamgiact.MaGiam} còn ( {giamgiact.SoLuong} lượt). \n" +
               $"Giảm {giamgiact.SoTienGiam}đ cho đơn hàng từ {giamgiact.DieuKienGiam}đ";

                TempData["Notification"] = message;
                return RedirectToAction("HienThiSanPhamChiTiet", new { id = idSp, message });
            }
            else
            {
                var message = $"Nhập Mã {giamgiact.MaGiam} còn ( {giamgiact.SoLuong} lượt). \n" +
              $"Giảm {giamgiact.PhanTramGiam}đ cho đơn hàng từ {giamgiact.DieuKienGiam}đ";

                TempData["Notification"] = message;
                return RedirectToAction("HienThiSanPhamChiTiet", new { id = idSp, message });
            }

        }
        [HttpPost]
        public string CheckBoxChatLieu(/*[FromBody] FilterData filter*/)
        {
            //var fillterSanPham = _CTN4_Ok.SanPhamChiTiets.ToList();
            //if (filter.Idchatlieu != null && filter.Idchatlieu.Count > 0)
            //{
            //    fillterSanPham = fillterSanPham.Where(c => filter.Idchatlieu.Contains(c.ChatLieu.Id)).ToList();
            //}
            //if (filter.IdMauSacs != null && filter.IdMauSacs.Count > 0)
            //{
            //    fillterSanPham = fillterSanPham.Where(c => filter.IdMauSacs.Contains(c.Mau.Id)).ToList();
            //}
            //return PartialView("_SanPhamLocCl", fillterSanPham);
            return "oke la";

        }

        [HttpGet]
        public IActionResult Search(int page, string TenSp)
        {
            var searchTenSp = _sanPhamChiTietService.GetAll();
            if (!string.IsNullOrEmpty(TenSp))
            {

                if (page == null) { page = 1; }
                var danhMuc = _danhMucService.GetAll();
                var danhMucChiTiets = _danhMucChiTiet.GetAll();
                var listSp = _sanPhamCuaHangService.GetAll().Where(c => c.Is_detele == true && c.TenSanPham.Contains(TenSp)).ToList();
                //var mauSacs = _mauSacService.GetAll();
                var chatLieus = _chatLieuService.GetAll();
                //var listSpct = _sanPhamChiTietService.GetAll();

                //var Paging = _CTN4_Ok.SanPhamChiTiets.Include(c => c.ChatLieu).Include(c => c.NSX).Include(c => c.Mau).Include(c => c.Size).Include(c => c.SanPham).Skip((page - 1) * pageSize).Take(pageSize).ToList();

                var view = new HienThiSanPhamView()
                {
                    danhMucs = danhMuc,
                    danhMucChiTiets = danhMucChiTiets,
                    sanPhams = listSp,
                    // maus = mauSacs,
                    chatLieus = chatLieus,
                    //sanPhamChiTiets = listSpct,
                    sanphampaging = listSp.Skip((page - 1) * pageSize).Take(pageSize).ToList(),
                    pagingInfo = new PagingInfo()
                    {
                        TotalItems = listSp.Count(),
                        CurrentPage = page,
                        ItemsPerPage = 6,

                    }
                };
                return View("HienThiSanPham", view);
            }
            else
            {
                var thongbaoSearch = "Không tìm thất sản phẩm nào ";
                TempData["Notification"] = thongbaoSearch;
                return RedirectToAction("HienThiSanPham", new { thongbaoSearch });
            }
            return RedirectToAction("HienThiSanPham");
        }
    }
}
