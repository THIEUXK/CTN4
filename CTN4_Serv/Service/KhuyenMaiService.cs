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
    public class KhuyenMaiService : IKhuyenMaiService
    {
        public DB_CTN4_ok _db;

        public KhuyenMaiService()
        {
            _db = new DB_CTN4_ok();
        }
        public List<KhuyenMai> GetAll()
        {
            return _db.KhuyenMais.ToList();
        }

        public KhuyenMai GetById(Guid id)
        {
            return GetAll().FirstOrDefault(c => c.Id == id);
        }

        public bool Them(KhuyenMai a)
        {
            try
            {
                _db.KhuyenMais.Add(a);
                _db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool Sua(KhuyenMai a)
        {
            try
            {
                _db.KhuyenMais.Update(a);
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
                _db.KhuyenMais.Remove(b);
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
