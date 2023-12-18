using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CTN4_Data.Models.DB_CTN4;

namespace CTN4_Serv.ViewModel
{
    public class ThieuxkView
    {
        public List<LichSuDonHang> LichSuDonHangs { get; set; }
        
        public List<SanPhamChiTiet> sanPhamChiTiets { get; set; }
        public List<DanhMuc> danhMucs { get; set; }
        public List<DanhMucChiTiet> danhMucChiTiets { get; set; }
        public List<SanPham> sanPhams { get; set; }
        public SanPhamChiTiet SanPhamChiTiet { get; set; }
        public List<Anh> AhList { get; set; }
        public Guid IdMau { get; set; }
        public List<GiamGiaChiTiet> GiamGiaChiTiets { get; set; }
        public SanPham SanPham { get; set; }
        public DanhMuc DanhMuc { get; set; }
        public List<HoaDonChiTiet> hoaDonChiTiets { get; set; }

        public HoaDon HoaDon { get; set; }


    }
}