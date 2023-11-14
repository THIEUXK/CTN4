using CTN4_Data.DB_Context;
using CTN4_Data.Models.DB_CTN4;
using CTN4_Serv.Service.IService;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace CTN4_Serv.Service
{
    public class SanPhamService : ISanPhamService
    {
        public DB_CTN4_ok _db;

        public SanPhamService()
        {
            _db = new DB_CTN4_ok();
        }
        public List<SanPham> GetAllProduct()
        {
            return _db.SanPhams.ToList();
        }
        public List<SanPham> GetAll()
        {
            return _db.SanPhams.Include(c => c.ChatLieu).Include(c => c.NSX).ToList();
        }
        public List<SanPham> GetFull(string Tensp, string gianhap, string giaban, string gianiemyet)
        {
            // Lọc danh sách dựa trên các điều kiện
            var result = _db.SanPhams.Where(sp =>
                (string.IsNullOrEmpty(Tensp) || sp.TenSanPham.Contains(Tensp)) &&
                (string.IsNullOrEmpty(gianhap) || sp.GiaNhap.ToString().Contains(gianhap)) &&
                (string.IsNullOrEmpty(giaban) || sp.GiaBan.ToString().Contains(giaban)) &&
                (string.IsNullOrEmpty(gianiemyet) || sp.GiaNiemYet.ToString().Contains(gianiemyet))
            ).ToList();

            return   result;
        }

        public List<SanPham> GetAllBySearch(string MaSp)
        {
            if(string.IsNullOrEmpty(MaSp))
            {
                return _db.SanPhams.ToList();
            }
            else
            {
               
                var product = _db.SanPhams.Where(p => p.MaSp.Equals(MaSp)).ToList();
                return product;
            }
            
            
        }
        public SanPham GetById(Guid id)
        {
            return GetAll().FirstOrDefault(c => c.Id == id);
        }

        public bool Them(SanPham a)
        {
            try
            {
                _db.SanPhams.Add(a);
                _db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool Sua(SanPham a)
        {
            try
            {
                _db.SanPhams.Update(a);
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
                _db.SanPhams.Remove(b);
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
