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
                .Where(ct => ct.TrangThai&& !ct.Is_detele )
                .ToList();

            // Tạo một Dictionary để lưu tổng số lượng bán của từng sản phẩm
            Dictionary<Guid, int> tongSoLuongBan = new Dictionary<Guid, int>();

            // Duyệt qua danh sách chi tiết hóa đơn để tính tổng số lượng bán của từng sản phẩm
            foreach (var chiTietHoaDon in chiTietHoaDons)
            {
                Guid productId = chiTietHoaDon.IdSanPhamChiTiet.GetValueOrDefault();

                if (tongSoLuongBan.ContainsKey(productId))
                {
                    tongSoLuongBan[productId] += chiTietHoaDon.SoLuong;
                }
                else
                {
                    tongSoLuongBan[productId] = chiTietHoaDon.SoLuong;
                }
            }

            // Sắp xếp danh sách theo số lượng bán giảm dần
            var sortedProducts = tongSoLuongBan.OrderByDescending(pair => pair.Value);

            // Lấy danh sách sản phẩm bán chạy
            List<BestSellingProductModel> result = new List<BestSellingProductModel>();

            // Lấy thông tin chi tiết của sản phẩm từ cơ sở dữ liệu và thêm vào danh sách kết quả
            foreach (var sortedProduct in sortedProducts)
            {
                var productDetail = _db.SanPhamChiTiets.FirstOrDefault(p => p.Id == sortedProduct.Key);
                var product = _db.SanPhams.FirstOrDefault(p => p.Id == productDetail.IdSp);

                if (productDetail != null)
                {
                    var bestSellingProduct = new BestSellingProductModel
                    {
                        ProductId = productDetail.Id,
                        ProductName = product.TenSanPham,
                        TotalQuantitySold = sortedProduct.Value
                    };
                    result.Add(bestSellingProduct);
                }
            }

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
                .Where(h => h.TrangThaiThanhToan && h.NgayTaoHoaDon.Year == namHienTai)
                .ToList();

            // Tạo Dictionary để lưu tổng tiền theo tháng
            Dictionary<int, int> tongTienTheoThang = new Dictionary<int, int>();

            // Tính tổng tiền của từng hóa đơn và nhóm theo tháng
            foreach (var hoaDon in hoaDonsThanhToanTrongNam)
            {
                int thang = hoaDon.NgayTaoHoaDon.Month;

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
            // Lấy năm hiện tại
            int namHienTai = DateTime.Now.Year;

            // Sử dụng LINQ để lấy danh sách các hóa đơn có TrangThaiThanhToan là true và ngày tạo hóa đơn trong năm hiện tại
            var hoaDonsTrangThaiTrue = _db.HoaDons
                .Where(h => h.TrangThaiThanhToan && h.NgayTaoHoaDon.Year == namHienTai)
                .ToList();

            // Tạo Dictionary để lưu số lượng đơn hàng theo tháng
            Dictionary<int, int> soLuongTheoThang = new Dictionary<int, int>();

            // Đếm số lượng đơn hàng của từng tháng
            foreach (var hoaDon in hoaDonsTrangThaiTrue)
            {
                int thang = hoaDon.NgayTaoHoaDon.Month;

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

