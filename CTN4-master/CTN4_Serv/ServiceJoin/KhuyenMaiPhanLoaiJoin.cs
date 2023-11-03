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
    public class KhuyenMaiPhanLoaiJoin
    {
        public DB_CTN4_ok _db;
        public KhuyenMaiPhanLoaiJoin()
        {
            _db = new DB_CTN4_ok();
        }

        public List<KhuyenMaiPhanLoai> getAllKhuyenMaiPhanLoai()
        {
            return _db.KhuyenMaiPhanLoais.Include(c => c.KhuyenMai).Include(c => c.PhanLoai).ToList();
        }
        public List<KhuyenMaiPhanLoai> phanLoaiKhuyenMai(string a)
        {
            return getAllKhuyenMaiPhanLoai().Where(c => c.KhuyenMai.MaKhuyenMai == a).ToList();
        }
        public List<KhuyenMaiPhanLoai> GetById(Guid id)
        {
            return getAllKhuyenMaiPhanLoai().Where(c => c.idKhuyenMai == id).ToList();
        }
        public List<KhuyenMaiPhanLoai> GetKhuyenMaiSanPham(Guid id)
        {
            return getAllKhuyenMaiPhanLoai().Where(c => c.idKhuyenMai == id).OrderByDescending(x => x.PhanLoai.TenPhanLoai).ToList();
        }
    }
}
