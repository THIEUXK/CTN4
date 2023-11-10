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


        public BanHangController()
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
            _httpClient.DefaultRequestHeaders.Add("token", "fa31ddca-73b0-11ee-b394-8ac29577e80e");
            _httpClient.DefaultRequestHeaders.Add("shop_id", "4189141");
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
                //var gioHang = SessionServices.GioHangSS(HttpContext.Session, "GioHang");

                //foreach (var x in gioHang)
                //{
                //    var spct = _SanPhamChiTiet.GetAll().FirstOrDefault(c => c.Id == x.IdSanPhamChiTiet);
                //    tong += float.Parse(spct.SanPham.GiaNiemYet.ToString()) * (x.SoLuong);

                //}

                //var view = new GioHangView()
                //{

                //    GioHangChiTiets = gioHang,
                //    TongTien = tong
                //};
                //return View(view);
            }

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
                if (ghct.Count()==0)
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
                var diachinhanhang = _diaChiNhanHangService.GetAll().Where(c => c.IdKhachHang == accnew[0].Id).FirstOrDefault(c=>c.TrangThai==true);

                var view2 = new GioHangView()
                {
                    DiaChiNhanHang=diachinhanhang,
                    KhachHang=nguoidung,
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
                //var gh2 = _GioHang.GetAll().FirstOrDefault(c => c.IdKhachHang == null);
                //var a = _GioHangjoiin.GetAll().Where(c => c.IdGioHang == gh2.Id);
                //foreach (var x in a)
                //{
                //    tong += float.Parse(x.SanPhamChiTiet.SanPham.GiaNiemYet.ToString()) * (x.SoLuong);

                //}

                //var view = new GioHangView()
                //{
                //    GioHangChiTiets = a,
                //    TongTien = tong,
                //    listDiaChi = _diaChiNhanHangService.GetAll().Where(c => c.IdKhachHang == accnew[0].Id).Select(s => new SelectListItem
                //    {
                //        Value = s.Id.ToString(),
                //        Text = s.name + s.DiaChi
                //    }).ToList(),
                //    listPhuongThucs = _phuongThucThanhToanService.GetAll().Select(s => new SelectListItem
                //    {
                //        Value = s.Id.ToString(),
                //        Text = s.TenPhuongThuc
                //    }).ToList(),

                //};
                //return View(view);
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
                }
                //Shipping shipping = new Shipping()
                //{
                //    = tong + 52000
                //};
                 shipping.data.totaloder = tong + shipping.data.total;

                //shipping.data.totaloder = shipping.data.total + int.Parse(tong.ToString());
                return Json(shipping, new System.Text.Json.JsonSerializerOptions());

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
        public async Task<JsonResult> chonDiaChi(/*[FromBody] ShippingOrder shippingOrder*/)
        {

            float tong = 0;
            var accnew = SessionServices.KhachHangSS(HttpContext.Session, "ACC");
            if (accnew.Count != 0)
            {
                var gh = _GioHang.GetAll().FirstOrDefault(c => c.IdKhachHang == accnew[0].Id);
                IEnumerable<GioHangChiTiet> ghct = _GioHangjoiin.GetAll().Where(c => c.IdGioHang == gh.Id);

                foreach (var x in ghct)
                {
                    tong += float.Parse(x.SanPhamChiTiet.SanPham.GiaNiemYet.ToString()) * (x.SoLuong);

                }           
                Shipping shipping = new Shipping()
                {
                    totaloder = tong + 52000
                };

                //shipping.data.totaloder = shipping.data.total + int.Parse(tong.ToString());
                return Json(shipping.totaloder, new System.Text.Json.JsonSerializerOptions());

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

        public IActionResult HoanThanhThanhToan(string name,string DiachiNhanChiTiet,string Sodienthoai,string Email,string addDiaChi, Guid IdDiaChi,Guid idphuongthuc,string ghiChu,float tienship,float tongtien)
        {
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
            Guid idHoaDon = Guid.NewGuid();
            var accnew = SessionServices.KhachHangSS(HttpContext.Session, "ACC");
            var gh = _GioHang.GetAll().FirstOrDefault(c => c.IdKhachHang == accnew[0].Id);
            if (accnew.Count != 0 && gh != null)
            {
                if (idphuongthuc== Guid.Parse("d16ac357-3ced-4c2c-bcdc-d38971211114"))
                {
                  
                }
                else
                {
                    
                    //Tạo hóa đơn mới
                    var hd = new HoaDon()
                    {
                        Id = idHoaDon,
                        NgayTaoHoaDon = DateTime.Now,
                        DiaChi = DiachiNhanChiTiet + " " + addDiaChi,
                        TrangThai = "Đang chờ xử lí",
                        TongTien = tongtien,
                        TienShip=tienship,
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
                            IdHoaDon = idHoaDon, //Id của hóa đơn vừa tạo
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
                    }
                }
            }
                
            else
            {
                return RedirectToAction("login", "Home");
                //Guid idHoaDon = Guid.NewGuid();
                ////Tạo hóa đơn mới
                //int tong = 0;
                //var ghnull = _GioHang.GetAll().FirstOrDefault(c => c.IdKhachHang == null);
                //foreach (var inso in _GioHangChiTiet.GetAll().Where(c => c.IdGioHang == ghnull.Id))
                //{
                //    tong += Int32.Parse(inso.SoLuong.ToString()) *
                //            Int32.Parse(inso.SanPhamChiTiet.SanPham.GiaNiemYet.ToString());
                //}

                //var hd = new HoaDon()
                //{
                //    Id = idHoaDon,
                //    NgayTaoHoaDon = DateTime.Now,
                //    DiaChi = "",
                //    TenKhachHang = "",
                //    SDTNguoiNhan = "",
                //    TrangThai = "Đang chờ xử lí",
                //    TongTien = tong,
                //    NgayDat = DateTime.Now,
                //    IdPhuongThuc = Guid.Parse("d16ac357-3ced-4c2c-bcdc-d38971211111")

                //};
                //if (_HoaDonService.Them(hd) == false)
                //{
                //    var message = "thanh toán lỗi(1)";
                //    TempData["ErrorMessage"] = message;
                //    return RedirectToAction("ThuTucThanhToan", "BanHang", new { message });
                //}


                ////Thêm chi tiết hóa đơn cho từng sản phẩm trong giỏ hàng
                //foreach (var ct in _GioHangChiTiet.GetAll().Where(c => c.IdGioHang == ghnull.Id))
                //{
                //    var cthd = new HoaDonChiTiet()
                //    {
                //        Id = Guid.NewGuid(),
                //        IdHoaDon = idHoaDon, //Id của hóa đơn vừa tạo
                //        IdSanPhamChiTiet = ct.IdSanPhamChiTiet,
                //        SoLuong = ct.SoLuong,
                //        GiaTien = ct.SanPhamChiTiet.SanPham.GiaNiemYet,
                //        TrangThai = true,
                //        Is_detele = true,
                //    };
                //    if (_HoaDonChiTiet.Them(cthd) == false)
                //    {
                //        var message = "thanh toán lỗi(2)";
                //        TempData["ErrorMessage"] = message;
                //        return RedirectToAction("ThuTucThanhToan", "BanHang", new { message });
                //    }

                //    //Trừ số lượng sản phẩm trong CSDL
                //    if (_GioHangChiTiet.Xoa(ct.Id) == false) //Xóa các bản ghi mà người dùng thêm vào trong giỏ hàng
                //    {
                //        var message = "thanh toán lỗi(3)";
                //        TempData["ErrorMessage"] = message;
                //        return RedirectToAction("ThuTucThanhToan", "BanHang", new { message });
                //    }
                //}
            }

            return RedirectToAction("SauThanhToan", idHoaDon);
        }

        public IActionResult HoaDon()
        {
            var a = _HoaDonService.GetAll();
            return View(a);
        }
        public IActionResult HoaDonChiTiet(Guid id)
        {
            var b = _HoaDonService.GetById(id);
            var a = _HoaDonChiTiet.GetAll().Where(c => c.IdHoaDon == id).ToList();
            var view = new ThieuxkView()
            {
                HoaDon = b,
                hoaDonChiTiets = a,
            };
            return View(view);
        }
        public IActionResult SauThanhToan(Guid idHoaDon)
        {

            return View();
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

        public IActionResult huydonKH(Guid id)
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

    }

}