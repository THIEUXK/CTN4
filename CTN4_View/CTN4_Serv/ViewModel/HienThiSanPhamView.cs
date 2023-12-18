using CTN4_Data.Models.DB_CTN4;
using CTN4_Serv.ServiceJoin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CTN4_Serv.ViewModel
{
    public class HienThiSanPhamView
    {
        public List<SanPham> sanPhams;
        public List<Mau> maus;
        public List<ChatLieu> chatLieus;
        public List<DanhMuc> danhMucs;
        public List<DanhMucChiTiet> danhMucChiTiets;
        public List<DanhMucChiTiet> danhMucChiTiet;
        public List<DanhMucChiTiet> danhMucChiTiet2;
        public List<SanPhamChiTiet> sanPhamChiTiets;
        public List<KhuyenMaiSanPham> khuyenMaiSanPhams { get; set; }
        public List<ChiTietSanPhamYeuThich> sanPhamYeuThiches { get; set; } 
        public List<KhachHang> khachHangs { get; set; } 
        public PagingInfo pagingInfo { get; set; } = new PagingInfo();
        public List<SanPham> sanphampaging { get; set; } = new List<SanPham>();
        public List<DanhMucChiTiet> sanphampaging1 { get; set; } = new List<DanhMucChiTiet>();
        public int TotalItems { get; set; }
        public int ItemsPerPage { get; set; }
        public int CurrentPage { get; set; }
        public int dem;
        public int soluonghienthi { get; set; }
        public string SortOrder { get; set; }
    }
}