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

		public HienThiSanPhamController()
		{
			_sanPhamCuaHangService = new SanPhamCuaHangService();
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
		//public IActionResult AddTOCard(Guid idSPCT, int soluong)
		//{

		//	if ()
		//	{
		//		return RedirectToAction("GioHang");
		//	}
		//	return RedirectToAction("HienThiSanPhamChiTiet", idSPCT);
		//}
		public IActionResult GioHang()
		{
			return View();
		}
	}
}
