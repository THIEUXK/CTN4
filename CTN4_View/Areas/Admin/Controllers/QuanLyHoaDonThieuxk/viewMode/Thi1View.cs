using CTN4_Data.Models.DB_CTN4;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CTN4_View.Areas.Admin.Controllers.QuanLyHoaDonThieuxk.viewMode
{
    public class Thi1View
    {
        public List<Guid> check11 { get; set; }
        public List<HoaDonChiTiet> HoaDonChiTiets { get; set; }
        public int idHD { get; set; }
        public HoaDon HoaDon { get; set; }
        public List<int> IdHD { get; set; }
        public List<SanPham> sanPhams { get; set; }
        public List<SanPhamTam> SanPhamTams { get; set; }
        public List<SanPhamChiTiet> SanPhamChiTiets { get; set; }
        public List<KhuyenMaiSanPham> KhuyenMaiSanPhams { get; set; }
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
