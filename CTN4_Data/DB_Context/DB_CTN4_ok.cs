using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using CTN4_Data.Models;
using CTN4_Data.Models.DB_CTN4;
using Microsoft.EntityFrameworkCore;

namespace CTN4_Data.DB_Context
{
    public class DB_CTN4_ok : DbContext
    {
        public DbSet<Anh> Anhs { get; set; }
        public DbSet<ChatLieu> ChatLieus { get; set; }
        public DbSet<ChiTietSanPhamYeuThich> ChiTietSanPhamYeu { get; set; }
        public DbSet<ChucVu> ChucVus { get; set; }
        public DbSet<DanhMuc> DanhMucs { get; set; }
        public DbSet<DanhMucChiTiet> DanhMucChiTiets { get; set; }
        public DbSet<DiaChiNhanHang> DaiChiNhanHangs { get; set; }
        public DbSet<GiamGia> GiamGias { get; set; }
        public DbSet<GiamGiaChiTiet> GiamGiaChiTiets { get; set; }
        public DbSet<GioHang> GioHangs { get; set; }
        public DbSet<GioHangChiTiet> GioHangChiTiets { get; set; }
        public DbSet<HoaDon> HoaDons { get; set; }
        public DbSet<HoaDonChiTiet> HoaDonChiTiets { get; set; }
        public DbSet<KhachHang> KhachHangs { get; set; }
        public DbSet<KhuyenMai> KhuyenMais { get; set; }
        public DbSet<KhuyenMaiPhanLoai> KhuyenMaiPhanLoais { get; set; }
        public DbSet<KhuyenMaiSanPham> KhuyenMaiSanPhams { get; set; }
        public DbSet<LichSuDonHang> LichSuDonHangs { get; set; }
        public DbSet<Mau> Maus { get; set; }
        public DbSet<NSX> NSXs { get; set; }
        public DbSet<NhanVien> NhanViens { get; set; }
        public DbSet<PhanLoai> PhanLoais { get; set; }
        public DbSet<PhanLoaiChiTiet> PhanLoaiChiTiets { get; set; }
        public DbSet<PhuongThucThanhToan> PhuongThucThanhToans { get; set; }
        public DbSet<SanPham> SanPhams { get; set; }
        public DbSet<SanPhamChiTiet> SanPhamChiTiets { get; set; }
        public DbSet<Size> Sizes { get; set; }
        public DbSet<DanhGiaSanPham> DanhGiaSanPhams { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=MSI;Initial Catalog=CTN4a;User ID=sa;Password=thieu12345");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Send();
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
