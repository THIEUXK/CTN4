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
    public class PhanLoaiService : IPhanLoaiService
    {
        public DB_CTN4_ok _db;

        public PhanLoaiService()
        {
            _db = new DB_CTN4_ok();
        }
        public List<PhanLoai> GetAll()
        {
            return _db.PhanLoais.ToList();
        }

        public PhanLoai GetById(Guid id)
        {
            return GetAll().FirstOrDefault(c => c.Id == id);
        }

        public bool Them(PhanLoai a)
        {
            try
            {
                _db.PhanLoais.Add(a);
                _db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool Sua(PhanLoai a)
        {
            try
            {
                _db.PhanLoais.Update(a);
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
                _db.PhanLoais.Remove(b);
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
