using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CTN4_Data.DB_Context;
using CTN4_Data.Models;
using CTN4_Data.Models.DB_CTN4;
using CTN4_Serv.Service.IService;

namespace CTN4_Serv.Service.Service
{
    public class LichSuHoaDonService : ILichSuHoaDonService
    {
        public DB_CTN4_ok _db;

        public LichSuHoaDonService()
        {
            _db = new DB_CTN4_ok();
        }
        public List<LichSuDonHang> GetAll()
        {
            return _db.LichSuDonHangs.ToList();
        }

        public LichSuDonHang GetById(Guid id)
        {
            return GetAll().FirstOrDefault(c => c.Id == id);
        }

        public bool Them(LichSuDonHang a)
        {
            try
            {
                _db.LichSuDonHangs.Add(a);
                _db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool Sua(LichSuDonHang a)
        {
            try
            {
                _db.LichSuDonHangs.Update(a);
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
                _db.LichSuDonHangs.Remove(b);
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
