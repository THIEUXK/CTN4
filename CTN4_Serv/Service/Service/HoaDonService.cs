using CTN4_Data.DB_Context;
using CTN4_Data.Models.DB_CTN4;
using CTN4_Serv.Service.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CTN4_Serv.Service.Service;

namespace CTN4_Serv.Service
{
    public class HoaDonService : IHoaDonService
    {
        public DB_CTN4_ok _db;


        public HoaDonService()
        {
            _db = new DB_CTN4_ok();
        }
        public List<HoaDon> GetAll()
        {
            return _db.HoaDons.Include(c=>c.KhachHang).Include(c=>c.DiaChiNhanHang).Include(c=>c.PhuongThucThanhToan).ToList();
        }
        public List<BestSellingProductModel> ThongKeSanPhamBanChay()
        {
            // Lấy danh sách chi tiết hóa đơn từ cơ sở dữ liệu
            var chiTietHoaDons = _db.HoaDonChiTiets
                .Where(ct => ct.TrangThai && ct.Is_detele)
                .ToList();

            // Tạo một Dictionary để lưu tổng số lượng bán của từng tên sản phẩm
            Dictionary<string, int> tongSoLuongBanTheoTen = new Dictionary<string, int>();

            // Duyệt qua danh sách chi tiết hóa đơn để tính tổng số lượng bán của từng tên sản phẩm
            foreach (var chiTietHoaDon in chiTietHoaDons)
            {
                var productDetail = _db.SanPhamChiTiets.FirstOrDefault(p => p.Id == chiTietHoaDon.IdSanPhamChiTiet);
                var productName = _db.SanPhams.Where(p => p.Id == productDetail.IdSp).Select(p => p.TenSanPham).FirstOrDefault();

                if (!string.IsNullOrEmpty(productName))
                {
                    if (tongSoLuongBanTheoTen.ContainsKey(productName))
                    {
                        tongSoLuongBanTheoTen[productName] += chiTietHoaDon.SoLuong;
                    }
                    else
                    {
                        tongSoLuongBanTheoTen[productName] = chiTietHoaDon.SoLuong;
                    }
                }
            }

            // Lấy danh sách sản phẩm bán chạy
            List<BestSellingProductModel> result = new List<BestSellingProductModel>();

            // Thêm thông tin vào danh sách kết quả
            foreach (var kvp in tongSoLuongBanTheoTen)
            {
                var bestSellingProduct = new BestSellingProductModel
                {
                    ProductName = kvp.Key,
                    TotalQuantitySold = kvp.Value
                };

                result.Add(bestSellingProduct);
            }

            // Sắp xếp danh sách theo số lượng bán giảm dần
            result = result.OrderByDescending(product => product.TotalQuantitySold).ToList();

            return result;
        }

        public HoaDon GetById(int id)
        {
            return GetAll().FirstOrDefault(c => c.Id == id);
        }
        public int[] ThongKeTongTienHoaDonTheoThangTrongNam()
        {
            // Lấy năm hiện tại
            int namHienTai = DateTime.Now.Year;

            // Sử dụng LINQ để lấy danh sách các hóa đơn có TrangThaiThanhToan là true và ngày tạo hóa đơn trong năm hiện tại
            var hoaDonsThanhToanTrongNam = _db.HoaDons
                .Where(h => h.TrangThaiThanhToan &&
                            h.NgayNhan.Value.Year == namHienTai &&
                            h.TrangThai == "Giao hàng thành công")
                .ToList();

            // Tạo Dictionary để lưu tổng tiền theo tháng
            Dictionary<int, int> tongTienTheoThang = new Dictionary<int, int>();

            // Tính tổng tiền của từng hóa đơn và nhóm theo tháng
            foreach (var hoaDon in hoaDonsThanhToanTrongNam)
            {
                int thang = hoaDon.NgayNhan.Value.Month;

                if (tongTienTheoThang.ContainsKey(thang))
                {
                    tongTienTheoThang[thang] += (int)hoaDon.TongTien;
                }
                else
                {
                    tongTienTheoThang[thang] = (int)hoaDon.TongTien;
                }
            }


            // Chuyển đổi Dictionary thành mảng int[]
            int[] result = new int[12];
            for (int i = 1; i <= 12; i++)
            {
                result[i - 1] = tongTienTheoThang.ContainsKey(i) ? tongTienTheoThang[i] : 0;
            }

            return result;
        }
        public int[] ThongKeSoLuongDonHangTheoThangTrongNam()
        {
            int namHienTai = DateTime.Now.Year;

            // Sử dụng LINQ để lấy danh sách các hóa đơn có TrangThaiThanhToan là true, 
            // ngày tạo hóa đơn trong năm hiện tại và TrangThai là "Giao hàng thành công"
            var hoaDonsTrangThaiTrue = _db.HoaDons
                .Where(h => h.TrangThaiThanhToan &&
                            h.NgayNhan.Value.Year == namHienTai &&
                            h.TrangThai == "Giao hàng thành công")
                .ToList();

            // Tạo Dictionary để lưu số lượng đơn hàng theo tháng
            Dictionary<int, int> soLuongTheoThang = new Dictionary<int, int>();

            // Đếm số lượng đơn hàng của từng tháng
            foreach (var hoaDon in hoaDonsTrangThaiTrue)
            {
                int thang = hoaDon.NgayNhan.Value.Month;

                if (soLuongTheoThang.ContainsKey(thang))
                {
                    soLuongTheoThang[thang]++;
                }
                else
                {
                    soLuongTheoThang[thang] = 1;
                }
            }

            // Chuyển đổi Dictionary thành mảng int[]
            int[] result = new int[12];
            for (int i = 1; i <= 12; i++)
            {
                result[i - 1] = soLuongTheoThang.ContainsKey(i) ? soLuongTheoThang[i] : 0;
            }

            return result;
        }
        public float[] ThongKeSoLuongDonHangTheoThangTrongNam(int nam)
        {
            // Khởi tạo mảng để lưu tổng tiền đơn hàng theo tháng
            float[] tongTienTheoThang = new float[12];

            // Sử dụng LINQ để lấy tổng tiền đơn hàng theo tháng
            var thongKe = _db.HoaDons
                .Where(h => h.TrangThaiThanhToan &&
                            h.NgayNhan.Value.Year == nam &&
                            h.TrangThai == "Giao hàng thành công")
                .GroupBy(h => h.NgayNhan.Value.Month)
                .Select(g => new { Thang = g.Key, TongTien = g.Sum(h => h.TongTien) });

            // Cập nhật tổng tiền đơn hàng vào mảng
            foreach (var item in thongKe)
            {
                tongTienTheoThang[item.Thang - 1] = (float)item.TongTien; // Chuyển đổi về kiểu float
            }

            return tongTienTheoThang;
        }


        public int[] ThongKeSoLuongDonHangTrongKhoangThoiGian(DateTime tuNgay, DateTime denNgay)
        {
            // Sử dụng LINQ để lấy danh sách các hóa đơn có TrangThaiThanhToan là true, 
            // ngày tạo hóa đơn trong khoảng thời gian và TrangThai là "Giao hàng thành công"
            var hoaDonsTrangThaiTrueTrongKhoangThoiGian = _db.HoaDons
                .Where(h => h.TrangThaiThanhToan &&
                            h.NgayNhan >= tuNgay &&
                            h.NgayNhan <= denNgay &&
                            h.TrangThai == "Giao hàng thành công")
                .ToList();

            // Tạo mảng để lưu số lượng đơn hàng theo số ngày trong khoảng thời gian
            int[] soLuongTheoNgayTrongKhoang = new int[(denNgay - tuNgay).Days + 1];

            // Đếm số lượng đơn hàng của từng ngày trong khoảng thời gian
            foreach (var hoaDon in hoaDonsTrangThaiTrueTrongKhoangThoiGian)
            {
                // Kiểm tra nếu NgayNhan và tuNgay không null
                if (hoaDon.NgayNhan.HasValue && tuNgay != null)
                {
                    TimeSpan timeSpan = hoaDon.NgayNhan.Value - tuNgay;
                    int ngayTrongKhoang = timeSpan.Days;

                    // Kiểm tra ngày để tránh tràn mảng
                    if (ngayTrongKhoang >= 0 && ngayTrongKhoang < soLuongTheoNgayTrongKhoang.Length)
                    {
                        soLuongTheoNgayTrongKhoang[ngayTrongKhoang]++;
                    }
                }
            }

            return soLuongTheoNgayTrongKhoang;
        }
        public decimal[] ThongKeTongTienDonHangTrongKhoangThoiGian(DateTime tuNgay, DateTime denNgay)
        {

            // Sử dụng LINQ để lấy danh sách các hóa đơn có TrangThaiThanhToan là true và ngày tạo hóa đơn trong khoảng thời gian
            var hoaDonsTrongKhoangThoiGian = _db.HoaDons
                .Where(h => h.TrangThaiThanhToan &&
                            h.NgayNhan >= tuNgay &&
                            h.NgayNhan <= denNgay &&
                            h.TrangThai == "Giao hàng thành công")
                .ToList();

            // Tạo mảng để lưu tổng tiền đơn hàng theo số ngày trong khoảng thời gian
            decimal[] tongTienTheoNgayTrongKhoang = new decimal[(denNgay - tuNgay).Days + 1];

            // Tính tổng tiền của từng ngày trong khoảng thời gian
            foreach (var hoaDon in hoaDonsTrongKhoangThoiGian)
            {
                // Kiểm tra nếu NgayNhan và tuNgay không null
                if (hoaDon.NgayNhan.HasValue && tuNgay != null)
                {
                    TimeSpan timeSpan = hoaDon.NgayNhan.Value - tuNgay;
                    int ngayTrongKhoang = timeSpan.Days;

                    // Kiểm tra ngày để tránh tràn mảng
                    if (ngayTrongKhoang >= 0 && ngayTrongKhoang < tongTienTheoNgayTrongKhoang.Length)
                    {
                        // Chuyển đổi giá trị float thành decimal trước khi thực hiện phép cộng
                        tongTienTheoNgayTrongKhoang[ngayTrongKhoang] += (decimal)hoaDon.TongTien;
                    }
                }
            }

            return tongTienTheoNgayTrongKhoang;
        }
        public bool Them(HoaDon a)
        {
            try
            {
                _db.HoaDons.Add(a);
                _db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        public bool Sua(HoaDon a)
        {
            try
            {
                _db.HoaDons.Update(a);
                _db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        public bool Xoa(int id)
        {
            try
            {
                var b = GetById(id);
                _db.HoaDons.Remove(b);
                _db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}

