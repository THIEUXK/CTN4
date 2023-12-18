using CTN4_Data.Models.DB_CTN4;
using CTN4_Serv.Service.IService;
using CTN4_Serv.Service;
using CTN4_Serv.ServiceJoin;
using CTN4_Serv.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Net.Http;
using CTN4_Serv.ViewModel.banhangview;
using System.Text;
using CTN4_View.Areas.Admin.Viewmodel;
using CTN4_Serv.Service.Service;
using Microsoft.AspNetCore.Authorization;
using System.Text.RegularExpressions;
using CTN4_View.Controllers.Shop.ViewModelThieuxk;
using CTN4_View_Admin.Controllers.Shop;
using DocumentFormat.OpenXml.Spreadsheet;
using DocumentFormat.OpenXml.Wordprocessing;
using DocumentFormat.OpenXml.Office2010.Excel;
using System.Linq;

namespace CTN4_View.Controllers.Shop
{
    public class BanHangController : Controller
    {
        #region Ctro
        private readonly HttpClient _httpClient;

        private readonly SanPhamCuaHangService _sanPhamCuaHangService;
        public IGioHangService _GioHang;
        public IGioHangChiTietService _GioHangChiTiet;
        public GioHangjoiin _GioHangjoiin;
        public IHoaDonService _HoaDonService;
        public IHoaDonChiTietService _HoaDonChiTiet;
        public ISanPhamChiTietService _SanPhamChiTiet;
        public ISanPhamService _sanPhamService;
        public IAnhService _anhService;
        public IPhuongThucThanhToanService _phuongThucThanhToanService;
        public IDiaChiNhanHangService _diaChiNhanHangService;
        public IKhachHangService _khachHangService;
        public IGiamGiaService _giamGiaService;
        public IGiamGiaChiTietService _giamGiaChiTietService;
        public readonly string _clientId;
        public readonly string _Secretkey;
        public readonly IVnPayService _ivnPayService;
        public readonly ICurrentUser _CurrentUser;
        public ILichSuHoaDonService _LichSuHoaDonService;
        public IKhuyenMaiSanPhamService _khuyenMaiSanPhamService;
        public IKhuyenMaiService _khuyenMaiService;
        public BanHangController(IConfiguration config, IVnPayService vnpay, ICurrentUser currentUser, IGioHangService giohang)
        {
            _diaChiNhanHangService = new DiaChiNhanHangService();
            _sanPhamCuaHangService = new SanPhamCuaHangService();
            _GioHang = giohang;
            _GioHangChiTiet = new GioHangChiTietService();
            _GioHangjoiin = new GioHangjoiin();
            _HoaDonService = new HoaDonService();
            _HoaDonChiTiet = new HoaDonChiTietService();
            _SanPhamChiTiet = new SanPhamChiTietService();
            _httpClient = new HttpClient();
            _sanPhamService = new SanPhamService();
            _anhService = new AnhService();
            _khachHangService = new KhachHangService();
            _phuongThucThanhToanService = new PhuongThucThanhToanService();
            _giamGiaChiTietService = new GiamGiaChiTietService();
            _giamGiaService = new GiamGiaService();
            _httpClient.DefaultRequestHeaders.Add("token", "fa31ddca-73b0-11ee-b394-8ac29577e80e");
            _httpClient.DefaultRequestHeaders.Add("shop_id", "4189141");
            _ivnPayService = vnpay;
            _clientId = config["PaypalSettings:ClientId"];
            _Secretkey = config["PaypalSettings:SecretKey"];
            _CurrentUser = currentUser;
            _LichSuHoaDonService = new LichSuHoaDonService();
            _khuyenMaiSanPhamService = new KhuyenMaiSanPhamService();
            _khuyenMaiService = new KhuyenMaiService();
        }
        #endregion

        #region Gio Hang
        [HttpGet]
        public IActionResult GioHang()
        {
            var KhuyenMaiSp = _khuyenMaiSanPhamService.GetAll().Where(c => c.KhuyenMai.Mua1tang1 == true).ToList();
            var a = new List<Guid>();

            foreach (var item in KhuyenMaiSp)
            {
                a.Add((Guid)item.IdSanPham);
            }
            var listSp11 = _sanPhamService.GetAll().Where(c => a.Contains(c.Id)).ToList();

            var accnew = SessionServices.KhachHangSS(HttpContext.Session, "ACC");
            float tong = 0;
            if (accnew.Count != 0)
            {
                var gh = _GioHang.GetAll().FirstOrDefault(c => c.IdKhachHang == accnew[0].Id);
                IEnumerable<GioHangChiTiet> ghct = _GioHangjoiin.GetAll().Where(c => c.IdGioHang == gh.Id);
                foreach (var x in ghct)
                {
                    tong += float.Parse(x.SanPhamChiTiet.SanPham.GiaNiemYet.ToString()) * (x.SoLuong);
                }
                var anh = _anhService.GetAll().ToList();
                var view2 = new GioHangView()
                {
                    GioHangChiTiets = ghct,
                    TongTien = tong,
                    anhs = anh,
                    sanPham11 = listSp11,
                };
                return View(view2);
            }
            else
            {
                return RedirectToAction("login", "Home");
            }

        }
        public IActionResult ThemVaoGio(int soluong, Guid IdSanPham, Guid IdSize, Guid IdMau)
        {
            var accnew = SessionServices.KhachHangSS(HttpContext.Session, "ACC");
            if (accnew.Count != 0)
            {
                #region check dieu kien

                var checksp = _SanPhamChiTiet.GetAll().FirstOrDefault(c => c.IdSp == IdSanPham && c.IdSize == IdSize && c.IdMau == IdMau);

                var KhuyenMaiSp = _khuyenMaiSanPhamService.GetAll().Where(c => c.KhuyenMai.Mua1tang1 == true).ToList();
                var g = new List<Guid>();
                foreach (var item in KhuyenMaiSp)
                {
                    // Kiểm tra xem Mau.Id đã xuất hiện trong danh sách chưa
                    if (!g.Contains((Guid)item.IdSanPham))
                    {
                        g.Add((Guid)item.IdSanPham);
                    }
                }
                if (g.Contains(checksp.SanPham.Id))
                {
                    if (soluong * 2 > checksp.SoLuong)
                    {
                        var message2 = "Số lượng không đủ vì đây là sản phẩm mua 1 tặng 1 !";
                        TempData["TB2"] = message2;
                        return RedirectToAction("HienThiSanPhamChiTiet", "HienThiSanPham", new { id = IdSanPham, message2 });
                    }

                }
                if (soluong > checksp.SoLuong)
                {
                    var message2 = "Số lượng không đủ !";
                    TempData["TB2"] = message2;
                    return RedirectToAction("HienThiSanPhamChiTiet", "HienThiSanPham", new { id = IdSanPham, message2 });
                }
                if (IdMau == Guid.Parse("00000000-0000-0000-0000-000000000000") || IdSize == Guid.Parse("00000000-0000-0000-0000-000000000000"))
                {
                    var message1 = "hãy chọn màu và size của bạn !";
                    TempData["TB1"] = message1;
                    return RedirectToAction("HienThiSanPhamChiTiet", "HienThiSanPham", new { id = IdSanPham, message1 });
                }
                if (soluong <= 0)
                {
                    var message2 = "Số lượng phải lớn hơn 0 !";
                    TempData["TB2"] = message2;
                    return RedirectToAction("HienThiSanPhamChiTiet", "HienThiSanPham", new { id = IdSanPham, message2 });
                }
                #endregion
                var tkmoi = accnew[0];
                if (tkmoi != null)
                {

                    var sanphamCT = _SanPhamChiTiet.GetAll().FirstOrDefault(c => c.IdSp == IdSanPham && c.IdSize == IdSize && c.IdMau == IdMau);
                    var gioHang = _GioHang.GetAll();
                    if (gioHang.Where(c => c.IdKhachHang == tkmoi.Id).ToList().Count == 0)
                    {
                        var a = new GioHang()
                        {
                            Id = Guid.NewGuid(),
                            IdKhachHang = tkmoi.Id,
                            TrangThai = true
                        };
                        _GioHang.Them(a);
                    }
                    {
                        var SP = _GioHangChiTiet.GetAll().FirstOrDefault(c => c.IdSanPhamChiTiet == sanphamCT.Id);
                        if (SP == null)
                        {
                            var d = new GioHangChiTiet()
                            {
                                Id = Guid.NewGuid(),
                                IdSanPhamChiTiet = sanphamCT.Id,
                                IdGioHang = _GioHang.GetAll().FirstOrDefault(c => c.IdKhachHang == tkmoi.Id).Id,
                                SoLuong = soluong,
                            };
                            if (_GioHangChiTiet.Them(d))
                            {
                                var product = _SanPhamChiTiet.GetById(sanphamCT.Id);
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
                                var product = _SanPhamChiTiet.GetById(sanphamCT.Id);
                                product.SoLuong -= soluong;
                                if (_SanPhamChiTiet.Sua(product))
                                {
                                    return RedirectToAction("GioHang");
                                }
                            }
                        }
                    }
                    var message3 = "Thêm thất bại !";
                    TempData["TB1"] = message3;
                    return RedirectToAction("HienThiSanPhamChiTiet", "HienThiSanPham", new { id = IdSanPham, message3 });


                }
            }
            else
            {
                return RedirectToAction("login", "Home");
            }

            var message4 = "Thêm thất bại !";
            TempData["TB1"] = message4;
            return RedirectToAction("HienThiSanPhamChiTiet", "HienThiSanPham", new { id = IdSanPham, message4 });
        }
        public IActionResult XoaChiTietGioHang(Guid id)
        {
            var b = _GioHangChiTiet.GetById(id);
            var product = _SanPhamChiTiet.GetById(b.IdSanPhamChiTiet.Value);
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
        #endregion

        #region Ban Hang
        public IActionResult PaymentCallback()
        {
            var response = _ivnPayService.PaymentExecute(Request.Query);
            response.IdUser = _CurrentUser.Id;
            if (response.PaymentId == "0")
            {
                var message = "Thanh toám thất bại";
                TempData["TB2"] = message;
                return RedirectToAction("ThuTucThanhToan", "BanHang", new { message });
            }
            var LuuTam = SessionBan.ThongTinTamSS(HttpContext.Session, "ACD");
            if (LuuTam.Count != 1)
            {
                var message = "Thanh toám thất bại";
                TempData["TB2"] = message;
                return RedirectToAction("ThuTucThanhToan", "BanHang", new { message });
            }
            int idHoaDon;
            var hh = _HoaDonService.GetAll().ToList();
            if (hh.Count == 0)
            {
                idHoaDon = 1;
            }
            else
            {
                idHoaDon = hh.Max(c => c.Id) + 1;
            }

            var accnew = SessionServices.KhachHangSS(HttpContext.Session, "ACC");
            var gh = _GioHang.GetAll().FirstOrDefault(c => c.IdKhachHang == accnew[0].Id);
            if (accnew.Count != 0 && gh != null)
            {

                var hd = new HoaDon()
                {
                    MaHoaDon = $"HD0{idHoaDon}",
                    DiaChi = LuuTam[0].DiachiNhanChiTiet + " " + LuuTam[0].addDiaChi,
                    TrangThai = "Đang chờ xử lí",
                    TongTien = LuuTam[0].tongtien,
                    TienShip = LuuTam[0].tienship,
                    NgayDat = DateTime.Now,
                    TrangThaiThanhToan = true,
                    Email = LuuTam[0].Email,
                    GhiChu = LuuTam[0].ghiChu,
                    IdKhachHang = accnew[0].Id,
                    IdPhuongThuc = LuuTam[0].idphuongthuc,
                    SDTNguoiNhan = LuuTam[0].Sodienthoai,
                    TenKhachHang = LuuTam[0].name,
                    Is_detele = true,
                };
                if (LuuTam[0].IdDiaChi != Guid.Parse("00000000-0000-0000-0000-000000000000"))
                {
                    hd.IdDiaChiNhanHang = LuuTam[0].IdDiaChi;
                }
                if (_HoaDonService.Them(hd) == false)
                {
                    var message = "thanh toán lỗi(1)";
                    TempData["ErrorMessage"] = message;
                    return RedirectToAction("ThuTucThanhToan", "BanHang", new { message });
                }
                var giamgianew = SessionBan.GiamGiaSS(HttpContext.Session, "GiamGia");
                if (giamgianew.Count != 0)
                {
                    var giamct = new GiamGiaChiTiet()
                    {
                        IdHoaDon = hd.Id,
                        IdGiamGia = giamgianew[0].Id
                    };
                    var a = _giamGiaService.GetById(giamgianew[0].Id);
                    a.SoLuong -= 1;
                    if (_giamGiaChiTietService.Them(giamct) == false || _giamGiaService.Sua(a))
                    {
                        var message = "lỗi mã giảm giá";
                        TempData["ErrorMessage"] = message;
                        return RedirectToAction("ThuTucThanhToan", "BanHang", new { message });
                    }
                }
                //Thêm chi tiết hóa đơn cho từng sản phẩm trong giỏ hàng
                foreach (var ct in _GioHangChiTiet.GetAll().Where(c => c.IdGioHang == gh.Id))
                {
                    var cthd = new HoaDonChiTiet()
                    {
                        Id = Guid.NewGuid(),
                        IdHoaDon = hd.Id, //Id của hóa đơn vừa tạo
                        IdSanPhamChiTiet = ct.IdSanPhamChiTiet,
                        SoLuong = ct.SoLuong,
                        GiaTien = ct.SanPhamChiTiet.SanPham.GiaNiemYet,
                        TrangThai = true,
                        Is_detele = true,
                    };
                    var KhuyenMaiSp = _khuyenMaiSanPhamService.GetAll().Where(c => c.KhuyenMai.Mua1tang1 == true).ToList();
                    var g = new List<Guid>();
                    foreach (var item in KhuyenMaiSp)
                    {
                        // Kiểm tra xem Mau.Id đã xuất hiện trong danh sách chưa
                        if (!g.Contains((Guid)item.IdSanPham))
                        {
                            g.Add((Guid)item.IdSanPham);
                        }
                    }
                    if (g.Contains(ct.SanPhamChiTiet.SanPham.Id))
                    {
                        cthd.SoLuong *= 2;
                    }
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
                    var lisdiachi1 = _diaChiNhanHangService.GetAll().Where(c => c.IdKhachHang == accnew[0].Id).ToList();
                    var lisdiachi = _diaChiNhanHangService.GetAll().Where(c => c.DiaChi == LuuTam[0].addDiaChi && c.IdKhachHang == accnew[0].Id && c.TienShip == LuuTam[0].tienship).ToList();
                    if (lisdiachi1.Count() < 4 && lisdiachi.Count == 0)
                    {
                        var diachi = new DiaChiNhanHang()
                        {
                            IdKhachHang = accnew[0].Id,
                            name = LuuTam[0].addDiaChi,
                            DiaChi = LuuTam[0].addDiaChi,
                            TienShip = LuuTam[0].tienship,
                        };
                        _diaChiNhanHangService.Them(diachi);
                    }
                }
            }


            else
            {
                return RedirectToAction("login", "Home");

            }

            return RedirectToAction("SauThanhToan", new { id = idHoaDon });
        }
        //Huyen
        [HttpGet("CheckOut/GetListDistrict")]
        public JsonResult GetListDistrict(int idProvin)
        {

            HttpResponseMessage responseDistrict = _httpClient.GetAsync("https://online-gateway.ghn.vn/shiip/public-api/master-data/district?province_id=" + idProvin).Result;

            District lstDistrict = new District();

            if (responseDistrict.IsSuccessStatusCode)
            {
                string jsonData2 = responseDistrict.Content.ReadAsStringAsync().Result;

                lstDistrict = JsonConvert.DeserializeObject<District>(jsonData2);
            }
            return Json(lstDistrict, new System.Text.Json.JsonSerializerOptions());
        }
        //Lấy địa chỉ phường xã
        [HttpGet("/CheckOut/GetListWard")]
        public JsonResult GetListWard(int idWard)
        {


            HttpResponseMessage responseWard = _httpClient.GetAsync("https://online-gateway.ghn.vn/shiip/public-api/master-data/ward?district_id=" + idWard).Result;

            Ward lstWard = new Ward();

            if (responseWard.IsSuccessStatusCode)
            {
                string jsonData2 = responseWard.Content.ReadAsStringAsync().Result;

                lstWard = JsonConvert.DeserializeObject<Ward>(jsonData2);
            }
            return Json(lstWard, new System.Text.Json.JsonSerializerOptions());
        }
        [HttpPost]
        [HttpPost("/CheckOut/GetTotalShipping")]
        public async Task<JsonResult> GetTotalShipping([FromBody] ShippingOrder shippingOrder)
        {

            var hang = new TinhTienShip()
            {
                service_id = shippingOrder.service_id,
                insurance_value = shippingOrder.insurance_value,
                from_district_id = shippingOrder.from_district_id,
                to_district_id = shippingOrder.to_district_id,
                to_ward_code = shippingOrder.to_ward_code.ToString(),
                height = shippingOrder.height,
                length = shippingOrder.length,
                weight = shippingOrder.weight,
                width = shippingOrder.width,
            };
            var url = $"https://online-gateway.ghn.vn/shiip/public-api/v2/shipping-order/fee";
            float tong = 0;
            var content = new StringContent(JsonConvert.SerializeObject(hang), Encoding.UTF8, "application/json");
            var respose = await _httpClient.PostAsync(url, content);
            Shipping shipping = new Shipping();
            if (respose.IsSuccessStatusCode)
            {
                string jsonData2 = respose.Content.ReadAsStringAsync().Result;

                shipping = JsonConvert.DeserializeObject<Shipping>(jsonData2);
                HttpContext.Session.SetInt32("shiptotal", shipping.data.total);
                shipping.data.totaloder = shippingOrder.tienhang + shipping.data.total - shippingOrder.tiengiam;
                shipping.tienGiam = shippingOrder.tiengiam;

                //shipping.data.totaloder = shipping.data.total + int.Parse(tong.ToString());
                return Json(shipping, new System.Text.Json.JsonSerializerOptions());
            }
            else
            {
                shipping.message = "False";

                //shipping.data.totaloder = shipping.data.total + int.Parse(tong.ToString());
                return Json(shipping, new System.Text.Json.JsonSerializerOptions());
            }

        }
        public IActionResult HoanThanhThanhToan(string tenmagiam, float tiengiama, float tienhanga, string name, string DiachiNhanChiTiet, string Sodienthoai, string Email, string addDiaChi, Guid IdDiaChi, Guid idphuongthuc, string ghiChu, float tienshipa, float tongtien)
        {
            #region Check validate
            if (name == null)
            {
                {
                    var message = "hãy nhớ điền tên của bạn của bạn";
                    TempData["TB2"] = message;
                    return RedirectToAction("ThuTucThanhToan", "BanHang", new { message });
                }
            }
            if (DiachiNhanChiTiet == null)
            {
                {
                    var message = "hãy nhớ điền địa chỉ chi tiết của bạn";
                    TempData["TB2"] = message;
                    return RedirectToAction("ThuTucThanhToan", "BanHang", new { message });
                }
            }
            if (Sodienthoai == null)
            {
                {
                    var message = "hãy nhớ điền số điện thoại của bạn";
                    TempData["TB2"] = message;
                    return RedirectToAction("ThuTucThanhToan", "BanHang", new { message });
                }
            }
            if (Sodienthoai == null)
            {
                {
                    var message = "hãy nhớ điền Email của bạn";
                    TempData["TB2"] = message;
                    return RedirectToAction("ThuTucThanhToan", "BanHang", new { message });
                }
            }
            if (addDiaChi == null)
            {
                {
                    var message = "hãy nhớ chọn địa chỉ của bạn";
                    TempData["TB2"] = message;
                    return RedirectToAction("ThuTucThanhToan", "BanHang", new { message });
                }
            }
            if (idphuongthuc == Guid.Parse("00000000-0000-0000-0000-000000000000"))
            {
                {
                    var message = "hãy nhớ chọn phương thức thanh toán của bạn";
                    TempData["TB1"] = message;
                    return RedirectToAction("ThuTucThanhToan", "BanHang", new { message });
                }
            }
            #endregion
            #region ma tu sinh
            int idHoaDon;
            var hh = _HoaDonService.GetAll().ToList();
            if (hh.Count == 0)
            {
                idHoaDon = 1;
            }
            else
            {
                idHoaDon = hh.Max(c => c.Id) + 1;
            }
            #endregion
            var accnew = SessionServices.KhachHangSS(HttpContext.Session, "ACC");
            var gh = _GioHang.GetAll().FirstOrDefault(c => c.IdKhachHang == accnew[0].Id);
            if (accnew.Count != 0 && gh != null)
            {
                #region tao hoa don
                if (idphuongthuc == Guid.Parse("d16ac357-3ced-4c2c-bcdc-d38971211114"))
                {
                    var alTam = new ThongTinTam()
                    {
                        name = name,
                        DiachiNhanChiTiet = DiachiNhanChiTiet,
                        Sodienthoai = Sodienthoai,
                        Email = Email,
                        addDiaChi = addDiaChi,
                        IdDiaChi = IdDiaChi,
                        idphuongthuc = idphuongthuc,
                        ghiChu = ghiChu,
                        tienship = tienshipa,
                        tongtien = tongtien,
                        TienHang = tienhanga,
                        TienGiam = tiengiama,
                    };
                    var LuuTam = SessionBan.ThongTinTamSS(HttpContext.Session, "ACD");
                    if (LuuTam.Count == 0)
                    {
                        LuuTam.Add(alTam);
                        SessionBan.SetObjToJson(HttpContext.Session, "ACD", LuuTam);
                    }
                    else if (LuuTam.Count != 0)
                    {
                        LuuTam.Clear();
                        LuuTam.Add(alTam);
                        SessionBan.SetObjToJson(HttpContext.Session, "ACD", LuuTam);
                    }
                    var model = new PaymentInformationModel()
                    {
                        OrderType = "túi sách",
                        Amount = tongtien,
                        OrderDescription = "Mua Tại Shop Boro",
                        Name = name,
                    };
                    var url = _ivnPayService.CreatePaymentUrl(model, HttpContext);
                    return Redirect(url);
                }
                else
                {
                    var hd = new HoaDon()
                    {
                        MaHoaDon = $"HD0{idHoaDon}",
                        DiaChi = DiachiNhanChiTiet + " " + addDiaChi,
                        TrangThai = "Đang chờ xử lí",
                        TongTien = tongtien,
                        TienShip = tienshipa,
                        TienGiam = tiengiama,
                        TienHang = tienhanga,
                        NgayDat = DateTime.Now,
                        TrangThaiThanhToan = false,
                        Email = Email,
                        GhiChu = ghiChu,
                        IdKhachHang = accnew[0].Id,
                        IdPhuongThuc = idphuongthuc,
                        SDTNguoiNhan = Sodienthoai,
                        TenKhachHang = name,
                        Is_detele = true,
                    };
                    if (IdDiaChi != Guid.Parse("00000000-0000-0000-0000-000000000000"))
                    {
                        hd.IdDiaChiNhanHang = IdDiaChi;
                    }
                    if (_HoaDonService.Them(hd) == false)
                    {
                        var message = "thanh toán lỗi(1)";
                        TempData["ErrorMessage"] = message;
                        return RedirectToAction("ThuTucThanhToan", "BanHang", new { message });
                    }
                    var giamgianew = SessionBan.GiamGiaSS(HttpContext.Session, "GiamGia");
                    if (tiengiama != 0)
                    {
                        var giamct = new GiamGiaChiTiet()
                        {
                            IdHoaDon = hd.Id,
                            IdGiamGia = giamgianew[0].Id
                        };
                        var a = _giamGiaService.GetById(giamgianew[0].Id);
                        a.SoLuong -= 1;
                        if (_giamGiaChiTietService.Them(giamct) == false || _giamGiaService.Sua(a) == false)
                        {
                            var message = "lỗi mã giảm giá";
                            TempData["ErrorMessage"] = message;
                            return RedirectToAction("ThuTucThanhToan", "BanHang", new { message });
                        }
                    }
                    //Thêm chi tiết hóa đơn cho từng sản phẩm trong giỏ hàng
                    foreach (var ct in _GioHangChiTiet.GetAll().Where(c => c.IdGioHang == gh.Id))
                    {
                        var cthd = new HoaDonChiTiet()
                        {
                            Id = Guid.NewGuid(),
                            IdHoaDon = hd.Id, //Id của hóa đơn vừa tạo
                            IdSanPhamChiTiet = ct.IdSanPhamChiTiet,
                            SoLuong = ct.SoLuong,
                            GiaTien = ct.SanPhamChiTiet.SanPham.GiaNiemYet,
                            TrangThai = true,
                            Is_detele = true,
                        };
                        var KhuyenMaiSp = _khuyenMaiSanPhamService.GetAll().Where(c => c.KhuyenMai.Mua1tang1 == true).ToList();
                        var g = new List<Guid>();
                        foreach (var item in KhuyenMaiSp)
                        {
                            // Kiểm tra xem Mau.Id đã xuất hiện trong danh sách chưa
                            if (!g.Contains((Guid)item.IdSanPham))
                            {
                                g.Add((Guid)item.IdSanPham);
                            }
                        }
                        if (g.Contains(ct.SanPhamChiTiet.SanPham.Id))
                        {
                         cthd.SoLuong *= 2;
                        }
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
                        var lisdiachi1 = _diaChiNhanHangService.GetAll().Where(c => c.IdKhachHang == accnew[0].Id && c.Is_detele == true).ToList();
                        var lisdiachi = _diaChiNhanHangService.GetAll().Where(c => c.DiaChi == addDiaChi && c.IdKhachHang == accnew[0].Id && c.TienShip == tienshipa && c.Is_detele == true).ToList();
                        if (lisdiachi1.Count() < 4 && lisdiachi.Count == 0)
                        {
                            var diachi = new DiaChiNhanHang()
                            {
                                IdKhachHang = accnew[0].Id,
                                name = DiachiNhanChiTiet,
                                DiaChi = addDiaChi,
                                TienShip = tienshipa,
                                Is_detele = true,
                                TrangThai = false
                            };
                            _diaChiNhanHangService.Them(diachi);
                        }
                    }
                }
                #endregion
            }
            else
            {
                return RedirectToAction("login", "Home");

            }

            return RedirectToAction("SauThanhToan", new { id = idHoaDon });
        }
        public IActionResult ThuTucThanhToan()
        {
            var giamgianew = SessionBan.GiamGiaSS(HttpContext.Session, "GiamGia");
            giamgianew.Clear();
            HttpResponseMessage responseProvin = _httpClient.GetAsync("https://online-gateway.ghn.vn/shiip/public-api/master-data/province").Result;

            Provin lstprovin = new Provin();

            if (responseProvin.IsSuccessStatusCode)
            {
                string jsonData2 = responseProvin.Content.ReadAsStringAsync().Result;
                lstprovin = JsonConvert.DeserializeObject<Provin>(jsonData2);
                ViewBag.Provin = new SelectList(lstprovin.data, "ProvinceID", "ProvinceName");
            }
            float tong = 0;
            var accnew = SessionServices.KhachHangSS(HttpContext.Session, "ACC");
            if (accnew.Count != 0)
            {
                var gh = _GioHang.GetAll().FirstOrDefault(c => c.IdKhachHang == accnew[0].Id);
                IEnumerable<GioHangChiTiet> ghct = _GioHangjoiin.GetAll().Where(c => c.IdGioHang == gh.Id);
                if (ghct.Count() == 0)
                {
                    var message = "Giỏ hàng đang trống hãy thêm sản phẩm của bạn để tiến hàng đặt hàng";
                    TempData["TB4"] = message;
                    return RedirectToAction("GioHang", new { message });
                }

                foreach (var x in ghct)
                {
                    tong += float.Parse(x.SanPhamChiTiet.SanPham.GiaNiemYet.ToString()) * (x.SoLuong);

                }
                var a = _GioHangjoiin.GetAll().Where(c => c.IdGioHang == gh.Id);
                var nguoidung = _khachHangService.GetAll().FirstOrDefault(c => c.Id == accnew[0].Id);
                var diachinhanhang = _diaChiNhanHangService.GetAll().Where(c => c.IdKhachHang == accnew[0].Id).FirstOrDefault(c => c.TrangThai == true && c.Is_detele == true);
                var giamgia = _giamGiaService.GetAll().Where(c => c.TrangThai == true && c.Is_detele == true && c.NgayBatDau <= DateTime.Now && c.NgayKetThuc >= DateTime.Now).ToList();
                var KhuyenMaiSp = _khuyenMaiSanPhamService.GetAll().Where(c => c.KhuyenMai.Mua1tang1 == true).ToList();
                var g = new List<Guid>();
                foreach (var item in KhuyenMaiSp)
                {
                    // Kiểm tra xem Mau.Id đã xuất hiện trong danh sách chưa
                    if (!g.Contains((Guid)item.IdSanPham))
                    {
                        g.Add((Guid)item.IdSanPham);
                    }
                }
                var view2 = new GioHangView()
                {
                    check11 = g,
                    GiamGias = giamgia,
                    DiaChiNhanHang = diachinhanhang,
                    KhachHang = nguoidung,
                    GioHangChiTiets = a,
                    TongTien = tong,
                    listDiaChi = _diaChiNhanHangService.GetAll().Where(c => c.IdKhachHang == accnew[0].Id && c.Is_detele == true).Select(s => new SelectListItem
                    {
                        Value = s.Id.ToString(),
                        Text = s.DiaChi
                    }).ToList(),
                    listPhuongThucs = _phuongThucThanhToanService.GetAll().Select(s => new SelectListItem
                    {
                        Value = s.Id.ToString(),
                        Text = s.TenPhuongThuc
                    }).ToList(),

                };

                return View(view2);
            }
            else
            {
                return RedirectToAction("login", "Home");

            }
        }
        [HttpGet("/CheckOut/chonDiaChi")]
        public async Task<JsonResult> chonDiaChi(Guid idDiaChiKD, float tienhang, float tiengiam, float tongtien)
        {
            float tong = 0;
            var accnew = SessionServices.KhachHangSS(HttpContext.Session, "ACC");
            if (accnew.Count != 0)
            {
                var gh = _GioHang.GetAll().FirstOrDefault(c => c.IdKhachHang == accnew[0].Id);
                IEnumerable<GioHangChiTiet> ghct = _GioHangjoiin.GetAll().Where(c => c.IdGioHang == gh.Id);
                var diaChi = _diaChiNhanHangService.GetAll().FirstOrDefault(c => c.Id == idDiaChiKD);
                foreach (var x in ghct)
                {
                    tong += float.Parse(x.SanPhamChiTiet.SanPham.GiaNiemYet.ToString()) * (x.SoLuong);
                }
                Shipping shipping = new Shipping()
                {
                    totaloder = tienhang + diaChi.TienShip.Value - tiengiam,
                    TienShip = diaChi.TienShip.Value,
                    tienGiam = tiengiam,
                    DiaChichiTiet = diaChi.name,
                };
                //shipping.data.totaloder = shipping.data.total + int.Parse(tong.ToString());
                return Json(shipping, new System.Text.Json.JsonSerializerOptions());
            }
            return Json(0, new System.Text.Json.JsonSerializerOptions());
        }
        public IActionResult SauThanhToan(int id)
        {
            var b = _HoaDonService.GetById(id);
            var a = _HoaDonChiTiet.GetAll().Where(c => c.IdHoaDon == id).ToList();
            var c = _giamGiaChiTietService.GetAll().Where(c => c.IdHoaDon == id).ToList();
            var view = new ThieuxkView()
            {
                HoaDon = b,
                hoaDonChiTiets = a,
                GiamGiaChiTiets = c
            };
            return View(view);
        }

        public IActionResult SuDunggiamGia(Guid IdGiamGia, float tienhanga, string DiachiNhanChiTiet, string name, string Sodienthoai, string Email, string addDiaChi, Guid IdDiaChi, Guid idphuongthuc, string ghiChu, float tienshipa, float tongtien)
        {
            HttpResponseMessage responseProvin = _httpClient.GetAsync("https://online-gateway.ghn.vn/shiip/public-api/master-data/province").Result;
            Provin lstprovin = new Provin();
            if (responseProvin.IsSuccessStatusCode)
            {
                string jsonData2 = responseProvin.Content.ReadAsStringAsync().Result;
                lstprovin = JsonConvert.DeserializeObject<Provin>(jsonData2);
                ViewBag.Provin = new SelectList(lstprovin.data, "ProvinceID", "ProvinceName");
            }
            float tong = 0;
            var accnew = SessionServices.KhachHangSS(HttpContext.Session, "ACC");
            if (accnew.Count != 0 && addDiaChi != null)
            {
                float tiensaugiam;
                var giamgia1 = _giamGiaService.GetById(IdGiamGia);
                if (giamgia1 == null || giamgia1.NgayBatDau > DateTime.Now || giamgia1.NgayKetThuc < DateTime.Now)
                {
                    var message = $"Giảm giá {giamgia1.MaGiam} hiện không thể sửa dụng";
                    TempData["TB2"] = message;
                    return RedirectToAction("ThuTucThanhToan", "BanHang", new { message });
                }
                if (giamgia1.SoLuong < 1)
                {
                    var message = $"Giảm giá {giamgia1.MaGiam} hiện đã hết";
                    TempData["TB2"] = message;
                    return RedirectToAction("ThuTucThanhToan", "BanHang", new { message });
                }
                if (giamgia1.LoaiGiamGia == false)
                {
                    if (giamgia1.DieuKienGiam < tienhanga)
                    {
                        tiensaugiam = tienhanga - giamgia1.SoTienGiam;
                    }
                    else
                    {
                        {
                            var message = "Tiền đơn hàng chưa đủ điều kiện để sử dụng mã giảm giá này";
                            TempData["TB2"] = message;
                            return RedirectToAction("ThuTucThanhToan", "BanHang", new { message });
                        }
                    }
                }
                else
                {
                    if (giamgia1.DieuKienGiam < tienhanga)
                    {
                        var tientru = (tienhanga * giamgia1.PhanTramGiam / 100);
                        if (tientru >= giamgia1.SoTienGiamToiDa)
                        {
                            tientru = giamgia1.SoTienGiamToiDa;
                        }
                        tiensaugiam = tienhanga - tientru;
                    }
                    else
                    {
                        {
                            var message = "Tiền đơn hàng chưa đủ điều kiện để sử dụng mã giảm giá này";
                            TempData["TB2"] = message;
                            return RedirectToAction("ThuTucThanhToan", "BanHang", new { message });
                        }
                    }
                }

                var gg = _giamGiaService.GetById(IdGiamGia);
                // Đọc dữ liệu từ Session xem trong Cart nó có cái gì chưa?
                var giamgianew = SessionBan.GiamGiaSS(HttpContext.Session, "GiamGia");
                if (giamgianew.Count == 0)
                {
                    giamgianew.Add(gg);
                    SessionBan.SetObjToJson(HttpContext.Session, "GiamGia", giamgianew);
                }
                else if (giamgianew.Count != 0)
                {
                    giamgianew.Clear();
                    giamgianew.Add(gg);
                    SessionBan.SetObjToJson(HttpContext.Session, "GiamGia", giamgianew);
                }
                float tiengiam = (tienhanga + tienshipa) - (tiensaugiam + tienshipa);
                var gh = _GioHang.GetAll().FirstOrDefault(c => c.IdKhachHang == accnew[0].Id);
                IEnumerable<GioHangChiTiet> ghct = _GioHangjoiin.GetAll().Where(c => c.IdGioHang == gh.Id);
                if (ghct.Count() == 0)
                {
                    var message = "Giỏ hàng đang trống hãy thêm sản phẩm của bạn để tiến hàng đặt hàng";
                    TempData["TB4"] = message;
                    return RedirectToAction("GioHang", new { message });
                }
                foreach (var x in ghct)
                {
                    tong += float.Parse(x.SanPhamChiTiet.SanPham.GiaNiemYet.ToString()) * (x.SoLuong);
                }
                var a = _GioHangjoiin.GetAll().Where(c => c.IdGioHang == gh.Id);
                var nguoidung = _khachHangService.GetAll().FirstOrDefault(c => c.Id == accnew[0].Id);
                var diachinhanhang = _diaChiNhanHangService.GetAll().Where(c => c.IdKhachHang == accnew[0].Id).FirstOrDefault(c => c.TrangThai == true && c.Is_detele == true);
                var giamgia = _giamGiaService.GetAll().Where(c => c.TrangThai == true && c.Is_detele == true && c.NgayBatDau <= DateTime.Now && c.NgayKetThuc >= DateTime.Now).ToList();
                var KhuyenMaiSp = _khuyenMaiSanPhamService.GetAll().Where(c => c.KhuyenMai.Mua1tang1 == true).ToList();
                var g = new List<Guid>();
                foreach (var item in KhuyenMaiSp)
                {
                    // Kiểm tra xem Mau.Id đã xuất hiện trong danh sách chưa
                    if (!g.Contains((Guid)item.IdSanPham))
                    {
                        g.Add((Guid)item.IdSanPham);
                    }
                }
                var view2 = new GioHangView()
                {
                    check11 = g,
                    IdMaGiam = IdGiamGia,
                    tienshipb = tienshipa,
                    tiengiamb = tiengiam,
                    tenmagiam = giamgia1.MaGiam,
                    tienhanga = tienhanga,
                    TienCuoiCungb = tiensaugiam + tienshipa,
                    name = name,
                    ghiChu = ghiChu,
                    Email = Email,
                    Sodienthoai = Sodienthoai,
                    addDiaChi = addDiaChi,
                    DiachiNhanChiTiet = DiachiNhanChiTiet,
                    IdDiaChi = IdDiaChi,
                    idphuongthuc = idphuongthuc,
                    GiamGias = giamgia,
                    DiaChiNhanHang = diachinhanhang,
                    KhachHang = nguoidung,
                    GioHangChiTiets = a,
                    TongTien = tong,
                    listDiaChi = _diaChiNhanHangService.GetAll().Where(c => c.IdKhachHang == accnew[0].Id && c.Is_detele == true).Select(s => new SelectListItem
                    {
                        Value = s.Id.ToString(),
                        Text = s.DiaChi
                    }).ToList(),
                    listPhuongThucs = _phuongThucThanhToanService.GetAll().Select(s => new SelectListItem
                    {
                        Value = s.Id.ToString(),
                        Text = s.TenPhuongThuc
                    }).ToList(),
                };

                return View("ThuTucThanhToan", view2);
            }
            else if (accnew.Count != 0 && addDiaChi == null)
            {
                float tiensaugiam;
                var giamgia1 = _giamGiaService.GetById(IdGiamGia);
                if (giamgia1 == null || giamgia1.NgayBatDau > DateTime.Now || giamgia1.NgayKetThuc < DateTime.Now)
                {
                    var message = $"Giảm giá {giamgia1.MaGiam} hiện không thể sửa dụng";
                    TempData["TB2"] = message;
                    return RedirectToAction("ThuTucThanhToan", "BanHang", new { message });
                }
                if (giamgia1.LoaiGiamGia == false)
                {
                    if (giamgia1.DieuKienGiam < tienhanga)
                    {
                        tiensaugiam = tienhanga - giamgia1.SoTienGiam;
                    }
                    else
                    {
                        {
                            var message = "Tiền đơn hàng chưa đủ điều kiện để sử dụng mã giảm giá này";
                            TempData["TB2"] = message;
                            return RedirectToAction("ThuTucThanhToan", "BanHang", new { message });
                        }
                    }
                }
                else
                {
                    if (giamgia1.DieuKienGiam < tienhanga)
                    {
                        var tientru = (tienhanga * giamgia1.PhanTramGiam / 100);
                        if (tientru >= giamgia1.SoTienGiamToiDa)
                        {
                            tientru = giamgia1.SoTienGiamToiDa;
                        }
                        tiensaugiam = tienhanga - tientru;
                    }
                    else
                    {
                        {
                            var message = "Tiền đơn hàng chưa đủ điều kiện để sử dụng mã giảm giá này";
                            TempData["TB2"] = message;
                            return RedirectToAction("ThuTucThanhToan", "BanHang", new { message });
                        }
                    }
                }

                var gg = _giamGiaService.GetById(IdGiamGia);
                // Đọc dữ liệu từ Session xem trong Cart nó có cái gì chưa?
                var giamgianew = SessionBan.GiamGiaSS(HttpContext.Session, "GiamGia");
                if (giamgianew.Count == 0)
                {
                    giamgianew.Add(gg);
                    SessionBan.SetObjToJson(HttpContext.Session, "GiamGia", giamgianew);
                }
                else if (giamgianew.Count != 0)
                {
                    giamgianew.Clear();
                    giamgianew.Add(gg);
                    SessionBan.SetObjToJson(HttpContext.Session, "GiamGia", giamgianew);
                }
                float tiengiam = (tienhanga + tienshipa) - (tiensaugiam + tienshipa);
                var gh = _GioHang.GetAll().FirstOrDefault(c => c.IdKhachHang == accnew[0].Id);
                IEnumerable<GioHangChiTiet> ghct = _GioHangjoiin.GetAll().Where(c => c.IdGioHang == gh.Id);
                if (ghct.Count() == 0)
                {
                    var message = "Giỏ hàng đang trống hãy thêm sản phẩm của bạn để tiến hàng đặt hàng";
                    TempData["TB4"] = message;
                    return RedirectToAction("GioHang", new { message });
                }
                foreach (var x in ghct)
                {
                    tong += float.Parse(x.SanPhamChiTiet.SanPham.GiaNiemYet.ToString()) * (x.SoLuong);
                }
                var a = _GioHangjoiin.GetAll().Where(c => c.IdGioHang == gh.Id);
                var nguoidung = _khachHangService.GetAll().FirstOrDefault(c => c.Id == accnew[0].Id);
                var diachinhanhang = _diaChiNhanHangService.GetAll().Where(c => c.IdKhachHang == accnew[0].Id).FirstOrDefault(c => c.TrangThai == true && c.Is_detele == true);
                var giamgia = _giamGiaService.GetAll().Where(c => c.TrangThai == true && c.Is_detele == true && c.NgayBatDau <= DateTime.Now && c.NgayKetThuc >= DateTime.Now).ToList();
                var KhuyenMaiSp = _khuyenMaiSanPhamService.GetAll().Where(c => c.KhuyenMai.Mua1tang1 == true).ToList();
                var g = new List<Guid>();
                foreach (var item in KhuyenMaiSp)
                {
                    // Kiểm tra xem Mau.Id đã xuất hiện trong danh sách chưa
                    if (!g.Contains((Guid)item.IdSanPham))
                    {
                        g.Add((Guid)item.IdSanPham);
                    }
                }
                var view2 = new GioHangView()
                {
                    check11 = g,
                    tienshipb = tienshipa,
                    tiengiamb = tiengiam,
                    tenmagiam = giamgia1.MaGiam,
                    tienhanga = tienhanga,
                    TienCuoiCungb = tiensaugiam + tienshipa,
                    name = name,
                    ghiChu = ghiChu,
                    Email = Email,
                    Sodienthoai = Sodienthoai,
                    addDiaChi = addDiaChi,
                    DiachiNhanChiTiet = DiachiNhanChiTiet,
                    IdDiaChi = IdDiaChi,
                    idphuongthuc = idphuongthuc,
                    GiamGias = giamgia,
                    DiaChiNhanHang = diachinhanhang,
                    KhachHang = nguoidung,
                    GioHangChiTiets = a,
                    TongTien = tong,
                    listDiaChi = _diaChiNhanHangService.GetAll().Where(c => c.IdKhachHang == accnew[0].Id && c.Is_detele == true).Select(s => new SelectListItem
                    {
                        Value = s.Id.ToString(),
                        Text = s.DiaChi
                    }).ToList(),
                    listPhuongThucs = _phuongThucThanhToanService.GetAll().Select(s => new SelectListItem
                    {
                        Value = s.Id.ToString(),
                        Text = s.TenPhuongThuc
                    }).ToList(),
                };

                return View("ThuTucThanhToan", view2);
            }
            else
            {
                return RedirectToAction("login", "Home");

            }
        }
        #endregion

        #region Hoa Don
        public IActionResult HoaDon()
        {
            var accnew = SessionServices.KhachHangSS(HttpContext.Session, "ACC");
            if (accnew.Count != 0)
            {
                var a = _HoaDonService.GetAll().Where(c => c.IdKhachHang == accnew[0].Id);
                return View(a);
            }
            else
            {
                return RedirectToAction("login", "Home");
            }

        }
        public IActionResult HoaDonChiTiet(int id)
        {
            var b = _HoaDonService.GetById(id);
            var a = _HoaDonChiTiet.GetAll().Where(c => c.IdHoaDon == id).ToList();
            var c = _giamGiaChiTietService.GetAll().Where(c => c.IdHoaDon == id).ToList();
            var d = _LichSuHoaDonService.GetAll().Where(c => c.IdHoaDonn == id && c.TrangThai == true).OrderByDescending(c => c.ThoiGianlam).ToList();

            var view = new ThieuxkView()
            {
                HoaDon = b,
                hoaDonChiTiets = a,
                GiamGiaChiTiets = c,
                LichSuDonHangs = d,
            };
            return View(view);
        }
        public IActionResult huydonKH(int id, string LyDo)
        {
            var accnew = SessionServices.KhachHangSS(HttpContext.Session, "ACC");
            if (accnew.Count != 0)
            {
                if (LyDo == null)
                {
                    var message = "hãy điền lý do của bạn";
                    TempData["TB4"] = message;
                    return RedirectToAction("HoaDonChiTiet", new { id = id, message });
                }
                var hd = _HoaDonService.GetById(id);
                if (hd.NgayGiao == null)
                {
                    hd.TrangThai = "Đơn hàng bị hủy";
                    ;
                    if (_HoaDonService.Sua(hd) == true)
                    {
                        var ls = new LichSuDonHang()
                        {
                            TrangThai = true,
                            NguoiThucHien = $"Khách hàng{accnew[0].TenDangNhap}",
                            ThoiGianlam = DateTime.Now,
                            ThaoTac = $"Hủy Đơn hàng {hd.MaHoaDon}",
                            IdHoaDonn = id
                        };
                        _LichSuHoaDonService.Them(ls);
                    }
                }
                else
                {
                    var message = "Đơn hàng không thể hủy vì đã và đang được giao";
                    TempData["TB4"] = message;
                    return RedirectToAction("HoaDonChiTiet", new { id = id, message });
                }
                var b = _HoaDonService.GetById(id);
                var a = _HoaDonChiTiet.GetAll().Where(c => c.IdHoaDon == id).ToList();
                var c = _giamGiaChiTietService.GetAll().Where(c => c.IdHoaDon == id).ToList();
                var d = _LichSuHoaDonService.GetAll().Where(c => c.IdHoaDonn == id).OrderByDescending(c => c.ThoiGianlam).ToList();
                var view = new ThieuxkView()
                {
                    HoaDon = b,
                    hoaDonChiTiets = a,
                    GiamGiaChiTiets = c,
                    LichSuDonHangs = d,
                };
                return View("HoaDonChiTiet", view);
            }
            else
            {
                return RedirectToAction("login", "Home");
            }
        }
        #endregion
    }

}