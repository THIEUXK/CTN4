using CTN4_Data.Models.DB_CTN4;
using CTN4_Serv.Service;
using CTN4_Serv.Service.IService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CTN4_View.Areas.Admin.Controllers.QuanLySpbc
{
    [Area("admin")]
    public class QuanLySpBcController : Controller
    {
        public ISanPhamChiTietService _sanPhamChiTietService;
        public ISanPhamService _sanPhamSv;
        public IHoaDonService _hoaDonService;
        public IHoaDonChiTietService _hoaDonChiTietService;
        public IDanhMucChiTietService _danhMucChiTietService;
        public IDanhMucService _danhMucService;


        public QuanLySpBcController()
        {
            _sanPhamChiTietService = new SanPhamChiTietService();
            _sanPhamSv = new SanPhamService();
            _hoaDonService = new HoaDonService();
            _hoaDonChiTietService = new HoaDonChiTietService();
            _danhMucChiTietService = new DanhMucChiTietMucChiTietService();
            _danhMucService = new DanhMucMucService();
        }
        // GET: QuanLySpBcController
        [HttpGet]
        public ActionResult AllSpindex()
        {
            var listsp = _hoaDonChiTietService.GetAll();
            var sp = _sanPhamSv.GetAll();
            var tensp = new List<string>();
            foreach (var a in listsp)
            {
                if (!tensp.Contains(a.SanPhamChiTiet.SanPham.TenSanPham))
                {
                    tensp.Add(a.SanPhamChiTiet.SanPham.TenSanPham);

                }

            }
            var sanPhamHungViews = new List<SanPhamHungView>();

            foreach (var b in tensp)
            {
                var listSpHien = listsp.Where(c => c.SanPhamChiTiet.SanPham.TenSanPham == b && c.TrangThai == true && (c.HoaDon.TrangThai == "Giao hàng thành công" || c.HoaDon.TrangThai == "Đưa hàng thành công"));
                int soluongmua = 0;
             
                foreach (var item in listSpHien)
                {
                    soluongmua += item.SoLuong;
                }
                if (soluongmua!=0)
                {
                    SanPhamHungView c = new SanPhamHungView()
                    {
                        TenSp = b,
                        AnhDaiDien = listSpHien.FirstOrDefault(c => c.SanPhamChiTiet.SanPham.TenSanPham == b).SanPhamChiTiet.SanPham.AnhDaiDien,
                        soluotmua = soluongmua,
                        GiaSanPham = listSpHien.FirstOrDefault(c => c.SanPhamChiTiet.SanPham.TenSanPham == b).SanPhamChiTiet.SanPham.GiaNiemYet,

                    };
                    sanPhamHungViews.Add(c);
                }
                
            }
            var view = new SanphamBcView()
            {
                SanPhamHungs = sanPhamHungViews.OrderByDescending(c => c.soluotmua).ToList()

            };
            return View(view);
        }
        public ActionResult themsanpham(string tensp)
        {
            var sp = _sanPhamSv.GetAll().FirstOrDefault(c => c.TenSanPham == tensp);
            var danhmuc = _danhMucService.GetAll().FirstOrDefault(c => c.Id == Guid.Parse("56dd3ee2-c4df-4376-b982-e2c0f7081173"));
            var existingDanhMucChiTiet = _danhMucChiTietService.GetAll()
    .FirstOrDefault(c => c.IdSanPham == sp.Id && c.IdDanhMuc == danhmuc.Id);
            if (existingDanhMucChiTiet != null)
            {
                var message3 = "Đã tồn tại sản phẩm ";
                TempData["ErrorMessage3"] = message3;
                return RedirectToAction("AllSpindex", new { message3 });
            }
            else
            {
                var danhmucct = new DanhMucChiTiet()
                {
                    IdSanPham = sp.Id,
                    IdDanhMuc = danhmuc.Id,
                };
                if (_danhMucChiTietService.Them(danhmucct) == true)
                {
                    var message1 = "Thêm Thành Công";
                    TempData["ErrorMessage1"] = message1;
                    return RedirectToAction("AllSpindex", new { message1 });

                }
                var message = "Thêm Thất Bại";
                TempData["ErrorMessage"] = message;
                return RedirectToAction("AllSpindex", new { message });
            }

        }

    }




}
