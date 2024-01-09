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
                var kmsp = _db.KhuyenMaiSanPhams.Where(p => p.IdkhuyenMai == id).ToList();
                var lstkm = _db.KhuyenMaiSanPhams.Where(p => p.IdkhuyenMai == id).Select(p => p.IdSanPham).ToList();
                foreach (var item in kmsp)
                {
                    _db.KhuyenMaiSanPhams.Remove(item);
                }
                foreach (var s in lstkm)
                {
                    var sp = _db.SanPhams.FirstOrDefault(p => p.Id == s);
                   sp.GiaNiemYet = sp.GiaBan ;
                    _db.SanPhams.Update(sp);
                }
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
        public bool CapNhat(Guid id)
        {
            try
            {
                var kmsp = _db.KhuyenMaiSanPhams.Where(p => p.IdkhuyenMai == id).ToList();
                var lstkm = _db.KhuyenMaiSanPhams.Where(p => p.IdkhuyenMai == id).Select(p => p.IdSanPham).ToList();
                foreach (var item in kmsp)
                {
                    _db.KhuyenMaiSanPhams.Remove(item);
                }
                foreach (var s in lstkm)
                {
                    var sp = _db.SanPhams.FirstOrDefault(p => p.Id == s);
                    sp.GiaNiemYet = sp.GiaBan;
                    _db.SanPhams.Update(sp);
                }
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
