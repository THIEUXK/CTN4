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
    public class PhanLoaiChiTietService : IphanLoaiChiTietService
    {
        public DB_CTN4_ok _db;

        public PhanLoaiChiTietService()
        {
            _db = new DB_CTN4_ok();
        }
        public List<PhanLoaiChiTiet> GetAll()
        {
            return _db.PhanLoaiChiTiets.ToList();
        }

        public PhanLoaiChiTiet GetById(Guid id)
        {
            return GetAll().FirstOrDefault(c => c.Id == id);
        }

        public bool Them(PhanLoaiChiTiet a)
        {
            try
            {
                _db.PhanLoaiChiTiets.Add(a);
                _db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool Sua(PhanLoaiChiTiet a)
        {
            try
            {
                _db.PhanLoaiChiTiets.Update(a);
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
                _db.PhanLoaiChiTiets.Remove(b);
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
