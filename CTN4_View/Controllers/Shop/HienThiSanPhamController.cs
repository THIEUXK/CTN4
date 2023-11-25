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
using System.Drawing.Printing;
using CTN4_View.Controllers.Shop.ViewModelThieuxk;
using DocumentFormat.OpenXml.Office2010.Excel;
using CTN4_View_Admin.Controllers.Shop;
using DocumentFormat.OpenXml.Wordprocessing;
using DocumentFormat.OpenXml.Spreadsheet;

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
        public IChiTietSanPhamYeuThichService _chiTietSanPhamYeuThichService;
        public DanhMucJoin _DanhMucjoiin;
        public DB_CTN4_ok _CTN4_Ok;
        public int pageSize = 6;
        public PagingInfo _pagingInfo;
        public ISanPhamService _sanphamService;
        public IKhachHangService _khachHangService;

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
            _sanphamService = new SanPhamService();
            _chiTietSanPhamYeuThichService = new ChiTietSanPhamYeuThichService();
            _khachHangService = new KhachHangService();
            _sanPhamChiTietService = new SanPhamChiTietService();
        }
        public IActionResult HienThiSanPham(int page, int Soluonghienthi)
        {
            var LuuTamCl = SessionBan.ChatLieuSS(HttpContext.Session, "ChatLieuTam");
            var LuuTamMau = SessionBan.MauSacSS(HttpContext.Session, "MauSacTam");
            var LuuTam = SessionBan.DanhMucSS(HttpContext.Session, "DanhMucTam");
            LuuTam.Clear();
            if (Soluonghienthi == 0) { Soluonghienthi = 6; }
            if (page == 0) { page = 1; }
            var danhMuc = _danhMucService.GetAll();
            var danhMucChiTiets = _danhMucChiTiet.GetAll();
            var listSp = _sanPhamCuaHangService.GetAll().Where(c => c.Is_detele == true).ToList();
            var listSp1 = _sanphamService.GetAll().Where(c => c.Is_detele == true).ToList();
            var listSp2 = _sanPhamChiTietService.GetAll().Where(c => c.Is_detele == true).ToList();
            var SpYt = _chiTietSanPhamYeuThichService.GetAll();
            var chatLieus = _chatLieuService.GetAll();
            var mauSacs = _mauSacService.GetAll();
            var khachhang = _khachHangService.GetAll();
            var view = new HienThiSanPhamView()
            {
                danhMucs = danhMuc,
                danhMucChiTiets = danhMucChiTiets,
                sanPhams = listSp1,
                sanPhamChiTiets = listSp2,
                chatLieus = chatLieus,
                maus = mauSacs,
                sanphampaging = listSp.Skip((page - 1) * Soluonghienthi).Take(Soluonghienthi).ToList(),
                pagingInfo = new PagingInfo()
                {
                    TotalItems = listSp.Count(),
                    CurrentPage = page,
                    ItemsPerPage = Soluonghienthi,

                },
                soluonghienthi = Soluonghienthi,
                sanPhamYeuThiches = SpYt,
                khachHangs = khachhang,

            };
            return View(view);
        }
        public IActionResult HienThiSanPham2(int page, int Soluonghienthi)
        {


            var LuuTamCl = SessionBan.ChatLieuSS(HttpContext.Session, "ChatLieuTam");
            var LuuTamMau = SessionBan.MauSacSS(HttpContext.Session, "MauSacTam");
            var b = new List<Guid>();
            foreach (var i in LuuTamMau)
            {
                b.Add(i.Id);
            }
            var a = new List<Guid>();
            foreach (var i in LuuTamCl)
            {
                a.Add(i.Id);
            }
            var idspA = new List<Guid>();
            var GetallSpCt = _sanPhamChiTietService.GetAll().Where(c => b.Contains((Guid)c.IdMau)).ToList();
            foreach (var i in GetallSpCt)
            {
                if (!idspA.Contains((Guid)i.IdSp))
                {
                    idspA.Add((Guid)i.IdSp);
                }

            }
            var searchMau = _sanphamService.GetAll().Where(c => idspA.Contains((Guid)c.Id) && c.Is_detele == true).ToList();
            var searchTenSp = _sanphamService.GetAll().Where(c => a.Contains((Guid)c.IdChatLieu) && c.Is_detele == true).ToList();

            if (searchTenSp.Count != 0 && searchMau.Count == 0)
            {
                if (Soluonghienthi == 0) { Soluonghienthi = 6; }
                if (page == 0) { page = 1; }
                var danhMuc = _danhMucService.GetAll();
                var danhMucChiTiets = _danhMucChiTiet.GetAll();
                var SpYt = _chiTietSanPhamYeuThichService.GetAll();
                var listSp = _sanPhamCuaHangService.GetAll().Where(c => c.Is_detele == true && a.Contains((Guid)c.IdChatLieu)).ToList();
                var listSp1 = _sanphamService.GetAll().Where(c => c.Is_detele == true).ToList();
                var listSp2 = _sanPhamChiTietService.GetAll().Where(c => c.Is_detele == true).ToList();
                var khachhang = _khachHangService.GetAll();
                var chatLieus = _chatLieuService.GetAll();
                var mauSacs = _mauSacService.GetAll();
                var view = new HienThiSanPhamView()
                {
                    danhMucs = danhMuc,
                    danhMucChiTiets = danhMucChiTiets,
                    sanPhams = listSp1,
                    sanPhamChiTiets = listSp2,
                    maus = mauSacs,
                    chatLieus = chatLieus,
                    sanphampaging = listSp.Skip((page - 1) * Soluonghienthi).Take(Soluonghienthi).ToList(),
                    pagingInfo = new PagingInfo()
                    {
                        TotalItems = listSp.Count(),
                        CurrentPage = page,
                        ItemsPerPage = Soluonghienthi,

                    },
                    soluonghienthi = Soluonghienthi,
                    sanPhamYeuThiches = SpYt,
                    khachHangs = khachhang,
                };
                return View("HienThiSanPham", view);
            }
            else if (searchTenSp.Count == 0 && searchMau.Count != 0)
            {
                if (Soluonghienthi == 0) { Soluonghienthi = 6; }
                if (page == 0) { page = 1; }
                var danhMuc = _danhMucService.GetAll();
                var danhMucChiTiets = _danhMucChiTiet.GetAll();
                var SpYt = _chiTietSanPhamYeuThichService.GetAll();
                var listSp = _sanPhamCuaHangService.GetAll().Where(c => c.Is_detele == true && idspA.Contains((Guid)c.Id)).ToList();
                var listSp1 = _sanphamService.GetAll().Where(c => c.Is_detele == true).ToList();
                var listSp2 = _sanPhamChiTietService.GetAll().Where(c => c.Is_detele == true).ToList();
                var khachhang = _khachHangService.GetAll();
                var chatLieus = _chatLieuService.GetAll();
                var mauSacs = _mauSacService.GetAll();
                var view = new HienThiSanPhamView()
                {
                    danhMucs = danhMuc,
                    danhMucChiTiets = danhMucChiTiets,
                    sanPhams = listSp1,
                    sanPhamChiTiets = listSp2,
                    maus = mauSacs,
                    chatLieus = chatLieus,
                    sanphampaging = listSp.Skip((page - 1) * Soluonghienthi).Take(Soluonghienthi).ToList(),
                    pagingInfo = new PagingInfo()
                    {
                        TotalItems = listSp.Count(),
                        CurrentPage = page,
                        ItemsPerPage = Soluonghienthi,

                    },
                    soluonghienthi = Soluonghienthi,
                    sanPhamYeuThiches = SpYt,
                    khachHangs = khachhang,
                };
                return View("HienThiSanPham", view);
            }
            else if (searchTenSp.Count != 0 && searchMau.Count != 0)
            {
                if (Soluonghienthi == 0) { Soluonghienthi = 6; }
                if (page == 0) { page = 1; }
                var danhMuc = _danhMucService.GetAll();
                var danhMucChiTiets = _danhMucChiTiet.GetAll();
                var SpYt = _chiTietSanPhamYeuThichService.GetAll();
                var listSp = _sanPhamCuaHangService.GetAll().Where(c => c.Is_detele == true && a.Contains((Guid)c.IdChatLieu) && idspA.Contains((Guid)c.Id)).ToList();
                if (listSp.Count == 0)
                {
                    var thongbaoSearch = "Không tìm thất sản phẩm nào ";
                    TempData["Notification"] = thongbaoSearch;
                    return RedirectToAction("viewSpRong", new { thongbaoSearch });
                }
                var listSp1 = _sanphamService.GetAll().Where(c => c.Is_detele == true).ToList();
                var listSp2 = _sanPhamChiTietService.GetAll().Where(c => c.Is_detele == true).ToList();
                var khachhang = _khachHangService.GetAll();
                var chatLieus = _chatLieuService.GetAll();
                var mauSacs = _mauSacService.GetAll();
                var view = new HienThiSanPhamView()
                {
                    danhMucs = danhMuc,
                    danhMucChiTiets = danhMucChiTiets,
                    sanPhams = listSp1,
                    sanPhamChiTiets = listSp2,
                    maus = mauSacs,
                    chatLieus = chatLieus,
                    sanphampaging = listSp.Skip((page - 1) * Soluonghienthi).Take(Soluonghienthi).ToList(),
                    pagingInfo = new PagingInfo()
                    {
                        TotalItems = listSp.Count(),
                        CurrentPage = page,
                        ItemsPerPage = Soluonghienthi,

                    },
                    soluonghienthi = Soluonghienthi,
                    sanPhamYeuThiches = SpYt,
                    khachHangs = khachhang,
                };
                return View("HienThiSanPham", view);
            }
            else
            {

                return RedirectToAction("HienThiSanPham");
            }
        }
        public IActionResult HienThiSanPhamChiTiet(Guid id)
        {
            var listsp1 = _sanPhamCuaHangService.GetAllSpcts(id).Where(c => c.Is_detele == true).ToList();
            var anh = _anhService.GetAll().Where(c => c.SanPhamChiTiet.SanPham.Id == id).ToList();
            var giamgia = _giamGiaService.GetAll().Where(c => c.TrangThai == true && c.Is_detele == true && c.NgayBatDau <= DateTime.Now && c.NgayKetThuc >= DateTime.Now).ToList();
            var listsp = _sanPhamCuaHangService.GetAll();
            var mau = _mauSacService.GetAll().ToList();
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
        [HttpGet]
        public IActionResult Search(int page, int Soluonghienthi, string TenSp)
        {
            if (TenSp == null)
            {
                return RedirectToAction("HienThiSanPham");
            }
            var searchTenSp = _sanphamService.GetAll().Where(c => c.TenSanPham.ToLower().Contains(TenSp.ToLower())).ToList();

            if (searchTenSp.Count != 0)
            {
                if (Soluonghienthi == 0) { Soluonghienthi = 6; }
                if (page == 0) { page = 1; }
                var danhMuc = _danhMucService.GetAll();
                var danhMucChiTiets = _danhMucChiTiet.GetAll();
                var SpYt = _chiTietSanPhamYeuThichService.GetAll();
                var listSp = _sanPhamCuaHangService.GetAll().Where(c => c.Is_detele == true && c.TenSanPham.ToLower().Contains(TenSp.ToLower())).ToList();
                var listSp1 = _sanphamService.GetAll().Where(c => c.Is_detele == true).ToList();
                var listSp2 = _sanPhamChiTietService.GetAll().Where(c => c.Is_detele == true).ToList();
                var khachhang = _khachHangService.GetAll();
                var chatLieus = _chatLieuService.GetAll();
                var mauSacs = _mauSacService.GetAll();
                var view = new HienThiSanPhamView()
                {
                    danhMucs = danhMuc,
                    danhMucChiTiets = danhMucChiTiets,
                    sanPhams = listSp1,
                    sanPhamChiTiets = listSp2,
                    maus = mauSacs,
                    chatLieus = chatLieus,
                    //sanPhamChiTiets = listSpct,
                    sanphampaging = listSp.Skip((page - 1) * Soluonghienthi).Take(Soluonghienthi).ToList(),
                    pagingInfo = new PagingInfo()
                    {
                        TotalItems = listSp.Count(),
                        CurrentPage = page,
                        ItemsPerPage = Soluonghienthi,

                    },
                    soluonghienthi = Soluonghienthi,
                    sanPhamYeuThiches = SpYt,
                    khachHangs = khachhang,
                };
                return View("HienThiSanPham", view);
            }
            else
            {

                var thongbaoSearch = "Không tìm thất sản phẩm nào ";
                TempData["Notification"] = thongbaoSearch;
                return RedirectToAction("viewSpRong", new { thongbaoSearch });
            }


        }
        public IActionResult viewSpRong(int page, int Soluonghienthi)
        {

           var LuuTamCl = SessionBan.ChatLieuSS(HttpContext.Session, "ChatLieuTam");
            var LuuTamMau = SessionBan.MauSacSS(HttpContext.Session, "MauSacTam");
            var LuuTam = SessionBan.DanhMucSS(HttpContext.Session, "DanhMucTam");
            LuuTam.Clear();
            if (Soluonghienthi == 0) { Soluonghienthi = 6; }
            if (page == 0) { page = 1; }
            var danhMuc = _danhMucService.GetAll();
            var danhMucChiTiets = _danhMucChiTiet.GetAll();
            var listSp = _sanPhamCuaHangService.GetAll().Where(c => c.Is_detele == true).ToList();
            var listSp1 = _sanphamService.GetAll().Where(c => c.Is_detele == true).ToList();
            var listSp2 = _sanPhamChiTietService.GetAll().Where(c => c.Is_detele == true).ToList();
            var SpYt = _chiTietSanPhamYeuThichService.GetAll();
            var chatLieus = _chatLieuService.GetAll();
            var mauSacs = _mauSacService.GetAll();
            var khachhang = _khachHangService.GetAll();
            var view = new HienThiSanPhamView()
            {
                danhMucs = danhMuc,
                danhMucChiTiets = danhMucChiTiets,
                sanPhams = listSp1,
                sanPhamChiTiets = listSp2,
                chatLieus = chatLieus,
                maus = mauSacs,
                sanphampaging = listSp.Skip((page - 1) * Soluonghienthi).Take(Soluonghienthi).ToList(),
                pagingInfo = new PagingInfo()
                {
                    TotalItems = listSp.Count(),
                    CurrentPage = page,
                    ItemsPerPage = Soluonghienthi,

                },
                soluonghienthi = Soluonghienthi,
                sanPhamYeuThiches = SpYt,
                khachHangs = khachhang,

            };
            return View(view);
        }
        public IActionResult ChonShowSp(int Soluonghienthi, int page)
        {
            if (Soluonghienthi == 0) { Soluonghienthi = 1; }
            if (page == 0) { page = 1; }
            var danhMuc = _danhMucService.GetAll();
            var danhMucChiTiets = _danhMucChiTiet.GetAll();
            var SpYt = _chiTietSanPhamYeuThichService.GetAll().ToList();
            var listSp = _sanPhamCuaHangService.GetAll().Where(c => c.Is_detele == true).ToList();
            var listSp1 = _sanphamService.GetAll().Where(c => c.Is_detele == true).ToList();
            var listSp2 = _sanPhamChiTietService.GetAll().Where(c => c.Is_detele == true).ToList();
            var chatLieus = _chatLieuService.GetAll();
            var mauSacs = _mauSacService.GetAll();
            var khachhang = _khachHangService.GetAll();
            var view = new HienThiSanPhamView()
            {
                danhMucs = danhMuc,
                danhMucChiTiets = danhMucChiTiets,
                sanPhams = listSp1,
                sanPhamChiTiets = listSp2,
                chatLieus = chatLieus,
                maus = mauSacs,
                sanphampaging = listSp.Skip((page - 1) * Soluonghienthi).Take(Soluonghienthi).ToList(),
                pagingInfo = new PagingInfo()
                {
                    TotalItems = listSp.Count(),
                    CurrentPage = page,
                    ItemsPerPage = Soluonghienthi,

                },
                soluonghienthi = Soluonghienthi,
                sanPhamYeuThiches = SpYt,
                khachHangs = khachhang,

            };
            return View("HienThiSanPham", view);


        }
        // ajax chat lieu
        [HttpPost("/XxemSanPham/layIDchatlieu")]
        public JsonResult LayChatLieu(Guid chatLieuId)
        {
            var danhMucLuu = _chatLieuService.GetById(chatLieuId);
            var LuuTam = SessionBan.ChatLieuSS(HttpContext.Session, "ChatLieuTam");

            if (LuuTam.FirstOrDefault(c => c.Id == chatLieuId) == null)
            {
                LuuTam.Add(danhMucLuu);
                SessionBan.SetObjToJson(HttpContext.Session, "ChatLieuTam", LuuTam);
            }
            return Json(new System.Text.Json.JsonSerializerOptions());
        }
        [HttpPost("/XxemSanPham/boIDchatlieu")]
        public JsonResult BoChatLieu(Guid chatLieuId)
        {
            var danhMucLuu = _chatLieuService.GetById(chatLieuId);
            var LuuTam = SessionBan.ChatLieuSS(HttpContext.Session, "ChatLieuTam");
            if (LuuTam.FirstOrDefault(c => c.Id == chatLieuId) != null)
            {
                for (int i = 0; i < LuuTam.Count; i++)
                {
                    if (LuuTam.FirstOrDefault(c => c.Id == chatLieuId) != null)
                    {
                        LuuTam.RemoveAt(i);
                    }
                }
                SessionBan.SetObjToJson(HttpContext.Session, "ChatLieuTam", LuuTam);
            }
            return Json(new System.Text.Json.JsonSerializerOptions());
        }

        // ajax mau sac
        [HttpPost("/XxemSanPham/layIDmausac")]
        public JsonResult LayMauSac(Guid MauSacId)
        {
            var MauSacLuu = _mauSacService.GetById(MauSacId);
            var LuuTam = SessionBan.MauSacSS(HttpContext.Session, "MauSacTam");

            if (LuuTam.FirstOrDefault(c => c.Id == MauSacId) == null)
            {
                LuuTam.Add(MauSacLuu);
                SessionBan.SetObjToJson(HttpContext.Session, "MauSacTam", LuuTam);
            }
            return Json(new System.Text.Json.JsonSerializerOptions());
        }
        [HttpPost("/XxemSanPham/boIDmausac")]
        public JsonResult BoMauSac(Guid MauSacId)
        {
            var MauSacLuu = _mauSacService.GetById(MauSacId);
            var LuuTam = SessionBan.MauSacSS(HttpContext.Session, "MauSacTam");
            if (LuuTam.FirstOrDefault(c => c.Id == MauSacId) != null)
            {
                for (int i = 0; i < LuuTam.Count; i++)
                {
                    if (LuuTam.FirstOrDefault(c => c.Id == MauSacId) != null)
                    {
                        LuuTam.RemoveAt(i);
                    }
                }
                SessionBan.SetObjToJson(HttpContext.Session, "MauSacTam", LuuTam);
            }
            return Json(new System.Text.Json.JsonSerializerOptions());
        }



    }
}
