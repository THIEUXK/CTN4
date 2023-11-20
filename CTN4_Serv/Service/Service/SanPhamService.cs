using CTN4_Data.DB_Context;
using CTN4_Data.Models.DB_CTN4;
using CTN4_Serv.Service.IService;
using CTN4_Serv.ViewModel.banhangview;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace CTN4_Serv.Service
{
    public class SanPhamService : ISanPhamService
    {
        public DB_CTN4_ok _db;

        public SanPhamService()
        {
            _db = new DB_CTN4_ok();
        }
        public List<SanPhamDanhMucVIewModel> GetAllProduct()
        {
            var listProduct = _db.SanPhams.ToList();
            var lstDanhMuc = _db.DanhMucs.ToList();
            var lst = _db.DanhMucChiTiets.ToList();
            var lstAll = from a in listProduct
                         join b in lst on a.Id equals b.IdSanPham
                         join c in lstDanhMuc on b.IdDanhMuc equals c.Id
                         select new SanPhamDanhMucVIewModel
                         {
                             Id= a.Id,
                             MaSp = a.MaSp,
                             AnhDaiDien = a.AnhDaiDien,
                             TenSanPham = a.TenSanPham,
                             GiaNhap = a.GiaNhap,
                             GiaBan = a.GiaBan,
                             GiaNiemYet = a.GiaNiemYet,
                             TenDanhMuc = c.TenDanhMuc,
                         };
            return lstAll.ToList();
        }
        public List<SanPhamDanhMucVIewModel> GetAllProductWithKhuyenMai()
        {
            var listProduct = _db.SanPhams.ToList();
            var lstDanhMuc = _db.DanhMucs.ToList();
            var lst = _db.DanhMucChiTiets.ToList();
            var lstAll = from a in listProduct
                         join b in lst on a.Id equals b.IdSanPham
                         join c in lstDanhMuc on b.IdDanhMuc equals c.Id
                         join d in _db.KhuyenMaiSanPhams.ToList() on a.Id equals d.IdSanPham
                         join e in _db.KhuyenMais.ToList() on d.IdkhuyenMai equals e.Id
                         select new SanPhamDanhMucVIewModel
                         {
                             Idkm = e.Id,
                             Id = a.Id,
                             MaSp = a.MaSp,
                             AnhDaiDien = a.AnhDaiDien,
                             TenSanPham = a.TenSanPham,
                             GiaNhap = a.GiaNhap,
                             GiaBan = a.GiaBan,
                             GiaNiemYet = a.GiaNiemYet,
                             TenDanhMuc = c.TenDanhMuc,
                             
                             
                         };
            return lstAll.ToList();
        }
        public List<SanPham> GetAll()
        {
            return _db.SanPhams.Include(c => c.ChatLieu).Include(c => c.NSX).ToList();
        }
        public List<SanPhamDanhMucVIewModel> TimSanPhamTheoDieuKien(string dieuKien)
        {
            if (string.IsNullOrEmpty(dieuKien))
            {
                var sanPhamList = _db.SanPhams.ToList();

                var listProduct = sanPhamList.Select(sp => new SanPhamDanhMucVIewModel
                {
                    Id = sp.Id,
                    MaSp = sp.MaSp,
                    TenSanPham = sp.TenSanPham,
                    AnhDaiDien = sp.AnhDaiDien,
                    // Các thuộc tính khác của SanPhamDanhMucVIewModel cần được ánh xạ tương ứng với SanPham
                    GiaNhap = sp.GiaNhap,
                    GiaBan = sp.GiaBan,
                    GiaNiemYet = sp.GiaNiemYet,
                    // Ví dụ: TenDanhMuc là một thuộc tính giả sử bạn có thể thêm vào từ một nguồn dữ liệu khác
                   
                }).ToList();
                var lstDanhMuc = _db.DanhMucs.ToList();
                var lst = _db.DanhMucChiTiets.ToList();
                var lstAll = from a in listProduct
                             join b in lst on a.Id equals b.IdSanPham
                             join c in lstDanhMuc on b.IdDanhMuc equals c.Id
                             select new SanPhamDanhMucVIewModel
                             {
                                 MaSp = a.MaSp,
                                 AnhDaiDien = a.AnhDaiDien,
                                 TenSanPham = a.TenSanPham,
                                 GiaNhap = a.GiaNhap,
                                 GiaBan = a.GiaBan,
                                 GiaNiemYet = a.GiaNiemYet,
                                 TenDanhMuc = c.TenDanhMuc,
                             };
                return lstAll.ToList();
            }
            else
            {
                var listProduct = _db.SanPhams.ToList();
                var lstDanhMuc = _db.DanhMucs.ToList();
                var lst = _db.DanhMucChiTiets.ToList();
                var lstAll = from a in listProduct
                             join b in lst on a.Id equals b.IdSanPham
                             join c in lstDanhMuc on b.IdDanhMuc equals c.Id
                             where c.TenDanhMuc.ToLower().Contains(dieuKien.ToLower())||
                             a.GiaNhap.ToString().Contains(dieuKien) ||
                             a.GiaBan.ToString().Contains(dieuKien) ||
                             a.GiaNiemYet.ToString().Contains(dieuKien) ||
                             a.MaSp.ToLower().Contains(dieuKien.ToLower()) ||
                             a.TenSanPham.ToLower().Contains(dieuKien.ToLower())
                             select new SanPhamDanhMucVIewModel
                             {
                                 MaSp = a.MaSp,
                                 AnhDaiDien = a.AnhDaiDien,
                                 TenSanPham =a.TenSanPham,
                                 GiaNhap =a.GiaNhap,
                                 GiaBan  = a.GiaBan,
                                 GiaNiemYet = a.GiaNiemYet,
                                 TenDanhMuc =c.TenDanhMuc,
                             };
                return lstAll.ToList();
            }
      
        }

        public List<SanPham> GetAllBySearch(string MaSp)
        {
            if(string.IsNullOrEmpty(MaSp))
            {
                return _db.SanPhams.ToList();
            }
            else
            {
               
                var product = _db.SanPhams.Where(p => p.MaSp.Equals(MaSp)).ToList();
                return product;
            }
            
            
        }
        public SanPham GetById(Guid id)
        {
            return GetAll().FirstOrDefault(c => c.Id == id);
        }

        public bool Them(SanPham a)
        {
            try
            {
                _db.SanPhams.Add(a);
                _db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool Sua(SanPham a)
        {
            try
            {
                _db.SanPhams.Update(a);
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
                _db.SanPhams.Remove(b);
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
