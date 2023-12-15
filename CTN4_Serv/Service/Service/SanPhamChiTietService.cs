using CTN4_Data.DB_Context;
using CTN4_Data.Models.DB_CTN4;
using CTN4_Serv.Service.IService;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CTN4_Serv.Service
{
    public class SanPhamChiTietService : ISanPhamChiTietService
    {
        public DB_CTN4_ok _db;

        public SanPhamChiTietService()
        {
            _db = new DB_CTN4_ok();
        }
        public List<SanPhamChiTiet> GetAll()
        {
            return _db.SanPhamChiTiets.Include(c=>c.Mau).Include(c=>c.Size).Include(c=>c.SanPham).ToList();
        }

        public SanPhamChiTiet GetById(Guid? id)
        {
            return GetAll().FirstOrDefault(c => c.Id == id);
        }

        public bool Them(SanPhamChiTiet a)
        {
            try
            {
                _db.SanPhamChiTiets.Add(a);
                _db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool Sua(SanPhamChiTiet a)
        {
            try
            {
                _db.SanPhamChiTiets.Update(a);
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
                _db.SanPhamChiTiets.Remove(b);
                _db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        public List<SanPhamChiTiet> GetSanPhamChiTiets( Guid id)
        {
            return _db.SanPhamChiTiets.Include(c=>c.Mau).Include(c=>c.Size).Include(c=>c.SanPham).Where(c=>c.Id == id).ToList();
        }
    }
}
