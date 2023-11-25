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
    public class DanhMucChiTietMucChiTietService : IDanhMucChiTietService
    {
        public DB_CTN4_ok _db;

        public DanhMucChiTietMucChiTietService()
        {
            _db = new DB_CTN4_ok();
        }
        public List<DanhMucChiTiet> GetAll()
        {
            return _db.DanhMucChiTiets.Include(c=>c.SanPham).Include(c=>c.DanhMuc).ToList();
        }

        public DanhMucChiTiet GetById(Guid id)
        {
            return GetAll().FirstOrDefault(c => c.Id == id);
        }

        public bool Them(DanhMucChiTiet a)
        {
            try
            {
                _db.DanhMucChiTiets.Add(a);
                _db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool Sua(DanhMucChiTiet a)
        {
            try
            {
                _db.DanhMucChiTiets.Update(a);
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
                _db.DanhMucChiTiets.Remove(b);
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
