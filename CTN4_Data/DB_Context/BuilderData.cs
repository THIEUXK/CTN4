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
                new Mau() { TenMau = "đen", Id = Guid.NewGuid(), Is_detele = true,TrangThai = true},
                new Mau() { TenMau = "trắng", Id = Guid.NewGuid(), Is_detele = true, TrangThai = true },
                new Mau() { TenMau = "nâu", Id = Guid.NewGuid(), Is_detele = true, TrangThai = true },
                new Mau() { TenMau = "xám", Id = Guid.NewGuid(),  Is_detele = true, TrangThai = true },
                new Mau() { TenMau = "vàng", Id = Guid.NewGuid(),  Is_detele = true, TrangThai = true },
                new Mau() { TenMau = "ghi", Id = Guid.NewGuid(),  Is_detele = true, TrangThai = true },
                new Mau() { TenMau = "cam", Id = Guid.NewGuid(),  Is_detele = true, TrangThai = true },
                new Mau() { TenMau = "xanh dương đậm", Id = Guid.NewGuid(),  Is_detele = true, TrangThai = true },
                new Mau() { TenMau = "xanh lục", Id = Guid.NewGuid(),  Is_detele = true, TrangThai = true },
                new Mau() { TenMau = "xanh dương", Id = Guid.NewGuid(),  Is_detele = true, TrangThai = true },
                new Mau() { TenMau = "xanh lá", Id = Guid.NewGuid(),  Is_detele = true, TrangThai = true },
                new Mau() { TenMau = "xanh nhạt", Id = Guid.NewGuid(),  Is_detele = true, TrangThai = true },
                new Mau() { TenMau = "tràm", Id =Guid.NewGuid(), Is_detele = true, TrangThai = true },
                new Mau() { TenMau = "tím", Id = Guid.NewGuid(), Is_detele = true, TrangThai = true },
                new Mau() { TenMau = "xanh lá đậm", Id = Guid.NewGuid(), Is_detele = true, TrangThai = true },
                new Mau() { TenMau = "xanh tím", Id = Guid.NewGuid(), Is_detele = true, TrangThai = true },
                new Mau() { TenMau = "hồng", Id = Guid.NewGuid(), Is_detele = true, TrangThai = true },
                new Mau() { TenMau = "kem", Id = Guid.NewGuid(), Is_detele = true, TrangThai = true },
                new Mau() { TenMau = "kem Đậm", Id = Guid.NewGuid(), Is_detele = true, TrangThai = true }
                );
            modelBuilder.Entity<SanPham>().HasData(
               new SanPham() { TenSanPham = "TXT Da Rắn Khóa Bạc _QuanChau_Trang_Da PU cao cấp(1)", AnhDaiDien = "TXT Da Rắn Khóa Bạc _QuanChau_Trang_Da PU cao cấp(1).jpg", Id=Guid.NewGuid(),Is_detele = true,TrangThai = true },
               new SanPham() { TenSanPham = "TXT Phủ Màu Tag Vuông_QuanChau_XanhLuc_Da PU mềm mịn, cao cấp(1)", AnhDaiDien = "TXT Phủ Màu Tag Vuông_QuanChau_XanhLuc_Da PU mềm mịn, cao cấp(1).jpg", Id = Guid.NewGuid(), Is_detele = true, TrangThai = true },
               new SanPham() { TenSanPham = "TDV Hobo Đáy Tròn_QuanChau_Trang_Da lộn, da PU cao cấp(1)", AnhDaiDien = "TDV Hobo Đáy Tròn_QuanChau_Trang_Da lộn, da PU cao cấp(1).jpg", Id = Guid.NewGuid(), Is_detele = true, TrangThai = true },
               new SanPham() { TenSanPham = "Túi Xách Nhỏ Curve 1_Trung Quốc_Xanhduong_Da tổng hợp(1)", AnhDaiDien = "Túi Xách Nhỏ Curve 1_Trung Quốc_Xanhduong_Da tổng hợp(1).webp", Id = Guid.NewGuid(), Is_detele = true, TrangThai = true },
               new SanPham() { TenSanPham = "TDV Hobo Đáy Tròn_QuanChau_Xanh-Duong_Da lộn, da PU cao cấp(1)", AnhDaiDien = "TDV Hobo Đáy Tròn_QuanChau_Xanh-Duong_Da lộn, da PU cao cấp(1).jpg", Id = Guid.NewGuid(), Is_detele = true, TrangThai = true },
               new SanPham() { TenSanPham = "TOT Classic Phối Màu _QuanChau_Ghi_Da PU mềm mịn, cao cấp(1)", AnhDaiDien = "TOT Classic Phối Màu _QuanChau_Ghi_Da PU mềm mịn, cao cấp(1).jpg", Id = Guid.NewGuid(), Is_detele = true, TrangThai = true },
               new SanPham() { TenSanPham = "TOT Classic Phối Màu _QuanChau_Nau_Da PU mềm mịn, cao cấp(1)", AnhDaiDien = "TOT Classic Phối Màu _QuanChau_Nau_Da PU mềm mịn, cao cấp(1).jpg", Id = Guid.NewGuid(), Is_detele = true, TrangThai = true },
               new SanPham() { TenSanPham = "Túi Xách Nhỏ Curve 1_Trung Quốc_XanhLa_Da tổng hợp(1)", AnhDaiDien = "Túi Xách Nhỏ Curve 1_Trung Quốc_XanhLa_Da tổng hợp(1).webp", Id = Guid.NewGuid(), Is_detele = true, TrangThai = true },
               new SanPham() { TenSanPham = "Túi Xách Nhỏ Đeo Vai - Cycling_Trung Quốc_XanhNhat_Da tổng hợp(1)", AnhDaiDien = "Túi Xách Nhỏ Đeo Vai - Cycling_Trung Quốc_XanhNhat_Da tổng hợp(1).webp", Id = Guid.NewGuid(), Is_detele = true, TrangThai = true },
               new SanPham() { TenSanPham = "TDV Hobo Quai Ngắn_QuanChau_Trang_Da PU mềm mịn, cao cấp(1)", AnhDaiDien = "TDV Hobo Quai Ngắn_QuanChau_Trang_Da PU mềm mịn, cao cấp(1).jpg", Id = Guid.NewGuid(), Is_detele = true, TrangThai = true }
            );
            modelBuilder.Entity<NSX>().HasData(
                new NSX() { TenNSX = "Juno", Id = Guid.NewGuid(), GhiChu = "", Is_detele = true, TrangThai = true},
                new NSX() { TenNSX = "Prada", Id = Guid.NewGuid(), GhiChu = "", Is_detele = true, TrangThai = true },
                new NSX() { TenNSX = "Gucci", Id = Guid.NewGuid(), GhiChu = "", Is_detele = true, TrangThai = true },
                new NSX() { TenNSX = "Chanel", Id = Guid.NewGuid(), GhiChu = "", Is_detele = true, TrangThai = true },
                new NSX() { TenNSX = "Coach", Id = Guid.NewGuid(), GhiChu = "", Is_detele = true, TrangThai = true },
                new NSX() { TenNSX = "MLB Korea", Id = Guid.NewGuid(), GhiChu = "", Is_detele = true, TrangThai = true },
                new NSX() { TenNSX = "Michael Kors", Id = Guid.NewGuid(), GhiChu = "", Is_detele = true, TrangThai = true },
                new NSX() { TenNSX = "JW Anderson", Id = Guid.NewGuid(), GhiChu = "", Is_detele = true, TrangThai = true },
                new NSX() { TenNSX = "Christian Dior", Id = Guid.NewGuid(), GhiChu = "", Is_detele = true, TrangThai = true },
                new NSX() { TenNSX = "Louis Vuitton", Id = Guid.NewGuid(), GhiChu = "", Is_detele = true, TrangThai = true }
            );
            modelBuilder.Entity<ChatLieu>().HasData(
                new ChatLieu() { TenChatLieu = "Da PU cao cấp", Id = Guid.NewGuid(), GhiChu = "", Is_detele = true, TrangThai = true },
                new ChatLieu() { TenChatLieu = "Da PU mềm mịn, cao cấp", Id = Guid.NewGuid(), GhiChu = "", Is_detele = true, TrangThai = true },
                new ChatLieu() { TenChatLieu = "Vai Canvat", Id = Guid.NewGuid(), GhiChu = "", Is_detele = true, TrangThai = true },
                new ChatLieu() { TenChatLieu = "Da tổng hợp", Id = Guid.NewGuid(), GhiChu = "", Is_detele = true, TrangThai = true }
                //new ChatLieu() { TenChatLieu = "Tricot (Vải dệt kim)", Id = Guid.NewGuid(), GhiChu = "", Is_detele = true, TrangThai = true },
                //new ChatLieu() { TenChatLieu = "Vải không dệt (Micro Polyester)", Id = Guid.NewGuid(), GhiChu = "", Is_detele = true, TrangThai = true },
                //new ChatLieu() { TenChatLieu = "Vải Simili (Giả da)", Id = Guid.NewGuid(), GhiChu = "", Is_detele = true, TrangThai = true }
            );
            modelBuilder.Entity<Size>().HasData(
                new Size() { TenSize = "30cm x 20cm x 10cm", Id = Guid.NewGuid(), Is_detele = true, TrangThai = true},
                new Size() { TenSize = "28cm x 22cm x 10cm", Id = Guid.NewGuid(), Is_detele = true, TrangThai = true },
                new Size() { TenSize = "27cm x 12cm x 8cm", Id = Guid.NewGuid(), Is_detele = true, TrangThai = true },
                new Size() { TenSize = "23cm x 13cm x 6cm", Id = Guid.NewGuid(), Is_detele = true, TrangThai = true },
                new Size() { TenSize = "23cm x 15cm x 5cm", Id = Guid.NewGuid(), Is_detele = true, TrangThai = true},
                new Size() { TenSize = "22cm x 18cm x 8cm", Id = Guid.NewGuid(), Is_detele = true, TrangThai = true },
                new Size() { TenSize = "20cm x 12cm x 7cm", Id = Guid.NewGuid(), Is_detele = true, TrangThai = true },
                new Size() { TenSize = "22cm x 15cm x 6cm", Id = Guid.NewGuid(), Is_detele = true, TrangThai = true },
                new Size() { TenSize = "17cm x 16cm x 7cm", Id = Guid.NewGuid(), Is_detele = true, TrangThai = true },
                new Size() { TenSize = "22cm x 12cm x 6cm", Id = Guid.NewGuid(), Is_detele = true, TrangThai = true},
                new Size() { TenSize = "21cm x 8cm x 13cm", Id = Guid.NewGuid(), Is_detele = true, TrangThai = true },
                new Size() { TenSize = "27cm x 6cm x 19cm", Id = Guid.NewGuid(), Is_detele = true, TrangThai = true },
                new Size() { TenSize = "20cm x 6cm x 13cm", Id = Guid.NewGuid(), Is_detele = true, TrangThai = true },
                new Size() { TenSize = "37cm x 13cm x 28cm", Id = Guid.NewGuid(), Is_detele = true, TrangThai = true},
                new Size() { TenSize = "20cm x 13.5cm x 7.5cm ", Id = Guid.NewGuid(), Is_detele = true, TrangThai = true },
                new Size() { TenSize = "19cm x 13cm x 7cm", Id = Guid.NewGuid(), Is_detele = true, TrangThai = true }
               
            );
            modelBuilder.Entity<DanhMuc>().HasData(
                new DanhMuc() { TenDanhMuc = "Túi đeo chéo Nữ – Cross body", Id = Guid.NewGuid(), Is_detele = true},
                new DanhMuc() { TenDanhMuc = "Túi đeo vai – Shoulder bag", Id = Guid.NewGuid(), Is_detele = true },
                new DanhMuc() { TenDanhMuc = "Túi tote", Id = Guid.NewGuid(), Is_detele = true },
                new DanhMuc() { TenDanhMuc = "Túi satchel", Id = Guid.NewGuid(), Is_detele = true },
                new DanhMuc() { TenDanhMuc = "Túi baguette", Id = Guid.NewGuid(), Is_detele = true },
                new DanhMuc() { TenDanhMuc = "Túi bao tử – Túi bumbag", Id = Guid.NewGuid(), Is_detele = true },
                new DanhMuc() { TenDanhMuc = "Túi cầm tay – Clutch", Id = Guid.NewGuid(), Is_detele = true },
                new DanhMuc() { TenDanhMuc = "Túi Hobo", Id = Guid.NewGuid(), Is_detele = true },
                new DanhMuc() { TenDanhMuc = "Túi dây rút – Pouch", Id = Guid.NewGuid(), Is_detele = true },
                new DanhMuc() { TenDanhMuc = "Túi Bucket", Id = Guid.NewGuid(), Is_detele = true },
                new DanhMuc() { TenDanhMuc = "Túi Bowling", Id = Guid.NewGuid(), Is_detele = true },
                new DanhMuc() { TenDanhMuc = "Túi Ring Bag", Id = Guid.NewGuid(), Is_detele = true }
            );
            modelBuilder.Entity<ChucVu>().HasData(
                new ChucVu() { TenChucVu = "Quản lý", Id = Guid.Parse("d16ac357-3ced-4c2c-bcdc-d38971214414"), TrangThai = true },
                new ChucVu() { TenChucVu = "Nhân viên", Id = Guid.Parse("56dd3ee2-c4df-4376-b982-e2c0f70877e9"), TrangThai = true }
            );
            modelBuilder.Entity<NhanVien>().HasData(
                new NhanVien()
                {
                    Ho = "Nguyễn",
                    Ten = "Trang",
                    Id = Guid.NewGuid(),
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
		}
    }
}
