using CTN4_Data.DB_Context;
using CTN4_Data.Models.DB_CTN4;
using CTN4_Serv.Service.IService;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CTN4_Serv.Service
{
    public class NhanVienService : INhanVienService
    {
        public DB_CTN4_ok _db;

        public NhanVienService()
        {
            _db = new DB_CTN4_ok();
        }
        public List<NhanVien> GetAll()
        {
            return _db.NhanViens.ToList();
        } public List<NhanVien> GetAlls()
        {
            return _db.NhanViens.Include(c=>c.ChucVu).ToList();
        }

        public NhanVien GetById(Guid id)
        {
            return GetAlls().FirstOrDefault(c => c.Id == id);
        }
		public NhanVien GetByIdChucVu(Guid id)
		{
			return _db.NhanViens.FirstOrDefault(c => c.IdChucVu == id);
		}
		public bool Them(NhanVien a)
        {
            try
            {
                _db.NhanViens.Add(a);
                _db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool Sua(NhanVien a)
        {
            try
            {
                _db.NhanViens.Update(a);
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
                _db.NhanViens.Remove(b);
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
