using CTN4_Data.Models.DB_CTN4;
using CTN4_Serv.Service;
using CTN4_Serv.Service.IService;
using CTN4_Serv.ServiceJoin;
using CTN4_Serv.ViewModel;
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
        public DanhMucSanPhamController()
        {
            _sanPhamCuaHangService = new SanPhamCuaHangService();
			_GioHang=new GioHangService();
			_GioHangChiTiet = new GioHangChiTietService();
			_GioHangjoiin =new GioHangjoiin();
			_danhMucService = new DanhMucMucService();
			_danhMucChiTiet = new DanhMucChiTietMucChiTietService();
            _DanhMucjoiin = new DanhMucJoin();
        }
        public IActionResult SanPhamDanhMuc(Guid id)
        {


            var c = _DanhMucjoiin.GetById(id);
            //var a = _sanPhamCuaHangService.GetAll().Where(c=>c.Id == c.)
            var danhMuc = _danhMucService.GetAll();
            var danhMucChiTiets = _danhMucChiTiet.GetAll();
            var view = new HienThiSanPhamView()
            {
                danhMucs = danhMuc,
                danhMucChiTiets = danhMucChiTiets,
                danhMucChiTiet2 = c,
            };
            return View(view);
        }
    }
}
