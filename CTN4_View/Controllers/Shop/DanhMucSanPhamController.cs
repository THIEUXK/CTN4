using CTN4_Data.DB_Context;
using CTN4_Data.Models.DB_CTN4;
using CTN4_Serv.Service;
using CTN4_Serv.Service.IService;
using CTN4_Serv.ServiceJoin;
using CTN4_Serv.ViewModel;
using CTN4_View_Admin.Controllers.Shop;
using DocumentFormat.OpenXml.Math;
using DocumentFormat.OpenXml.Office2010.Excel;
using DocumentFormat.OpenXml.Wordprocessing;
using Microsoft.AspNetCore.Mvc;

namespace CTN4_View.Controllers.Shop
{
    public class DanhMucSanPhamController : Controller
    {
        private readonly SanPhamCuaHangService _sanPhamCuaHangService;
        public IGioHangService _GioHang;
        public IGioHangChiTietService _GioHangChiTiet;
        public GioHangjoiin _GioHangjoiin;
        public IDanhMucService _danhMucService;
        public IDanhMucChiTietService _danhMucChiTiet;
        public DanhMucJoin _DanhMucjoiin;
        public IMauService _mauSacService;
        public IChatLieuService _chatLieuService;
        public ISizeService _sizeService;
        public ISanPhamChiTietService _sanPhamChiTietService;
        public IAnhService _anhService;
        public IGiamGiaService _giamGiaService;
        public IChiTietSanPhamYeuThichService _chiTietSanPhamYeuThichService;
        public DB_CTN4_ok _CTN4_Ok;
        public int pageSize = 6;
        public PagingInfo _pagingInfo;
        public ISanPhamService _sanphamService;
        public IKhachHangService _khachHangService;
        public IKhuyenMaiSanPhamService _kmspService;
        public DanhMucSanPhamController(IGioHangService giohang)
        {
            _sanPhamCuaHangService = new SanPhamCuaHangService();
            _GioHang = giohang;
            _GioHangChiTiet = new GioHangChiTietService();
            _GioHangjoiin = new GioHangjoiin();
            _danhMucService = new DanhMucMucService();
            _danhMucChiTiet = new DanhMucChiTietMucChiTietService();
            _DanhMucjoiin = new DanhMucJoin();
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
        }

        public IActionResult SanPhamDanhMuc(Guid id, int page, int Soluonghienthi)
        {
            var danhMucLuu = _danhMucService.GetById(id);
            var LuuTam = SessionBan.DanhMucSS(HttpContext.Session, "DanhMucTam");
            if (LuuTam.Count == 0)
            {
                LuuTam.Add(danhMucLuu);
                SessionBan.SetObjToJson(HttpContext.Session, "DanhMucTam", LuuTam);
            }
            else if (LuuTam.Count != 0)
            {
                LuuTam.Clear();
                LuuTam.Add(danhMucLuu);
                SessionBan.SetObjToJson(HttpContext.Session, "DanhMucTam", LuuTam);
            }
            var luuGiaBatDau = SessionBan.Sobatdau(HttpContext.Session, "minPrice");
            var luuGiaKetThuc = SessionBan.Sobatdau(HttpContext.Session, "maxPrice");
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
            var searchGiaTien = _sanphamService.GetAll()
            .Where(c => c.GiaNiemYet >= luuGiaBatDau && c.GiaNiemYet <= luuGiaKetThuc && c.Is_detele == true).ToList();
            if (searchTenSp.Count != 0 && searchMau.Count == 0)
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
                var khuyenMaiSp = _kmspService.GetAll().Where(c => c.KhuyenMai.TrangThai == true && c.KhuyenMai.Is_Detele == false && c.KhuyenMai.NgayBatDau <= DateTime.Now && c.KhuyenMai.NgayKetThuc >= DateTime.Now).ToList();
                //var c = _DanhMucjoiin.GetById(id).Where(c => c.SanPham.Is_detele == true && c.SanPham.TrangThai == true).ToList();
                List<DanhMucChiTiet> c;
                if (luuGiaKetThuc != 0 && luuGiaBatDau < luuGiaKetThuc)
                {
                    c = _DanhMucjoiin.getAllDanhMucChitiet().Where(c => c.SanPham.Is_detele == true && c.SanPham.TrangThai == true && c.SanPham.GiaNiemYet >= luuGiaBatDau && c.SanPham.GiaNiemYet <= luuGiaKetThuc && a.Contains((Guid)c.SanPham.IdChatLieu) && c.DanhMuc.Id == LuuTam[0].Id).ToList();
                }
                else
                {
                    c = _DanhMucjoiin.getAllDanhMucChitiet().Where(c => c.SanPham.Is_detele == true && c.SanPham.TrangThai == true && a.Contains((Guid)c.SanPham.IdChatLieu) && c.DanhMuc.Id == LuuTam[0].Id).ToList();
                }
                if (c.Count == 0)
                {
                    var thongbaoSearch = "Không tìm thất sản phẩm nào ";
                    TempData["Notification"] = thongbaoSearch;
                    return RedirectToAction("viewSpRong", "HienThiSanPham", new { thongbaoSearch });
                }
                var view = new HienThiSanPhamView()
                {
                    danhMucs = danhMuc,
                    danhMucChiTiets = danhMucChiTiets,
                    sanPhams = listSp1,
                    sanPhamChiTiets = listSp2,
                    chatLieus = chatLieus,
                    maus = mauSacs,
                    sanphampaging1 = c.Skip((page - 1) * Soluonghienthi).Take(Soluonghienthi).ToList(),
                    pagingInfo = new PagingInfo()
                    {
                        TotalItems = c.Count(),
                        CurrentPage = page,
                        ItemsPerPage = Soluonghienthi,

                    },
                    soluonghienthi = Soluonghienthi,
                    sanPhamYeuThiches = SpYt,
                    khachHangs = khachhang,
                    danhMucChiTiet2 = c,
                    khuyenMaiSanPhams = khuyenMaiSp
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
                var listSp = _sanPhamCuaHangService.GetAll().Where(c => c.Is_detele == true).ToList();
                var listSp1 = _sanphamService.GetAll().Where(c => c.Is_detele == true).ToList();
                var listSp2 = _sanPhamChiTietService.GetAll().Where(c => c.Is_detele == true).ToList();
                var SpYt = _chiTietSanPhamYeuThichService.GetAll();
                var chatLieus = _chatLieuService.GetAll().Where(c=>c.TrangThai == true && c.Is_detele== true).ToList();
                var mauSacs = _mauSacService.GetAll().Where(c=>c.TrangThai == true && c.Is_detele== true).ToList();
                var khachhang = _khachHangService.GetAll();
                var khuyenMaiSp = _kmspService.GetAll().Where(c => c.KhuyenMai.TrangThai == true && c.KhuyenMai.Is_Detele == false && c.KhuyenMai.NgayBatDau <= DateTime.Now && c.KhuyenMai.NgayKetThuc >= DateTime.Now).ToList();
                //var c = _DanhMucjoiin.GetById(id).Where(c => c.SanPham.Is_detele == true && c.SanPham.TrangThai == true).ToList();
                List<DanhMucChiTiet> c;
                if (luuGiaKetThuc != 0 && luuGiaBatDau < luuGiaKetThuc)
                {
                    c = _DanhMucjoiin.getAllDanhMucChitiet().Where(c => c.SanPham.Is_detele == true && c.SanPham.TrangThai == true && c.SanPham.GiaNiemYet >= luuGiaBatDau && c.SanPham.GiaNiemYet <= luuGiaKetThuc && idspA.Contains((Guid)c.SanPham.Id) && c.DanhMuc.Id == LuuTam[0].Id).ToList();
                }
                else
                {
                    c = _DanhMucjoiin.getAllDanhMucChitiet().Where(c => c.SanPham.Is_detele == true && c.SanPham.TrangThai == true && idspA.Contains((Guid)c.SanPham.Id) && c.DanhMuc.Id == LuuTam[0].Id).ToList();
                }
                if (c.Count == 0)
                {
                    var thongbaoSearch = "Không tìm thất sản phẩm nào ";
                    TempData["Notification"] = thongbaoSearch;
                    return RedirectToAction("viewSpRong", "HienThiSanPham", new { thongbaoSearch });
                }
                var view = new HienThiSanPhamView()
                {
                    danhMucs = danhMuc,
                    danhMucChiTiets = danhMucChiTiets,
                    sanPhams = listSp1,
                    sanPhamChiTiets = listSp2,
                    chatLieus = chatLieus,
                    maus = mauSacs,
                    sanphampaging1 = c.Skip((page - 1) * Soluonghienthi).Take(Soluonghienthi).ToList(),
                    pagingInfo = new PagingInfo()
                    {
                        TotalItems = c.Count(),
                        CurrentPage = page,
                        ItemsPerPage = Soluonghienthi,

                    },
                    soluonghienthi = Soluonghienthi,
                    sanPhamYeuThiches = SpYt,
                    khachHangs = khachhang,
                    danhMucChiTiet2 = c,
                    khuyenMaiSanPhams = khuyenMaiSp
                };
                return View(view);
            }///// chỉ tìm màu
            else if (searchTenSp.Count != 0 && searchMau.Count != 0 && searchGiaTien.Count ==0)
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
                var khuyenMaiSp = _kmspService.GetAll().Where(c => c.KhuyenMai.TrangThai == true && c.KhuyenMai.Is_Detele == false && c.KhuyenMai.NgayBatDau <= DateTime.Now && c.KhuyenMai.NgayKetThuc >= DateTime.Now).ToList();
                //var c = _DanhMucjoiin.GetById(id).Where(c => c.SanPham.Is_detele == true && c.SanPham.TrangThai == true).ToList();
                List<DanhMucChiTiet> c;
                if (luuGiaKetThuc != 0 && luuGiaBatDau < luuGiaKetThuc)
                {
                    c = _DanhMucjoiin.getAllDanhMucChitiet().Where(c => c.SanPham.Is_detele == true && c.SanPham.TrangThai == true && c.SanPham.GiaNiemYet >= luuGiaBatDau && c.SanPham.GiaNiemYet <= luuGiaKetThuc && idspA.Contains((Guid)c.SanPham.Id) && a.Contains((Guid)c.SanPham.IdChatLieu) && c.DanhMuc.Id == LuuTam[0].Id).ToList();
                }
                else
                {
                    c = _DanhMucjoiin.getAllDanhMucChitiet().Where(c => c.SanPham.Is_detele == true && c.SanPham.TrangThai == true && idspA.Contains((Guid)c.SanPham.Id) && a.Contains((Guid)c.SanPham.IdChatLieu) && c.DanhMuc.Id == LuuTam[0].Id).ToList();
                }
                if (c.Count == 0)
                {
                    var thongbaoSearch = "Không tìm thất sản phẩm nào ";
                    TempData["Notification"] = thongbaoSearch;
                    return RedirectToAction("viewSpRong", "HienThiSanPham", new { thongbaoSearch });
                }
                var view = new HienThiSanPhamView()
                {
                    danhMucs = danhMuc,
                    danhMucChiTiets = danhMucChiTiets,
                    sanPhams = listSp1,
                    sanPhamChiTiets = listSp2,
                    chatLieus = chatLieus,
                    maus = mauSacs,
                    sanphampaging1 = c.Skip((page - 1) * Soluonghienthi).Take(Soluonghienthi).ToList(),
                    pagingInfo = new PagingInfo()
                    {
                        TotalItems = c.Count(),
                        CurrentPage = page,
                        ItemsPerPage = Soluonghienthi,

                    },
                    soluonghienthi = Soluonghienthi,
                    sanPhamYeuThiches = SpYt,
                    khachHangs = khachhang,
                    danhMucChiTiet2 = c,
                    khuyenMaiSanPhams = khuyenMaiSp
                };
                return View(view);
            }// Chỉ tìm giá tiền
            else if (searchTenSp.Count == 0 && searchMau.Count == 0)
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
                var khuyenMaiSp = _kmspService.GetAll().Where(c => c.KhuyenMai.TrangThai == true && c.KhuyenMai.Is_Detele == false && c.KhuyenMai.NgayBatDau <= DateTime.Now && c.KhuyenMai.NgayKetThuc >= DateTime.Now).ToList();
                //var c = _DanhMucjoiin.GetById(id).Where(c => c.SanPham.Is_detele == true && c.SanPham.TrangThai == true).ToList();
                List<DanhMucChiTiet> c;
                if (luuGiaKetThuc != 0 && luuGiaBatDau < luuGiaKetThuc)
                {
                    c = _DanhMucjoiin.getAllDanhMucChitiet().Where(c => c.SanPham.Is_detele == true && c.SanPham.TrangThai == true && c.SanPham.GiaNiemYet >= luuGiaBatDau && c.SanPham.GiaNiemYet <= luuGiaKetThuc && c.DanhMuc.Id == LuuTam[0].Id).ToList();
                }
                else
                {
                    c = _DanhMucjoiin.getAllDanhMucChitiet().Where(c => c.SanPham.Is_detele == true && c.SanPham.TrangThai == true && c.DanhMuc.Id == LuuTam[0].Id).ToList();
                }
                if (c.Count == 0)
                {
                    var thongbaoSearch = "Không tìm thất sản phẩm nào ";
                    TempData["Notification"] = thongbaoSearch;
                    return RedirectToAction("viewSpRong", "HienThiSanPham", new { thongbaoSearch });
                }
                var view = new HienThiSanPhamView()
                {
                    danhMucs = danhMuc,
                    danhMucChiTiets = danhMucChiTiets,
                    sanPhams = listSp1,
                    sanPhamChiTiets = listSp2,
                    chatLieus = chatLieus,
                    maus = mauSacs,
                    sanphampaging1 = c.Skip((page - 1) * Soluonghienthi).Take(Soluonghienthi).ToList(),
                    pagingInfo = new PagingInfo()
                    {
                        TotalItems = c.Count(),
                        CurrentPage = page,
                        ItemsPerPage = Soluonghienthi,

                    },
                    soluonghienthi = Soluonghienthi,
                    sanPhamYeuThiches = SpYt,
                    khachHangs = khachhang,
                    danhMucChiTiet2 = c,
                    khuyenMaiSanPhams = khuyenMaiSp
                };
                return View(view);
            }
            else if (searchTenSp.Count != 0 && searchMau.Count != 0 && searchGiaTien.Count != 0)
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
                var khuyenMaiSp = _kmspService.GetAll().Where(c => c.KhuyenMai.TrangThai == true && c.KhuyenMai.Is_Detele == false && c.KhuyenMai.NgayBatDau <= DateTime.Now && c.KhuyenMai.NgayKetThuc >= DateTime.Now).ToList();
                //var c = _DanhMucjoiin.GetById(id).Where(c => c.SanPham.Is_detele == true && c.SanPham.TrangThai == true).ToList();
                List<DanhMucChiTiet> c;
                if (luuGiaKetThuc != 0 && luuGiaBatDau < luuGiaKetThuc)
                {
                    c = _DanhMucjoiin.getAllDanhMucChitiet().Where(c => c.SanPham.Is_detele == true && c.SanPham.TrangThai == true && c.SanPham.GiaNiemYet >= luuGiaBatDau && c.SanPham.GiaNiemYet <= luuGiaKetThuc && idspA.Contains((Guid)c.SanPham.Id) && a.Contains((Guid)c.SanPham.IdChatLieu) && c.DanhMuc.Id == LuuTam[0].Id).ToList();
                }
                else
                {
                    c = _DanhMucjoiin.getAllDanhMucChitiet().Where(c => c.SanPham.Is_detele == true && c.SanPham.TrangThai == true && idspA.Contains((Guid)c.SanPham.Id) && a.Contains((Guid)c.SanPham.IdChatLieu) && c.DanhMuc.Id == LuuTam[0].Id).ToList();
                }
                if (c.Count == 0)
                {
                    var thongbaoSearch = "Không tìm thất sản phẩm nào ";
                    TempData["Notification"] = thongbaoSearch;
                    return RedirectToAction("viewSpRong", "HienThiSanPham", new { thongbaoSearch });
                }
                var view = new HienThiSanPhamView()
                {
                    danhMucs = danhMuc,
                    danhMucChiTiets = danhMucChiTiets,
                    sanPhams = listSp1,
                    sanPhamChiTiets = listSp2,
                    chatLieus = chatLieus,
                    maus = mauSacs,
                    sanphampaging1 = c.Skip((page - 1) * Soluonghienthi).Take(Soluonghienthi).ToList(),
                    pagingInfo = new PagingInfo()
                    {
                        TotalItems = c.Count(),
                        CurrentPage = page,
                        ItemsPerPage = Soluonghienthi,

                    },
                    soluonghienthi = Soluonghienthi,
                    sanPhamYeuThiches = SpYt,
                    khachHangs = khachhang,
                    danhMucChiTiet2 = c,
                    khuyenMaiSanPhams = khuyenMaiSp
                };
                return View(view);
            }
            else if (searchTenSp.Count == 0 && searchMau.Count == 0 && searchGiaTien.Count == 0 && luuGiaBatDau != 0 && luuGiaKetThuc != 0)
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
                var khuyenMaiSp = _kmspService.GetAll().Where(c => c.KhuyenMai.TrangThai == true && c.KhuyenMai.Is_Detele == false && c.KhuyenMai.NgayBatDau <= DateTime.Now && c.KhuyenMai.NgayKetThuc >= DateTime.Now).ToList();
                //var c = _DanhMucjoiin.GetById(id).Where(c => c.SanPham.Is_detele == true && c.SanPham.TrangThai == true).ToList();
                List<DanhMucChiTiet> c;
                if (luuGiaKetThuc != 0 && luuGiaBatDau < luuGiaKetThuc)
                {
                    c = _DanhMucjoiin.getAllDanhMucChitiet().Where(c => c.SanPham.Is_detele == true && c.SanPham.TrangThai == true && c.SanPham.GiaNiemYet >= luuGiaBatDau && c.SanPham.GiaNiemYet <= luuGiaKetThuc && c.DanhMuc.Id == LuuTam[0].Id).ToList();
                }
                else
                {
                    c = _DanhMucjoiin.getAllDanhMucChitiet().Where(c => c.SanPham.Is_detele == true && c.SanPham.TrangThai == true && c.DanhMuc.Id == LuuTam[0].Id).ToList();
                }
                if (c.Count == 0)
                {
                    var thongbaoSearch = "Không tìm thất sản phẩm nào ";
                    TempData["Notification"] = thongbaoSearch;
                    return RedirectToAction("viewSpRong", "HienThiSanPham", new { thongbaoSearch });
                }
                var view = new HienThiSanPhamView()
                {
                    danhMucs = danhMuc,
                    danhMucChiTiets = danhMucChiTiets,
                    sanPhams = listSp1,
                    sanPhamChiTiets = listSp2,
                    chatLieus = chatLieus,
                    maus = mauSacs,
                    sanphampaging1 = c.Skip((page - 1) * Soluonghienthi).Take(Soluonghienthi).ToList(),
                    pagingInfo = new PagingInfo()
                    {
                        TotalItems = c.Count(),
                        CurrentPage = page,
                        ItemsPerPage = Soluonghienthi,

                    },
                    soluonghienthi = Soluonghienthi,
                    sanPhamYeuThiches = SpYt,
                    khachHangs = khachhang,
                    danhMucChiTiet2 = c,
                    khuyenMaiSanPhams = khuyenMaiSp
                }; return View(view);
            }
            else
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
                var c = _DanhMucjoiin.GetById(id).Where(c => c.SanPham.Is_detele == true && c.SanPham.TrangThai == true).ToList();
                var khuyenMaiSp = _kmspService.GetAll().Where(c => c.KhuyenMai.TrangThai == true && c.KhuyenMai.Is_Detele == false && c.KhuyenMai.NgayBatDau <= DateTime.Now && c.KhuyenMai.NgayKetThuc >= DateTime.Now).ToList();
                var view = new HienThiSanPhamView()
                {
                    danhMucs = danhMuc,
                    danhMucChiTiets = danhMucChiTiets,
                    sanPhams = listSp1,
                    sanPhamChiTiets = listSp2,
                    chatLieus = chatLieus,
                    maus = mauSacs,
                    sanphampaging1 = c.Skip((page - 1) * Soluonghienthi).Take(Soluonghienthi).ToList(),
                    pagingInfo = new PagingInfo()
                    {
                        TotalItems = c.Count(),
                        CurrentPage = page,
                        ItemsPerPage = Soluonghienthi,

                    },
                    soluonghienthi = Soluonghienthi,
                    sanPhamYeuThiches = SpYt,
                    khachHangs = khachhang,
                    danhMucChiTiet2 = c,
                    khuyenMaiSanPhams = khuyenMaiSp
                }; return View(view);
            }
        }
        public IActionResult ChonShowSp(int Soluonghienthi, int page, Guid id)
        {
            //var luuChonShow = SessionBan.SanPhamMoRong(HttpContext.Session, "ChonShowSp");
            //luuChonShow = Soluonghienthi;
            //SessionBan.SetObjToJson(HttpContext.Session, "ChonShowSp", luuChonShow);
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
            var slspDanhMuc = _DanhMucjoiin.GetById(id).Where(c => c.SanPham.Is_detele == true && c.SanPham.TrangThai == true).ToList();
            var c = _DanhMucjoiin.getAllDanhMucChitiet().Where(c => c.SanPham.Is_detele == true && c.SanPham.TrangThai == true).ToList();
            var khuyenMaiSp = _kmspService.GetAll().Where(c => c.KhuyenMai.TrangThai == true && c.KhuyenMai.Is_Detele == true && c.KhuyenMai.NgayBatDau <= DateTime.Now && c.KhuyenMai.NgayKetThuc >= DateTime.Now).ToList();
            var view = new HienThiSanPhamView()
            {
                danhMucs = danhMuc,
                danhMucChiTiets = danhMucChiTiets,
                sanPhams = listSp1,
                sanPhamChiTiets = listSp2,
                chatLieus = chatLieus,
                maus = mauSacs,
                sanphampaging1 = c.Skip((page - 1) * Soluonghienthi).Take(Soluonghienthi).ToList(),
                pagingInfo = new PagingInfo()
                {
                    TotalItems = c.Count(),
                    CurrentPage = page,
                    ItemsPerPage = Soluonghienthi,

                },
                soluonghienthi = Soluonghienthi,
                sanPhamYeuThiches = SpYt,
                khachHangs = khachhang,
                danhMucChiTiet2 = c,
                khuyenMaiSanPhams = khuyenMaiSp,
            };
            return View("SanPhamDanhMuc", view);
        }
        [HttpGet]
        public IActionResult Search(int page, int Soluonghienthi, string TenSp, Guid id)
        {
            var LuuTam = SessionBan.DanhMucSS(HttpContext.Session, "DanhMucTam");
            if (LuuTam.Count != 0)
            {
                if (TenSp == null)
                {
                    return RedirectToAction("SanPhamDanhMuc");
                }
                var searchTenSp1 = _DanhMucjoiin.getAllDanhMucChitiet().Where(c => c.SanPham.Is_detele == true && c.SanPham.TrangThai == true && c.SanPham.TenSanPham.ToLower().Contains(TenSp.ToLower()) && c.DanhMuc.Id == LuuTam[0].Id).ToList();

                if (searchTenSp1.Count != 0)
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
                    var chatLieus = _chatLieuService.GetAll().Where(c=>c.TrangThai == true && c.Is_detele== true).ToList();
                    var mauSacs = _mauSacService.GetAll().Where(c=>c.TrangThai == true && c.Is_detele== true).ToList();
                    var slspDanhMuc = _DanhMucjoiin.getAllDanhMucChitiet().Where(c => c.SanPham.Is_detele == true && c.SanPham.TrangThai == true && c.SanPham.TenSanPham.ToLower().Contains(TenSp.ToLower()) && c.DanhMuc.Id == LuuTam[0].Id).ToList();
                    var c = _DanhMucjoiin.getAllDanhMucChitiet().Where(c => c.SanPham.Is_detele == true && c.SanPham.TrangThai == true).ToList();
                    var view = new HienThiSanPhamView()
                    {
                        danhMucs = danhMuc,
                        danhMucChiTiets = danhMucChiTiets,
                        sanPhams = listSp1,
                        sanPhamChiTiets = listSp2,
                        chatLieus = chatLieus,
                        maus = mauSacs,
                        sanphampaging1 = slspDanhMuc.Skip((page - 1) * Soluonghienthi).Take(Soluonghienthi).ToList(),
                        pagingInfo = new PagingInfo()
                        {
                            TotalItems = slspDanhMuc.Count(),
                            CurrentPage = page,
                            ItemsPerPage = Soluonghienthi,

                        },
                        soluonghienthi = Soluonghienthi,
                        sanPhamYeuThiches = SpYt,
                        khachHangs = khachhang,


                        danhMucChiTiet2 = slspDanhMuc,
                    };
                    return View("SanPhamDanhMuc", view);
                }
                else
                {
                    //ViewBag.ThongBao = "Không tìm thấy sản phẩm nào";
                    //return PartialView("_ThongBaoPartial");

                    var thongbaoSearch = "Không tìm thất sản phẩm nào ";
                    TempData["Notification"] = thongbaoSearch;
                    return RedirectToAction("viewSpRong", "HienThiSanPham", new { thongbaoSearch });
                }
            }
            if (TenSp == null)
            {
                return RedirectToAction("SanPhamDanhMuc");
            }
            var searchTenSp = _DanhMucjoiin.getAllDanhMucChitiet().Where(c => c.SanPham.Is_detele == true && c.SanPham.TrangThai == true && c.SanPham.TenSanPham.ToLower().Contains(TenSp.ToLower())).ToList();

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
                var chatLieus = _chatLieuService.GetAll().Where(c=>c.TrangThai == true && c.Is_detele== true).ToList();
                var mauSacs = _mauSacService.GetAll().Where(c=>c.TrangThai == true && c.Is_detele== true).ToList();
                var slspDanhMuc = _DanhMucjoiin.getAllDanhMucChitiet().Where(c => c.SanPham.Is_detele == true && c.SanPham.TrangThai == true && c.SanPham.TenSanPham.ToLower().Contains(TenSp.ToLower())).ToList();
                var c = _DanhMucjoiin.getAllDanhMucChitiet().Where(c => c.SanPham.Is_detele == true && c.SanPham.TrangThai == true).ToList();
                var view = new HienThiSanPhamView()
                {
                    danhMucs = danhMuc,
                    danhMucChiTiets = danhMucChiTiets,
                    sanPhams = listSp1,
                    sanPhamChiTiets = listSp2,
                    chatLieus = chatLieus,
                    maus = mauSacs,
                    sanphampaging1 = slspDanhMuc.Skip((page - 1) * Soluonghienthi).Take(Soluonghienthi).ToList(),
                    pagingInfo = new PagingInfo()
                    {
                        TotalItems = slspDanhMuc.Count(),
                        CurrentPage = page,
                        ItemsPerPage = Soluonghienthi,

                    },
                    soluonghienthi = Soluonghienthi,
                    sanPhamYeuThiches = SpYt,
                    khachHangs = khachhang,


                    danhMucChiTiet2 = slspDanhMuc,
                };
                return View("SanPhamDanhMuc", view);
            }
            else
            {
                var thongbaoSearch = "Không tìm thấy sản phẩm nào ";
                TempData["Notification"] = thongbaoSearch;
                return RedirectToAction("viewSpRong", "HienThiSanPham", new { thongbaoSearch });
            }



        }
        public IActionResult HienThiSanPham2(int page, int Soluonghienthi)
        {

            var LuuTam = SessionBan.DanhMucSS(HttpContext.Session, "DanhMucTam");
            if (LuuTam.Count != 0)
            {
                var searchTenSp1 = _DanhMucjoiin.getAllDanhMucChitiet().Where(c => c.SanPham.Is_detele == true && c.SanPham.TrangThai == true && c.DanhMuc.Id == LuuTam[0].Id).ToList();

                if (searchTenSp1.Count != 0)
                {
                    var LuuTamCl = SessionBan.ChatLieuSS(HttpContext.Session, "ChatLieuTam");
                    var LuuTamMau = SessionBan.MauSacSS(HttpContext.Session, "MauSacTam");
                    var d = new List<Guid>();
                    foreach (var i in LuuTam)
                    {
                        d.Add(i.Id);
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

                    if (searchTenSp.Count != 0 && searchMau.Count == 0)
                    {
                        if (Soluonghienthi == 0) { Soluonghienthi = 9; }
                        if (page == 0) { page = 1; }
                         var danhMuc = _danhMucService.GetAll().Where(c=> c.Is_detele== true).ToList();
                        var danhMucChiTiets = _danhMucChiTiet.GetAll();
                        var SpYt = _chiTietSanPhamYeuThichService.GetAll();
                        var listSp = _sanPhamCuaHangService.GetAll().Where(c => c.Is_detele == true && a.Contains((Guid)c.IdChatLieu)).ToList();
                        var listSp1 = _sanphamService.GetAll().Where(c => c.Is_detele == true).ToList();
                        var listSp2 = _sanPhamChiTietService.GetAll().Where(c => c.Is_detele == true).ToList();
                        var khachhang = _khachHangService.GetAll();
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
                        };
                        return View("SanPhamDanhMuc", view);
                    }
                    else if (searchTenSp.Count == 0 && searchMau.Count != 0)
                    {
                        if (Soluonghienthi == 0) { Soluonghienthi = 9; }
                        if (page == 0) { page = 1; }
                         var danhMuc = _danhMucService.GetAll().Where(c=> c.Is_detele== true).ToList();
                        var danhMucChiTiets = _danhMucChiTiet.GetAll();
                        var SpYt = _chiTietSanPhamYeuThichService.GetAll();
                        var listSp = _sanPhamCuaHangService.GetAll().Where(c => c.Is_detele == true && idspA.Contains((Guid)c.Id)).ToList();
                        var listSp1 = _sanphamService.GetAll().Where(c => c.Is_detele == true).ToList();
                        var listSp2 = _sanPhamChiTietService.GetAll().Where(c => c.Is_detele == true).ToList();
                        var khachhang = _khachHangService.GetAll();
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
                        };
                        return View("SanPhamDanhMuc", view);
                    }
                    else if (searchTenSp.Count != 0 && searchMau.Count != 0)
                    {
                        if (Soluonghienthi == 0) { Soluonghienthi = 9; }
                        if (page == 0) { page = 1; }
                         var danhMuc = _danhMucService.GetAll().Where(c=> c.Is_detele== true).ToList();
                        var danhMucChiTiets = _danhMucChiTiet.GetAll();
                        var SpYt = _chiTietSanPhamYeuThichService.GetAll();
                        var listSp = _sanPhamCuaHangService.GetAll().Where(c => c.Is_detele == true && a.Contains((Guid)c.IdChatLieu) && idspA.Contains((Guid)c.Id)).ToList();
                        if (listSp.Count == 0)
                        {
                            var thongbaoSearch = "Không tìm thất sản phẩm nào ";
                            TempData["Notification"] = thongbaoSearch;
                            return RedirectToAction("viewSpRong", "HienThiSanPham", new { thongbaoSearch });
                        }
                        var listSp1 = _sanphamService.GetAll().Where(c => c.Is_detele == true).ToList();
                        var listSp2 = _sanPhamChiTietService.GetAll().Where(c => c.Is_detele == true).ToList();
                        var khachhang = _khachHangService.GetAll();
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
                        };
                        return View("SanPhamDanhMuc", view);
                    }
                    else
                    {
                        return RedirectToAction("SanPhamDanhMuc");
                    }
                }

            }
            var thongbaoSearch1 = "Không tìm thất sản phẩm nào ";
            TempData["Notification"] = thongbaoSearch1;
            return RedirectToAction("viewSpRong", "HienThiSanPham", new { thongbaoSearch1 });

        }



    }
}
