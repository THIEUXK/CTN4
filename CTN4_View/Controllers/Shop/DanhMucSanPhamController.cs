using CTN4_Data.DB_Context;
using CTN4_Data.Models.DB_CTN4;
using CTN4_Serv.Service;
using CTN4_Serv.Service.IService;
using CTN4_Serv.ServiceJoin;
using CTN4_Serv.ViewModel;
using CTN4_View_Admin.Controllers.Shop;
using DocumentFormat.OpenXml.Math;
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
            if (Soluonghienthi == 0) { Soluonghienthi = 6; }
            if (page == 0) { page = 1; }
            var danhMuc = _danhMucService.GetAll();
            var danhMucChiTiets = _danhMucChiTiet.GetAll();
            var listSp = _sanPhamCuaHangService.GetAll().Where(c => c.Is_detele == true).ToList();
            var SpYt = _chiTietSanPhamYeuThichService.GetAll();
            var chatLieus = _chatLieuService.GetAll();
            var khachhang = _khachHangService.GetAll();
            var c = _DanhMucjoiin.GetById(id).Where(c => c.SanPham.Is_detele == true).ToList();
            var view = new HienThiSanPhamView()
            {
                danhMucs = danhMuc,
                danhMucChiTiets = danhMucChiTiets,
                sanPhams = listSp,
                chatLieus = chatLieus,
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
            };
            return View(view);
        }
        public IActionResult ChonShowSp(int Soluonghienthi, int page, Guid id)
        {
            if (Soluonghienthi == 0) { Soluonghienthi = 6; }
            if (page == 0) { page = 1; }
            var danhMuc = _danhMucService.GetAll();
            var danhMucChiTiets = _danhMucChiTiet.GetAll();
            var listSp = _sanPhamCuaHangService.GetAll().Where(c => c.Is_detele == true).ToList();
            var SpYt = _chiTietSanPhamYeuThichService.GetAll();
            var chatLieus = _chatLieuService.GetAll();
            var khachhang = _khachHangService.GetAll();
            var slspDanhMuc = _DanhMucjoiin.GetById(id).Where(c => c.SanPham.Is_detele == true).ToList();
            var c = _DanhMucjoiin.getAllDanhMucChitiet().Where(c => c.SanPham.Is_detele == true).ToList();
            var view = new HienThiSanPhamView()
            {
                danhMucs = danhMuc,
                danhMucChiTiets = danhMucChiTiets,
                sanPhams = listSp,
                chatLieus = chatLieus,
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
                var searchTenSp1 = _DanhMucjoiin.getAllDanhMucChitiet().Where(c => c.SanPham.Is_detele == true && c.SanPham.TenSanPham.ToLower().Contains(TenSp.ToLower()) && c.DanhMuc.Id == LuuTam[0].Id).ToList();

                if (searchTenSp1.Count != 0)
                {
                    if (Soluonghienthi == 0) { Soluonghienthi = 6; }
                    if (page == 0) { page = 1; }
                    var danhMuc = _danhMucService.GetAll();
                    var danhMucChiTiets = _danhMucChiTiet.GetAll();
                    var SpYt = _chiTietSanPhamYeuThichService.GetAll();
                    var listSp = _sanPhamCuaHangService.GetAll().Where(c => c.Is_detele == true && c.TenSanPham.ToLower().Contains(TenSp.ToLower())).ToList();
                    var khachhang = _khachHangService.GetAll();
                    var chatLieus = _chatLieuService.GetAll();
                    var slspDanhMuc = _DanhMucjoiin.getAllDanhMucChitiet().Where(c => c.SanPham.Is_detele == true && c.SanPham.TenSanPham.ToLower().Contains(TenSp.ToLower())&& c.DanhMuc.Id == LuuTam[0].Id).ToList();
                    var c = _DanhMucjoiin.getAllDanhMucChitiet().Where(c => c.SanPham.Is_detele == true).ToList();
                    var view = new HienThiSanPhamView()
                    {
                        danhMucs = danhMuc,
                        danhMucChiTiets = danhMucChiTiets,
                        sanPhams = listSp,
                        chatLieus = chatLieus,
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
                    ViewBag.ThongBao = "Không tìm thấy sản phẩm nào";
                    return PartialView("_ThongBaoPartial");

                    //var thongbaoSearch = "Không tìm thất sản phẩm nào ";
                    //TempData["Notification"] = thongbaoSearch;
                    //return RedirectToAction("viewSpRong", "HienThiSanPham", new { thongbaoSearch });
                }
            }
            if (TenSp == null)
            {
                return RedirectToAction("SanPhamDanhMuc");
            }
            var searchTenSp = _DanhMucjoiin.getAllDanhMucChitiet().Where(c => c.SanPham.Is_detele == true && c.SanPham.TenSanPham.ToLower().Contains(TenSp.ToLower())).ToList();

            if (searchTenSp.Count != 0)
            {
                if (Soluonghienthi == 0) { Soluonghienthi = 6; }
                if (page == 0) { page = 1; }
                var danhMuc = _danhMucService.GetAll();
                var danhMucChiTiets = _danhMucChiTiet.GetAll();
                var SpYt = _chiTietSanPhamYeuThichService.GetAll();
                var listSp = _sanPhamCuaHangService.GetAll().Where(c => c.Is_detele == true && c.TenSanPham.ToLower().Contains(TenSp.ToLower())).ToList();
                var khachhang = _khachHangService.GetAll();
                var chatLieus = _chatLieuService.GetAll();
                var slspDanhMuc = _DanhMucjoiin.getAllDanhMucChitiet().Where(c => c.SanPham.Is_detele == true && c.SanPham.TenSanPham.ToLower().Contains(TenSp.ToLower())).ToList();
                var c = _DanhMucjoiin.getAllDanhMucChitiet().Where(c => c.SanPham.Is_detele == true).ToList();
                var view = new HienThiSanPhamView()
                {
                    danhMucs = danhMuc,
                    danhMucChiTiets = danhMucChiTiets,
                    sanPhams = listSp,
                    chatLieus = chatLieus,
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
                ViewBag.ThongBao = "Không tìm thấy sản phẩm nào";
                return PartialView("_ThongBaoPartial");

                //var thongbaoSearch = "Không tìm thất sản phẩm nào ";
                //TempData["Notification"] = thongbaoSearch;
                //return RedirectToAction("viewSpRong", "HienThiSanPham", new { thongbaoSearch });
            }



        }
        //public IActionResult _ThongBaoPartial()
        //{

        //    return View();
        //}
    }
}
