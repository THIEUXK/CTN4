using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CTN4_Data.Models.DB_CTN4;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CTN4_Serv.ViewModel
{
    public class GioHangView
    {
        public List<Anh> anhs {  get; set; }
        public IEnumerable<GioHangChiTiet> GioHangChiTiets { get; set; }
        public float TongTien { get; set; }
        public List<SanPhamChiTiet> sanPhamChiTietsList { get; set; }
        public Guid idGH { get; set; }
        public float TongTienGioHang { get; set; }
        public List<SelectListItem> listPhuongThucs{ get; set; }
        public Guid idphuongthuc { get; set; }
    }
}
