using CTN4_Data.DB_Context;
using CTN4_Data.Models.DB_CTN4;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CTN4_Serv.ServiceJoin
{

    public class DanhMucJoin
    {
        public DB_CTN4_ok _db;
        public DanhMucJoin()
        {
           _db = new DB_CTN4_ok(); 
        }
        public List<DanhMucChiTiet> getAllDanhMucChitiet()
        {
            return _db.DanhMucChiTiets.Include(c=>c.DanhMuc).Include(c=>c.SanPham).ToList();
        } 
        public List<DanhMucChiTiet> sanPhamDanhMuc(string a)
        {
            return getAllDanhMucChitiet().Where(c=>c.DanhMuc.TenDanhMuc == a).ToList();
        }
        public List<DanhMucChiTiet> GetById(Guid id)
        {
            return getAllDanhMucChitiet().Where(c => c.IdDanhMuc == id).ToList();
        }
         public List<DanhMucChiTiet> GetDanhMucChiTiets(Guid id)
        {
            return getAllDanhMucChitiet().Where(c=>c.IdDanhMuc == id).OrderByDescending(x=>x.SanPham.TenSanPham).ToList();
        }
    }
}
