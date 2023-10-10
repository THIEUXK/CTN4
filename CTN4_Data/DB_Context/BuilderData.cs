﻿using System;
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
                new Mau() { TenMau = "nâu da", Id = Guid.NewGuid(), Is_detele = true, TrangThai = true },
                new Mau() { TenMau = "xám", Id = Guid.NewGuid(),  Is_detele = true, TrangThai = true },
                new Mau() { TenMau = "vàng", Id = Guid.NewGuid(),  Is_detele = true, TrangThai = true },
                new Mau() { TenMau = "cam", Id = Guid.NewGuid(),  Is_detele = true, TrangThai = true },
                new Mau() { TenMau = "xanh lục", Id = Guid.NewGuid(),  Is_detele = true, TrangThai = true },
                new Mau() { TenMau = "xanh đương", Id = Guid.NewGuid(),  Is_detele = true, TrangThai = true },
                new Mau() { TenMau = "tràm", Id =Guid.NewGuid(), Is_detele = true, TrangThai = true },
                new Mau() { TenMau = "tím", Id = Guid.NewGuid(), Is_detele = true, TrangThai = true },
                new Mau() { TenMau = "xanh lá đậm", Id = Guid.NewGuid(), Is_detele = true, TrangThai = true },
                new Mau() { TenMau = "hồng", Id = Guid.NewGuid(), Is_detele = true, TrangThai = true },
                new Mau() { TenMau = "kem", Id = Guid.NewGuid(), Is_detele = true, TrangThai = true }
                );
            modelBuilder.Entity<SanPham>().HasData(
               new SanPham() { TenSanPham = "Túi Xách Nhỏ Hobo Dập Logo Jn", AnhDaiDiem = "",Id=Guid.NewGuid(),Is_detele = true,TrangThai = true },
               new SanPham() { TenSanPham = "Túi Xách Nhỏ Top Handle Cozy", AnhDaiDiem = "", Id = Guid.NewGuid(), Is_detele = true, TrangThai = true },
               new SanPham() { TenSanPham = "Túi Xách Nhỏ Top Handle Phối Hoa 3D", AnhDaiDiem = "", Id = Guid.NewGuid(), Is_detele = true, TrangThai = true },
               new SanPham() { TenSanPham = "Túi Xách Nhỏ Shoulder Bag Trang Trí Khóa Logo Cách Điệu", AnhDaiDiem = "", Id = Guid.NewGuid(), Is_detele = true, TrangThai = true },
               new SanPham() { TenSanPham = "Túi Xách Nhỏ Dây Kéo Phối 2 Chất Liệu", AnhDaiDiem = "", Id = Guid.NewGuid(), Is_detele = true, TrangThai = true },
               new SanPham() { TenSanPham = "Túi Xách Nhỏ Dáng Boho New Moon", AnhDaiDiem = "", Id = Guid.NewGuid(), Is_detele = true, TrangThai = true },
               new SanPham() { TenSanPham = "Túi Xách Nhỏ Đeo Vai Elite Of The Class", AnhDaiDiem = "", Id = Guid.NewGuid(), Is_detele = true, TrangThai = true },
               new SanPham() { TenSanPham = "Túi Xách Nhỏ Nắp Gập Khóa Trang Trí", AnhDaiDiem = "", Id = Guid.NewGuid(), Is_detele = true, TrangThai = true },
               new SanPham() { TenSanPham = "Túi Xách Nhỏ Đeo Vai Time Travelling", AnhDaiDiem = "", Id = Guid.NewGuid(), Is_detele = true, TrangThai = true },
               new SanPham() { TenSanPham = "Túi Xách Nhỏ Hobo Time Travelling", AnhDaiDiem = "", Id = Guid.NewGuid(), Is_detele = true, TrangThai = true }
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
                new ChatLieu() { TenChatLieu = "Da thuộc (real leather)", Id = Guid.NewGuid(), GhiChu = "", Is_detele = true, TrangThai = true },
                new ChatLieu() { TenChatLieu = "Vải bông (Cotton)", Id = Guid.NewGuid(), GhiChu = "", Is_detele = true, TrangThai = true },
                new ChatLieu() { TenChatLieu = "Canvas", Id = Guid.NewGuid(), GhiChu = "", Is_detele = true, TrangThai = true },
                new ChatLieu() { TenChatLieu = "Nylon (Polyester)", Id = Guid.NewGuid(), GhiChu = "", Is_detele = true, TrangThai = true },
                new ChatLieu() { TenChatLieu = "Tricot (Vải dệt kim)", Id = Guid.NewGuid(), GhiChu = "", Is_detele = true, TrangThai = true },
                new ChatLieu() { TenChatLieu = "Vải không dệt (Micro Polyester)", Id = Guid.NewGuid(), GhiChu = "", Is_detele = true, TrangThai = true },
                new ChatLieu() { TenChatLieu = "Vải Simili (Giả da)", Id = Guid.NewGuid(), GhiChu = "", Is_detele = true, TrangThai = true }
            );
            modelBuilder.Entity<Size>().HasData(
                new Size() { TenSize = "Extra Small", Id = Guid.NewGuid(), Is_detele = true, TrangThai = true},
                new Size() { TenSize = "Small", Id = Guid.NewGuid(), Is_detele = true, TrangThai = true },
                new Size() { TenSize = "Standard (Medium)", Id = Guid.NewGuid(), Is_detele = true, TrangThai = true },
                new Size() { TenSize = "Large", Id = Guid.NewGuid(), Is_detele = true, TrangThai = true },
                new Size() { TenSize = "Extra Large", Id = Guid.NewGuid(), Is_detele = true, TrangThai = true }
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
        }
    }
}
