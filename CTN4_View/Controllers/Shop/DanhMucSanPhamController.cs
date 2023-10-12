using CTN4_Data.Models.DB_CTN4;
using CTN4_Serv.ServiceJoin;
using Microsoft.AspNetCore.Mvc;

namespace CTN4_View.Controllers.Shop
{
    public class DanhMucSanPhamController : Controller
    {

       public DanhMucJoin _DanhMucjoiin;
        public DanhMucSanPhamController()
        {
            _DanhMucjoiin = new DanhMucJoin();
        }
        public IActionResult SanPhamDanhMuc(string danhmuc)
        {
            var a = _DanhMucjoiin.sanPhamDanhMuc(danhmuc);
            return View(a);
        }
    }
}
