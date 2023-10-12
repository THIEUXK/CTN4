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
    public class GiamGiaService : IGiamGiaService
    {
        public DB_CTN4_ok _db;

        public GiamGiaService()
        {
            _db = new DB_CTN4_ok();
        }
        public List<GiamGia> GetAll()
        {
            return _db.GiamGias.ToList();
        }

        public GiamGia GetById(Guid id)
        {
            return GetAll().FirstOrDefault(c => c.Id == id);
        }

        public bool Them(GiamGia a)
        {
            try
            {
                _db.GiamGias.Add(a);
                _db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool Sua(GiamGia a)
        {
            try
            {
                _db.GiamGias.Update(a);
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
                _db.GiamGias.Remove(b);
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
