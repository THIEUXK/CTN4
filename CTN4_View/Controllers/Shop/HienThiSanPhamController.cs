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
        //public DanhMucJoin _DanhMucjoiin;
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
            _chatLieuService = new ChatLieuService();
            _pagingInfo = new PagingInfo();
            _CTN4_Ok = new DB_CTN4_ok();
        }
        public IActionResult HienThiSanPham(int page)
        {
            
            if (page == null) {page=1;}
            var danhMuc = _danhMucService.GetAll();
            var danhMucChiTiets = _danhMucChiTiet.GetAll();
            var listSpCt = _sanPhamCuaHangService.GetAll();
            var mauSacs = _mauSacService.GetAll();
            var chatLieus = _chatLieuService.GetAll();
            
            //var Paging = _CTN4_Ok.SanPhamChiTiets.Include(c => c.ChatLieu).Include(c => c.NSX).Include(c => c.Mau).Include(c => c.Size).Include(c => c.SanPham).Skip((page - 1) * pageSize).Take(pageSize).ToList();
            
            var view = new HienThiSanPhamView()
            {
                danhMucs = danhMuc,
                danhMucChiTiets = danhMucChiTiets,
                sanPhamChiTiets = listSpCt,
                maus = mauSacs,
                chatLieus = chatLieus,
                sanphampaging = listSpCt.Skip((page - 1) * pageSize).Take(pageSize).ToList(),
                pagingInfo = new PagingInfo()
                {
                    TotalItems = listSpCt.Count(),
                    CurrentPage= page,
                    ItemsPerPage = 6,
            
                }
            };
            return View(view);
        }
        public IActionResult HienThiSanPhamChiTiet(Guid id)
        {
            var view = new SanPhamBan()
            {
                SanPhamChiTiet = _sanPhamCuaHangService.GetById(id),
                Anh = _sanPhamCuaHangService.GeAnhs(id)
            };
            return View(view);

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
        //[Route("/SearchGiaTien/{min}/[max]")]
        public IActionResult SearchGiaTien(float min, float max)
        {
            var view = _sanPhamCuaHangService.TimKiemTenKhoangGia(min, max);
            float maxPrice = _sanPhamCuaHangService.MaxTien();
            ViewBag.MaxPrice = maxPrice;
            return View(view);

        }
    }
}
