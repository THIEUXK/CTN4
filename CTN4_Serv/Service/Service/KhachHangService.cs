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
    public class KhachHangService : IKhachHangService
    {
        public DB_CTN4_ok _db;

        public KhachHangService()
        {
            _db = new DB_CTN4_ok();
        }
        public List<KhachHang> GetAll()
        {
            return _db.KhachHangs.ToList();
        }

        public KhachHang GetById(Guid id)
        {
            return GetAll().FirstOrDefault(c => c.Id == id);
        }

        public bool Them(KhachHang a)
        {
            try
            {
                _db.KhachHangs.Add(a);
                _db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool Sua(KhachHang a)
        {
            try
            {
                
                _db.KhachHangs.Update(a);
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
                _db.KhachHangs.Remove(b);
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
