using CTN4_Data.Models.DB_CTN4;

namespace CTN4_View.Areas.Admin.Controllers.QuanLyHoaDonThieuxk.viewMode
{
    public class Thi1View
    {
        public List<int> IdHD { get; set; }
        public List<SanPham> sanPhams { get; set; }
        public List<SanPhamTam> SanPhamTams { get; set; }
        public List<SanPhamChiTiet> SanPhamChiTiets { get; set; }
        public List<KhuyenMaiSanPham> KhuyenMaiSanPhams { get; set; }
    }
}
