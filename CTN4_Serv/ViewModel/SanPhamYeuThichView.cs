using CTN4_Data.Models.DB_CTN4;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CTN4_Serv.ViewModel
{
    public class SanPhamYeuThichView
    {
        public KhachHang KhachHang { get; set; }
        public List<ChiTietSanPhamYeuThich> chiTietSanPhamYeuThiches { get; set; }
    }
}
