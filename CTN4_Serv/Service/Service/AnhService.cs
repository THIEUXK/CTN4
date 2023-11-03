using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CTN4_Data.DB_Context;
using CTN4_Data.Models.DB_CTN4;
using CTN4_Serv.Service.IService;
using Microsoft.EntityFrameworkCore;

namespace CTN4_Serv.Service
{
    public class AnhService : IAnhService
    {
        public DB_CTN4_ok _db;

        public AnhService()
        {
            _db = new DB_CTN4_ok();
        }
        public List<Anh> GetAll()
        {
            return _db.Anhs.Include(c => c.SanPhamChiTiet.SanPham).ToList();
        }

        public Anh GetById(Guid id)
        {
            return GetAll().FirstOrDefault(c => c.Id == id);
        }

        public bool Them(Anh a)
        {
            try
            {
                _db.Anhs.Add(a);
                _db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool Sua(Anh a)
        {
            try
            {
                _db.Anhs.Update(a);
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
                _db.Anhs.Remove(b);
                _db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        public bool XoaBySP(Guid id)
        {
            try
            {
                var b = GetAll().FirstOrDefault(c => c.IdSanPhamChiTiet == id);
                _db.Anhs.Remove(b);
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