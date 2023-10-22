using CTN4_Data.Models.DB_CTN4;
using CTN4_Serv.Service.IService;
using CTN4_Serv.Service;
using CTN4_Serv.ServiceJoin;
using CTN4_Serv.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace CTN4_View.Controllers.Shop
{
    public class BanHangController : Controller
    {
        private readonly SanPhamCuaHangService _sanPhamCuaHangService;
        public IGioHangService _GioHang;
        public IGioHangChiTietService _GioHangChiTiet;
        public GioHangjoiin _GioHangjoiin;
        public IHoaDonService _HoaDonService;
        public IHoaDonChiTietService _HoaDonChiTiet;
        public ISanPhamChiTietService _SanPhamChiTiet;


        public BanHangController()
        {
            _sanPhamCuaHangService = new SanPhamCuaHangService();
            _GioHang = new GioHangService();
            _GioHangChiTiet = new GioHangChiTietService();
            _GioHangjoiin = new GioHangjoiin();
            _HoaDonService = new HoaDonService();
            _HoaDonChiTiet = new HoaDonChiTietService();
            _SanPhamChiTiet = new SanPhamChiTietService();
        }

        [HttpGet]
        public IActionResult GioHang()
        {
            var a = _GioHangjoiin.GetAll();
            float tong = 0;
            foreach (var x in a)
            {
                tong += float.Parse(x.SanPhamChiTiet.GiaNiemYet.ToString()) * (x.SoLuong);

            }

            var view = new GioHangView()
            {
                GioHangChiTiets = a,
                TongTien = tong
            };
            return View(view);
        }

        public IActionResult XoaChiTietGioHang(Guid id)
        {
            var b = _GioHangChiTiet.GetById(id);
            var product = _sanPhamCuaHangService.GetById(b.IdSanPhamChiTiet.Value);
            if (_GioHangChiTiet.Xoa(id))
            {
                product.SoLuong += b.SoLuong;
                if (_SanPhamChiTiet.Sua(product))
                {
                    return RedirectToAction("GioHang");
                }

            }
            var message = "Xóa Thất Bại";
            TempData["ErrorMessage"] = message;
            return RedirectToAction("GioHang", "BanHang", new { message });

        }

        public IActionResult ThuTucThanhToan()
        {
            var a = _GioHangjoiin.GetAll();
            float tong = 0;
            foreach (var x in a)
            {
                tong += float.Parse(x.SanPhamChiTiet.GiaNiemYet.ToString()) * (x.SoLuong);

            }

            var view = new GioHangView()
            {
                GioHangChiTiets = a,
                TongTien = tong
            };
            return View(view);
        }

        public IActionResult HoanThanhThanhToan()
        {
            var a1 = new List<SanPhamChiTiet>();
            //Kiểm tra số lượng sản phẩm trong giỏ hàng với số lượng sản phẩm còn lại
            foreach (var CT in _GioHangjoiin.GetAll())
            {
                var sp = _sanPhamCuaHangService.GetById(CT.SanPhamChiTiet.Id);
                a1.Add(sp);
            }

            if (a1.Count > 0)
            {
                Guid idHoaDon = Guid.NewGuid();
                //Tạo hóa đơn mới
                int tong = 0;
                foreach (var inso in _GioHangChiTiet.GetAll())
                {
                    tong += Int32.Parse(inso.SoLuong.ToString()) *
                            Int32.Parse(inso.SanPhamChiTiet.GiaNiemYet.ToString());
                }

                var hd = new HoaDon()
                {
                    Id = idHoaDon,
                    NgayTaoHoaDon = DateTime.Now,
                    DiaChi = "",
                    TrangThai = "Đang xử lí",
                    TongTien = tong,
                    NgayDat = DateTime.Now,
                    IdDiaChiNhanHang = null,
                    IdKhachHang = Guid.Parse("d16ac357-3ced-4c2c-bcdc-d38971214499"),
                    IdPhuongThuc = Guid.Parse("d16ac357-3ced-4c2c-bcdc-d38971211111")

                };
                if (_HoaDonService.Them(hd) == false)
                {
                    var message = "thanh toán lỗi(1)";
                    TempData["ErrorMessage"] = message;
                    return RedirectToAction("ThuTucThanhToan", "BanHang", new { message });
                }


                //Thêm chi tiết hóa đơn cho từng sản phẩm trong giỏ hàng
                foreach (var ct in _GioHangChiTiet.GetAll())
                {
                    var cthd = new HoaDonChiTiet()
                    {
                        Id = Guid.NewGuid(),
                        IdHoaDon = idHoaDon, //Id của hóa đơn vừa tạo
                        IdSanPhamChiTiet = ct.IdSanPhamChiTiet,
                        SoLuong = ct.SoLuong,
                        GiaTien = ct.SanPhamChiTiet.GiaNiemYet,
                        TrangThai = true,
                        Is_detele = true,
                    };
                    if (_HoaDonChiTiet.Them(cthd) == false)
                    {
                        var message = "thanh toán lỗi(2)";
                        TempData["ErrorMessage"] = message;
                        return RedirectToAction("ThuTucThanhToan", "BanHang", new { message });
                    }

                    //Trừ số lượng sản phẩm trong CSDL
                    if (_GioHangChiTiet.Xoa(ct.Id) == false) //Xóa các bản ghi mà người dùng thêm vào trong giỏ hàng
                    {
                        var message = "thanh toán lỗi(3)";
                        TempData["ErrorMessage"] = message;
                        return RedirectToAction("ThuTucThanhToan", "BanHang", new { message });
                    }
                }
            }
            else
            {
                return RedirectToAction("ThuTucThanhToan");
            }
            return RedirectToAction("SauThanhToan");
        }

        public IActionResult HoaDon()
        {
            var a = _HoaDonService.GetAll();
            return View(a);
        }
        public IActionResult HoaDonChiTiet(Guid id)
        {
            var a = _HoaDonChiTiet.GetAll().Where(c=>c.IdHoaDon==id);
            return View(a);
        }
        public IActionResult SauThanhToan()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ThemVaoGio(int soluong, Guid idSP)
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
                _GioHang.Them(a);
            }
            {
                var SP = _GioHangChiTiet.GetAll().FirstOrDefault(c => c.IdSanPhamChiTiet == idSP);
                if (SP == null)
                {
                    var d = new GioHangChiTiet()
                    {
                        Id = Guid.NewGuid(),
                        IdSanPhamChiTiet = idSP,
                        IdGioHang = Guid.Parse("d16ac357-3ced-4c2c-bcdc-d38971214498"),
                        SoLuong = soluong,
                    };
                    if (_GioHangChiTiet.Them(d))
                    {
                        var product = _sanPhamCuaHangService.GetById(idSP);
                        product.SoLuong -= soluong;
                        if (_SanPhamChiTiet.Sua(product))
                        {
                            return RedirectToAction("GioHang");
                        }
                    }
                }
                else
                {
                    SP.SoLuong += soluong;
                    if (_GioHangChiTiet.Sua(SP))
                    {
                        var product = _sanPhamCuaHangService.GetById(idSP);
                        product.SoLuong -= soluong;
                        if (_SanPhamChiTiet.Sua(product))
                        {
                            return RedirectToAction("GioHang");
                        }
                    }
                }
            }

            var c = _sanPhamCuaHangService.GetById(idSP);

            return RedirectToAction("HienThiSanPhamChiTiet", "HienThiSanPham", c);
        }

    }
}
