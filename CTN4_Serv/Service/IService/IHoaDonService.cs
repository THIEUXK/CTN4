using CTN4_Data.Models.DB_CTN4;
using CTN4_Serv.Service.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CTN4_Serv.Service.IService
{
    public interface IHoaDonService
    {
        public List<HoaDon> GetAll();
        public HoaDon GetById(int id);
        public int[] ThongKeTongTienHoaDonTheoThangTrongNam();
        public int[] ThongKeSoLuongDonHangTrongKhoangThoiGian(DateTime tuNgay, DateTime denNgay);
        public decimal[] ThongKeTongTienDonHangTrongKhoangThoiGian(DateTime tuNgay, DateTime denNgay);
        public int[] ThongKeSoLuongDonHangTheoThangTrongNam();
        public float[] ThongKeSoLuongDonHangTheoThangTrongNam(int nam);
        public List<BestSellingProductModel> ThongKeSanPhamBanChay();
        public bool Them(HoaDon a);
        public bool Sua(HoaDon a);
        public bool Xoa(int id);
    }
}
