using CTN4_Data.DB_Context;
using CTN4_Data.Models.DB_CTN4;
using CTN4_Serv.Service.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace CTN4_Serv.Service
{
    public class GioHangChiTietService : IGioHangChiTietService
    {
        public DB_CTN4_ok _db;

        public GioHangChiTietService()
        {
            _db = new DB_CTN4_ok();
        }
        public List<GioHangChiTiet> GetAll()
        {
            return _db.GioHangChiTiets.Include(c=>c.SanPhamChiTiet).Include(c=>c.GioHang).Include(c => c.SanPhamChiTiet.SanPham).ToList();
        }

        public GioHangChiTiet GetById(Guid id)
        {
            return GetAll().FirstOrDefault(c => c.Id == id);
        }

        public bool Them(GioHangChiTiet a)
        {
            try
            {
                _db.GioHangChiTiets.Add(a);
                _db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool Sua(GioHangChiTiet a)
        {
            try
            {
                _db.GioHangChiTiets.Update(a);
                _db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool Xoa(Guid id)
        {
            try
            {
                var b = GetById(id);
                _db.GioHangChiTiets.Remove(b);
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
