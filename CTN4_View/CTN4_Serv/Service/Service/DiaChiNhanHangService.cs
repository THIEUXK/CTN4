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
    public class DiaChiNhanHangService : IDiaChiNhanHangService
    {
        public DB_CTN4_ok _db;

        public DiaChiNhanHangService()
        {
            _db = new DB_CTN4_ok();
        }
        public List<DiaChiNhanHang> GetAll()
        {
            return _db.DaiChiNhanHangs.ToList();
        }

        public DiaChiNhanHang GetById(Guid id)
        {
            return GetAll().FirstOrDefault(c => c.Id == id);
        }

        public bool Them(DiaChiNhanHang a)
        {
            try
            {
                var lstByIdUser = _db.DaiChiNhanHangs.AsQueryable().Where(p=>p.IdKhachHang == a.IdKhachHang).ToList();
                //if (lstByIdUser !=null && lstByIdUser.Count() <= 3)
                //{
                    _db.DaiChiNhanHangs.Add(a);
                    _db.SaveChanges();
                //}               
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool Sua(DiaChiNhanHang a)
        {
            try
            {
                _db.DaiChiNhanHangs.Update(a);
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
                _db.DaiChiNhanHangs.Remove(b);
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
