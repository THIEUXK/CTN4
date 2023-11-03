using CTN4_Data.DB_Context;
using CTN4_Data.Models.DB_CTN4;
using CTN4_Serv.Service.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace CTN4_Serv.Service
{
    public class HoaDonService : IHoaDonService
    {
        public DB_CTN4_ok _db;

        public HoaDonService()
        {
            _db = new DB_CTN4_ok();
        }
        public List<HoaDon> GetAll()
        {
            return _db.HoaDons.Include(c=>c.KhachHang).Include(c=>c.DiaChiNhanHang).Include(c=>c.PhuongThucThanhToan).ToList();
        }

        public HoaDon GetById(Guid id)
        {
            return GetAll().FirstOrDefault(c => c.Id == id);
        }

        public bool Them(HoaDon a)
        {
            try
            {
                _db.HoaDons.Add(a);
                _db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool Sua(HoaDon a)
        {
            try
            {
                _db.HoaDons.Update(a);
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
                _db.HoaDons.Remove(b);
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

