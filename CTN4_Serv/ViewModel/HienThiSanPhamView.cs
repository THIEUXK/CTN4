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
        public List<SanPhamChiTiet> sanPhamChiTiets;
        public List<DanhMuc> danhMucs;
        public List<DanhMucChiTiet> danhMucChiTiets;
        public List<DanhMucChiTiet> danhMucChiTiet;
        public List<DanhMucChiTiet> danhMucChiTiet2;
    }
}