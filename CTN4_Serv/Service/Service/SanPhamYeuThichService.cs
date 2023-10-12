using CTN4_Data.DB_Context;
using CTN4_Data.Models.DB_CTN4;
using CTN4_Serv.Service.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CTN4_Serv.Service
{
    public class SanPhamYeuThichService : ISanPhamYeuThichService
    {
        public DB_CTN4_ok _db;

        public SanPhamYeuThichService()
        {
            _db=new DB_CTN4_ok();
        }
        public List<SanPhamYeuThich> GetAll()
        {
            return _db.SanPhamYeuThichs.ToList();
        }

        public SanPhamYeuThich GetById(Guid id)
        {
            return GetAll().FirstOrDefault(c => c.Id == id);
        }

        public bool Them(SanPhamYeuThich a)
        {
            try
            {
                _db.SanPhamYeuThichs.Add(a);
                _db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool Sua(SanPhamYeuThich a)
        {
            try
            {
                _db.SanPhamYeuThichs.Update(a);
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
                _db.SanPhamYeuThichs.Remove(b);
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
