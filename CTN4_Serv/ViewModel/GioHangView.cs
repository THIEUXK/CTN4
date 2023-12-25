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
        public List<Guid> check11 { get; set; }
        public DiaChiNhanHang? DiaChiNhanHang { get; set; }
        public KhachHang KhachHang { get; set; }
        public List<Anh> anhs { get; set; }
        public IEnumerable<GioHangChiTiet> GioHangChiTiets { get; set; }
        public float TongTien { get; set; }
        public List<SanPhamChiTiet> sanPhamChiTietsList { get; set; }
        public Guid idGH { get; set; }
        public float TongTienGioHang { get; set; }
        public List<SelectListItem> listPhuongThucs { get; set; }
        public List<SelectListItem> listDiaChi { get; set; }
        public List<GiamGia> GiamGias { get; set; }
        public float tienhanga { get; set; }
        public string DiachiNhanChiTiet { get; set; }
        public string Sodienthoai { get; set; }
        public string Email { get; set; }
        public Guid idphuongthuc { get; set; }
        public Guid IdDiaChi { get; set; }
        public Guid IdMaGiam { get; set; }
        public string addDiaChi { get; set; }
        public string ghiChu { get; set; }
        public float tienshipb { get; set; }
        public float tongtienb { get; set; }
        public float TienCuoiCungb { get; set; }
        public float tiengiamb { get; set; }
        public string name { get; set; }
        public string tenmagiam { get; set; }
    }
}
