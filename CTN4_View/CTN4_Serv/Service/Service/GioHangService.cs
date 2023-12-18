using CTN4_Data.DB_Context;
using CTN4_Data.Models.DB_CTN4;
using CTN4_Serv.Service.IService;
using CTN4_Serv.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CTN4_Serv.Service
{
    public class GioHangService : IGioHangService
    {
        public DB_CTN4_ok _db;
        public ICurrentUser _currentUser;
        public GioHangService(ICurrentUser user)
        {
            _db = new DB_CTN4_ok();
            _currentUser = user;
        }
        public List<GioHang> GetAll()
        {
            return _db.GioHangs.ToList();
        }

        public int slsanpham()
        {
            var giohang = _db.GioHangs.ToList();
            var ghct = _db.GioHangChiTiets.ToList();

            var query = from gh in giohang 
                        join a in ghct on gh.Id equals a.IdGioHang
                        where gh.IdKhachHang == _currentUser.Id
                        select new
                        {
                            sl = a.SoLuong,
                        };

            var result = query.Count();

            if (_currentUser == null)
            {
                return 0;
            }
            return result;
        }
        public GioHang GetById(Guid id)
        {
            return GetAll().FirstOrDefault(c => c.Id == id);
        }

        public bool Them(GioHang a)
        {
            try
            {
                _db.GioHangs.Add(a);
                _db.SaveChanges();
                
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool Sua(GioHang a)
        {
            try
            {
                _db.GioHangs.Update(a);
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
                _db.GioHangs.Remove(b);
                _db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        public bool Clean(Guid idKH)
        {
            try
            {
                var gh = GetAll().FirstOrDefault(c => c.Id == idKH);
                if (gh==null)
                {
                    return true;
                }
                var ghct = _db.GioHangChiTiets.ToList().Where(c => c.IdGioHang == gh.Id);
                _db.GioHangChiTiets.RemoveRange(ghct);
                _db.GioHangs.RemoveRange(gh);
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
