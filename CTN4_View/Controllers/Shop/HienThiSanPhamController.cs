using CTN4_Serv.Service.IService;
using CTN4_Serv.Service;
using CTN4_Serv.ServiceJoin;
using CTN4_Serv.ViewModel;
using Microsoft.AspNetCore.Mvc;
using CTN4_Data.Models.DB_CTN4;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore;

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
		 public DanhMucJoin _DanhMucjoiin;
		
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
		public IActionResult HienThiSanPhamChiTiet(Guid id)
		{
			var view = new SanPhamBan()
			{
				SanPhamChiTiet = _sanPhamCuaHangService.GetById(id),
				Anh = _sanPhamCuaHangService.GeAnhs(id)
			};
			return View(view);

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
