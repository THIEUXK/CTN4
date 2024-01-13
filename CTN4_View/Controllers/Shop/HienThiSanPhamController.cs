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
using System.Linq;
using Org.BouncyCastle.Crypto;
using CTN4_Data.Models;
using Microsoft.CodeAnalysis.CSharp.Syntax;

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
        public IKhuyenMaiSanPhamService _kmspService;
        public IHoaDonChiTietService _hoaDonChiTietService;
        public IHoaDonService _hoaDonService;
        public IDanhGiaSanPhamService _danhGiaSanPhamService;

        public HienThiSanPhamController(IGioHangService giohang)

        //public IKhuyenMaiSanPhamService _kmspService;
        //public HienThiSanPhamController()

        {
            _sanPhamCuaHangService = new SanPhamCuaHangService();
            _GioHang = giohang;
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
            _kmspService = new KhuyenMaiSanPhamService();
            _hoaDonChiTietService = new HoaDonChiTietService();
            _hoaDonService = new HoaDonService();
            _danhGiaSanPhamService = new DanhGiaSanPhamService();
        }

        public IActionResult HienThiSanPham(int page, int Soluonghienthi, string load, string sortOrder = "")
        {
            if (load == "a")
            {
                var luuGiaBatDau1 = SessionBan.Sobatdau(HttpContext.Session, "minPrice");
                var luuGiaKetThuc1 = SessionBan.Sobatdau(HttpContext.Session, "maxPrice");
                var LuuTamCl1 = SessionBan.ChatLieuSS(HttpContext.Session, "ChatLieuTam");
                var LuuTamMau1 = SessionBan.MauSacSS(HttpContext.Session, "MauSacTam");
                var LuuTam1 = SessionBan.DanhMucSS(HttpContext.Session, "DanhMucTam");
                var showSp1 = SessionBan.SanPhamMoRong(HttpContext.Session, "ChonShowSp");
                luuGiaBatDau1 = 0;
                luuGiaKetThuc1 = 0;
                LuuTamCl1.Clear();
                LuuTamMau1.Clear();
                LuuTam1.Clear();
                showSp1 = 0;
                SessionBan.SetObjToJson(HttpContext.Session, "minPrice", luuGiaBatDau1);
                SessionBan.SetObjToJson(HttpContext.Session, "maxPrice", luuGiaKetThuc1);
                SessionBan.SetObjToJson(HttpContext.Session, "ChatLieuTam", LuuTamCl1);
                SessionBan.SetObjToJson(HttpContext.Session, "MauSacTam", LuuTamMau1);
                SessionBan.SetObjToJson(HttpContext.Session, "DanhMucTam", LuuTam1);
                SessionBan.SetObjToJson(HttpContext.Session, "ChonShowSp", showSp1);
                if (Soluonghienthi == 0) { Soluonghienthi = 9; }
                if (page == 0) { page = 1; }
                var danhMuc = _danhMucService.GetAll().Where(c=> c.Is_detele== true).ToList();
                var danhMucChiTiets = _danhMucChiTiet.GetAll();
                var listSp = _sanPhamCuaHangService.GetAll().Where(c => c.Is_detele == true).ToList();
                var listSp1 = _sanphamService.GetAll().Where(c => c.Is_detele == true).ToList();
                var listSp2 = _sanPhamChiTietService.GetAll().Where(c => c.Is_detele == true).ToList();
                var SpYt = _chiTietSanPhamYeuThichService.GetAll();
                var chatLieus = _chatLieuService.GetAll().Where(c=>c.TrangThai == true && c.Is_detele== true).ToList();
                var mauSacs = _mauSacService.GetAll().Where(c=>c.TrangThai == true && c.Is_detele== true).ToList();
                var khachhang = _khachHangService.GetAll();
                var khuyenMaiSp = _kmspService.GetAll().Where(c => c.KhuyenMai.TrangThai == true && c.KhuyenMai.Is_Detele == true && c.KhuyenMai.NgayBatDau <= DateTime.Now && c.KhuyenMai.NgayKetThuc >= DateTime.Now).ToList();

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
                    khuyenMaiSanPhams = khuyenMaiSp,
                    SortOrder = sortOrder

                };
                return View(view);
            }

            var luuGiaBatDau = SessionBan.Sobatdau(HttpContext.Session, "minPrice");
            var luuGiaKetThuc = SessionBan.Sobatdau(HttpContext.Session, "maxPrice");
            var LuuTamCl = SessionBan.ChatLieuSS(HttpContext.Session, "ChatLieuTam");
            var LuuTamMau = SessionBan.MauSacSS(HttpContext.Session, "MauSacTam");
            var LuuTam = SessionBan.DanhMucSS(HttpContext.Session, "DanhMucTam");
            var showSp = SessionBan.SanPhamMoRong(HttpContext.Session, "ChonShowSp");

            if (showSp != 0)
            {
                Soluonghienthi = showSp;
            }
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
            var searchGiaTien = _sanphamService.GetAll()
            .Where(c => c.GiaNiemYet >= luuGiaBatDau && c.GiaNiemYet <= luuGiaKetThuc && c.Is_detele == true).ToList();
            // Chỉ tìm chất liệu
            if (searchTenSp.Count != 0 && searchMau.Count == 0)
            {
                if (Soluonghienthi == 0) { Soluonghienthi = 9; }
                if (page == 0) { page = 1; }
               var danhMuc = _danhMucService.GetAll().Where(c=> c.Is_detele== true).ToList();
                var danhMucChiTiets = _danhMucChiTiet.GetAll();
                var SpYt = _chiTietSanPhamYeuThichService.GetAll();
                List<SanPham> listSp;
                if (luuGiaKetThuc != 0 && luuGiaBatDau < luuGiaKetThuc)
                {
                    listSp = _sanPhamCuaHangService.GetAll().Where(c => c.Is_detele == true && a.Contains((Guid)c.IdChatLieu) && c.GiaNiemYet >= luuGiaBatDau && c.GiaNiemYet <= luuGiaKetThuc).ToList();
                }
                else
                {
                    listSp = _sanPhamCuaHangService.GetAll().Where(c => c.Is_detele == true && a.Contains((Guid)c.IdChatLieu)).ToList();
                }
                if (listSp.Count == 0)
                {
                    var thongbaoSearch = "Không tìm thất sản phẩm nào ";
                    TempData["Notification"] = thongbaoSearch;
                    return RedirectToAction("viewSpRong", new { thongbaoSearch });
                }
                var listSp1 = _sanphamService.GetAll().Where(c => c.Is_detele == true).ToList();
                var listSp2 = _sanPhamChiTietService.GetAll().Where(c => c.Is_detele == true).ToList();
                var khachhang = _khachHangService.GetAll();
                var khuyenMaiSp = _kmspService.GetAll().Where(c => c.KhuyenMai.TrangThai == true && c.KhuyenMai.Is_Detele == true && c.KhuyenMai.NgayBatDau <= DateTime.Now && c.KhuyenMai.NgayKetThuc >= DateTime.Now).ToList();
               var chatLieus = _chatLieuService.GetAll().Where(c=>c.TrangThai == true && c.Is_detele== true).ToList();
                 var mauSacs = _mauSacService.GetAll().Where(c=>c.TrangThai == true && c.Is_detele== true).ToList();
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
                    khuyenMaiSanPhams = khuyenMaiSp,
                    SortOrder = sortOrder
                };
                return View(view);
            }
            ///// chỉ tìm màu
            else if (searchTenSp.Count == 0 && searchMau.Count != 0)
            {
                if (Soluonghienthi == 0) { Soluonghienthi = 9; }
                if (page == 0) { page = 1; }
               var danhMuc = _danhMucService.GetAll().Where(c=> c.Is_detele== true).ToList();
                var danhMucChiTiets = _danhMucChiTiet.GetAll();
                var SpYt = _chiTietSanPhamYeuThichService.GetAll();
                List<SanPham> listSp;
                if (luuGiaKetThuc != 0 && luuGiaBatDau < luuGiaKetThuc)
                {
                    listSp = _sanPhamCuaHangService.GetAll().Where(c => c.Is_detele == true && idspA.Contains((Guid)c.Id) && c.GiaNiemYet >= luuGiaBatDau && c.GiaNiemYet <= luuGiaKetThuc).ToList();
                }
                else
                {
                    listSp = _sanPhamCuaHangService.GetAll().Where(c => c.Is_detele == true && idspA.Contains((Guid)c.Id)).ToList();
                }
                if (listSp.Count == 0)
                {
                    var thongbaoSearch = "Không tìm thất sản phẩm nào ";
                    TempData["Notification"] = thongbaoSearch;
                    return RedirectToAction("viewSpRong", new { thongbaoSearch });
                }
                var listSp1 = _sanphamService.GetAll().Where(c => c.Is_detele == true).ToList();
                var listSp2 = _sanPhamChiTietService.GetAll().Where(c => c.Is_detele == true).ToList();
                var khachhang = _khachHangService.GetAll();
                var khuyenMaiSp = _kmspService.GetAll().Where(c => c.KhuyenMai.TrangThai == true && c.KhuyenMai.Is_Detele == true && c.KhuyenMai.NgayBatDau <= DateTime.Now && c.KhuyenMai.NgayKetThuc >= DateTime.Now).ToList();
               var chatLieus = _chatLieuService.GetAll().Where(c=>c.TrangThai == true && c.Is_detele== true).ToList();
                 var mauSacs = _mauSacService.GetAll().Where(c=>c.TrangThai == true && c.Is_detele== true).ToList();
                switch (sortOrder)
                {
                    case "Thấp xuống Cao":
                        listSp = listSp.OrderBy(s => s.GiaNiemYet).ToList();
                        break;
                    case "Cao xuống Thấp":
                        listSp = listSp.OrderByDescending(s => s.GiaNiemYet).ToList();
                        break;
                    default:
                        break;
                }
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
                    khuyenMaiSanPhams = khuyenMaiSp,
                    SortOrder = sortOrder
                };
                return View(view);
            }
            ///// chỉ tìm chất liệu và màu sắc
            else if (searchTenSp.Count != 0 && searchMau.Count != 0 && searchGiaTien.Count == 0)
            {
                if (Soluonghienthi == 0) { Soluonghienthi = 9; }
                if (page == 0) { page = 1; }
               var danhMuc = _danhMucService.GetAll().Where(c=> c.Is_detele== true).ToList();
                var danhMucChiTiets = _danhMucChiTiet.GetAll();
                var SpYt = _chiTietSanPhamYeuThichService.GetAll();
                List<SanPham> listSp;
                if (luuGiaKetThuc != 0 && luuGiaBatDau < luuGiaKetThuc)
                {
                    listSp = _sanPhamCuaHangService.GetAll().Where(c => c.Is_detele == true && idspA.Contains((Guid)c.Id) && c.GiaNiemYet >= luuGiaBatDau && c.GiaNiemYet <= luuGiaKetThuc && a.Contains((Guid)c.IdChatLieu)).ToList();
                }
                else
                {
                    listSp = _sanPhamCuaHangService.GetAll().Where(c => c.Is_detele == true && idspA.Contains((Guid)c.Id) && a.Contains((Guid)c.IdChatLieu)).ToList();
                }
                if (listSp.Count == 0)
                {
                    var thongbaoSearch = "Không tìm thất sản phẩm nào ";
                    TempData["Notification"] = thongbaoSearch;
                    return RedirectToAction("viewSpRong", new { thongbaoSearch });
                }
                var listSp1 = _sanphamService.GetAll().Where(c => c.Is_detele == true).ToList();
                var listSp2 = _sanPhamChiTietService.GetAll().Where(c => c.Is_detele == true).ToList();
                var khachhang = _khachHangService.GetAll();
                var khuyenMaiSp = _kmspService.GetAll().Where(c => c.KhuyenMai.TrangThai == true && c.KhuyenMai.Is_Detele == true && c.KhuyenMai.NgayBatDau <= DateTime.Now && c.KhuyenMai.NgayKetThuc >= DateTime.Now).ToList();
               var chatLieus = _chatLieuService.GetAll().Where(c=>c.TrangThai == true && c.Is_detele== true).ToList();
                 var mauSacs = _mauSacService.GetAll().Where(c=>c.TrangThai == true && c.Is_detele== true).ToList();
                switch (sortOrder)
                {
                    case "Thấp xuống Cao":
                        listSp = listSp.OrderBy(s => s.GiaNiemYet).ToList();
                        break;
                    case "Cao xuống Thấp":
                        listSp = listSp.OrderByDescending(s => s.GiaNiemYet).ToList();
                        break;
                    default:
                        break;
                }
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
                    khuyenMaiSanPhams = khuyenMaiSp,
                    SortOrder = sortOrder
                };
                return View(view);
            }
            // Chỉ tìm giá tiền
            else if (searchTenSp.Count == 0 && searchMau.Count == 0)
            {
                if (Soluonghienthi == 0) { Soluonghienthi = 9; }
                if (page == 0) { page = 1; }
               var danhMuc = _danhMucService.GetAll().Where(c=> c.Is_detele== true).ToList();
                var danhMucChiTiets = _danhMucChiTiet.GetAll();
                var SpYt = _chiTietSanPhamYeuThichService.GetAll();
                List<SanPham> listSp;
                if (luuGiaKetThuc != 0 && luuGiaBatDau < luuGiaKetThuc)
                {
                    listSp = _sanPhamCuaHangService.GetAll().Where(c => c.Is_detele == true && c.GiaNiemYet >= luuGiaBatDau && c.GiaNiemYet <= luuGiaKetThuc).ToList();
                }
                else
                {
                    listSp = _sanPhamCuaHangService.GetAll().Where(c => c.Is_detele).ToList();
                }
                if (listSp.Count == 0)
                {
                    var thongbaoSearch = "Không tìm thất sản phẩm nào ";
                    TempData["Notification"] = thongbaoSearch;
                    return RedirectToAction("viewSpRong", new { thongbaoSearch });
                }
                //var listSp = _sanPhamCuaHangService.GetAll().Where(c => c.Is_detele == true && (minPrice == null || c.GiaNiemYet >= minPrice) && (maxPrice == null || c.GiaNiemYet <= maxPrice)).ToList();
                var listSp1 = _sanphamService.GetAll().Where(c => c.Is_detele == true).ToList();
                var listSp2 = _sanPhamChiTietService.GetAll().Where(c => c.Is_detele == true).ToList();
                var khachhang = _khachHangService.GetAll();
                var khuyenMaiSp = _kmspService.GetAll().Where(c => c.KhuyenMai.TrangThai == true && c.KhuyenMai.Is_Detele == true && c.KhuyenMai.NgayBatDau <= DateTime.Now && c.KhuyenMai.NgayKetThuc >= DateTime.Now).ToList();
               var chatLieus = _chatLieuService.GetAll().Where(c=>c.TrangThai == true && c.Is_detele== true).ToList();
                 var mauSacs = _mauSacService.GetAll().Where(c=>c.TrangThai == true && c.Is_detele== true).ToList();
                switch (sortOrder)
                {
                    case "Thấp xuống Cao":
                        listSp = listSp.OrderBy(s => s.GiaNiemYet).ToList();
                        break;
                    case "Cao xuống Thấp":
                        listSp = listSp.OrderByDescending(s => s.GiaNiemYet).ToList();
                        break;
                    default:
                        break;
                }
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
                    khuyenMaiSanPhams = khuyenMaiSp,
                    SortOrder = sortOrder
                };
                return View(view);
            }
            /// tìm cả 3 cùng một lúc 
            else if (searchTenSp.Count != 0 && searchMau.Count != 0 && searchGiaTien.Count != 0)
            {
                if (Soluonghienthi == 0) { Soluonghienthi = 9; }
                if (page == 0) { page = 1; }
               var danhMuc = _danhMucService.GetAll().Where(c=> c.Is_detele== true).ToList();
                var danhMucChiTiets = _danhMucChiTiet.GetAll();
                var SpYt = _chiTietSanPhamYeuThichService.GetAll();
                List<SanPham> listSp;
                if (luuGiaKetThuc != 0 && luuGiaBatDau < luuGiaKetThuc)
                {
                    listSp = _sanPhamCuaHangService.GetAll().Where(c => c.Is_detele == true && a.Contains((Guid)c.IdChatLieu) && idspA.Contains((Guid)c.Id) && c.GiaNiemYet >= luuGiaBatDau && c.GiaNiemYet <= luuGiaKetThuc).ToList();
                }
                else
                {
                    listSp = _sanPhamCuaHangService.GetAll().Where(c => c.Is_detele == true && a.Contains((Guid)c.IdChatLieu) && idspA.Contains((Guid)c.Id)).ToList();
                }
                if (listSp.Count == 0)
                {
                    var thongbaoSearch = "Không tìm thất sản phẩm nào ";
                    TempData["Notification"] = thongbaoSearch;
                    return RedirectToAction("viewSpRong", new { thongbaoSearch });
                }
                var listSp1 = _sanphamService.GetAll().Where(c => c.Is_detele == true).ToList();
                var listSp2 = _sanPhamChiTietService.GetAll().Where(c => c.Is_detele == true).ToList();
                var khachhang = _khachHangService.GetAll();
                var khuyenMaiSp = _kmspService.GetAll().Where(c => c.KhuyenMai.TrangThai == true && c.KhuyenMai.Is_Detele == true && c.KhuyenMai.NgayBatDau <= DateTime.Now && c.KhuyenMai.NgayKetThuc >= DateTime.Now).ToList();
               var chatLieus = _chatLieuService.GetAll().Where(c=>c.TrangThai == true && c.Is_detele== true).ToList();
                 var mauSacs = _mauSacService.GetAll().Where(c=>c.TrangThai == true && c.Is_detele== true).ToList();
                switch (sortOrder)
                {
                    case "Thấp xuống Cao":
                        listSp = listSp.OrderBy(s => s.GiaNiemYet).ToList();
                        break;
                    case "Cao xuống Thấp":
                        listSp = listSp.OrderByDescending(s => s.GiaNiemYet).ToList();
                        break;
                    default:
                        break;
                }
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
                    khuyenMaiSanPhams = khuyenMaiSp,
                    SortOrder = sortOrder
                };
                return View(view);
            }
            else if (searchTenSp.Count == 0 && searchMau.Count == 0 && searchGiaTien.Count == 0 && luuGiaBatDau != 0 && luuGiaKetThuc != 0)
            {
                if (Soluonghienthi == 0) { Soluonghienthi = 9; }
                if (page == 0) { page = 1; }
               var danhMuc = _danhMucService.GetAll().Where(c=> c.Is_detele== true).ToList();
                var danhMucChiTiets = _danhMucChiTiet.GetAll();
                var SpYt = _chiTietSanPhamYeuThichService.GetAll();
                List<SanPham> listSp;
                if (luuGiaKetThuc != 0 && luuGiaBatDau < luuGiaKetThuc)
                {
                    listSp = _sanPhamCuaHangService.GetAll().Where(c => c.Is_detele == true && c.GiaNiemYet >= luuGiaBatDau && c.GiaNiemYet <= luuGiaKetThuc).ToList();
                }
                else
                {
                    listSp = _sanPhamCuaHangService.GetAll().Where(c => c.Is_detele == true).ToList();
                }
                if (listSp.Count == 0)
                {
                    var thongbaoSearch = "Không tìm thất sản phẩm nào ";
                    TempData["Notification"] = thongbaoSearch;
                    return RedirectToAction("viewSpRong", new { thongbaoSearch });
                }
                var listSp1 = _sanphamService.GetAll().Where(c => c.Is_detele == true).ToList();
                var listSp2 = _sanPhamChiTietService.GetAll().Where(c => c.Is_detele == true).ToList();
                var khachhang = _khachHangService.GetAll();
                var khuyenMaiSp = _kmspService.GetAll().Where(c => c.KhuyenMai.TrangThai == true && c.KhuyenMai.Is_Detele == true && c.KhuyenMai.NgayBatDau <= DateTime.Now && c.KhuyenMai.NgayKetThuc >= DateTime.Now).ToList();
               var chatLieus = _chatLieuService.GetAll().Where(c=>c.TrangThai == true && c.Is_detele== true).ToList();
                 var mauSacs = _mauSacService.GetAll().Where(c=>c.TrangThai == true && c.Is_detele== true).ToList();
                switch (sortOrder)
                {
                    case "Thấp xuống Cao":
                        listSp = listSp.OrderBy(s => s.GiaNiemYet).ToList();
                        break;
                    case "Cao xuống Thấp":
                        listSp = listSp.OrderByDescending(s => s.GiaNiemYet).ToList();
                        break;
                    default:
                        break;
                }
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
                    khuyenMaiSanPhams = khuyenMaiSp,
                    SortOrder = sortOrder
                };
                return View(view);
            }
            else
            {
                //var thongbaoSearch = "Không tìm thất sản phẩm nào ";
                //  TempData["Notification"] = thongbaoSearch;
                //   return RedirectToAction("viewSpRong", new { thongbaoSearch });
                //var LuuTamCl = SessionBan.ChatLieuSS(HttpContext.Session, "ChatLieuTam");
                //var LuuTamMau = SessionBan.MauSacSS(HttpContext.Session, "MauSacTam");
                //var LuuTam = SessionBan.DanhMucSS(HttpContext.Session, "DanhMucTam");
                //LuuTam.Clear();
                if (Soluonghienthi == 0) { Soluonghienthi = 9; }
                if (page == 0) { page = 1; }
               var danhMuc = _danhMucService.GetAll().Where(c=> c.Is_detele== true).ToList();
                var danhMucChiTiets = _danhMucChiTiet.GetAll();
                var listSp = _sanPhamCuaHangService.GetAll().Where(c => c.Is_detele == true).ToList();
                var listSp1 = _sanphamService.GetAll().Where(c => c.Is_detele == true).ToList();
                var listSp2 = _sanPhamChiTietService.GetAll().Where(c => c.Is_detele == true).ToList();
                var SpYt = _chiTietSanPhamYeuThichService.GetAll();
               var chatLieus = _chatLieuService.GetAll().Where(c=>c.TrangThai == true && c.Is_detele== true).ToList();
                 var mauSacs = _mauSacService.GetAll().Where(c=>c.TrangThai == true && c.Is_detele== true).ToList();
                var khachhang = _khachHangService.GetAll();
                var khuyenMaiSp = _kmspService.GetAll().Where(c => c.KhuyenMai.TrangThai == true && c.KhuyenMai.Is_Detele == true && c.KhuyenMai.NgayBatDau <= DateTime.Now && c.KhuyenMai.NgayKetThuc >= DateTime.Now).ToList();

                switch (sortOrder)
                {
                    case "Thấp xuống Cao":
                        listSp = listSp.OrderBy(s => s.GiaNiemYet).ToList();
                        break;
                    case "Cao xuống Thấp":
                        listSp = listSp.OrderByDescending(s => s.GiaNiemYet).ToList();
                        break;
                    default:
                        break;
                }
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
                    khuyenMaiSanPhams = khuyenMaiSp,
                    SortOrder = sortOrder

                };
                return View(view);

            }


        }
        public IActionResult HienThiSanPhamChiTiet(Guid id)
        {
            var idsp = new List<Guid>();
            var accnew = SessionServices.KhachHangSS(HttpContext.Session, "ACC");
            if (accnew.Count != 0)
            {
                var idhoadon = new List<int>();
                var hoadon1 = _hoaDonService.GetAll().Where(c => c.IdKhachHang == accnew[0].Id && c.NgayNhan != null).ToList();
                foreach (var item in hoadon1)
                {
                    idhoadon.Add(item.Id);
                }

                var hdct = _hoaDonChiTietService.GetAll().Where(c => idhoadon.Contains(c.IdHoaDon) && c.TrangThai == true && c.Is_detele == true).ToList();

                foreach (var item in hdct)
                {
                    if (!idsp.Contains((Guid)item.SanPhamChiTiet.IdSp))
                    {
                        idsp.Add((Guid)item.SanPhamChiTiet.IdSp);
                    }

                }

            }
            var listsp1 = _sanPhamCuaHangService.GetAllSpcts(id).Where(c => c.Is_detele == true).ToList();
            var anh = _anhService.GetAll().Where(c => c.SanPhamChiTiet.SanPham.Id == id).ToList();
            var giamgia = _giamGiaService.GetAll().Where(c => c.TrangThai == true && c.Is_detele == true && c.NgayBatDau <= DateTime.Now && c.NgayKetThuc >= DateTime.Now).ToList();
            var listsp = _sanPhamCuaHangService.GetAll();
            var mau = _mauSacService.GetAll().ToList();
            var spctcuthe = _CTN4_Ok.SanPhamChiTiets.Include(c => c.Size).ToList().Where(c => c.IdSp == id && c.Is_detele == true);
            var SpYt = _chiTietSanPhamYeuThichService.GetAll();
            var splienquan = _danhMucChiTiet.GetAll().Where(c => c.IdSanPham == id && c.DanhMuc.Is_detele == true);
            var a = new List<Guid>();
            foreach (var i in splienquan)
            {
                a.Add((Guid)i.IdDanhMuc);
            }
            var listDanhMucLq = _danhMucChiTiet.GetAll().Where(c => a.Contains((Guid)c.IdDanhMuc) && c.DanhMuc.Is_detele == true).ToList();
            var b = new List<Guid>();
            foreach (var i in listDanhMucLq)
            {
                b.Add((Guid)i.IdSanPham);
            }

            var c = _danhGiaSanPhamService.GetAll().FirstOrDefault(c => c.IdSanPham == id);
            if (accnew.Count() != 0)
            {
                c = _danhGiaSanPhamService.GetAll().FirstOrDefault(c => c.IdSanPham == id && c.IdKhachHang == accnew[0].Id);
            }
            else
            {
                c = _danhGiaSanPhamService.GetAll().FirstOrDefault(c => c.IdSanPham == id);
            }
            var danhgiasanpham = _danhGiaSanPhamService.GetAll().Where(c => c.Is_delete == true && c.TrangThaiAnHien == true && c.TrangThaiDuyet == true).ToList();
            var danhgia1sanpham = _danhGiaSanPhamService.GetAll().Where(c => c.Is_delete == true && c.TrangThaiAnHien == true && c.TrangThaiDuyet == true && c.IdSanPham == id).ToList();
            var listSanPhamLq = _sanphamService.GetAll().Where(c => b.Contains((Guid)c.Id) && c.Is_detele == true).ToList();


            float trungBinhDanhGia = 0;
            int dem = 0;

            // Kiểm tra trường hợp danh sách đánh giá không có phần tử
            if (danhgia1sanpham.Count() == 0)
            {
                trungBinhDanhGia = 0;
            }
            else
            {
                foreach (var x in danhgia1sanpham)
                {
                    trungBinhDanhGia += x.SoSao;
                    dem++;
                }
                trungBinhDanhGia /= dem;
                string formattedOutput = trungBinhDanhGia.ToString("F1");
            }

            // Tiếp tục xử lý với giá trị trungBinhDanhGia đã tính được

            //trungBinhDanhGia = (decimal)Math.Round((double)trungBinhDanhGia, 1);


            var view = new SanPhamBan()
            {
                sanPham = _sanPhamCuaHangService.GetById(id),
                Anh = _sanPhamCuaHangService.GeAnhs(id),
                sanPhamChiTiets = listsp1,
                maus = mau,
                sizect = spctcuthe.ToList(),
                anhs = anh,
                sanPhams = listSanPhamLq,
                giamgias = giamgia,
                sanPhamYeuThiches = SpYt,
                idsanphamdamuas = idsp,
                danhGiaSanPhams = danhgiasanpham,
                danhGiaSanPhamCuaToi = c,
                trungBinhDanhGia = (float)Math.Round(trungBinhDanhGia, 1),


            };
            return View(view);

        }
        public IActionResult XacNhanDanhGia(Guid idsp, string message)
        {
            var accnew = SessionServices.KhachHangSS(HttpContext.Session, "ACC");
            var LuuTam = SessionBan.DanhGia(HttpContext.Session, "DanhGiaTam");
            // Kiểm tra xem người dùng đã đánh giá sản phẩm này chưa

            var existingReview = _danhGiaSanPhamService.GetDanhGiaByIdSanPhamAndIdKhachHang(idsp, accnew[0].Id);

            if (existingReview != null)
            {
                // Kiểm tra xem còn số lượt sửa hay không
                if (existingReview.SoSua <= 0)
                {
                    var message1 = "Bạn đã sửa đánh giá đủ lần!";
                    TempData["message1"] = message1;
                    return RedirectToAction("HienThiSanPhamChiTiet", new { id = idsp, message1 });
                }
                
                // Cập nhật đánh giá hiện tại
                existingReview.BinhLuan = message;
                existingReview.SoSao = LuuTam;
                existingReview.ThoiGian = DateTime.Now;
                existingReview.SoSua -= 1; // Giảm số lượt sửa
                existingReview.TrangThaiDuyet = false;  //existingReview.TrangThai = false;
                existingReview.Is_delete = true;

                _danhGiaSanPhamService.Sua(existingReview); // Bạn nên triển khai một phương thức để cập nhật đánh giá trong dịch vụ của bạn

                var message2 = "Đánh giá của bạn đã được cập nhật!";
                TempData["message2"] = message2;

                return RedirectToAction("HienThiSanPhamChiTiet", new { id = idsp, message2 });
            }
            if (LuuTam == 0)
            {
                var message1 = "Hãy chọn số sao đánh giá của bạn!";
                TempData["message1"] = message1;
                return RedirectToAction("HienThiSanPhamChiTiet", new { id = idsp, message1 });
            }

            var Danhgianew = new DanhGiaSanPham()
            {
                Id = Guid.NewGuid(),
                IdSanPham = idsp,
                IdKhachHang = accnew[0].Id,
                BinhLuan = message,
                SoSao = LuuTam,
                Is_delete = true,
                TrangThaiAnHien = true,
                TrangThaiDuyet = false,
                ThoiGian = DateTime.Now,
                SoSua = 1
            };
            _danhGiaSanPhamService.Them(Danhgianew);
            if (_danhGiaSanPhamService.Them(Danhgianew) != null)
            {
                var message1 = "Đánh giá của bạn đã được ghi nhận!";
                TempData["message2"] = message1;
                return RedirectToAction("HienThiSanPhamChiTiet", new { id = idsp, message1 });
            }
            return RedirectToAction("HienThiSanPhamChiTiet", new { id = idsp });
        }
        public IActionResult XoaDanhGia(Guid idsp)
        {
            var accnew = SessionServices.KhachHangSS(HttpContext.Session, "ACC");
            var LuuTam = SessionBan.DanhGia(HttpContext.Session, "DanhGiaTam");
            // Kiểm tra xem người dùng đã đánh giá sản phẩm này chưa

            var existingReview = _danhGiaSanPhamService.GetDanhGiaByIdSanPhamAndIdKhachHang(idsp, accnew[0].Id);

            if (existingReview != null)
            {


                if( existingReview.TrangThaiAnHien == true && existingReview.TrangThaiDuyet == true)
                {
                       existingReview.TrangThaiAnHien = false;


                _danhGiaSanPhamService.Sua(existingReview); // Bạn nên triển khai một phương thức để cập nhật đánh giá trong dịch vụ của bạn



                return RedirectToAction("HienThiSanPhamChiTiet", new { id = idsp });
                }
                else
                {
                      existingReview.TrangThaiAnHien = true;


                _danhGiaSanPhamService.Sua(existingReview); // Bạn nên triển khai một phương thức để cập nhật đánh giá trong dịch vụ của bạn



                return RedirectToAction("HienThiSanPhamChiTiet", new { id = idsp });
                }
             
                
            }
            return RedirectToAction("HienThiSanPhamChiTiet", new { id = idsp });
        }
        public IActionResult chonMau(Guid IdSanPham, Guid IdMau)
        {
            var listsp1 = _sanPhamCuaHangService.GetAllSpcts(IdSanPham).Where(c => c.Is_detele == true).ToList();
            var anh = _anhService.GetAll().Where(c => c.SanPhamChiTiet.SanPham.Id == IdSanPham).ToList();
            var danhgiasanpham = _danhGiaSanPhamService.GetAll().Where(c => c.Is_delete == true && c.TrangThaiAnHien == true && c.TrangThaiDuyet == true).ToList();
             var splienquan = _danhMucChiTiet.GetAll().Where(c => c.IdSanPham == IdSanPham && c.DanhMuc.Is_detele == true);
            var a = new List<Guid>();
            foreach (var i in splienquan)
            {
                a.Add((Guid)i.IdDanhMuc);
            }
            var listDanhMucLq = _danhMucChiTiet.GetAll().Where(c => a.Contains((Guid)c.IdDanhMuc) && c.DanhMuc.Is_detele == true).ToList();
            var b = new List<Guid>();
            foreach (var i in listDanhMucLq)
            {
                b.Add((Guid)i.IdSanPham);
            }
            var listsp = _sanphamService.GetAll().Where(c => b.Contains((Guid)c.Id) && c.Is_detele == true).ToList();
            
            var mau = _mauSacService.GetAll().Distinct().ToList();
            var size = _sizeService.GetAll().Distinct().ToList();
            var spctcuthe = _CTN4_Ok.SanPhamChiTiets.Include(c => c.Size).Where(c => c.IdMau == IdMau && c.IdSp == IdSanPham && c.Is_detele == true).ToList();
            var mauluu = _mauSacService.GetAll().FirstOrDefault(c => c.Id == IdMau);
            var giamgia = _giamGiaService.GetAll().Where(c => c.TrangThai == true && c.Is_detele == true && c.NgayBatDau <= DateTime.Now && c.NgayKetThuc >= DateTime.Now).ToList();
            var SpYt = _chiTietSanPhamYeuThichService.GetAll();
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
                giamgias = giamgia,
                sanPhamYeuThiches = SpYt,
                danhGiaSanPhams = danhgiasanpham,
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
            var danhgiasanpham = _danhGiaSanPhamService.GetAll().Where(c => c.Is_delete == true && c.TrangThaiAnHien == true && c.TrangThaiDuyet == true).ToList();
            var listsp1 = _sanPhamCuaHangService.GetAllSpcts(IdSanPham).Where(c => c.Is_detele == true).ToList();
            var anh = _anhService.GetAll().Where(c => c.SanPhamChiTiet.SanPham.Id == IdSanPham).ToList();
             var splienquan = _danhMucChiTiet.GetAll().Where(c => c.IdSanPham == IdSanPham && c.DanhMuc.Is_detele == true);
            var a = new List<Guid>();
            foreach (var i in splienquan)
            {
                a.Add((Guid)i.IdDanhMuc);
            }
            var listDanhMucLq = _danhMucChiTiet.GetAll().Where(c => a.Contains((Guid)c.IdDanhMuc) && c.DanhMuc.Is_detele == true).ToList();
            var b = new List<Guid>();
            foreach (var i in listDanhMucLq)
            {
                b.Add((Guid)i.IdSanPham);
            }
            var listsp = _sanphamService.GetAll().Where(c => b.Contains((Guid)c.Id) && c.Is_detele == true).ToList();
            var mau = _mauSacService.GetAll().Distinct().ToList();
            var size = _CTN4_Ok.SanPhamChiTiets.Include(c => c.Size).Where(c => c.IdMau == IdMau && c.IdSp == IdSanPham).ToList();
            var spcuthe = _CTN4_Ok.SanPhamChiTiets.FirstOrDefault(c => c.IdMau == IdMau && c.IdSp == IdSanPham && c.IdSize == idSize && c.Is_detele == true);
            var giamgia = _giamGiaService.GetAll().Where(c => c.TrangThai == true && c.Is_detele == true && c.NgayBatDau <= DateTime.Now && c.NgayKetThuc >= DateTime.Now).ToList();
            var SpYt = _chiTietSanPhamYeuThichService.GetAll();
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
                giamgias = giamgia,
                sanPhamYeuThiches = SpYt,
                danhGiaSanPhams = danhgiasanpham,

            };
            return View("HienThiSanPhamChiTiet", view);
        }
        public IActionResult ThongTinVocher(Guid idVoucher, Guid idSp)
        {

            var giamgiact = _giamGiaService.GetById(idVoucher);
            if (giamgiact.LoaiGiamGia == false)
            {

                var message = $"Nhập Mã {giamgiact.MaGiam} còn ( {giamgiact.SoLuong} lượt). \n" +
               $"Giảm {giamgiact.SoTienGiam.ToString("N0")}VND cho đơn hàng từ {giamgiact.DieuKienGiam.ToString("N0")}VND";

                TempData["Notification"] = message;
                return RedirectToAction("HienThiSanPhamChiTiet", new { id = idSp, message });
            }
            else
            {
                var message = $"Nhập Mã {giamgiact.MaGiam} còn ( {giamgiact.SoLuong} lượt). \n" +
              $"Giảm {giamgiact.PhanTramGiam}% cho đơn hàng từ {giamgiact.DieuKienGiam.ToString("N0")}VND";

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
                if (Soluonghienthi == 0) { Soluonghienthi = 9; }
                if (page == 0) { page = 1; }
               var danhMuc = _danhMucService.GetAll().Where(c=> c.Is_detele== true).ToList();
                var danhMucChiTiets = _danhMucChiTiet.GetAll();
                var SpYt = _chiTietSanPhamYeuThichService.GetAll();
                var listSp = _sanPhamCuaHangService.GetAll().Where(c => c.Is_detele == true && c.TenSanPham.ToLower().Contains(TenSp.ToLower())).ToList();
                var listSp1 = _sanphamService.GetAll().Where(c => c.Is_detele == true).ToList();
                var listSp2 = _sanPhamChiTietService.GetAll().Where(c => c.Is_detele == true).ToList();
                var khachhang = _khachHangService.GetAll();
                var khuyenMaiSp = _kmspService.GetAll().Where(c => c.KhuyenMai.TrangThai == true && c.KhuyenMai.Is_Detele == true && c.KhuyenMai.NgayBatDau <= DateTime.Now && c.KhuyenMai.NgayKetThuc >= DateTime.Now).ToList();
               var chatLieus = _chatLieuService.GetAll().Where(c=>c.TrangThai == true && c.Is_detele== true).ToList();
                 var mauSacs = _mauSacService.GetAll().Where(c=>c.TrangThai == true && c.Is_detele== true).ToList();
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
                    khuyenMaiSanPhams = khuyenMaiSp,
                };
                return View("HienThiSanPham", view);
            }
            else
            {

                var thongbaoSearch = "Không tìm thấy sản phẩm nào ";
                TempData["Notification"] = thongbaoSearch;
                return RedirectToAction("viewSpRong", new { thongbaoSearch });
            }


        }
        public IActionResult viewSpRong(int page, int Soluonghienthi)
        {


            if (Soluonghienthi == 0) { Soluonghienthi = 9; }
            if (page == 0) { page = 1; }
           var danhMuc = _danhMucService.GetAll().Where(c=> c.Is_detele== true).ToList();
            var danhMucChiTiets = _danhMucChiTiet.GetAll();
            var listSp = _sanPhamCuaHangService.GetAll().Where(c => c.Is_detele == true).ToList();
            var listSp1 = _sanphamService.GetAll().Where(c => c.Is_detele == true).ToList();
            var listSp2 = _sanPhamChiTietService.GetAll().Where(c => c.Is_detele == true).ToList();
            var SpYt = _chiTietSanPhamYeuThichService.GetAll();
           var chatLieus = _chatLieuService.GetAll().Where(c=>c.TrangThai == true && c.Is_detele== true).ToList();
             var mauSacs = _mauSacService.GetAll().Where(c=>c.TrangThai == true && c.Is_detele== true).ToList();
            var khachhang = _khachHangService.GetAll();
            var khuyenMaiSp = _kmspService.GetAll().Where(c => c.KhuyenMai.TrangThai == true && c.KhuyenMai.Is_Detele == true && c.KhuyenMai.NgayBatDau <= DateTime.Now && c.KhuyenMai.NgayKetThuc >= DateTime.Now).ToList();
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
                khuyenMaiSanPhams = khuyenMaiSp,

            };
            return View(view);
        }
        public IActionResult ChonShowSp(int Soluonghienthi, int page)
        {
            var luuChonShow = SessionBan.SanPhamMoRong(HttpContext.Session, "ChonShowSp");
            luuChonShow = Soluonghienthi;
            SessionBan.SetObjToJson(HttpContext.Session, "ChonShowSp", luuChonShow);
            if (Soluonghienthi == 0) { Soluonghienthi = 1; }
            if (page == 0) { page = 1; }
           var danhMuc = _danhMucService.GetAll().Where(c=> c.Is_detele== true).ToList();
            var danhMucChiTiets = _danhMucChiTiet.GetAll();
            var SpYt = _chiTietSanPhamYeuThichService.GetAll().ToList();
            var listSp = _sanPhamCuaHangService.GetAll().Where(c => c.Is_detele == true).ToList();
            var listSp1 = _sanphamService.GetAll().Where(c => c.Is_detele == true).ToList();
            var listSp2 = _sanPhamChiTietService.GetAll().Where(c => c.Is_detele == true).ToList();
           var chatLieus = _chatLieuService.GetAll().Where(c=>c.TrangThai == true && c.Is_detele== true).ToList();
             var mauSacs = _mauSacService.GetAll().Where(c=>c.TrangThai == true && c.Is_detele== true).ToList();
            var khachhang = _khachHangService.GetAll();
            var khuyenMaiSp = _kmspService.GetAll().Where(c => c.KhuyenMai.TrangThai == true && c.KhuyenMai.Is_Detele == true && c.KhuyenMai.NgayBatDau <= DateTime.Now && c.KhuyenMai.NgayKetThuc >= DateTime.Now).ToList();
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
                khuyenMaiSanPhams = khuyenMaiSp,

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
        //// ajax loc gia tien
        [HttpPost("/XxemSanPham/layGiaLoc")]
        public JsonResult LocGiaTien(float minPrice, float maxPrice)
        {
            if (minPrice > maxPrice)
            {
                return Json("that bai 1", new System.Text.Json.JsonSerializerOptions());
            }
            var locGia = _sanphamService.GetAll();
            var filteredProducts = locGia.Where(p => p.GiaNiemYet >= minPrice && p.GiaNiemYet <= maxPrice).ToList();
            var luuGiaBatDau = SessionBan.Sobatdau(HttpContext.Session, "minPrice");
            var luuGiaKetThuc = SessionBan.Sobatdau(HttpContext.Session, "maxPrice");
            luuGiaBatDau = minPrice;
            luuGiaKetThuc = maxPrice;
            if (luuGiaBatDau != null)
            {
                luuGiaBatDau = minPrice;
            }
            if (luuGiaKetThuc != null)
            {
                luuGiaKetThuc = maxPrice;
            }
            SessionBan.SetObjToJson(HttpContext.Session, "minPrice", luuGiaBatDau);
            SessionBan.SetObjToJson(HttpContext.Session, "maxPrice", luuGiaKetThuc);
            return Json("ok", new System.Text.Json.JsonSerializerOptions());
        }
        [HttpPost("/XxemSanPham/XoaSsGiaTien")]
        public JsonResult XoaSsGiaTien()
        {
            var luuGiaBatDau = SessionBan.Sobatdau(HttpContext.Session, "minPrice");
            var luuGiaKetThuc = SessionBan.Sobatdau(HttpContext.Session, "maxPrice");
            luuGiaBatDau = null;
            luuGiaKetThuc = null;
            SessionBan.SetObjToJson(HttpContext.Session, "minPrice", luuGiaBatDau);
            SessionBan.SetObjToJson(HttpContext.Session, "maxPrice", luuGiaKetThuc);
            return Json("ok", new System.Text.Json.JsonSerializerOptions());
        }

        // ajax đánh giá
        [HttpPost("/XxemSanPham/luuDanhGia")]
        public JsonResult LayDanhGia(int rating)
        {

            var LuuTam = SessionBan.DanhGia(HttpContext.Session, "DanhGiaTam");

            if (LuuTam == null)
            {
                LuuTam = rating;
                SessionBan.SetObjToJson(HttpContext.Session, "DanhGiaTam", LuuTam);
            }
            else
            {
                LuuTam = rating;
                SessionBan.SetObjToJson(HttpContext.Session, "DanhGiaTam", LuuTam);
            }

            return Json(new System.Text.Json.JsonSerializerOptions());
        }
    }
}
