namespace CTN4.Models
{
    public class KhuyenMaiChiTiet
    {
        public Guid Id { get; set; }
        public Guid? IdSanPham { get;set; }
        public Guid? IdKhuyenMai { get; set; }

        public KhuyenMai? KhuyenMai { get; set;}
        public SanPhamChiTiet? SanPhamChiTiet { get; set; }
    }
}
