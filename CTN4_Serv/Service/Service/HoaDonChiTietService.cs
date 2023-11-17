using CTN4_Data.DB_Context;
using CTN4_Data.Models.DB_CTN4;
using CTN4_Serv.Service.IService;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CTN4_Serv.Service
{
    public class HoaDonChiTietService : IHoaDonChiTietService
    {
        public DB_CTN4_ok _db;

        public HoaDonChiTietService()
        {
            _db = new DB_CTN4_ok();
        }
        public List<HoaDonChiTiet> GetAll()
        {
            return _db.HoaDonChiTiets.Include(c=>c.HoaDon).Include(c => c.SanPhamChiTiet.SanPham).Include(c => c.SanPhamChiTiet.Size).Include(c => c.SanPhamChiTiet.Mau).Include(c => c.SanPhamChiTiet).Include(c=>c.SanPhamChiTiet.SanPham.ChatLieu).Include(c => c.SanPhamChiTiet.SanPham.NSX).ToList();
        }

        public HoaDonChiTiet GetById(Guid id)
        {
            return GetAll().FirstOrDefault(c => c.Id == id);
        }

        public bool Them(HoaDonChiTiet a)
        {
            try
            {
                _db.HoaDonChiTiets.Add(a);
                _db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool Sua(HoaDonChiTiet a)
        {
            try
            {
                _db.HoaDonChiTiets.Update(a);
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
                _db.HoaDonChiTiets.Remove(b);
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
