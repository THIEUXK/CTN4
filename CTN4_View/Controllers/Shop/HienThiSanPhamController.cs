using CTN4_Serv.Service.IService;
using CTN4_Serv.Service;
using CTN4_Serv.ServiceJoin;
using CTN4_Serv.ViewModel;
using Microsoft.AspNetCore.Mvc;
using CTN4_Data.Models.DB_CTN4;

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

		public HienThiSanPhamController()
		{
			_sanPhamCuaHangService = new SanPhamCuaHangService();
			_GioHang=new GioHangService();
			_GioHangChiTiet = new GioHangChiTietService();
			_GioHangjoiin =new GioHangjoiin();
			_danhMucService = new DanhMucMucService();
			_danhMucChiTiet = new DanhMucChiTietMucChiTietService();
		}
		[HttpGet]
		public IActionResult HienThiSanPham()
		{

			var danhMuc = _danhMucService.GetAll();
			var danhMucChiTiets = _danhMucChiTiet.GetAll();
			var listSpCt = _sanPhamCuaHangService.GetAll();
			var a = new HienThiSanPhamView()
			{
				danhMucs = danhMuc,
				danhMucChiTiets = danhMucChiTiets,
				sanPhamChiTiets = listSpCt,
			};
			return View(a);
		}
		//[Route("/{Alias}-{id}.html", Name ="SanPhamChiTiet")]
		public IActionResult HienThiSanPhamChiTiet(Guid id)
		{
			var view = new SanPhamBan()
			{
				SanPhamChiTiet = _sanPhamCuaHangService.GetById(id),
				Anh = _sanPhamCuaHangService.GeAnhs(id)
			};
			return View(view);

		}
		
		
	}
}
