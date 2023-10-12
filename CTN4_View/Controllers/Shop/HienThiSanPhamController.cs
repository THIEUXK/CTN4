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

		public HienThiSanPhamController()
		{
			_sanPhamCuaHangService = new SanPhamCuaHangService();
			_GioHang=new GioHangService();
			_GioHangChiTiet = new GioHangChiTietService();
			_GioHangjoiin =new GioHangjoiin();
		}
		[HttpGet]
		public IActionResult HienThiSanPham()
		{
			var listSpCt = _sanPhamCuaHangService.GetAll();
			return View(listSpCt);
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
