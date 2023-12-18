using CTN4_Serv.Service;
using CTN4_Serv.Service.IService;
using CTN4_Serv.ServiceJoin;
using CTN4_View.Areas.Admin.Viewmodel;
using Microsoft.AspNetCore.Mvc;

namespace CTN4_View.Areas.Admin.Controllers.QuanLySale
{
    [Area("admin")]
    public class QuanLySale : Controller
    {
        public ISanPhamService _sp;
        public IKhuyenMaiSanPhamService _kmsp;
        public IKhuyenMaiService _km;

        public KhuyenMaiSanPhamJoin _khuyenMaiSanPhamJoin;

        public QuanLySale()
        {
            _sp = new SanPhamService();
            _kmsp = new KhuyenMaiSanPhamService();
            _km = new KhuyenMaiService();
            _khuyenMaiSanPhamJoin = new KhuyenMaiSanPhamJoin();
        }
        public IActionResult Index()
        {
            var km = _khuyenMaiSanPhamJoin.getAllKhuyenMaiSanPham();
            var view = new SaleViewModel()
            {
                khuyenMaiSanPhams = km,
            };
            return View(view);
        }
    }
}

