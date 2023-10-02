namespace CTN4_Data.Models.DB_CTN4
{
    public class SanPhamYeuThich
    {
        public Guid Id { get; set; }
        public Guid? IdKhachHang { get; set; }
        public KhachHang? KKhachHang { get; set; }
        public List<ChiTietSanPhamYeuThich> CTietSanPhamYeuThiches { get; set; }
    }
}
