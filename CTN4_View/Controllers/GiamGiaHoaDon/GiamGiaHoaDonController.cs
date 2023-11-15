using CTN4_Data.Models.DB_CTN4;
using CTN4_Serv.Service;
using CTN4_Serv.Service.IService;
using Microsoft.AspNetCore.Mvc;

namespace CTN4_View.Controllers.GiamGiaHoaDon
{
    public class GiamGiaHoaDonController : Controller
    {
        public IHoaDonService HoaDonService { get; set; }
        public IGiamGiaService GiamGiaService { get; set; }
        public IGiamGiaChiTietService GiamGiaChiTietService { get; set; }

        public GiamGiaHoaDonController()
        {
            HoaDonService = new HoaDonService();
            GiamGiaChiTietService = new GiamGiaChiTietService();
            GiamGiaService = new GiamGiaService();
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult ApDungGiamGia(int IdHoaDon, string GiamGia)
        {
            if (GiamGia == null)
            {
                var message = "hãy nhập mã của bạn";
                TempData["TB1"] = message;
                return RedirectToAction("HoaDonChiTiet", "BanHang", new { id = IdHoaDon, message });
            }
            var Voucher = GiamGiaService.GetAll().FirstOrDefault( c=> c.MaGiam == GiamGia && c.NgayBatDau < DateTime.Now && c.NgayKetThuc > DateTime.Now);
            if (Voucher == null)
            {
                var message = "Mã không tồn tại";
                TempData["TB1"] = message;
                return RedirectToAction("HoaDonChiTiet", "BanHang", new { id = IdHoaDon, message });
            }    
            else
            {
                var Hoadon = HoaDonService.GetAll().FirstOrDefault(c => c.Id == IdHoaDon && c.TongTien >= Voucher.DieuKienGiam);

                if (Voucher.LoaiGiamGia == true)
                {
                    Hoadon.TongTien -= Voucher.SoTienGiam;
                    Voucher.SoLuong -= 1;
                    GiamGiaService.Sua(Voucher);
                    if (HoaDonService.Sua(Hoadon) == false) 
                    {
                        var message = "Áp mã thất bại";
                        TempData["TB1"] = message;
                        return RedirectToAction("HoaDonChiTiet", "BanHang", new { id = IdHoaDon, message });
                    }
                }
                else
                {
                    Hoadon.TongTien /= Voucher.PhanTramGiam;
                    Voucher.SoLuong -= 1;
                    GiamGiaService.Sua(Voucher);
                    if (HoaDonService.Sua(Hoadon) == false)
                    {
                        var message = "Áp mã thất bại";
                        TempData["TB1"] = message;
                        return RedirectToAction("HoaDonChiTiet", "BanHang", new { id = IdHoaDon, message });
                    }
                }
                var GiamGiaChiTiet = new GiamGiaChiTiet()
                {
                    IdGiamGia = Voucher.Id,
                    IdHoaDon = IdHoaDon,

                };
                var message2 = "Sử dụng voucher thành công";
                TempData["TB2"] = message2;
                return RedirectToAction("HoaDonChiTiet", "BanHang", new { id = IdHoaDon, message2 });
            }
            return View();
        }
    }
}
