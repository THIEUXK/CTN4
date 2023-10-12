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

        public BanHangController()
        {
            _sanPhamCuaHangService = new SanPhamCuaHangService();
            _GioHang = new GioHangService();
            _GioHangChiTiet = new GioHangChiTietService();
            _GioHangjoiin = new GioHangjoiin();
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
                if (_GioHang.Them(a))
                {
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
                                return RedirectToAction("GioHang");
                            }
                        }
                    }

                }
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
                        return RedirectToAction("GioHang");
                    }
                }
                else
                {
                    SP.SoLuong += soluong;
                    if (_GioHangChiTiet.Sua(SP))
                    {
                        return RedirectToAction("GioHang");
                    }
                }
            }

            var c = _sanPhamCuaHangService.GetById(idSP);

            return RedirectToAction("HienThiSanPhamChiTiet","HienThiSanPham", c);
        }

    }
}
