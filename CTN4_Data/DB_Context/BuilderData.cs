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
               new SanPham() { TenSanPham = "",AnhDaiDiem = "",Id=Guid.NewGuid(),Is_detele = true,TrangThai = true, }
            );
        }
    }
}
