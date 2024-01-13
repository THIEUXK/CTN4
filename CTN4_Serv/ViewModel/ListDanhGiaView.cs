using CTN4_Data.Models;
using CTN4_Data.Models.DB_CTN4;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CTN4_Serv.ViewModel
{
    public class ListDanhGiaView
    {
         public List<DanhGiaSanPham> SanPhamDaDanhGia { get; set; }
         public List<DanhGiaSanPham> DuyetDanhGia { get; set; }
         public List<DanhGiaSanPham> DanhGiaBiAn { get; set; }
    }
}
