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
            // lay ra toan bo danh sasch idsp da dc km
            var lstkm = _db.KhuyenMaiSanPhams.Select(p => p.IdSanPham);
            var listProduct = _db.SanPhams.ToList();
            var lstDanhMuc = _db.DanhMucs.ToList();
            var lst = _db.DanhMucChiTiets.ToList();

            var lstAll = (from a in listProduct
                          join b in lst on a.Id equals b.IdSanPham
                          join c in lstDanhMuc on b.IdDanhMuc equals c.Id
                          where !lstkm.Contains(a.Id) // Thêm điều kiện kiểm tra a.Id không tồn tại trong lstkm
                          select new SanPhamDanhMucVIewModel
                          {
                              Id = a.Id,
                              MaSp = a.MaSp,
                              AnhDaiDien = a.AnhDaiDien,
                              TenSanPham = a.TenSanPham,
                              GiaNhap = a.GiaNhap,
                              GiaBan = a.GiaBan,
                              GiaNiemYet = a.GiaNiemYet,
                              TenDanhMuc = c.TenDanhMuc,
                          }).DistinctBy(x => x.Id);

            return lstAll.ToList();

        }
        public List<SanPhamDanhMucVIewModel> GetAllProductWithKhuyenMai()
        {
            var listProduct = _db.SanPhams.ToList();
            var lstDanhMuc = _db.DanhMucs.ToList();
            var lst = _db.DanhMucChiTiets.ToList();

            var lstAll = (from a in listProduct
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
                          }).DistinctBy(x => x.Id); // Thêm DistinctBy để chỉ áp dụng Distinct cho trường Id

            return lstAll.ToList();
        }

        public List<SanPhamDanhMucVIewModel> GetallKM()
        {
            var lstkm = _db.KhuyenMaiSanPhams.Select(p => p.IdSanPham).ToList();
            var listkm = _db.KhuyenMais.ToList();
            var listProduct = _db.SanPhams.ToList();
            var lstDanhMucChiTiet = _db.DanhMucChiTiets.ToList();
            var lstDanhMuc = _db.DanhMucs.ToList();

            // Truy vấn lấy tất cả sản phẩm có trong danh sách khuyến mãi và sử dụng Distinct
            var lstAll = (from a in listProduct
                          join b in lstDanhMucChiTiet on a.Id equals b.IdSanPham
                          join c in lstDanhMuc on b.IdDanhMuc equals c.Id
                          join d in _db.KhuyenMaiSanPhams.ToList() on a.Id equals d.IdSanPham
                          join e in listkm on d.IdkhuyenMai equals e.Id
                          where lstkm.Contains(a.Id) // Điều kiện chỉ lấy những sản phẩm có trong danh sách khuyến mãi
                          select new SanPhamDanhMucVIewModel
                          {
                              Id = a.Id,
                              MaSp = a.MaSp,
                              AnhDaiDien = a.AnhDaiDien,
                              TenSanPham = a.TenSanPham,
                              GiaNhap = a.GiaNhap,
                              GiaBan = a.GiaBan,
                              GiaNiemYet = a.GiaNiemYet,
                              TenDanhMuc = c.TenDanhMuc,
                              Idkm = e.Id,
                              TenKm = e.MaKhuyenMai,
                          }).DistinctBy(x => x.Id);

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
                    GiaNhap = sp.GiaNhap,
                    GiaBan = sp.GiaBan,
                    GiaNiemYet = sp.GiaNiemYet,
                }).ToList();

                var lstDanhMuc = _db.DanhMucs.ToList();
                var lst = _db.DanhMucChiTiets.ToList();

                var lstAll = (from a in listProduct
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
                              }).DistinctBy(x => x.Id);

                return lstAll.ToList();

            }
            else
            {
                var lstkm = _db.KhuyenMaiSanPhams.Select(p => p.IdSanPham);
                var listProduct = _db.SanPhams.ToList();
                var lstDanhMuc = _db.DanhMucs.ToList();
                var lst = _db.DanhMucChiTiets.ToList();
                var lstAll = (from a in listProduct
                              join b in lst on a.Id equals b.IdSanPham
                              join c in lstDanhMuc on b.IdDanhMuc equals c.Id
                              where !lstkm.Contains(a.Id) // Thêm điều kiện kiểm tra a.Id không tồn tại trong lstkm
                              where c.TenDanhMuc.ToLower().Contains(dieuKien.ToLower()) ||
                                    a.GiaNhap.ToString().Contains(dieuKien) ||
                                    a.GiaBan.ToString().Contains(dieuKien) ||
                                    a.GiaNiemYet.ToString().Contains(dieuKien) ||
                                    a.MaSp.ToLower().Contains(dieuKien.ToLower()) ||
                                    a.TenSanPham.ToLower().Contains(dieuKien.ToLower())
                              select new SanPhamDanhMucVIewModel
                              {
                                  MaSp = a.MaSp,
                                  AnhDaiDien = a.AnhDaiDien,
                                  TenSanPham = a.TenSanPham,
                                  GiaNhap = a.GiaNhap,
                                  GiaBan = a.GiaBan,
                                  GiaNiemYet = a.GiaNiemYet,
                                  TenDanhMuc = c.TenDanhMuc,
                              }).DistinctBy(x => x.Id);

                return lstAll.ToList();

            }

        }

        public List<SanPhamDanhMucVIewModel> GetAllBySearch(string MaSp)
        {
            var lstkm = _db.KhuyenMaiSanPhams.Select(p => p.IdSanPham);
            var listProduct = _db.SanPhams.ToList();
            var lstDanhMuc = _db.DanhMucs.ToList();
            var lst = _db.DanhMucChiTiets.ToList();

            var lstAll = (from a in listProduct
                          join b in lst on a.Id equals b.IdSanPham
                          join c in lstDanhMuc on b.IdDanhMuc equals c.Id
                          where !lstkm.Contains(a.Id)
                          where a.MaSp.Equals(MaSp)
                          select new SanPhamDanhMucVIewModel
                          {
                              Id = a.Id,
                              MaSp = a.MaSp,
                              AnhDaiDien = a.AnhDaiDien,
                              TenSanPham = a.TenSanPham,
                              GiaNhap = a.GiaNhap,
                              GiaBan = a.GiaBan,
                              GiaNiemYet = a.GiaNiemYet,
                              TenDanhMuc = c.TenDanhMuc,
                          }).DistinctBy(x => x.Id);

            return lstAll.ToList();
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
