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

namespace CTN4_View.Controllers.Shop
{
    public class BanHangController : Controller
    {
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


        public BanHangController(IConfiguration config, IVnPayService vnpay, ICurrentUser currentUser)
        {
            _diaChiNhanHangService = new DiaChiNhanHangService();
            _sanPhamCuaHangService = new SanPhamCuaHangService();
            _GioHang = new GioHangService();
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

        }


        [HttpGet]
        public IActionResult GioHang()
        {
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
                    anhs = anh
                };
                return View(view2);
            }
            else
            {
                return RedirectToAction("login", "Home");
            }

        }


        //[Authorize]
        //public IActionResult PaypalCheckout()
        //{
        //    return View();
        //}
        //public IActionResult CreatePaymentUrl(string DiachiNhanChiTiet)
        //{
        //    model.Name = RemoveAccents(model.Name);
        //    model.OrderDescription = RemoveAccents(model.OrderDescription);
        //    model.OrderType = RemoveAccents(model.OrderType);
        //    var url = _ivnPayService.CreatePaymentUrl(model, HttpContext);
        //    return Redirect(url);
        //    return View();
        //}
        //private string RemoveAccents(string input)
        //{
        //    string normalizedString = input.Normalize(NormalizationForm.FormD);
        //    Regex regex = new Regex("[^a-zA-Z0-9 ]");
        //    return regex.Replace(normalizedString, "").ToLower();
        //}

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
                    NgayTaoHoaDon = DateTime.Now,
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
        public IActionResult ThuTucThanhToan()
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
                var diachinhanhang = _diaChiNhanHangService.GetAll().Where(c => c.IdKhachHang == accnew[0].Id).FirstOrDefault(c => c.TrangThai == true);

                var view2 = new GioHangView()
                {
                    DiaChiNhanHang = diachinhanhang,
                    KhachHang = nguoidung,
                    GioHangChiTiets = a,
                    TongTien = tong,
                    listDiaChi = _diaChiNhanHangService.GetAll().Where(c => c.IdKhachHang == accnew[0].Id).Select(s => new SelectListItem
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
            var accnew = SessionServices.KhachHangSS(HttpContext.Session, "ACC");
            var respose = await _httpClient.PostAsync(url, content);



            if (accnew.Count != 0)
            {
                var gh = _GioHang.GetAll().FirstOrDefault(c => c.IdKhachHang == accnew[0].Id);
                var ghct = _GioHangjoiin.GetAll().Where(c => c.IdGioHang == gh.Id);

                foreach (var x in ghct)
                {
                    tong += float.Parse(x.SanPhamChiTiet.SanPham.GiaNiemYet.ToString()) * (x.SoLuong);

                }
                Shipping shipping = new Shipping();
                if (respose.IsSuccessStatusCode)
                {
                    string jsonData2 = respose.Content.ReadAsStringAsync().Result;

                    shipping = JsonConvert.DeserializeObject<Shipping>(jsonData2);
                    HttpContext.Session.SetInt32("shiptotal", shipping.data.total);
                    shipping.data.totaloder = tong + shipping.data.total;

                    //shipping.data.totaloder = shipping.data.total + int.Parse(tong.ToString());
                    return Json(shipping, new System.Text.Json.JsonSerializerOptions());
                }
                else
                {
                    shipping.message = "False";

                    //shipping.data.totaloder = shipping.data.total + int.Parse(tong.ToString());
                    return Json(shipping, new System.Text.Json.JsonSerializerOptions());
                }

                //Shipping shipping = new Shipping()
                //{
                //    = tong + 52000
                //};


            }
            else
            {
                var gh2 = _GioHang.GetAll().FirstOrDefault(c => c.IdKhachHang == null);
                var a = _GioHangjoiin.GetAll().Where(c => c.IdGioHang == gh2.Id);
                foreach (var x in a)
                {
                    tong += float.Parse(x.SanPhamChiTiet.SanPham.GiaNiemYet.ToString()) * (x.SoLuong);

                }
                Shipping shipping = new Shipping()
                {
                    totaloder = tong + 50000
                };
                //if (respose.IsSuccessStatusCode)
                //{
                //    string jsonData2 = respose.Content.ReadAsStringAsync().Result;

                //    shipping = JsonConvert.DeserializeObject<Shipping>(jsonData2);
                //    HttpContext.Session.SetInt32("shiptotal", shipping.data.total);
                //}


                return Json(shipping, new System.Text.Json.JsonSerializerOptions());

            }


        }

        [HttpGet("/CheckOut/chonDiaChi")]
        public async Task<JsonResult> chonDiaChi(Guid idDiaChiKD)
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
                    totaloder = tong + diaChi.TienShip.Value,
                    TienShip = diaChi.TienShip.Value
                };

                //shipping.data.totaloder = shipping.data.total + int.Parse(tong.ToString());
                return Json(shipping, new System.Text.Json.JsonSerializerOptions());

            }
            return Json(0, new System.Text.Json.JsonSerializerOptions());
        }

        public IActionResult HoanThanhThanhToan(string name, string DiachiNhanChiTiet, string Sodienthoai, string Email, string addDiaChi, Guid IdDiaChi, Guid idphuongthuc, string ghiChu, float tienship, float tongtien)
        {
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
                        tienship = tienship,
                        tongtien = tongtien
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
                        NgayTaoHoaDon = DateTime.Now,
                        DiaChi = DiachiNhanChiTiet + " " + addDiaChi,
                        TrangThai = "Đang chờ xử lí",
                        TongTien = tongtien,
                        TienShip = tienship,
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
                        var lisdiachi = _diaChiNhanHangService.GetAll().Where(c => c.DiaChi == addDiaChi && c.IdKhachHang == accnew[0].Id && c.TienShip == tienship).ToList();
                        if (lisdiachi1.Count() < 4 && lisdiachi.Count == 0)
                        {
                            var diachi = new DiaChiNhanHang()
                            {
                                IdKhachHang = accnew[0].Id,
                                name = addDiaChi,
                                DiaChi = addDiaChi,
                                TienShip = tienship,
                            };
                            _diaChiNhanHangService.Them(diachi);
                        }
                    }
                }
            }

            else
            {
                return RedirectToAction("login", "Home");

            }

            return RedirectToAction("SauThanhToan",new {id=idHoaDon});
        }
        //public int TraVeIdHoaDon()
        //{
        //    var hh2 = _HoaDonService.GetAll().ToList();
        //    if (hh2.Count == 0)
        //    {
        //        int idHoaDon2 = hh2.Max(c => c.Id);
        //    }

        //}
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


            var view = new ThieuxkView()
            {
                HoaDon = b,
                hoaDonChiTiets = a,
                GiamGiaChiTiets = c
            };
            return View(view);
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

        [HttpPost]
        public IActionResult ThemVaoGio(int soluong, Guid IdSanPham, Guid IdSize, Guid IdMau)
        {
            var accnew = SessionServices.KhachHangSS(HttpContext.Session, "ACC");
            if (accnew.Count != 0)
            {
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
                //var sanphamCT = _SanPhamChiTiet.GetAll().FirstOrDefault(c => c.IdSp == IdSanPham && c.IdSize == IdSize && c.IdMau == IdMau);

                ////if (accnew.Count == 0)
                ////{
                ////    gioHang.Add(a);
                ////    SessionServices.SetObjToJson(HttpContext.Session, "GioHang", accnew);
                ////}
                ////else if (accnew.Count != 0)
                ////{
                ////    gioHang.Clear();
                ////    gioHang.Add(a);
                ////    SessionServices.SetObjToJson(HttpContext.Session, "GioHang", accnew);
                ////}

                //var gioHang = SessionServices.GioHangSS(HttpContext.Session, "GioHang");
                //var SP = gioHang.FirstOrDefault(c => c.IdSanPhamChiTiet == sanphamCT.Id);
                //if (SP == null)
                //{
                //    var d = new GioHangChiTiet()
                //    {
                //        Id = Guid.NewGuid(),
                //        IdSanPhamChiTiet = sanphamCT.Id,
                //        SoLuong = soluong,
                //    };
                //    gioHang.Add(d);
                //    SessionServices.SetObjToJson(HttpContext.Session, "GioHang", gioHang);

                //    var product = _SanPhamChiTiet.GetById(sanphamCT.Id);
                //    product.SoLuong -= soluong;
                //    if (_SanPhamChiTiet.Sua(product))
                //    {
                //        return RedirectToAction("GioHang");
                //    }
                //}
                //else
                //{
                //    SP.SoLuong += soluong;

                //    gioHang.Remove(SP);
                //    gioHang.Add(SP);
                //    SessionServices.SetObjToJson(HttpContext.Session, "GioHang", gioHang);
                //    var product = _SanPhamChiTiet.GetById(sanphamCT.Id);
                //    product.SoLuong -= soluong;
                //    if (_SanPhamChiTiet.Sua(product))
                //    {
                //        return RedirectToAction("GioHang");
                //    }
                //}
            }

            var message4 = "Thêm thất bại !";
            TempData["TB1"] = message4;
            return RedirectToAction("HienThiSanPhamChiTiet", "HienThiSanPham", new { id = IdSanPham, message4 });
        }
        public IActionResult huydonKH(int id)
        {
            var hd = _HoaDonService.GetById(id);
            if (hd.NgayGiao == null)
            {
                hd.TrangThai = "Quý khách đã hủy đơn hàng thành công";
                hd.Is_detele = false;
                _HoaDonService.Sua(hd);
            }
            else
            {
                var message = "Đơn hàng không thể hủy vì đã và đang được giao";
                TempData["TB4"] = message;
                return RedirectToAction("HoaDonChiTiet", new { id = id, message });
            }

            var b = _HoaDonService.GetById(id);
            var a = _HoaDonChiTiet.GetAll().Where(c => c.IdHoaDon == id).ToList();
            var view = new ThieuxkView()
            {
                HoaDon = b,
                hoaDonChiTiets = a,
            };
            return View("HoaDonChiTiet", view);
        }
        //[HttpPost("/CheckOut/ThemDiaChi")]
        //public IActionResult ThemDiaChiMoi([FromBody] DiaChiHung diaChiHung)
        //{
        //    var accnew = SessionServices.KhachHangSS(HttpContext.Session, "ACC");
        //    if (diaChiHung.DiaChi == null || diaChiHung.tiennhip == null)
        //    {
        //        var message = "hãy nhớ chọn địa chỉ của bạn";
        //        TempData["TBDC"] = message;
        //        return RedirectToAction("ThuTucThanhToan", "BanHang", new { message });
        //    }


        //    var lisdiachi = _diaChiNhanHangService.GetAll().Where(c => c.DiaChi == diaChiHung.DiaChi && c.IdKhachHang == accnew[0].Id).ToList();
        //    if (lisdiachi.Count()==3)
        //    {
        //        var message = "Địa chỉ khách hàng đã quá 3 địa chỉ không thêm tiếp";
        //        TempData["TBDC"] = message;
        //        return RedirectToAction("ThuTucThanhToan", "BanHang", new { message });
        //    }
        //    if (accnew.Count != 0)
        //    {
        //        var diachi = new DiaChiNhanHang()
        //        {
        //            IdKhachHang = accnew[0].Id,
        //            name = diaChiHung.DiaChi,
        //            DiaChi = diaChiHung.DiaChi,
        //            TienShip = float.Parse(diaChiHung.tiennhip),
        //        };
        //        _diaChiNhanHangService.Them(diachi); 
        //        return RedirectToAction("ThuTucThanhToan");
        //    }
        //    else
        //    {
        //        return RedirectToAction("login", "Home");
        //    }
        //}
    }

}