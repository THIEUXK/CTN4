using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CTN4_Data.DB_Context;
using CTN4_Data.Models.DB_CTN4;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace CTN4_Serv.ServiceJoin
{
    public class SanPhamCuaHangService
    {
        public DB_CTN4_ok _db;

        public SanPhamCuaHangService()
        {
            _db=new DB_CTN4_ok();
        }

        public List<SanPham> GetAll()
        {
            return _db.SanPhams.Include(c=>c.ChatLieu).Include(c=>c.NSX).Include(c=>c.KhuyenMaiSanPhams).ToList();
        }

        public SanPham GetById(Guid id)
        {
            return GetAll().FirstOrDefault(c => c.Id == id);
        }
        public List<SanPham> TimKiemTenSanPham(string ten)
        {
            return GetAll().Where(c => c.TenSanPham.ToString() == ten).ToList();
        }
        public List<SanPham> TimKiemTenKhoangGia(float GiaDau,float GiaCuoi)
        {
            return GetAll().Where(c => c.GiaNiemYet>=GiaDau&&c.GiaNiemYet<=GiaCuoi).ToList();
        }
         public float  MaxTien()
        {
            return  _db.SanPhamChiTiets.Max(p => p.SanPham.GiaNiemYet);
        }
        public List<Anh> GeAnhs(Guid id)
        {
            return _db.Anhs.Where(c=>c.IdSanPhamChiTiet==id).ToList();
        }
        public List<SanPham> PagIng(int a,int b)
        {
            return _db.SanPhams.ToList();
            
        }
        public List<SanPhamChiTiet> GetAllSpct()
        {
            return _db.SanPhamChiTiets.Include(c=>c.Mau).Include(c=>c.Size).Include(c=>c.SanPham).ToList();
        }
        public List<SanPhamChiTiet> GetAllSpcts(Guid id)
        {
            return _db.SanPhamChiTiets.Include(c=>c.Mau).Include(c=>c.Size).Include(c=>c.SanPham).Where(c=>c.IdSp == id).ToList();
        }
    }
}
