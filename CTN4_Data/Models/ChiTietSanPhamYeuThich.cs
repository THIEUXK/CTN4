namespace CTN4_Data.Models.DB_CTN4
{
    public class ChiTietSanPhamYeuThich
    {
        public Guid Id { get; set; }

        public Guid? IdSanPham { get; set; }
        public Guid? IdSanPhamYeuThich { get; set; }
        public virtual SanPhamYeuThich? SanPhamYeuThich { get; set; }
        public virtual SanPham? SanPham { get; set; }

    }
}
