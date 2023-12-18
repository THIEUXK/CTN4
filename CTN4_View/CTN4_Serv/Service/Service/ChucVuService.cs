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
    public class ChucVuService : IChucVuService
    {
        public DB_CTN4_ok _db;

        public ChucVuService()
        {
            _db = new DB_CTN4_ok();
        }
        public List<ChucVu> GetAll()
        {
            return _db.ChucVus.ToList();
        }

        public ChucVu GetById(Guid id)
        {
            return GetAll().FirstOrDefault(c => c.Id == id);
        }

        public bool Them(ChucVu a)
        {
            try
            {
                _db.ChucVus.Add(a);
                _db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool Sua(ChucVu a)
        {
            try
            {
                _db.ChucVus.Update(a);
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
                _db.ChucVus.Remove(b);
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
