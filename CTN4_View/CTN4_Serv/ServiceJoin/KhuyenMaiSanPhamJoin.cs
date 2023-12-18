using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CTN4_Data.DB_Context;
using CTN4_Data.Models.DB_CTN4;
using Microsoft.EntityFrameworkCore;

namespace CTN4_Serv.ServiceJoin
{
    public class KhuyenMaiSanPhamJoin
    {
        public DB_CTN4_ok _db;
        public KhuyenMaiSanPhamJoin()
        {
            _db = new DB_CTN4_ok();
        }

        public List<KhuyenMaiSanPham> getAllKhuyenMaiSanPham()
        {
            return _db.KhuyenMaiSanPhams.Include(c => c.KhuyenMai).Include(c => c.SanPham).ToList();
        }
        public List<KhuyenMaiSanPham> sanPhamKhuyenMai(string a)
        {
            return getAllKhuyenMaiSanPham().Where(c => c.KhuyenMai.MaKhuyenMai == a).ToList();
        }
        public List<KhuyenMaiSanPham> GetById(Guid id)
        {
            return getAllKhuyenMaiSanPham().Where(c => c.IdkhuyenMai == id).ToList();
        }
        public List<KhuyenMaiSanPham> GetKhuyenMaiPhanLoai(Guid id)
        {
            return getAllKhuyenMaiSanPham().Where(c => c.IdkhuyenMai == id).OrderByDescending(x => x.SanPham.TenSanPham).ToList();
        }
    }
}
