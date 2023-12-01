using CTN4_Data.Models.DB_CTN4;
using CTN4_Serv.ViewModel.banhangview;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CTN4_Serv.Service.IService
{
    public interface ISanPhamService
    {
        public List<SanPhamDanhMucVIewModel> GetAllProduct();
        public List<SanPham> GetAll();
        public List<SanPhamDanhMucVIewModel> GetAllBySearch(string MaSp);
        public List<SanPhamDanhMucVIewModel> TimSanPhamTheoDieuKien(string dieuKien);
        public List<SanPhamDanhMucVIewModel> GetAllProductWithKhuyenMai();
        public List<SanPhamDanhMucVIewModel> GetallKM();
        public SanPham GetById(Guid id);
        public bool Them(SanPham a);
        public bool Sua(SanPham a);
        public bool Xoa(Guid id);
    }
}
