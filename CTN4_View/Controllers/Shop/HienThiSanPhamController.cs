using CTN4_Serv.Service.IService;
using CTN4_Serv.Service;
using CTN4_Serv.ServiceJoin;
using Microsoft.AspNetCore.Mvc;

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
    }
}
