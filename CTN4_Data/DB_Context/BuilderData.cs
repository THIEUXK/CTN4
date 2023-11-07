using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CTN4_Data.Models.DB_CTN4;
using Microsoft.EntityFrameworkCore;

namespace CTN4_Data.DB_Context
{
    public static class BuilderData
    {
        public static void Send(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Mau>().HasData(
                new Mau() { TenMau = "đen", Id = Guid.Parse("56dd3ee2-c4df-4376-b982-e2c0f7081111"), Is_detele = true, TrangThai = true },
                new Mau() { TenMau = "trắng", Id = Guid.Parse("56dd3ee2-c4df-4376-b982-e2c0f7081112"), Is_detele = true, TrangThai = true },
                new Mau() { TenMau = "nâu", Id = Guid.Parse("56dd3ee2-c4df-4376-b982-e2c0f7081113"), Is_detele = true, TrangThai = true },
                new Mau() { TenMau = "xám", Id = Guid.Parse("56dd3ee2-c4df-4376-b982-e2c0f7081114"), Is_detele = true, TrangThai = true },
                new Mau() { TenMau = "vàng", Id = Guid.Parse("56dd3ee2-c4df-4376-b982-e2c0f7081115"), Is_detele = true, TrangThai = true },
                new Mau() { TenMau = "ghi", Id = Guid.Parse("56dd3ee2-c4df-4376-b982-e2c0f7081116"), Is_detele = true, TrangThai = true },
                new Mau() { TenMau = "cam", Id = Guid.Parse("56dd3ee2-c4df-4376-b982-e2c0f7081117"), Is_detele = true, TrangThai = true },
                new Mau() { TenMau = "xanh dương đậm", Id = Guid.Parse("56dd3ee2-c4df-4376-b982-e2c0f7081118"), Is_detele = true, TrangThai = true },
                new Mau() { TenMau = "xanh lục", Id = Guid.Parse("56dd3ee2-c4df-4376-b982-e2c0f7081119"), Is_detele = true, TrangThai = true },
                new Mau() { TenMau = "xanh dương", Id = Guid.Parse("56dd3ee2-c4df-4376-b982-e2c0f7081110"), Is_detele = true, TrangThai = true },
                new Mau() { TenMau = "xanh lá", Id = Guid.Parse("56dd3ee2-c4df-4376-b982-e2c0f7081121"), Is_detele = true, TrangThai = true },
                new Mau() { TenMau = "xanh nhạt", Id = Guid.Parse("56dd3ee2-c4df-4376-b982-e2c0f7081131"), Is_detele = true, TrangThai = true },
                new Mau() { TenMau = "tràm", Id = Guid.Parse("56dd3ee2-c4df-4376-b982-e2c0f7081141"), Is_detele = true, TrangThai = true },
                new Mau() { TenMau = "tím", Id = Guid.Parse("56dd3ee2-c4df-4376-b982-e2c0f7081151"), Is_detele = true, TrangThai = true },
                new Mau() { TenMau = "xanh lá đậm", Id = Guid.Parse("56dd3ee2-c4df-4376-b982-e2c0f7081161"), Is_detele = true, TrangThai = true },
                new Mau() { TenMau = "xanh tím", Id = Guid.Parse("56dd3ee2-c4df-4376-b982-e2c0f7081171"), Is_detele = true, TrangThai = true },
                new Mau() { TenMau = "hồng", Id = Guid.Parse("56dd3ee2-c4df-4376-b982-e2c0f7081181"), Is_detele = true, TrangThai = true },
                new Mau() { TenMau = "kem", Id = Guid.Parse("56dd3ee2-c4df-4376-b982-e2c0f7081191"), Is_detele = true, TrangThai = true },
                new Mau() { TenMau = "kem Đậm", Id = Guid.Parse("56dd3ee2-c4df-4376-b982-e2c0f7081101"), Is_detele = true, TrangThai = true }
                );
            modelBuilder.Entity<KhuyenMai>().HasData(
              new KhuyenMai()
              {
                  Id = Guid.Parse("f877e80d-2b32-43b0-be70-cf3b15113056"),
                  MaKhuyenMai = "km01",
                  PhanTramGiamGia = 50,
                  NgayBatDau = Convert.ToDateTime("06/07/2023"),
                  NgayKetThuc = Convert.ToDateTime("09/11/2023"),
                  SoTienGiam = 0,
                  TrangThai = true,
                  Is_Detele = true
              },
              new KhuyenMai()
              {
                  Id = Guid.Parse("da810cca-4fca-4291-a52b-875841d49e34"),
                  MaKhuyenMai = "km02",
                  PhanTramGiamGia = 0,
                  NgayBatDau = Convert.ToDateTime("09/07/2023"),
                  NgayKetThuc = Convert.ToDateTime("09/11/2023"),
                  SoTienGiam = 50000,
                  TrangThai = true,
                  Is_Detele = true
              },
              new KhuyenMai()
              {
                  Id = Guid.Parse("23bdd26c-d7a3-4307-8e22-d230b653d611"),
                  MaKhuyenMai = "km03",
                  PhanTramGiamGia = 20,
                  NgayBatDau = Convert.ToDateTime("01/07/2023"),
                  NgayKetThuc = Convert.ToDateTime("09/11/2023"),
                  SoTienGiam = 0,
                  TrangThai = true,
                  Is_Detele = true
              },
              new KhuyenMai()
              {
                  Id = Guid.Parse("13effe44-e728-48a8-9baa-967da4ee38cd"),
                  MaKhuyenMai = "km04",
                  PhanTramGiamGia = 0,
                  NgayBatDau = Convert.ToDateTime("06/07/2023"),
                  NgayKetThuc = Convert.ToDateTime("09/08/2023"),
                  SoTienGiam = 22000,
                  TrangThai = true,
                  Is_Detele = true
              },
              new KhuyenMai()
              {
                  Id = Guid.Parse("fa1ae994-6ab0-4ee6-b8b1-ff336cf994a8"),
                  MaKhuyenMai = "km05",
                  PhanTramGiamGia = 10,
                  NgayBatDau = Convert.ToDateTime("09/09/2023"),
                  NgayKetThuc = Convert.ToDateTime("09/11/2023"),
                  SoTienGiam = 0,
                  TrangThai = true,
                  Is_Detele = true
              },
              new KhuyenMai()
              {
                  Id = Guid.Parse("e3e37e9e-7ea3-4f87-94af-1329363a4322"),
                  MaKhuyenMai = "km06",
                  PhanTramGiamGia = 25,
                  NgayBatDau = Convert.ToDateTime("08/10/2023"),
                  NgayKetThuc = Convert.ToDateTime("09/11/2023"),
                  SoTienGiam = 0,
                  TrangThai = true,
                  Is_Detele = true
              }
          );
            modelBuilder.Entity<SanPham>().HasData(
               new SanPham()
               {
                   TenSanPham = "TXT Da Rắn Khóa Bạc",
                   AnhDaiDien = "TXT Da Rắn Khóa Bạc _QuanChau_Trang_Da PU cao cấp(1).jpg",
                   Id = Guid.Parse("56dd3ee2-c4df-4376-b982-e2c0f7081211"),
                   MaSp = "SP01",
                   MoTa = "oke la",
                   GiaNhap = 400000,
                   GiaBan = 600000,
                   GiaNiemYet = 600000,
                   GhiChu = "",
                   IdChatLieu = Guid.Parse("56dd3ee2-c4df-4376-b982-e2c0f7081144"),
                   IdNSX = Guid.Parse("56dd3ee2-c4df-4376-b982-e2c0f7081124"),
                   Is_detele = true,
                   TrangThai = true
               },

                   new SanPham()
                   {
                       TenSanPham = "TXT Phủ Màu Tag Vuông",
                       AnhDaiDien = "TXT Phủ Màu Tag Vuông_QuanChau_XanhLuc_Da PU mềm mịn, cao cấp(1).jpg",
                       Id = Guid.Parse("56dd3ee2-c4df-4376-b982-e2c0f7081311"),
                       MaSp = "SP02",
                       MoTa = "oke la",
                       GiaNhap = 400000,
                       GiaBan = 600000,
                       GiaNiemYet = 600000,
                       GhiChu = "",
                       IdChatLieu = Guid.Parse("56dd3ee2-c4df-4376-b982-e2c0f7081144"),
                       IdNSX = Guid.Parse("56dd3ee2-c4df-4376-b982-e2c0f7081124"),
                       Is_detele = true,
                       TrangThai = true
                   },
                   new SanPham()
                   {
                       TenSanPham = "TDV Hobo Đáy Tròn",
                       AnhDaiDien = "TDV Hobo Đáy Tròn_QuanChau_Xanh-Duong_Da lộn, da PU cao cấp_Dài 22 x Cao 12 x Rộng 6 (cm)(1).jpg",
                       Id = Guid.Parse("56dd3ee2-c4df-4376-b982-e2c0f7081411"),
                       MaSp = "SP03",
                       MoTa = "oke la",
                       GiaNhap = 400000,
                       GiaBan = 600000,
                       GiaNiemYet = 600000,
                       GhiChu = "",
                       IdChatLieu = Guid.Parse("56dd3ee2-c4df-4376-b982-e2c0f7081144"),
                       IdNSX = Guid.Parse("56dd3ee2-c4df-4376-b982-e2c0f7081124"),
                       Is_detele = true,
                       TrangThai = true
                   }, new SanPham()
                   {
                       TenSanPham = "TDV Hobo Quai Ngắn",
                       AnhDaiDien = "TDV Hobo Quai Ngắn_QuanChau_Ghi_Da PU mềm mịn, cao cấp_Dài 27 x Rộng 6 x Cao 19 (cm)(1).jpg",
                       Id = Guid.Parse("56dd3ee2-c4df-4376-b982-e2c0f7081511"),
                       MaSp = "SP04",
                       MoTa = "oke la",
                       GiaNhap = 400000,
                       GiaBan = 600000,
                       GiaNiemYet = 600000,
                       GhiChu = "",
                       IdChatLieu = Guid.Parse("56dd3ee2-c4df-4376-b982-e2c0f7081144"),
                       IdNSX = Guid.Parse("56dd3ee2-c4df-4376-b982-e2c0f7081124"),
                       Is_detele = true,
                       TrangThai = true
                   }, new SanPham()
                   {
                       TenSanPham = "TOT Classic Phối Màu",
                       AnhDaiDien = "TOT Classic Phối Màu _QuanChau_Den_Da PU mềm mịn, cao cấp_Dài 20 x Rộng 13.5 x Cao 7.5 (cm)(1).jpg",
                       Id = Guid.Parse("56dd3ee2-c4df-4376-b982-e2c0f7081611"),
                       MaSp = "SP05",
                       MoTa = "oke la",
                       GiaNhap = 400000,
                       GiaBan = 600000,
                       GiaNiemYet = 600000,
                       GhiChu = "",
                       IdChatLieu = Guid.Parse("56dd3ee2-c4df-4376-b982-e2c0f7081144"),
                       IdNSX = Guid.Parse("56dd3ee2-c4df-4376-b982-e2c0f7081124"),
                       Is_detele = true,
                       TrangThai = true
                   }
            );
            modelBuilder.Entity<KhuyenMai>().HasData(
                new KhuyenMai() {
                    Id = Guid.Parse("f877e80d-2b32-43b0-be70-cf3b15113056"), 
                    MaKhuyenMai = "km01", 
                    PhanTramGiamGia = 50,
                    NgayBatDau = Convert.ToDateTime("06/07/2023"),
                    NgayKetThuc = Convert.ToDateTime("09/11/2023"),
                    SoTienGiam = 0,
                    TrangThai = true, 
                    Is_Detele = true 
                },
                new KhuyenMai()
                {
                    Id = Guid.Parse("da810cca-4fca-4291-a52b-875841d49e34"),
                    MaKhuyenMai = "km02",
                    PhanTramGiamGia = 0,
                    NgayBatDau = Convert.ToDateTime("09/07/2023"),
                    NgayKetThuc = Convert.ToDateTime("09/11/2023"),
                    SoTienGiam = 50000,
                    TrangThai = true,
                    Is_Detele = true
                },
                new KhuyenMai()
                {
                    Id = Guid.Parse("23bdd26c-d7a3-4307-8e22-d230b653d611"),
                    MaKhuyenMai = "km03",
                    PhanTramGiamGia = 20,
                    NgayBatDau = Convert.ToDateTime("01/07/2023"),
                    NgayKetThuc = Convert.ToDateTime("09/11/2023"),
                    SoTienGiam = 0,
                    TrangThai = true,
                    Is_Detele = true
                },
                new KhuyenMai()
                {
                    Id = Guid.Parse("13effe44-e728-48a8-9baa-967da4ee38cd"),
                    MaKhuyenMai = "km04",
                    PhanTramGiamGia = 0,
                    NgayBatDau = Convert.ToDateTime("06/07/2023"),
                    NgayKetThuc = Convert.ToDateTime("09/08/2023"),
                    SoTienGiam = 22000,
                    TrangThai = true,
                    Is_Detele = true
                },
                new KhuyenMai()
                {
                    Id = Guid.Parse("fa1ae994-6ab0-4ee6-b8b1-ff336cf994a8"),
                    MaKhuyenMai = "km05",
                    PhanTramGiamGia = 10,
                    NgayBatDau = Convert.ToDateTime("09/09/2023"),
                    NgayKetThuc = Convert.ToDateTime("09/11/2023"),
                    SoTienGiam = 0,
                    TrangThai = true,
                    Is_Detele = true
                },
                new KhuyenMai()
                {
                    Id = Guid.Parse("e3e37e9e-7ea3-4f87-94af-1329363a4322"),
                    MaKhuyenMai = "km06",
                    PhanTramGiamGia = 25,
                    NgayBatDau = Convert.ToDateTime("08/10/2023"),
                    NgayKetThuc = Convert.ToDateTime("09/11/2023"),
                    SoTienGiam = 0,
                    TrangThai = true,
                    Is_Detele = true
                }
            );
            modelBuilder.Entity<NSX>().HasData(
                new NSX() { TenNSX = "Juno", Id = Guid.Parse("56dd3ee2-c4df-4376-b982-e2c0f7081124"), GhiChu = "", Is_detele = true, TrangThai = true },
                new NSX() { TenNSX = "Prada", Id = Guid.Parse("56dd3ee2-c4df-4376-b982-e2c0f7081125"), GhiChu = "", Is_detele = true, TrangThai = true },
                new NSX() { TenNSX = "Gucci", Id = Guid.Parse("56dd3ee2-c4df-4376-b982-e2c0f7081126"), GhiChu = "", Is_detele = true, TrangThai = true },
                new NSX() { TenNSX = "Chanel", Id = Guid.Parse("56dd3ee2-c4df-4376-b982-e2c0f7081127"), GhiChu = "", Is_detele = true, TrangThai = true },
                new NSX() { TenNSX = "Coach", Id = Guid.Parse("56dd3ee2-c4df-4376-b982-e2c0f7081128"), GhiChu = "", Is_detele = true, TrangThai = true },
                new NSX() { TenNSX = "MLB Korea", Id = Guid.Parse("56dd3ee2-c4df-4376-b982-e2c0f7081129"), GhiChu = "", Is_detele = true, TrangThai = true },
                new NSX() { TenNSX = "Michael Kors", Id = Guid.Parse("56dd3ee2-c4df-4376-b982-e2c0f7081133"), GhiChu = "", Is_detele = true, TrangThai = true },
                new NSX() { TenNSX = "JW Anderson", Id = Guid.Parse("56dd3ee2-c4df-4376-b982-e2c0f7081134"), GhiChu = "", Is_detele = true, TrangThai = true },
                new NSX() { TenNSX = "Christian Dior", Id = Guid.Parse("56dd3ee2-c4df-4376-b982-e2c0f7081135"), GhiChu = "", Is_detele = true, TrangThai = true },
                new NSX() { TenNSX = "Louis Vuitton", Id = Guid.Parse("56dd3ee2-c4df-4376-b982-e2c0f7081136"), GhiChu = "", Is_detele = true, TrangThai = true }
            );
            modelBuilder.Entity<ChatLieu>().HasData(
                new ChatLieu() { TenChatLieu = "Da PU cao cấp", Id = Guid.Parse("56dd3ee2-c4df-4376-b982-e2c0f7081137"), GhiChu = "", Is_detele = true, TrangThai = true },
                new ChatLieu() { TenChatLieu = "Da PU mềm mịn, cao cấp", Id = Guid.Parse("56dd3ee2-c4df-4376-b982-e2c0f7081138"), GhiChu = "", Is_detele = true, TrangThai = true },
                new ChatLieu() { TenChatLieu = "Vai Canvat", Id = Guid.Parse("56dd3ee2-c4df-4376-b982-e2c0f7081139"), GhiChu = "", Is_detele = true, TrangThai = true },
                new ChatLieu() { TenChatLieu = "Da tổng hợp", Id = Guid.Parse("56dd3ee2-c4df-4376-b982-e2c0f7081144"), GhiChu = "", Is_detele = true, TrangThai = true }
                //new ChatLieu() { TenChatLieu = "Tricot (Vải dệt kim)", Id = Guid.Parse("56dd3ee2-c4df-4376-b982-e2c0f7081111"), GhiChu = "", Is_detele = true, TrangThai = true },
                //new ChatLieu() { TenChatLieu = "Vải không dệt (Micro Polyester)", Id = Guid.Parse("56dd3ee2-c4df-4376-b982-e2c0f7081111"), GhiChu = "", Is_detele = true, TrangThai = true },
                //new ChatLieu() { TenChatLieu = "Vải Simili (Giả da)", Id = Guid.Parse("56dd3ee2-c4df-4376-b982-e2c0f7081111"), GhiChu = "", Is_detele = true, TrangThai = true }
            );
            modelBuilder.Entity<Size>().HasData(
                new Size() { TenSize = "15cm x 9.5cm x 7cm", CoSize = "S", Id = Guid.Parse("56dd3ee2-c4df-4376-b982-e2c0f7081146"), Is_detele = true, TrangThai = true },
                new Size() { TenSize = "20cm x 12cm x 7cm", CoSize = "M", Id = Guid.Parse("56dd3ee2-c4df-4376-b982-e2c0f7081147"), Is_detele = true, TrangThai = true },
                new Size() { TenSize = "25cm x 14.5cm x 8cm", CoSize = "OM", Id = Guid.Parse("56dd3ee2-c4df-4376-b982-e2c0f7081148"), Is_detele = true, TrangThai = true },
                new Size() { TenSize = "30cm x 21cm x 10cm", CoSize = "L", Id = Guid.Parse("56dd3ee2-c4df-4376-b982-e2c0f7081149"), Is_detele = true, TrangThai = true }


            );
            modelBuilder.Entity<DanhMuc>().HasData(
                new DanhMuc() { TenDanhMuc = "Túi đeo chéo Nữ – Cross body", Id = Guid.Parse("56dd3ee2-c4df-4376-b982-e2c0f7081163"), Is_detele = true },
                new DanhMuc() { TenDanhMuc = "Túi đeo vai – Shoulder bag", Id = Guid.Parse("56dd3ee2-c4df-4376-b982-e2c0f7081164"), Is_detele = true },
                new DanhMuc() { TenDanhMuc = "Túi tote", Id = Guid.Parse("56dd3ee2-c4df-4376-b982-e2c0f4381111"), Is_detele = true },
                new DanhMuc() { TenDanhMuc = "Túi satchel", Id = Guid.Parse("56dd3ee2-c4df-4376-b982-e2c0f7081165"), Is_detele = true },
                new DanhMuc() { TenDanhMuc = "Túi baguette", Id = Guid.Parse("56dd3ee2-c4df-4376-b982-e2c0f7081166"), Is_detele = true },
                new DanhMuc() { TenDanhMuc = "Túi bao tử – Túi bumbag", Id = Guid.Parse("56dd3ee2-c4df-4376-b982-e2c0f7081167"), Is_detele = true },
                new DanhMuc() { TenDanhMuc = "Túi cầm tay – Clutch", Id = Guid.Parse("56dd3ee2-c4df-4376-b982-e2c0f7081168"), Is_detele = true },
                new DanhMuc() { TenDanhMuc = "Túi Hobo", Id = Guid.Parse("56dd3ee2-c4df-4376-b982-e2c0f7089111"), Is_detele = true },
                new DanhMuc() { TenDanhMuc = "Túi dây rút – Pouch", Id = Guid.Parse("56dd3ee2-c4df-4376-b982-e2c0f7081169"), Is_detele = true },
                new DanhMuc() { TenDanhMuc = "Túi Bucket", Id = Guid.Parse("56dd3ee2-c4df-4376-b982-e2c0f7081170"), Is_detele = true },
                new DanhMuc() { TenDanhMuc = "Túi Bowling", Id = Guid.Parse("56dd3ee2-c4df-4376-b982-e2c0f7081171"), Is_detele = true },
                new DanhMuc() { TenDanhMuc = "Túi Ring Bag", Id = Guid.Parse("56dd3ee2-c4df-4376-b982-e2c0f7081172"), Is_detele = true }
            );
            modelBuilder.Entity<ChucVu>().HasData(
                new ChucVu() { TenChucVu = "Quản lý", Id = Guid.Parse("d16ac357-3ced-4c2c-bcdc-d38971214414"), TrangThai = true },
                new ChucVu() { TenChucVu = "Nhân viên", Id = Guid.Parse("56dd3ee2-c4df-4376-b982-e2c0f70877e9"), TrangThai = true }
            );
            modelBuilder.Entity<PhuongThucThanhToan>().HasData(
                new PhuongThucThanhToan() { TenPhuongThuc = "Thanh toán khi nhận hàng", Id = Guid.Parse("d16ac357-3ced-4c2c-bcdc-d38971211111"), TrangThai = true, Is_detele = true },
                //new PhuongThucThanhToan() { TenPhuongThuc = "Thanh toán tại cửa hàng", Id = Guid.Parse("d16ac357-3ced-4c2c-bcdc-d38971211112"), TrangThai = true, Is_detele = true },
                //new PhuongThucThanhToan() { TenPhuongThuc = "Thanh toán qua ngân hàng", Id = Guid.Parse("d16ac357-3ced-4c2c-bcdc-d38971211113"), TrangThai = true, Is_detele = true },
                new PhuongThucThanhToan() { TenPhuongThuc = "Thanh toán qua VNpay", Id = Guid.Parse("d16ac357-3ced-4c2c-bcdc-d38971211114"), TrangThai = true, Is_detele = true }
            );
            modelBuilder.Entity<NhanVien>().HasData(
                new NhanVien()
                {
                    Ho = "Nguyễn",
                    Ten = "Trang",
                    Id = Guid.Parse("56dd3ee2-c4df-4376-b982-e2c0f7081173"),
                    TenDangNhap = "trangnt34",
                    SDT = "0912384746",
                    AnhDaiDien = "",
                    MatKhau = "12345678",
                    GioiTinh = "Nữ",
                    DiaChi = "Hà Nội",
                    Email = "nothing@gmail.com",
                    Trangthai = true,
                    IdChucVu = Guid.Parse("d16ac357-3ced-4c2c-bcdc-d38971214414")
                }, new NhanVien()
                {
                    Ho = "Cao",
                    Ten = "Toan",
                    Id = Guid.Parse("56dd3ee2-c4df-4376-b982-e2c0f7081174"),
                    TenDangNhap = "1",
                    SDT = "0912384746",
                    AnhDaiDien = "",
                    MatKhau = "1",
                    GioiTinh = "Nam",
                    DiaChi = "Hà Nội",
                    Email = "nothing@gmail.com",
                    Trangthai = true,
                    IdChucVu = Guid.Parse("d16ac357-3ced-4c2c-bcdc-d38971214414")
                }
            );
            modelBuilder.Entity<KhachHang>().HasData(
                new KhachHang()
                {
                    Ho = "Bùi Văm",
                    Ten = "Thiều",
                    Id = Guid.Parse("d16ac357-3ced-4c2c-bcdc-d38971214499"),
                    TenDangNhap = "thieuxk",
                    SDT = "0912384746",
                    AnhDaiDien = "",
                    MatKhau = "thieuxk",
                    GioiTinh = "Nam",
                    DiaChi = "Hà Nội",
                    Email = "thieubvph20221@gmail.com",
                    Trangthai = true,
                    Is_detele = true
                }
            );
            modelBuilder.Entity<SanPhamChiTiet>().HasData(
               new SanPhamChiTiet()
               {//// size S
                   Id = Guid.Parse("42d4f7d5-0499-4df5-926f-ccce5fbb6010"),
                   SoLuong = 100,
                   IdSp = Guid.Parse("56dd3ee2-c4df-4376-b982-e2c0f7081211"),
                   IdMau = Guid.Parse("56dd3ee2-c4df-4376-b982-e2c0f7081112"),
                   IdSize = Guid.Parse("56dd3ee2-c4df-4376-b982-e2c0f7081146"),
                   TrangThai = true,
                   Is_detele = true,
               }, new SanPhamChiTiet()
               {
                   Id = Guid.Parse("42d4f7d5-0499-4df5-926f-ccce5fbb6011"),
                   SoLuong = 100,
                   IdSp = Guid.Parse("56dd3ee2-c4df-4376-b982-e2c0f7081211"),
                   IdMau = Guid.Parse("56dd3ee2-c4df-4376-b982-e2c0f7081111"),
                   IdSize = Guid.Parse("56dd3ee2-c4df-4376-b982-e2c0f7081146"),
                   TrangThai = true,
                   Is_detele = true,
               }, new SanPhamChiTiet()
               {
                   Id = Guid.Parse("42d4f7d5-0499-4df5-926f-ccce5fbb6012"),
                   SoLuong = 100,
                   IdSp = Guid.Parse("56dd3ee2-c4df-4376-b982-e2c0f7081211"),
                   IdMau = Guid.Parse("56dd3ee2-c4df-4376-b982-e2c0f7081113"),
                   IdSize = Guid.Parse("56dd3ee2-c4df-4376-b982-e2c0f7081146"),
                   TrangThai = true,
                   Is_detele = true,
               }, ///// size M
                  new SanPhamChiTiet()
                  {
                      Id = Guid.Parse("42d4f7d5-0499-4df5-926f-ccce5fbb6013"),
                      SoLuong = 100,
                      IdSp = Guid.Parse("56dd3ee2-c4df-4376-b982-e2c0f7081211"),
                      IdMau = Guid.Parse("56dd3ee2-c4df-4376-b982-e2c0f7081112"),
                      IdSize = Guid.Parse("56dd3ee2-c4df-4376-b982-e2c0f7081147"),
                      TrangThai = true,
                      Is_detele = true,
                  }, new SanPhamChiTiet()
                  {
                      Id = Guid.Parse("42d4f7d5-0499-4df5-926f-ccce5fbb6014"),
                      SoLuong = 100,
                      IdSp = Guid.Parse("56dd3ee2-c4df-4376-b982-e2c0f7081211"),
                      IdMau = Guid.Parse("56dd3ee2-c4df-4376-b982-e2c0f7081111"),
                      IdSize = Guid.Parse("56dd3ee2-c4df-4376-b982-e2c0f7081147"),
                      TrangThai = true,
                      Is_detele = true,
                  }, new SanPhamChiTiet()
                  {
                      Id = Guid.Parse("42d4f7d5-0499-4df5-926f-ccce5fbb6015"),
                      SoLuong = 100,
                      IdSp = Guid.Parse("56dd3ee2-c4df-4376-b982-e2c0f7081211"),
                      IdMau = Guid.Parse("56dd3ee2-c4df-4376-b982-e2c0f7081113"),
                      IdSize = Guid.Parse("56dd3ee2-c4df-4376-b982-e2c0f7081147"),
                      TrangThai = true,
                      Is_detele = true,
                  },///// Size OM
                  new SanPhamChiTiet()
                  {
                      Id = Guid.Parse("42d4f7d5-0499-4df5-926f-ccce5fbb6016"),
                      SoLuong = 100,
                      IdSp = Guid.Parse("56dd3ee2-c4df-4376-b982-e2c0f7081211"),
                      IdMau = Guid.Parse("56dd3ee2-c4df-4376-b982-e2c0f7081111"),
                      IdSize = Guid.Parse("56dd3ee2-c4df-4376-b982-e2c0f7081148"),
                      TrangThai = true,
                      Is_detele = true,
                  }, new SanPhamChiTiet()
                  {
                      Id = Guid.Parse("42d4f7d5-0499-4df5-926f-ccce5fbb6017"),
                      SoLuong = 100,
                      IdSp = Guid.Parse("56dd3ee2-c4df-4376-b982-e2c0f7081211"),
                      IdMau = Guid.Parse("56dd3ee2-c4df-4376-b982-e2c0f7081113"),
                      IdSize = Guid.Parse("56dd3ee2-c4df-4376-b982-e2c0f7081148"),
                      TrangThai = true,
                      Is_detele = true,
                  }, new SanPhamChiTiet()
                  {
                      Id = Guid.Parse("42d4f7d5-0499-4df5-926f-ccce5fbb6018"),
                      SoLuong = 100,
                      IdSp = Guid.Parse("56dd3ee2-c4df-4376-b982-e2c0f7081211"),
                      IdMau = Guid.Parse("56dd3ee2-c4df-4376-b982-e2c0f7081114"),
                      IdSize = Guid.Parse("56dd3ee2-c4df-4376-b982-e2c0f7081148"),
                      TrangThai = true,
                      Is_detele = true,
                  },//////// sp 2 ///// size S
                  new SanPhamChiTiet()
                  {
                      Id = Guid.Parse("42d4f7d5-0499-4df5-926f-ccce5fbb6019"),
                      SoLuong = 100,
                      IdSp = Guid.Parse("56dd3ee2-c4df-4376-b982-e2c0f7081311"),
                      IdMau = Guid.Parse("56dd3ee2-c4df-4376-b982-e2c0f7081111"),
                      IdSize = Guid.Parse("56dd3ee2-c4df-4376-b982-e2c0f7081146"),
                      TrangThai = true,
                      Is_detele = true,
                  }, new SanPhamChiTiet()
                  {
                      Id = Guid.Parse("42d4f7d5-0499-4df5-926f-ccce5fbb6020"),
                      SoLuong = 100,
                      IdSp = Guid.Parse("56dd3ee2-c4df-4376-b982-e2c0f7081311"),
                      IdMau = Guid.Parse("56dd3ee2-c4df-4376-b982-e2c0f7081151"),
                      IdSize = Guid.Parse("56dd3ee2-c4df-4376-b982-e2c0f7081146"),
                      TrangThai = true,
                      Is_detele = true,
                  }, new SanPhamChiTiet()
                  {
                      Id = Guid.Parse("42d4f7d5-0499-4df5-926f-ccce5fbb6021"),
                      SoLuong = 100,
                      IdSp = Guid.Parse("56dd3ee2-c4df-4376-b982-e2c0f7081311"),
                      IdMau = Guid.Parse("56dd3ee2-c4df-4376-b982-e2c0f7081113"),
                      IdSize = Guid.Parse("56dd3ee2-c4df-4376-b982-e2c0f7081146"),
                      TrangThai = true,
                      Is_detele = true,
                  },///////// Size M
                  new SanPhamChiTiet()
                  {
                      Id = Guid.Parse("42d4f7d5-0499-4df5-926f-ccce5fbb6022"),
                      SoLuong = 100,
                      IdSp = Guid.Parse("56dd3ee2-c4df-4376-b982-e2c0f7081311"),
                      IdMau = Guid.Parse("56dd3ee2-c4df-4376-b982-e2c0f7081111"),
                      IdSize = Guid.Parse("56dd3ee2-c4df-4376-b982-e2c0f7081147"),
                      TrangThai = true,
                      Is_detele = true,
                  }, new SanPhamChiTiet()
                  {
                      Id = Guid.Parse("42d4f7d5-0499-4df5-926f-ccce5fbb6023"),
                      SoLuong = 100,
                      IdSp = Guid.Parse("56dd3ee2-c4df-4376-b982-e2c0f7081311"),
                      IdMau = Guid.Parse("56dd3ee2-c4df-4376-b982-e2c0f7081151"),
                      IdSize = Guid.Parse("56dd3ee2-c4df-4376-b982-e2c0f7081147"),
                      TrangThai = true,
                      Is_detele = true,
                  }, new SanPhamChiTiet()
                  {
                      Id = Guid.Parse("42d4f7d5-0499-4df5-926f-ccce5fbb6024"),
                      SoLuong = 100,
                      IdSp = Guid.Parse("56dd3ee2-c4df-4376-b982-e2c0f7081311"),
                      IdMau = Guid.Parse("56dd3ee2-c4df-4376-b982-e2c0f7081113"),
                      IdSize = Guid.Parse("56dd3ee2-c4df-4376-b982-e2c0f7081147"),
                      TrangThai = true,
                      Is_detele = true,
                  },//////// Size OM
                  new SanPhamChiTiet()
                  {
                      Id = Guid.Parse("42d4f7d5-0499-4df5-926f-ccce5fbb6025"),
                      SoLuong = 100,
                      IdSp = Guid.Parse("56dd3ee2-c4df-4376-b982-e2c0f7081311"),
                      IdMau = Guid.Parse("56dd3ee2-c4df-4376-b982-e2c0f7081111"),
                      IdSize = Guid.Parse("56dd3ee2-c4df-4376-b982-e2c0f7081148"),
                      TrangThai = true,
                      Is_detele = true,
                  }, new SanPhamChiTiet()
                  {
                      Id = Guid.Parse("42d4f7d5-0499-4df5-926f-ccce5fbb6026"),
                      SoLuong = 100,
                      IdSp = Guid.Parse("56dd3ee2-c4df-4376-b982-e2c0f7081311"),
                      IdMau = Guid.Parse("56dd3ee2-c4df-4376-b982-e2c0f7081113"),
                      IdSize = Guid.Parse("56dd3ee2-c4df-4376-b982-e2c0f7081148"),
                      TrangThai = true,
                      Is_detele = true,
                  }, new SanPhamChiTiet()
                  {
                      Id = Guid.Parse("42d4f7d5-0499-4df5-926f-ccce5fbb6027"),
                      SoLuong = 100,
                      IdSp = Guid.Parse("56dd3ee2-c4df-4376-b982-e2c0f7081311"),
                      IdMau = Guid.Parse("56dd3ee2-c4df-4376-b982-e2c0f7081151"),
                      IdSize = Guid.Parse("56dd3ee2-c4df-4376-b982-e2c0f7081148"),
                      TrangThai = true,
                      Is_detele = true,
                  }, //////////// Size L
                  new SanPhamChiTiet()
                  {
                      Id = Guid.Parse("42d4f7d5-0499-4df5-926f-ccce5fbb6028"),
                      SoLuong = 100,
                      IdSp = Guid.Parse("56dd3ee2-c4df-4376-b982-e2c0f7081311"),
                      IdMau = Guid.Parse("56dd3ee2-c4df-4376-b982-e2c0f7081151"),
                      IdSize = Guid.Parse("56dd3ee2-c4df-4376-b982-e2c0f7081149"),
                      TrangThai = true,
                      Is_detele = true,
                  }, new SanPhamChiTiet()
                  {
                      Id = Guid.Parse("42d4f7d5-0499-4df5-926f-ccce5fbb6029"),
                      SoLuong = 100,
                      IdSp = Guid.Parse("56dd3ee2-c4df-4376-b982-e2c0f7081311"),
                      IdMau = Guid.Parse("56dd3ee2-c4df-4376-b982-e2c0f7081113"),
                      IdSize = Guid.Parse("56dd3ee2-c4df-4376-b982-e2c0f7081149"),
                      TrangThai = true,
                      Is_detele = true,
                  }, new SanPhamChiTiet()
                  {
                      Id = Guid.Parse("42d4f7d5-0499-4df5-926f-ccce5fbb6030"),
                      SoLuong = 100,
                      IdSp = Guid.Parse("56dd3ee2-c4df-4376-b982-e2c0f7081311"),
                      IdMau = Guid.Parse("56dd3ee2-c4df-4376-b982-e2c0f7081111"),
                      IdSize = Guid.Parse("56dd3ee2-c4df-4376-b982-e2c0f7081149"),
                      TrangThai = true,
                      Is_detele = true,
                  },/////////// Sp 3 /////// Size S
                  new SanPhamChiTiet()
                  {
                      Id = Guid.Parse("42d4f7d5-0499-4df5-926f-ccce5fbb6031"),
                      SoLuong = 100,
                      IdSp = Guid.Parse("56dd3ee2-c4df-4376-b982-e2c0f7081511"),
                      IdMau = Guid.Parse("56dd3ee2-c4df-4376-b982-e2c0f7081111"),
                      IdSize = Guid.Parse("56dd3ee2-c4df-4376-b982-e2c0f7081146"),
                      TrangThai = true,
                      Is_detele = true,
                  }, new SanPhamChiTiet()
                  {
                      Id = Guid.Parse("42d4f7d5-0499-4df5-926f-ccce5fbb6032"),
                      SoLuong = 100,
                      IdSp = Guid.Parse("56dd3ee2-c4df-4376-b982-e2c0f7081511"),
                      IdMau = Guid.Parse("56dd3ee2-c4df-4376-b982-e2c0f7081112"),
                      IdSize = Guid.Parse("56dd3ee2-c4df-4376-b982-e2c0f7081146"),
                      TrangThai = true,
                      Is_detele = true,
                  },////////// Size M
                  new SanPhamChiTiet()
                  {
                      Id = Guid.Parse("42d4f7d5-0499-4df5-926f-ccce5fbb6033"),
                      SoLuong = 100,
                      IdSp = Guid.Parse("56dd3ee2-c4df-4376-b982-e2c0f7081511"),
                      IdMau = Guid.Parse("56dd3ee2-c4df-4376-b982-e2c0f7081111"),
                      IdSize = Guid.Parse("56dd3ee2-c4df-4376-b982-e2c0f7081147"),
                      TrangThai = true,
                      Is_detele = true,
                  },
                  new SanPhamChiTiet()
                  {
                      Id = Guid.Parse("42d4f7d5-0499-4df5-926f-ccce5fbb6034"),
                      SoLuong = 100,
                      IdSp = Guid.Parse("56dd3ee2-c4df-4376-b982-e2c0f7081511"),
                      IdMau = Guid.Parse("56dd3ee2-c4df-4376-b982-e2c0f7081112"),
                      IdSize = Guid.Parse("56dd3ee2-c4df-4376-b982-e2c0f7081147"),
                      TrangThai = true,
                      Is_detele = true,
                  },////////// Size OM
                  new SanPhamChiTiet()
                  {
                      Id = Guid.Parse("42d4f7d5-0499-4df5-926f-ccce5fbb6035"),
                      SoLuong = 100,
                      IdSp = Guid.Parse("56dd3ee2-c4df-4376-b982-e2c0f7081511"),
                      IdMau = Guid.Parse("56dd3ee2-c4df-4376-b982-e2c0f7081111"),
                      IdSize = Guid.Parse("56dd3ee2-c4df-4376-b982-e2c0f7081148"),
                      TrangThai = true,
                      Is_detele = true,
                  },
                  new SanPhamChiTiet()
                  {
                      Id = Guid.Parse("42d4f7d5-0499-4df5-926f-ccce5fbb6036"),
                      SoLuong = 100,
                      IdSp = Guid.Parse("56dd3ee2-c4df-4376-b982-e2c0f7081511"),
                      IdMau = Guid.Parse("56dd3ee2-c4df-4376-b982-e2c0f7081112"),
                      IdSize = Guid.Parse("56dd3ee2-c4df-4376-b982-e2c0f7081148"),
                      TrangThai = true,
                      Is_detele = true,
                  },/////////////// Size L
                  new SanPhamChiTiet()
                  {
                      Id = Guid.Parse("42d4f7d5-0499-4df5-926f-ccce5fbb6037"),
                      SoLuong = 100,
                      IdSp = Guid.Parse("56dd3ee2-c4df-4376-b982-e2c0f7081511"),
                      IdMau = Guid.Parse("56dd3ee2-c4df-4376-b982-e2c0f7081111"),
                      IdSize = Guid.Parse("56dd3ee2-c4df-4376-b982-e2c0f7081149"),
                      TrangThai = true,
                      Is_detele = true,
                  },
                  new SanPhamChiTiet()
                  {
                      Id = Guid.Parse("42d4f7d5-0499-4df5-926f-ccce5fbb6038"),
                      SoLuong = 100,
                      IdSp = Guid.Parse("56dd3ee2-c4df-4376-b982-e2c0f7081511"),
                      IdMau = Guid.Parse("56dd3ee2-c4df-4376-b982-e2c0f7081112"),
                      IdSize = Guid.Parse("56dd3ee2-c4df-4376-b982-e2c0f7081149"),
                      TrangThai = true,
                      Is_detele = true,
                  }
          );
        }
    }
}
