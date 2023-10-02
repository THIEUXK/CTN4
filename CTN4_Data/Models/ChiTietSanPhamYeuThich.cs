namespace CTN4_Data.Models.DB_CTN4
{
    public class ChiTietSanPhamYeuThich
    {
        public Guid Id { get; set; }

        public Guid? IdSanPhamChiTiet { get; set; }
        public Guid? IdSanPhamYeuThich { get; set; }
        public SanPhamYeuThich? SanPhamYeuThich { get; set; }
        public SanPhamChiTiet? SanPhamChiTiet { get; set; }

    }
}
