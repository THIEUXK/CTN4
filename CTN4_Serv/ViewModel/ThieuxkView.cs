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
        public List<SanPham> sanPhams { get; set; }
        public List<SanPhamChiTiet> sanPhamChiTiets { get; set; }
        public SanPhamChiTiet SanPhamChiTiet { get; set; }
        public List<Anh> AhList { get; set; }
        public Guid IdMau { get; set; }

        public SanPham SanPham { get; set; }
        public List<HoaDonChiTiet> hoaDonChiTiets { get; set; }

        public HoaDon HoaDon { get; set; }

    }
}