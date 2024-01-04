using CTN4_Data.DB_Context;
using CTN4_Data.Models.DB_CTN4;
using CTN4_Serv.Service.IService;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CTN4_Data.Models;

namespace CTN4_Serv.Service
{
    public class DanhGiaSanPhamService : IDanhGiaSanPhamService
    {
        public DB_CTN4_ok _db;

        public DanhGiaSanPhamService()
        {
            _db = new DB_CTN4_ok();
        }
        public List<DanhGiaSanPham> GetAll()
        {
            return _db.DanhGiaSanPhams.Include(c => c.SanPham).Include(c=>c.KhachHang).ToList();
        }

        public DanhGiaSanPham GetById(Guid id)
        {
            return GetAll().FirstOrDefault(c => c.Id == id);
        } public DanhGiaSanPham GetDanhGiaByIdSanPhamAndIdKhachHang(Guid idSanPham, Guid idKhachHang)
    {
        // Thực hiện truy vấn trong cơ sở dữ liệu để kiểm tra xem đã có đánh giá từ người dùng cho sản phẩm chưa
        return _db.DanhGiaSanPhams
            .FirstOrDefault(d => d.IdSanPham == idSanPham && d.IdKhachHang == idKhachHang);
    }

        public bool Them(DanhGiaSanPham a)
        {
            try
            {
                _db.DanhGiaSanPhams.Add(a);
                _db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool Sua(DanhGiaSanPham a)
        {
            try
            {
                _db.DanhGiaSanPhams.Update(a);
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
                _db.DanhGiaSanPhams.Remove(b);
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
