namespace CTN4_Data.Models.DB_CTN4
{
    public class ChiTietSanPhamYeuThich
    {
        public Guid Id { get; set; }

        public Guid? IdSanPham { get; set; }
        public Guid? IdKhachHang { get; set; }
        public virtual KhachHang? KhachHang { get; set; }
        public virtual SanPham? SanPham { get; set; }

    }
}
