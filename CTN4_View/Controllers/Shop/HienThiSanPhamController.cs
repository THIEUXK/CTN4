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

		public HienThiSanPhamController()
		{
			_sanPhamCuaHangService = new SanPhamCuaHangService();
			_GioHang=new GioHangService();
			_GioHangChiTiet = new GioHangChiTietService();
		}
		[HttpGet]
		public IActionResult HienThiSanPham()
		{
			var listSpCt = _sanPhamCuaHangService.GetAll();
			return View(listSpCt);
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
		public IActionResult AddTOCard(Guid idSPCT, int soluong)
		{

			var gioHang = _GioHang.GetAll();
			if (gioHang.Count == 0)
			{
				var a = new GioHang()
				{
					Id = Guid.Parse("d16ac357-3ced-4c2c-bcdc-d38971214498"),
					IdKhachHang = Guid.Parse("d16ac357-3ced-4c2c-bcdc-d38971214499"),
					TrangThai = true
				};
				if (_GioHang.Them(a))
				{
					return RedirectToAction("GioHang");
				}
			}

			var CTGiohangn = _GioHangChiTiet.GetAll().FirstOrDefault(c => c.IdSanPhamChiTiet == idSPCT);
			if (CTGiohangn == null)
			{
				var b = new GioHangChiTiet()
				{
					IdSanPhamChiTiet = idSPCT,
					IdGioHang = Guid.Parse("d16ac357-3ced-4c2c-bcdc-d38971214498"),
					SoLuong = soluong,
				};
				if (_GioHangChiTiet.Them(b))
				{
					return RedirectToAction("GioHang");
				}
			}
			else
			{
				CTGiohangn.SoLuong += soluong;
				if (_GioHangChiTiet.Sua(CTGiohangn))
				{
					return RedirectToAction("GioHang");
				}

			}
			return RedirectToAction("HienThiSanPhamChiTiet",idSPCT);
		}
		public IActionResult GioHang()
		{
			
			return View();
		}
	}
}
