using CTN4_Data.Models.DB_CTN4;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CTN4_Serv.ViewModel
{
    public class SanPhamBanChayView
    {
        public List<SanPham> sanPhams {get;set;}
        public List<DanhMucChiTiet> danhMucChiTiets {get;set;}
        public List<DanhMucChiTiet> danhMucChiTiets1 {get;set;}
        public List<ChiTietSanPhamYeuThich> sanPhamYeuThiches { get; set; } 
    }
}
