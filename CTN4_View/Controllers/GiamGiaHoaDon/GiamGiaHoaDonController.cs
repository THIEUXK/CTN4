using CTN4_Data.Models.DB_CTN4;
using CTN4_Serv.Service;
using CTN4_Serv.Service.IService;
using CTN4_Serv.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace CTN4_View.Controllers.GiamGiaHoaDon
{
    public class GiamGiaHoaDonController : Controller
    {
        public IHoaDonService _HoaDonService { get; set; }
        public IGiamGiaService _GiamGiaService { get; set; }
        public IGiamGiaChiTietService _GiamGiaChiTietService { get; set; }
        public IHoaDonChiTietService _HoaDonChiTiwtService { get; set; }

        public GiamGiaHoaDonController()
        {
            _HoaDonService = new HoaDonService();
            _GiamGiaChiTietService = new GiamGiaChiTietService();
            _GiamGiaService = new GiamGiaService();
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult ApDungGiamGia(int IdHoaDon, string GiamGia)
        {


            bool IsGiamGiaDaSuDung(string maGiamGia)
            {
                // Thực hiện kiểm tra trong cơ sở dữ liệu hoặc nơi lưu trữ khác
                // Trả về true nếu đã sử dụng, false nếu chưa
                // Đây chỉ là một ví dụ giả định, bạn cần điều chỉnh theo cách thức hoạt động của ứng dụng của mình
                return false; // hoặc true nếu đã sử dụng
            }

            if (GiamGia == null)
            {
                var message = "hãy nhập mã của bạn";
                TempData["TB1"] = message;
                return RedirectToAction("HoaDonChiTiet", "BanHang", new { id = IdHoaDon, message });
            }

            if (IsGiamGiaDaSuDung(GiamGia))
            {
                var message = "Bạn đã sử dụng mã giảm giá cho đơn hàng này rồi";
                TempData["TB1"] = message;
                return RedirectToAction("HoaDonChiTiet", "BanHang", new { id = IdHoaDon, message });
            }
            var Voucher = _GiamGiaService.GetAll().FirstOrDefault(c => c.MaGiam == GiamGia && c.NgayBatDau < DateTime.Now && c.NgayKetThuc > DateTime.Now);
            
            if (Voucher == null)
            {
                var message = "Mã không tồn tại";
                TempData["TB1"] = message;
                return RedirectToAction("HoaDonChiTiet", "BanHang", new { id = IdHoaDon, message });
            }
            else
            {
                var Hoadon = _HoaDonService.GetAll().FirstOrDefault(c => c.Id == IdHoaDon);
                var daSuDung = _GiamGiaChiTietService.GetAll().Any(g => g.IdGiamGia == Voucher.Id && g.IdHoaDon == IdHoaDon);
                var giatien = _HoaDonService.GetAll().FirstOrDefault(c => c.Id == IdHoaDon);
                if (daSuDung)
                {
                    var message = "Mã giảm giá này đã được sử dụng trước đó";
                    TempData["TB1"] = message;
                    return RedirectToAction("HoaDonChiTiet", "BanHang", new { id = IdHoaDon, message });
                }
                else
                {
                  
                    if (Hoadon.TongTien < Voucher.DieuKienGiam)
                    {
                        var message = "Mã giảm giá này không phù hợp với đơn hàng của bạn";
                        TempData["TB1"] = message;
                        return RedirectToAction("HoaDonChiTiet", "BanHang", new { id = IdHoaDon, message });
                        //Hoadon.TongTien -= Voucher.SoTienGiamToiDa;
                        //Voucher.SoLuong -= 1;
                        //_GiamGiaService.Sua(Voucher);
                        //if (_HoaDonService.Sua(Hoadon) == false)
                        //{
                        //    var message = "Áp mã thất bại";
                        //    TempData["TB1"] = message;
                        //    return RedirectToAction("HoaDonChiTiet", "BanHang", new { id = IdHoaDon, message });
                        //}
                    }
                    else
                    {
                        if (Voucher.SoLuong <= 0)
                        {
                            var message = "Mã đã sử dụng hết";
                            TempData["TB1"] = message;
                            return RedirectToAction("HoaDonChiTiet", "BanHang", new { id = IdHoaDon, message });
                        }
                        else
                        {
                            if (Voucher.LoaiGiamGia == false)
                            {
                                Hoadon.TongTien = Hoadon.TongTien - Voucher.SoTienGiam;
                                //giatien.GiaHang = Hoadon.TongTien + Voucher.SoTienGiam;
                                Voucher.SoLuong -= 1;
                                _GiamGiaService.Sua(Voucher);
                                if (_HoaDonService.Sua(Hoadon) == false)
                                {
                                    var message = "Áp mã thất bại";
                                    TempData["TB1"] = message;
                                    return RedirectToAction("HoaDonChiTiet", "BanHang", new { id = IdHoaDon, message });
                                }
                            }
                            else
                            {
                                if (Hoadon.TongTien * (Voucher.PhanTramGiam) / 100 <= Voucher.SoTienGiamToiDa)
                                {
                                    Hoadon.TongTien -= Hoadon.TongTien * (Voucher.PhanTramGiam) / 100;
                                    Voucher.SoLuong -= 1;
                                    _GiamGiaService.Sua(Voucher);
                                    if (_HoaDonService.Sua(Hoadon) == false)
                                    {
                                        var message = "Áp mã thất bại";
                                        TempData["TB1"] = message;
                                        return RedirectToAction("HoaDonChiTiet", "BanHang", new { id = IdHoaDon, message });
                                    }
                                }
                                else if (Hoadon.TongTien * (Voucher.PhanTramGiam) / 100 > Voucher.SoTienGiamToiDa)
                                {
                                    Hoadon.TongTien -= Voucher.SoTienGiamToiDa;
                                    Voucher.SoLuong -= 1;
                                    _GiamGiaService.Sua(Voucher);
                                    if (_HoaDonService.Sua(Hoadon) == false)
                                    {
                                        var message = "Áp mã thất bại";
                                        TempData["TB1"] = message;
                                        return RedirectToAction("HoaDonChiTiet", "BanHang", new { id = IdHoaDon, message });
                                    }
                                }
                            }
                        }

                    }
                }


                var GiamGiaChiTiet = new GiamGiaChiTiet()
                {
                    IdGiamGia = Voucher.Id,
                    IdHoaDon = IdHoaDon,

                };
                _GiamGiaChiTietService.Them(GiamGiaChiTiet);

                var message2 = "Sử dụng voucher thành công";
                TempData["TB2"] = message2;
                return RedirectToAction("HoaDonChiTiet", "BanHang", new { id = IdHoaDon, message2 });
            }
            return View();

        }
    }
}
