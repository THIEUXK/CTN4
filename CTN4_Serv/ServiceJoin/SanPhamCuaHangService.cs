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

        public List<SanPhamChiTiet> GetAll()
        {
            return _db.SanPhamChiTiets.Include(c => c.ChatLieu).Include(c => c.NSX).Include(c => c.Mau)
                .Include(c => c.Size).Include(c => c.SanPham).ToList();
        }

        public SanPhamChiTiet GetById(Guid id)
        {
            return GetAll().FirstOrDefault(c => c.Id == id);
        }
        public List<SanPhamChiTiet> TimKiemTenSanPham(string ten)
        {
            return GetAll().Where(c => c.SanPham.TenSanPham.ToString() == ten).ToList();
        }
        public List<SanPhamChiTiet> TimKiemTenKhoangGia(float GiaDau,float GiaCuoi)
        {
            return GetAll().Where(c => c.GiaNiemYet>=GiaDau&&c.GiaNiemYet<=GiaCuoi).ToList();
        }
         public float  MaxTien()
        {
            return  _db.SanPhamChiTiets.Max(p => p.GiaNiemYet);
        }
        public List<Anh> GeAnhs(Guid id)
        {
            return _db.Anhs.Where(c=>c.IdSanPhamChiTiet==id).ToList();
        }
        public List<SanPhamChiTiet> GetByIdMs(Guid id)
        {
            return GetAll().Where(c => c.IdMau == id).ToList();
        }
        public List<SanPhamChiTiet> GetByIdCl(Guid id)
        {
            return GetAll().Where(c => c.IdChatLieu == id).ToList();
        }
        
        public List<SanPhamChiTiet> PagIng(int a,int b)
        {
            return _db.SanPhamChiTiets.Include(c => c.ChatLieu).Include(c => c.NSX).Include(c => c.Mau)
                .Include(c => c.Size).Include(c => c.SanPham).Skip((a-1)*b).Take(b).ToList();
            
        }
    }
}
