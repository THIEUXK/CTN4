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
    public class KhuyenMaiPhanLoaiService : IKhuyenMaiPhanLoaiService
    {
        public DB_CTN4_ok _db;

        public KhuyenMaiPhanLoaiService()
        {
            _db = new DB_CTN4_ok();
        }
        public List<KhuyenMaiPhanLoai> GetAll()
        {
            return _db.KhuyenMaiPhanLoais.ToList();
        }

        public KhuyenMaiPhanLoai GetById(Guid id)
        {
            return GetAll().FirstOrDefault(c => c.Id == id);
        }

        public bool Them(KhuyenMaiPhanLoai a)
        {
            try
            {
                _db.KhuyenMaiPhanLoais.Add(a);
                _db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool Sua(KhuyenMaiPhanLoai a)
        {
            try
            {
                _db.KhuyenMaiPhanLoais.Update(a);
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
                _db.KhuyenMaiPhanLoais.Remove(b);
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
