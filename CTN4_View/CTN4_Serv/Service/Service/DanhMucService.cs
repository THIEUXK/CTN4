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
    public class DanhMucMucService : IDanhMucService
    {
        public DB_CTN4_ok _db;

        public DanhMucMucService()
        {
            _db = new DB_CTN4_ok();
        }
        public List<DanhMuc> GetAll()
        {
            return _db.DanhMucs.ToList();
        }

        public DanhMuc GetById(Guid id)
        {
            return GetAll().FirstOrDefault(c => c.Id == id);
        }

        public bool Them(DanhMuc a)
        {
            try
            {
                _db.DanhMucs.Add(a);
                _db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool Sua(DanhMuc a)
        {
            try
            {
                _db.DanhMucs.Update(a);
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
                _db.DanhMucs.Remove(b);
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
