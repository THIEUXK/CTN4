namespace CTN4_Data.Models.DB_CTN4
{
    public class KhuyenMaiSanPham
    {
        public Guid Id { get; set; }
        public Guid? IdSanPhamChiTiet { get; set; }
        public Guid? IdkhuyenMai { get; set; }

        public SanPhamChiTiet? SanPhamChiTiet { get; set; }
        public KhuyenMai? KhuyenMai { get; set; }
    }
}
