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
            //modelBuilder.Entity<SanPham>().HasData(
            //   new SanPham() { TenSanPham = "TXT Da Rắn Khóa Bạc _QuanChau_Trang_Da PU cao cấp(1)", AnhDaiDien = "TXT Da Rắn Khóa Bạc _QuanChau_Trang_Da PU cao cấp(1).jpg", Id = Guid.Parse("56dd3ee2-c4df-4376-b982-e2c0f7081211"), Is_detele = true, TrangThai = true },
            //   new SanPham() { TenSanPham = "TXT Phủ Màu Tag Vuông_QuanChau_XanhLuc_Da PU mềm mịn, cao cấp(1)", AnhDaiDien = "TXT Phủ Màu Tag Vuông_QuanChau_XanhLuc_Da PU mềm mịn, cao cấp(1).jpg", Id = Guid.Parse("56dd3ee2-c4df-4376-b982-e2c0f7081311"), Is_detele = true, TrangThai = true },
            //   new SanPham() { TenSanPham = "TDV Hobo Đáy Tròn_QuanChau_Trang_Da lộn, da PU cao cấp(1)", AnhDaiDien = "TDV Hobo Đáy Tròn_QuanChau_Trang_Da lộn, da PU cao cấp(1).jpg", Id = Guid.Parse("56dd3ee2-c4df-4376-b982-e2c0f7081411"), Is_detele = true, TrangThai = true },
            //   new SanPham() { TenSanPham = "Túi Xách Nhỏ Curve 1_Trung Quốc_Xanhduong_Da tổng hợp(1)", AnhDaiDien = "Túi Xách Nhỏ Curve 1_Trung Quốc_Xanhduong_Da tổng hợp(1).webp", Id = Guid.Parse("56dd3ee2-c4df-4376-b982-e2c0f7081511"), Is_detele = true, TrangThai = true },
            //   new SanPham() { TenSanPham = "TDV Hobo Đáy Tròn_QuanChau_Xanh-Duong_Da lộn, da PU cao cấp(1)", AnhDaiDien = "TDV Hobo Đáy Tròn_QuanChau_Xanh-Duong_Da lộn, da PU cao cấp(1).jpg", Id = Guid.Parse("56dd3ee2-c4df-4376-b982-e2c0f7081611"), Is_detele = true, TrangThai = true },
            //   new SanPham() { TenSanPham = "TOT Classic Phối Màu _QuanChau_Ghi_Da PU mềm mịn, cao cấp(1)", AnhDaiDien = "TOT Classic Phối Màu _QuanChau_Ghi_Da PU mềm mịn, cao cấp(1).jpg", Id = Guid.Parse("56dd3ee2-c4df-4376-b982-e2c0f7081711"), Is_detele = true, TrangThai = true },
            //   new SanPham() { TenSanPham = "TOT Classic Phối Màu _QuanChau_Nau_Da PU mềm mịn, cao cấp(1)", AnhDaiDien = "TOT Classic Phối Màu _QuanChau_Nau_Da PU mềm mịn, cao cấp(1).jpg", Id = Guid.Parse("56dd3ee2-c4df-4376-b982-e2c0f7081811"), Is_detele = true, TrangThai = true },
            //   new SanPham() { TenSanPham = "Túi Xách Nhỏ Curve 1_Trung Quốc_XanhLa_Da tổng hợp(1)", AnhDaiDien = "Túi Xách Nhỏ Curve 1_Trung Quốc_XanhLa_Da tổng hợp(1).webp", Id = Guid.Parse("56dd3ee2-c4df-4376-b982-e2c0f7081911"), Is_detele = true, TrangThai = true },
            //   new SanPham() { TenSanPham = "Túi Xách Nhỏ Đeo Vai - Cycling_Trung Quốc_XanhNhat_Da tổng hợp(1)", AnhDaiDien = "Túi Xách Nhỏ Đeo Vai - Cycling_Trung Quốc_XanhNhat_Da tổng hợp(1).webp", Id = Guid.Parse("56dd3ee2-c4df-4376-b982-e2c0f7081122"), Is_detele = true, TrangThai = true },
            //   new SanPham() { TenSanPham = "TDV Hobo Quai Ngắn_QuanChau_Trang_Da PU mềm mịn, cao cấp(1)", AnhDaiDien = "TDV Hobo Quai Ngắn_QuanChau_Trang_Da PU mềm mịn, cao cấp(1).jpg", Id = Guid.Parse("56dd3ee2-c4df-4376-b982-e2c0f7081123"), Is_detele = true, TrangThai = true }
            //);
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
                new Size() { TenSize = "30cm x 20cm x 10cm", Id = Guid.Parse("56dd3ee2-c4df-4376-b982-e2c0f7081146"), Is_detele = true, TrangThai = true },
                new Size() { TenSize = "28cm x 22cm x 10cm", Id = Guid.Parse("56dd3ee2-c4df-4376-b982-e2c0f7081147"), Is_detele = true, TrangThai = true },
                new Size() { TenSize = "27cm x 12cm x 8cm", Id = Guid.Parse("56dd3ee2-c4df-4376-b982-e2c0f7081148"), Is_detele = true, TrangThai = true },
                new Size() { TenSize = "23cm x 13cm x 6cm", Id = Guid.Parse("56dd3ee2-c4df-4376-b982-e2c0f7081149"), Is_detele = true, TrangThai = true },
                new Size() { TenSize = "23cm x 15cm x 5cm", Id = Guid.Parse("56dd3ee2-c4df-4376-b982-e2c0f7081150"), Is_detele = true, TrangThai = true },
                new Size() { TenSize = "22cm x 18cm x 8cm", Id = Guid.Parse("56dd3ee2-c4df-4376-b982-e2c0f7081152"), Is_detele = true, TrangThai = true },
                new Size() { TenSize = "20cm x 12cm x 7cm", Id = Guid.Parse("56dd3ee2-c4df-4376-b982-e2c0f7081153"), Is_detele = true, TrangThai = true },
                new Size() { TenSize = "22cm x 15cm x 6cm", Id = Guid.Parse("56dd3ee2-c4df-4376-b982-e2c0f7081154"), Is_detele = true, TrangThai = true },
                new Size() { TenSize = "17cm x 16cm x 7cm", Id = Guid.Parse("56dd3ee2-c4df-4376-b982-e2c0f7081155"), Is_detele = true, TrangThai = true },
                new Size() { TenSize = "22cm x 12cm x 6cm", Id = Guid.Parse("56dd3ee2-c4df-4376-b982-e2c0f7081156"), Is_detele = true, TrangThai = true },
                new Size() { TenSize = "21cm x 8cm x 13cm", Id = Guid.Parse("56dd3ee2-c4df-4376-b982-e2c0f7081157"), Is_detele = true, TrangThai = true },
                new Size() { TenSize = "27cm x 6cm x 19cm", Id = Guid.Parse("56dd3ee2-c4df-4376-b982-e2c0f7081158"), Is_detele = true, TrangThai = true },
                new Size() { TenSize = "20cm x 6cm x 13cm", Id = Guid.Parse("56dd3ee2-c4df-4376-b982-e2c0f7081159"), Is_detele = true, TrangThai = true },
                new Size() { TenSize = "37cm x 13cm x 28cm", Id = Guid.Parse("56dd3ee2-c4df-4376-b982-e2c0f7081160"), Is_detele = true, TrangThai = true },
                new Size() { TenSize = "20cm x 13.5cm x 7.5cm ", Id = Guid.Parse("56dd3ee2-c4df-4376-b982-e2c0f7081161"), Is_detele = true, TrangThai = true },
                new Size() { TenSize = "19cm x 13cm x 7cm", Id = Guid.Parse("56dd3ee2-c4df-4376-b982-e2c0f7081162"), Is_detele = true, TrangThai = true }

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
                new PhuongThucThanhToan() { TenPhuongThuc = "Thanh toán tại cửa hàng", Id = Guid.Parse("d16ac357-3ced-4c2c-bcdc-d38971211112"), TrangThai = true, Is_detele = true },
                new PhuongThucThanhToan() { TenPhuongThuc = "Thanh toán qua ngân hàng", Id = Guid.Parse("d16ac357-3ced-4c2c-bcdc-d38971211113"), TrangThai = true, Is_detele = true },
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
            //modelBuilder.Entity<SanPhamChiTiet>().HasData(
            //   new SanPhamChiTiet()
            //   {
            //       Id = Guid.NewGuid(),
            //       MaSp = "SP01",
            //       SoLuong = 100,
            //       MoTa = "oke la",
            //       TrangThai = true,
            //       GiaNhap = 300000,
            //       GiaBan = 500000,
            //       GiaNiemYet = 450000,
            //       GhiChu = "",
            //       Is_detele = true,
            //       IdSp = Guid.Parse("56dd3ee2-c4df-4376-b982-e2c0f7081211"),
            //       IdChatLieu = Guid.Parse("56dd3ee2-c4df-4376-b982-e2c0f7081137"),
            //       IdMau = Guid.Parse("56dd3ee2-c4df-4376-b982-e2c0f7081112"),
            //       IdNSX = Guid.Parse("56dd3ee2-c4df-4376-b982-e2c0f7081124"),
            //       IdSize = Guid.Parse("56dd3ee2-c4df-4376-b982-e2c0f7081146"),

            //   },
            //   new SanPhamChiTiet()
            //   {
            //       Id = Guid.NewGuid(),
            //       MaSp = "SP02",
            //       SoLuong = 100,
            //       MoTa = "oke la",
            //       TrangThai = true,
            //       GiaNhap = 400000,
            //       GiaBan = 600000,
            //       GiaNiemYet = 550000,
            //       GhiChu = "",
            //       Is_detele = true,
            //       IdSp = Guid.Parse("56dd3ee2-c4df-4376-b982-e2c0f7081311"),
            //       IdChatLieu = Guid.Parse("56dd3ee2-c4df-4376-b982-e2c0f7081138"),
            //       IdMau = Guid.Parse("56dd3ee2-c4df-4376-b982-e2c0f7081131"),
            //       IdNSX = Guid.Parse("56dd3ee2-c4df-4376-b982-e2c0f7081125"),
            //       IdSize = Guid.Parse("56dd3ee2-c4df-4376-b982-e2c0f7081147"),

            //   }, new SanPhamChiTiet()
            //   {
            //       Id = Guid.NewGuid(),
            //       MaSp = "SP03",
            //       SoLuong = 100,
            //       MoTa = "oke la",
            //       TrangThai = true,
            //       GiaNhap = 600000,
            //       GiaBan = 700000,
            //       GiaNiemYet = 70000,
            //       GhiChu = "",
            //       Is_detele = true,
            //       IdSp = Guid.Parse("56dd3ee2-c4df-4376-b982-e2c0f7081411"),
            //       IdChatLieu = Guid.Parse("56dd3ee2-c4df-4376-b982-e2c0f7081137"),
            //       IdMau = Guid.Parse("56dd3ee2-c4df-4376-b982-e2c0f7081112"),
            //       IdNSX = Guid.Parse("56dd3ee2-c4df-4376-b982-e2c0f7081125"),
            //       IdSize = Guid.Parse("56dd3ee2-c4df-4376-b982-e2c0f7081148"),

            //   }, new SanPhamChiTiet()
            //   {
            //       Id = Guid.NewGuid(),
            //       MaSp = "SP04",
            //       SoLuong = 100,
            //       MoTa = "oke la",
            //       TrangThai = true,
            //       GiaNhap = 300000,
            //       GiaBan = 600000,
            //       GiaNiemYet = 550000,
            //       GhiChu = "",
            //       Is_detele = true,
            //       IdSp = Guid.Parse("56dd3ee2-c4df-4376-b982-e2c0f7081511"),
            //       IdChatLieu = Guid.Parse("56dd3ee2-c4df-4376-b982-e2c0f7081144"),
            //       IdMau = Guid.Parse("56dd3ee2-c4df-4376-b982-e2c0f7081110"),
            //       IdNSX = Guid.Parse("56dd3ee2-c4df-4376-b982-e2c0f7081126"),
            //       IdSize = Guid.Parse("56dd3ee2-c4df-4376-b982-e2c0f7081149"),

            //   }, new SanPhamChiTiet()
            //   {
            //       Id = Guid.NewGuid(),
            //       MaSp = "SP05",
            //       SoLuong = 100,
            //       MoTa = "oke la",
            //       TrangThai = true,
            //       GiaNhap = 400000,
            //       GiaBan = 4500000,
            //       GiaNiemYet = 550000,
            //       GhiChu = "",
            //       Is_detele = true,
            //       IdSp = Guid.Parse("56dd3ee2-c4df-4376-b982-e2c0f7081611"),
            //       IdChatLieu = Guid.Parse("56dd3ee2-c4df-4376-b982-e2c0f7081137"),
            //       IdMau = Guid.Parse("56dd3ee2-c4df-4376-b982-e2c0f7081110"),
            //       IdNSX = Guid.Parse("56dd3ee2-c4df-4376-b982-e2c0f7081127"),
            //       IdSize = Guid.Parse("56dd3ee2-c4df-4376-b982-e2c0f7081150"),

            //   }, new SanPhamChiTiet()
            //   {
            //       Id = Guid.NewGuid(),
            //       MaSp = "SP06",
            //       SoLuong = 100,
            //       MoTa = "oke la",
            //       TrangThai = true,
            //       GiaNhap = 300000,
            //       GiaBan = 700000,
            //       GiaNiemYet = 750000,
            //       GhiChu = "",
            //       Is_detele = true,
            //       IdSp = Guid.Parse("56dd3ee2-c4df-4376-b982-e2c0f7081711"),
            //       IdChatLieu = Guid.Parse("56dd3ee2-c4df-4376-b982-e2c0f7081138"),
            //       IdMau = Guid.Parse("56dd3ee2-c4df-4376-b982-e2c0f7081116"),
            //       IdNSX = Guid.Parse("56dd3ee2-c4df-4376-b982-e2c0f7081124"),
            //       IdSize = Guid.Parse("56dd3ee2-c4df-4376-b982-e2c0f7081152"),

            //   }, new SanPhamChiTiet()
            //   {
            //       Id = Guid.NewGuid(),
            //       MaSp = "SP07",
            //       SoLuong = 100,
            //       MoTa = "oke la",
            //       TrangThai = true,
            //       GiaNhap = 400000,
            //       GiaBan = 500000,
            //       GiaNiemYet = 450000,
            //       GhiChu = "",
            //       Is_detele = true,
            //       IdSp = Guid.Parse("56dd3ee2-c4df-4376-b982-e2c0f7081811"),
            //       IdChatLieu = Guid.Parse("56dd3ee2-c4df-4376-b982-e2c0f7081138"),
            //       IdMau = Guid.Parse("56dd3ee2-c4df-4376-b982-e2c0f7081113"),
            //       IdNSX = Guid.Parse("56dd3ee2-c4df-4376-b982-e2c0f7081124"),
            //       IdSize = Guid.Parse("56dd3ee2-c4df-4376-b982-e2c0f7081153"),

            //   }, new SanPhamChiTiet()
            //   {
            //       Id = Guid.NewGuid(),
            //       MaSp = "SP08",
            //       SoLuong = 100,
            //       MoTa = "oke la",
            //       TrangThai = true,
            //       GiaNhap = 400000,
            //       GiaBan = 650000,
            //       GiaNiemYet = 550000,
            //       GhiChu = "",
            //       Is_detele = true,
            //       IdSp = Guid.Parse("56dd3ee2-c4df-4376-b982-e2c0f7081911"),
            //       IdChatLieu = Guid.Parse("56dd3ee2-c4df-4376-b982-e2c0f7081144"),
            //       IdMau = Guid.Parse("56dd3ee2-c4df-4376-b982-e2c0f7081121"),
            //       IdNSX = Guid.Parse("56dd3ee2-c4df-4376-b982-e2c0f7081124"),
            //       IdSize = Guid.Parse("56dd3ee2-c4df-4376-b982-e2c0f7081154"),

            //   }, new SanPhamChiTiet()
            //   {
            //       Id = Guid.NewGuid(),
            //       MaSp = "SP09",
            //       SoLuong = 100,
            //       MoTa = "oke la",
            //       TrangThai = true,
            //       GiaNhap = 400000,
            //       GiaBan = 600000,
            //       GiaNiemYet = 550000,
            //       GhiChu = "",
            //       Is_detele = true,
            //       IdSp = Guid.Parse("56dd3ee2-c4df-4376-b982-e2c0f7081122"),
            //       IdChatLieu = Guid.Parse("56dd3ee2-c4df-4376-b982-e2c0f7081144"),
            //       IdMau = Guid.Parse("56dd3ee2-c4df-4376-b982-e2c0f7081131"),
            //       IdNSX = Guid.Parse("56dd3ee2-c4df-4376-b982-e2c0f7081124"),
            //       IdSize = Guid.Parse("56dd3ee2-c4df-4376-b982-e2c0f7081155"),

            //   }, new SanPhamChiTiet()
            //   {
            //       Id = Guid.NewGuid(),
            //       MaSp = "SP10",
            //       SoLuong = 100,
            //       MoTa = "oke la",
            //       TrangThai = true,
            //       GiaNhap = 400000,
            //       GiaBan = 600000,
            //       GiaNiemYet = 550000,
            //       GhiChu = "",
            //       Is_detele = true,
            //       IdSp = Guid.Parse("56dd3ee2-c4df-4376-b982-e2c0f7081123"),
            //       IdChatLieu = Guid.Parse("56dd3ee2-c4df-4376-b982-e2c0f7081138"),
            //       IdMau = Guid.Parse("56dd3ee2-c4df-4376-b982-e2c0f7081112"),
            //       IdNSX = Guid.Parse("56dd3ee2-c4df-4376-b982-e2c0f7081124"),
            //       IdSize = Guid.Parse("56dd3ee2-c4df-4376-b982-e2c0f7081156"),

            //   }
            //   );
        }
    }
}
