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
    public class PhuongThucThanhToanService : IPhuongThucThanhToanService
    {
        public DB_CTN4_ok _db;

        public PhuongThucThanhToanService()
        {
            _db = new DB_CTN4_ok();
        }
        public List<PhuongThucThanhToan> GetAll()
        {
            return _db.PhuongThucThanhToans.ToList();
        }

        public PhuongThucThanhToan GetById(Guid id)
        {
            return GetAll().FirstOrDefault(c => c.Id == id);
        }

        public bool Them(PhuongThucThanhToan a)
        {
            try
            {
                _db.PhuongThucThanhToans.Add(a);
                _db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool Sua(PhuongThucThanhToan a)
        {
            try
            {
                _db.PhuongThucThanhToans.Update(a);
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
                _db.PhuongThucThanhToans.Remove(b);
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
