using CTN4_Data.DB_Context;
using CTN4_Data.Models.DB_CTN4;
using CTN4_Serv.Service.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CTN4_Serv.Service
{
    public class SanPhamService : ISanPhamService
    {
        public DB_CTN4_ok _db;

        public SanPhamService()
        {
            _db = new DB_CTN4_ok();
        }
        public List<SanPham> GetAll()
        {
            return _db.SanPhams.ToList();
        }

        public SanPham GetById(Guid id)
        {
            return GetAll().FirstOrDefault(c => c.Id == id);
        }

        public bool Them(SanPham a)
        {
            try
            {
                _db.SanPhams.Add(a);
                _db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool Sua(SanPham a)
        {
            try
            {
                _db.SanPhams.Update(a);
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
                _db.SanPhams.Remove(b);
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
