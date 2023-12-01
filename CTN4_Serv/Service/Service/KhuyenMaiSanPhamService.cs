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
    public class KhuyenMaiSanPhamService : IKhuyenMaiSanPhamService
    {
        public DB_CTN4_ok _db;

        public KhuyenMaiSanPhamService()
        {
            _db = new DB_CTN4_ok();
        }
        public List<KhuyenMaiSanPham> GetAll()
        {
            return _db.KhuyenMaiSanPhams.Include(c=>c.KhuyenMai).Include(c=>c.SanPham).ToList();
        }

        public KhuyenMaiSanPham GetById(Guid id)
        {
            return GetAll().FirstOrDefault(c => c.Id == id);
        }

        public bool Them(KhuyenMaiSanPham a)
        {
            try
            {
                _db.KhuyenMaiSanPhams.Add(a);
                _db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool Sua(KhuyenMaiSanPham a)
        {
            try
            {
                _db.KhuyenMaiSanPhams.Update(a);
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
                _db.KhuyenMaiSanPhams.Remove(b);
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
