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
    public class ChiTietSanPhamYeuThichService : IChiTietSanPhamYeuThichService
    {
        public DB_CTN4_ok _db;

        public ChiTietSanPhamYeuThichService()
        {
            _db = new DB_CTN4_ok();
        }
        public List<ChiTietSanPhamYeuThich> GetAll()
        {
            return _db.ChiTietSanPhamYeu.Include(c => c.SanPham).Include(c=>c.KhachHang).ToList();
        }

        public ChiTietSanPhamYeuThich GetById(Guid id)
        {
            return GetAll().FirstOrDefault(c => c.Id == id);
        }

        public bool Them(ChiTietSanPhamYeuThich a)
        {
            try
            {
                _db.ChiTietSanPhamYeu.Add(a);
                _db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool Sua(ChiTietSanPhamYeuThich a)
        {
            try
            {
                _db.ChiTietSanPhamYeu.Update(a);
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
                _db.ChiTietSanPhamYeu.Remove(b);
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
