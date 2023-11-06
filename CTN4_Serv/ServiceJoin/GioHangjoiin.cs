using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CTN4_Data.DB_Context;
using CTN4_Data.Models.DB_CTN4;
using Microsoft.EntityFrameworkCore;

namespace CTN4_Serv.ServiceJoin
{
    public class GioHangjoiin
    {
        public DB_CTN4_ok _db;

        public GioHangjoiin()
        {
            _db = new DB_CTN4_ok();
        }

        public List<GioHangChiTiet> GetAll()
        {
            return _db.GioHangChiTiets.Include(c => c.GioHang).Include(c => c.SanPhamChiTiet).Include(c => c.SanPhamChiTiet.SanPham).Include(c => c.SanPhamChiTiet.Size).Include(c => c.SanPhamChiTiet.Mau).ToList();
        }
        public GioHangChiTiet GetById(Guid id)
        {
            return GetAll().FirstOrDefault(c => c.Id == id);
        }

        public bool ThemGio(GioHangChiTiet a)
        {
            try
            {
                var b = new GioHangChiTiet()
                {
                    Id = Guid.NewGuid(),
                    IdSanPhamChiTiet = a.IdSanPhamChiTiet,
                    IdGioHang = a.IdGioHang,
                    SoLuong = a.SoLuong
                };
                _db.GioHangChiTiets.Add(b);
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