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
        public ISizeService _sizeService;
        public ISanPhamChiTietService _sanPhamChiTietService;
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
            _pagingInfo = new PagingInfo();
            _CTN4_Ok = new DB_CTN4_ok();
        }
        public IActionResult HienThiSanPham(int page)
        {

            if (page == null) { page = 1; }
            var danhMuc = _danhMucService.GetAll();
            var danhMucChiTiets = _danhMucChiTiet.GetAll();
            var listSp = _sanPhamCuaHangService.GetAll();
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
            return View(view);
        }
        public IActionResult HienThiSanPhamChiTiet(Guid id)
        {
            var listsp1 = _CTN4_Ok.SanPhamChiTiets.Include(c=>c.Mau).Include(c=>c.Size).Include(c=>c.SanPham).Where(c=>c.IdSp == id).ToList();
            //var listsp = _sanPhamChiTietService.GetSanPhamChiTiets(id).Distinct().ToList();
            var mau = _mauSacService.GetAll().Distinct().ToList();
            var size = _sizeService.GetAll().Distinct().ToList();
            //var QS = (from idmau in listsp
            //          select mau).Distinct();
            //foreach (var item in MS)
            //{
            //    Console.WriteLine(item);
            //}
            var view = new SanPhamBan()
            {
                sanPhams = _sanPhamCuaHangService.GetById(id),
                Anh = _sanPhamCuaHangService.GeAnhs(id),
                sanPhamChiTiets = listsp1,
                maus = mau,
                sizes = size
                
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
