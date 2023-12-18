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
    public class GiamGiaChiTietService : IGiamGiaChiTietService
    {
        public DB_CTN4_ok _db;

        public GiamGiaChiTietService()
        {
            _db = new DB_CTN4_ok();
        }
        public List<GiamGiaChiTiet> GetAll()
        {
            return _db.GiamGiaChiTiets.Include(c=> c.GiamGia).Include(c=>c.HoaDon).ToList();
        }

        public GiamGiaChiTiet GetById(Guid id)
        {
            return GetAll().FirstOrDefault(c => c.Id == id);
        }

        public bool Them(GiamGiaChiTiet a)
        {
            try
            {
                _db.GiamGiaChiTiets.Add(a);
                _db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool Sua(GiamGiaChiTiet a)
        {
            try
            {
                _db.GiamGiaChiTiets.Update(a);
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
                _db.GiamGiaChiTiets.Remove(b);
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
